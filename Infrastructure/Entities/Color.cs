using DataAccess.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public enum Colors : int
    {
        Black = 1,
        Silver,
        SpaceBlack,
        SpaceGrey,
        DeepPurple,
        Starlight,
        Green,
        Gold,
        SierraBlue,
        Midnight
    }
    public class Color : IEntity
    {
        public int Id { get; set; }
        [Required, MinLength(3)]
        public string? Name { get; set; }

        public ICollection<Phone> Phones { get; set; } = new HashSet<Phone>();
    }
}
