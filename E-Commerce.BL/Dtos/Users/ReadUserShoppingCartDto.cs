namespace E_Commerce.BL.Dtos.Users
{
    public class ReadUserShoppingCartDto
    {
        public string Id { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        /*------------------------------------------------------------------------*/
        public ShoppingCartBelongToUserDto ShoppingCart { get; set; } = null!;
        /*------------------------------------------------------------------------*/
    }
}
