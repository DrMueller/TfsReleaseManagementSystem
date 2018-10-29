using Mmu.Mlazh.AzureApplicationExtensions.Infrastructure.Settings.Models;
using Mmu.Mlazh.AzureApplicationExtensions.Infrastructure.Settings.Services;
using Mmu.Trms.Application.Infrastructure.Settings.Models;

namespace Mmu.Trms.Application.Infrastructure.Settings.Services.Implementation
{
    internal class AppSettingsProvider : IAppSettingsProvider, IApplicationInsightsSettingsProvider
    {
        private readonly AppSettings _appSettings;

        public AppSettingsProvider(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        public AppSettings ProvideSettings()
        {
            return _appSettings;
        }

        public ApplicationInsightsSettings ProvideApplicationInsightsSettings()
        {
            return _appSettings.ApplicationInsightsSettings;
        }
    }
}