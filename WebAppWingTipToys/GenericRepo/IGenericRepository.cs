using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepo
{
    public interface IGenericRepository<T> where T:class
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        IEnumerable<T> GetByFilter(Expression<Func<T, bool>> filter = null,
        string includeProperty = "");
        void Insert(T obj);
        void Update(T obj);
        void Delete(object id);
        void Save();
    }
}
