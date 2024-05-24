using E_Commerce.BL.Dtos.ShoppingCarts;
using E_Commerce.BL.Managers.ShoppingCarts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartsController : ControllerBase
    {
        /*------------------------------------------------------------------------*/
        private readonly IShoppingCartManager _shoppingCartManager;
        /*------------------------------------------------------------------------*/
        public ShoppingCartsController(IShoppingCartManager shoppingCartManager)
        {
            _shoppingCartManager = shoppingCartManager;
        }
        /*------------------------------------------------------------------------*/
        // Get All Shopping Carts With Details
        // Get: api/ShoppingCarts
        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<ShoppingCartDetailsDto>> GetAllShoppingCartsWithDetails()
        {
            var shoppingCarts = _shoppingCartManager.GetAllShoppingCartsWithDetails();
            if (!shoppingCarts.Any())
            {
                return NotFound("No Shopping Carts Found");
            }
            int shoppingCartsCount = shoppingCarts.Count();
            var response = new { ShoppingCartsCount = shoppingCartsCount, ShoppingCarts = shoppingCarts };
            return Ok(response);
        }
        /*------------------------------------------------------------------------*/
        // Get a Specific Shopping Cart By User Claims
        // Get: api/ShoppingCarts/UserShoppingCart
        [HttpGet]
        [Route("UserShoppingCart")]
        [Authorize(Roles = "User")]
        public ActionResult<ShoppingCartDetailsDto> GetShoppingCartByUserFromClaims()
        {
            var userShoppingCart = _shoppingCartManager.GetShoppingCartByUserClaims(User);
            if (userShoppingCart == null)
            {
                return NotFound($"No Shopping Cart for this User");
            }
            return Ok(userShoppingCart);
        }
        /*------------------------------------------------------------------------*/
        // Get a Specific Shopping Cart By User Id
        // Get: api/ShoppingCarts/UserShoppingCart/{userId}
        [HttpGet]
        [Route("UserShoppingCart/{userId}")]
        [Authorize(Roles = "User")]
        public ActionResult<ShoppingCartDetailsDto> GetShoppingCartByUserId(string userId)
        {
            var userShoppingCart = _shoppingCartManager.GetShoppingCartByUserId(userId);
            if (userShoppingCart == null)
            {
                return NotFound($"Shopping Cart With User With Id : {userId} Not Found");
            }
            return Ok(userShoppingCart);
        }
        /*------------------------------------------------------------------------*/
        // Add Product To Shopping Cart
        // Post: api/ShoppingCarts/AddToCart
        [HttpPost]
        [Route("AddToCart")]
        [Authorize(Roles = "User")]
        public async Task<ActionResult<AddToShoppingCartDto>> AddToCart(AddToShoppingCartDto addToShoppingCartDto)
        {
            try
            {
                await _shoppingCartManager.AddItemsToShoppingCart(User, addToShoppingCartDto);
                return Ok("Product added successfully to the shopping cart.");
            }
            catch (Exception ex)
            {
                if (ex is InvalidOperationException)
                {
                    return NotFound(ex.Message);
                }
                else if (ex is ArgumentException)
                {
                    return BadRequest(ex.Message);
                }
                else
                {
                    return StatusCode(500, $"An error occurred: {ex.Message}");
                }
            }
        }
        /*------------------------------------------------------------------------*/
        // Remove a Specific Item From Shopping Cart By User Claims and Product Id
        // Delete: api/ShoppingCarts/RemoveItemFromCart/{productId}
        [HttpDelete]
        [Authorize(Roles = "User")]
        public ActionResult RemoveFromCart(int productId)
        {
            try
            {
                _shoppingCartManager.RemoveItemsFromShoppingCart(User, productId);
                return Ok("Product removed from cart successfully");

            }
            catch (Exception ex)
            {
                if (ex is InvalidOperationException)
                {
                    return NotFound(ex.Message);
                }
                else
                {
                    return StatusCode(500, $"An error occurred: {ex.Message}");
                }
            }
        }
        /*------------------------------------------------------------------------*/
        // Remove a All Items From Shopping Cart By User Claims
        // Delete: api/ShoppingCarts/RemoveAllItemsFromCart
        [HttpDelete]
        [Route("RemoveAllItemsFromCart")]
        [Authorize(Roles = "User")]
        public ActionResult RemoveAllItemsFromShoppingCartByUserClaims()
        {
            try
            {
                _shoppingCartManager.RemoveAllItemsFromShoppingCartByUserClaims(User);
                return Ok("All Products removed from cart successfully.");
            }
            catch (Exception ex)
            {
                if (ex is InvalidOperationException)
                {
                    return NotFound(ex.Message);
                }
                else
                {
                    return StatusCode(500, $"An error occurred: {ex.Message}");
                }
            }
        }
        /*------------------------------------------------------------------------*/
        // Edit Item Quantity in Shopping Cart
        // Patch: api/ShoppingCarts
        [HttpPatch]
        [Authorize(Roles = "User")]
        public ActionResult EditItemQuantity(EditItemQuantityDto editItemQuantityDto)
        {
            try
            {
                var updatedcart = _shoppingCartManager.EditItemQuantity(User, editItemQuantityDto);
                if (updatedcart == null)
                {
                    return BadRequest();
                }
                //return Ok("Quantity Updated successfully.");
                return Ok(updatedcart);
            }
            catch (Exception ex)
            {
                if (ex is InvalidOperationException)
                {
                    return NotFound(ex.Message);
                }
                else
                {
                    return StatusCode(500, $"An error occurred: {ex.Message}");
                }
            }
        }
        /*------------------------------------------------------------------------*/
    }
}
