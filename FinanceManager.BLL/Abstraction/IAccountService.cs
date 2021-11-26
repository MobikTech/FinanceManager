using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinanceManager.BLL.ViewModels;

namespace FinanceManager.BLL.Abstraction
{
    public interface IAccountService
    {
        public Task<AccountViewModel> CreateAccount(AccountViewModel viewModel);

        public Task<AccountViewModel> GetAccount(int id);
        
        public Task<IEnumerable<AccountViewModel>> GetAllAccounts();
        
        public Task UpdateAccount(AccountViewModel viewModel);
        
        public Task DeleteAccount(int id);
    }
}