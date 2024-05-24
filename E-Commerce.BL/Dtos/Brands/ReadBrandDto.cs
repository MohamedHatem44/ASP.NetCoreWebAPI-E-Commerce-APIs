namespace E_Commerce.BL.Dtos.Brands
{
    public class ReadBrandDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
