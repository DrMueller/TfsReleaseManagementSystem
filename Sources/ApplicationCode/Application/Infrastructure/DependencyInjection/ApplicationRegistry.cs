using Mmu.Mlazh.AzureApplicationExtensions.Infrastructure.Settings.Services;
using Mmu.Mlh.Adapters.Areas.Services;
using Mmu.Trms.Application.Infrastructure.Settings.Services;
using Mmu.Trms.Application.Infrastructure.Settings.Services.Implementation;
using StructureMap;

namespace Mmu.Trms.Application.Infrastructure.DependencyInjection
{
    public class ApplicationRegistry : Registry
    {
        public ApplicationRegistry()
        {
            Scan(
                scanner =>
                {
                    scanner.AssemblyContainingType<ApplicationRegistry>();
                    scanner.AddAllTypesOf(typeof(IAdapter<,>));
                    scanner.WithDefaultConventions();
                });

            For(typeof(IAdapter<,>)).Singleton();

            For<IAppSettingsProvider>().Use<AppSettingsProvider>().Singleton();
            For<IApplicationInsightsSettingsProvider>().Use<AppSettingsProvider>().Singleton();
        }
    }
}