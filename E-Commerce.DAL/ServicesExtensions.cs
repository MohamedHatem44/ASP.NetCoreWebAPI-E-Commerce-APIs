using E_Commerce.DAL.Data.Context;
using E_Commerce.DAL.Repositories.Brands;
using E_Commerce.DAL.Repositories.Categories;
using E_Commerce.DAL.Repositories.Orders;
using E_Commerce.DAL.Repositories.Products;
using E_Commerce.DAL.Repositories.ShoppingCarts;
using E_Commerce.DAL.Repositories.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace E_Commerce.DAL
{
    public static class ServicesExtensions
    {
        public static void AddDALServices(this IServiceCollection services, IConfiguration configuration)
        {
            /*------------------------------------------------------------------------*/
            var connectionString = configuration.GetConnectionString("ECommerceDb");
            services.AddDbContext<E_CommerceContext>(options => options.UseSqlServer(connectionString));
            /*------------------------------------------------------------------------*/
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();
            services.AddScoped<IUserRepository,  UserRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            /*------------------------------------------------------------------------*/
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            /*------------------------------------------------------------------------*/
        }
    }
}
