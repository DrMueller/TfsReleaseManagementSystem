using Mmu.Mlh.Adapters.Areas.Services;
using Mmu.Trms.DataAccess.Areas.Repositories;
using Mmu.Trms.DomainServices.Areas.Repositories;
using StructureMap;

namespace Mmu.Trms.DataAccess.Infrastructure.DependencyInjection
{
    public class DataAccessRegistry : Registry
    {
        public DataAccessRegistry()
        {
            Scan(
                scanner =>
                {
                    scanner.AssemblyContainingType<DataAccessRegistry>();
                    scanner.AddAllTypesOf(typeof(IAdapter<,>));
                    scanner.WithDefaultConventions();
                });

            For(typeof(IAdapter<,>)).Singleton();
            For<IWorkItemRepository>().Use<WorkItemRepository>();
            For<IBuildChangeRepository>().Use<BuildChangeRepository>();
        }
    }
}