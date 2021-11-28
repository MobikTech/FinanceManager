using System.Collections.Generic;

namespace FinanceManager.DAL.Abstraction
{
    public interface IBaseRepository<TEntity>
    {
        //CREATE
        public TEntity Create(TEntity entity);

        //READ
        public List<TEntity> GetAll();
        public TEntity GetById(int id);

        //UPDATE
        public void Update(TEntity entity);

        //DELETE
        public void Delete(TEntity entity);

        public void Delete(int id);
    }
}