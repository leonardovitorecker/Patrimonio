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
    public class CategoriasController : Controller
    {
        private readonly DBContext _context;

        public CategoriasController(DBContext context)
        {
            _context = context;
        }

        // GET: Categorias
        public async Task<IActionResult> Index()
        {
              return _context.categorias != null ? 
                          View(await _context.categorias.ToListAsync()) :
                          Problem("Entity set 'DBContext.categoria'  is null.");
        }

        // GET: Categorias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.categorias == null)
            {
                return NotFound();
            }

            var dbCategoria = await _context.categorias
                .FirstOrDefaultAsync(m => m.id == id);
            if (dbCategoria == null)
            {
                return NotFound();
            }

            return View(dbCategoria);
        }

        // GET: Categorias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categorias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,descricaocategoria")] DbCategoria dbCategoria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dbCategoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dbCategoria);
        }

        // GET: Categorias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.categorias == null)
            {
                return NotFound();
            }

            var dbCategoria = await _context.categorias.FindAsync(id);
            if (dbCategoria == null)
            {
                return NotFound();
            }
            return View(dbCategoria);
        }

        // POST: Categorias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,descricaocategoria")] DbCategoria dbCategoria)
        {
            if (id != dbCategoria.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dbCategoria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DbCategoriaExists(dbCategoria.id))
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
            return View(dbCategoria);
        }

        // GET: Categorias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.categorias == null)
            {
                return NotFound();
            }

            var dbCategoria = await _context.categorias
                .FirstOrDefaultAsync(m => m.id == id);
            if (dbCategoria == null)
            {
                return NotFound();
            }

            return View(dbCategoria);
        }

        // POST: Categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.categorias == null)
            {
                return Problem("Entity set 'DBContext.categoria'  is null.");
            }
            var dbCategoria = await _context.categorias.FindAsync(id);
            if (dbCategoria != null)
            {
                _context.categorias.Remove(dbCategoria);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DbCategoriaExists(int id)
        {
          return (_context.categorias?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
