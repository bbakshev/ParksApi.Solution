using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParksApi.Models;

namespace ParksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParksController : ControllerBase
    {
        private readonly ParksApiContext _db;

        public ParksController(ParksApiContext db)
        {
            _db = db;
        }

        // GET api/parks
        [HttpGet]
        public async Task<IActionResult> GetParks(int id, string name, string state, string description, string established, int page = 1, int pageSize = 5)
        {
            IQueryable<Park> query = _db.Parks.AsQueryable();

            if (name != null)
            {
                query = query.Where(entry => entry.Name == name);
            }

            if (state != null)
            {
                query = query.Where(entry => entry.State == state);
            }

            if (description != null)
            {
                query = query.Where(entry => entry.Description == description);
            }

            if (established != null)
            {
                query = query.Where(entry => entry.Established == established);
            }

            if (id != 0)
            {
                query = query.Where(entry => entry.ParkId == id);
            }

            int skip = (page - 1) * pageSize;

            List<Park> parks = await query
                        .Skip(skip)
                        .Take(pageSize)
                        .ToListAsync();

            int totalCount = _db.Parks.Count();

            var response = new
            {
                totalCount = totalCount,
                pageSize = pageSize,
                page = page,
                parks = parks
            };

            return Ok(response);
        }

        // GET api/parks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Park>> GetPark(int id)
        {
            Park park = await _db.Parks.FirstOrDefaultAsync(entry => entry.ParkId == id);
            if (park == null)
            {
                return NotFound();
            }
            return park;
        }

        // POST api/parks
        [HttpPost]
        public async Task<ActionResult<Park>> Post(Park park)
        {
            _db.Parks.Add(park);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPark), new { id = park.ParkId }, park);
        }

        // PUT api/parks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Park park)
        {
            if (id != park.ParkId)
            {
                return BadRequest();
            }
            _db.Parks.Update(park);

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParkExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

    private bool ParkExists(int id)
    {
        return _db.Parks.Any(park => park.ParkId == id);
    }

    // DELETE api/parks/5
    [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePark(int id)
        {
            Park park = await _db.Parks.FindAsync(id);
            if (park == null)
            {
                return NotFound();
            }
            _db.Parks.Remove(park);
            await _db.SaveChangesAsync();
            
            return NoContent();
        }
    }
}