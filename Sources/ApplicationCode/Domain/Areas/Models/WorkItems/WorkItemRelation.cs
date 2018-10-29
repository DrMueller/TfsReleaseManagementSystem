using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Trms.Domain.Areas.Models.WorkItems
{
    public class WorkItemRelation
    {
        public string RelationTypeDescription { get; }
        public int TargetWorkItemId { get; }

        public WorkItemRelation(int targetWorkItemId, string relationTypeDescription)
        {
            Guard.StringNotNullOrEmpty(() => relationTypeDescription);

            TargetWorkItemId = targetWorkItemId;
            RelationTypeDescription = relationTypeDescription;
        }
    }
}