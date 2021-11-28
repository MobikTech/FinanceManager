using Microsoft.AspNetCore.Mvc;
using FinanceManager.BLL.Abstraction;

namespace FinanceManager.PL.MVC.Controllers
{
    public sealed class TransactionController : Controller
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }
        
        
    }
}