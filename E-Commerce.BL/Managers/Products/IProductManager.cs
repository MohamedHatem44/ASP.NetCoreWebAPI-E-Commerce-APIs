using E_Commerce.BL.Dtos.Products;

namespace E_Commerce.BL.Managers.Products
{
    public interface IProductManager
    {
        /*------------------------------------------------------------------------*/
        // Get All Products Without Details
        IEnumerable<ReadProductDto> GetAllProducts();
        /*------------------------------------------------------------------------*/
        // Get a Specific Product By Id Without Details
        ReadProductDto? GetProductById(int id);
        /*------------------------------------------------------------------------*/
        // Create a New Product
        ProductDetailsDto? CreateProduct(CreateProductDto createProductDto);
        /*------------------------------------------------------------------------*/
        // Update a Specific Product With Id
        ProductDetailsDto? UpdateProduct(int id, UpdateProductDto updateProductDto);
        /*------------------------------------------------------------------------*/
        // Delete a Specific Product With Id
        void DeleteProduct(int id);
        /*------------------------------------------------------------------------*/
        // Get All Products With Details
        IEnumerable<ProductDetailsDto> GetAllProductsWithDetails();
        /*------------------------------------------------------------------------*/
        // Get a Specific Product By Id With Details
        ProductDetailsDto? GetSpecificProductWithDetails(int id);
        /*------------------------------------------------------------------------*/
        // Get All Products With Details With optional parameters for Category Name and Product Title filtration
        IEnumerable<ProductDetailsDto> GetAllProductsWithSearchParameters(string? category, string? brand, string? title);
        /*------------------------------------------------------------------------*/
        // Get All Products With Details With optional generic parameter
        public IEnumerable<ProductDetailsDto> GetAllProductsWithGenericSearchParameter(Dictionary<string, string>? queryParams);
        /*------------------------------------------------------------------------*/
    }
}
