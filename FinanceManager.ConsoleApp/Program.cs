using System.IO;
using FinanceManager.BLL.Abstraction;
using FinanceManager.BLL.DTO;
using FinanceManager.BLL.Util;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceManager.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // IConfigurationRoot configurationRoot = (new JsonConfigurationManager("appsettings.json")).ConfigurationRoot;
            string connectionString = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"))
                .Build()
                .GetConnectionString("Postgres");

            ServiceModule module = new ServiceModule(connectionString);

            ServiceProvider serviceProvider = module.ServiceProvider;
            
            
            
            module.ServiceProvider.GetService<IAccountService>().CreateAccount(new AccountDTO()
            {
                Id = 0,
                Count = 1000,
                Number = "1"
            });
            
        }
    }
}