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
    public class FourPsController : Controller
    {
        private readonly RKGemsContext _context;

        public FourPsController(RKGemsContext context)
        {
            _context = context;
        }

        // GET: FourPs
        public async Task<IActionResult> Index()
        {
            var rKGemsContext = _context.FourPs.Include(f => f.PurchaseItemNumber).Include(x => x.WeightOfResult).AsQueryable();
            return View(await rKGemsContext.ToListAsync());
        }

        // GET: FourPs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fourP = await _context.FourPs
                .Include(f => f.PurchaseItemNumber)
                .FirstOrDefaultAsync(m => m.FourPId == id);
            if (fourP == null)
            {
                return NotFound();
            }

            return View(fourP);
        }

        // GET: FourPs/Create
        public IActionResult Create()
        {
            ViewData["PurchaseId"] = new SelectList(_context.Purchase, "Id", "ItemNumber");
            return View();
        }

        // POST: FourPs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FourPId,FourPQuantity,FourPWeight,PurchaseId,IdOfResult")] FourP fourP)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fourP);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PurchaseId"] = new SelectList(_context.Purchase, "Id", "ItemNumber", fourP.IdOfResult);
            return View(fourP);
        }

        // GET: FourPs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fourP = await _context.FourPs.FindAsync(id);
            if (fourP == null)
            {
                return NotFound();
            }
            ViewData["PurchaseId"] = new SelectList(_context.Purchase, "Id", "ItemNumber", fourP.IdOfResult);
            return View(fourP);
        }

        // POST: FourPs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FourPId,FourPQuantity,FourPWeight,PurchaseId,IdOfResult")] FourP fourP)
        {
            if (id != fourP.FourPId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fourP);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FourPExists(fourP.FourPId))
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
            ViewData["PurchaseId"] = new SelectList(_context.Purchase, "Id", "ItemNumber", fourP.IdOfResult);
            return View(fourP);
        }

        // GET: FourPs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fourP = await _context.FourPs
                .Include(f => f.PurchaseItemNumber)
                .FirstOrDefaultAsync(m => m.FourPId == id);
            if (fourP == null)
            {
                return NotFound();
            }

            return View(fourP);
        }

        // POST: FourPs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fourP = await _context.FourPs.FindAsync(id);
            _context.FourPs.Remove(fourP);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FourPExists(int id)
        {
            return _context.FourPs.Any(e => e.FourPId == id);
        }
    }
}
