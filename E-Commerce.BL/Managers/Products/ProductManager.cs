using E_Commerce.BL.Dtos.Categories;
using E_Commerce.BL.Dtos.Products;
using E_Commerce.BL.Mapper.UnitMapper;
using E_Commerce.DAL;
using E_Commerce.DAL.Data.Models;

namespace E_Commerce.BL.Managers.Products
{
    public class ProductManager : IProductManager
    {
        /*------------------------------------------------------------------------*/
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUnitMapper _unitMapper;
        /*------------------------------------------------------------------------*/
        public ProductManager(IUnitOfWork unitOfWork, IUnitMapper unitMapper)
        {
            _unitOfWork = unitOfWork;
            _unitMapper = unitMapper;
        }
        /*------------------------------------------------------------------------*/
        // Get All Products Without Details
        public IEnumerable<ReadProductDto> GetAllProducts()
        {
            var products = _unitOfWork.ProductRepository.GetAll();
            var allProducts = products.Select(product => _unitMapper.ProductMapper.ModelToReadProduct(product));
            return allProducts;
        }
        /*------------------------------------------------------------------------*/
        // Get All Products With Details
        public IEnumerable<ProductDetailsDto> GetAllProductsWithDetails()
        {
            var products = _unitOfWork.ProductRepository.GetAllProductsWithDetails();
            var allProducts = products.Select(product => _unitMapper.ProductMapper.ModelToReadProductDetails(product));
            return allProducts;
        }
        /*------------------------------------------------------------------------*/
        // Get All Products With Details With optional parameters for Category Name and Product Title filtration
        public IEnumerable<ProductDetailsDto> GetAllProductsWithSearchParameters(string? category, string? brand, string? title)
        {
            var products = _unitOfWork.ProductRepository.GetAllProductsWithDetails();
            // Filter by category name if provided
            if (!string.IsNullOrEmpty(category))
            {
                products = products.Where(p => p.Category.Name.Equals(category, StringComparison.OrdinalIgnoreCase));
            }
            // Filter by brand name if provided
            if (!string.IsNullOrEmpty(brand))
            {
                products = products.Where(p => p.Brand.Name.Equals(brand, StringComparison.OrdinalIgnoreCase));
            }
            // Filter by product title if provided
            if (!string.IsNullOrEmpty(title))
            {
                products = products.Where(p => p.Title.Contains(title, StringComparison.OrdinalIgnoreCase));
            }
            var searchResultProduct = products.Select(product => _unitMapper.ProductMapper.ModelToReadProductDetails(product));
            return searchResultProduct;
        }
        /*------------------------------------------------------------------------*/
        // Get All Products With Details With optional generic parameter
        public IEnumerable<ProductDetailsDto> GetAllProductsWithGenericSearchParameter(Dictionary<string, string>? queryParams)
        {
            List<string> searchTerms = new List<string>();

            if (queryParams != null)
            {
                foreach (var key in queryParams.Keys)
                {
                    var lowercaseKey = key.ToLower();
                    var lowercaseValue = queryParams[key].ToLower();
                    searchTerms.Add(lowercaseValue);
                }
            }

            var products = _unitOfWork.ProductRepository.GetAllProductsWithDetails();

            if (searchTerms.Any())
            {
                var lowercaseSearchTerms = searchTerms.Select(term => term.ToLower());
                products = products.Where(p =>
                    lowercaseSearchTerms.Any(searchTerm =>
                        p.Title.ToLower().Contains(searchTerm) ||
                        p.Description.ToLower().Contains(searchTerm) ||
                        p.Category.Name.ToLower().Contains(searchTerm) ||
                        p.Brand.Name.ToLower().Contains(searchTerm) ||
                        (p.Colors != null && p.Colors.Any(color => color.ToLower().Contains(searchTerm)))
                ));
            }
            var searchResultProduct = products.Select(product => _unitMapper.ProductMapper.ModelToReadProductDetails(product));
            return searchResultProduct;
        }
        /*------------------------------------------------------------------------*/
        // Get a Specific Product By Id Without Details
        public ReadProductDto? GetProductById(int id)
        {
            var product = _unitOfWork.ProductRepository.GetById(id);
            if (product == null)
            {
                return null;
            }
            var specificProduct = _unitMapper.ProductMapper.ModelToReadProduct(product);
            return specificProduct;
        }
        /*------------------------------------------------------------------------*/
        // Get a Specific Product By Id With Details
        public ProductDetailsDto? GetSpecificProductWithDetails(int id)
        {
            var product = _unitOfWork.ProductRepository.GetSpecificProductWithDetails(id);
            if (product == null)
            {
                return null;
            }
            var specificProduct = _unitMapper.ProductMapper.ModelToReadProductDetails(product);
            return specificProduct;
        }
        /*------------------------------------------------------------------------*/
        // Create a New Product
        public ProductDetailsDto? CreateProduct(CreateProductDto createProductDto)
        {
            var existingProduct = _unitOfWork.ProductRepository.GetProductByTitle(createProductDto.Title);
            // If the Product Title is not unique, return null
            if (existingProduct != null)
            {
                return null;
            }
            // Check if the provided CategoryId and BrandId exist in the database
            var categoryExists = _unitOfWork.CategoryRepository.GetById(createProductDto.CategoryId);
            var brandExists = _unitOfWork.BrandRepository.GetById(createProductDto.BrandId);

            // If either the category or brand does not exist, throw Exception
            if (categoryExists == null || brandExists == null)
            {
                throw new InvalidOperationException("Category or Brand with provided Id does not exist");
            }

            // Create a product
            var newProduct = _unitMapper.ProductMapper.CreateProductToModel(createProductDto);
            _unitOfWork.ProductRepository.Create(newProduct);
            _unitOfWork.SaveChanges();

            // Convert the new Product entity to a ReadProductDto
            var newProductToReturn = _unitMapper.ProductMapper.ModelToReadProductDetails(newProduct);
            return newProductToReturn;
        }
        /*------------------------------------------------------------------------*/
        // Update a Specific Product With Id
        public ProductDetailsDto? UpdateProduct(int id, UpdateProductDto updateProductDto)
        {
            // Retrieve the product by ID
            var product = _unitOfWork.ProductRepository.GetById(id);
            // If product with the specified ID is not found, return null
            if (product == null)
            {
                return null;
            }
            // Check if the title is being changed
            if (!product.Title.Equals(updateProductDto.Title, StringComparison.OrdinalIgnoreCase))
            {
                var existingProductWithSameName = _unitOfWork.ProductRepository.GetProductByTitle(updateProductDto.Title);
                if (existingProductWithSameName != null && existingProductWithSameName.Id != id)
                {
                    return null;
                }
            }
            // Check if the provided CategoryId and BrandId exist in the database
            var categoryExists = _unitOfWork.CategoryRepository.GetById(updateProductDto.CategoryId);
            var brandExists = _unitOfWork.BrandRepository.GetById(updateProductDto.BrandId);

            // If either the category or brand does not exist, throw Exception
            if (categoryExists == null || brandExists == null)
            {
                throw new InvalidOperationException("Category or Brand with provided Id does not exist");
            }

            // Update Product details
            _unitMapper.ProductMapper.UpdateProductToModel(updateProductDto, product);
            _unitOfWork.ProductRepository.Update(product);
            if (!string.IsNullOrEmpty(updateProductDto.ImageUrl))
            {
                product.ImageUrl = updateProductDto.ImageUrl;
            }
            _unitOfWork.SaveChanges();
            // Convert the new Category entity to a ReadCategoryDto
            var updatedPeoductToReturn = _unitMapper.ProductMapper.ModelToReadProductDetails(product);
            return updatedPeoductToReturn;
        }
        /*------------------------------------------------------------------------*/
        // Delete a Specific Product With Id
        public void DeleteProduct(int id)
        {
            var product = _unitOfWork.ProductRepository.GetById(id);
            if (product == null)
            {
                // Product not found, nothing to delete
                return;
            }
            _unitOfWork.ProductRepository.Delete(product);
            _unitOfWork.SaveChanges();
        }
        /*------------------------------------------------------------------------*/
    }
}