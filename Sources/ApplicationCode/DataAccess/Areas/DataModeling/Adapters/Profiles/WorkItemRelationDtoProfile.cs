using AutoMapper;
using Mmu.Trms.DataAccess.Areas.DataModeling.Dtos;
using Mmu.Trms.Domain.Areas.Models.WorkItems;

namespace Mmu.Trms.DataAccess.Areas.DataModeling.Adapters.Profiles
{
    public class WorkItemRelationDtoProfile : Profile
    {
        public WorkItemRelationDtoProfile()
        {
            CreateMap<WorkItemRelation, WorkItemRelationDto>()
                .ForMember(d => d.RelationTypeDescription, c => c.MapFrom(f => f.RelationTypeDescription))
                .ForMember(d => d.TargetWorkItemId, c => c.MapFrom(f => f.TargetWorkItemId));
        }
    }
}
