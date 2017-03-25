using System;
using System.Collections.Generic;
using NS.Orm;
using System.Linq;

namespace NS.Business.Categories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly NorthwindEntities _northwindEntityDataModel;
        public CategoryRepository(NorthwindEntities northwindEntityDataModel)
        {
            _northwindEntityDataModel = northwindEntityDataModel;
        }

        public void Create(Category instance)
        {
            _northwindEntityDataModel.Categories.Add(instance);
            _northwindEntityDataModel.SaveChanges();
        }

        public void Delete(int id)
        {
            var category = _northwindEntityDataModel.Categories.FirstOrDefault(x => x.CategoryID == id);

            if (category != null)
            {
                _northwindEntityDataModel.Categories.Remove(category);
                _northwindEntityDataModel.SaveChanges();
            }
        }

        public IList<Category> List()
        {
            return _northwindEntityDataModel.Categories.ToList();
        }

        public Category Load(int id)
        {
            return _northwindEntityDataModel.Categories.FirstOrDefault(x => x.CategoryID == id);
        }

        public void Update(Category instance)
        {
            var category = _northwindEntityDataModel.Categories.FirstOrDefault(x => x.CategoryID == instance.CategoryID);

            if (category != null)
            {
                _northwindEntityDataModel.Entry(category).CurrentValues.SetValues(instance);
                _northwindEntityDataModel.SaveChanges(); 
            }
        }
    }
}
