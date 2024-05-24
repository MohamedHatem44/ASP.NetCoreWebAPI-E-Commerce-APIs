using System.ComponentModel.DataAnnotations;

namespace E_Commerce.BL.Dtos.Brands
{
    public class UpdateBrandDto
    {
        [Required(ErrorMessage = "Brand Name is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Brand Name must be between 3 and 50 characters.")]
        public string Name { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;
    }
}
