using MagicVilla_VillaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_VillaAPI.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }

        public DbSet<Villa> Villas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                new Villa()
                {
                    Id = 1,
                    Name = "Royal Villa",
                    Details = "Lorem Ipsum.",
                    ImageUrl = "",
                    Occupancy = 5,
                    Rate = 200,
                    Sqft = 500,
                    Amenity = "",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                },
                new Villa()
                {
                    Id = 2,
                    Name = "Hills Villa",
                    Details = "Lorem Ipsum.",
                    ImageUrl = "",
                    Occupancy = 7,
                    Rate = 400,
                    Sqft = 390,
                    Amenity = "",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                },
                new Villa()
                {
                    Id = 3,
                    Name = "Diamond Villa",
                    Details = "Lorem Ipsum.",
                    ImageUrl = "",
                    Occupancy = 4,
                    Rate = 300,
                    Sqft = 300,
                    Amenity = "",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                });
        }
    }
}
