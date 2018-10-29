﻿using System.Collections.Generic;
using Mmu.Trms.DataAccess.Areas.DataModeling.Dtos;
using Mmu.Trms.Domain.Areas.Models.WorkItems;

namespace Mmu.Trms.DataAccess.Areas.DataModeling.Adapters
{
    public interface IWorkItemRelationDtoAdapter
    {
        WorkItemRelations Adapt(IReadOnlyCollection<WorkItemRelationDto> dtos);
    }
}