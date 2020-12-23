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
    public class FörfattareController : ControllerBase
    {
        private readonly BokbibliotekContext _context;

        public FörfattareController(BokbibliotekContext context)
        {
            _context = context;
        }

        // GET: api/Författare
        //hämta ut författare data
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Författare>>> GetFörfattare()
        {
            return await _context.Författare.ToListAsync();
        }

        // GET: api/Författare/5
        //hämta ut författare data med id
        [HttpGet("{id}")]
        public async Task<ActionResult<Författare>> GetFörfattare(int id)
        {
            var författare = await _context.Författare.FindAsync(id);

            if (författare == null)
            {
                return NotFound();
            }

            return författare;
        }

        // PUT: api/Författare/5
        //Uppdatera författare id
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFörfattare(int id, Författare författare)
        {
            if (id != författare.FörfattareId)
            {
                return BadRequest();
            }

            _context.Entry(författare).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FörfattareExists(id))
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

        // POST: api/Författare
        //Uppdatera författare
        [HttpPost]
        public async Task<ActionResult<Författare>> PostFörfattare(Författare författare)
        {
            _context.Författare.Add(författare);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFörfattare", new { id = författare.FörfattareId }, författare);
        }

        // DELETE: api/Författare/5
        //radera författare id
        [HttpDelete("{id}")]
        public async Task<ActionResult<Författare>> DeleteFörfattare(int id)
        {
            var författare = await _context.Författare.FindAsync(id);
            if (författare == null)
            {
                return NotFound();
            }

            _context.Författare.Remove(författare);
            await _context.SaveChangesAsync();

            return författare;
        }

        private bool FörfattareExists(int id)
        {
            return _context.Författare.Any(e => e.FörfattareId == id);
        }
    }
}
