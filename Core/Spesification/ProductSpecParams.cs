using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Spesification
{
    public class ProductSpecParams
    {
        private const int MaxPageSize = 50; //const sabitlerde kullanılıyor
        public int PageIndex { get; set; } = 1;

        private int pageSize = 6;

        public int PageSize
        {
            get => pageSize;
            set => pageSize = (value > MaxPageSize) ? MaxPageSize : value; //maxpage
        }

        public int? BrandId { get; set; }
        public int? TypeId { get; set; }
        public string Sort { get; set; }

        private string search;

        public string Search
        {
            get => search;
            set => search = value.ToLower();
        }
    }
}
