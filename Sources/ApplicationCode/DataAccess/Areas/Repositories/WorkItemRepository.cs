using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mmu.Mlh.Adapters.Areas.Services;
using Mmu.Mlh.RestExtensions.Areas.Models;
using Mmu.Mlh.RestExtensions.Areas.RestProxies;
using Mmu.Trms.Application.Infrastructure.Settings.Models;
using Mmu.Trms.Application.Infrastructure.Settings.Services;
using Mmu.Trms.DataAccess.Areas.DataModeling.Dtos;
using Mmu.Trms.Domain.Areas.Models.WorkItems;
using Mmu.Trms.DomainServices.Areas.Repositories;

namespace Mmu.Trms.DataAccess.Areas.Repositories
{
    public class WorkItemRepository : IWorkItemRepository
    {
        private readonly IAdapterResolver _adapterResolver;
        private readonly IRestProxy _restProxy;
        private readonly AzureFunctionsSettings _settings;

        public WorkItemRepository(
            IRestProxy restProxy,
            IAppSettingsProvider settingsProvider,
            IAdapterResolver adapterResolver)
        {
            _restProxy = restProxy;
            _adapterResolver = adapterResolver;
            _settings = settingsProvider.ProvideSettings().AzureFunctionsSettings;
        }

        public async Task<WorkItem> CreateWorkItemAsync(string workItemTypeName, WorkItem workItem)
        {
            var createWorkItemDto = _adapterResolver.ResolveByAdapteeTypes<CreateWorkItemDto, WorkItem>().Adapt(workItem);
            createWorkItemDto.WorkItemTypeName = workItemTypeName;
            var functionUri = new Uri(_settings.PostWorkItemPath);

            var returnedDto = await _restProxy.PerformCallAsync<WorkItemDto>(
                b => b.StartBuilding(functionUri, RestCallMethodType.Post)
                    .WithBody(new RestCallBody(createWorkItemDto))
                    .Build());

            return _adapterResolver.ResolveByAdapteeTypes<WorkItemDto, WorkItem>().Adapt(returnedDto);
        }

        public async Task<IReadOnlyCollection<WorkItem>> GetWorkItemsByIdsAsync(IReadOnlyCollection<int> workItemIds)
        {
            var idsString = string.Join(",", workItemIds);
            var functionUri = new Uri(_settings.GetWorkItemsByIdsPath + "&workItemIds=" + idsString);

            var returnedDtos = await _restProxy.PerformCallAsync<List<WorkItemDto>>(
                b => b.StartBuilding(functionUri)
                    .Build());

            var adapter = _adapterResolver.ResolveByAdapteeTypes<WorkItemDto, WorkItem>();
            var result = returnedDtos.Select(dto => adapter.Adapt(dto)).ToList();
            return result;
        }
    }
}