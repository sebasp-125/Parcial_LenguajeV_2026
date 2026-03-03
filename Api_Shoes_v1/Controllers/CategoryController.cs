using Api_Shoes_v1.Dtos.Categories;
using Api_Shoes_v1.RealModels;
using Api_Shoes_v1.Services.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api_Shoes_v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly ICategory _categoryService;

        public CategoryController(ICategory categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("AllCategories")]
        public async Task<IActionResult> AllCategories()
        {
            var categories = await _categoryService.GetAllCategories();
            return Ok(categories);
        }

        [HttpPost("AddCategory")]
        public async Task<IActionResult> AddCategory([FromBody] CategoryCreateDto categoryDto)
        {
            if (categoryDto == null)
            {
                return BadRequest("La categoría es nula.");
            }

            var category = new Category
            {
                Name = categoryDto.Name
            };

            var createdCategory = await _categoryService.CreateCategory(category);
            return Ok(createdCategory);
        }
    }
}
