namespace E_Commerce.BL.Dtos.Users
{
    public class ShoppingCartBelongToUserDto
    {
        public int Id { get; set; }
        public int ItemsCount { get; set; }
        public decimal TotalPrice { get; set; }
        /*------------------------------------------------------------------------*/
        public ICollection<CartItemsBelongToUserShoppingCartDto> CartItems { get; set; } = [];
        /*------------------------------------------------------------------------*/
    }
}
