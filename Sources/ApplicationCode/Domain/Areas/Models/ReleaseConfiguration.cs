using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Trms.Domain.Areas.Models
{
    public class ReleaseConfiguration
    {
        public int BuildId { get; }
        public string BuildVersion { get; }
        public int ParentWorkItemId { get; }

        public ReleaseConfiguration(int buildId, string buildVersion, int parentWorkItemId)
        {
            Guard.ObjectNotNull(() => buildVersion);

            BuildId = buildId;
            BuildVersion = buildVersion;
            ParentWorkItemId = parentWorkItemId;
        }
    }
}