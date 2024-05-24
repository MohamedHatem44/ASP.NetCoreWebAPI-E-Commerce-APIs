using E_Commerce.DAL.Data.Context;
using E_Commerce.DAL.Data.Models;
using E_Commerce.DAL.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.DAL.Repositories.Brands
{
    public class BrandRepository : GenericRepository<Brand>, IBrandRepository
    {
        /*------------------------------------------------------------------------*/
        public BrandRepository(E_CommerceContext context) : base(context)
        {
        }
        /*------------------------------------------------------------------------*/
        // Get All Brands With Products
        public IEnumerable<Brand> GetAllBrandsWithProducts()
        {
            return _context.Set<Brand>()
                .AsNoTracking()
                .Include(brand => brand.Products);
        }
        /*------------------------------------------------------------------------*/
        // Get a Specific Brand By Id With Products
        public Brand? GetSpecificBrandWithProducts(int id)
        {
            return _context.Set<Brand>()
              .AsNoTracking()
              .Include(brand => brand.Products)
              .FirstOrDefault(brand => brand.Id == id);
        }
        /*------------------------------------------------------------------------*/
        // Get a Specific Brand By Name
        public Brand? GetBrandByName(string name)
        {
            return _context.Set<Brand>()
                 .AsNoTracking()
                 .FirstOrDefault(brand => brand.Name == name);
        }
        /*------------------------------------------------------------------------*/
    }
}
