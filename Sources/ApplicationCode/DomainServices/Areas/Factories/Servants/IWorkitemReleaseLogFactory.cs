using System.Collections.Generic;
using Mmu.Trms.Domain.Areas.Models.WorkItems;

namespace Mmu.Trms.DomainServices.Areas.Factories.Servants
{
    public interface IWorkItemReleaseLogFactory
    {
        string CreateReleaseLog(string version, IEnumerable<WorkItem> releasedWorkItems);
    }
}