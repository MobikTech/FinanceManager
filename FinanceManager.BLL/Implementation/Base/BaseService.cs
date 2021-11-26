namespace FinanceManager.BLL.Implementation
{
    public class BaseService<TUnitOfWork>
    {
        protected TUnitOfWork Database { get; }

        public BaseService(TUnitOfWork uow)
        {
            Database = uow;
        }
    }
}