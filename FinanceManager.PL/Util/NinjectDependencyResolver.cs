using System;
using System.Collections.Generic;
using FinanceManager.BLL.Abstraction;
using FinanceManager.BLL.Implementation;
using Ninject;


namespace FinanceManager.PL.Util
{
    public class NinjectDependencyResolver
    {
        private IKernel kernel;
        
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<IAccountService>().To<AccountService>();
            kernel.Bind<ICategoryService>().To<CategoryService>();
            kernel.Bind<ITransactionService>().To<TransactionService>();
        }
    }
}