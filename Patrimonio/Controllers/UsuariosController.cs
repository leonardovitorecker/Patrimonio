using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Patrimonio.Models;

namespace Patrimonio.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly DBContext _context;

        public UsuariosController(DBContext context)
        {
            _context = context;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
              return _context.usuario != null ? 
                          View(await _context.usuario.ToListAsync()) :
                          Problem("Entity set 'DBContext.usuario'  is null.");
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.usuario == null)
            {
                return NotFound();
            }

            var dbUsuario = await _context.usuario
                .FirstOrDefaultAsync(m => m.id == id);
            if (dbUsuario == null)
            {
                return NotFound();
            }

            return View(dbUsuario);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,nome,login,senha")] DbUsuario dbUsuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dbUsuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dbUsuario);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.usuario == null)
            {
                return NotFound();
            }

            var dbUsuario = await _context.usuario.FindAsync(id);
            if (dbUsuario == null)
            {
                return NotFound();
            }
            return View(dbUsuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nome,login,senha")] DbUsuario dbUsuario)
        {
            if (id != dbUsuario.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dbUsuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DbUsuarioExists(dbUsuario.id))
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
            return View(dbUsuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.usuario == null)
            {
                return NotFound();
            }

            var dbUsuario = await _context.usuario
                .FirstOrDefaultAsync(m => m.id == id);
            if (dbUsuario == null)
            {
                return NotFound();
            }

            return View(dbUsuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.usuario == null)
            {
                return Problem("Entity set 'DBContext.usuario'  is null.");
            }
            var dbUsuario = await _context.usuario.FindAsync(id);
            if (dbUsuario != null)
            {
                _context.usuario.Remove(dbUsuario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DbUsuarioExists(int id)
        {
          return (_context.usuario?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
