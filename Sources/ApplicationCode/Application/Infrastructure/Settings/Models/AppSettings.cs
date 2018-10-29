using Mmu.Mlazh.AzureApplicationExtensions.Infrastructure.Settings.Models;

namespace Mmu.Trms.Application.Infrastructure.Settings.Models
{
    public class AppSettings
    {
        public const string SectionKey = "AppSettings";
        public ApplicationInsightsSettings ApplicationInsightsSettings { get; set; }
        public AzureFunctionsSettings AzureFunctionsSettings { get; set; }
    }
}