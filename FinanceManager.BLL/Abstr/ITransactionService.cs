using System.Collections.Generic;
using System.Threading.Tasks;
using FinanceManager.BLL.DTO;

namespace FinanceManager.BLL.Abstraction
{
    public interface ITransactionService
    {
        public TransactionDTO CreateTransaction(TransactionDTO dto);
        
        public TransactionDTO GetTransaction(int id);

        public IEnumerable<TransactionDTO> GetAllTransactions();
        
        public void UpdateTransaction(TransactionDTO dto);
        
        public void DeleteTransaction(int id);
    }
}