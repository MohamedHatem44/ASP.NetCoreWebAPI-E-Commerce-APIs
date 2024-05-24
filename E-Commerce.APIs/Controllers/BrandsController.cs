using E_Commerce.BL.Managers.Brands;
using Microsoft.AspNetCore.Mvc;
using E_Commerce.BL.Dtos.Brands;
using Microsoft.AspNetCore.Authorization;

namespace E_Commerce.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        /*------------------------------------------------------------------------*/
        private readonly IBrandManager _brandManager;
        /*------------------------------------------------------------------------*/
        public BrandsController(IBrandManager brandManager)
        {
            _brandManager = brandManager;
        }
        /*------------------------------------------------------------------------*/
        // Get All Brands Without Products
        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<ReadBrandDto>> GetAllBrands()
        {
            var brands = _brandManager.GetAllBrands();
            if (!brands.Any())
            {
                return NotFound("No Brands Found");
            }
            int brandsCount = brands.Count();
            var response = new { BrandsCount = brandsCount, Brands = brands };
            return Ok(response);
        }
        /*------------------------------------------------------------------------*/
        // Get All Brands With Products
        [HttpGet]
        [Route("BrandsWithProducts")]
        [Authorize]
        public ActionResult<IEnumerable<BrandDetailsDto>> GetAllbrandsWithProducts()
        {
            var brands = _brandManager.GetAllBrandsWithProducts();
            if (!brands.Any())
            {
                return NotFound("No Orders Found");
            }
            int brandsCount = brands.Count();
            var response = new { BrandsCount = brandsCount, Brands = brands };
            return Ok(response);
        }
        /*------------------------------------------------------------------------*/
        // Get a Specific Brand By Id Without Products
        [HttpGet]
        [Route("{id:int}")]
        [Authorize]
        public ActionResult<ReadBrandDto> GetBrandById(int id)
        {
            var brand = _brandManager.GetBrandById(id);
            if (brand == null)
            {
                return NotFound($"brand With Id : {id} Not Found");
            }
            return Ok(brand);
        }
        /*------------------------------------------------------------------------*/
        // Get a Specific brand By Id Without Products
        [HttpGet]
        [Route("{id:int}/BrandsWithProducts")]
        [Authorize]
        public ActionResult<BrandDetailsDto> GetSpecificbrandWithProducts(int id)
        {
            var brand = _brandManager.GetSpecificBrandWithProducts(id);
            if (brand == null)
            {
                return NotFound($"Brand With Id : {id} Not Found");
            }
            return Ok(brand);
        }
        /*------------------------------------------------------------------------*/
        // Create a New Brand
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult<ReadBrandDto> CreateBrand(CreateBrandDto createBrandDto)
        {
            var newbrand = _brandManager.CreateBrand(createBrandDto);
            if (newbrand == null)
            {
                return Conflict("Brand with the same name already exists, Brand name must be unique");
            }
            return CreatedAtAction(nameof(GetBrandById), new { id = newbrand?.Id }, newbrand);
        }
        /*------------------------------------------------------------------------*/
        // Update a Specific Brand With Id
        [HttpPut]
        [Route("{id:int}")]
        [Authorize(Roles = "Admin")]
        public ActionResult<ReadBrandDto> UpdateBrand(int id, UpdateBrandDto updateBrandDto)
        {
            var brand = _brandManager.GetBrandById(id);
            if (brand == null)
            {
                return NotFound($"Brand With Id : {id} Not Found");
            }
            var updatedBrand = _brandManager.UpdateBrand(id, updateBrandDto);
            if (updatedBrand == null)
            {
                return Conflict("Brand with the same name already exists, Brand name must be unique");
            }
            return Ok(updatedBrand);
        }
        /*------------------------------------------------------------------------*/
        // Delete a Specific Brand By Id
        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteBrand(int id)
        {
            var brand = _brandManager.GetBrandById(id);
            if (brand == null)
            {
                return NotFound($"Brand With Id : {id} Not Found");
            }
            _brandManager.DeleteBrand(id);
            return Ok(new { Message = "Brand deleted successfully" });
        }
        /*------------------------------------------------------------------------*/
    }
}
