using System;
using System.Collections.Generic;
using System.Linq;
using FinanceManager.BLL.Abstraction;
using FinanceManager.BLL.DTO;
using FinanceManager.BLL.Mappers;
using FinanceManager.DAL.Abstraction;
using FinanceManager.DAL.Entities;

namespace FinanceManager.BLL.Implementation
{
    public class AccountService : BaseService<IUnitOfWork>, IAccountService
    {
        private readonly IGeneralMapper<Account, AccountDTO> _accountMapper;

        public AccountService(IUnitOfWork uow, IGeneralMapper<Account, AccountDTO> accountMapper) 
            : base(uow)
        {
            _accountMapper = accountMapper;
        }
        
        
        public AccountDTO CreateAccount(AccountDTO dto)
        {
            Account account = _accountMapper.MapBack(dto);
            Account result = Database.AccountRepository.Create(account);
            if (result == null)
            {
                throw new NotImplementedException();
            }
            Database.Save();
            return _accountMapper.Map(result);
        }

        public AccountDTO CheckAccountCount(AccountDTO dto)
        {
            if (dto.Number == null)
            {
                throw new NotImplementedException();
            }
            Account result = Database.AccountRepository.GetByNumber(dto.Number);
            if (result == null)
            {
                throw new NotImplementedException();
            }

            return _accountMapper.Map(result);
        }

        public IEnumerable<AccountDTO> GetAllAccounts()
        {
            List<Account> result = Database.AccountRepository.GetAll(); 
            if (result == null)
            {
                throw new NotImplementedException();
            }
            return result.Select(_accountMapper.Map);
        }
        
        // public void UpdateCount(AccountDTO dto)
        // {
        //     if (dto.Number == null)
        //     {
        //         throw new NotImplementedException();
        //     }
        //     Account account = Database.AccountRepository.GetByNumber(dto.Number);
        //     if (account == null)
        //     {
        //         throw new NotImplementedException();
        //     }
        //
        //     account.Count = dto.Count;
        //     Database.AccountRepository.Update(account);
        //     Database.Save();
        // }

        public void DeleteAccount(AccountDTO dto)
        {
            if (dto.Number == null)
            {
                throw new NotImplementedException();
            }
            Account account = Database.AccountRepository.GetByNumber(dto.Number);
            if (account == null)
            {
                throw new NotImplementedException();
            }
            Database.AccountRepository.Delete(account);
            Database.Save();
        }
    }
}