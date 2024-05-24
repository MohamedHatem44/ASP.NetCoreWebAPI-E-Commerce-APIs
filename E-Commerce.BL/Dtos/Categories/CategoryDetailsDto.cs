namespace E_Commerce.BL.Dtos.Categories
{
    public class CategoryDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public int ProductsCount { get; set; }
        public IEnumerable<ProductsBelongToCategoryDto> Products { get; set; } = [];
    }
 
}
