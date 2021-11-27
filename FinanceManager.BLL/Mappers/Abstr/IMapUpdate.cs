namespace FinanceManager.BLL.Mappers
{
    public interface IMapUpdate<TEntity, in TModel>
    {
        public TEntity MapUpdate(TModel model, TEntity entity);
    }
}