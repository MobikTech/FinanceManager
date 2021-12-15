namespace FinanceManager.BLL.Impl
{
    public class BaseService<TUnitOfWork>
    {
        protected TUnitOfWork Database { get; }

        protected BaseService(TUnitOfWork uow)
        {
            Database = uow;
        }
    }
}