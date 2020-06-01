using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Core.Interfaces;
using Core.Specifications;
using API.DTOs;
using System.Linq;
using AutoMapper;
using API.Helpers;

namespace API.Controllers
{
    public class BusinessesController : BaseApiController
    {
        private readonly IGenericRepository<Business> _businessRepo;
        private readonly IGenericRepository<BusinessCategory> _businessCategoryRepo;
        private readonly IMapper _mapper;
        public BusinessesController(IGenericRepository<Business> businessRepo,
                                    IGenericRepository<BusinessCategory> businessCategoryRepo,
                                    IMapper mapper)        
        {
            _mapper = mapper;
            _businessCategoryRepo = businessCategoryRepo;
            _businessRepo = businessRepo;
        }

    [HttpGet]
    public async Task<ActionResult<Pagination<BusinessToReturnDto>>> GetBusinesses([FromQuery]BusinessSpecParams businessParams)
    {
        var spec = new BusinessesWithCategoriesSpecification(businessParams);

        var countSpec = new BusinessWithFiltersForCountSpecification(businessParams);
        
        var totalItems = await _businessRepo.CountAsync(spec);

        var businesses = await _businessRepo.ListAsync(spec);

        var data = _mapper
                .Map<IReadOnlyList<Business>, IReadOnlyList<BusinessToReturnDto>>(businesses);

        return Ok(new Pagination<BusinessToReturnDto>(businessParams.PageIndex, businessParams.PageSize, totalItems, data));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BusinessToReturnDto>> GetBusiness(int id)
    {
        var spec = new BusinessesWithCategoriesSpecification(id);

        var business = await _businessRepo.GetEntityWithSpec(spec);

        return _mapper.Map<Business, BusinessToReturnDto>(business);

    }

    [HttpGet("categories")]
    public async Task<ActionResult<BusinessCategory>> GetBusinessCategories()
    {
        return Ok(await _businessCategoryRepo.ListAllAsync());
    }


}
}