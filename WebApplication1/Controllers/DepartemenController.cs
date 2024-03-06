using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DepartemenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DepartemenController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Departemen
        public async Task<IActionResult> Index()
        {
            return View(await _context.Departemens.ToListAsync());
        }

        // GET: Departemen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departemen = await _context.Departemens
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departemen == null)
            {
                return NotFound();
            }

            return View(departemen);
        }

        // GET: Departemen/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Departemen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ConsumableName,Brand,Packaging,Unit,MinimumStock,ExpiredDate,ReceivedQuantity,Price,IncomingDate,ConsumptionCost,CurrentStock")] Departemen departemen)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departemen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(departemen);
        }

        // GET: Departemen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departemen = await _context.Departemens.FindAsync(id);
            if (departemen == null)
            {
                return NotFound();
            }
            return View(departemen);
        }

        // POST: Departemen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ConsumableName,Brand,Packaging,Unit,MinimumStock,ExpiredDate,ReceivedQuantity,Price,IncomingDate,ConsumptionCost,CurrentStock")] Departemen departemen)
        {
            if (id != departemen.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departemen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartemenExists(departemen.Id))
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
            return View(departemen);
        }

        // GET: Departemen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departemen = await _context.Departemens
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departemen == null)
            {
                return NotFound();
            }

            return View(departemen);
        }

        // POST: Departemen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var departemen = await _context.Departemens.FindAsync(id);
            if (departemen != null)
            {
                _context.Departemens.Remove(departemen);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartemenExists(int id)
        {
            return _context.Departemens.Any(e => e.Id == id);
        }
    }
}
