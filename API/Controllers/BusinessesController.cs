using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Core.Interfaces;
using Core.Specifications;
using API.DTOs;
using System.Linq;
using AutoMapper;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BusinessesController : ControllerBase
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
    public async Task<ActionResult<IReadOnlyList<BusinessToReturnDto>>> GetBusinesses()
    {
        var spec = new BusinessesWithCategoriesSpecification();

        var businesses = await _businessRepo.ListAsync(spec);

        return Ok(_mapper
            .Map<IReadOnlyList<Business>, IReadOnlyList<BusinessToReturnDto>>(businesses));
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