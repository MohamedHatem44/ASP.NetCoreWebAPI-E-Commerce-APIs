using E_Commerce.DAL.Data.Models;
using E_Commerce.DAL.Repositories.Generic;

namespace E_Commerce.DAL.Repositories.Categories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        /*------------------------------------------------------------------------*/
        // Get All Categories With Products
        IEnumerable<Category> GetAllCategoriesWithProducts();
        /*------------------------------------------------------------------------*/
        // Get a Specific Category By Id With Products
        Category? GetSpecificCategoryWithProducts(int id);
        /*------------------------------------------------------------------------*/
        // Get a Specific Category By Name
        public Category? GetCategoryByName(string name);
        /*------------------------------------------------------------------------*/
    }
}
