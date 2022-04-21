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
    public class UsuariosController : Controller
    {
        private readonly ContextoBaseDatos _context;

        public UsuariosController(ContextoBaseDatos context)
        {
            _context = context;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            var contextoBaseDatos = _context.Usuario.Include(u => u.AccesoUsuario).Include(u => u.CatDiabetes).Include(u => u.CatEstado).Include(u => u.Rutina);
            return View(await contextoBaseDatos.ToListAsync());
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .Include(u => u.AccesoUsuario)
                .Include(u => u.CatDiabetes)
                .Include(u => u.CatEstado)
                .Include(u => u.Rutina)
                .FirstOrDefaultAsync(m => m.Usuario_id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            ViewData["Usuario_id"] = new SelectList(_context.AccesoUsuario, "Usuario_id", "Contraseña");
            ViewData["Diabetes_id"] = new SelectList(_context.CatDiabetes, "Diabetes_id", "Diabetes_id");
            ViewData["Estado_id"] = new SelectList(_context.CatEstado, "Estado_id", "Estado_id");
            ViewData["Rutina_id"] = new SelectList(_context.Rutina, "Rutina_id", "Rutina_id");
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Usuario_id,Nombre,ApPat,ApMat,Edad,Celular,Estado_id,Diabetes_id,Rutina_id")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Usuario_id"] = new SelectList(_context.AccesoUsuario, "Usuario_id", "Contraseña", usuario.Usuario_id);
            ViewData["Diabetes_id"] = new SelectList(_context.CatDiabetes, "Diabetes_id", "Diabetes_id", usuario.Diabetes_id);
            ViewData["Estado_id"] = new SelectList(_context.CatEstado, "Estado_id", "Estado_id", usuario.Estado_id);
            ViewData["Rutina_id"] = new SelectList(_context.Rutina, "Rutina_id", "Rutina_id", usuario.Rutina_id);
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            ViewData["Usuario_id"] = new SelectList(_context.AccesoUsuario, "Usuario_id", "Contraseña", usuario.Usuario_id);
            ViewData["Diabetes_id"] = new SelectList(_context.CatDiabetes, "Diabetes_id", "Diabetes_id", usuario.Diabetes_id);
            ViewData["Estado_id"] = new SelectList(_context.CatEstado, "Estado_id", "Estado_id", usuario.Estado_id);
            ViewData["Rutina_id"] = new SelectList(_context.Rutina, "Rutina_id", "Rutina_id", usuario.Rutina_id);
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Usuario_id,Nombre,ApPat,ApMat,Edad,Celular,Estado_id,Diabetes_id,Rutina_id")] Usuario usuario)
        {
            if (id != usuario.Usuario_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.Usuario_id))
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
            ViewData["Usuario_id"] = new SelectList(_context.AccesoUsuario, "Usuario_id", "Contraseña", usuario.Usuario_id);
            ViewData["Diabetes_id"] = new SelectList(_context.CatDiabetes, "Diabetes_id", "Diabetes_id", usuario.Diabetes_id);
            ViewData["Estado_id"] = new SelectList(_context.CatEstado, "Estado_id", "Estado_id", usuario.Estado_id);
            ViewData["Rutina_id"] = new SelectList(_context.Rutina, "Rutina_id", "Rutina_id", usuario.Rutina_id);
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .Include(u => u.AccesoUsuario)
                .Include(u => u.CatDiabetes)
                .Include(u => u.CatEstado)
                .Include(u => u.Rutina)
                .FirstOrDefaultAsync(m => m.Usuario_id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuario.Any(e => e.Usuario_id == id);
        }
    }
}
