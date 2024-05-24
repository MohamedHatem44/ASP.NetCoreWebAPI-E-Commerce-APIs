using E_Commerce.BL.Dtos.Categories;
using E_Commerce.BL.Mapper.UnitMapper;
using E_Commerce.DAL;
using E_Commerce.DAL.Data.Models;

namespace E_Commerce.BL.Managers.Categories
{
    public class CategoryManager : ICategoryManager
    {
        /*------------------------------------------------------------------------*/
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUnitMapper _unitmapper;
        /*------------------------------------------------------------------------*/
        public CategoryManager(IUnitOfWork unitOfWork, IUnitMapper unitmapper)
        {
            _unitOfWork = unitOfWork;
            _unitmapper = unitmapper;
        }
        /*------------------------------------------------------------------------*/
        // Get All Categories Without Products
        public IEnumerable<ReadCategoryDto> GetAllCategories()
        {
            var categories = _unitOfWork.CategoryRepository.GetAll();
            var allCategories = categories.Select(category => _unitmapper.CategoryMapper.ModelToReadCategory(category));
            return allCategories;
        }
        /*------------------------------------------------------------------------*/
        // Get All Categories With Products
        public IEnumerable<CategoryDetailsDto> GetAllCategoriesWithProducts()
        {
            var categories = _unitOfWork.CategoryRepository.GetAllCategoriesWithProducts();
            var allCategoriesWithProducts = categories.Select(category => _unitmapper.CategoryMapper.ModelToReadCategoryWithProducts(category));
            return allCategoriesWithProducts;
        }
        /*------------------------------------------------------------------------*/
        // Get a Specific Category By Id Without Products
        public ReadCategoryDto? GetCategoryById(int id)
        {
            var category = _unitOfWork.CategoryRepository.GetById(id);
            if (category == null)
            {
                return null;
            }
            var specificCategory = _unitmapper.CategoryMapper.ModelToReadCategory(category);
            return specificCategory;
        }
        /*------------------------------------------------------------------------*/
        // Get a Specific Category By Id With Products
        public CategoryDetailsDto? GetSpecificCategoryWithProducts(int id)
        {
            var category = _unitOfWork.CategoryRepository.GetSpecificCategoryWithProducts(id);
            if (category == null)
            {
                return null;
            }
            var specificCategoryWithProducts = _unitmapper.CategoryMapper.ModelToReadCategoryWithProducts(category);
            return specificCategoryWithProducts;
        }
        /*------------------------------------------------------------------------*/
        // Create a New Category
        public ReadCategoryDto? CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var existingCategory = _unitOfWork.CategoryRepository.GetCategoryByName(createCategoryDto.Name);
            // If the category name is not unique, return null
            if (existingCategory != null)
            {
                return null;
            }
            // Create a Category
            var newCategory = new Category
            {
                Name = createCategoryDto.Name,
                ImageUrl = createCategoryDto.ImageUrl,
            };
            _unitOfWork.CategoryRepository.Create(newCategory);
            _unitOfWork.SaveChanges();

            // Convert the new Category entity to a ReadCategoryDto
            var newCategoryToReturn = _unitmapper.CategoryMapper.ModelToReadCategory(newCategory);
            return newCategoryToReturn;
        }
        /*------------------------------------------------------------------------*/
        // Update a Specific Category With Id
        public ReadCategoryDto? UpdateCategory(int id, UpdateCategoryDto updateCategoryDto)
        {
            // Retrieve the category by ID
            var category = _unitOfWork.CategoryRepository.GetById(id);
            // If category with the specified ID is not found, return null
            if (category == null)
            {
                return null;
            }
            // Check if the name is being changed
            if (!category.Name.Equals(updateCategoryDto.Name, StringComparison.OrdinalIgnoreCase))
            {
                var existingCategoryWithSameName = _unitOfWork.CategoryRepository.GetCategoryByName(updateCategoryDto.Name);
                if (existingCategoryWithSameName != null && existingCategoryWithSameName.Id != id)
                {
                    return null;
                }
            }
            // Update Category details
            category.Name = updateCategoryDto.Name;
            if (!string.IsNullOrEmpty(updateCategoryDto.ImageUrl))
            {
                category.ImageUrl = updateCategoryDto.ImageUrl;
            }

            _unitOfWork.CategoryRepository.Update(category);
            _unitOfWork.SaveChanges();

            // Convert the new Category entity to a ReadCategoryDto
            var updatedCategoryToReturn = _unitmapper.CategoryMapper.ModelToReadCategory(category);
            return updatedCategoryToReturn;
        }
        /*------------------------------------------------------------------------*/
        // Delete a Specific Category With Id
        public void DeleteCategory(int id)
        {
            var category = _unitOfWork.CategoryRepository.GetById(id);
            if (category == null)
            {
                return;
            }
            _unitOfWork.CategoryRepository.Delete(category);
            _unitOfWork.SaveChanges();
        }
        /*------------------------------------------------------------------------*/
    }
}
