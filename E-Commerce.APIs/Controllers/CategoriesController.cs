using E_Commerce.BL.Managers.Categories;
using Microsoft.AspNetCore.Mvc;
using E_Commerce.BL.Dtos.Categories;
using Microsoft.AspNetCore.Authorization;

namespace E_Commerce.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        /*------------------------------------------------------------------------*/
        private readonly ICategoryManager _categoryManager;
        /*------------------------------------------------------------------------*/
        public CategoriesController(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }
        /*------------------------------------------------------------------------*/
        // Get All Categories Without Products
        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<ReadCategoryDto>> GetAllCategories()
        {
            var categories = _categoryManager.GetAllCategories();
            if (!categories.Any())
            {
                return NotFound("No Categories Found");
            }
            int categoriesCount = categories.Count();
            var response = new { CategoriesCount = categoriesCount, Categories = categories };
            return Ok(response);
        }
        /*------------------------------------------------------------------------*/
        // Get All Categories With Products
        [HttpGet]
        [Route("CategoriesWithProducts")]
        [Authorize]
        public ActionResult<IEnumerable<CategoryDetailsDto>> GetAllCategoriesWithProducts()
        {
            var categories = _categoryManager.GetAllCategoriesWithProducts();
            if (!categories.Any())
            {
                return NotFound("No Categories Found");
            }
            int categoriesCount = categories.Count();
            var response = new { CategoriesCount = categoriesCount, Categories = categories };
            return Ok(response);
        }
        /*------------------------------------------------------------------------*/
        // Get a Specific Category By Id Without Products
        [HttpGet]
        [Route("{id:int}")]
        [Authorize]
        public ActionResult<ReadCategoryDto> GetCategoryById(int id)
        {
            var category = _categoryManager.GetCategoryById(id);
            if (category == null)
            {
                return NotFound($"Category With Id : {id} Not Found");
            }
            return Ok(category);
        }
        /*------------------------------------------------------------------------*/
        // Get a Specific Category By Id Without Products
        [HttpGet]
        [Route("{id:int}/CategoriesWithProducts")]
        [Authorize]
        public ActionResult<CategoryDetailsDto> GetSpecificCategoryWithProducts(int id)
        {
            var category = _categoryManager.GetSpecificCategoryWithProducts(id);
            if (category == null)
            {
                return NotFound($"Category With Id : {id} Not Found");
            }
            return Ok(category);
        }
        /*------------------------------------------------------------------------*/
        // Create a New Category
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult<ReadCategoryDto> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var newCategory = _categoryManager.CreateCategory(createCategoryDto);
            if (newCategory == null)
            {
                return Conflict("Category with the same name already exists, Category name must be unique");
            }
            return CreatedAtAction(nameof(GetCategoryById), new { id = newCategory.Id }, newCategory);
        }
        /*------------------------------------------------------------------------*/
        // Update a Specific Category With Id
        [HttpPut]
        [Route("{id:int}")]
        [Authorize(Roles = "Admin")]
        public ActionResult<ReadCategoryDto> UpdateCategory(int id, UpdateCategoryDto updateCategoryDto)
        {
            var category = _categoryManager.GetCategoryById(id);
            if (category == null)
            {
                return NotFound($"Category With Id : {id} Not Found");
            }
            var updatedCategory = _categoryManager.UpdateCategory(id, updateCategoryDto);
            if (updatedCategory == null)
            {
                return Conflict("Category with the same name already exists, Category name must be unique");
            }
            return Ok(updatedCategory);
        }
        /*------------------------------------------------------------------------*/
        // Delete a Specific Category With Id
        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteCategory(int id)
        {
            var category = _categoryManager.GetCategoryById(id);
            if (category == null)
            {
                return NotFound($"Category With Id : {id} Not Found");
            }
            _categoryManager.DeleteCategory(id);
            return Ok(new { Message = "Category deleted successfully" });
        }
        /*------------------------------------------------------------------------*/
    }
}
