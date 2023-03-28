using AutoMapper;
using SuperStore.Data.Models;
using SuperStoreAPI.Views;

namespace SuperStoreAPI.Helpers
{
    public class ProductProfile: Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductView>().ForMember(
                dest => dest.InInventory,
                op => op.MapFrom(src => src.Inventory != 0 ? true : false));
            CreateMap<Product, ProductForCreationView>();
            CreateMap<ProductForCreationView, Product>();
            CreateMap<ProductForUpdateView, Product>();
            CreateMap<ProductForCreationView, ProductView>();
            CreateMap<ProductView, Product>();
        }
    }
}
