using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data;

public class NZWalksDbContext : DbContext
{
    public NZWalksDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {

    }
    
    public DbSet<Difficulty> Difficulties { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<Walk> Walks { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // Seed data for Difficulties
        // Easy, Medium, Hard

        var difficulties = new List<Difficulty>()
        {
            new Difficulty()
            {
                Id = Guid.Parse("0d2cb1db-b382-44ae-84c3-39709c98b1a2"),
                Name = "Easy"
            },
            new Difficulty()
            {
                Id = Guid.Parse("1a85e1eb-4df9-4b24-93ed-9f43fefcb4ab"),
                Name = "Medium"
            },
            new Difficulty()
            {
                Id = Guid.Parse("11dd282a-ff68-42ef-95c1-fa20f495fcdf"),
                Name = "Hard"
            }
        };

        // Seed difficulties to the database
        builder.Entity<Difficulty>().HasData(difficulties);

        var regions = new List<Region>
        {
            new Region
            {
                Id = Guid.Parse("4d9c68bc-3bf5-4bf7-8c90-d0d1bb6698f2"),
                Name = "Auckland",
                Code = "AKL",
                RegionImageUrl = "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750"
            },
            new Region
            {
                Id = Guid.Parse("34c37640-ecef-46ff-9ab5-ef18c1dd2775"),
                Name = "Northland",
                Code = "NTL",
                RegionImageUrl = null
            },
            new Region
            {
                Id = Guid.Parse("58afc93b-1a82-4465-893b-0298302f7adb"),
                Name = "Bay of Plenty",
                Code = "BOP",
                RegionImageUrl = null
            },
            new Region
            {
                Id = Guid.Parse("1a8c15d1-d98c-48cf-8288-cc539e6338e6"),
                Name = "Wellington",
                Code = "WGN",
                RegionImageUrl = null
            },
            new Region
            {
                Id = Guid.Parse("245b6678-149c-4cf0-9165-66a9dba0ec98"),
                Name = "Nelson",
                Code = "NSN",
                RegionImageUrl = null
            },
            new Region
            {
                Id = Guid.Parse("ce56b4b2-fbb4-43b8-ab90-65408beac04f"),
                Name = "Southland",
                Code = "STL",
                RegionImageUrl = null
            }
        };

        builder.Entity<Region>().HasData(regions);
    }
}
