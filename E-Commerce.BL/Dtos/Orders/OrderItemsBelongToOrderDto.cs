namespace E_Commerce.BL.Dtos.Orders
{
    public class OrderItemsBelongToOrderDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string Color { get; set; } = string.Empty;
        public int ProductId { get; set; }
        public string ProductTitle { get; set; } = string.Empty;
        public decimal ItemPrice { get; set; }
    }
}
