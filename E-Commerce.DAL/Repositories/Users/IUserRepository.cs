using E_Commerce.DAL.Data.Models;
using E_Commerce.DAL.Repositories.Generic;

namespace E_Commerce.DAL.Repositories.Users
{
    public interface IUserRepository : IGenericRepository<User>
    {
        /*------------------------------------------------------------------------*/
        // Get User By Id
        public User? GetUserById(string id);
        /*------------------------------------------------------------------------*/
        // Get User By Email
        public User? GetUserByEmail(string email);
        /*------------------------------------------------------------------------*/
        // Get All Users With Orders
        IEnumerable<User> GetAllUsersWithOrders();
        /*------------------------------------------------------------------------*/
        // Get All Users With Shopping Cart
        IEnumerable<User>? GetAllUsersWithShoppingCart();
        /*------------------------------------------------------------------------*/
    }
}
