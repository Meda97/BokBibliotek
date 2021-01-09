using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BokBibliotek.Data;
using BokBibliotek.Models;

namespace BokBibliotek.Controllers
{
    public class FörsenadeBoklånController : Controller
    {
        private readonly BokbibliotekContext _context;

        public FörsenadeBoklånController(BokbibliotekContext context)
        {
            _context = context;
        }

        // GET: FörsenadeBoklån
        public async Task<IActionResult> Index()
        {
            var bokbibliotekContext = _context.Boklån.Where(b => b.Returdatum < DateTime.Now).Include(b => b.Bok).Include(b => b.Låntagare);
            return View(await bokbibliotekContext.ToListAsync());
        }
    }
}