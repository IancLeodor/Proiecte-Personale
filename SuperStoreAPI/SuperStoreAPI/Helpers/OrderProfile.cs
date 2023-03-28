using AutoMapper;
using SuperStore.Data.Models;
using SuperStoreAPI.Views;

namespace SuperStoreAPI.Helpers
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderView>().ReverseMap();
            CreateMap<Order, OrderForCreationUpdateView>().ReverseMap();
        }
    }
}
