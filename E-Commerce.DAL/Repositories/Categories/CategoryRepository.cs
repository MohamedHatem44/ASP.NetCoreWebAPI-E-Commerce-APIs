using E_Commerce.DAL.Data.Context;
using E_Commerce.DAL.Data.Models;
using E_Commerce.DAL.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.DAL.Repositories.Categories
{
    public class CategoryRepository : GenericRepository<Category> , ICategoryRepository
    {
        /*------------------------------------------------------------------------*/
        public CategoryRepository(E_CommerceContext context) : base(context)
        {
        }
        /*------------------------------------------------------------------------*/
        // Get All Categories With Products
        public IEnumerable<Category> GetAllCategoriesWithProducts()
        {
            return _context.Set<Category>()
                .AsNoTracking()
                .Include(category => category.Products);
        }
        /*------------------------------------------------------------------------*/
        // Get a Specific Category By Id With Products
        public Category? GetSpecificCategoryWithProducts(int id)
        {
            return _context.Set<Category>()
              .AsNoTracking()
              .Include(category => category.Products)
              .FirstOrDefault(category => category.Id == id);
        }
        /*------------------------------------------------------------------------*/
        // Get a Specific Category By Name
        public Category? GetCategoryByName(string name)
        {
            return _context.Set<Category>()
                 .AsNoTracking()
                 .FirstOrDefault(category => category.Name == name);
        }
        /*------------------------------------------------------------------------*/
    }
}
