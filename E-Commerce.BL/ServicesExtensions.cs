using E_Commerce.BL.Managers.Auth;
using E_Commerce.BL.Managers.Brands;
using E_Commerce.BL.Managers.Categories;
using E_Commerce.BL.Managers.Images;
using E_Commerce.BL.Managers.Orders;
using E_Commerce.BL.Managers.Products;
using E_Commerce.BL.Managers.ShoppingCarts;
using E_Commerce.BL.Managers.Users;
using E_Commerce.BL.Mapper.AuthMapper;
using E_Commerce.BL.Mapper.BrandMapper;
using E_Commerce.BL.Mapper.CategoryMapper;
using E_Commerce.BL.Mapper.OrderMapper;
using E_Commerce.BL.Mapper.ProductMapper;
using E_Commerce.BL.Mapper.ShoppingCartMapper;
using E_Commerce.BL.Mapper.UnitMapper;
using E_Commerce.BL.Mapper.UserMapper;
using Microsoft.Extensions.DependencyInjection;

namespace E_Commerce.BL
{
    public static class ServicesExtensions
    {
        public static void AddBLServices(this IServiceCollection services)
        {
            /*------------------------------------------------------------------------*/
            services.AddScoped<ICategoryManager, CategoryManager>();
            services.AddScoped<IProductManager, ProductManager>();
            services.AddScoped<IBrandManager, BrandManager>(); 
            services.AddScoped<IShoppingCartManager, ShoppingCartManager>();
            services.AddScoped<IUserManager, UserManager>();
            services.AddScoped<IOrderManager, OrderManager>();
            services.AddScoped<IAuthManager, AuthManager>();
            services.AddScoped<IImageManager, ImageManager>();
            /*------------------------------------------------------------------------*/
            services.AddScoped<IAuthMapper, AuthMapper>();
            services.AddScoped<ICategoryMapper, CategoryMapper>();
            services.AddScoped<IBrandMapper, BrandMapper>();
            services.AddScoped<IBrandMapper, BrandMapper>();
            services.AddScoped<IProductMapper, ProductMapper>();
            services.AddScoped<IUserMapper, UserMapper>();
            services.AddScoped<IShoppingCartMapper, ShoppingCartMapper>();
            services.AddScoped<IOrderMapper, OrderMapper>();
            /*------------------------------------------------------------------------*/
            services.AddScoped<IUnitMapper, UnitMapper>();
            /*------------------------------------------------------------------------*/
        }
    }
}
