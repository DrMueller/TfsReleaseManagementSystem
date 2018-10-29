using System.Collections.Generic;
using System.Linq;
using Mmu.Trms.DataAccess.Areas.DataModeling.Dtos;
using Mmu.Trms.Domain.Areas.Models.WorkItems;

namespace Mmu.Trms.DataAccess.Areas.DataModeling.Adapters.Implementation
{
    public class WorkItemFieldDtoAdapter : IWorkItemFieldDtoAdapter
    {
        public WorkItemFields Adapt(IReadOnlyCollection<WorkItemFieldDto> dtos)
        {
            if (dtos == null)
            {
                return new WorkItemFields(new List<WorkItemField>());
            }

            var entries = dtos.Select(f => new WorkItemField(f.Name, f.Value)).ToList();
            return new WorkItemFields(entries);
        }
    }
}