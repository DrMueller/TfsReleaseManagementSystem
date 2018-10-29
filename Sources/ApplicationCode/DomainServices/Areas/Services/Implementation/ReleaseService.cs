using System.Linq;
using System.Threading.Tasks;
using Mmu.Trms.Domain.Areas.Models;
using Mmu.Trms.DomainServices.Areas.Factories;
using Mmu.Trms.DomainServices.Areas.Repositories;

namespace Mmu.Trms.DomainServices.Areas.Services.Implementation
{
    internal class ReleaseService : IReleaseService
    {
        private readonly IBuildChangeRepository _buildChangeRepository;
        private readonly IWorkItemReleaseFactory _releaseFactory;
        private readonly IWorkItemRepository _workItemRepository;

        public ReleaseService(
            IBuildChangeRepository buildChangeRepository,
            IWorkItemRepository workItemRepository,
            IWorkItemReleaseFactory releaseFactory)
        {
            _buildChangeRepository = buildChangeRepository;
            _workItemRepository = workItemRepository;
            _releaseFactory = releaseFactory;
        }

        public async Task CreateReleaseAsync(ReleaseConfiguration config)
        {
            var buildChanges = await _buildChangeRepository.GetBuildChangesByBuildId(config.BuildId);
            var workItemIds = buildChanges
                .Select(bc => bc.ParseWorkItemId())
                .Where(parseResult => parseResult.IsSuccess)
                .Select(ps => ps.WorkItemId).ToList();

            var workItems = await _workItemRepository.GetWorkItemsByIdsAsync(workItemIds);
            var workitemRelease = _releaseFactory.CreateRelease(config.BuildVersion, config.ParentWorkItemId, workItems);

            await _workItemRepository.CreateWorkItemAsync("Release", workitemRelease);
        }
    }
}