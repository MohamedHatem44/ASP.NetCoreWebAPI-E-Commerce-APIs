using E_Commerce.BL.Dtos.Orders;
using E_Commerce.DAL.Data.Models;

namespace E_Commerce.BL.Mapper.OrderMapper
{
    public class OrderMapper : IOrderMapper
    {
        /*------------------------------------------------------------------------*/
        public OrderDetailsDto MapModelToReadOrderDetails(Order order)
        {
            return new OrderDetailsDto
            {
                Id = order.Id,
                UserId = order.UserId,
                FullName = order.User.FullName,
                PhoneNumber = order.User.PhoneNumber ?? "",
                ShippingAddress = order.User.Address,
                ItemsCount = order.OrderItems.Count,
                ShippingPrice = ClacShippingPrice(order),
                TaxPrice = ClacTaxPrice(order),
                TotalOrderPrice = CalculateTotalPrice(order),
                OrderStatus = order.OrderStatus,
                CreatedAt = order.CreatedAt,
                OrderItems = order.OrderItems != null
                    ? order.OrderItems.Select(orderItem => new OrderItemsBelongToOrderDto
                    {
                        Id = orderItem.Id,
                        Quantity = orderItem.Quantity,
                        Color = orderItem.Color,
                        ProductId = orderItem.Product.Id,
                        ProductTitle = orderItem.Product.Title,
                        ItemPrice = CalcItemPrice(orderItem)
                    }) : Enumerable.Empty<OrderItemsBelongToOrderDto>()
            };
        }
        /*------------------------------------------------------------------------*/
        public Order MapCreateOrderToModel(string userId)
        {
            return new Order
            {
                UserId = userId,
                OrderStatus = "Pending",
            };
        }
        /*------------------------------------------------------------------------*/
        public OrderItem MapCreateOrderItemToModel(CartItem cartItem)
        {
            return new OrderItem
            {
                ProductId = cartItem.ProductId,
                Quantity = cartItem.Quantity,
                Color = cartItem.Color,
            };
        }
        /*------------------------------------------------------------------------*/
        public OrderItem MapCreateOrderItemToModel(ProductQuantityToCreateOrderDto productQuantity, Product product)
        {
            return new OrderItem
            {
                ProductId = productQuantity.productId,
                Quantity = productQuantity.quantity,
                Color = product.Colors != null && product.Colors.Length > 0 ? product.Colors[0] : "",
            };
        }
        /*------------------------------------------------------------------------*/
        private decimal CalcItemPrice(OrderItem orderItem)
        {
            return orderItem.Product.Price * orderItem.Quantity;
        }
        /*------------------------------------------------------------------------*/
        private decimal ClacShippingPrice(Order order)
        {
            var shippingRatio = 0.05m;
            return order.OrderItems.Sum(item => item.Product.Price * item.Quantity) * shippingRatio;
        }
        /*------------------------------------------------------------------------*/
        private decimal ClacTaxPrice(Order order)
        {
            var taxRatio = 0.14m;
            return order.OrderItems.Sum(item => item.Product.Price * item.Quantity) * taxRatio;
        }
        /*------------------------------------------------------------------------*/
        private decimal CalculateTotalPrice(Order order)
        {
            decimal totalPrice = 0;
            foreach (var item in order.OrderItems)
            {
                totalPrice += CalcItemPrice(item);
            }
            totalPrice += ClacShippingPrice(order);
            totalPrice += ClacTaxPrice(order);
            return totalPrice;
        }
        /*------------------------------------------------------------------------*/
    }
}
