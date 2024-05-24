using E_Commerce.BL.Dtos.Orders;
using E_Commerce.DAL.Data.Models;

namespace E_Commerce.BL.Mapper.OrderMapper
{
    public interface IOrderMapper
    {
        /*------------------------------------------------------------------------*/
        public OrderDetailsDto MapModelToReadOrderDetails(Order order);
        /*------------------------------------------------------------------------*/
        public Order MapCreateOrderToModel(string userId);
        /*------------------------------------------------------------------------*/
        public OrderItem MapCreateOrderItemToModel(CartItem cartItem);
        /*------------------------------------------------------------------------*/
        public OrderItem MapCreateOrderItemToModel(ProductQuantityToCreateOrderDto productQuantity, Product product);
        /*------------------------------------------------------------------------*/
    }
}
