using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mmu.Mlh.Adapters.Areas.Services;
using Mmu.Mlh.RestExtensions.Areas.RestProxies;
using Mmu.Trms.Application.Infrastructure.Settings.Services;
using Mmu.Trms.DataAccess.Areas.DataModeling.Dtos;
using Mmu.Trms.Domain.Areas.Models;
using Mmu.Trms.DomainServices.Areas.Repositories;

namespace Mmu.Trms.DataAccess.Areas.Repositories
{
    public class BuildChangeRepository : IBuildChangeRepository
    {
        private readonly IAdapterResolver _adapterResolver;
        private readonly string _buildChangesFunctionPath;
        private readonly IRestProxy _restProxy;

        public BuildChangeRepository(
            IRestProxy restProxy,
            IAdapterResolver adapterResolver,
            IAppSettingsProvider settingsProvider)
        {
            _restProxy = restProxy;
            _adapterResolver = adapterResolver;
            _buildChangesFunctionPath = settingsProvider.ProvideSettings().AzureFunctionsSettings.GetBuildChangesByBuildIdPath;
        }

        public async Task<IReadOnlyCollection<BuildChange>> GetBuildChangesByBuildId(long buildId)
        {
            var functionPath = new Uri(_buildChangesFunctionPath.Replace("{buildId}", buildId.ToString()));

            var dtos = await _restProxy.PerformCallAsync<List<BuildChangeDto>>(
                builderFactory => builderFactory.StartBuilding(functionPath)
                    .Build());

            if (dtos == null)
            {
                return new List<BuildChange>();
            }

            var adapter = _adapterResolver.ResolveByAdapteeTypes<BuildChangeDto, BuildChange>();
            var result = dtos.Select(dto => adapter.Adapt(dto)).ToList();
            return result;
        }
    }
}