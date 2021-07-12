using Core.Entities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec)
        {
            var query = inputQuery; //inputQuery = Which query is send from repo or controller
            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria); // p => p.ProductTypeId == id
            }

            //Aggregate(Default method) = Total Query | current= Entity that we are passing here (main entity) | include = Expression of our include statements(Include lambda)
            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));
            return query;
        }
    }
}
