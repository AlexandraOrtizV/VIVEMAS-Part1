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
    public class AccesoAdministradoresController : Controller
    {
        private readonly ContextoBaseDatos _context;

        public AccesoAdministradoresController(ContextoBaseDatos context)
        {
            _context = context;
        }

        // GET: AccesoAdministradores
        public async Task<IActionResult> Index()
        {
            return View(await _context.AccesoAdministrador.ToListAsync());
        }

        // GET: AccesoAdministradores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accesoAdministrador = await _context.AccesoAdministrador
                .FirstOrDefaultAsync(m => m.Administrador_id == id);
            if (accesoAdministrador == null)
            {
                return NotFound();
            }

            return View(accesoAdministrador);
        }

        // GET: AccesoAdministradores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AccesoAdministradores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Administrador_id,Correo,Contraseña")] AccesoAdministrador accesoAdministrador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accesoAdministrador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(accesoAdministrador);
        }

        // GET: AccesoAdministradores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accesoAdministrador = await _context.AccesoAdministrador.FindAsync(id);
            if (accesoAdministrador == null)
            {
                return NotFound();
            }
            return View(accesoAdministrador);
        }

        // POST: AccesoAdministradores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Administrador_id,Correo,Contraseña")] AccesoAdministrador accesoAdministrador)
        {
            if (id != accesoAdministrador.Administrador_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accesoAdministrador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccesoAdministradorExists(accesoAdministrador.Administrador_id))
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
            return View(accesoAdministrador);
        }

        // GET: AccesoAdministradores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accesoAdministrador = await _context.AccesoAdministrador
                .FirstOrDefaultAsync(m => m.Administrador_id == id);
            if (accesoAdministrador == null)
            {
                return NotFound();
            }

            return View(accesoAdministrador);
        }

        // POST: AccesoAdministradores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var accesoAdministrador = await _context.AccesoAdministrador.FindAsync(id);
            _context.AccesoAdministrador.Remove(accesoAdministrador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccesoAdministradorExists(int id)
        {
            return _context.AccesoAdministrador.Any(e => e.Administrador_id == id);
        }
    }
}
