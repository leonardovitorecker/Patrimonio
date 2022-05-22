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
    public class FornecedorController : Controller
    {
        private readonly DBContext _context;

        public FornecedorController(DBContext context)
        {
            _context = context;
        }

        // GET: Fornecedors
        public async Task<IActionResult> Index()
        {
              return _context.fornecedor != null ? 
                          View(await _context.fornecedor.ToListAsync()) :
                          Problem("Entity set 'DBContext.fornecedor'  is null.");
        }

        // GET: Fornecedors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.fornecedor == null)
            {
                return NotFound();
            }

            var dbFornecedor = await _context.fornecedor
                .FirstOrDefaultAsync(m => m.id == id);
            if (dbFornecedor == null)
            {
                return NotFound();
            }

            return View(dbFornecedor);
        }

        // GET: Fornecedors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fornecedors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nomefornecedor,endereco,fone")] DbFornecedor dbFornecedor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dbFornecedor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dbFornecedor);
        }

        // GET: Fornecedors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.fornecedor == null)
            {
                return NotFound();
            }

            var dbFornecedor = await _context.fornecedor.FindAsync(id);
            if (dbFornecedor == null)
            {
                return NotFound();
            }
            return View(dbFornecedor);
        }

        // POST: Fornecedors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nomefornecedor,endereco,fone")] DbFornecedor dbFornecedor)
        {
            if (id != dbFornecedor.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dbFornecedor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DbFornecedorExists(dbFornecedor.id))
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
            return View(dbFornecedor);
        }

        // GET: Fornecedors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.fornecedor == null)
            {
                return NotFound();
            }

            var dbFornecedor = await _context.fornecedor
                .FirstOrDefaultAsync(m => m.id == id);
            if (dbFornecedor == null)
            {
                return NotFound();
            }

            return View(dbFornecedor);
        }

        // POST: Fornecedors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.fornecedor == null)
            {
                return Problem("Entity set 'DBContext.fornecedor'  is null.");
            }
            var dbFornecedor = await _context.fornecedor.FindAsync(id);
            if (dbFornecedor != null)
            {
                _context.fornecedor.Remove(dbFornecedor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DbFornecedorExists(int id)
        {
          return (_context.fornecedor?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
