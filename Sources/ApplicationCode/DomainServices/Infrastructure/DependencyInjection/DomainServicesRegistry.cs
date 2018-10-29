using Mmu.Trms.DomainServices.Areas.Factories.Servants;
using Mmu.Trms.DomainServices.Areas.Factories.Servants.Implementation;
using Mmu.Trms.DomainServices.Areas.Services;
using Mmu.Trms.DomainServices.Areas.Services.Implementation;
using StructureMap;

namespace Mmu.Trms.DomainServices.Infrastructure.DependencyInjection
{
    public class DomainServicesRegistry : Registry
    {
        public DomainServicesRegistry()
        {
            Scan(
                scanner =>
                {
                    scanner.AssemblyContainingType<DomainServicesRegistry>();
                    scanner.WithDefaultConventions();
                });

            For<IWorkItemReleaseLogFactory>().Use<WorkItemReleaseLogFactory>().Singleton();
            For<IReleaseService>().Use<ReleaseService>().Singleton();
        }
    }
}