namespace WizardAcademyDropouts.Maps;

using AutoMapper;
using DTOs;
using Domain.Entities;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Failure, string>();
        CreateMap<string, Failure>().ConvertUsing(src => Failure.FromNameIgnoreCase(src));
        CreateMap<Knack, string>();
        CreateMap<string, Knack>().ConvertUsing(src => Knack.FromNameIgnoreCase(src));
        CreateMap<Character, CharacterDTO>()
            .ReverseMap()
            .ForMember(dest => dest.Inventory, opt => opt.MapFrom(src =>
            src.Inventory.Where(item => !string.IsNullOrWhiteSpace(item))
                .Select(item => new Item(0, item, src.Id))));
        CreateMap<Character, CharacterListItemDTO>();
    }
}