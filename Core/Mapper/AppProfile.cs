using AutoMapper;
using Core.DTO.Authentication;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapper
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            //UserEntity -> LoginDto
            CreateMap<UserEntity, LoginDto>().ReverseMap();

            CreateMap<RegisterDto, UserEntity>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Image, opt => opt.Ignore()) //коли перетворюємо, то поле Image ігнорується    
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.UserRoles, opt => opt.Ignore()); // Assuming UserRoles will be handled separately

            CreateMap<UserEntity, RegisterDto>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Password, opt => opt.Ignore()) // Assuming password won't be mapped back
                .ForMember(dest => dest.ConfirmPassword, opt => opt.Ignore()); // Assuming password won't be mapped back
                

        }      

    }
}
