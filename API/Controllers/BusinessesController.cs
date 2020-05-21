using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BusinessesController : ControllerBase
    {
        private readonly StoreContext _context;
        public BusinessesController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Business>>> GetBusinesses()
        {
            var businesses = await _context.Businesses.ToListAsync();
            return Ok(businesses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Business>> GetBusiness(int id)
        {
            return await _context.Businesses.FindAsync(id);
        }
    }
}