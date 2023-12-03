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
    public class PedidosProductoesController : Controller
    {
        private readonly LuchoSoftContext _context;

        public PedidosProductoesController(LuchoSoftContext context)
        {
            _context = context;
        }

        // GET: PedidosProductoes
        public async Task<IActionResult> Index()
        {
            var luchoSoftContext = _context.PedidosProductos.Include(p => p.IdPedidoNavigation).Include(p => p.IdProductoNavigation);
            return View(await luchoSoftContext.ToListAsync());
        }

        // GET: PedidosProductoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PedidosProductos == null)
            {
                return NotFound();
            }

            var pedidosProducto = await _context.PedidosProductos
                .Include(p => p.IdPedidoNavigation)
                .Include(p => p.IdProductoNavigation)
                .FirstOrDefaultAsync(m => m.IdPedidosProductos == id);
            if (pedidosProducto == null)
            {
                return NotFound();
            }

            return View(pedidosProducto);
        }

        // GET: PedidosProductoes/Create
        public IActionResult Create()
        {
            ViewData["IdPedido"] = new SelectList(_context.Pedidos, "IdPedido", "IdPedido");
            ViewData["IdProducto"] = new SelectList(_context.Productos, "IdProducto", "IdProducto");
            return View();
        }

        // POST: PedidosProductoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPedidosProductos,FechaPedidoProducto,CantidadProducto,Subtotal,IdProducto,IdPedido")] PedidosProducto pedidosProducto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedidosProducto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPedido"] = new SelectList(_context.Pedidos, "IdPedido", "IdPedido", pedidosProducto.IdPedido);
            ViewData["IdProducto"] = new SelectList(_context.Productos, "IdProducto", "IdProducto", pedidosProducto.IdProducto);
            return View(pedidosProducto);
        }

        // GET: PedidosProductoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PedidosProductos == null)
            {
                return NotFound();
            }

            var pedidosProducto = await _context.PedidosProductos.FindAsync(id);
            if (pedidosProducto == null)
            {
                return NotFound();
            }
            ViewData["IdPedido"] = new SelectList(_context.Pedidos, "IdPedido", "IdPedido", pedidosProducto.IdPedido);
            ViewData["IdProducto"] = new SelectList(_context.Productos, "IdProducto", "IdProducto", pedidosProducto.IdProducto);
            return View(pedidosProducto);
        }

        // POST: PedidosProductoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPedidosProductos,FechaPedidoProducto,CantidadProducto,Subtotal,IdProducto,IdPedido")] PedidosProducto pedidosProducto)
        {
            if (id != pedidosProducto.IdPedidosProductos)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedidosProducto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidosProductoExists(pedidosProducto.IdPedidosProductos))
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
            ViewData["IdPedido"] = new SelectList(_context.Pedidos, "IdPedido", "IdPedido", pedidosProducto.IdPedido);
            ViewData["IdProducto"] = new SelectList(_context.Productos, "IdProducto", "IdProducto", pedidosProducto.IdProducto);
            return View(pedidosProducto);
        }

        // GET: PedidosProductoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PedidosProductos == null)
            {
                return NotFound();
            }

            var pedidosProducto = await _context.PedidosProductos
                .Include(p => p.IdPedidoNavigation)
                .Include(p => p.IdProductoNavigation)
                .FirstOrDefaultAsync(m => m.IdPedidosProductos == id);
            if (pedidosProducto == null)
            {
                return NotFound();
            }

            return View(pedidosProducto);
        }

        // POST: PedidosProductoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PedidosProductos == null)
            {
                return Problem("Entity set 'LuchoSoftContext.PedidosProductos'  is null.");
            }
            var pedidosProducto = await _context.PedidosProductos.FindAsync(id);
            if (pedidosProducto != null)
            {
                _context.PedidosProductos.Remove(pedidosProducto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidosProductoExists(int id)
        {
          return (_context.PedidosProductos?.Any(e => e.IdPedidosProductos == id)).GetValueOrDefault();
        }
    }
}
