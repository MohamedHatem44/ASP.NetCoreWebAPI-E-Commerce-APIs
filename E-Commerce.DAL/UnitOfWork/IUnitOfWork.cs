using E_Commerce.DAL.Data.Models;
using E_Commerce.DAL.Repositories.Brands;
using E_Commerce.DAL.Repositories.Categories;
using E_Commerce.DAL.Repositories.Orders;
using E_Commerce.DAL.Repositories.Products;
using E_Commerce.DAL.Repositories.ShoppingCarts;
using E_Commerce.DAL.Repositories.Users;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce.DAL
{
    public interface IUnitOfWork
    {
        /*------------------------------------------------------------------------*/
        public ICategoryRepository CategoryRepository { get; }
        public IBrandRepository BrandRepository { get; }
        public IProductRepository ProductRepository { get; }
        public IShoppingCartRepository ShoppingCartRepository { get; }
        public IUserRepository UserRepository { get; }
        public IOrderRepository OrderRepository { get; }
        public UserManager<User> UserManager { get; }
        /*------------------------------------------------------------------------*/
        void SaveChanges();
        /*------------------------------------------------------------------------*/
    }
}
