using Application.Responses;
using AutoMapper;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserResponse>().ReverseMap();
    }
}