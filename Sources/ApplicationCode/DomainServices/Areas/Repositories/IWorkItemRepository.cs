using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Trms.Domain.Areas.Models;
using Mmu.Trms.Domain.Areas.Models.WorkItems;

namespace Mmu.Trms.DomainServices.Areas.Repositories
{
    public interface IWorkItemRepository
    {
        Task<WorkItem> CreateWorkItemAsync(string workItemTypeName, WorkItem workItem);

        Task<IReadOnlyCollection<WorkItem>> GetWorkItemsByIdsAsync(IReadOnlyCollection<int> workItemIds);
    }
}