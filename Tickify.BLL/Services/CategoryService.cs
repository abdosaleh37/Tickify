using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickify.Core.Entities;
using Tickify.Core.Interfaces.Repositories;
using Tickify.Core.Interfaces.Services;
namespace Tickify.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Category> AddCategory(Category category)
        {
            await _unitOfWork.Categories.AddAsync(category);
            await _unitOfWork.Complete();

            return category;
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _unitOfWork.Categories.GetAllAsync();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(id);
            return category!;
        }

        public async Task<Category> GetCategoryByName(string name)
        {
            var category = await _unitOfWork.Categories
                             .FirstOrDefaultAsync(c => c.Name == name);
            return category!;
        }

        public async Task<Category> UpdateCategory(Category category)
        {
            _unitOfWork.Categories.Update(category);
            await _unitOfWork.Complete();

            return category;
        }

        public async Task DeleteCategory(Category category)
        {
            _unitOfWork.Categories.Remove(category);
            await _unitOfWork.Complete();
        }
    }
}
