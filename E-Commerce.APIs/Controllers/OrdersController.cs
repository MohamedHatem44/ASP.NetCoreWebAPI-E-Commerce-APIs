using E_Commerce.BL.Dtos.Orders;
using E_Commerce.BL.Managers.Orders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        /*------------------------------------------------------------------------*/
        private readonly IOrderManager _orderManager;
        /*------------------------------------------------------------------------*/
        public OrdersController(IOrderManager orderManager)
        {
            _orderManager = orderManager;
        }
        /*------------------------------------------------------------------------*/
        // Get All Orders
        // Get: api/orders
        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<OrderDetailsDto>> GetAllOrdersWithDetails()
        {
            var orders = _orderManager.GetAllOrdersWithDetails();
            if (!orders.Any())
            {
                return NotFound("No Orders Found");
            }
            int ordersCount = orders.Count();
            var response = new { OrdersCount = ordersCount, Orders = orders };
            return Ok(response);
        }
        /*------------------------------------------------------------------------*/
        // Get Orders By User Clamis
        // Get: api/Orders/UserOrders
        [HttpGet]
        [Route("UserOrders")]
        [Authorize(Roles = "User")]
        public ActionResult<IEnumerable<OrderDetailsDto>> GetOrdersByUserClamis()
        {
            try
            {
                var userOrders = _orderManager.GetOrdersByUserClaims(User);
                int ordersCount = userOrders.Count();
                var response = new { UserOrdersCount = ordersCount, Orders = userOrders };
                return Ok(response);
            }
            catch (Exception ex)
            {
                if (ex is InvalidOperationException)
                {
                    return NotFound(ex.Message);
                }
                else
                {
                    return StatusCode(500, $"An error occurred: {ex.Message}");
                }
            }
        }
        /*------------------------------------------------------------------------*/
        // Get Orders By User Id
        // Get: api/Orders
        [HttpGet]
        [Route("UserOrders/{userId}")]
        [Authorize(Roles = "User")]
        public ActionResult<IEnumerable<OrderDetailsDto>> GetOrdersByUserId(string userId)
        {
            try
            {
                var userOrders = _orderManager.GetOrdersByUserId(userId);
                int ordersCount = userOrders.Count();
                var response = new { UserOrdersCount = ordersCount, Orders = userOrders };
                return Ok(response);
            }
            catch (Exception ex)
            {
                if (ex is InvalidOperationException)
                {
                    return NotFound(ex.Message);
                }
                else
                {
                    return StatusCode(500, $"An error occurred: {ex.Message}");
                }
            }
        }
        /*------------------------------------------------------------------------*/
        // POST: api/orders
        [HttpPost]
        [Authorize(Roles = "User")]
        public ActionResult CreateOrder(List<ProductQuantityToCreateOrderDto> productQuantities)
        {
            try
            {
                _orderManager.CreateOrder(User, productQuantities);
                return Ok("Order created successfully");
            }
            catch (Exception ex)
            {
                if (ex is InvalidOperationException)
                {
                    return NotFound(ex.Message);
                }
                else if (ex is ArgumentException)
                {
                    return BadRequest(ex.Message);
                }
                else
                {
                    return StatusCode(500, $"An error occurred: {ex.Message}");
                }
            }
        }
        /*------------------------------------------------------------------------*/
        // POST: api/orders/CreateOrderFromCart
        [HttpPost]
        [Route("CreateOrderFromCart")]
        [Authorize(Roles = "User")]
        public ActionResult CreateOrderFromCart()
        {
            try
            {
                _orderManager.CreateOrderFromCart(User);
                return Ok("Order created successfully");
            }
            catch (Exception ex)
            {
                if (ex is InvalidOperationException)
                {
                    return NotFound(ex.Message);
                }
                else if (ex is ArgumentException)
                {
                    return BadRequest(ex.Message);
                }
                else
                {
                    return StatusCode(500, $"An error occurred: {ex.Message}");
                }
            }
        }
        /*------------------------------------------------------------------------*/
    }
}
