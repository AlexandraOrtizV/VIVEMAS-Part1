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
    public class AdministradoresController : Controller
    {
        private readonly ContextoBaseDatos _context;

        public AdministradoresController(ContextoBaseDatos context)
        {
            _context = context;
        }

        // GET: Administradores
        public async Task<IActionResult> Index()
        {
            var contextoBaseDatos = _context.Administrador.Include(a => a.AccesoAdministrador).Include(a => a.CatEstado);
            return View(await contextoBaseDatos.ToListAsync());
        }

        // GET: Administradores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrador = await _context.Administrador
                .Include(a => a.AccesoAdministrador)
                .Include(a => a.CatEstado)
                .FirstOrDefaultAsync(m => m.Admin_id == id);
            if (administrador == null)
            {
                return NotFound();
            }

            return View(administrador);
        }

        // GET: Administradores/Create
        public IActionResult Create()
        {
            ViewData["Admin_id"] = new SelectList(_context.AccesoAdministrador, "Administrador_id", "Contraseña");
            ViewData["Estado_id"] = new SelectList(_context.Set<CatEstado>(), "Estado_id", "Estado_id");
            return View();
        }

        // POST: Administradores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Admin_id,Nombre,ApPat,ApMat,Puesto,Celular,Estado_id")] Administrador administrador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(administrador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Admin_id"] = new SelectList(_context.AccesoAdministrador, "Administrador_id", "Contraseña", administrador.Admin_id);
            ViewData["Estado_id"] = new SelectList(_context.Set<CatEstado>(), "Estado_id", "Estado_id", administrador.Estado_id);
            return View(administrador);
        }

        // GET: Administradores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrador = await _context.Administrador.FindAsync(id);
            if (administrador == null)
            {
                return NotFound();
            }
            ViewData["Admin_id"] = new SelectList(_context.AccesoAdministrador, "Administrador_id", "Contraseña", administrador.Admin_id);
            ViewData["Estado_id"] = new SelectList(_context.Set<CatEstado>(), "Estado_id", "Estado_id", administrador.Estado_id);
            return View(administrador);
        }

        // POST: Administradores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Admin_id,Nombre,ApPat,ApMat,Puesto,Celular,Estado_id")] Administrador administrador)
        {
            if (id != administrador.Admin_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(administrador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdministradorExists(administrador.Admin_id))
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
            ViewData["Admin_id"] = new SelectList(_context.AccesoAdministrador, "Administrador_id", "Contraseña", administrador.Admin_id);
            ViewData["Estado_id"] = new SelectList(_context.Set<CatEstado>(), "Estado_id", "Estado_id", administrador.Estado_id);
            return View(administrador);
        }

        // GET: Administradores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrador = await _context.Administrador
                .Include(a => a.AccesoAdministrador)
                .Include(a => a.CatEstado)
                .FirstOrDefaultAsync(m => m.Admin_id == id);
            if (administrador == null)
            {
                return NotFound();
            }

            return View(administrador);
        }

        // POST: Administradores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var administrador = await _context.Administrador.FindAsync(id);
            _context.Administrador.Remove(administrador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdministradorExists(int id)
        {
            return _context.Administrador.Any(e => e.Admin_id == id);
        }
    }
}
