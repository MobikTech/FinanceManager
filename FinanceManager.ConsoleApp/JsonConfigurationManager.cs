using Microsoft.Extensions.Configuration;

namespace FinanceManager.ConsoleApp
{
    public sealed class JsonConfigurationManager
    {
        public readonly IConfigurationRoot ConfigurationRoot; 
        
        public JsonConfigurationManager(string configFileName)
        {
            var configBuilder = new ConfigurationBuilder();
            
            configBuilder.SetBasePath("D:/Projects/.Net/Lab_3/FinanceManager/FinanceManager.ConsoleApp");
            configBuilder.AddJsonFile(configFileName);
            ConfigurationRoot = configBuilder.Build();
        }
    }
}