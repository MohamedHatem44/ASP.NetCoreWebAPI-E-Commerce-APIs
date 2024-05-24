using E_Commerce.BL.Dtos.Brands;

namespace E_Commerce.BL.Managers.Brands
{
    public interface IBrandManager
    {
        /*------------------------------------------------------------------------*/
        // Get All Brands Without Products
        IEnumerable<ReadBrandDto> GetAllBrands();
        /*------------------------------------------------------------------------*/
        // Get a Specific Brand By Id Without Products
        ReadBrandDto? GetBrandById(int id);
        /*------------------------------------------------------------------------*/
        // Create a New Brand
        ReadBrandDto? CreateBrand(CreateBrandDto createBrandDto);
        /*------------------------------------------------------------------------*/
        // Update a Specific Brand By Id
        ReadBrandDto? UpdateBrand(int id, UpdateBrandDto updateBrandDto);
        /*------------------------------------------------------------------------*/
        // Delete a Specific Brand By Id
        void DeleteBrand(int id);
        /*------------------------------------------------------------------------*/
        // Get All Brands With Products
        IEnumerable<BrandDetailsDto> GetAllBrandsWithProducts();
        /*------------------------------------------------------------------------*/
        // Get a Specific Brand By Id With Products
        BrandDetailsDto? GetSpecificBrandWithProducts(int id);
        /*------------------------------------------------------------------------*/
    }
}
