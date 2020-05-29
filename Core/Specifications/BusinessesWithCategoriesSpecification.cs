using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class BusinessesWithCategoriesSpecification : BaseSpecification<Business>
    {
        public BusinessesWithCategoriesSpecification()
        {
            AddInclude(x => x.BusinessCategory);
        }

        public BusinessesWithCategoriesSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.BusinessCategory);
        }
    }
}