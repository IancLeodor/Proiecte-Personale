using AutoMapper;
using SuperStore.Data.Models;
using SuperStoreAPI.Views;

namespace SuperStoreAPI.Helpers
{
    public class OrderProductProfile : Profile
    {
        public OrderProductProfile()
        {
            CreateMap<OrderProduct, OrderProductView>().ForMember(x => x.ProductDescription, opt => opt.MapFrom(src => src.Product.Description))
                .ForMember(x=>x.Category, opt=>opt.MapFrom(src=>"Nume: " + src.Product.Name.ToString() + " - Price: " + src.Product.Price.ToString()));
            CreateMap<OrderProduct, OrderProductForCreationUpdateView>().ReverseMap();
        }
    }
}
