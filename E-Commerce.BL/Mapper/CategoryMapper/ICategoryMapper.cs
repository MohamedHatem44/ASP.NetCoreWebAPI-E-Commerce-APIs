using E_Commerce.BL.Dtos.Categories;
using E_Commerce.DAL.Data.Models;

namespace E_Commerce.BL.Mapper.CategoryMapper
{
    public interface ICategoryMapper
    {
        /*------------------------------------------------------------------------*/
        public ReadCategoryDto ModelToReadCategory(Category category);
        /*------------------------------------------------------------------------*/
        public CategoryDetailsDto ModelToReadCategoryWithProducts(Category category);
        /*------------------------------------------------------------------------*/
    }
}
