using AutoMapper;
using Mmu.Mlh.Adapters.Areas.Services;
using Mmu.Trms.DataAccess.Areas.DataModeling.Dtos;
using Mmu.Trms.Domain.Areas.Models.WorkItems;

namespace Mmu.Trms.DataAccess.Areas.DataModeling.Adapters.Implementation
{
    public class WorkItemDtoAdapter : AdapterBase<WorkItemDto, WorkItem>
    {
        private readonly IAdapterResolver _adapterResolver;

        public WorkItemDtoAdapter(IMapper mapper, IAdapterResolver adapterResolver) : base(mapper)
        {
            _adapterResolver = adapterResolver;
        }

        public override WorkItem Adapt(WorkItemDto dto)
        {
            var relationAdapter = _adapterResolver.ResolveByAdapterType<IWorkItemRelationDtoAdapter>();
            var fieldAdapter = _adapterResolver.ResolveByAdapterType<IWorkItemFieldDtoAdapter>();

            return new WorkItem(
                dto.Id,
                relationAdapter.Adapt(dto.Relations),
                fieldAdapter.Adapt(dto.Fields));
        }
    }
}