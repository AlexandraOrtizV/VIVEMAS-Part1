using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VIVEMAS.Models;

namespace VIVEMAS.Controllers
{
    public class PlatillosController : Controller
    {
        private readonly ContextoBaseDatos _context;

        public PlatillosController(ContextoBaseDatos context)
        {
            _context = context;
        }

        // GET: Platillos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Platillo.ToListAsync());
        }

        // GET: Platillos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var platillo = await _context.Platillo
                .FirstOrDefaultAsync(m => m.Platillo_id == id);
            if (platillo == null)
            {
                return NotFound();
            }

            return View(platillo);
        }

        // GET: Platillos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Platillos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Platillo_id,Nombre,Ingredientes,Procedimiento,Tiempo,Porciones,Calorias")] Platillo platillo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(platillo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(platillo);
        }

        // GET: Platillos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var platillo = await _context.Platillo.FindAsync(id);
            if (platillo == null)
            {
                return NotFound();
            }
            return View(platillo);
        }

        // POST: Platillos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Platillo_id,Nombre,Ingredientes,Procedimiento,Tiempo,Porciones,Calorias")] Platillo platillo)
        {
            if (id != platillo.Platillo_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(platillo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlatilloExists(platillo.Platillo_id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(platillo);
        }

        // GET: Platillos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var platillo = await _context.Platillo
                .FirstOrDefaultAsync(m => m.Platillo_id == id);
            if (platillo == null)
            {
                return NotFound();
            }

            return View(platillo);
        }

        // POST: Platillos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var platillo = await _context.Platillo.FindAsync(id);
            _context.Platillo.Remove(platillo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlatilloExists(int id)
        {
            return _context.Platillo.Any(e => e.Platillo_id == id);
        }
    }
}
