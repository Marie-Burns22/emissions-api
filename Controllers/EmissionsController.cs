using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmissionApi.Models;

namespace EmissionApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmissionsController : ControllerBase
    {
        private readonly TodoContext _context;

        public EmissionsController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/Emissions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Emission>>> GetEmissions()
        {
            return await _context.Emissions.ToListAsync();
        }

        // GET: api/Emissions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Emission>> GetEmission(long id)
        {
            var Emission = await _context.Emissions.FindAsync(id);

            if (Emission == null)
            {
                return NotFound();
            }

            return Emission;
        }

        // PUT: api/Emissions/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmission(long id, Emission Emission)
        {
            if (id != Emission.Id)
            {
                return BadRequest();
            }

            _context.Entry(Emission).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmissionExists(id))
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

        // POST: api/Emissions
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        /// <summary>
        /// Creates a Emission.
        /// </summary>
        ///<remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "id": 1,
        ///        "name": "Item1",
        ///        "isComplete": true
        ///     }
        ///
        /// </remarks>
        /// <returns>A newly created Emission</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>  
        [HttpPost]
        public async Task<ActionResult<Emission>> PostEmission(Emission Emission)
        {
            _context.Emissions.Add(Emission);
            await _context.SaveChangesAsync();

            // return CreatedAtAction("GetEmission", new { id = Emission.Id }, Emission);
            return CreatedAtAction(nameof(GetEmission), new { id = Emission.Id }, Emission);
        }

        // DELETE: api/Emissions/5
        /// <summary>
        /// Deletes a specific Emission.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Emission>> DeleteEmission(long id)
        {
            var Emission = await _context.Emissions.FindAsync(id);
            if (Emission == null)
            {
                return NotFound();
            }

            _context.Emissions.Remove(Emission);
            await _context.SaveChangesAsync();

            return Emission;
        }

        private bool EmissionExists(long id)
        {
            return _context.Emissions.Any(e => e.Id == id);
        }
    }
}
