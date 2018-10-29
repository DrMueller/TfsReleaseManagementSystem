using System;
using AutoMapper;
using Mmu.Mlh.Adapters.Areas.Services;
using Mmu.Trms.DataAccess.Areas.DataModeling.Dtos;
using Mmu.Trms.Domain.Areas.Models.WorkItems;

namespace Mmu.Trms.DataAccess.Areas.DataModeling.Adapters.Implementation
{
    public class CreateWorkItemDtoAdapter : AdapterBase<CreateWorkItemDto, WorkItem>
    {
        public CreateWorkItemDtoAdapter(IMapper mapper) : base(mapper)
        {
        }

        public override WorkItem Adapt(CreateWorkItemDto dto)
        {
            throw new NotImplementedException();
        }
    }
}