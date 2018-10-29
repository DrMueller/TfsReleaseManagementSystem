using AutoMapper;
using Mmu.Trms.DataAccess.Areas.DataModeling.Dtos;
using Mmu.Trms.Domain.Areas.Models.WorkItems;

namespace Mmu.Trms.DataAccess.Areas.DataModeling.Adapters.Profiles
{
    public class CreateWorkItemDtoProfile : Profile
    {
        public CreateWorkItemDtoProfile()
        {
            CreateMap<WorkItem, CreateWorkItemDto>()
                .ForMember(d => d.Fields, c => c.MapFrom(f => f.Fields.Entries))
                .ForMember(d => d.Relations, c => c.MapFrom(f => f.Relations.Entries))
                .ForMember(d => d.WorkItemTypeName, c => c.Ignore());
        }
    }
}