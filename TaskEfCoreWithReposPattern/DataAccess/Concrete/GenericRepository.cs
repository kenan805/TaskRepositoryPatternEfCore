using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TaskEfCoreWithReposPattern.Context;
using TaskEfCoreWithReposPattern.DataAccess.Abstract;

namespace TaskEfCoreWithReposPattern.DataAccess.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected MyDbContext _context;
        public GenericRepository()
        {
            _context = new MyDbContext();
        }
        public IQueryable<T> GetAll()
        {
            return from entity in _context.Set<T>()
                   select entity;
        }

        public void Insert(T entity)
        {
            _context.Set<T>().Add(entity);
            SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Attach(entity);
            SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public IQueryable<T> Query(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }
    }
}
