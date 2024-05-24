using E_Commerce.BL.Dtos.ShoppingCarts;
using E_Commerce.BL.Mapper.UnitMapper;
using E_Commerce.DAL;
using E_Commerce.DAL.Data.Models;
using System.Security.Claims;

namespace E_Commerce.BL.Managers.ShoppingCarts
{
    public class ShoppingCartManager : IShoppingCartManager
    {
        /*------------------------------------------------------------------------*/
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUnitMapper _unitMapper;
        /*------------------------------------------------------------------------*/
        public ShoppingCartManager(IUnitOfWork unitOfWork, IUnitMapper unitMapper)
        {
            _unitOfWork = unitOfWork;
            _unitMapper = unitMapper;
        }
        /*------------------------------------------------------------------------*/
        // Get All Shopping Carts With Details
        public IEnumerable<ShoppingCartDetailsDto> GetAllShoppingCartsWithDetails() 
        {
            var shoppingCarts = _unitOfWork.ShoppingCartRepository.GetAllShoppingCartsWithDetails();
            var allShoppingCartsWithDetails = shoppingCarts.Select(shoppingCart => _unitMapper.ShoppingCartMapper.MapModelToReadShoppingCartDetails(shoppingCart));
            return allShoppingCartsWithDetails;
        }
        /*------------------------------------------------------------------------*/
        // Get a Specific Shopping Cart By User From Claims
        public ShoppingCartDetailsDto? GetShoppingCartByUserClaims(ClaimsPrincipal claimsPrincipal)
        {
            var userId = _unitOfWork.UserManager.GetUserId(claimsPrincipal);
            if (userId == null)
            {
                return null;
            }
            var shoppingCart = _unitOfWork.ShoppingCartRepository.GetShoppingCartByUserId(userId);
            if (shoppingCart == null)
            {
                return null;
            }

            var uersShoppingCart = _unitMapper.ShoppingCartMapper.MapModelToReadShoppingCartDetails(shoppingCart);
            return uersShoppingCart;
        }
        /*------------------------------------------------------------------------*/
        // Get a Specific Shopping Cart By User Id
        public ShoppingCartDetailsDto? GetShoppingCartByUserId(string userId)
        {
            var user = _unitOfWork.UserRepository.GetUserById(userId);
            if (user == null)
            {
                return null;
            }
            var shoppingCart = _unitOfWork.ShoppingCartRepository.GetShoppingCartByUserId(userId);
            if (shoppingCart == null)
            {
                return null;
            }

            var uersShoppingCart = _unitMapper.ShoppingCartMapper.MapModelToReadShoppingCartDetails(shoppingCart);
            return uersShoppingCart;
        }
        /*------------------------------------------------------------------------*/
        // Add Product To Shopping Cart
        public async Task AddItemsToShoppingCart(ClaimsPrincipal claimsPrincipal, AddToShoppingCartDto addToShoppingCartDto)
        {
            var user = await _unitOfWork.UserManager.GetUserAsync(claimsPrincipal);
            if (user == null)
            {
                throw new InvalidOperationException($"User not found");
            }

            var product = _unitOfWork.ProductRepository.GetById(addToShoppingCartDto.ProductId);
            if (product == null)
            {
                throw new InvalidOperationException($"Product with ID {addToShoppingCartDto.ProductId} not found");
            }

            if (product.Quantity < addToShoppingCartDto.Quantity)
            {
                throw new ArgumentException($"Product with ID {addToShoppingCartDto.ProductId} does not have enough quantity in stock");
            }

            // Check if user has Shopping Cart
            var cart = _unitOfWork.ShoppingCartRepository.GetShoppingCartByUserId(user.Id);

            if (cart == null)
            {
                cart = new ShoppingCart { UserId = user.Id };
                _unitOfWork.ShoppingCartRepository.Create(cart);
            }

            _unitOfWork.ShoppingCartRepository.AddItemsToShoppingCart(user.Id, addToShoppingCartDto.ProductId, addToShoppingCartDto.Quantity);
            _unitOfWork.SaveChanges();
        }
        /*------------------------------------------------------------------------*/
        // Remove a Specific Item From Shopping Cart By User Claims and Product Id
        public void RemoveItemsFromShoppingCart(ClaimsPrincipal claimsPrincipal, int productId)
        {
            // Retrieve the current user's shopping cart
            var userId = _unitOfWork.UserManager.GetUserId(claimsPrincipal);
            if (userId == null)
            {
                throw new InvalidOperationException($"User not found");
            }
            var cart = _unitOfWork.ShoppingCartRepository.GetShoppingCartByUserId(userId);
            if (cart == null)
            {
                throw new InvalidOperationException($"Shopping Cart with User ID {userId} not found");
            }
            if (cart.CartItems.Count == 0)
            {
                throw new InvalidOperationException($"Shopping Cart with User ID {userId} is empty");
            }
            // Check if the shopping cart contains the product
            var existingCartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);
            if (existingCartItem == null)
            {
                throw new InvalidOperationException($"Product with ID {productId} is not found in the Shopping Cart");
            }

            _unitOfWork.ShoppingCartRepository.RemoveItemFromShoppingCartByProductId(userId, productId);
            _unitOfWork.SaveChanges();
        }
        /*------------------------------------------------------------------------*/
        // Remove a All Items From Shopping Cart By User Claims
        public void RemoveAllItemsFromShoppingCartByUserClaims(ClaimsPrincipal claimsPrincipal)
        {
            // Retrieve the current user's shopping cart
            var userId = _unitOfWork.UserManager.GetUserId(claimsPrincipal);
            if (userId == null)
            {
                throw new InvalidOperationException($"User not found");
            }
            var cart = _unitOfWork.ShoppingCartRepository.GetShoppingCartByUserId(userId);
            if (cart == null)
            {
                throw new InvalidOperationException($"Shopping Cart with User ID {userId} not found");
            }
            if (cart.CartItems.Count == 0)
            {
                throw new InvalidOperationException($"Shopping Cart with User ID {userId} is empty");
            }
            _unitOfWork.ShoppingCartRepository.RemoveAllItemsFromShoppingCartByUsertId(userId);
            _unitOfWork.SaveChanges();
        }
        /*------------------------------------------------------------------------*/
        // Edit Item Quantity in Shopping Cart
        public ShoppingCartDetailsDto? EditItemQuantity(ClaimsPrincipal claimsPrincipal, EditItemQuantityDto editItemQuantityDto)
        {
            // Retrieve the current user's shopping cart
            var userId = _unitOfWork.UserManager.GetUserId(claimsPrincipal);
            if(userId == null)
            {
                throw new InvalidOperationException($"User not found");
            }
            var cart = _unitOfWork.ShoppingCartRepository.GetShoppingCartByUserId(userId);
            if (cart == null)
            {
                throw new InvalidOperationException($"Shopping Cart with User ID {userId} not found.");
            }
            if (cart.CartItems.Count == 0)
            {
                throw new InvalidOperationException($"Shopping Cart with User ID {userId} is empty.");
            }
            // Check if the shopping cart contains the product
            var existingCartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == editItemQuantityDto.ProductId);
            if (existingCartItem == null)
            {
                throw new InvalidOperationException($"Product with ID {editItemQuantityDto.ProductId} is not found in the Shopping Cart.");
            }

            _unitOfWork.ShoppingCartRepository.EditItemQuantity(userId, editItemQuantityDto.ProductId, editItemQuantityDto.Quantity);
            _unitOfWork.SaveChanges();

            var updatedCart = _unitOfWork.ShoppingCartRepository.GetShoppingCartByUserId(userId);
            if (updatedCart == null)
            {
                return null;
            }
            var uersShoppingCart = _unitMapper.ShoppingCartMapper.MapModelToReadShoppingCartDetails(updatedCart);
            return uersShoppingCart;
        }
        /*------------------------------------------------------------------------*/
    }
}
