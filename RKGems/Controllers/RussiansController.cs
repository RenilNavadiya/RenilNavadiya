using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RKGems.Data;
using RKGems.Models;

namespace RKGems.Controllers
{
    public class RussiansController : Controller
    {
        private readonly RKGemsContext _context;

        public RussiansController(RKGemsContext context)
        {
            _context = context;
        }

        // GET: Russians
        public async Task<IActionResult> Index()
        {
            var rKGemsContext = _context.Russians.Include(r => r.PurchaseItemNumber).Include(x => x.WeightOfFourP).AsQueryable();
            return View(await rKGemsContext.ToListAsync());
        }

        // GET: Russians/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var russian = await _context.Russians
                .Include(r => r.PurchaseItemNumber)
                .FirstOrDefaultAsync(m => m.RussianId == id);
            if (russian == null)
            {
                return NotFound();
            }

            return View(russian);
        }

        // GET: Russians/Create
        public IActionResult Create()
        {
            ViewData["PurchaseId"] = new SelectList(_context.Purchase, "Id", "ItemNumber");
            return View();
        }

        // POST: Russians/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RussianId,RussianQuantity,RussianWeight,PurchaseId,IdOfFourP")] Russian russian)
        {
            if (ModelState.IsValid)
            {
                _context.Add(russian);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PurchaseId"] = new SelectList(_context.Purchase, "Id", "ItemNumber", russian.PurchaseId);
            return View(russian);
        }

        // GET: Russians/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var russian = await _context.Russians.FindAsync(id);
            if (russian == null)
            {
                return NotFound();
            }
            ViewData["PurchaseId"] = new SelectList(_context.Purchase, "Id", "ItemNumber", russian.PurchaseId);
            return View(russian);
        }

        // POST: Russians/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RussianId,RussianQuantity,RussianWeight,PurchaseId,IdOfFourP")] Russian russian)
        {
            if (id != russian.RussianId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(russian);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RussianExists(russian.RussianId))
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
            ViewData["PurchaseId"] = new SelectList(_context.Purchase, "Id", "ItemNumber", russian.PurchaseId);
            return View(russian);
        }

        // GET: Russians/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var russian = await _context.Russians
                .Include(r => r.PurchaseItemNumber)
                .FirstOrDefaultAsync(m => m.RussianId == id);
            if (russian == null)
            {
                return NotFound();
            }

            return View(russian);
        }

        // POST: Russians/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var russian = await _context.Russians.FindAsync(id);
            _context.Russians.Remove(russian);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RussianExists(int id)
        {
            return _context.Russians.Any(e => e.RussianId == id);
        }
    }
}
