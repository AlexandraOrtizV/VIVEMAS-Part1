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
    public class CatDificultadesController : Controller
    {
        private readonly ContextoBaseDatos _context;

        public CatDificultadesController(ContextoBaseDatos context)
        {
            _context = context;
        }

        // GET: CatDificultades
        public async Task<IActionResult> Index()
        {
            return View(await _context.CatDificultad.ToListAsync());
        }

        // GET: CatDificultades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catDificultad = await _context.CatDificultad
                .FirstOrDefaultAsync(m => m.Dificultad_id == id);
            if (catDificultad == null)
            {
                return NotFound();
            }

            return View(catDificultad);
        }

        // GET: CatDificultades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatDificultades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Dificultad_id,Descripcion")] CatDificultad catDificultad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catDificultad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catDificultad);
        }

        // GET: CatDificultades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catDificultad = await _context.CatDificultad.FindAsync(id);
            if (catDificultad == null)
            {
                return NotFound();
            }
            return View(catDificultad);
        }

        // POST: CatDificultades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Dificultad_id,Descripcion")] CatDificultad catDificultad)
        {
            if (id != catDificultad.Dificultad_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catDificultad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatDificultadExists(catDificultad.Dificultad_id))
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
            return View(catDificultad);
        }

        // GET: CatDificultades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catDificultad = await _context.CatDificultad
                .FirstOrDefaultAsync(m => m.Dificultad_id == id);
            if (catDificultad == null)
            {
                return NotFound();
            }

            return View(catDificultad);
        }

        // POST: CatDificultades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catDificultad = await _context.CatDificultad.FindAsync(id);
            _context.CatDificultad.Remove(catDificultad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatDificultadExists(int id)
        {
            return _context.CatDificultad.Any(e => e.Dificultad_id == id);
        }
    }
}
