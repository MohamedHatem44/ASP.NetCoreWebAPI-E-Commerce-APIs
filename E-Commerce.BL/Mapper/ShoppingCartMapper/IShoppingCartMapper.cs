using E_Commerce.BL.Dtos.ShoppingCarts;
using E_Commerce.DAL.Data.Models;

namespace E_Commerce.BL.Mapper.ShoppingCartMapper
{
    public interface IShoppingCartMapper
    {
        /*------------------------------------------------------------------------*/
        public ShoppingCartDetailsDto MapModelToReadShoppingCartDetails(ShoppingCart shoppingCart);
        /*------------------------------------------------------------------------*/
    }
}
