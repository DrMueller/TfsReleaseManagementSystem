using System.Collections.Generic;
using System.Text;
using Mmu.Trms.Domain.Areas.Models.WorkItems;
using Mmu.Trms.DomainServices.Areas.Services;
using Mmu.Trms.DomainServices.Infrastructure.Constants;

namespace Mmu.Trms.DomainServices.Areas.Factories.Servants.Implementation
{
    internal class WorkItemReleaseLogFactory : IWorkItemReleaseLogFactory
    {
        private readonly ITfsPathsService _tfsPathsService;

        public WorkItemReleaseLogFactory(ITfsPathsService tfsPathsService)
        {
            _tfsPathsService = tfsPathsService;
        }

        public string CreateReleaseLog(string version, IEnumerable<WorkItem> releasedWorkItems)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Released with Version {version}:");
            sb.AppendLine("<ul>");

            foreach (var workItem in releasedWorkItems)
            {
                sb.Append("<li>");
                sb.Append(CreateLink(workItem));
                sb.AppendLine("</li>");
            }

            sb.AppendLine("</ul>");
            return sb.ToString();
        }

        private string CreateLink(WorkItem workItem)
        {
            var displayText = $"{workItem.Id} - {workItem.Fields[KnownWorkItemFieldNames.Title].Value}";
            const string LinkTemplate = "<a href=\"{0}\">{1}</a>";

            var projectPath = string.Concat(
                _tfsPathsService.GetDefaultProjectPath(),
                "/_workitems/edit/",
                workItem.Id);

            var result = string.Format(LinkTemplate, projectPath, displayText);
            return result;
        }
    }
}