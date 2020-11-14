using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericRepo;
using EntityProj;
using System.Linq.Expressions;

namespace Provider
{
    public class RepoProvider
    {
        private IGenericRepository<EntityProj.Category> _repo;

        public RepoProvider()
        {
            _repo = new GenericRepository<EntityProj.Category>(new WingtiptoysEntities());
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _repo.GetAll();
        }

        public IEnumerable<Category> GetCategoryWithProducts(string categoryName)
        {
            Expression<Func<Category, bool>> func=(category)=>  category.CategoryName == categoryName ? true : false;

            return _repo.GetByFilter(func, "Products");
            //Todo enter exception handling when the context does not contain the mentioned include entity.
        }
    }
}
