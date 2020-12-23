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
    public class BokFörfattareController : ControllerBase
    {
        private readonly BokbibliotekContext _context;

        public BokFörfattareController(BokbibliotekContext context)
        {
            _context = context;
        }

        // GET: api/BokFörfattare
        //hämta ut bokförfattare data
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BokFörfattare>>> GetBokFörfattare()
        {
            return await _context.BokFörfattare.ToListAsync();
        }

        // GET: api/BokFörfattare/5
        //hämta ut bokförfattare data med id
        [HttpGet("{id}")]
        public async Task<ActionResult<BokFörfattare>> GetBokFörfattare(int id)
        {
            var bokFörfattare = await _context.BokFörfattare.FindAsync(id);

            if (bokFörfattare == null)
            {
                return NotFound();
            }

            return bokFörfattare;
        }

        // PUT: api/BokFörfattare/5
        //Uppdatera bokförfattare id
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBokFörfattare(int id, BokFörfattare bokFörfattare)
        {
            if (id != bokFörfattare.BokId)
            {
                return BadRequest();
            }

            _context.Entry(bokFörfattare).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BokFörfattareExists(id))
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

        // POST: api/BokFörfattare
        //Uppdatera bokförfattare
        [HttpPost]
        public async Task<ActionResult<BokFörfattare>> PostBokFörfattare(BokFörfattare bokFörfattare)
        {
            _context.BokFörfattare.Add(bokFörfattare);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BokFörfattareExists(bokFörfattare.BokId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBokFörfattare", new { id = bokFörfattare.BokId }, bokFörfattare);
        }

        // DELETE: api/BokFörfattare/5
        //radera bokförfattare id
        [HttpDelete("{id}")]
        public async Task<ActionResult<BokFörfattare>> DeleteBokFörfattare(int id)
        {
            var bokFörfattare = await _context.BokFörfattare.FindAsync(id);
            if (bokFörfattare == null)
            {
                return NotFound();
            }

            _context.BokFörfattare.Remove(bokFörfattare);
            await _context.SaveChangesAsync();

            return bokFörfattare;
        }

        private bool BokFörfattareExists(int id)
        {
            return _context.BokFörfattare.Any(e => e.BokId == id);
        }
    }
}
