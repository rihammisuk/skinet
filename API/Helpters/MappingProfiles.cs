using API.Dtos;
using AutoMapper;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpters
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(m=>m.ProductBrand, o=>o.MapFrom(s=>s.ProductBrand.Name))
                .ForMember(m=>m.ProductType, o=>o.MapFrom(s=>s.ProductType.Name))
                .ForMember(m=>m.PictureUrl,o=> o.MapFrom<ProductUrlResolver>());
        }
    }
}
