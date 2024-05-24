using E_Commerce.BL.Dtos.ShoppingCarts;
using E_Commerce.DAL.Data.Models;

namespace E_Commerce.BL.Mapper.ShoppingCartMapper
{
    public class ShoppingCartMapper : IShoppingCartMapper
    {
        /*------------------------------------------------------------------------*/
        public ShoppingCartDetailsDto MapModelToReadShoppingCartDetails(ShoppingCart shoppingCart)
        {
            return new ShoppingCartDetailsDto
            {
                Id = shoppingCart.Id,
                UserId = shoppingCart.User.Id,
                ItemsCount = shoppingCart.CartItems?.Count ?? 0,
                TotalPrice = CalculateTotalPrice(shoppingCart),
                CartItems = shoppingCart.CartItems != null
             ? shoppingCart.CartItems.Select(cartItem => new CartItemsBelongToShoppingCartDto
             {
                 Id = cartItem.Id,
                 Quantity = cartItem.Quantity,
                 Color = cartItem.Color,
                 CreatedAt = cartItem.CreatedAt,
                 ProductId = cartItem.Product.Id,
                 ProductTitle = cartItem.Product.Title,
                 ItemPrice = CalcItemPrice(cartItem),
             }) : Enumerable.Empty<CartItemsBelongToShoppingCartDto>()
            };
        }
        /*------------------------------------------------------------------------*/
        private decimal CalcItemPrice(CartItem cartItem)
        {
            return cartItem.Product.Price * cartItem.Quantity;
        }
        /*------------------------------------------------------------------------*/
        private decimal CalculateTotalPrice(ShoppingCart shoppingCart)
        {
            decimal totalPrice = 0;
            foreach (var item in shoppingCart.CartItems)
            {
                totalPrice += CalcItemPrice(item);
            }
            return totalPrice;
        }
        /*------------------------------------------------------------------------*/
    }
}
