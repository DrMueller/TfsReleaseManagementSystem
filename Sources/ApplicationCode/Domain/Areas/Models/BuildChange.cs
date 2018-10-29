using System.Text.RegularExpressions;
using Mmu.Trms.Domain.Areas.Models.WorkItems;

namespace Mmu.Trms.Domain.Areas.Models
{
    public class BuildChange
    {
        public string Message { get; }

        public BuildChange(string message)
        {
            Message = message;
        }

        public WorkItemIdParsingResult ParseWorkItemId()
        {
            var regex = new Regex("(^#)(\\d{1,10})");
            var regexMatch = regex.Match(Message);
            if (!regexMatch.Success)
            {
                return new WorkItemIdParsingResult(false, 0);
            }

            var match = regexMatch.Value;
            var matchWithoutHash = match.Replace("#", string.Empty);
            var workitemId = int.Parse(matchWithoutHash);
            return new WorkItemIdParsingResult(true, workitemId);
        }
    }
}