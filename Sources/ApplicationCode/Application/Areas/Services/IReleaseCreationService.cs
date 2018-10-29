using System.Threading.Tasks;
using Mmu.Trms.Application.Areas.Dtos;

namespace Mmu.Trms.Application.Areas.Services
{
    public interface IReleaseCreationService
    {
        Task CreateReleaseAsync(ReleaseConfigurationDto dto);
    }
}