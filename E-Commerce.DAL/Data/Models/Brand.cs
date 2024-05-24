using System.ComponentModel.DataAnnotations;

namespace E_Commerce.DAL.Data.Models
{
    public class Brand
    {
        /*------------------------------------------------------------------------*/
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string ImageUrl { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public string Slug { get { return GenerateSlug(Name); } private set { } }
        /*-----------------------------------------------------------------------------*/
        // Relation With Product Table
        // Each Brand Has Many Products
        // Each Product Belong To One Brand
        public ICollection<Product> Products { get; set; } = [];
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
