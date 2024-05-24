using System.ComponentModel.DataAnnotations;

namespace E_Commerce.BL.Dtos.ShoppingCarts
{
    public class EditItemQuantityDto
    {
        [Required(ErrorMessage = "Product Id is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Product Id must be greater than 0")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, 49, ErrorMessage = "Quantity must be greater than 0 and less than 50")]
        public int Quantity { get; set; }
    }
}
