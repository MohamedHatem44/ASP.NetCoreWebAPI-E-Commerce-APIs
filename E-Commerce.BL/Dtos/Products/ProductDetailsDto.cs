namespace E_Commerce.BL.Dtos.Products
{
    public class ProductDetailsDto
    {
        /*------------------------------------------------------------------------*/
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public int? Sold { get; set; } = 0;
        public decimal Price { get; set; }
        public decimal? PriceAfterDiscount { get; set; }
        public string[]? Colors { get; set; } = [];
        public double? RatingsAverage { get; set; } = 0;
        public int? RatingsQuantity { get; set; } = 0;
        public DateTime CreatedAt { get; set; }
        /*------------------------------------------------------------------------*/
        public ProductCategoryDto Category { get; set; } = null!;
        public ProductBrandDto Brand { get; set; } = null!;
        /*------------------------------------------------------------------------*/
    }
}




