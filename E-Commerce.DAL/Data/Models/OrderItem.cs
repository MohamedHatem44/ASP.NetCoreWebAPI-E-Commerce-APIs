using System.ComponentModel.DataAnnotations;

namespace E_Commerce.DAL.Data.Models
{
    public class OrderItem
    {
        /*-----------------------------------------------------------------------------*/
        public int Id { get; set; }
        [Required]
        [Range(1, 49)]
        public int Quantity { get; set; } = 1;
        public string Color { get; set; } = string.Empty;
        /*-----------------------------------------------------------------------------*/
        // Foreign key to link the OrderItem to a Order
        public int OrderId { get; set; }
        // Relation With Order Table
        // Each Order Has Many OrderItems
        // Each OrderItem Belong To One Order
        public Order Order { get; set; } = null!;
        /*-----------------------------------------------------------------------------*/
        // Foreign key to link the OrderItem to a Product
        public int ProductId { get; set; }
        // Relation With Product Table
        // Each Product Has Many OrderItems
        // Each OrderItem Belong To One Product
        public Product Product { get; set; } = null!;
        /*-----------------------------------------------------------------------------*/
    }
}
