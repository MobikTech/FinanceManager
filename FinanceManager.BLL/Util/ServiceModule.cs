using FinanceManager.DAL.Abstraction;
using FinanceManager.DAL.DB;
using FinanceManager.DAL.Implementation;
using Microsoft.EntityFrameworkCore;
using Ninject.Modules;

namespace FinanceManager.BLL.Util
{
    public sealed class ServiceModule : NinjectModule
    {
        private readonly DbContextOptions<FinanceManagerDbContext> _options;

        public ServiceModule(DbContextOptions<FinanceManagerDbContext> options)
        {
            _options = options;
        }
        
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument(new FinanceManagerDbContext(_options));
        }
    }
}