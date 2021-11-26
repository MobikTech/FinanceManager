namespace FinanceManager.BLL.Mappers
{
    public interface IMap<in TEntity, out TModel>
    {
        public TModel Map(TEntity entity);
    }
}