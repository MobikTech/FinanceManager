using System;
using System.IO;
using FinanceManager.BLL.Abstraction;
using FinanceManager.BLL.DTO;
using FinanceManager.BLL.Mappers;
using FinanceManager.BLL.Util;
using FinanceManager.DAL.Abstraction;
using FinanceManager.DAL.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceManager.Tests
{
    public class BaseServiceTests
    {
        protected readonly ServiceProvider _serviceProvider;
        protected readonly IAccountService _accountService;
        protected readonly IAccountRepository _accountRepository;
        protected readonly IGeneralMapper<Account, AccountDTO> _accountMapper;
        protected readonly ICategoryService _categoryService;
        protected readonly ICategoryRepository _categoryRepository;
        protected readonly IGeneralMapper<Category, CategoryDTO> _categporyMapper;
        protected readonly ITransactionService _transactionService;
        protected readonly ITransactionRepository _transactionRepository;
        protected readonly IGeneralMapper<Transaction, TransactionDTO> _transactionMapper;

        private readonly IUnitOfWork _unitOfWork;

        public BaseServiceTests()
        {
            string connectionString = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"))
                .Build()
                .GetConnectionString("Postgres");
            connectionString =
                "Host=localhost;Port=5432;Database=finance_manager_tests;Username=postgres;Password=1234;";
            _serviceProvider = new ServiceModule(connectionString).ServiceProvider;

            _accountService = _serviceProvider.GetService<IAccountService>();
            _accountRepository = _serviceProvider.GetService<IUnitOfWork>().AccountRepository;
            _accountMapper = _serviceProvider.GetService<IGeneralMapper<Account, AccountDTO>>();
            
            _categoryService = _serviceProvider.GetService<ICategoryService>();
            _categoryRepository = _serviceProvider.GetService<IUnitOfWork>().CategoryRepository;
            _categporyMapper = _serviceProvider.GetService<IGeneralMapper<Category, CategoryDTO>>();
            
            _transactionService = _serviceProvider.GetService<ITransactionService>();
            _transactionRepository = _serviceProvider.GetService<IUnitOfWork>().TransactionRepository;
            _transactionMapper = _serviceProvider.GetService<IGeneralMapper<Transaction, TransactionDTO>>();

            _unitOfWork = _serviceProvider.GetService<IUnitOfWork>();

            if (_accountRepository.GetAll().Count == 0)
            {
                InitializingData();
            }
        }

        private void InitializingData()
        {
            _accountRepository.Create(new Account()
            {
                Number = "12345",
                Count = 1000
            });

            _accountRepository.Create(new Account()
            {
                Number = "54321",
                Count = 0
            });

            _categoryRepository.Create(new Category()
            {
                Name = "Products"
            });
            _categoryRepository.Create(new Category()
            {
                Name = "Salary"
            });
            _categoryRepository.Create(new Category()
            {
                Name = "YouTube Premium"
            });
            _unitOfWork.Save();
        }
    }
}