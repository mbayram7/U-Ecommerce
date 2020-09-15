using Core.Entities;
using System.Linq;
using Core.Spesification;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SpesificationEvaluator<TEntity> where TEntity : BaseEntity
    {

        //- SpecificationEvaluator<T> and the GetQuery method is used for *applying the
        //    filtering and includes expressions to our query.If a criteria expression exists, 
        //    it is *applied with a 'Where', following by any Include expressions. * Note the
        //    query is not actually executed at this point.To execute the query requires calling
        //    an EF core execution method such as .ToList()


        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec)
        {

            var query = inputQuery;

            if(spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);  // p=>p.ProductTypeId == id gibi oluyor

            }

            if (spec.OrderBy != null)
            {
                query = query.OrderBy(spec.OrderBy);  // p=>p.ProductTypeId == id gibi oluyor

            }

            if (spec.OrderByDescending != null)
            {
                query = query.OrderByDescending(spec.OrderByDescending);  // p=>p.ProductTypeId == id gibi oluyor

            }

            if(spec.IsPagingEnabled)
            {
                query = query.Skip(spec.Skip).Take(spec.Take);
            }



            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));

            return query;

        }
    }
}
 