namespace E_Commerce.BL.Dtos.ShoppingCarts
{
    public class ShoppingCartDetailsDto
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public int ItemsCount { get; set; }
        public decimal TotalPrice { get; set; }
        
        public IEnumerable<CartItemsBelongToShoppingCartDto> CartItems { get; set; } = [];
    }
}
