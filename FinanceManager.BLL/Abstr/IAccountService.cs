using System.Collections.Generic;
using FinanceManager.BLL.DTO;

namespace FinanceManager.BLL.Abstraction
{
    public interface IAccountService
    {
        public AccountDTO CreateAccount(AccountDTO dto);
        
        public AccountDTO GetAccountById(int id);
        public AccountDTO GetAccountByNumber(string number);

        public IEnumerable<AccountDTO> GetAllAccounts();
        
        public decimal CheckIncome(int categoryId, int accountId);
        public decimal CheckCosts(int categoryId, int accountId);
        
        public decimal CheckIncome(int accountId);
        
        public decimal CheckCosts(int accountId);

        public void DeleteAccount(int id);
        // public bool TryDeleteAccount(string number);
    }
}