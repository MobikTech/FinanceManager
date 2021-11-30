using FinanceManager.BLL.Abstraction;
using FinanceManager.BLL.DTO;
using FinanceManager.BLL.Mappers;
using FinanceManager.PL.MVC.Models;

namespace FinanceManager.PL.MVC.Mappers
{
    public class AccountViewMapper : IMap<AccountDTO, AccountViewModel>, IMapBack<AccountViewModel, AccountDTO>
    {
        private readonly IAccountService _accountService;

        public AccountViewMapper(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public AccountViewModel Map(AccountDTO dto)
        {
            return new AccountViewModel()
            {
                Number = dto.Number,
                Count = dto.Count
            };
        }

        public AccountDTO MapBack(AccountViewModel model)
        {
            return new AccountDTO()
            {
                Number = model.Number,
                Count = model.Count,
                // Id = _accountService.GetAccountByNumber(model.Number).Id
            };
        }
    }
}