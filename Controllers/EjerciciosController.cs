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
    public class EjerciciosController : Controller
    {
        private readonly ContextoBaseDatos _context;

        public EjerciciosController(ContextoBaseDatos context)
        {
            _context = context;
        }

        // GET: Ejercicios
        public async Task<IActionResult> Index()
        {
            var contextoBaseDatos = _context.Ejercicio.Include(e => e.CatDificultad).Include(e => e.TipoEjercicio);
            return View(await contextoBaseDatos.ToListAsync());
        }

        // GET: Ejercicios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ejercicio = await _context.Ejercicio
                .Include(e => e.CatDificultad)
                .Include(e => e.TipoEjercicio)
                .FirstOrDefaultAsync(m => m.Ejercicio_id == id);
            if (ejercicio == null)
            {
                return NotFound();
            }

            return View(ejercicio);
        }

        // GET: Ejercicios/Create
        public IActionResult Create()
        {
            ViewData["Dificultad_id"] = new SelectList(_context.CatDificultad, "Dificultad_id", "Dificultad_id");
            ViewData["Tipo_id"] = new SelectList(_context.TipoEjercicio, "Tipo_id", "Tipo_id");
            return View();
        }

        // POST: Ejercicios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Ejercicio_id,Nombre,Descripcion,Tiempo,Equipo,Tipo_id,Dificultad_id")] Ejercicio ejercicio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ejercicio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Dificultad_id"] = new SelectList(_context.CatDificultad, "Dificultad_id", "Dificultad_id", ejercicio.Dificultad_id);
            ViewData["Tipo_id"] = new SelectList(_context.TipoEjercicio, "Tipo_id", "Tipo_id", ejercicio.Tipo_id);
            return View(ejercicio);
        }

        // GET: Ejercicios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ejercicio = await _context.Ejercicio.FindAsync(id);
            if (ejercicio == null)
            {
                return NotFound();
            }
            ViewData["Dificultad_id"] = new SelectList(_context.CatDificultad, "Dificultad_id", "Dificultad_id", ejercicio.Dificultad_id);
            ViewData["Tipo_id"] = new SelectList(_context.TipoEjercicio, "Tipo_id", "Tipo_id", ejercicio.Tipo_id);
            return View(ejercicio);
        }

        // POST: Ejercicios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Ejercicio_id,Nombre,Descripcion,Tiempo,Equipo,Tipo_id,Dificultad_id")] Ejercicio ejercicio)
        {
            if (id != ejercicio.Ejercicio_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ejercicio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EjercicioExists(ejercicio.Ejercicio_id))
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
            ViewData["Dificultad_id"] = new SelectList(_context.CatDificultad, "Dificultad_id", "Dificultad_id", ejercicio.Dificultad_id);
            ViewData["Tipo_id"] = new SelectList(_context.TipoEjercicio, "Tipo_id", "Tipo_id", ejercicio.Tipo_id);
            return View(ejercicio);
        }

        // GET: Ejercicios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ejercicio = await _context.Ejercicio
                .Include(e => e.CatDificultad)
                .Include(e => e.TipoEjercicio)
                .FirstOrDefaultAsync(m => m.Ejercicio_id == id);
            if (ejercicio == null)
            {
                return NotFound();
            }

            return View(ejercicio);
        }

        // POST: Ejercicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ejercicio = await _context.Ejercicio.FindAsync(id);
            _context.Ejercicio.Remove(ejercicio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EjercicioExists(int id)
        {
            return _context.Ejercicio.Any(e => e.Ejercicio_id == id);
        }
    }
}
