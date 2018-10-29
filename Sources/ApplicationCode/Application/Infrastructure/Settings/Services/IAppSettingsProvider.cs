using Mmu.Trms.Application.Infrastructure.Settings.Models;

namespace Mmu.Trms.Application.Infrastructure.Settings.Services
{
    public interface IAppSettingsProvider
    {
        AppSettings ProvideSettings();
    }
}