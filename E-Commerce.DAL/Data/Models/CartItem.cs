using System.ComponentModel.DataAnnotations;

namespace E_Commerce.DAL.Data.Models
{
    public class CartItem
    {
        /*-----------------------------------------------------------------------------*/
        public int Id { get; set; }

        [Required]
        [Range(1, 49)]
        public int Quantity { get; set; } = 1;
        public string Color { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /*-----------------------------------------------------------------------------*/
        // Foreign key to link the CartItem to a Shopping Cart
        public int ShoppingCartId { get; set; }
        // Relation With ShoppingCart Table
        // Each ShoppingCart Has Many CartItems
        // Each CartItem Belong To One ShoppingCart
        public ShoppingCart ShoppingCart { get; set; } = null!;
        /*-----------------------------------------------------------------------------*/
        // Foreign key to link the CartItem to a Product
        public int ProductId { get; set; }
        // Relation With Product Table
        // Each Product Has Many CartItems
        // Each CartItem Belong To One Product
        public Product Product { get; set; } = null!;
        /*-----------------------------------------------------------------------------*/
    }
}
