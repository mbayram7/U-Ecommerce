using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.Spesification
{
    public interface ISpecification<T>
    {

        //- ISpecification<T> defines a Criteria expression and a collection of Include expressions.Criteria 
        //    is for storing our filtering expression and Includes is for storing our expressions that determine 
        //    what data we want to include in the query.Note that expressions are nothing more than filter criteria 
        //        you pass into LINQ methods, e.g.Where(p => p.Description == "Test")


        Expression<Func<T, bool>> Criteria { get; }
        List<Expression<Func<T,object>>> Includes { get; }
        Expression<Func<T,object>> OrderBy { get; }
        Expression<Func<T,object>> OrderByDescending { get;  }

        int Take { get; }
        int Skip { get; }
        bool IsPagingEnabled { get; }
    }
}
