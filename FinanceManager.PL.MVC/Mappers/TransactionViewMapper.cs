using FinanceManager.BLL.Abstraction;
using FinanceManager.BLL.DTO;
using FinanceManager.BLL.Mappers;
using FinanceManager.PL.MVC.Models;

namespace FinanceManager.PL.MVC.Mappers
{
    public class TransactionViewMapper : IMap<TransactionDTO, TransactionViewModel>, IMapBack<TransactionViewModel, TransactionDTO>
    {
        private readonly IAccountService _accountService;
        private readonly ICategoryService _categoryService;

        public TransactionViewMapper(IAccountService accountService1, ICategoryService categoryService)
        {
            _accountService = accountService1;
            _categoryService = categoryService;
        }

        public TransactionViewModel Map(TransactionDTO dto)
        {
            string sourceNumber = null;
            string targetNumber = null;
            string categoryName = null;
            if (dto.SourceId.HasValue)
            {
                sourceNumber = _accountService.GetAccountById(dto.SourceId.Value).Number;
            }
            if (dto.TargetId.HasValue)
            {
                targetNumber = _accountService.GetAccountById(dto.TargetId.Value).Number;
            }
            if (dto.CategoryId.HasValue)
            {
                categoryName = _categoryService.GetCategoryById(dto.SourceId.Value).Name;
            }
            return new TransactionViewModel()
            {
                Sum = dto.Sum,
                SourceNumber = sourceNumber,
                TargetNumber = targetNumber,
                CategoryName = categoryName
            };
        }

        public TransactionDTO MapBack(TransactionViewModel model)
        {
            int? sourceId = null;
            int? targetId = null;
            int? categoryId = null;
            if (model.SourceNumber is not null)
            {
                sourceId = _accountService.GetAccountByNumber(model.SourceNumber).Id;
            }
            if (model.TargetNumber is not null)
            {
                targetId = _accountService.GetAccountByNumber(model.TargetNumber).Id;
            }
            if (model.CategoryName is not null)
            {
                categoryId = _categoryService.GetCategoryByName(model.CategoryName).Id;
            }
            return new TransactionDTO()
            {
                //todo add transaction id getter
                // Id = default,
                Sum = model.Sum,
                // Date = default,
                SourceId = sourceId,
                TargetId = targetId,
                CategoryId = categoryId
            };
        }
    }
}