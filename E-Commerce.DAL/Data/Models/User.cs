using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.DAL.Data.Models
{
    public class User : IdentityUser
    {
        /*------------------------------------------------------------------------*/
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Address { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        /*------------------------------------------------------------------------*/
        // Relation With ShoppingCart Table
        // Each ShoppingCart Belong To One User
        // Each User Has One ShoppingCart
        public ShoppingCart? ShoppingCart { get; set; }
        /*------------------------------------------------------------------------*/
        // Relation With Order Table
        // Each Order Belong To One User
        // Each User Has Many Orders
        public ICollection<Order> Orders { get; set; } = [];
        /*------------------------------------------------------------------------*/
    }
}