using System.Collections.Generic;
using System.Linq;
using FinanceManager.DAL.Abstr;
using FinanceManager.DAL.DB;
using Microsoft.EntityFrameworkCore;

namespace FinanceManager.DAL.Impl
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly FinanceManagerDbContext _context;
        protected DbSet<TEntity> DbSet => _context.Set<TEntity>();

        protected BaseRepository(FinanceManagerDbContext context)
        {
            _context = context;
        }

        public virtual TEntity Create(TEntity entity)
        {
            return DbSet.Add(entity).Entity;
        }

        public virtual List<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public virtual TEntity GetById(int id)
        {
            return DbSet.Find(id);
        }

        public virtual void Update(TEntity entity)
        {
            DbSet.Update(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            // if (Context.Entry(entity).State == EntityState.Detached)
            // {
            //     DbSet.Attach(entity);
            // }
            DbSet.Remove(entity);
        }
        
        // public virtual void Delete(int id)
        // {
        //     TEntity entity = GetById(id);
        //     DbSet.Remove(entity);
        // }
    }
}