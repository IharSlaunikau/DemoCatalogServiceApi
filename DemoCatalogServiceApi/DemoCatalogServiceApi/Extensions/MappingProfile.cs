using AutoMapper;
using DemoCatalogServiceApi.DataAccess.Nortwind.Entities;
using DemoCatalogServiceApi.Models.Requests;

namespace DemoCatalogServiceApi.Extensions
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PostAddProductRequest, Product>();
            CreateMap<PutEditProductRequest, Product>();

            CreateMap<PostAddCategoryRequest, Category>();
            CreateMap<PutEditCategoryRequest, Category>();
        }
    }
}
