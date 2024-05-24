using E_Commerce.BL.Dtos.Categories;

namespace E_Commerce.BL.Managers.Categories
{
    public interface ICategoryManager
    {
        /*------------------------------------------------------------------------*/
        // Get All Categories Without Products
        IEnumerable<ReadCategoryDto> GetAllCategories();
        /*------------------------------------------------------------------------*/
        // Get a Specific Category By Id Without Products
        ReadCategoryDto? GetCategoryById(int id);
        /*------------------------------------------------------------------------*/
        // Create a New Category
        ReadCategoryDto? CreateCategory(CreateCategoryDto createCategoryDto);
        /*------------------------------------------------------------------------*/
        // Update a Specific Category With Id
        ReadCategoryDto? UpdateCategory(int id, UpdateCategoryDto updateCategoryDto);
        /*------------------------------------------------------------------------*/
        // Delete a Specific Category With Id
        void DeleteCategory(int id);
        /*------------------------------------------------------------------------*/
        // Get All Categories With Products
        IEnumerable<CategoryDetailsDto> GetAllCategoriesWithProducts();
        /*------------------------------------------------------------------------*/
        // Get a Specific Category By Id With Products
        CategoryDetailsDto? GetSpecificCategoryWithProducts(int id);
        /*------------------------------------------------------------------------*/
    }
}
