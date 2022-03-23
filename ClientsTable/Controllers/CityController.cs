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

        [HttpGet("{cityId}")]
        public async Task<IActionResult> GetById(int cityId)
        {
            var entity = await _context.Cities.FirstOrDefaultAsync(x => x.Id == cityId);

            if (entity == null) return NotFound();
            
            return Ok(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CityEntity cityEntity)
        {
            var result = await _context.Cities.AddAsync(cityEntity);
            await _context.SaveChangesAsync();
            return Ok(result.Entity.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Update(CityEntity cityEntity)
        {
            _context.Cities.Update(cityEntity);
            await _context.SaveChangesAsync();
            
            return Ok();
        }

        [HttpDelete("{cityId}")]
        public async Task<IActionResult> Delete(int cityId)
        {
            var entity = await _context.Cities.FirstOrDefaultAsync(x=> x.Id == cityId);
            _context.Cities.Remove(entity);
            await _context.SaveChangesAsync();
            
            return Ok();
        }
    }
}