using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Trms.Domain.Areas.Models.WorkItems
{
    public class WorkItemField
    {
        public string Name { get; }
        public object Value { get; }

        public WorkItemField(string name, object value)
        {
            Guard.StringNotNullOrEmpty(() => name);

            Name = name;
            Value = value;
        }
    }
}