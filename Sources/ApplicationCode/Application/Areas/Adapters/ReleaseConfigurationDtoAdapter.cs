using AutoMapper;
using Mmu.Mlh.Adapters.Areas.Services;
using Mmu.Trms.Application.Areas.Dtos;
using Mmu.Trms.Domain.Areas.Models;

namespace Mmu.Trms.Application.Areas.Adapters
{
    public class ReleaseConfigurationDtoAdapter : AdapterBase<ReleaseConfigurationDto, ReleaseConfiguration>
    {
        public ReleaseConfigurationDtoAdapter(IMapper mapper) : base(mapper)
        {
        }

        public override ReleaseConfiguration Adapt(ReleaseConfigurationDto dto)
        {
            return new ReleaseConfiguration(
                dto.BuildId,
                dto.BuildVersion,
                dto.ParentWorkItemId);
        }
    }
}