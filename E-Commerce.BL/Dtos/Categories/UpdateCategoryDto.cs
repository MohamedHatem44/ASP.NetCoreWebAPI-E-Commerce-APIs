using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.BL.Dtos.Categories
{
    public class UpdateCategoryDto
    {
        [Required(ErrorMessage = "Category Name is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Category Name must be between 3 and 50 characters.")]
        public string Name { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;
    }
}
