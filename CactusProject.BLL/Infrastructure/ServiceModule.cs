using Ninject.Modules;
using CactusProject.DAL.Interfaces;
using CactusProject.DAL.Repositories;
using NLayerApp.DAL.Repositories;

namespace CactusProject.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private string connectionString;
        public ServiceModule(string connection)
        {
            connectionString = connection;
        }
        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(connectionString);
        }
    }
}