using AutoMapper;
using Mmu.Mlh.Adapters.Areas.Services;
using Mmu.Trms.DataAccess.Areas.DataModeling.Dtos;
using Mmu.Trms.Domain.Areas.Models;

namespace Mmu.Trms.DataAccess.Areas.DataModeling.Adapters.Implementation
{
    public class BuildChangeDtoAdapter : AdapterBase<BuildChangeDto, BuildChange>
    {
        public BuildChangeDtoAdapter(IMapper mapper) : base(mapper)
        {
        }

        public override BuildChange Adapt(BuildChangeDto dto)
        {
            return new BuildChange(dto.Message);
        }
    }
}