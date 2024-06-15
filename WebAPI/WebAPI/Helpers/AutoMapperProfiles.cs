using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebAPI.Dtos;
using WebAPI.Models;

namespace WebAPI.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles(){
            CreateMap<City,CityDto>().ReverseMap();
            CreateMap<City, CityDto>().ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id));

            CreateMap<City,CityUpdateDto>().ReverseMap();

            CreateMap<Property,PropertyDto>().ReverseMap();
            CreateMap<Photo, PhotoDto>().ReverseMap();


            CreateMap<Property, PropertyListDto>()
            .ForMember(d => d.City, opt => opt.MapFrom(src => src.City!.Name))
            .ForMember(d => d.Country, opt => opt.MapFrom(src => src.City!.Name))
            .ForMember(d => d.PropertyType, opt => opt.MapFrom(src => src.PropertyType!.Name))
            .ForMember(d => d.FurnishingType, opt => opt.MapFrom(src => src.FurnishingType!.Name))
            .ForMember(d=>d.Photo,opt=>opt.MapFrom(src=>src.Photos
                            .FirstOrDefault(p => p.IsPrimary).ImageUrl));

            CreateMap<Property, PropertyDetailDto>()
            .ForMember(d => d.City, opt => opt.MapFrom(src => src.City!.Name))
            .ForMember(d => d.Country, opt => opt.MapFrom(src => src.City!.Name))
            .ForMember(d => d.PropertyType, opt => opt.MapFrom(src => src.PropertyType!.Name))
            .ForMember(d => d.FurnishingType, opt => opt.MapFrom(src => src.FurnishingType!.Name));

            CreateMap<PropertyType,KeyValuePairDto>().ReverseMap();
            CreateMap<FurnishingType, KeyValuePairDto>().ReverseMap();
        }
    }
}