using E_Commerce.BL.Dtos.ShoppingCarts;
using System.Security.Claims;

namespace E_Commerce.BL.Managers.ShoppingCarts
{
    public interface IShoppingCartManager
    {
        /*------------------------------------------------------------------------*/
        // Get All Shopping Carts With Details
        IEnumerable<ShoppingCartDetailsDto> GetAllShoppingCartsWithDetails();
        /*------------------------------------------------------------------------*/
        // Get a Specific Shopping Cart By User From Claims
        ShoppingCartDetailsDto? GetShoppingCartByUserClaims(ClaimsPrincipal claimsPrincipal);
        /*------------------------------------------------------------------------*/
        // Get a Specific Shopping Cart By User Id
        public ShoppingCartDetailsDto? GetShoppingCartByUserId(string userId);
        /*------------------------------------------------------------------------*/
        // Add Product To Shopping Cart
        Task AddItemsToShoppingCart(ClaimsPrincipal claimsPrincipal, AddToShoppingCartDto addToShoppingCartDto);
        /*------------------------------------------------------------------------*/
        // Remove a Specific Item From Shopping Cart By User Claims and Product Id
        void RemoveItemsFromShoppingCart(ClaimsPrincipal claimsPrincipal, int productId);
        /*------------------------------------------------------------------------*/
        // Remove a All Items From Shopping Cart By User Claims
        void RemoveAllItemsFromShoppingCartByUserClaims(ClaimsPrincipal claimsPrincipal);
        /*------------------------------------------------------------------------*/
        // Edit Item Quantity in Shopping Cart
        ShoppingCartDetailsDto? EditItemQuantity(ClaimsPrincipal claimsPrincipal, EditItemQuantityDto editItemQuantityDto);
        /*------------------------------------------------------------------------*/
    }
}
