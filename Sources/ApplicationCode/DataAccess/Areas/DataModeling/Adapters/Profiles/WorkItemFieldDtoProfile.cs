using AutoMapper;
using Mmu.Trms.DataAccess.Areas.DataModeling.Dtos;
using Mmu.Trms.Domain.Areas.Models.WorkItems;

namespace Mmu.Trms.DataAccess.Areas.DataModeling.Adapters.Profiles
{
    public class WorkItemFieldDtoProfile : Profile
    {
        public WorkItemFieldDtoProfile()
        {
            CreateMap<WorkItemField, WorkItemFieldDto>()
                .ForMember(d => d.Name, c => c.MapFrom(f => f.Name))
                .ForMember(d => d.Value, c => c.MapFrom(f => f.Value));
        }
    }
}
