using AutoMapper;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.Dto;

namespace NZWalks.API.Mappings;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<Region, RegionDto>().ReverseMap();
        CreateMap<AddRegionRequestDto, Region>().ReverseMap();
        CreateMap<UpdateRegionRequestDto, Region>().ReverseMap();
        CreateMap<Walk, WalkDto>().ReverseMap();
        CreateMap<AddWalkRequestDto, Walk>().ReverseMap();
        CreateMap<UpdateRegionRequestDto, Walk>().ReverseMap();
        CreateMap<Difficulty, DifficultyDto>().ReverseMap();
        CreateMap<UpdateWalkRequestDto, Walk>().ReverseMap();
    }
}
