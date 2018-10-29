using System.Collections.Generic;
using Mmu.Mlh.LanguageExtensions.Areas.Collections;
using Mmu.Trms.Domain.Areas.Models.WorkItems;
using Mmu.Trms.DomainServices.Areas.Factories.Servants;
using Mmu.Trms.DomainServices.Infrastructure.Constants;

namespace Mmu.Trms.DomainServices.Areas.Factories.Implementation
{
    public class WorkItemReleaseFactory : IWorkItemReleaseFactory
    {
        private readonly IWorkItemReleaseLogFactory _releaseLogFactory;

        public WorkItemReleaseFactory(IWorkItemReleaseLogFactory releaseLogFactory)
        {
            _releaseLogFactory = releaseLogFactory;
        }

        public WorkItem CreateRelease(string version, int parentWorkItemId, IReadOnlyCollection<WorkItem> releasedWorkItems)
        {
            var fields = CreateFields(version, releasedWorkItems);
            var relations = CreateRelations(parentWorkItemId, releasedWorkItems);

            return new WorkItem(
                0,
                relations,
                fields
            );
        }

        private WorkItemFields CreateFields(string version, IReadOnlyCollection<WorkItem> releasedWorkItems)
        {
            var titleField = new WorkItemField("Title", $"Release {version}");
            var versionField = new WorkItemField("Custom.Version", version);

            var releaseLog = _releaseLogFactory.CreateReleaseLog(version, releasedWorkItems);
            var descriptionField = new WorkItemField("Description", releaseLog);

            var entries = new List<WorkItemField>
            {
                titleField,
                descriptionField,
                versionField
            };

            return new WorkItemFields(entries);
        }

        private static WorkItemRelations CreateRelations(int parentWorkItemId, IReadOnlyCollection<WorkItem> releasedWorkItems)
        {
            var entries = new List<WorkItemRelation> { new WorkItemRelation(parentWorkItemId, KnownWorkItemRelationTypes.Parent) };
            releasedWorkItems.ForEach(wi => entries.Add(new WorkItemRelation(wi.Id, KnownWorkItemRelationTypes.Related)));

            return new WorkItemRelations(entries);
        }
    }
}