using System.ComponentModel.DataAnnotations;

namespace E_Commerce.BL.Dtos.Orders
{
    public class ProductQuantityToCreateOrderDto
    {
        [Required(ErrorMessage = "Product Id is required")]
        public int productId { get; set; }

        [Required(ErrorMessage = "Product Quantity is required")]
        [Range(1, 49, ErrorMessage = "Quantity must be greater than 0 and less than 50")]
        public int quantity { get; set; }
    }
}
