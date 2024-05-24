namespace E_Commerce.BL.Dtos.Orders
{
    public class OrderDetailsDto
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string ShippingAddress { get; set; } = string.Empty;
        public int ItemsCount { get; set; }
        public decimal ShippingPrice { get; set; }
        public decimal TaxPrice { get; set; }
        public decimal TotalOrderPrice { get; set; }
        public string OrderStatus { get; set; } = "In Shipping";
        public string PaymentMethod { get; set; } = "Cash";
        public DateTime CreatedAt { get; set; }
        public IEnumerable<OrderItemsBelongToOrderDto> OrderItems { get; set; } = [];
    }
}
