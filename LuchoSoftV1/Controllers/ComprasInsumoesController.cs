using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LuchoSoftV1.Models;

namespace LuchoSoftV1.Controllers
{
    public class ComprasInsumoesController : Controller
    {
        private readonly LuchoSoftContext _context;

        public ComprasInsumoesController(LuchoSoftContext context)
        {
            _context = context;
        }

        // GET: ComprasInsumoes
        public async Task<IActionResult> Index()
        {
            var luchoSoftContext = _context.ComprasInsumos.Include(c => c.IdCompraNavigation).Include(c => c.IdInsumoNavigation);
            return View(await luchoSoftContext.ToListAsync());
        }

        // GET: ComprasInsumoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ComprasInsumos == null)
            {
                return NotFound();
            }

            var comprasInsumo = await _context.ComprasInsumos
                .Include(c => c.IdCompraNavigation)
                .Include(c => c.IdInsumoNavigation)
                .FirstOrDefaultAsync(m => m.IdComprasInsumos == id);
            if (comprasInsumo == null)
            {
                return NotFound();
            }

            return View(comprasInsumo);
        }

        // GET: ComprasInsumoes/Create
        public IActionResult Create()
        {
            ViewData["IdCompra"] = new SelectList(_context.Compras, "IdCompra", "IdCompra");
            ViewData["IdInsumo"] = new SelectList(_context.Insumos, "IdInsumo", "IdInsumo");
            return View();
        }

        // POST: ComprasInsumoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdComprasInsumos,CantidadInsumoComprasInsumos,PrecioInsumoComprasInsumos,IdCompra,IdInsumo")] ComprasInsumo comprasInsumo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comprasInsumo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCompra"] = new SelectList(_context.Compras, "IdCompra", "IdCompra", comprasInsumo.IdCompra);
            ViewData["IdInsumo"] = new SelectList(_context.Insumos, "IdInsumo", "IdInsumo", comprasInsumo.IdInsumo);
            return View(comprasInsumo);
        }

        // GET: ComprasInsumoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ComprasInsumos == null)
            {
                return NotFound();
            }

            var comprasInsumo = await _context.ComprasInsumos.FindAsync(id);
            if (comprasInsumo == null)
            {
                return NotFound();
            }
            ViewData["IdCompra"] = new SelectList(_context.Compras, "IdCompra", "IdCompra", comprasInsumo.IdCompra);
            ViewData["IdInsumo"] = new SelectList(_context.Insumos, "IdInsumo", "IdInsumo", comprasInsumo.IdInsumo);
            return View(comprasInsumo);
        }

        // POST: ComprasInsumoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdComprasInsumos,CantidadInsumoComprasInsumos,PrecioInsumoComprasInsumos,IdCompra,IdInsumo")] ComprasInsumo comprasInsumo)
        {
            if (id != comprasInsumo.IdComprasInsumos)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comprasInsumo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComprasInsumoExists(comprasInsumo.IdComprasInsumos))
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
            ViewData["IdCompra"] = new SelectList(_context.Compras, "IdCompra", "IdCompra", comprasInsumo.IdCompra);
            ViewData["IdInsumo"] = new SelectList(_context.Insumos, "IdInsumo", "IdInsumo", comprasInsumo.IdInsumo);
            return View(comprasInsumo);
        }

        // GET: ComprasInsumoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ComprasInsumos == null)
            {
                return NotFound();
            }

            var comprasInsumo = await _context.ComprasInsumos
                .Include(c => c.IdCompraNavigation)
                .Include(c => c.IdInsumoNavigation)
                .FirstOrDefaultAsync(m => m.IdComprasInsumos == id);
            if (comprasInsumo == null)
            {
                return NotFound();
            }

            return View(comprasInsumo);
        }

        // POST: ComprasInsumoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ComprasInsumos == null)
            {
                return Problem("Entity set 'LuchoSoftContext.ComprasInsumos'  is null.");
            }
            var comprasInsumo = await _context.ComprasInsumos.FindAsync(id);
            if (comprasInsumo != null)
            {
                _context.ComprasInsumos.Remove(comprasInsumo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComprasInsumoExists(int id)
        {
          return (_context.ComprasInsumos?.Any(e => e.IdComprasInsumos == id)).GetValueOrDefault();
        }
    }
}
