using System.ComponentModel.DataAnnotations;

namespace E_Commerce.BL.Dtos.Users
{
    public class CreateUserDto
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "FullName is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "FullName Name must be between 3 and 50 characters.")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Invalid phone number format")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Address is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Address must be between 3 and 100 characters.")]
        public string Address { get; set; } = string.Empty;
    }
}
