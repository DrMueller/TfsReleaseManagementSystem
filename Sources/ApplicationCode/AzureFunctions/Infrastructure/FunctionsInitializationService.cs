using Mmu.Trms.Application.Infrastructure.Initialization;
using Mmu.Trms.Dependencies;

namespace Mmu.Trms.AzureFunctions.Infrastructure
{
    public static class FunctionsInitializationService
    {
        public static void Initialize()
        {
            AppInitializationService.Initialize(
                typeof(FunctionsInitializationService).Assembly,
                DependenciesProvider.ProvideDependencencies);
        }
    }
}