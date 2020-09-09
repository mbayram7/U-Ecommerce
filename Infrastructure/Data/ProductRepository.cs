using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext storeContext;

        public ProductRepository(StoreContext storeContext) //storeContext initialize yapıldı
        {
            this.storeContext = storeContext;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await storeContext.Products.Include(p => p.ProductType).Include(p => p.ProductBrand).FirstOrDefaultAsync(p=>p.Id == id); // bazı bilgiler farklı tablolardan geldiği için include yapıldı
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await storeContext.Products.Include(p=>p.ProductType).Include(p => p.ProductBrand).ToListAsync(); ;
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            return await storeContext.ProductBrands.ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            return await storeContext.ProductTypes.ToListAsync();
        }

    }
}
