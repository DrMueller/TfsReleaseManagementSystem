using Mmu.Mlazh.AzureApplicationExtensions.Areas.AzureAppInitialization.Services;
using Mmu.Mlh.ConsoleExtensions.Areas.Commands.Services;
using Mmu.Mlh.ServiceProvisioning.Areas.Initialization.Models;
using Mmu.Mlh.ServiceProvisioning.Areas.Provisioning.Services;
using Mmu.Trms.Application.Infrastructure.Initialization;
using Mmu.Trms.Dependencies;

namespace Mmu.Trms.TestConsole
{
    public static class Program
    {
        public static void Main()
        {
            AppInitializationService.Initialize(
                typeof(Program).Assembly,
                DependenciesProvider.ProvideDependencencies);

            ServiceLocatorSingleton
                .Instance
                .GetService<IConsoleCommandsStartupService>()
                .Start();
        }
    }
}