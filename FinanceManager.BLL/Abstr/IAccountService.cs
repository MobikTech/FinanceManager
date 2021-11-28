using System.Collections.Generic;
using System.Threading.Tasks;
using FinanceManager.BLL.DTO;

namespace FinanceManager.BLL.Abstraction
{
    public interface IAccountService
    {
        public AccountDTO CreateAccount(AccountDTO dto);

        public AccountDTO CheckAccountCount(AccountDTO dto);
        
        public IEnumerable<AccountDTO> GetAllAccounts();
        
        // public void UpdateCount(AccountDTO dto);
        
        public void DeleteAccount(AccountDTO dto);
    }
}