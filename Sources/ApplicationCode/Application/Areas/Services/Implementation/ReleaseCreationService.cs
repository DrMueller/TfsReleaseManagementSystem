using System.Threading.Tasks;
using Mmu.Mlh.Adapters.Areas.Services;
using Mmu.Trms.Application.Areas.Dtos;
using Mmu.Trms.Domain.Areas.Models;
using Mmu.Trms.DomainServices.Areas.Services;

namespace Mmu.Trms.Application.Areas.Services.Implementation
{
    public class ReleaseCreationService : IReleaseCreationService
    {
        private readonly IAdapterResolver _adapterResolver;
        private readonly IReleaseService _releaseService;

        public ReleaseCreationService(IAdapterResolver adapterResolver, IReleaseService releaseService)
        {
            _adapterResolver = adapterResolver;
            _releaseService = releaseService;
        }

        public async Task CreateReleaseAsync(ReleaseConfigurationDto dto)
        {
            var model = _adapterResolver.ResolveByAdapteeTypes<ReleaseConfigurationDto, ReleaseConfiguration>().Adapt(dto);
            await _releaseService.CreateReleaseAsync(model);
        }
    }
}