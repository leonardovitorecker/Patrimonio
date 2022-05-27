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
    public class DepartamentosController : Controller
    {
        private readonly DBContext _context;

        public DepartamentosController(DBContext context)
        {
            _context = context;
        }

        // GET: Departamentoes
        public async Task<IActionResult> Index()
        {
          
              return _context.departamento != null ? 
                          View(await _context.departamento.ToListAsync()) :
                          Problem("Entity set 'DBContext.departamento'  is null.");
        }

        // GET: Departamentoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.departamento == null)
            {
                return NotFound();
            }

            var dbDepartamento = await _context.departamento
                .FirstOrDefaultAsync(m => m.id == id);
            if (dbDepartamento == null)
            {
                return NotFound();
            }

            return View(dbDepartamento);
        }

        // GET: Departamentoes/Create
        public IActionResult Create()
        {
            ViewBag.local = (from c in _context.local
                             select new {
                             text = c.nomelocal,
                             value = c.id}).Distinct();

            ViewBag.local2 = new SelectList(_context.local, "id", "nomelocal");
            return View();
        }

        // POST: Departamentoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nomedepartamento,descricaodepartamento,idlocal")] DbDepartamento dbDepartamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dbDepartamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dbDepartamento);
        }

        // GET: Departamentoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.departamento == null)
            {
                return NotFound();
            }

            var dbDepartamento = await _context.departamento.FindAsync(id);
            if (dbDepartamento == null)
            {
                return NotFound();
            }
            return View(dbDepartamento);
        }

        // POST: Departamentoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nomedepartamento,descricaodepartamento,idlocal")] DbDepartamento dbDepartamento)
        {
            if (id != dbDepartamento.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dbDepartamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DbDepartamentoExists(dbDepartamento.id))
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
            return View(dbDepartamento);
        }

        // GET: Departamentoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.departamento == null)
            {
                return NotFound();
            }

            var dbDepartamento = await _context.departamento
                .FirstOrDefaultAsync(m => m.id == id);
            if (dbDepartamento == null)
            {
                return NotFound();
            }

            return View(dbDepartamento);
        }

        // POST: Departamentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.departamento == null)
            {
                return Problem("Entity set 'DBContext.departamento'  is null.");
            }
            var dbDepartamento = await _context.departamento.FindAsync(id);
            if (dbDepartamento != null)
            {
                _context.departamento.Remove(dbDepartamento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DbDepartamentoExists(int id)
        {
          return (_context.departamento?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
