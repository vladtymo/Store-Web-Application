using DataAccess.Interfaces;

namespace DataAccess.Entities
{
    public class Phone : IEntity
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int ColorId { get; set; }
        public Color? Color { get; set; }
        public decimal Price { get; set; }
        public int Memory { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
    }
}
