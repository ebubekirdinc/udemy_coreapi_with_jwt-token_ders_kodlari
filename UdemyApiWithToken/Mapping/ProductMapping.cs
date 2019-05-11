using AutoMapper;
using UdemyApiWithToken.Domain;
using UdemyApiWithToken.Resources;

namespace UdemyApiWithToken.Mapping
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<ProductResource, Product>();
            CreateMap<Product, ProductResource>();
        }
    }
}