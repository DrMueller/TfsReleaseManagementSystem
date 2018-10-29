namespace Mmu.Trms.Application.Infrastructure.Settings.Models
{
    public class AzureFunctionsSettings
    {
        public string GetBuildChangesByBuildIdPath { get; set; }
        public string GetWorkItemsByIdsPath { get; set; }
        public string PostWorkItemPath { get; set; }
    }
}