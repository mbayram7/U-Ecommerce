using AutoMapper;
using Core.Entities;
using Ecommerce.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //ProductToReturnDto class'ında brand ve type string değer tutuluyor, onların değerlerini 
            //çıktı almak için bunu yapmak gerekiyor, dto da class dışı sütunları çekmek için 
            //class ekleme yerine burada bu yapılıyor.

            CreateMap<Product, ProductToReturnDto>()
                .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
                .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>());  // resim urlsini oluşturuyor; https://localhost:5001/images/products/sb-ts1.png" hale getiriyor
        }
    }
}
