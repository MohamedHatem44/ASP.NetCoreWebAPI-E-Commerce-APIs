using E_Commerce.DAL;
using E_Commerce.BL;
using E_Commerce.DAL.Data.Models;
using Microsoft.AspNetCore.Identity;
using E_Commerce.DAL.Data.Context;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.FileProviders;

namespace E_Commerce.APIs
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            /*------------------------------------------------------------------------*/
            var builder = WebApplication.CreateBuilder(args);
            /*------------------------------------------------------------------------*/
            const string AllowAllCorsPolicy = "AllowAll";
            /*------------------------------------------------------------------------*/
            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            /*------------------------------------------------------------------------*/
            builder.Services.AddBLServices();
            builder.Services.AddDALServices(builder.Configuration);
            /*------------------------------------------------------------------------*/
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(AllowAllCorsPolicy, b =>
                {
                    b.AllowAnyOrigin()
                     .AllowAnyMethod()
                     .AllowAnyHeader();
                });
            });
            /*------------------------------------------------------------------------*/
            // Identity
            builder.Services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<E_CommerceContext>()
                .AddDefaultTokenProviders();
            /*------------------------------------------------------------------------*/
            // Authentication
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "defaultSchema";
                options.DefaultChallengeScheme = "defaultSchema";
            }).AddJwtBearer("defaultSchema", options =>
            {
                var keyFromConfig = builder.Configuration.GetValue<string>("SecretKey");
                var keyInBytes = Encoding.ASCII.GetBytes(keyFromConfig!);
                var key = new SymmetricSecurityKey(keyInBytes);

                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = key,
                };
            });
            /*------------------------------------------------------------------------*/
            var app = builder.Build();
            /*------------------------------------------------------------------------*/
            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var roles = new[] { "Admin", "User" };
                foreach (var roleName in roles)
                {
                    if (!await roleManager.RoleExistsAsync(roleName))
                    {
                        await roleManager.CreateAsync(new IdentityRole(roleName));
                    }
                }
            }
            /*------------------------------------------------------------------------*/
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            /*------------------------------------------------------------------------*/
            var staticFilesPath = Path.Combine(Environment.CurrentDirectory, "Images");
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(staticFilesPath),
                RequestPath = "/Images"
            });

            app.UseHttpsRedirection();

            app.UseCors(AllowAllCorsPolicy);

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            await app.RunAsync();
            /*------------------------------------------------------------------------*/
        }
    }
}
