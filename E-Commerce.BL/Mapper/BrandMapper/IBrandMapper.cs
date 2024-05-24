using E_Commerce.BL.Dtos.Brands;
using E_Commerce.DAL.Data.Models;

namespace E_Commerce.BL.Mapper.BrandMapper
{
    public interface IBrandMapper
    {
        /*------------------------------------------------------------------------*/
        public ReadBrandDto ModelToReadBrand(Brand brand);
        /*------------------------------------------------------------------------*/
        public BrandDetailsDto ModelToReadBrandWithProducts(Brand brand);
        /*------------------------------------------------------------------------*/
    }
}
