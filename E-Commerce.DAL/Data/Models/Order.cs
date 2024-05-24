using System.ComponentModel.DataAnnotations;

namespace E_Commerce.DAL.Data.Models
{
    public class Order
    {
        /*-----------------------------------------------------------------------------*/
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string PaymentMethod { get; set; } = "Cash";

        [StringLength(50, MinimumLength = 3)]
        public string OrderStatus { get; set; } = "In Shipping";

        public bool IsDelivered { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        /*-----------------------------------------------------------------------------*/
        // Foreign key to link the shopping cart to a user
        public string UserId { get; set; } = string.Empty;
        // Relation With User Table
        // Each Order Belong To One User
        // Each User Has Many Orders
        public User User { get; set; } = null!;
        /*-----------------------------------------------------------------------------*/
        // Relation With OrderItem Table
        // Each Order Has Many OrderItems
        // Each OrderItem Belong To One Order
        public ICollection<OrderItem> OrderItems { get; set; } = [];
        /*-----------------------------------------------------------------------------*/
    }
}
