using FinanceManager.BLL.Abstraction;
using FinanceManager.BLL.DTO;
using FinanceManager.BLL.Implementation;
using FinanceManager.BLL.Mappers;
using FinanceManager.DAL.Abstraction;
using FinanceManager.DAL.DB;
using FinanceManager.DAL.Entities;
using FinanceManager.DAL.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceManager.BLL.Util
{
    public sealed class ServiceModule
    {
        private readonly DbContextOptions<FinanceManagerDbContext> _options;
        private readonly ServiceCollection _serviceCollection = new ServiceCollection();
        public ServiceProvider ServiceProvider { get; }

        public ServiceModule(string connectionString)
        {
            _options = new DbContextOptionsBuilder<FinanceManagerDbContext>().UseNpgsql(connectionString).Options;
            ServiceProvider = ConfigureServices(_serviceCollection);
        }

        private ServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IUnitOfWork>(x => new UnitOfWork(_options));
            
            services.AddTransient<IGeneralMapper<Account, AccountDTO>, AccountMapper>();
            services.AddTransient<IGeneralMapper<Category, CategoryDTO>, CategoryMapper>();
            services.AddTransient<IGeneralMapper<Transaction, TransactionDTO>, TransactionMapper>();
            
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ITransactionService, TransactionService>();
 
            return services.BuildServiceProvider();
        }
    }
    
    
    
    
    
    // public sealed class ServiceModule : NinjectModule
    // {
    //     private readonly DbContextOptions<FinanceManagerDbContext> _options;
    //
    //     public ServiceModule(DbContextOptions<FinanceManagerDbContext> options)
    //     {
    //         _options = options;
    //     }
    //     
    //     public override void Load()
    //     {
    //         Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument(new FinanceManagerDbContext(_options));
    //     }
    // }
}