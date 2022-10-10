using DataAccess.Entities;
using DataAccess.Entities.Configurations;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions options) : base(options) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);

        //    string connStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StoreDb_2022;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //    optionsBuilder.UseSqlServer(connStr);
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new PhoneConfiguration());

            modelBuilder.SeedColors();
            modelBuilder.SeedPhones();
        }

        public virtual DbSet<Phone> Phones { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
    }
}
