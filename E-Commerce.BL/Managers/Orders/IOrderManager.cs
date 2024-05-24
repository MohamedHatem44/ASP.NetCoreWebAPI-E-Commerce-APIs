using E_Commerce.BL.Dtos.Orders;
using System.Security.Claims;

namespace E_Commerce.BL.Managers.Orders
{
    public interface IOrderManager
    {
        /*------------------------------------------------------------------------*/
        // Get All Orders With Details
        IEnumerable<OrderDetailsDto> GetAllOrdersWithDetails();
        /*------------------------------------------------------------------------*/
        // Get Orders By User Clamis
        IEnumerable<OrderDetailsDto> GetOrdersByUserClaims(ClaimsPrincipal claimsPrincipal);
        /*------------------------------------------------------------------------*/
        // Get Orders By User Id
        IEnumerable<OrderDetailsDto> GetOrdersByUserId(string userId);
        /*------------------------------------------------------------------------*/
        // Place Order
        void CreateOrder(ClaimsPrincipal claimsPrincipal, List<ProductQuantityToCreateOrderDto> productQuantities);
        /*------------------------------------------------------------------------*/
        // Place Order From Shopping Cart
        void CreateOrderFromCart(ClaimsPrincipal claimsPrincipal);
        /*------------------------------------------------------------------------*/
    }
}
