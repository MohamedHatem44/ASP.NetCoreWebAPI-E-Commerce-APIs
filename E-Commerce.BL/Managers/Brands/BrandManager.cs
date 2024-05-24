using E_Commerce.BL.Dtos.Brands;
using E_Commerce.BL.Dtos.Products;
using E_Commerce.BL.Mapper.UnitMapper;
using E_Commerce.DAL;
using E_Commerce.DAL.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace E_Commerce.BL.Managers.Brands
{
    public class BrandManager : IBrandManager
    {
        /*------------------------------------------------------------------------*/
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUnitMapper _unitmapper;
        /*------------------------------------------------------------------------*/
        public BrandManager(IUnitOfWork unitOfWork, IUnitMapper unitmapper)
        {
            _unitOfWork = unitOfWork;
            _unitmapper = unitmapper;
        }
        /*------------------------------------------------------------------------*/
        // Get All Brands Without Products
        public IEnumerable<ReadBrandDto> GetAllBrands()
        {
            var brands = _unitOfWork.BrandRepository.GetAll();
            var allBrands = brands.Select(brand => _unitmapper.BrandMapper.ModelToReadBrand(brand));
            return allBrands;
        }
        /*------------------------------------------------------------------------*/
        // Get All Brands With Products
        public IEnumerable<BrandDetailsDto> GetAllBrandsWithProducts()
        {
            var brands = _unitOfWork.BrandRepository.GetAllBrandsWithProducts();
            var allBrandsWithProducts = brands.Select(brand => _unitmapper.BrandMapper.ModelToReadBrandWithProducts(brand));
            return allBrandsWithProducts;
        }
        /*------------------------------------------------------------------------*/
        // Get a Specific Brand By Id Without Products
        public ReadBrandDto? GetBrandById(int id)
        {
            var brand = _unitOfWork.BrandRepository.GetById(id);
            if (brand == null)
            {
                return null;
            }
            var specificBrand = _unitmapper.BrandMapper.ModelToReadBrand(brand);
            return specificBrand;
        }
        /*------------------------------------------------------------------------*/
        // Get a Specific Brand By Id With Products
        public BrandDetailsDto? GetSpecificBrandWithProducts(int id)
        {
            var brand = _unitOfWork.BrandRepository.GetSpecificBrandWithProducts(id);
            if (brand == null)
            {
                return null;
            }
            var specificBrandWithProducts = _unitmapper.BrandMapper.ModelToReadBrandWithProducts(brand);
            return specificBrandWithProducts;
        }
        /*------------------------------------------------------------------------*/
        // Create a New Brand
        public ReadBrandDto? CreateBrand(CreateBrandDto createBrandDto)
        {
            var existingBrand = _unitOfWork.BrandRepository.GetBrandByName(createBrandDto.Name);
            // If the brand name is not unique, return null
            if (existingBrand != null)
            {
                return null;
            }
            // Create a Brand
            var newBrand = new Brand 
            {
                Name = createBrandDto.Name,
                ImageUrl = createBrandDto.ImageUrl,
            };
            _unitOfWork.BrandRepository.Create(newBrand);
            _unitOfWork.SaveChanges();

            // Convert the new Brand entity to a ReadBrandDto
            var newBrandToReturn = _unitmapper.BrandMapper.ModelToReadBrand(newBrand);
            return newBrandToReturn;
        }
        /*------------------------------------------------------------------------*/
        // Update a Specific Brand By Id
        public ReadBrandDto? UpdateBrand(int id, UpdateBrandDto updateBrandDto)
        {
            // Retrieve the brand by ID
            var brand = _unitOfWork.BrandRepository.GetById(id);
            // If brand with the specified ID is not found, return null
            if (brand == null)
            {
                return null;
            }
            // Check if the name is being changed
            if (!brand.Name.Equals(updateBrandDto.Name, StringComparison.OrdinalIgnoreCase))
            {
                var existingBrandWithSameName = _unitOfWork.BrandRepository.GetBrandByName(updateBrandDto.Name);
                if (existingBrandWithSameName != null && existingBrandWithSameName.Id != id)
                {
                    return null;
                }
            }
            // Update Brand details
            brand.Name = updateBrandDto.Name;
            if (!string.IsNullOrEmpty(updateBrandDto.ImageUrl))
            {
                brand.ImageUrl = updateBrandDto.ImageUrl;
            }

            _unitOfWork.BrandRepository.Update(brand);
            _unitOfWork.SaveChanges();

            // Convert the new Brand entity to a ReadBrandDto
            var updatedBrandToReturn = _unitmapper.BrandMapper.ModelToReadBrand(brand);
            return updatedBrandToReturn;
        }
        /*------------------------------------------------------------------------*/
        // Delete a Specific Brand By Id
        public void DeleteBrand(int id)
        {
            var brand = _unitOfWork.BrandRepository.GetById(id);
            if (brand == null)
            {
                return;
            }
            _unitOfWork.BrandRepository.Delete(brand);
            _unitOfWork.SaveChanges();
        }
        /*------------------------------------------------------------------------*/
    }
}
