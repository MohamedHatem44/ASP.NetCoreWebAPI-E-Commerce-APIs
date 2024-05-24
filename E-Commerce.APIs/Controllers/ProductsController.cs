using E_Commerce.BL.Dtos.Products;
using E_Commerce.BL.Managers.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        /*------------------------------------------------------------------------*/
        private readonly IProductManager _productManager;
        /*------------------------------------------------------------------------*/
        public ProductsController(IProductManager productManager)
        {
            _productManager = productManager;
        }
        /*------------------------------------------------------------------------*/
        // Get All Products Without Details
        // Get: api/products
        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<ReadProductDto>> GetAllProducts()
        {
            var products = _productManager.GetAllProducts();
            if (!products.Any())
            {
                return NotFound("No Products Found");
            }
            int productsCount = products.Count();
            var response = new { ProductsCount = productsCount, Products = products };
            return Ok(response);
        }
        /*------------------------------------------------------------------------*/
        // Get All Products With Details
        // Get: api/products/ProductsDetails
        [HttpGet]
        [Route("ProductsDetails")]
        [Authorize]
        public ActionResult<IEnumerable<ProductDetailsDto>> GetAllProductsWithDetails()
        {
            var products = _productManager.GetAllProductsWithDetails();
            if (!products.Any())
            {
                return NotFound("No Products Found");
            }
            int productsCount = products.Count();
            var response = new { ProductsCount = productsCount, Products = products };
            return Ok(response);
        }
        /*------------------------------------------------------------------------*/
        // Get All Products With Details With optional parameters for Category Name, Brand Name and Product Title filtration
        // Get: api/products/ProductsDetails/search
        [HttpGet]
        [Route("ProductsDetails/search")]
        [Authorize]
        public ActionResult<IEnumerable<ProductDetailsDto>> GetAllProductsWithSearchParameters([FromQuery] string? category, [FromQuery] string? brand, [FromQuery] string? title)
        {
            var products = _productManager.GetAllProductsWithSearchParameters(category, brand, title);
            if (!products.Any())
            {
                return NotFound("No Products Found");
            }
            int productsCount = products.Count();
            var response = new { ProductsCount = productsCount, Products = products };
            return Ok(response);
        }
        /*------------------------------------------------------------------------*/
        // Get All Products With Details With optional generic parameter
        // Get: api/products/ProductsDetails/GenericSearch
        [HttpGet]
        [Route("ProductsDetails/GenericSearch")]
        [Authorize]
        public ActionResult<IEnumerable<ProductDetailsDto>> SearchProducts([FromQuery] Dictionary<string, string>? queryParams)
        {
            var products = _productManager.GetAllProductsWithGenericSearchParameter(queryParams);
            if (!products.Any())
            {
                return NotFound("No Products Found");
            }
            int productsCount = products.Count();
            var response = new { ProductsCount = productsCount, Products = products };
            return Ok(response);
        }
        /*------------------------------------------------------------------------*/
        // Get a Specific Product By Id Without Details
        // Get: api/products/{id}
        [HttpGet]
        [Route("{id:int}")]
        [Authorize]
        public ActionResult<ReadProductDto> GetProductById(int id)
        {
            var product = _productManager.GetProductById(id);
            if (product == null)
            {
                return NotFound($"Product With Id : {id} Not Found");
            }
            return Ok(product);
        }
        /*------------------------------------------------------------------------*/
        // Get a Specific Product By Id With Details
        // Get: api/products/{id}/ProductsDetails
        [HttpGet]
        [Route("{id:int}/ProductsDetails")]
        [Authorize]
        public ActionResult<ProductDetailsDto> GetSpecificProductWithDetails(int id)
        {
            var product = _productManager.GetSpecificProductWithDetails(id);
            if (product == null)
            {
                return NotFound($"Product With Id : {id} Not Found");
            }
            return Ok(product);
        }
        /*------------------------------------------------------------------------*/
        // Create a New Product
        // Post: api/products
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult<CreateProductDto> CreateCategory(CreateProductDto createProductDto)
        {
            try
            {
                var newProduct = _productManager.CreateProduct(createProductDto);
                if (newProduct == null)
                {
                    return Conflict("Product with the same title already exists, Product title must be unique");
                }
                return CreatedAtAction(nameof(GetProductById), new { id = newProduct.Id }, newProduct);
            }
            catch (Exception ex)
            {
                if (ex is InvalidOperationException)
                {
                    return NotFound(ex.Message);
                }
                else
                {
                    return StatusCode(500, "An error occurred while processing your request");
                }
            }
        }
        /*------------------------------------------------------------------------*/
        // Update a Specific Product With Id
        // Patch: api/products/{id}/ProductsDetails
        [HttpPatch]
        [Route("{id:int}/ProductsDetails")]
        [Authorize(Roles = "Admin")]
        public ActionResult<UpdateProductDto> UpdateCategory(int id, UpdateProductDto updateProductDto)
        {
            try
            {
                var product = _productManager.GetProductById(id);
                if (product == null)
                {
                    return NotFound($"Product With Id : {id} Not Found");
                }
                // Check if the new product name is unique among existing products
                var updatedProduct = _productManager.UpdateProduct(id, updateProductDto);
                if (updatedProduct == null)
                {
                    return Conflict("Product with the same title already exists, Product title must be unique");
                }

                // Return 200 OK status code along with the updated product
                return Ok(updatedProduct);
            }
            catch (Exception ex)
            {
                if (ex is InvalidOperationException)
                {
                    return NotFound(ex.Message);
                }
                else
                {
                    return StatusCode(500, "An error occurred while processing your request");
                }
            }
        }
        /*------------------------------------------------------------------------*/
        // Delete a Specific Product With Id
        // Delete: api/products/{id}
        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteProduct(int id)
        {
            var product = _productManager.GetProductById(id);
            if (product == null)
            {
                return NotFound($"Product With Id : {id} Not Found");
            }
            _productManager.DeleteProduct(id);
            return Ok(new { Message = "Product deleted successfully" });
        }
        /*------------------------------------------------------------------------*/
    }
}
