namespace E_Commerce.BL.Dtos.ShoppingCarts
{
    public class CartItemsBelongToShoppingCartDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; } = 1;
        public string Color { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public int ProductId { get; set; }
        public string ProductTitle { get; set; } = string.Empty;
        public decimal ItemPrice { get; set; }
    }
}
