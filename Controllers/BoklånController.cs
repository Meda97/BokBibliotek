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
    public class BoklånController : ControllerBase
    {
        private readonly BokbibliotekContext _context;

        public BoklånController(BokbibliotekContext context)
        {
            _context = context;
        }

        // GET: api/Boklån
        //hämta ut boklån data
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Boklån>>> GetBoklån()
        {
            return await _context.Boklån.ToListAsync();
        }

        // GET: api/Boklån/5 
        //hämta ut boklån data med id
        [HttpGet("{id}")]
        public async Task<ActionResult<Boklån>> GetBoklån(int id)
        {
            var boklån = await _context.Boklån
            .Include(b => b.Bok)
            .Include(l => l.Låntagare)
            .FirstOrDefaultAsync(b => b.BoklånId == id);

            if (boklån == null)
            {
                return NotFound();
            }

            return boklån;
        }

        // PUT: api/Boklån/5
        //Uppdatera boklån
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBoklån(int id, Boklån boklån)
        {
            if (id != boklån.BoklånId)
            {
                return BadRequest();
            }

            _context.Entry(boklån).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoklånExists(id))
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

        //koden gör att man ser om boken är utlånad eller inte och lämnar tillbaka boken
        [HttpPut("return/{id}")]
        public async Task<IActionResult> ReturnRental(int id, Boklån boklån)
        {
            if (id != boklån.BoklånId)
            {
                return BadRequest();
            }

            boklån.Utlånad = false;

            boklån.Returdatum = DateTime.Now;

            _context.Entry(boklån).State = EntityState.Modified;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoklånExists(id))
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




        // POST: api/Boklån
        //skapa boklån
        [HttpPost]
        public async Task<ActionResult<Boklån>> PostBoklån(Boklån boklån)
        {
            boklån.Returdatum = null;
            boklån.Utlånad = true;
            _context.Boklån.Add(boklån);
            await _context.SaveChangesAsync();


            return CreatedAtAction("GetBoklån", new { id = boklån.BoklånId }, boklån);
        }

        // DELETE: api/Boklån/5
        //radera boklån id
        [HttpDelete("{id}")]
        public async Task<ActionResult<Boklån>> DeleteBoklån(int id)
        {
            var boklån = await _context.Boklån.FindAsync(id);
            if (boklån == null)
            {
                return NotFound();
            }

            _context.Boklån.Remove(boklån);
            await _context.SaveChangesAsync();

            return boklån;
        }

        private bool BoklånExists(int id)
        {
            return _context.Boklån.Any(e => e.BoklånId == id);
        }
    }
}
