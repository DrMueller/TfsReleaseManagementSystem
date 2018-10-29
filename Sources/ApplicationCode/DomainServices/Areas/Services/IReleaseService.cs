using System.Threading.Tasks;
using Mmu.Trms.Domain.Areas.Models;

namespace Mmu.Trms.DomainServices.Areas.Services
{
    public interface IReleaseService
    {
        Task CreateReleaseAsync(ReleaseConfiguration config);
    }
}