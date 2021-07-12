using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification()
        {
        }

        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public Expression<Func<T, bool>> Criteria { get; } // For Where linq statement

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>(); // For Include statement for Eager loading

        protected void AddInclude(Expression<Func<T, object>> IncludeExpression) //For Add Multiple Include (List of Include)
        {
            Includes.Add(IncludeExpression);
        }
    }
}
