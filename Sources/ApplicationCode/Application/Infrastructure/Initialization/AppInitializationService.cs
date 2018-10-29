using System;
using System.Reflection;
using Mmu.Mlazh.AzureApplicationExtensions.Areas.AzureAppInitialization.Services;
using Mmu.Mlh.ServiceProvisioning.Areas.Initialization.Models;
using Mmu.Trms.Application.Infrastructure.Settings.Models;

namespace Mmu.Trms.Application.Infrastructure.Initialization
{
    public static class AppInitializationService
    {
        public static void Initialize(Assembly rootAssembly, Action provideDependenciesCallback)
        {
            var containerConfig = ContainerConfiguration.CreateFromAssembly(
                rootAssembly,
                initializeAutoMapper: true,
                logInitialization: true);

            InitializationService.AssureServicesAreInitialized(containerConfig, provideDependenciesCallback);
            InitializationService.AssureSettingsAreInitialized<AppSettings>(AppSettings.SectionKey, rootAssembly);
        }
    }
}