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
    public class MilitaryUnitsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MilitaryUnitsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MilitaryUnits
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.MilitaryUnit.Include(m => m.IdAreaNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: MilitaryUnits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var militaryUnit = await _context.MilitaryUnit
                .Include(m => m.IdAreaNavigation)
                .SingleOrDefaultAsync(m => m.IdMilitaryUnit == id);
            if (militaryUnit == null)
            {
                return NotFound();
            }

            return View(militaryUnit);
        }

        // GET: MilitaryUnits/Create
        public IActionResult Create()
        {
            ViewData["IdArea"] = new SelectList(_context.Area, "IdArea", "NameArea");
            return View();
        }

        // POST: MilitaryUnits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMilitaryUnit,NameMilitaryUnit,IdArea")] MilitaryUnit militaryUnit)
        {
            if (ModelState.IsValid)
            {
                militaryUnit.NameMilitaryUnit = militaryUnit.NameMilitaryUnit.Trim();
                var anyMilitaryUnit = _context.MilitaryUnit.Any(p => (String.Compare(p.NameMilitaryUnit,militaryUnit.NameMilitaryUnit) == 0)&&(p.IdArea==militaryUnit.IdArea));
                if (anyMilitaryUnit)
                {
                    ModelState.AddModelError("", "Данная в/ч в данном регионе уже зарегистрирована");
                    return View();
                }
                _context.Add(militaryUnit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdArea"] = new SelectList(_context.Area, "IdArea", "NameArea", militaryUnit.IdArea);
            return View(militaryUnit);
        }

        // GET: MilitaryUnits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var militaryUnit = await _context.MilitaryUnit.SingleOrDefaultAsync(m => m.IdMilitaryUnit == id);
            if (militaryUnit == null)
            {
                return NotFound();
            }
            ViewData["IdArea"] = new SelectList(_context.Area, "IdArea", "NameArea", militaryUnit.IdArea);
            return View(militaryUnit);
        }

        // POST: MilitaryUnits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMilitaryUnit,NameMilitaryUnit,IdArea")] MilitaryUnit militaryUnit)
        {
            if (id != militaryUnit.IdMilitaryUnit)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    militaryUnit.NameMilitaryUnit = militaryUnit.NameMilitaryUnit.Trim();
                    var anyMilitaryUnit = _context.MilitaryUnit.Any(p => (String.Compare(p.NameMilitaryUnit, militaryUnit.NameMilitaryUnit) == 0) && (p.IdArea == militaryUnit.IdArea));
                    if (anyMilitaryUnit)
                    {
                        ModelState.AddModelError("", "Данная в/ч в данном регионе уже зарегистрирована");
                        return View();
                    }
                    _context.Update(militaryUnit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MilitaryUnitExists(militaryUnit.IdMilitaryUnit))
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
            ViewData["IdArea"] = new SelectList(_context.Area, "IdArea", "NameArea", militaryUnit.IdArea);
            return View(militaryUnit);
        }

        // GET: MilitaryUnits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var militaryUnit = await _context.MilitaryUnit
                .Include(m => m.IdAreaNavigation)
                .SingleOrDefaultAsync(m => m.IdMilitaryUnit == id);
            if (militaryUnit == null)
            {
                return NotFound();
            }

            return View(militaryUnit);
        }

        // POST: MilitaryUnits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var militaryUnit = await _context.MilitaryUnit.SingleOrDefaultAsync(m => m.IdMilitaryUnit == id);
            _context.MilitaryUnit.Remove(militaryUnit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MilitaryUnitExists(int id)
        {
            return _context.MilitaryUnit.Any(e => e.IdMilitaryUnit == id);
        }
    }
}
