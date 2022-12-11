using CatalogService.Business.Abstract;
using CatalogService.DataAccess.Abstract;
using CatalogService.Entities.Concrete;
using CatalogService.Entities.DTOs;
using CorePackage.Helpers.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CatalogService.Entities.DTOs.CategoryDTO;

namespace CatalogService.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IResult Add(CategoryAddDTO category)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CategoryListDTO>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
