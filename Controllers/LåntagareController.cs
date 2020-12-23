using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BokBibliotek.Data;
using BokBibliotek.Models;

namespace BokBibliotek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LåntagareController : ControllerBase
    {
        private readonly BokbibliotekContext _context;

        public LåntagareController(BokbibliotekContext context)
        {
            _context = context;
        }

        // GET: api/Låntagare
        //hämta ut låntagare data
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Låntagare>>> GetLåntagare()
        {
            return await _context.Låntagare.ToListAsync();
        }

        // GET: api/Låntagare/5
        //hämta ut låntagare data med id
        [HttpGet("{id}")]
        public async Task<ActionResult<Låntagare>> GetLåntagare(int id)
        {
            var låntagare = await _context.Låntagare.FindAsync(id);

            if (låntagare == null)
            {
                return NotFound();
            }

            return låntagare;
        }

        // PUT: api/Låntagare/5
        //Uppdatera lånetagare id
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLåntagare(int id, Låntagare låntagare)
        {
            if (id != låntagare.LåntagareId)
            {
                return BadRequest();
            }

            _context.Entry(låntagare).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LåntagareExists(id))
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

        // POST: api/Låntagare
        //Uppdatera lånetagare
        [HttpPost]
        public async Task<ActionResult<Låntagare>> PostLåntagare(Låntagare låntagare)
        {
            _context.Låntagare.Add(låntagare);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLåntagare", new { id = låntagare.LåntagareId }, låntagare);
        }

        // DELETE: api/Låntagare/5
        //radera lånetagare id
        [HttpDelete("{id}")]
        public async Task<ActionResult<Låntagare>> DeleteLåntagare(int id)
        {
            var låntagare = await _context.Låntagare.FindAsync(id);
            if (låntagare == null)
            {
                return NotFound();
            }

            _context.Låntagare.Remove(låntagare);
            await _context.SaveChangesAsync();

            return låntagare;
        }

        private bool LåntagareExists(int id)
        {
            return _context.Låntagare.Any(e => e.LåntagareId == id);
        }
    }
}
