using E_Commerce.DAL.Data.Models;
using E_Commerce.DAL.Repositories.Generic;

namespace E_Commerce.DAL.Repositories.Brands
{
    public interface IBrandRepository : IGenericRepository<Brand>
    {
        /*------------------------------------------------------------------------*/
        // Get All Brands With Products
        IEnumerable<Brand> GetAllBrandsWithProducts();
        /*------------------------------------------------------------------------*/
        // Get a Specific Brand By Id With Products
        Brand? GetSpecificBrandWithProducts(int id);
        /*------------------------------------------------------------------------*/
        // Get a Specific Brand By Name
        public Brand? GetBrandByName(string name);
        /*------------------------------------------------------------------------*/
    }
}
