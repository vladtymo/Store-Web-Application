namespace BusinessLogic.DTOs
{
    public class PhoneDTO
    {
        public int Id { get; set; }
        public string? Model { get; set; }
        public int ColorId { get; set; }
        public string? ColorName { get; set; }
        public decimal Price { get; set; }
        public int Memory { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
    }
}
