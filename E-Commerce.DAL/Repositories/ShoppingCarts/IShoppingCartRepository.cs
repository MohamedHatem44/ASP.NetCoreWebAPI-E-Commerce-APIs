using E_Commerce.DAL.Data.Models;
using E_Commerce.DAL.Repositories.Generic;

namespace E_Commerce.DAL.Repositories.ShoppingCarts
{
    public interface IShoppingCartRepository : IGenericRepository<ShoppingCart>
    {
        /*------------------------------------------------------------------------*/
        // Get All Shopping Carts With Details
        IEnumerable<ShoppingCart> GetAllShoppingCartsWithDetails();
        /*------------------------------------------------------------------------*/
        // Get a Specific Shopping Cart With Details By User Id
        ShoppingCart? GetShoppingCartByUserId(string userId);
        /*------------------------------------------------------------------------*/
        // Add Product To Shopping Cart
        void AddItemsToShoppingCart(string userId, int productId, int quantity);
        /*------------------------------------------------------------------------*/
        // Remove a Specific Item From Shopping Cart By User Id and Product Id
        void RemoveItemFromShoppingCartByProductId(string userId, int productId);
        /*------------------------------------------------------------------------*/
        // Remove a All Items From Shopping Cart By User Id
        void RemoveAllItemsFromShoppingCartByUsertId(string userId);
        /*------------------------------------------------------------------------*/
        // Edit Item Quantity in Shopping Cart
        void EditItemQuantity(string userId, int productId, int quantity);
        /*------------------------------------------------------------------------*/
    }
}
