namespace Mmu.Trms.Application.Areas.Dtos
{
    public class ReleaseConfigurationDto
    {
        public int BuildId { get; set; }
        public string BuildVersion { get; set; }
        public int ParentWorkItemId { get; set; }
    }
}