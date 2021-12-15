namespace FinanceManagement.BLL.Impl.Base
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