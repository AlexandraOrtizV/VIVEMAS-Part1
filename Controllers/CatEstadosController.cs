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
    public class CatEstadosController : Controller
    {
        private readonly ContextoBaseDatos _context;

        public CatEstadosController(ContextoBaseDatos context)
        {
            _context = context;
        }

        // GET: CatEstados
        public async Task<IActionResult> Index()
        {
            return View(await _context.CatEstado.ToListAsync());
        }

        // GET: CatEstados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catEstado = await _context.CatEstado
                .FirstOrDefaultAsync(m => m.Estado_id == id);
            if (catEstado == null)
            {
                return NotFound();
            }

            return View(catEstado);
        }

        // GET: CatEstados/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatEstados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Estado_id,Descripcion,Activo")] CatEstado catEstado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catEstado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catEstado);
        }

        // GET: CatEstados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catEstado = await _context.CatEstado.FindAsync(id);
            if (catEstado == null)
            {
                return NotFound();
            }
            return View(catEstado);
        }

        // POST: CatEstados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Estado_id,Descripcion,Activo")] CatEstado catEstado)
        {
            if (id != catEstado.Estado_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catEstado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatEstadoExists(catEstado.Estado_id))
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
            return View(catEstado);
        }

        // GET: CatEstados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catEstado = await _context.CatEstado
                .FirstOrDefaultAsync(m => m.Estado_id == id);
            if (catEstado == null)
            {
                return NotFound();
            }

            return View(catEstado);
        }

        // POST: CatEstados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catEstado = await _context.CatEstado.FindAsync(id);
            _context.CatEstado.Remove(catEstado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatEstadoExists(int id)
        {
            return _context.CatEstado.Any(e => e.Estado_id == id);
        }
    }
}
