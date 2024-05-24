using E_Commerce.DAL.Data.Context;
using E_Commerce.DAL.Data.Models;
using E_Commerce.DAL.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.DAL.Repositories.Orders
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        /*------------------------------------------------------------------------*/
        public OrderRepository(E_CommerceContext context) : base(context)
        {
        }
        /*------------------------------------------------------------------------*/
        // Get All Orders With Details
        public IEnumerable<Order> GetAllOrdersWithDetails()
        {
            return _context.Set<Order>()
                .AsNoTracking()
                .Include(order => order.User)
                .Include(order => order.OrderItems)
                   .ThenInclude(orderItem => orderItem.Product);
        }
        /*------------------------------------------------------------------------*/
        // Get a Specific Order With Details By User Id
        public IEnumerable<Order> GetOrdersByUserId(string userId)
        {
            return _context.Set<Order>()
                .AsNoTracking()
                .Include(order => order.User)
                .Include(order => order.OrderItems)
                   .ThenInclude(orderItem => orderItem.Product)
                .Where(order => order.UserId == userId);
        }
        /*------------------------------------------------------------------------*/
        // Get Shopping Cart Items By User Id
        public IEnumerable<CartItem> GetShoppingCartItemsByUserId(string userId)
        {
            return _context.Set<CartItem>()
                .Include(cartItem => cartItem.ShoppingCart)
                .Where(cartItem => cartItem.ShoppingCart.UserId == userId)
                .Include(cartItem => cartItem.Product);
        }
        /*------------------------------------------------------------------------*/
        // Clear Cart Items
        public void ClearCartItems(IEnumerable<CartItem> cartItems)
        {
            _context.CartItems.RemoveRange(cartItems);
        }
        /*------------------------------------------------------------------------*/
    }
}
