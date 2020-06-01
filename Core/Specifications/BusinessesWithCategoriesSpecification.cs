using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class BusinessesWithCategoriesSpecification : BaseSpecification<Business>
    {
        public BusinessesWithCategoriesSpecification(BusinessSpecParams businessParams) 
            : base(x => 
                (string.IsNullOrEmpty(businessParams.Search) || x.Name.ToLower().Contains(businessParams.Search)) && 
                (!businessParams.CategoryId.HasValue || x.BusinessCategoryId == businessParams.CategoryId)
            )
        {
            AddInclude(x => x.BusinessCategory);
            AddOrderBy(x => x.Name);
            ApplyPaging(businessParams.PageSize * (businessParams.PageIndex - 1), businessParams.PageSize);

            if(!string.IsNullOrEmpty(businessParams.Sort))
            {
                switch(businessParams.Sort)
                {
                    case "contactAsc":
                        AddOrderBy(p => p.ContactPerson);
                        break;

                    case "contactDesc":
                        AddOrderByDescending(p => p.ContactPerson);
                        break;

                    default:
                        AddOrderBy(p => p.Name);
                        break;

                }
            }
        }

        

        public BusinessesWithCategoriesSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.BusinessCategory);
        }
    }
}