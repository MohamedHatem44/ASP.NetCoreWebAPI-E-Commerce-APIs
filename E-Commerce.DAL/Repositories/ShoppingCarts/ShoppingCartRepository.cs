using E_Commerce.DAL.Data.Context;
using E_Commerce.DAL.Data.Models;
using E_Commerce.DAL.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.DAL.Repositories.ShoppingCarts
{
    public class ShoppingCartRepository : GenericRepository<ShoppingCart>, IShoppingCartRepository
    {
        /*------------------------------------------------------------------------*/
        public ShoppingCartRepository(E_CommerceContext context) : base(context)
        {
        }
        /*------------------------------------------------------------------------*/
        // Get All Shopping Carts With Details
        public IEnumerable<ShoppingCart> GetAllShoppingCartsWithDetails()
        {
            return _context.Set<ShoppingCart>()
                .AsNoTracking()
                   .Include(shoppingCart => shoppingCart.User)
                   .Include(shoppingCart => shoppingCart.CartItems)
                      .ThenInclude(cartItem => cartItem.Product);
        }
        /*------------------------------------------------------------------------*/
        // Get Shopping Cart With Details By User Id
        public ShoppingCart? GetShoppingCartByUserId(string userId)
        {
            return _context.Set<ShoppingCart>()
              .AsNoTracking()
                 .Include(shoppingCart => shoppingCart.User)
                 .Include(shoppingCart => shoppingCart.CartItems)
                    .ThenInclude(cartItem => cartItem.Product)
                 .FirstOrDefault(shoppingCart => shoppingCart.UserId == userId);
        }
        /*------------------------------------------------------------------------*/
        // Add Product To Shopping Cart
        public void AddItemsToShoppingCart(string userId, int productId, int quantity)
        {
            // Check if the user already has a shopping cart
            var cart = _context.ShoppingCarts.FirstOrDefault(sc => sc.UserId == userId);
            // If the user doesn't have a shopping cart, create a new one
            if (cart == null)
            {
                cart = new ShoppingCart { UserId = userId };
                _context.ShoppingCarts.Add(cart);
            }

            var product = _context.Products.Find(productId);
            if (product != null)
            {
                var existingCartItem = _context.CartItems.FirstOrDefault(ci => ci.ProductId == productId && ci.ShoppingCartId == cart.Id);


                if (existingCartItem != null)
                {
                    // If the cart already contains the product, increase its quantity
                    existingCartItem.Quantity += quantity;
                }
                else
                {
                    // Create a new cart item and add it to the cart
                    var cartItem = new CartItem
                    {
                        ProductId = product.Id,
                        //Product = product, 
                        Quantity = quantity,
                        Color = product.Colors != null && product.Colors.Length > 0 ? product.Colors[0] : ""
                    };
                    cart.CartItems.Add(cartItem);
                }

                _context.SaveChanges();
            }
        }
        /*------------------------------------------------------------------------*/
        // Remove a Specific Item From Shopping Cart By User Id and Product Id
        public void RemoveItemFromShoppingCartByProductId(string userId, int productId)
        {
            // Check if the user already has a shopping cart
            var shoppingCart = _context.ShoppingCarts.FirstOrDefault(sc => sc.UserId == userId);
            if(shoppingCart == null)
            {
                return;
            }
            var item = _context.CartItems.FirstOrDefault(ci => ci.ShoppingCartId == shoppingCart.Id && ci.ProductId == productId);
            if (item == null)
            {
                return;
            }
            _context.CartItems.Remove(item);
            _context.SaveChanges();
        }
        /*------------------------------------------------------------------------*/
        // Remove a All Items From Shopping Cart By User Id
        public void RemoveAllItemsFromShoppingCartByUsertId(string userId)
        {
            // Check if the user already has a shopping cart
            var shoppingCart = _context.ShoppingCarts.FirstOrDefault(sc => sc.UserId == userId);
            if (shoppingCart == null)
            {
                return;
            }
            var cartItemsToDelete = _context.CartItems.Where(ci => ci.ShoppingCartId == shoppingCart.Id);
            if (cartItemsToDelete.Any())
            {
                _context.CartItems.RemoveRange(cartItemsToDelete);
                _context.SaveChanges();
            }
        }
        /*------------------------------------------------------------------------*/
        // Edit Item Quantity in Shopping Cart
        public void EditItemQuantity(string userId, int productId, int quantity)
        {
            // Check if the user already has a shopping cart
            var shoppingCart = _context.ShoppingCarts.FirstOrDefault(sc => sc.UserId == userId);
            if (shoppingCart == null)
            {
                return;
            }
            var existingCartItem = _context.CartItems.FirstOrDefault(ci => ci.ProductId == productId && ci.ShoppingCartId == shoppingCart.Id);

            if (existingCartItem != null)
            {
                existingCartItem.Quantity = quantity;
                _context.SaveChanges();
            }
        }
        /*------------------------------------------------------------------------*/
    }
}
