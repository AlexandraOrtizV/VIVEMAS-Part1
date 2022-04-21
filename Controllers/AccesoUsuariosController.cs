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
    public class AccesoUsuariosController : Controller
    {
        private readonly ContextoBaseDatos _context;

        public AccesoUsuariosController(ContextoBaseDatos context)
        {
            _context = context;
        }

        // GET: AccesoUsuarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.AccesoUsuario.ToListAsync());
        }

        // GET: AccesoUsuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accesoUsuario = await _context.AccesoUsuario
                .FirstOrDefaultAsync(m => m.Usuario_id == id);
            if (accesoUsuario == null)
            {
                return NotFound();
            }

            return View(accesoUsuario);
        }

        // GET: AccesoUsuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AccesoUsuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Usuario_id,Correo,Contraseña")] AccesoUsuario accesoUsuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accesoUsuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(accesoUsuario);
        }

        // GET: AccesoUsuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accesoUsuario = await _context.AccesoUsuario.FindAsync(id);
            if (accesoUsuario == null)
            {
                return NotFound();
            }
            return View(accesoUsuario);
        }

        // POST: AccesoUsuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Usuario_id,Correo,Contraseña")] AccesoUsuario accesoUsuario)
        {
            if (id != accesoUsuario.Usuario_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accesoUsuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccesoUsuarioExists(accesoUsuario.Usuario_id))
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
            return View(accesoUsuario);
        }

        // GET: AccesoUsuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accesoUsuario = await _context.AccesoUsuario
                .FirstOrDefaultAsync(m => m.Usuario_id == id);
            if (accesoUsuario == null)
            {
                return NotFound();
            }

            return View(accesoUsuario);
        }

        // POST: AccesoUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var accesoUsuario = await _context.AccesoUsuario.FindAsync(id);
            _context.AccesoUsuario.Remove(accesoUsuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccesoUsuarioExists(int id)
        {
            return _context.AccesoUsuario.Any(e => e.Usuario_id == id);
        }
    }
}
