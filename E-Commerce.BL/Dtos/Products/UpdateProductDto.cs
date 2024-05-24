using E_Commerce.DAL.Validators;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace E_Commerce.BL.Dtos.Products
{
    public class UpdateProductDto
    {
        /*------------------------------------------------------------------------*/
        [Required(ErrorMessage = "Product Title is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Product Title must be between 3 and 50 characters.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Product Description is required.")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "Product Description must be between 3 and 250 characters.")]
        public string Description { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public int Quantity { get; set; }

        public int? Sold { get; set; } = 0;

        [Column(TypeName = "decimal(7,2)")]
        public decimal Price { get; set; }

        [Column(TypeName = "decimal(7,2)")]
        [LessThan("Price", ErrorMessage = "Price after discount must be less than Price.")]
        public decimal? PriceAfterDiscount { get; set; }

        public string[]? Colors { get; set; } = [];

        [Range(1, 5, ErrorMessage = "Product Ratings Average must be between 1 and 5")]
        public double? RatingsAverage { get; set; } = 0;

        public int? RatingsQuantity { get; set; } = 0;
        /*-----------------------------------------------------------------------------*/
        //FK From Category Table
        [Required(ErrorMessage = "Category ID is required.")]
        public int CategoryId { get; set; }
        /*-----------------------------------------------------------------------------*/
        //FK From Brand Table
        [Required(ErrorMessage = "Brand ID is required.")]
        public int BrandId { get; set; }
        /*-----------------------------------------------------------------------------*/
    }
}
