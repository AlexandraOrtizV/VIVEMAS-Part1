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
    public class TipoEjerciciosController : Controller
    {
        private readonly ContextoBaseDatos _context;

        public TipoEjerciciosController(ContextoBaseDatos context)
        {
            _context = context;
        }

        // GET: TipoEjercicios
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoEjercicio.ToListAsync());
        }

        // GET: TipoEjercicios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoEjercicio = await _context.TipoEjercicio
                .FirstOrDefaultAsync(m => m.Tipo_id == id);
            if (tipoEjercicio == null)
            {
                return NotFound();
            }

            return View(tipoEjercicio);
        }

        // GET: TipoEjercicios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoEjercicios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Tipo_id,Descripcion")] TipoEjercicio tipoEjercicio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoEjercicio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoEjercicio);
        }

        // GET: TipoEjercicios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoEjercicio = await _context.TipoEjercicio.FindAsync(id);
            if (tipoEjercicio == null)
            {
                return NotFound();
            }
            return View(tipoEjercicio);
        }

        // POST: TipoEjercicios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Tipo_id,Descripcion")] TipoEjercicio tipoEjercicio)
        {
            if (id != tipoEjercicio.Tipo_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoEjercicio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoEjercicioExists(tipoEjercicio.Tipo_id))
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
            return View(tipoEjercicio);
        }

        // GET: TipoEjercicios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoEjercicio = await _context.TipoEjercicio
                .FirstOrDefaultAsync(m => m.Tipo_id == id);
            if (tipoEjercicio == null)
            {
                return NotFound();
            }

            return View(tipoEjercicio);
        }

        // POST: TipoEjercicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoEjercicio = await _context.TipoEjercicio.FindAsync(id);
            _context.TipoEjercicio.Remove(tipoEjercicio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoEjercicioExists(int id)
        {
            return _context.TipoEjercicio.Any(e => e.Tipo_id == id);
        }
    }
}
