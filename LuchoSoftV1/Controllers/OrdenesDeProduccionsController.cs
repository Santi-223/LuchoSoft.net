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
    public class OrdenesDeProduccionsController : Controller
    {
        private readonly LuchoSoftContext _context;

        public OrdenesDeProduccionsController(LuchoSoftContext context)
        {
            _context = context;
        }

        // GET: OrdenesDeProduccions
        public async Task<IActionResult> Index()
        {
            var luchoSoftContext = _context.OrdenesDeProduccions.Include(o => o.IdEmpleadoNavigation);
            return View(await luchoSoftContext.ToListAsync());
        }

        // GET: OrdenesDeProduccions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OrdenesDeProduccions == null)
            {
                return NotFound();
            }

            var ordenesDeProduccion = await _context.OrdenesDeProduccions
                .Include(o => o.IdEmpleadoNavigation)
                .FirstOrDefaultAsync(m => m.IdOrdenDeProduccion == id);
            if (ordenesDeProduccion == null)
            {
                return NotFound();
            }

            return View(ordenesDeProduccion);
        }

        // GET: OrdenesDeProduccions/Create
        public IActionResult Create()
        {
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "IdEmpleado");
            return View();
        }

        // POST: OrdenesDeProduccions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdOrdenDeProduccion,DescripcionOrden,FechaOrden,IdEmpleado")] OrdenesDeProduccion ordenesDeProduccion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ordenesDeProduccion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "IdEmpleado", ordenesDeProduccion.IdEmpleado);
            return View(ordenesDeProduccion);
        }

        // GET: OrdenesDeProduccions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OrdenesDeProduccions == null)
            {
                return NotFound();
            }

            var ordenesDeProduccion = await _context.OrdenesDeProduccions.FindAsync(id);
            if (ordenesDeProduccion == null)
            {
                return NotFound();
            }
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "IdEmpleado", ordenesDeProduccion.IdEmpleado);
            return View(ordenesDeProduccion);
        }

        // POST: OrdenesDeProduccions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdOrdenDeProduccion,DescripcionOrden,FechaOrden,IdEmpleado")] OrdenesDeProduccion ordenesDeProduccion)
        {
            if (id != ordenesDeProduccion.IdOrdenDeProduccion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ordenesDeProduccion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdenesDeProduccionExists(ordenesDeProduccion.IdOrdenDeProduccion))
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
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "IdEmpleado", ordenesDeProduccion.IdEmpleado);
            return View(ordenesDeProduccion);
        }

        // GET: OrdenesDeProduccions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.OrdenesDeProduccions == null)
            {
                return NotFound();
            }

            var ordenesDeProduccion = await _context.OrdenesDeProduccions
                .Include(o => o.IdEmpleadoNavigation)
                .FirstOrDefaultAsync(m => m.IdOrdenDeProduccion == id);
            if (ordenesDeProduccion == null)
            {
                return NotFound();
            }

            return View(ordenesDeProduccion);
        }

        // POST: OrdenesDeProduccions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OrdenesDeProduccions == null)
            {
                return Problem("Entity set 'LuchoSoftContext.OrdenesDeProduccions'  is null.");
            }
            var ordenesDeProduccion = await _context.OrdenesDeProduccions.FindAsync(id);
            if (ordenesDeProduccion != null)
            {
                _context.OrdenesDeProduccions.Remove(ordenesDeProduccion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdenesDeProduccionExists(int id)
        {
          return (_context.OrdenesDeProduccions?.Any(e => e.IdOrdenDeProduccion == id)).GetValueOrDefault();
        }
    }
}
