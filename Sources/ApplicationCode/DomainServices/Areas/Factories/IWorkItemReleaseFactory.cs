using System.Collections.Generic;
using Mmu.Trms.Domain.Areas.Models;
using Mmu.Trms.Domain.Areas.Models.WorkItems;

namespace Mmu.Trms.DomainServices.Areas.Factories
{
    public interface IWorkItemReleaseFactory
    {
        WorkItem CreateRelease(string version, int parentWorkItemId, IReadOnlyCollection<WorkItem> releasedWorkItems);
    }
}