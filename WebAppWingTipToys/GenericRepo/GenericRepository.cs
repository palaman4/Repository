using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq.Expressions;

namespace GenericRepo
{
  public class GenericRepository<T>: IGenericRepository<T> where T:class
    {
        private DbContext _context = null;
        private DbSet<T> entity = null;
        public GenericRepository(DbContext dbContext)
        {
            this._context = dbContext;
            entity = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return entity.ToList();
        }
        public T GetById(object id)
        {
            return entity.Find(id);
        }

       public virtual IEnumerable<T> GetByFilter(Expression<Func<T, bool>> filter = null,
        string includeProperty = "")
        {
            IQueryable<T> query = entity;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            //Todo: enable to attach multiple child entities
            if (includeProperty != null)
            {
                query = query.Include(includeProperty);
                
            }

                return query.ToList();
        }


        public void Insert(T obj)
        {
            entity.Add(obj);
        }
        public void Update(T obj)
        {
            entity.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(object id)
        {
            T existing = entity.Find(id);
            entity.Remove(existing);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}


    

