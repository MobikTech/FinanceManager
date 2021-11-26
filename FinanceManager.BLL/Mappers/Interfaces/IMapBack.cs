namespace FinanceManager.BLL.Mappers
{
    public interface IMapBack<in TModel, out TEntity>
    {
        public TEntity MapBack(TModel model);
    }
}