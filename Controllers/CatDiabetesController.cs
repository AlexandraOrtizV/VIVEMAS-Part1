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
    public class CatDiabetesController : Controller
    {
        private readonly ContextoBaseDatos _context;

        public CatDiabetesController(ContextoBaseDatos context)
        {
            _context = context;
        }

        // GET: CatDiabetes
        public async Task<IActionResult> Index()
        {
            return View(await _context.CatDiabetes.ToListAsync());
        }

        // GET: CatDiabetes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catDiabetes = await _context.CatDiabetes
                .FirstOrDefaultAsync(m => m.Diabetes_id == id);
            if (catDiabetes == null)
            {
                return NotFound();
            }

            return View(catDiabetes);
        }

        // GET: CatDiabetes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatDiabetes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Diabetes_id,Descripcion")] CatDiabetes catDiabetes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catDiabetes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catDiabetes);
        }

        // GET: CatDiabetes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catDiabetes = await _context.CatDiabetes.FindAsync(id);
            if (catDiabetes == null)
            {
                return NotFound();
            }
            return View(catDiabetes);
        }

        // POST: CatDiabetes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Diabetes_id,Descripcion")] CatDiabetes catDiabetes)
        {
            if (id != catDiabetes.Diabetes_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catDiabetes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatDiabetesExists(catDiabetes.Diabetes_id))
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
            return View(catDiabetes);
        }

        // GET: CatDiabetes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catDiabetes = await _context.CatDiabetes
                .FirstOrDefaultAsync(m => m.Diabetes_id == id);
            if (catDiabetes == null)
            {
                return NotFound();
            }

            return View(catDiabetes);
        }

        // POST: CatDiabetes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catDiabetes = await _context.CatDiabetes.FindAsync(id);
            _context.CatDiabetes.Remove(catDiabetes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatDiabetesExists(int id)
        {
            return _context.CatDiabetes.Any(e => e.Diabetes_id == id);
        }
    }
}
