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
    public class BoksController : ControllerBase
    {
        private readonly BokbibliotekContext _context;

        public BoksController(BokbibliotekContext context)
        {
            _context = context;
        }

        // GET: api/Boks
        //hämta ut bok data
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bok>>> GetBok()
        {
            return await _context.Bok.ToListAsync();
        }

        // GET: api/Boks/5
        //hämta ut bok data med id
        [HttpGet("{id}")]
        public async Task<ActionResult<Bok>> GetBok(int id)
        {
            var bok = await _context.Bok.FindAsync(id);

            if (bok == null)
            {
                return NotFound();
            }

            return bok;
        }

        // PUT: api/Boks/5
        //Uppdatera bok id
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBok(int id, Bok bok)
        {
            if (id != bok.BokId)
            {
                return BadRequest();
            }

            _context.Entry(bok).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BokExists(id))
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

        // POST: api/Boks
        //Uppdatera bok
        [HttpPost]
        public async Task<ActionResult<Bok>> PostBok(Bok bok)
        {
            _context.Bok.Add(bok);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBok", new { id = bok.BokId }, bok);
        }

        // DELETE: api/Boks/5
        //radera bok id
        [HttpDelete("{id}")]
        public async Task<ActionResult<Bok>> DeleteBok(int id)
        {
            var bok = await _context.Bok.FindAsync(id);
            if (bok == null)
            {
                return NotFound();
            }

            _context.Bok.Remove(bok);
            await _context.SaveChangesAsync();

            return bok;
        }

        private bool BokExists(int id)
        {
            return _context.Bok.Any(e => e.BokId == id);
        }
    }
}
