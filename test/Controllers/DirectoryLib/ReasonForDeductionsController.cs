using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using test;
using test.Data;
using Microsoft.AspNetCore.Authorization;

namespace test.Controllers.DirectoryLib
{
    [Authorize(Roles = "Admin")]
    public class ReasonForDeductionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReasonForDeductionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ReasonForDeductions
        public async Task<IActionResult> Index()
        {
            return View(await _context.ReasonForDeduction.ToListAsync());
        }

        // GET: ReasonForDeductions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reasonForDeduction = await _context.ReasonForDeduction
                .SingleOrDefaultAsync(m => m.IdReasonForDeduction == id);
            if (reasonForDeduction == null)
            {
                return NotFound();
            }

            return View(reasonForDeduction);
        }

        // GET: ReasonForDeductions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReasonForDeductions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdReasonForDeduction,NameReasonForDeduction")] ReasonForDeduction reasonForDeduction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reasonForDeduction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reasonForDeduction);
        }

        // GET: ReasonForDeductions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reasonForDeduction = await _context.ReasonForDeduction.SingleOrDefaultAsync(m => m.IdReasonForDeduction == id);
            if (reasonForDeduction == null)
            {
                return NotFound();
            }
            return View(reasonForDeduction);
        }

        // POST: ReasonForDeductions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdReasonForDeduction,NameReasonForDeduction")] ReasonForDeduction reasonForDeduction)
        {
            if (id != reasonForDeduction.IdReasonForDeduction)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reasonForDeduction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReasonForDeductionExists(reasonForDeduction.IdReasonForDeduction))
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
            return View(reasonForDeduction);
        }

        // GET: ReasonForDeductions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reasonForDeduction = await _context.ReasonForDeduction
                .SingleOrDefaultAsync(m => m.IdReasonForDeduction == id);
            if (reasonForDeduction == null)
            {
                return NotFound();
            }

            return View(reasonForDeduction);
        }

        // POST: ReasonForDeductions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reasonForDeduction = await _context.ReasonForDeduction.SingleOrDefaultAsync(m => m.IdReasonForDeduction == id);
            _context.ReasonForDeduction.Remove(reasonForDeduction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReasonForDeductionExists(int id)
        {
            return _context.ReasonForDeduction.Any(e => e.IdReasonForDeduction == id);
        }
    }
}
