using AutoMapper;
using SuperStore.Data.Models;
using SuperStoreAPI.Views;

namespace SuperStoreAPI.Helpers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserView>()
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(
                    dest => dest.Address,
                    opt => opt.MapFrom(src => $"{src.Address.Country}, {src.Address.City}, {src.Address.Street} {src.Address.Number}"));
           
            CreateMap<UserCreationView, User>();
        }
    }
}
