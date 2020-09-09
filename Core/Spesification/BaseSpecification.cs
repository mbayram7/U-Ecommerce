using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.Spesification
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        //- BaseSpecification<T> is the concrete implementation of our interface. 
        //    It defines Criteria and Includes as properties and an additional method 
        //    for adding include expressions to the Includes collection.


        public BaseSpecification() // parametresiz istek olursa burası çalışıyor
        {
        }      

        public BaseSpecification(Expression<Func<T, bool>> criteria)  // mesela id'ye göre product çekileceği zaman burası çalışıyor, criteria burada id oluyor
        {
            Criteria = criteria;    
        } 



        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; }
            = new List<Expression<Func<T, object>>>();

        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
    }
}
