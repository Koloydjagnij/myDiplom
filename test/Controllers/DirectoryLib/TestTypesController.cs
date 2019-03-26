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
    public class TestTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TestTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TestTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TestType.ToListAsync());
        }

        // GET: TestTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testType = await _context.TestType
                .SingleOrDefaultAsync(m => m.IdTestType == id);
            if (testType == null)
            {
                return NotFound();
            }

            return View(testType);
        }

        // GET: TestTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TestTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTestType,NameTestType")] TestType testType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(testType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(testType);
        }

        // GET: TestTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testType = await _context.TestType.SingleOrDefaultAsync(m => m.IdTestType == id);
            if (testType == null)
            {
                return NotFound();
            }
            return View(testType);
        }

        // POST: TestTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTestType,NameTestType")] TestType testType)
        {
            if (id != testType.IdTestType)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestTypeExists(testType.IdTestType))
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
            return View(testType);
        }

        // GET: TestTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testType = await _context.TestType
                .SingleOrDefaultAsync(m => m.IdTestType == id);
            if (testType == null)
            {
                return NotFound();
            }

            return View(testType);
        }

        // POST: TestTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var testType = await _context.TestType.SingleOrDefaultAsync(m => m.IdTestType == id);
            _context.TestType.Remove(testType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestTypeExists(int id)
        {
            return _context.TestType.Any(e => e.IdTestType == id);
        }
    }
}
