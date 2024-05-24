using E_Commerce.DAL.Data.Context;
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
    public class UnitOfWork : IUnitOfWork
    {
        /*------------------------------------------------------------------------*/
        public readonly E_CommerceContext _context;
        /*------------------------------------------------------------------------*/
        public ICategoryRepository CategoryRepository { get; }
        public IBrandRepository BrandRepository { get; }
        public IProductRepository ProductRepository { get; }
        public IShoppingCartRepository ShoppingCartRepository { get; }
        public IUserRepository UserRepository { get; }
        public IOrderRepository OrderRepository { get; }
        public UserManager<User> UserManager { get; }
        /*------------------------------------------------------------------------*/
        public UnitOfWork
                (
                ICategoryRepository categoryRepository,
                IBrandRepository brandRepository,
                IProductRepository productRepository,
                IShoppingCartRepository shoppingCartRepository,
                IUserRepository userRepository,
                IOrderRepository orderRepository,
                UserManager<User> _userManager,
                E_CommerceContext context
                )
        {
            CategoryRepository = categoryRepository;
            ProductRepository = productRepository;
            BrandRepository = brandRepository;
            ShoppingCartRepository = shoppingCartRepository;
            UserRepository = userRepository;
            OrderRepository = orderRepository;
            UserManager = _userManager;
            _context = context;
        }
        /*------------------------------------------------------------------------*/
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        /*------------------------------------------------------------------------*/
    }
}
