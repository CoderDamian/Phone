﻿using AutoMapper;
using MyPhone.DTO.DTOs;
using MyPhone.Domain.Entities;

namespace MyPhone.ApplicationService.Mappings
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Person, PersonCreateDTO>()
                .ReverseMap();

            CreateMap<Person, PersonDTO>()
                .ReverseMap();

            CreateMap<Person, PersonUpdateDTO>()
                .ReverseMap();
        }
    }
}
