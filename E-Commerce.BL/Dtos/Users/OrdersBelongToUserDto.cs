namespace E_Commerce.BL.Dtos.Users
{
    public class OrdersBelongToUserDto
    {
        public int Id { get; set; }
        public int OrderItemsCount { get; set; }
        public decimal ShippingPrice { get; set; }
        public decimal TaxPrice { get; set; }
        public decimal TotalOrderPrice { get; set; }
        public string OrderStatus { get; set; } = "In Shipping";
        public string PaymentMethod { get; set; } = "Cash";
        public DateTime CreatedAt { get; set; }
        /*------------------------------------------------------------------------*/
        public IEnumerable<OrderItemsBelongToUserOrderDto> OrderItems { get; set; } = [];
        /*------------------------------------------------------------------------*/
    }
}
