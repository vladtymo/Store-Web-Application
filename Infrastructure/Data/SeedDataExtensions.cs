using BusinessLogic.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data
{
    public static class SeedDataExtensions
    {
        public static void SeedPhones(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Phone>().HasData(new Phone[]
            {
                new Phone()
                {
                    Id = 1,
                    Model = "iPhone 14",
                    ColorId = (int)Colors.Midnight,
                    Memory = 128,
                    Price = 799,
                    Description = "A total powerhouse.",
                    ImageUrl = @"https://estore.ua/ua/media/catalog/product/cache/9/image/600x600/9df78eab33525d08d6e5fb8d27136e95/i/p/iphone-14-finish-select-202209-6-1inch-midnight_1.png"
                },
                new Phone()
                {
                    Id = 2,
                    Model = "iPhone 14 Plus",
                    ColorId = (int)Colors.Starlight,
                    Memory = 128,
                    Price = 899,
                    Description = "Big and bigger.",
                    ImageUrl = @"https://estore.ua/ua/media/catalog/product/cache/9/image/600x600/9df78eab33525d08d6e5fb8d27136e95/i/p/iphone-14-plus_2__3.jpeg"
                },
                new Phone()
                {
                    Id = 3,
                    Model = "iPhone 14 Pro",
                    ColorId = (int)Colors.SpaceBlack,
                    Memory = 256,
                    Price = 1099,
                    Description = "The ultimate iPhone.",
                    ImageUrl = @"https://estore.ua/ua/media/catalog/product/cache/9/image/600x600/9df78eab33525d08d6e5fb8d27136e95/1/4/14pro-promax-black-1_4_2.jpeg"
                },
                new Phone()
                {
                    Id = 4,
                    Model = "iPhone 14 Pro Max",
                    ColorId = (int)Colors.DeepPurple,
                    Memory = 512,
                    Price = 1399,
                    Description = "Pro. Beyond.",
                    ImageUrl = @"https://estore.ua/ua/media/catalog/product/cache/9/image/600x600/9df78eab33525d08d6e5fb8d27136e95/1/4/14pro-promax-purple-1_9.jpeg"
                }
            });
        }
        public static void SeedColors(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Color>().HasData(new Color[]
            {
                new Color() { Id = (int)Colors.Silver, Name = "Silver" },
                new Color() { Id = (int)Colors.Black, Name = "Black" },
                new Color() { Id = (int)Colors.SpaceBlack, Name = "Space Black" },
                new Color() { Id = (int)Colors.SpaceGrey, Name = "Space Grey" },
                new Color() { Id = (int)Colors.DeepPurple, Name = "Deep Purple" },
                new Color() { Id = (int)Colors.Starlight, Name = "Starlight" },
                new Color() { Id = (int)Colors.Green, Name = "Green" },
                new Color() { Id = (int)Colors.Gold, Name = "Gold" },
                new Color() { Id = (int)Colors.SierraBlue, Name = "Sierra Blue" },
                new Color() { Id = (int)Colors.Midnight, Name = "Midnight" },
            });
        }
    }
}
