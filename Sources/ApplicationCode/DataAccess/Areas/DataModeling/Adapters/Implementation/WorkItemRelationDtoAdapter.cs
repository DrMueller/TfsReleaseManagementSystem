using System.Collections.Generic;
using System.Linq;
using Mmu.Trms.DataAccess.Areas.DataModeling.Dtos;
using Mmu.Trms.Domain.Areas.Models.WorkItems;

namespace Mmu.Trms.DataAccess.Areas.DataModeling.Adapters.Implementation
{
    public class WorkItemRelationDtoAdapter : IWorkItemRelationDtoAdapter
    {
        public WorkItemRelations Adapt(IReadOnlyCollection<WorkItemRelationDto> dtos)
        {
            if (dtos == null)
            {
                return new WorkItemRelations(new List<WorkItemRelation>());
            }

            var entries = dtos.Select(f => new WorkItemRelation(f.TargetWorkItemId, f.RelationTypeDescription)).ToList();
            return new WorkItemRelations(entries);
        }
    }
}