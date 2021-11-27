using System;
using FinanceManager.BLL.Abstraction;
using FinanceManager.BLL.DTO;
using FinanceManager.BLL.Implementation;
using FinanceManager.BLL.Mappers;
using FinanceManager.DAL.Abstraction;
using FinanceManager.DAL.DB;
using FinanceManager.DAL.Entities;
using FinanceManager.DAL.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceManager.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            FinanceManagerDbContext dbContext = new SampleContextFactory().CreateDbContext(args);
            DbContextOptions<FinanceManagerDbContext> options = GetDbContextOptions<FinanceManagerDbContext>();
            
            var serviceCollection = new ServiceCollection();

            // serviceCollection.AddTransient<DbContextOptions<FinanceManagerDbContext>>(provider => { });
            serviceCollection.AddSingleton<IUnitOfWork, UnitOfWork>();
            
            // BLL
            serviceCollection.AddTransient<IGeneralMapper<Account, AccountDTO>, AccountMapper>();
            serviceCollection.AddTransient<IGeneralMapper<Category, CategoryDTO>, CategoryMapper>();
            serviceCollection.AddTransient<IGeneralMapper<Transaction, TransactionDTO>, TransactionMapper>();
            
            serviceCollection.AddTransient<IAccountService, AccountService>();
            serviceCollection.AddTransient<ICategoryService, CategoryService>();
            serviceCollection.AddTransient<ITransactionService, TransactionService>();
 
            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
            
            serviceProvider.GetService<IAccountService>().CreateAccount(new AccountDTO()
            {
                Id = 0,
                Count = 100,
                Number = "1002312"
            });
        }

        private static DbContextOptions<TContext> GetDbContextOptions<TContext>() where TContext : DbContext
        {
            IConfigurationRoot configuration = (new JsonConfigurationManager("appsettings.json")).ConfigurationRoot;
            string connectionString = configuration.GetConnectionString("Postgres");
            var optionsBuilder = new DbContextOptionsBuilder<TContext>();
            DbContextOptions<TContext> options = optionsBuilder.UseNpgsql(connectionString).Options;
            return options;
        }
    }
    
    public class SampleContextFactory : IDesignTimeDbContextFactory<FinanceManagerDbContext>
    {
        public FinanceManagerDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = (new JsonConfigurationManager("appsettings.json")).ConfigurationRoot;
            string connectionString = configuration.GetConnectionString("Postgres");
            var optionsBuilder = new DbContextOptionsBuilder<FinanceManagerDbContext>();
            DbContextOptions<FinanceManagerDbContext> options = optionsBuilder.UseNpgsql(connectionString).Options;
            return new FinanceManagerDbContext(options);
        }
    }
}