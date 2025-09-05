using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tickify.Core.Entities;
using Tickify.Core.Interfaces.Services;

namespace Tickify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] Category category)
        {
            if (category == null)
            {
                return BadRequest();
            }
            var created = await _categoryService.AddCategory(category);
            return Ok(created);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategories();
            return Ok(categories);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _categoryService.GetCategoryById(id);

            if (category == null)
            {
                return NotFound($"No category found with id = {id}");
            }
            return Ok(category);
        }

        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetCategoryByName(string name)
        {
            var category = await _categoryService.GetCategoryByName(name);

            if (category == null)
            {
                return NotFound($"No category found with name : {name}");
            }
            return Ok(category);
        }

        [HttpPut]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _categoryService.GetCategoryById(id);

            if(category == null)
            {
                return NotFound($"No category found with id = {id}");
            }
            await _categoryService.DeleteCategory(category);
            return Ok(category);
        }

        [HttpDelete]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] Category updatedCategory)
        {
            var category = await _categoryService.GetCategoryById(id);

            if (category == null)
            {
                return NotFound($"No category found with id = {id}");
            }
            await _categoryService.UpdateCategory(updatedCategory);
            return Ok(updatedCategory);
        }
    }
}
