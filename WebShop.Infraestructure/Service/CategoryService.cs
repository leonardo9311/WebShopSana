using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Core.DTO;
using WebShop.Core.Interfaces.Service;

namespace WebShop.Infraestructure.Service
{
    public class CategoryService : ICategoryService
    {
        public Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CategoryDto> GetCategoryByIdAsync(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
