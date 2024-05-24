namespace E_Commerce.DAL.Data.Models
{
    public class ShoppingCart
    {
        /*-----------------------------------------------------------------------------*/
        public int Id { get; set; }
        /*-----------------------------------------------------------------------------*/
        // Foreign key to link the ShoppingCart to a User
        public string UserId { get; set; } = string.Empty;
        // Relation With User Table
        // Each ShoppingCart Belong To One User
        // Each User Has One ShoppingCart
        public User User { get; set; } = null!;
        /*-----------------------------------------------------------------------------*/
        // Relation With CartItem Table
        // Each ShoppingCart Has Many CartItems
        // Each CartItem Belong To One ShoppingCart
        public ICollection<CartItem> CartItems { get; set; } = [];
        /*-----------------------------------------------------------------------------*/
    }
}
