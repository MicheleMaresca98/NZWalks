using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories;

public class InMemoryRegionRepository : IRegionRepository
{
    public async Task<Region> CreateAsync(Region region)
    {
        return region;
    }

    public async Task<Region?> DeleteAsync(Guid id)
    {
        return new Region()
        {
            Id = id,
            Code = "SAM",
            Name = "Sameer's Region Name"
        };
    }

    public async Task<List<Region>> GetAllAsync()
    {
        return new List<Region>
        {
            new Region()
            {
                Id = Guid.NewGuid(),
                Code = "SAM",
                Name = "Sameer's Region Name"
            }
        };
    }

    public async Task<Region> GetByIdAsync(Guid id)
    {
        return new Region()
        {
            Id = Guid.NewGuid(),
            Code = "SAM",
            Name = "Sameer's Region Name"
        };
    }

    public async Task<Region?> UpdateAsync(Guid id, Region region)
    {
        return region;
    }
}
