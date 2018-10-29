using System.Collections.Generic;
using System.Linq;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Trms.Domain.Areas.Models.WorkItems
{
    public class WorkItemFields
    {
        public IReadOnlyCollection<WorkItemField> Entries { get; }

        public WorkItemField this[string name]
        {
            get
            {
                return Entries.SingleOrDefault(f => f.Name == name);
            }
        }

        public WorkItemFields(IReadOnlyCollection<WorkItemField> entries)
        {
            Entries = entries;
            Guard.ObjectNotNull(() => entries);
        }
    }
}