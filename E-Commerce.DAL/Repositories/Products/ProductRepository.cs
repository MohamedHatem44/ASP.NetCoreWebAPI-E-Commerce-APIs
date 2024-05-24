using E_Commerce.DAL.Data.Context;
using E_Commerce.DAL.Data.Models;
using E_Commerce.DAL.Repositories.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace E_Commerce.DAL.Repositories.Products
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        /*------------------------------------------------------------------------*/
        public ProductRepository(E_CommerceContext context) : base(context)
        {
        }
        /*------------------------------------------------------------------------*/
        public IEnumerable<Product> GetAllProductsWithDetails()
        {
            return _context.Set<Product>()
                .AsNoTracking()
                .Include(product => product.Category)
                .Include(product => product.Brand);
        }
        /*------------------------------------------------------------------------*/
        // Get a Specific Product By Id With Details
        public Product? GetSpecificProductWithDetails(int id)
        {
            return _context.Set<Product>()
                .AsNoTracking()
                .Include(product => product.Category)
                .Include(product => product.Brand)
                .FirstOrDefault(product => product.Id == id);
        }
        /*------------------------------------------------------------------------*/
        // Get a Specific Product By Title
        public Product? GetProductByTitle(string title)
        {
            return _context.Set<Product>()
                 .AsNoTracking()
                 .FirstOrDefault(product => product.Title == title);
        }
        /*------------------------------------------------------------------------*/
        // Get All Products With Details With optional parameters for Category, Brand, and Title filtration
        public IEnumerable<Product> GetAllProductsWithSearchParameters(string? category, string? brand, string? title)
        {
            var query = _context.Set<Product>()
                .AsNoTracking()
                .Include(product => product.Category)
                .Include(product => product.Brand)
                .AsQueryable();

            // Filter by category name if provided
            if (!string.IsNullOrEmpty(category))
            {
                //query = query.Where(p => p.Category.Name.ToLower().Contains(category.ToLower()));
                query = query.Where(p => p.Category.Name.Equals(category));
            }

            // Filter by brand name if provided
            if (!string.IsNullOrEmpty(brand))
            {
                query = query.Where(p => p.Brand.Name.ToLower().Contains(brand.ToLower()));
            }

            // Filter by product title if provided
            if (!string.IsNullOrEmpty(title))
            {
                query = query.Where(p => p.Title.ToLower().Contains(title.ToLower()));
            }

            return query.ToList();
        }
        /*------------------------------------------------------------------------*/
        // Get All Products With Details With optional generic parameter
        public IEnumerable<Product> GetAllProductsWithGenericSearchParameter(Dictionary<string, string>? queryParams)
        {
            var query = _context.Set<Product>()
                .AsNoTracking()
                .Include(product => product.Category)
                .Include(product => product.Brand)
                .AsQueryable();

            if (queryParams != null && queryParams.Any())
            {
                foreach (var param in queryParams)
                {
                    var key = param.Key.ToLower();
                    var value = param.Value.ToLower();
                    query = query.Where(p =>
                         p.Title.ToLower().Contains(value) ||
                         p.Description.ToLower().Contains(value) ||
                         p.Category.Name.ToLower().Contains(value) ||
                         p.Brand.Name.ToLower().Contains(value)
                     );

                }
            }
            return query.ToList();
        }
        /*------------------------------------------------------------------------*/
    }
}
