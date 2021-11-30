using System;
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

            IAccountService accountService = serviceProvider.GetService<IAccountService>();
            ICategoryService categoryService = serviceProvider.GetService<ICategoryService>();
            ITransactionService transactionService = serviceProvider.GetService<ITransactionService>();
            
            
            transactionService.MakeTransaction(new TransactionDTO()
            {
                Sum = 90,
                CategoryId = 1,
                SourceId = 1
            });
            transactionService.MakeTransaction(new TransactionDTO()
            {
                Sum = 120,
                CategoryId = 1,
                SourceId = 1
            });
            transactionService.MakeTransaction(new TransactionDTO()
            {
                Sum = 10,
                CategoryId = 2,
                TargetId = 1
            });
            transactionService.MakeTransaction(new TransactionDTO()
            {
                Sum = 100,
                CategoryId = 2,
                TargetId = 1
            });
            transactionService.MakeTransaction(new TransactionDTO()
            {
                Sum = 80,
                CategoryId = 3,
                SourceId = 1
            });
            Console.WriteLine($"Total costs on products - {accountService.CheckCosts(1, 1)}");
            Console.WriteLine($"Total income by salary - {accountService.CheckIncome(2, 1)}");
            Console.WriteLine($"Total costs - {accountService.CheckCosts(1)}");
        }
    }
}