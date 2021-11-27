using System.Collections.Generic;
using System.Threading.Tasks;
using FinanceManager.BLL.DTO;

namespace FinanceManager.BLL.Abstraction
{
    public interface IAccountService
    {
        public AccountDTO CreateAccount(AccountDTO dto);

        public AccountDTO GetAccount(int id);
        
        public IEnumerable<AccountDTO> GetAllAccounts();
        
        public void UpdateAccount(AccountDTO dto);
        
        public void DeleteAccount(int id);
    }
}