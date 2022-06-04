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
    public class PatrimoniosController : Controller
    {
        private readonly DBContext _context;

        public PatrimoniosController(DBContext context)
        {
            _context = context;
        }

        // GET: Patrimonios
        public async Task<IActionResult> Index()
        {
            List<DtoPatrimonio> dtoPatrimonio = (from p in _context.patrimonio
                                                 join l in _context.local on p.idlocal equals l.id
                                                 join c in _context.categorias on p.idcategoria equals c.id
                                                 join f in _context.fornecedor on p.idfornecedor equals f.id
                                                 select new DtoPatrimonio
                                                      {
                                                          id = p.id,
                                                          nomepatrimonio = p.nomepatrimonio,
                                                          nomecategoria = c.descricaocategoria,
                                                          nomelocal = l.nomelocal,
                                                          nomefornecedor = f.nomefornecedor
                                                      }).ToList();
            return View(dtoPatrimonio);
        }

        // GET: Patrimonios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.patrimonio == null)
            {
                return NotFound();
            }

            var dbPatrimonio = (from p in _context.patrimonio
                                join l in _context.local on p.idlocal equals l.id
                                join c in _context.categorias on p.idcategoria equals c.id
                                join f in _context.fornecedor on p.idfornecedor equals f.id
                                select new DtoPatrimonio
                                {
                                    id = p.id,
                                    nomepatrimonio = p.nomepatrimonio,
                                    nomecategoria = c.descricaocategoria,
                                    nomelocal = l.nomelocal,
                                    nomefornecedor=f.nomefornecedor
                                }).FirstOrDefault();
            if (dbPatrimonio == null)
            {
                return NotFound();
            }

            return View(dbPatrimonio);
        }

        // GET: Patrimonios/Create
        public IActionResult Create()
        {
            ViewBag.local = new SelectList(_context.local, "id", "nomelocal");
            ViewBag.fornecedor = new SelectList(_context.fornecedor, "id", "nomefornecedor");
            ViewBag.categoria = new SelectList(_context.categorias, "id", "descricaocategoria");
            return View();
        }

        // POST: Patrimonios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,numeetiqueta,nomepatrimonio,descricaopatrimonio,valorpatrimonio,idcategoria,idlocal,marcamodelo,dataqquisicao,databaixa,numf,numserie,situacao,idfornecedor,datagarantia")] DbPatrimonio dbPatrimonio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dbPatrimonio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dbPatrimonio);
        }

        // GET: Patrimonios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.patrimonio == null)
            {
                return NotFound();
            }

            var dbPatrimonio = (from p in _context.patrimonio
                                join l in _context.local on p.idlocal equals l.id
                                join c in _context.categorias on p.idcategoria equals c.id
                                join f in _context.fornecedor on p.idfornecedor equals f.id
                                select new DtoPatrimonio
                                {
                                    id = p.id,
                                    nomepatrimonio = p.nomepatrimonio,
                                    nomecategoria = c.descricaocategoria,
                                    nomelocal = l.nomelocal,
                                    nomefornecedor = f.nomefornecedor
                                }).FirstOrDefault();
            if (dbPatrimonio == null)
            {
                return NotFound();
            }
            return View(dbPatrimonio);
        }

        // POST: Patrimonios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,numeetiqueta,nomepatrimonio,descricaopatrimonio,valorpatrimonio,idcategoria,idlocal,marcamodelo,dataqquisicao,databaixa,numf,numserie,situacao,idfornecedor,datagarantia")] DbPatrimonio dbPatrimonio)
        {
            if (id != dbPatrimonio.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dbPatrimonio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DbPatrimonioExists(dbPatrimonio.id))
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
            return View(dbPatrimonio);
        }

        // GET: Patrimonios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.patrimonio == null)
            {
                return NotFound();
            }

            var dbPatrimonio = (from p in _context.patrimonio
                                join l in _context.local on p.idlocal equals l.id
                                join c in _context.categorias on p.idcategoria equals c.id
                                join f in _context.fornecedor on p.idfornecedor equals f.id
                                select new DtoPatrimonio
                                {
                                    id = p.id,
                                    nomepatrimonio = p.nomepatrimonio,
                                    nomecategoria = c.descricaocategoria,
                                    nomelocal = l.nomelocal,
                                    nomefornecedor = f.nomefornecedor
                                }).FirstOrDefault();
            if (dbPatrimonio == null)
            {
                return NotFound();
            }

            return View(dbPatrimonio);
        }

        // POST: Patrimonios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.patrimonio == null)
            {
                return Problem("Entity set 'DBContext.patrimonio'  is null.");
            }
            var dbPatrimonio = await _context.patrimonio.FindAsync(id);
            if (dbPatrimonio != null)
            {
                _context.patrimonio.Remove(dbPatrimonio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DbPatrimonioExists(int id)
        {
          return (_context.patrimonio?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
