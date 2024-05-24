using E_Commerce.BL.Dtos.Categories;
using E_Commerce.DAL.Data.Models;

namespace E_Commerce.BL.Mapper.CategoryMapper
{
    public class CategoryMapper : ICategoryMapper
    {
        /*------------------------------------------------------------------------*/
        public ReadCategoryDto ModelToReadCategory(Category category)
        {
            return new ReadCategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                ImageUrl = category.ImageUrl,
                CreatedAt = category.CreatedAt,
            };
        }
        /*------------------------------------------------------------------------*/
        public CategoryDetailsDto ModelToReadCategoryWithProducts(Category category)
        {
            return new CategoryDetailsDto
            {
                Id = category.Id,
                Name = category.Name,
                ImageUrl = category.ImageUrl,
                CreatedAt = category.CreatedAt,
                Slug = category.Slug,
                ProductsCount = category.Products.Count,
                Products = category.Products != null
                    ? category.Products.Select(product => new ProductsBelongToCategoryDto
                    {
                        Id = product.Id,
                        Title = product.Title,
                    })
                            : Enumerable.Empty<ProductsBelongToCategoryDto>()
            };
        }
        /*------------------------------------------------------------------------*/
    }
}
