using System.Collections.Generic;
using System.Threading.Tasks;
using FinanceManager.BLL.ViewModels;

namespace FinanceManager.BLL.Abstraction
{
    public interface ITransactionService
    {
        public Task<TransactionViewModel> CreateTransaction(TransactionViewModel viewModel);
        
        public Task<TransactionViewModel> GetTransaction(int id);

        public Task<IEnumerable<TransactionViewModel>> GetAllTransactions();
        
        public Task UpdateTransaction(TransactionViewModel viewModel);
        
        public Task DeleteTransaction(int id);
    }
}