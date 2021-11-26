using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanceManager.BLL.Abstraction;
using FinanceManager.BLL.Mappers;
using FinanceManager.BLL.ViewModels;
using FinanceManager.DAL.Abstraction;
using FinanceManager.DAL.Entities;

namespace FinanceManager.BLL.Implementation
{
    public class AccountService : BaseService<IUnitOfWork>, IAccountService
    {
        private readonly IGeneralMapper<Account, AccountViewModel> _accountMapper;

        public AccountService(
            IUnitOfWork uow, 
            IGeneralMapper<Account, AccountViewModel> accountMapper) 
            : base(uow)
        {
            _accountMapper = accountMapper;
        }
        
        
        public async Task<AccountViewModel> CreateAccount(AccountViewModel viewModel)
        {
            Account account = _accountMapper.MapBack(viewModel);
            Account result = await Database.AccountRepository.Create(account);
            if (result == null)
            {
                throw new NotImplementedException();
            }
            
            return _accountMapper.Map(result);
        }

        public async Task<AccountViewModel> GetAccount(int id)
        {
            Account result = await Database.AccountRepository.GetById(id);
            if (result == null)
            {
                throw new NotImplementedException();
            }

            return _accountMapper.Map(result);
        }

        public async Task<IEnumerable<AccountViewModel>> GetAllAccounts()
        {
            List<Account> result = await Database.AccountRepository.GetAll(); 
            if (result == null)
            {
                throw new NotImplementedException();
            }
            return result.Select(_accountMapper.Map);
        }

        public async Task UpdateAccount(AccountViewModel viewModel)
        {
            Account account = await Database.AccountRepository.GetById(viewModel.Id);
            if (account == null)
            {
                throw new NotImplementedException();
            }
            account = _accountMapper.MapUpdate(viewModel, account);
            await Database.AccountRepository.Update(account);
        }

        public async Task DeleteAccount(int id)
        {
            Account account = await Database.AccountRepository.GetById(id);
            if (account == null)
            {
                throw new NotImplementedException();
            }
            await Database.AccountRepository.Delete(account);
        }
    }
}