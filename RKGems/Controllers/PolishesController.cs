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
    public class PolishesController : Controller
    {
        private readonly RKGemsContext _context;

        public PolishesController(RKGemsContext context)
        {
            _context = context;
        }

        // GET: Polishes
        public async Task<IActionResult> Index()
        {
            var rKGemsContext = _context.Polishes.Include(p => p.PolishItemNumber).Include(p => p.WeightOfResult);
            return View(await rKGemsContext.ToListAsync());
        }

        // GET: Polishes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var polish = await _context.Polishes
                .Include(p => p.PolishItemNumber)
                .Include(p => p.WeightOfResult)
                .FirstOrDefaultAsync(m => m.PolishId == id);
            if (polish == null)
            {
                return NotFound();
            }

            return View(polish);
        }

        // GET: Polishes/Create
        public IActionResult Create()
        {
            ViewData["PurchaseId"] = new SelectList(_context.Purchase, "Id", "ItemNumber");
            ViewData["IdOfResult"] = new SelectList(_context.Results, "ResultId", "ResultId");
            return View();
        }

        // POST: Polishes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PolishId,PolishQuantity,PolishWeight,PurchaseId,IdOfResult")] Polish polish)
        {
            if (ModelState.IsValid)
            {
                _context.Add(polish);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PurchaseId"] = new SelectList(_context.Purchase, "Id", "ItemNumber", polish.PurchaseId);
            ViewData["IdOfResult"] = new SelectList(_context.Results, "ResultId", "ResultId", polish.IdOfResult);
            return View(polish);
        }

        // GET: Polishes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var polish = await _context.Polishes.FindAsync(id);
            if (polish == null)
            {
                return NotFound();
            }
            ViewData["PurchaseId"] = new SelectList(_context.Purchase, "Id", "ItemNumber", polish.PurchaseId);
            ViewData["IdOfResult"] = new SelectList(_context.Results, "ResultId", "ResultId", polish.IdOfResult);
            return View(polish);
        }

        // POST: Polishes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PolishId,PolishQuantity,PolishWeight,PurchaseId,IdOfResult")] Polish polish)
        {
            if (id != polish.PolishId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(polish);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PolishExists(polish.PolishId))
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
            ViewData["PurchaseId"] = new SelectList(_context.Purchase, "Id", "ItemNumber", polish.PurchaseId);
            ViewData["IdOfResult"] = new SelectList(_context.Results, "ResultId", "ResultId", polish.IdOfResult);
            return View(polish);
        }

        // GET: Polishes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var polish = await _context.Polishes
                .Include(p => p.PolishItemNumber)
                .Include(p => p.WeightOfResult)
                .FirstOrDefaultAsync(m => m.PolishId == id);
            if (polish == null)
            {
                return NotFound();
            }

            return View(polish);
        }

        // POST: Polishes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var polish = await _context.Polishes.FindAsync(id);
            _context.Polishes.Remove(polish);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PolishExists(int id)
        {
            return _context.Polishes.Any(e => e.PolishId == id);
        }
    }
}
