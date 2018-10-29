namespace Mmu.Trms.Domain.Areas.Models
{
    public class WorkItemIdParsingResult
    {
        public bool IsSuccess { get; }
        public int WorkItemId { get; }

        public WorkItemIdParsingResult(bool isSuccess, int workItemId)
        {
            IsSuccess = isSuccess;
            WorkItemId = workItemId;
        }
    }
}