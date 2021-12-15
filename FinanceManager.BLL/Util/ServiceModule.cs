using FinanceManager.BLL.Abstraction;
using FinanceManager.BLL.DTO;
using FinanceManager.BLL.Impl;
using FinanceManager.BLL.Mappers;
using FinanceManager.DAL.Abstr.UoWs;
using FinanceManager.DAL.DB;
using FinanceManager.DAL.Entities;
using FinanceManager.DAL.Impl.UoWs;
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
}