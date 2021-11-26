using Microsoft.Extensions.Configuration;
using System.IO;

namespace FinanceManager.PL.Managers
{
    public sealed class JsonConfigurationManager
    {
        public readonly IConfigurationRoot ConfigurationRoot; 
        
        public JsonConfigurationManager(string configFileName)
        {
            var configBuilder = new ConfigurationBuilder();
            configBuilder.SetBasePath("D:/Projects/.Net/Lab_3/FinanceManagement/FinanceManager.PL");
            configBuilder.AddJsonFile(configFileName);
            ConfigurationRoot = configBuilder.Build();
        }
    }
}