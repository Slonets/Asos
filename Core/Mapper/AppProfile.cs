﻿using AutoMapper;
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
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.UserRoles, opt => opt.Ignore()); // Assuming UserRoles will be handled separately

            CreateMap<UserEntity, RegisterDto>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Password, opt => opt.Ignore()); // Assuming password won't be mapped back


            CreateMap<EditUserDto, UserEntity>()
           .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
           .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
           .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
           .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
           .ForMember(dest => dest.UserRoles, opt => opt.Ignore());

            CreateMap<UserEntity, EditUserDto>()
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));           
            //.ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.)

            CreateMap<UserEntity, UserViewDto>()
            .ForMember(dest => dest.LockoutEnabled, opt => opt.MapFrom(src=>src.LockoutEnabled))
            .ForMember(dest => dest.LockoutEnd, opt => opt.MapFrom(src => src.LockoutEnd))
            .ForMember(dest=>dest.Roles, opt => opt.MapFrom(src => GetRoleFromUserEntity(src)));

            CreateMap<UserViewDto, UserEntity>()
            .ForMember(dest => dest.UserRoles, opt => opt.MapFrom(src =>src.Roles));
        }

        private string GetRoleFromUserEntity(UserEntity userEntity)
        {
            string result = "";
            foreach (var role in userEntity.UserRoles)
            {
                result += role.Role.Name + " ";
            }

            // Отримання ролі з UserEntity         
            return result;
        }

    }
}
