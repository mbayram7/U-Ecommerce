using Core.Entities;
using Core.Interfaces;
using Core.Spesification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {

        private readonly StoreContext storeContext;
        public GenericRepository(StoreContext storeContext) 
        {
            this.storeContext = storeContext;
        }



        public async Task<T> GetByIdAsync(int id)  //generic ile çalışıldığı zaman include kullanılmıyor, çok fazla property olduğu zaman çok fazla include yapmak gerekirdi
        {
            return await storeContext.Set<T>().FindAsync(id);
        }  

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await storeContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }
           
        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public async Task<int> CountAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }


        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            //-The ApplySpecification method in the GenericRepository<T> calls the GetQuery method,
            //    passing in the 'raw' data retrieved from the db context as an IQueryable of a generic
            //    dbset.Note that _context.Set<T>()(Assume T = Product) is exactly the same as _context.
            //    Products and allows the generic nature of this implementation.We also pass in the 'spec' 
            //    which defines the filter criteria and additional data to include.


            return SpesificationEvaluator<T>.GetQuery(storeContext.Set<T>().AsQueryable(), spec);  
        }

      
    }
}
