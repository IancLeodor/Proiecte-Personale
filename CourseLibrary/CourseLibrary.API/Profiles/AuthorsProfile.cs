using AutoMapper;
using CourseLibrary.API.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLibrary.API.Profiles
{
    public class AuthorsProfile : Profile
    {
        public AuthorsProfile()
        {
            CreateMap<Entities.Author, Models.AuthorDto>()
                .ForMember(
                    dest => dest.Name, //numele de destinatie a obiectului 
                    opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))// ne dorim sa fie cartografiat de la prenumele si prenumele sursei 
                .ForMember(
                    dest => dest.Age, //ne asiguram ca hartile sunt in varsta actuala a autorului
                    opt => opt.MapFrom(src => src.DateOfBirth.GetCurrentAge()));

            CreateMap<Models.AuthorForCreationDto, Entities.Author>();

        }
    }
}
