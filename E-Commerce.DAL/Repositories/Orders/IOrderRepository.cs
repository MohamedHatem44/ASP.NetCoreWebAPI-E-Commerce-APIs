using E_Commerce.DAL.Data.Models;
using E_Commerce.DAL.Repositories.Generic;

namespace E_Commerce.DAL.Repositories.Orders
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        /*------------------------------------------------------------------------*/
        // Get All Orders With Details
        IEnumerable<Order> GetAllOrdersWithDetails();
        /*------------------------------------------------------------------------*/
        // Get Orders With Details By User Id
        IEnumerable<Order> GetOrdersByUserId(string userId);
        /*------------------------------------------------------------------------*/
        // Get Shopping Cart Items By User Id
        IEnumerable<CartItem> GetShoppingCartItemsByUserId(string userId);
        /*------------------------------------------------------------------------*/
        // Clear Cart Items
        public void ClearCartItems(IEnumerable<CartItem> cartItems);
        /*------------------------------------------------------------------------*/
    }
}
