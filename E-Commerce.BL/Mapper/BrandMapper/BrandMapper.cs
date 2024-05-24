using E_Commerce.BL.Dtos.Brands;
using E_Commerce.DAL.Data.Models;

namespace E_Commerce.BL.Mapper.BrandMapper
{
    public class BrandMapper : IBrandMapper
    {
        /*------------------------------------------------------------------------*/
        public ReadBrandDto ModelToReadBrand(Brand brand)
        {
            return new ReadBrandDto
            {
                Id = brand.Id,
                Name = brand.Name,
                ImageUrl = brand.ImageUrl,
                CreatedAt = brand.CreatedAt,
            };
        }
        /*------------------------------------------------------------------------*/
        public BrandDetailsDto ModelToReadBrandWithProducts(Brand brand)
        {
            return new BrandDetailsDto
            {
                Id = brand.Id,
                Name = brand.Name,
                ImageUrl = brand.ImageUrl,
                CreatedAt = brand.CreatedAt,
                Slug = brand.Slug,
                ProductsCount = brand.Products.Count,
                Products = brand.Products != null
                    ? brand.Products.Select(product => new ProductsBelongToBrandDto
                    {
                        Id = product.Id,
                        Title = product.Title,
                    })
                            : Enumerable.Empty<ProductsBelongToBrandDto>()
            };
        }
        /*------------------------------------------------------------------------*/

    }
}
