using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.DAL.Data.Models
{
    public class Product
    {
        /*------------------------------------------------------------------------*/
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; } = string.Empty;

        public string Slug { get { return GenerateSlug(Title); } private set { } }

        [Required]
        [StringLength(250, MinimumLength = 3)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        public int Quantity { get; set; }

        public int? Sold { get; set; } = 0;

        [Required]
        [Column(TypeName = "decimal(7,2)")]
        public decimal Price { get; set; }

        [Column(TypeName = "decimal(7,2)")]
        public decimal? PriceAfterDiscount { get; set; }

        public string[]? Colors { get; set; } = [];

        [Range(1, 5)]
        public double? RatingsAverage { get; set; } = 0;

        public int? RatingsQuantity { get; set; } = 0;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        /*-----------------------------------------------------------------------------*/
        // Foreign key to link the Product to a Category
        public int CategoryId { get; set; }
        // Relation With Category Table
        // Each Category Has Many Products
        // Each Product Belong To One Category
        public Category Category { get; set; } = null!;
        /*-----------------------------------------------------------------------------*/
        // Foreign key to link the Product to a Brand
        public int BrandId { get; set; }
        // Relation With Brand Table
        // Each Brand Has Many Products
        // Each Product Belong To One Brand
        public Brand Brand { get; set; } = null!;
        /*-----------------------------------------------------------------------------*/
        // Relation With CartItem Table
        // Each Product Has Many CartItems
        // Each CartItem Belong To One Product
        public ICollection<CartItem> CartItems { get; set; } = [];
        /*-----------------------------------------------------------------------------*/
        // Relation With OrderItem Table
        // Each Product Has Many OrderItems
        // Each OrderItem Belong To One Product
        public ICollection<OrderItem> OrderItems { get; set; } = [];
        /*-----------------------------------------------------------------------------*/
        private string GenerateSlug(string input)
        {
            // Convert to lowercase and replace whitespace with hyphens
            string slug = input.ToLower().Replace(" ", "-");
            return slug;
        }
        /*-----------------------------------------------------------------------------*/
    }
}
