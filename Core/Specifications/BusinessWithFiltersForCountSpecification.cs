using Core.Entities;

namespace Core.Specifications
{
    public class BusinessWithFiltersForCountSpecification : BaseSpecification<Business>
    {
        public BusinessWithFiltersForCountSpecification(BusinessSpecParams businessParams)
        : base(x => 
                (string.IsNullOrEmpty(businessParams.Search) || x.Name.ToLower().Contains(businessParams.Search)) && 
                (!businessParams.CategoryId.HasValue || x.BusinessCategoryId == businessParams.CategoryId)
            )
        {

        }
    }
}