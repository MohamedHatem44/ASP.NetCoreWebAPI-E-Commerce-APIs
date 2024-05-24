using E_Commerce.BL.Dtos.Products;
using E_Commerce.DAL.Data.Models;

namespace E_Commerce.BL.Mapper.ProductMapper
{
    public interface IProductMapper
    {
        /*------------------------------------------------------------------------*/
        public ReadProductDto ModelToReadProduct(Product product);
        /*------------------------------------------------------------------------*/
        public ProductDetailsDto ModelToReadProductDetails(Product product);
        /*------------------------------------------------------------------------*/
        public Product CreateProductToModel(CreateProductDto createProductDto);
        /*------------------------------------------------------------------------*/
        public void UpdateProductToModel(UpdateProductDto updateProductDto, Product product);
        /*------------------------------------------------------------------------*/
    }
}
