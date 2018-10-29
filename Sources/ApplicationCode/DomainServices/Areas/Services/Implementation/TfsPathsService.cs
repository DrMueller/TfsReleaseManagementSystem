namespace Mmu.Trms.DomainServices.Areas.Services.Implementation
{
    public class TfsPathsService : ITfsPathsService
    {
        public string GetDefaultProjectPath()
        {
            return "https://drmueller.visualstudio.com/Fun%20Project";
        }
    }
}