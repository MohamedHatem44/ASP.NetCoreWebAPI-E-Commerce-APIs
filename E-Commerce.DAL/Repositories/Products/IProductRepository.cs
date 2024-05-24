using E_Commerce.DAL.Data.Models;
using E_Commerce.DAL.Repositories.Generic;

namespace E_Commerce.DAL.Repositories.Products
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        /*------------------------------------------------------------------------*/
        // Get All Products With Products
        IEnumerable<Product> GetAllProductsWithDetails();
        /*------------------------------------------------------------------------*/
        // Get a Specific Product By Id With Details
        Product? GetSpecificProductWithDetails(int id);
        /*------------------------------------------------------------------------*/
        // Get a Specific Product By Title
        Product? GetProductByTitle(string title);
        /*------------------------------------------------------------------------*/
        // Get All Products With Details With optional parameters for Category, Brand, and Title filtration
        IEnumerable<Product> GetAllProductsWithSearchParameters(string? category, string? brand, string? title);
        /*------------------------------------------------------------------------*/
        // Get All Products With Details With optional generic parameter
        IEnumerable<Product> GetAllProductsWithGenericSearchParameter(Dictionary<string, string>? queryParams);
        /*------------------------------------------------------------------------*/
    }
}
