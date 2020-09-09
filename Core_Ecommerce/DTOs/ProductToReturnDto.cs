using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.DTOs
{
    public class ProductToReturnDto
    {
        //     AutoMapper, projemizde Entity nesnelerini database’den çektiğimiz haliyle değil,
        //    bu nesneleri istediğimiz(UI’da bizim için gerekli olacak) formata çevirmemizi 
        //    sağlayan basit bir kütüphanedir.DTO(Data Transfer Object) ise AutoMapper’ın
        //    dönüştürmesini istediğimiz format modelidir.


        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }

  
        public string ProductType { get; set; }

  
        public string ProductBrand { get; set; }
    }
}
