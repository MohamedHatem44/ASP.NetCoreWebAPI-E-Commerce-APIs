using E_Commerce.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace E_Commerce.DAL.Data.Context
{
    public class E_CommerceContext : IdentityDbContext<User>
    {
        /*------------------------------------------------------------------------*/
        #region DbSet
        // Categories Table
        public DbSet<Category> Categories => Set<Category>();

        // Brands Table
        public DbSet<Brand> Brands => Set<Brand>();

        // Products Table
        public DbSet<Product> Products => Set<Product>();

        // ShoppingCarts Table
        public DbSet<ShoppingCart> ShoppingCarts => Set<ShoppingCart>();

        // CartItems Table
        public DbSet<CartItem> CartItems => Set<CartItem>();

        // Orders Table
        public DbSet<Order> Orders => Set<Order>();

        // OrderItems Table
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();
        #endregion
        /*------------------------------------------------------------------------*/
        public E_CommerceContext(DbContextOptions options) : base(options)
        {

        }
        /*------------------------------------------------------------------------*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            /*------------------------------------------------------------------------*/
            #region Tables Constraint 
            // Category Table
            var categoryBulider = modelBuilder.Entity<Category>();
            categoryBulider
               .HasIndex(c => c.Name)
               .IsUnique();

            // Brand Table
            var brandBulider = modelBuilder.Entity<Brand>();
            brandBulider
               .HasIndex(b => b.Name)
               .IsUnique();

            // Product Table
            var productBulider = modelBuilder.Entity<Product>();
            productBulider
               .HasIndex(p => p.Title)
               .IsUnique();

            #endregion
            /*------------------------------------------------------------------------*/
            #region Seeding
            /*------------------------------------------------------------------------*/
            #region Categories
            // Creating a list of Categories
            var _categories = new List<Category>
                {
                    new Category { Id = 1, Name = "Mobiles" },
                    new Category { Id = 2, Name = "Laptops" },
                    new Category { Id = 3, Name = "Cameras" },
                    new Category { Id = 4, Name = "Televisions" },
                    new Category { Id = 5, Name = "Headphones" },
                    new Category { Id = 6, Name = "Tablets" },
                    new Category { Id = 7, Name = "Smart Watches" },
                    new Category { Id = 8, Name = "Printers" },
                    new Category { Id = 9, Name = "Gaming Consoles" },
                    new Category { Id = 10, Name = "Smart Home Devices" }
                };
            #endregion
            /*------------------------------------------------------------------------*/
            #region Brands
            // Creating a list of Brands
            var _brands = new List<Brand>
                {
                    new Brand { Id = 1, Name = "Apple" },
                    new Brand { Id = 2, Name = "Samsung" },
                    new Brand { Id = 3, Name = "Sony" },
                    new Brand { Id = 4, Name = "Dell" },
                    new Brand { Id = 5, Name = "HP" },
                    new Brand { Id = 6, Name = "Canon" },
                    new Brand { Id = 7, Name = "Nike" },
                    new Brand { Id = 8, Name = "Adidas" },
                    new Brand { Id = 9, Name = "Microsoft" },
                    new Brand { Id = 10, Name = "LG" }
                };
            #endregion
            /*------------------------------------------------------------------------*/
            #region Products
            // Creating a list of products
            var _products = new List<Product>
               {
                    new Product
                    {
                        Id = 1,
                        Title = "iPhone 13 Pro",
                        Description = "Latest iPhone model with advanced camera features",
                        Quantity = 100,
                        Sold = 22,
                        Price = 1099.99m,
                        PriceAfterDiscount = 999.99m,
                        Colors = new string[] { "Black", "Silver", "Gold" },
                        RatingsAverage = 4.5,
                        RatingsQuantity = 500,
                        CategoryId = 1,
                        BrandId = 1
                    },
                    new Product 
                    { 
                        Id = 2,
                        Title = "Samsung Galaxy S21 Ultra", 
                        Description = "Flagship Android smartphone with a powerful camera system",
                        Quantity = 150,
                        Sold = 28,
                        Price = 1199.99m,
                        PriceAfterDiscount = 1099.99m,
                        Colors = new string[] { "Phantom Black", "Phantom Silver", "Phantom Titanium" },
                        RatingsAverage = 4.8,
                        RatingsQuantity = 400,
                        CategoryId = 1,
                        BrandId = 1
                    },
                    new Product 
                    {
                        Id = 3, 
                        Title = "Dell XPS 13",
                        Description = "Thin and powerful laptop with a stunning InfinityEdge display",
                        Quantity = 50,
                        Sold = 5,
                        Price = 1299.99m,
                        PriceAfterDiscount = 1199.99m,
                        Colors = new string[] { "Platinum Silver", "Frost White", "Rose Gold" },
                        RatingsAverage = 4.6,
                        RatingsQuantity = 300,
                        CategoryId = 2,
                        BrandId = 2
                    },
                    new Product 
                    { 
                        Id = 4,
                        Title = "MacBook Pro",
                        Description = "Professional-grade laptop with powerful performance and Retina display",
                        Quantity = 30,
                        Sold = 7,
                        Price = 1999.99m,
                        PriceAfterDiscount = 1899.99m,
                        Colors = new string[] { "Space Gray", "Silver" },
                        RatingsAverage = 4.9,
                        RatingsQuantity = 350,
                        CategoryId = 2,
                        BrandId = 2
                    },
                    new Product
                    { 
                        Id = 5, 
                        Title = "Sony Alpha A7 III", 
                        Description = "Full-frame mirrorless camera with excellent low-light performance",
                        Quantity = 300,
                        Sold = 70,
                        Price = 8999.99m,
                        PriceAfterDiscount = 1899.99m,
                        Colors = new string[] { "Space Gray", "Silver" },
                        RatingsAverage = 2.9,
                        RatingsQuantity = 350,
                        CategoryId = 3,
                        BrandId = 3
                    },
                    new Product
                    {
                   
                        Id = 6,
                        Title = "Canon EOS R5",
                        Description = "High-resolution mirrorless camera with advanced autofocus capabilities",
                        Quantity = 80,
                        Sold = 50,
                        Price = 3499.99m,
                        PriceAfterDiscount = 3299.99m,
                        Colors = new string[] { "Black", "Silver"  },
                        RatingsAverage = 4.7,
                        RatingsQuantity = 100,
                        CategoryId = 3,
                        BrandId = 3
                    },
                    new Product
                    {
                        Id = 7,
                        Title = "Google Pixel 6 Pro",
                        Description = "Google's flagship smartphone with an exceptional camera and 5G capability",
                        Quantity = 150,
                        Sold = 100,
                        Price = 999.99m,
                        PriceAfterDiscount = null,
                        Colors = new string[] { "Stormy Black", "Cloudy White", "Sunrise Gold" },
                        RatingsAverage = 4.9,
                        RatingsQuantity = 200,
                        CategoryId = 4,
                        BrandId = 4
                    },
                    new Product
                    {
                        Id = 8,
                        Title = "OnePlus 9 Pro",
                        Description = "Premium Android smartphone with Hasselblad camera technology",
                        Quantity = 120,
                        Sold = 80,
                        Price = 1099.99m,
                        PriceAfterDiscount = 999.99m,
                        Colors = new string[] { "Morning Mist", "Pine Green", "Stellar Black" },
                        RatingsAverage = 1.7,
                        RatingsQuantity = 180,
                        CategoryId = 4,
                        BrandId = 4
                    },
                    new Product
                    {
                        Id = 9,
                        Title = "Lenovo ThinkPad X1 Carbon",
                        Description = "Ultra-portable business laptop with a durable design and impressive battery life",
                        Quantity = 500,
                        Sold = 400,
                        Price = 3499.99m,
                        PriceAfterDiscount = 2499.99m,
                        Colors = new string[] { "Graphite Black", "Pine Green" },
                        RatingsAverage = 2.6,
                        RatingsQuantity = 220,
                        CategoryId = 5,
                        BrandId = 5
                    },
                    new Product
                    {
                        Id = 10,
                        Title = "HP Spectre x360",
                        Description = "Convertible laptop with sleek design and powerful performance",
                        Quantity = 200,
                        Sold = 150,
                        Price = 1499.99m,
                        PriceAfterDiscount = 1399.99m,
                        Colors = new string[] { "Graphite Black", "Rose Gold" },
                        RatingsAverage = 2.6,
                        RatingsQuantity = 220,
                        CategoryId = 5,
                        BrandId = 5
                    },
                    new Product
                    {
                        Id = 11,
                        Title = "Fujifilm X-T4",
                        Description = "Mirrorless camera with outstanding image quality and in-body stabilization",
                        Quantity = 180,
                        Sold = 120,
                        Price = 1299.99m,
                        PriceAfterDiscount = null,
                        Colors = new string[] { "Midnight Blue" },
                        RatingsAverage = 3.2,
                        RatingsQuantity = 180,
                        CategoryId = 6,
                        BrandId = 6
                    },
                    new Product
                    {
                        Id = 12,
                        Title = "Nikon Z6 II",
                        Description = "Full-frame mirrorless camera with 24.5 megapixels and 4K video capability",
                        Quantity = 250,
                        Sold = 200,
                        Price = 1799.99m,
                        PriceAfterDiscount = 1599.99m,
                        Colors = new string[] { "Rose Gold" },
                        RatingsAverage = 4.5,
                        RatingsQuantity = 300,
                        CategoryId = 6,
                        BrandId = 6
                    },
                    new Product
                    {
                        Id = 13,
                        Title = "Microsoft Surface Laptop 4",
                        Description = "Slim and stylish laptop with touchscreen display and excellent keyboard",
                        Quantity = 300,
                        Sold = 280,
                        Price = 1899.99m,
                        PriceAfterDiscount = 1799.99m,
                        Colors = new string[] { "Space Gray" },
                        RatingsAverage = 3.9,
                        RatingsQuantity = 250,
                        CategoryId = 7,
                        BrandId = 7
                    },
                    new Product
                    {
                        Id = 14,
                        Title = "ASUS ROG Phone 5",
                        Description = "Gaming smartphone with high-refresh-rate display and advanced cooling system",
                        Quantity = 150,
                        Sold = 100,
                        Price = 999.99m,
                        PriceAfterDiscount = 899.99m,
                        Colors = new string[] { "Silver" ,"Space Gray" },
                        RatingsAverage = 4.1,
                        RatingsQuantity = 180,
                        CategoryId = 7,
                        BrandId = 7
                    },
                    new Product
                    {
                        Id = 15,
                        Title = "Sony PlayStation 5",
                        Description = "Next-gen gaming console with fast load times and immersive 4K gaming",
                        Quantity = 320,
                        Sold = 300,
                        Price = 2099.99m,
                        PriceAfterDiscount = 1899.99m,
                        Colors = new string[] { "Sapphire Blue", "Silver" },
                        RatingsAverage = 4.7,
                        RatingsQuantity = 280,
                        CategoryId = 8,
                        BrandId = 8
                    },
                    new Product
                    {
                        Id = 16,
                        Title = "Xbox Series X",
                        Description = "Powerful gaming console with 4K resolution and backward compatibility",
                        Quantity = 220,
                        Sold = 200,
                        Price = 1399.99m,
                        PriceAfterDiscount = null,
                        Colors = new string[] { "Gold", "Silver" },
                        RatingsAverage = 3.8,
                        RatingsQuantity = 200,
                        CategoryId = 8,
                        BrandId = 8
                    },
                    new Product
                    {
                        Id = 17,
                        Title = "Amazon Echo (4th Gen)",
                        Description = "Smart speaker with improved sound quality and built-in Alexa voice assistant",
                        Quantity = 270,
                        Sold = 240,
                        Price = 1599.99m,
                        PriceAfterDiscount = null,
                        Colors = new string[] { "Coral Red", "Gold" },
                        RatingsAverage = 4.3,
                        RatingsQuantity = 220,
                        CategoryId = 9,
                        BrandId = 9
                    },
                    new Product
                    {
                        Id = 18,
                        Title = "Google Nest Hub Max",
                        Description = "Smart display with a large screen, perfect for controlling your smart home devices",
                        Quantity = 190,
                        Sold = 150,
                        Price = 1199.99m,
                        PriceAfterDiscount = 1099.99m,
                        Colors = new string[] { "Emerald Green", "Coral Red" },
                        RatingsAverage = 3.6,
                        RatingsQuantity = 210,
                        CategoryId = 9,
                        BrandId = 9
                    },
                };
            #endregion
            /*------------------------------------------------------------------------*/
            #region Users
            //var _users = new List<User>
            //{
            //    new User { Id = new Guid().ToString(), FullName = "user01", Email = "user01@example.com", Address = "111 Main St", PhoneNumber = "123-456-7890" },
            //    new User { Id = new Guid().ToString(), FullName = "user02", Email = "user02@example.com", Address = "222 Main St", PhoneNumber = "987-654-3210" },
            //    new User { Id = new Guid().ToString(), FullName = "user03", Email = "user03@example.com", Address = "333 Main St", PhoneNumber = "555-123-4567" },
            //    new User { Id = new Guid().ToString(), FullName = "user04", Email = "user04@example.com", Address = "444 Main St", PhoneNumber = "111-222-3333" },
            //    new User { Id = new Guid().ToString(), FullName = "user05", Email = "user05@example.com", Address = "555 Main St", PhoneNumber = "444-555-6666" },
            //    new User { Id = new Guid().ToString(), FullName = "user06", Email = "user06@example.com", Address = "666 Main St", PhoneNumber = "444-555-6666" },
            //    new User { Id = new Guid().ToString(), FullName = "user07", Email = "user07@example.com", Address = "777 Main St", PhoneNumber = "444-555-6666" },
            //    new User { Id = new Guid().ToString(), FullName = "user08", Email = "user08@example.com", Address = "888 Main St", PhoneNumber = "444-555-6666" },
            //    new User { Id = new Guid().ToString(), FullName = "user09", Email = "user09@example.com", Address = "999 Main St", PhoneNumber = "444-555-6666" },
            //    new User { Id = new Guid().ToString(), FullName  = "user10", Email = "user10@example.com", Address = "999 Main St", PhoneNumber = "444-555-6666" },
            //    new User { Id = new Guid().ToString(), FullName  = "user11", Email = "user11@example.com", Address = "999 Main St", PhoneNumber = "444-555-6666" },
            //    new User { Id = new Guid().ToString(), FullName  = "user12", Email = "user12@example.com", Address = "999 Main St", PhoneNumber = "444-555-6666" },
            //    new User { Id = new Guid().ToString(), FullName  = "user13", Email = "user13@example.com", Address = "999 Main St", PhoneNumber = "444-555-6666" },
            //    new User { Id = new Guid().ToString(), FullName  = "user14", Email = "user14@example.com", Address = "999 Main St", PhoneNumber = "444-555-6666" },
            //    new User { Id = new Guid().ToString(), FullName  = "user15", Email = "user15@example.com", Address = "999 Main St", PhoneNumber = "444-555-6666" },
            //    new User { Id = new Guid().ToString(), FullName  = "user16", Email = "user16@example.com", Address = "999 Main St", PhoneNumber = "444-555-6666" },
            //    new User { Id = new Guid().ToString(), FullName  = "user17", Email = "user17@example.com", Address = "999 Main St", PhoneNumber = "444-555-6666" },
            //    new User { Id = new Guid().ToString(), FullName  = "user18", Email = "user18@example.com", Address = "999 Main St", PhoneNumber = "444-555-6666" },
            //    new User { Id = new Guid().ToString(), FullName  = "user19", Email = "user19@example.com", Address = "999 Main St", PhoneNumber = "444-555-6666" },
            //    new User { Id = new Guid().ToString(), FullName  = "user20", Email = "user20@example.com", Address = "999 Main St", PhoneNumber = "444-555-6666" },
            //};
            #endregion
            /*------------------------------------------------------------------------*/
            #region CartItems
            // Creating a list of CartItems
            //var _cartItems = new List<CartItem>
            //{
            //    new CartItem { Id = 1, Quantity = 2, ProductId = 1, Color = "Black", ShoppingCartId = 1 },
            //    new CartItem { Id = 2, Quantity = 1, ProductId = 2, Color = "Phantom Titanium", ShoppingCartId = 1 },
            //    new CartItem { Id = 3, Quantity = 2, ProductId = 1, Color = "Black", ShoppingCartId = 2 },
            //    new CartItem { Id = 4, Quantity = 4, ProductId = 3, Color = "Silver", ShoppingCartId = 2 },
            //    new CartItem { Id = 5, Quantity = 2, ProductId = 1, Color = "Black", ShoppingCartId = 3 },
            //    new CartItem { Id = 6, Quantity = 1, ProductId = 4, Color = "Space Gray", ShoppingCartId = 3 },
            //    new CartItem { Id = 7, Quantity = 2, ProductId = 1, Color = "Black", ShoppingCartId = 4 },
            //    new CartItem { Id = 8, Quantity = 4, ProductId = 5, Color = "Silver", ShoppingCartId = 4 }
            //};
            #endregion
            /*------------------------------------------------------------------------*/
            #region ShoppingCarts
            // Creating a list of ShoppingCarts
            //var _shoppingCarts = new List<ShoppingCart>
            //    {
            //        new ShoppingCart { Id = 1, UserId = 1 },
            //        new ShoppingCart { Id = 2, UserId = 2 },
            //        new ShoppingCart { Id = 3, UserId = 3 },
            //        new ShoppingCart { Id = 4, UserId = 4 },
            //        new ShoppingCart { Id = 5, UserId = 5 },
            //        new ShoppingCart { Id = 6, UserId = 6 },
            //        new ShoppingCart { Id = 7, UserId = 7 },
            //        new ShoppingCart { Id = 8, UserId = 8 }
            //    };
            #endregion
            /*------------------------------------------------------------------------*/
            #region OrderItems
            // Creating a list of CartItems
            //var _orderItems = new List<OrderItem>
            //{
            //    new OrderItem { Id = 1, Quantity = 1, ProductId = 1, Color = "Black", OrderId = 1 },
            //    new OrderItem { Id = 2, Quantity = 2, ProductId = 2, Color = "Phantom Titanium", OrderId = 1 },
            //    new OrderItem { Id = 3, Quantity = 1, ProductId = 1, Color = "Black", OrderId = 2 },
            //    new OrderItem { Id = 4, Quantity = 3, ProductId = 3, Color = "Frost White", OrderId = 2 },
            //    new OrderItem { Id = 5, Quantity = 1, ProductId = 1, Color = "Black", OrderId = 3 },
            //    new OrderItem { Id = 6, Quantity = 4, ProductId = 4, Color = "Space Gray", OrderId = 3 },
            //    new OrderItem { Id = 7, Quantity = 1, ProductId = 1, Color = "Gold", OrderId = 4 },
            //    new OrderItem { Id = 8, Quantity = 5, ProductId = 5, Color = "Space Gray", OrderId = 4 }
            //};
            #endregion
            /*------------------------------------------------------------------------*/
            #region Orders
            // Creating a list of Orders
            //var _orders = new List<Order>
            //    {
            //        new Order { Id = 1, UserId = 5 },
            //        new Order { Id = 2, UserId = 6 },
            //        new Order { Id = 3, UserId = 7 },
            //        new Order { Id = 4, UserId = 7 }
            //    };
            #endregion
            /*------------------------------------------------------------------------*/
            #region HasData
            modelBuilder.Entity<Category>().HasData(_categories);
            modelBuilder.Entity<Brand>().HasData(_brands);
            modelBuilder.Entity<Product>().HasData(_products);
            //modelBuilder.Entity<User>().HasData(_users);
            //modelBuilder.Entity<CartItem>().HasData(_cartItems);
            //modelBuilder.Entity<ShoppingCart>().HasData(_shoppingCarts);
            //modelBuilder.Entity<OrderItem>().HasData(_orderItems);
            //modelBuilder.Entity<Order>().HasData(_orders);
            #endregion
            /*------------------------------------------------------------------------*/
            #endregion
        }
        /*------------------------------------------------------------------------*/
    }
}
