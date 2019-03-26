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
    public class MilitaryServiceCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MilitaryServiceCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MilitaryServiceCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.MilitaryServiceCategory.ToListAsync());
        }

        // GET: MilitaryServiceCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var militaryServiceCategory = await _context.MilitaryServiceCategory
                .SingleOrDefaultAsync(m => m.IdCategoryMs == id);
            if (militaryServiceCategory == null)
            {
                return NotFound();
            }

            return View(militaryServiceCategory);
        }

        // GET: MilitaryServiceCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MilitaryServiceCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCategoryMs,NameCategoryMs")] MilitaryServiceCategory militaryServiceCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(militaryServiceCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(militaryServiceCategory);
        }

        // GET: MilitaryServiceCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var militaryServiceCategory = await _context.MilitaryServiceCategory.SingleOrDefaultAsync(m => m.IdCategoryMs == id);
            if (militaryServiceCategory == null)
            {
                return NotFound();
            }
            return View(militaryServiceCategory);
        }

        // POST: MilitaryServiceCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCategoryMs,NameCategoryMs")] MilitaryServiceCategory militaryServiceCategory)
        {
            if (id != militaryServiceCategory.IdCategoryMs)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(militaryServiceCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MilitaryServiceCategoryExists(militaryServiceCategory.IdCategoryMs))
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
            return View(militaryServiceCategory);
        }

        // GET: MilitaryServiceCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var militaryServiceCategory = await _context.MilitaryServiceCategory
                .SingleOrDefaultAsync(m => m.IdCategoryMs == id);
            if (militaryServiceCategory == null)
            {
                return NotFound();
            }

            return View(militaryServiceCategory);
        }

        // POST: MilitaryServiceCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var militaryServiceCategory = await _context.MilitaryServiceCategory.SingleOrDefaultAsync(m => m.IdCategoryMs == id);
            _context.MilitaryServiceCategory.Remove(militaryServiceCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MilitaryServiceCategoryExists(int id)
        {
            return _context.MilitaryServiceCategory.Any(e => e.IdCategoryMs == id);
        }
    }
}
