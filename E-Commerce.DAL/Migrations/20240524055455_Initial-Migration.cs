using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_Commerce.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OrderStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDelivered = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Sold = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(7,2)", nullable: false),
                    PriceAfterDiscount = table.Column<decimal>(type: "decimal(7,2)", nullable: true),
                    Colors = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RatingsAverage = table.Column<double>(type: "float", nullable: true),
                    RatingsQuantity = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShoppingCartId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_ShoppingCarts_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "ShoppingCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "CreatedAt", "ImageUrl", "Name", "Slug" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 24, 5, 54, 51, 263, DateTimeKind.Utc).AddTicks(4276), "", "Apple", "apple" },
                    { 2, new DateTime(2024, 5, 24, 5, 54, 51, 263, DateTimeKind.Utc).AddTicks(4278), "", "Samsung", "samsung" },
                    { 3, new DateTime(2024, 5, 24, 5, 54, 51, 263, DateTimeKind.Utc).AddTicks(4279), "", "Sony", "sony" },
                    { 4, new DateTime(2024, 5, 24, 5, 54, 51, 263, DateTimeKind.Utc).AddTicks(4281), "", "Dell", "dell" },
                    { 5, new DateTime(2024, 5, 24, 5, 54, 51, 263, DateTimeKind.Utc).AddTicks(4282), "", "HP", "hp" },
                    { 6, new DateTime(2024, 5, 24, 5, 54, 51, 263, DateTimeKind.Utc).AddTicks(4284), "", "Canon", "canon" },
                    { 7, new DateTime(2024, 5, 24, 5, 54, 51, 263, DateTimeKind.Utc).AddTicks(4285), "", "Nike", "nike" },
                    { 8, new DateTime(2024, 5, 24, 5, 54, 51, 263, DateTimeKind.Utc).AddTicks(4286), "", "Adidas", "adidas" },
                    { 9, new DateTime(2024, 5, 24, 5, 54, 51, 263, DateTimeKind.Utc).AddTicks(4287), "", "Microsoft", "microsoft" },
                    { 10, new DateTime(2024, 5, 24, 5, 54, 51, 263, DateTimeKind.Utc).AddTicks(4289), "", "LG", "lg" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "ImageUrl", "Name", "Slug" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 24, 5, 54, 51, 263, DateTimeKind.Utc).AddTicks(4253), "", "Mobiles", "mobiles" },
                    { 2, new DateTime(2024, 5, 24, 5, 54, 51, 263, DateTimeKind.Utc).AddTicks(4258), "", "Laptops", "laptops" },
                    { 3, new DateTime(2024, 5, 24, 5, 54, 51, 263, DateTimeKind.Utc).AddTicks(4260), "", "Cameras", "cameras" },
                    { 4, new DateTime(2024, 5, 24, 5, 54, 51, 263, DateTimeKind.Utc).AddTicks(4261), "", "Televisions", "televisions" },
                    { 5, new DateTime(2024, 5, 24, 5, 54, 51, 263, DateTimeKind.Utc).AddTicks(4262), "", "Headphones", "headphones" },
                    { 6, new DateTime(2024, 5, 24, 5, 54, 51, 263, DateTimeKind.Utc).AddTicks(4266), "", "Tablets", "tablets" },
                    { 7, new DateTime(2024, 5, 24, 5, 54, 51, 263, DateTimeKind.Utc).AddTicks(4267), "", "Smart Watches", "smart-watches" },
                    { 8, new DateTime(2024, 5, 24, 5, 54, 51, 263, DateTimeKind.Utc).AddTicks(4268), "", "Printers", "printers" },
                    { 9, new DateTime(2024, 5, 24, 5, 54, 51, 263, DateTimeKind.Utc).AddTicks(4269), "", "Gaming Consoles", "gaming-consoles" },
                    { 10, new DateTime(2024, 5, 24, 5, 54, 51, 263, DateTimeKind.Utc).AddTicks(4271), "", "Smart Home Devices", "smart-home-devices" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "Colors", "CreatedAt", "Description", "ImageUrl", "Price", "PriceAfterDiscount", "Quantity", "RatingsAverage", "RatingsQuantity", "Slug", "Sold", "Title" },
                values: new object[,]
                {
                    { 1, 1, 1, "[\"Black\",\"Silver\",\"Gold\"]", new DateTime(2024, 5, 24, 5, 54, 51, 263, DateTimeKind.Utc).AddTicks(4296), "Latest iPhone model with advanced camera features", "", 1099.99m, 999.99m, 100, 4.5, 500, "iphone-13-pro", 22, "iPhone 13 Pro" },
                    { 2, 1, 1, "[\"Phantom Black\",\"Phantom Silver\",\"Phantom Titanium\"]", new DateTime(2024, 5, 24, 5, 54, 51, 263, DateTimeKind.Utc).AddTicks(4308), "Flagship Android smartphone with a powerful camera system", "", 1199.99m, 1099.99m, 150, 4.7999999999999998, 400, "samsung-galaxy-s21-ultra", 28, "Samsung Galaxy S21 Ultra" },
                    { 3, 2, 2, "[\"Platinum Silver\",\"Frost White\",\"Rose Gold\"]", new DateTime(2024, 5, 24, 5, 54, 51, 263, DateTimeKind.Utc).AddTicks(4314), "Thin and powerful laptop with a stunning InfinityEdge display", "", 1299.99m, 1199.99m, 50, 4.5999999999999996, 300, "dell-xps-13", 5, "Dell XPS 13" },
                    { 4, 2, 2, "[\"Space Gray\",\"Silver\"]", new DateTime(2024, 5, 24, 5, 54, 51, 263, DateTimeKind.Utc).AddTicks(4318), "Professional-grade laptop with powerful performance and Retina display", "", 1999.99m, 1899.99m, 30, 4.9000000000000004, 350, "macbook-pro", 7, "MacBook Pro" },
                    { 5, 3, 3, "[\"Space Gray\",\"Silver\"]", new DateTime(2024, 5, 24, 5, 54, 51, 263, DateTimeKind.Utc).AddTicks(4323), "Full-frame mirrorless camera with excellent low-light performance", "", 8999.99m, 1899.99m, 300, 2.8999999999999999, 350, "sony-alpha-a7-iii", 70, "Sony Alpha A7 III" },
                    { 6, 3, 3, "[\"Black\",\"Silver\"]", new DateTime(2024, 5, 24, 5, 54, 51, 263, DateTimeKind.Utc).AddTicks(4328), "High-resolution mirrorless camera with advanced autofocus capabilities", "", 3499.99m, 3299.99m, 80, 4.7000000000000002, 100, "canon-eos-r5", 50, "Canon EOS R5" },
                    { 7, 4, 4, "[\"Stormy Black\",\"Cloudy White\",\"Sunrise Gold\"]", new DateTime(2024, 5, 24, 5, 54, 51, 263, DateTimeKind.Utc).AddTicks(4334), "Google's flagship smartphone with an exceptional camera and 5G capability", "", 999.99m, null, 150, 4.9000000000000004, 200, "google-pixel-6-pro", 100, "Google Pixel 6 Pro" },
                    { 8, 4, 4, "[\"Morning Mist\",\"Pine Green\",\"Stellar Black\"]", new DateTime(2024, 5, 24, 5, 54, 51, 263, DateTimeKind.Utc).AddTicks(4338), "Premium Android smartphone with Hasselblad camera technology", "", 1099.99m, 999.99m, 120, 1.7, 180, "oneplus-9-pro", 80, "OnePlus 9 Pro" },
                    { 9, 5, 5, "[\"Graphite Black\",\"Pine Green\"]", new DateTime(2024, 5, 24, 5, 54, 51, 263, DateTimeKind.Utc).AddTicks(4343), "Ultra-portable business laptop with a durable design and impressive battery life", "", 3499.99m, 2499.99m, 500, 2.6000000000000001, 220, "lenovo-thinkpad-x1-carbon", 400, "Lenovo ThinkPad X1 Carbon" },
                    { 10, 5, 5, "[\"Graphite Black\",\"Rose Gold\"]", new DateTime(2024, 5, 24, 5, 54, 51, 263, DateTimeKind.Utc).AddTicks(4348), "Convertible laptop with sleek design and powerful performance", "", 1499.99m, 1399.99m, 200, 2.6000000000000001, 220, "hp-spectre-x360", 150, "HP Spectre x360" },
                    { 11, 6, 6, "[\"Midnight Blue\"]", new DateTime(2024, 5, 24, 5, 54, 51, 263, DateTimeKind.Utc).AddTicks(4352), "Mirrorless camera with outstanding image quality and in-body stabilization", "", 1299.99m, null, 180, 3.2000000000000002, 180, "fujifilm-x-t4", 120, "Fujifilm X-T4" },
                    { 12, 6, 6, "[\"Rose Gold\"]", new DateTime(2024, 5, 24, 5, 54, 51, 263, DateTimeKind.Utc).AddTicks(4356), "Full-frame mirrorless camera with 24.5 megapixels and 4K video capability", "", 1799.99m, 1599.99m, 250, 4.5, 300, "nikon-z6-ii", 200, "Nikon Z6 II" },
                    { 13, 7, 7, "[\"Space Gray\"]", new DateTime(2024, 5, 24, 5, 54, 51, 263, DateTimeKind.Utc).AddTicks(4360), "Slim and stylish laptop with touchscreen display and excellent keyboard", "", 1899.99m, 1799.99m, 300, 3.8999999999999999, 250, "microsoft-surface-laptop-4", 280, "Microsoft Surface Laptop 4" },
                    { 14, 7, 7, "[\"Silver\",\"Space Gray\"]", new DateTime(2024, 5, 24, 5, 54, 51, 263, DateTimeKind.Utc).AddTicks(4364), "Gaming smartphone with high-refresh-rate display and advanced cooling system", "", 999.99m, 899.99m, 150, 4.0999999999999996, 180, "asus-rog-phone-5", 100, "ASUS ROG Phone 5" },
                    { 15, 8, 8, "[\"Sapphire Blue\",\"Silver\"]", new DateTime(2024, 5, 24, 5, 54, 51, 263, DateTimeKind.Utc).AddTicks(4368), "Next-gen gaming console with fast load times and immersive 4K gaming", "", 2099.99m, 1899.99m, 320, 4.7000000000000002, 280, "sony-playstation-5", 300, "Sony PlayStation 5" },
                    { 16, 8, 8, "[\"Gold\",\"Silver\"]", new DateTime(2024, 5, 24, 5, 54, 51, 263, DateTimeKind.Utc).AddTicks(4375), "Powerful gaming console with 4K resolution and backward compatibility", "", 1399.99m, null, 220, 3.7999999999999998, 200, "xbox-series-x", 200, "Xbox Series X" },
                    { 17, 9, 9, "[\"Coral Red\",\"Gold\"]", new DateTime(2024, 5, 24, 5, 54, 51, 263, DateTimeKind.Utc).AddTicks(4379), "Smart speaker with improved sound quality and built-in Alexa voice assistant", "", 1599.99m, null, 270, 4.2999999999999998, 220, "amazon-echo-(4th-gen)", 240, "Amazon Echo (4th Gen)" },
                    { 18, 9, 9, "[\"Emerald Green\",\"Coral Red\"]", new DateTime(2024, 5, 24, 5, 54, 51, 263, DateTimeKind.Utc).AddTicks(4394), "Smart display with a large screen, perfect for controlling your smart home devices", "", 1199.99m, 1099.99m, 190, 3.6000000000000001, 210, "google-nest-hub-max", 150, "Google Nest Hub Max" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Brands_Name",
                table: "Brands",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ShoppingCartId",
                table: "CartItems",
                column: "ShoppingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name",
                table: "Categories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Title",
                table: "Products",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_UserId",
                table: "ShoppingCarts",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
