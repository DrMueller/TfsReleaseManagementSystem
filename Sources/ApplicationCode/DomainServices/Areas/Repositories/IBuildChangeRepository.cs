using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Mmu.Trms.Domain.Areas.Models;

namespace Mmu.Trms.DomainServices.Areas.Repositories
{
    public interface IBuildChangeRepository
    {
        Task<IReadOnlyCollection<BuildChange>> GetBuildChangesByBuildId(long buildId);
    }
}
