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
    public class RutinasController : Controller
    {
        private readonly ContextoBaseDatos _context;

        public RutinasController(ContextoBaseDatos context)
        {
            _context = context;
        }

        // GET: Rutinas
        public async Task<IActionResult> Index()
        {
            var contextoBaseDatos = _context.Rutina.Include(r => r.Ejercicio).Include(r => r.Platillo);
            return View(await contextoBaseDatos.ToListAsync());
        }

        // GET: Rutinas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rutina = await _context.Rutina
                .Include(r => r.Ejercicio)
                .Include(r => r.Platillo)
                .FirstOrDefaultAsync(m => m.Rutina_id == id);
            if (rutina == null)
            {
                return NotFound();
            }

            return View(rutina);
        }

        // GET: Rutinas/Create
        public IActionResult Create()
        {
            ViewData["Ejercicio_id"] = new SelectList(_context.Ejercicio, "Ejercicio_id", "Nombre");
            ViewData["Platillo_id"] = new SelectList(_context.Platillo, "Platillo_id", "Platillo_id");
            return View();
        }

        // POST: Rutinas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Rutina_id,Platillo_id,Ejercicio_id")] Rutina rutina)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rutina);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Ejercicio_id"] = new SelectList(_context.Ejercicio, "Ejercicio_id", "Nombre", rutina.Ejercicio_id);
            ViewData["Platillo_id"] = new SelectList(_context.Platillo, "Platillo_id", "Platillo_id", rutina.Platillo_id);
            return View(rutina);
        }

        // GET: Rutinas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rutina = await _context.Rutina.FindAsync(id);
            if (rutina == null)
            {
                return NotFound();
            }
            ViewData["Ejercicio_id"] = new SelectList(_context.Ejercicio, "Ejercicio_id", "Nombre", rutina.Ejercicio_id);
            ViewData["Platillo_id"] = new SelectList(_context.Platillo, "Platillo_id", "Platillo_id", rutina.Platillo_id);
            return View(rutina);
        }

        // POST: Rutinas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Rutina_id,Platillo_id,Ejercicio_id")] Rutina rutina)
        {
            if (id != rutina.Rutina_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rutina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RutinaExists(rutina.Rutina_id))
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
            ViewData["Ejercicio_id"] = new SelectList(_context.Ejercicio, "Ejercicio_id", "Nombre", rutina.Ejercicio_id);
            ViewData["Platillo_id"] = new SelectList(_context.Platillo, "Platillo_id", "Platillo_id", rutina.Platillo_id);
            return View(rutina);
        }

        // GET: Rutinas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rutina = await _context.Rutina
                .Include(r => r.Ejercicio)
                .Include(r => r.Platillo)
                .FirstOrDefaultAsync(m => m.Rutina_id == id);
            if (rutina == null)
            {
                return NotFound();
            }

            return View(rutina);
        }

        // POST: Rutinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rutina = await _context.Rutina.FindAsync(id);
            _context.Rutina.Remove(rutina);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RutinaExists(int id)
        {
            return _context.Rutina.Any(e => e.Rutina_id == id);
        }
    }
}
