using FinanceManager.BLL.DTO;
using FinanceManager.BLL.Mappers;
using FinanceManager.DAL.Abstraction;
using FinanceManager.DAL.DB;
using FinanceManager.DAL.Entities;
using FinanceManager.DAL.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceManager.BLL.Extensions
{
    public static class IServiceCollecitonExtensions
    {
        public static void AddDalDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FinanceManagerDbContext>(options => 
                options.UseNpgsql(configuration.GetConnectionString("Postgres")));
            
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            
            services.AddTransient<IGeneralMapper<Account, AccountDTO>, AccountMapper>();
            services.AddTransient<IGeneralMapper<Category, CategoryDTO>, CategoryMapper>();
            services.AddTransient<IGeneralMapper<Transaction, TransactionDTO>, TransactionMapper>();
        }
    }
}