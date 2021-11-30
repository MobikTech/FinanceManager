using System;
using System.IO;
using FinanceManager.BLL.Util;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceManager.Tests
{
    public class BaseServiceTests
    {
        protected readonly ServiceProvider _serviceProvider;
        
        public BaseServiceTests()
        {
            string connectionString = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"))
                .Build()
                .GetConnectionString("Postgres");
            connectionString =
                "Host=localhost;Port=5432;Database=finance_manager_tests;Username=postgres;Password=1234;";
            _serviceProvider = new ServiceModule(connectionString).ServiceProvider;
        }
    }
}