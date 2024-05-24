namespace E_Commerce.BL.Dtos.Users
{
    public class ReadUserOrdersDto
    {
        public string Id { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public int OrdersCount { get; set; }
        /*------------------------------------------------------------------------*/
        public IEnumerable<OrdersBelongToUserDto> Orders { get; set; } = [];
        /*------------------------------------------------------------------------*/
    }
}
