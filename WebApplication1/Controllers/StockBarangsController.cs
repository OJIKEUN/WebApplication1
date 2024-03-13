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
    public class StockBarangsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StockBarangsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StockBarangs
        public async Task<IActionResult> Index()
        {
            return View(await _context.StockBarang.ToListAsync());
        }

        // GET: StockBarangs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockBarang = await _context.StockBarang
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stockBarang == null)
            {
                return NotFound();
            }

            return View(stockBarang);
        }

        // GET: StockBarangs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StockBarangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NamaBarang,In,Out,Balance")] StockBarang stockBarang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stockBarang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stockBarang);
        }

        // GET: StockBarangs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockBarang = await _context.StockBarang.FindAsync(id);
            if (stockBarang == null)
            {
                return NotFound();
            }
            return View(stockBarang);
        }

        // POST: StockBarangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NamaBarang,In,Out,Balance")] StockBarang stockBarang)
        {
            if (id != stockBarang.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stockBarang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StockBarangExists(stockBarang.Id))
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
            return View(stockBarang);
        }

        // GET: StockBarangs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockBarang = await _context.StockBarang
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stockBarang == null)
            {
                return NotFound();
            }

            return View(stockBarang);
        }

        // POST: StockBarangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stockBarang = await _context.StockBarang.FindAsync(id);
            if (stockBarang != null)
            {
                _context.StockBarang.Remove(stockBarang);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StockBarangExists(int id)
        {
            return _context.StockBarang.Any(e => e.Id == id);
        }
    }
}
