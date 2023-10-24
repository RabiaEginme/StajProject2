using Microsoft.EntityFrameworkCore;
using StajProject2.Data;
using System.Linq.Expressions;

namespace StajProject2.DAL
{
    public interface IGenericRepository<T> where T : class 
    {
        T FindById(object EntityId);
        IEnumerable<T> Select(Expression<Func<T, bool>> Filter = null);
        void Insert(T Entity);
        void Update(T Entity);
        void Delete(object EntityId);
        void Delete(T Entity);
    }
    public class StudentRepository<T>
        : IGenericRepository<T> where T : class
    {
        private SchoolContext _context;
        private DbSet<T> _dbSet;
        public StudentRepository(SchoolContext context, DbSet<T> dbset)
        {
            _context = context;
            _dbSet = dbset;
        }
        public virtual T FindById(object EntityId)
        {
            return _dbSet.Find(EntityId);
        }
        public virtual IEnumerable<T> Select(Expression<Func<T, bool>> Filter = null)
        {
            if (Filter != null)
            {
                return _dbSet.Where(Filter);
            }
            return _dbSet;
        }
        public virtual void Insert(T entity)
        {
            _dbSet.Add(entity);
        }
        public virtual void Update(T entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }
        public virtual void Delete(object EntityId)
        {
            T entityToDelete = _dbSet.Find(EntityId);
            Delete(entityToDelete);
        }
        public virtual void Delete(T Entity)
        {
            if (_context.Entry(Entity).State == EntityState.Detached) //Concurrency için 
            {
                _dbSet.Attach(Entity);
            }
            _dbSet.Remove(Entity);
        }
    }
    
}
