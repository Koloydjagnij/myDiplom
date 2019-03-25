using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using test;
using test.Data;

namespace test.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MaritalStatusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MaritalStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MaritalStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.MaritalStatus.ToListAsync());
        }

        // GET: MaritalStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maritalStatus = await _context.MaritalStatus
                .SingleOrDefaultAsync(m => m.IdMaritalStatus == id);
            if (maritalStatus == null)
            {
                return NotFound();
            }

            return View(maritalStatus);
        }

        // GET: MaritalStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MaritalStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMaritalStatus,NameMaritalStatus")] MaritalStatus maritalStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(maritalStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(maritalStatus);
        }

        // GET: MaritalStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maritalStatus = await _context.MaritalStatus.SingleOrDefaultAsync(m => m.IdMaritalStatus == id);
            if (maritalStatus == null)
            {
                return NotFound();
            }
            return View(maritalStatus);
        }

        // POST: MaritalStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMaritalStatus,NameMaritalStatus")] MaritalStatus maritalStatus)
        {
            if (id != maritalStatus.IdMaritalStatus)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(maritalStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaritalStatusExists(maritalStatus.IdMaritalStatus))
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
            return View(maritalStatus);
        }

        // GET: MaritalStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maritalStatus = await _context.MaritalStatus
                .SingleOrDefaultAsync(m => m.IdMaritalStatus == id);
            if (maritalStatus == null)
            {
                return NotFound();
            }

            return View(maritalStatus);
        }

        // POST: MaritalStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var maritalStatus = await _context.MaritalStatus.SingleOrDefaultAsync(m => m.IdMaritalStatus == id);
            _context.MaritalStatus.Remove(maritalStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaritalStatusExists(int id)
        {
            return _context.MaritalStatus.Any(e => e.IdMaritalStatus == id);
        }
    }
}
