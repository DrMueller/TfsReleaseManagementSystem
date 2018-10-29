namespace Mmu.Trms.Domain.Areas.Models.WorkItems
{
    public class WorkItem
    {
        public WorkItemFields Fields { get; }
        public int Id { get; }
        public WorkItemRelations Relations { get; }

        public WorkItem(
            int id,
            WorkItemRelations relations,
            WorkItemFields fields)
        {
            Id = id;
            Relations = relations;
            Fields = fields;
        }
    }
}