namespace E_Commerce.BL.Dtos.Brands
{
    public class BrandDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public int ProductsCount { get; set; }
        public IEnumerable<ProductsBelongToBrandDto> Products { get; set; } = [];
    }
}
