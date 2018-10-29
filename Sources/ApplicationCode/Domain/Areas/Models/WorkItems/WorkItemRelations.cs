using System.Collections.Generic;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Trms.Domain.Areas.Models.WorkItems
{
    public class WorkItemRelations
    {
        public IReadOnlyCollection<WorkItemRelation> Entries { get; }

        public WorkItemRelations(IReadOnlyCollection<WorkItemRelation> entries)
        {
            Guard.ObjectNotNull(() => entries);

            Entries = entries;
        }
    }
}