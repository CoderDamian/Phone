﻿using AutoMapper;
using MyPhone.ApplicationService.DTOs;
using MyPhone.Domain.Entities;

namespace MyPhone.ApplicationService.Mappings
{
    public class PhoneProfile : Profile
    {
        public PhoneProfile()
        {
            CreateMap<Phone, PhoneCreateDTO>()
                .ReverseMap();

            CreateMap<Phone, PhoneDTO>()
                .ReverseMap();

            CreateMap<Phone, PersonUpdateDTO>()
                .ReverseMap();
        }
    }
}
