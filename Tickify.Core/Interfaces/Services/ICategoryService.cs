using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickify.Core.Entities;

namespace Tickify.Core.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<Category> AddCategory(Category category);
        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category> GetCategoryById(int id);
        Task<Category> GetCategoryByName(string name);
        Task<Category> UpdateCategory(Category category);
        Task DeleteCategory(Category category);


    }
}
