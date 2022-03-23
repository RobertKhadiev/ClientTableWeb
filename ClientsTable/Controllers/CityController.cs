using System.Linq;
using System.Threading.Tasks;
using ClientsTable.Entities;
using ClientsTable.repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClientsTable.Controllers
{
    [ApiController]
    [Route("cities")]
    public class CityController: ControllerBase
    {
        private readonly DataContext _context;

        public CityController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cities = await _context.Cities.ToListAsync();

            if (!cities.Any())
            {
                return BadRequest("Cities not found");
            }
            
            return Ok(cities);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CityEntity cityEntity)
        {
            var result = await _context.Cities.AddAsync(cityEntity);
            await _context.SaveChangesAsync();
            return Ok(result.Entity.Id);
        }
    }
}