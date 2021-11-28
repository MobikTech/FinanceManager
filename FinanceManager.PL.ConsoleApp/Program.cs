using System.IO;
using FinanceManager.BLL.Abstraction;
using FinanceManager.BLL.DTO;
using FinanceManager.BLL.Util;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceManager.PL.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"))
                .Build()
                .GetConnectionString("Postgres");

            ServiceModule module = new ServiceModule(connectionString);

            ServiceProvider serviceProvider = module.ServiceProvider;
            
            
            
            // module.ServiceProvider.GetService<IAccountService>().CreateAccount(new AccountDTO()
            // {
            //     Id = 0,
            //     Count = 1000,
            //     Number = "1"
            // });
            // module.ServiceProvider.GetService<ICategoryService>().CreateCategory(new CategoryDTO()
            // {
            //     Id = 0,
            //     Name = "products"
            // });
            module.ServiceProvider.GetService<ITransactionService>().MakeTransaction(new TransactionDTO()
            {
                Sum = 70,
                CategoryId = 1,
                TargetId = 8
            });
        }
    }
}