using E_Commerce.DAL.Data.Context;
using E_Commerce.DAL.Data.Models;
using E_Commerce.DAL.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.DAL.Repositories.Users
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        /*------------------------------------------------------------------------*/
        public UserRepository(E_CommerceContext context) : base(context)
        {
        }
        /*------------------------------------------------------------------------*/
        // Get User By Id
        public User? GetUserById(string id)
        {
            return _context.Set<User>().Find(id);
        }
        /*------------------------------------------------------------------------*/
        // Get User By Email
        public User? GetUserByEmail(string email)
        {
            return _context.Set<User>()
                     .AsNoTracking()
                     .FirstOrDefault(user => user.Email == email);
        }
        /*------------------------------------------------------------------------*/
        // Get All Users With Orders
        public IEnumerable<User> GetAllUsersWithOrders()
        {
            return _context.Set<User>()
                 .AsNoTracking()
                 .Include(user => user.Orders)
                    .ThenInclude(order => order.OrderItems)
                        .ThenInclude(orderItem => orderItem.Product);
        }
        /*------------------------------------------------------------------------*/
        // Get All Users With Shopping Cart
        public IEnumerable<User>? GetAllUsersWithShoppingCart()
        {
            return _context.Set<User>()
                 .AsNoTracking()
                 .Include(user => user.ShoppingCart)
                    .ThenInclude(shoppingCart => shoppingCart!.CartItems)
                        .ThenInclude(cartItems => cartItems.Product);
        }
        /*------------------------------------------------------------------------*/
    }
}
