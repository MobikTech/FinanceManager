namespace FinanceManager.BLL.Mappers
{
    public interface IGeneralMapper<TEntity, TModel> : 
        IMap<TEntity, TModel>, 
        IMapBack<TModel, TEntity>,
        IMapUpdate<TEntity, TModel>
    {
        
    }
}