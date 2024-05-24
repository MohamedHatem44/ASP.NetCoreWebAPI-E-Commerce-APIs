using E_Commerce.BL.Dtos.Products;
using E_Commerce.DAL.Data.Models;

namespace E_Commerce.BL.Mapper.ProductMapper
{
    public class ProductMapper : IProductMapper
    {
        /*------------------------------------------------------------------------*/
        public ReadProductDto ModelToReadProduct(Product product)
        {
            return new ReadProductDto
            {
                Id = product.Id,
                Title = product.Title,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                CreatedAt = product.CreatedAt,
            };
        }
        /*------------------------------------------------------------------------*/
        public ProductDetailsDto ModelToReadProductDetails(Product product)
        {
            return new ProductDetailsDto
            {
                Id = product.Id,
                Title = product.Title,
                CreatedAt = product.CreatedAt,
                Slug = product.Slug,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                Quantity = product.Quantity,
                Sold = product.Sold,
                Price = product.Price,
                PriceAfterDiscount = product.PriceAfterDiscount,
                Colors = product.Colors,
                RatingsAverage = product.RatingsAverage,
                RatingsQuantity = product.RatingsQuantity,
                Category = new ProductCategoryDto
                {
                    Id = product.Category.Id,
                    Name = product.Category.Name
                },
                Brand = new ProductBrandDto
                {
                    Id = product.Brand.Id,
                    Name = product.Brand.Name
                }
            };
        }
        /*------------------------------------------------------------------------*/
        public Product CreateProductToModel(CreateProductDto createProductDto)
        {
            return new Product
            {
                Title = createProductDto.Title,
                Description = createProductDto.Description,
                ImageUrl = createProductDto.ImageUrl,
                Quantity = createProductDto.Quantity,
                Sold = createProductDto.Sold ?? 0,
                Price = createProductDto.Price,
                PriceAfterDiscount = createProductDto.PriceAfterDiscount,
                Colors = createProductDto.Colors,
                RatingsAverage = createProductDto.RatingsAverage ?? 0,
                RatingsQuantity = createProductDto.RatingsQuantity ?? 0,
                CategoryId = createProductDto.CategoryId,
                BrandId = createProductDto.BrandId
            };
        }
        /*------------------------------------------------------------------------*/
        public void UpdateProductToModel(UpdateProductDto updateProductDto, Product product)
        {
            product.Title = updateProductDto.Title;
            product.Description = updateProductDto.Description;
            product.Quantity = updateProductDto.Quantity;
            product.Sold = updateProductDto.Sold;
            product.Price = updateProductDto.Price;
            product.PriceAfterDiscount = updateProductDto.PriceAfterDiscount;
            product.Colors = updateProductDto.Colors;
            product.RatingsAverage = updateProductDto.RatingsAverage;
            product.RatingsQuantity = updateProductDto.RatingsQuantity;
            product.CategoryId = updateProductDto.CategoryId;
            product.BrandId = updateProductDto.BrandId;
        }
        /*------------------------------------------------------------------------*/
    }
}
