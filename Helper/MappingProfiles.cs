using AutoMapper;
using WebApplication8.Dto;
using WebApplication8.Models;

namespace WebApplication8.Helper;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {            CreateMap<Pokemon, PokemonDto>().ReverseMap();
                 CreateMap<Category, CategoryDto>().ReverseMap();
                 CreateMap<Country, CountryDto>().ReverseMap();
                 CreateMap<Owner, OwnerDto>().ReverseMap();
                 CreateMap<Review, ReviewDto> ().ReverseMap();
                 CreateMap<Owner, OwnerDto>().ReverseMap(); 
                 CreateMap<Reviewer, ReviewerDto>().ReverseMap();

    }
}