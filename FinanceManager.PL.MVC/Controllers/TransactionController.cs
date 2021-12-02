using Microsoft.AspNetCore.Mvc;
using FinanceManager.BLL.Abstraction;
using FinanceManager.BLL.DTO;
using FinanceManager.PL.MVC.Mappers;
using FinanceManager.PL.MVC.Models;

namespace FinanceManager.PL.MVC.Controllers
{
    public sealed class TransactionController : Controller
    {
        private readonly ITransactionService _transactionService;
        private readonly TransactionViewMapper _transactionViewMapper;

        public TransactionController(ITransactionService transactionService, TransactionViewMapper transactionViewMapper)
        {
            _transactionService = transactionService;
            _transactionViewMapper = transactionViewMapper;
        }

        
        [HttpGet]
        public IActionResult Make()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Make(TransactionViewModel transactionModel)
        {
            TransactionDTO dto = _transactionViewMapper.MapBack(transactionModel);
            _transactionService.MakeTransaction(dto);
            return RedirectToAction("Accounts", "Account");
        }
    }
}