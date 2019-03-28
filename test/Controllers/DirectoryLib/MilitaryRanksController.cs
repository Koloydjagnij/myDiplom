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
    public class MilitaryRanksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MilitaryRanksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MilitaryRanks
        public async Task<IActionResult> Index()
        {
            return View(await _context.MilitaryRank.ToListAsync());
        }

        // GET: MilitaryRanks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var militaryRank = await _context.MilitaryRank
                .SingleOrDefaultAsync(m => m.IdMilitaryRank == id);
            if (militaryRank == null)
            {
                return NotFound();
            }

            return View(militaryRank);
        }

        // GET: MilitaryRanks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MilitaryRanks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMilitaryRank,NameMilitaryRank")] MilitaryRank militaryRank)
        {
            if (ModelState.IsValid)
            {
                militaryRank.NameMilitaryRank = militaryRank.NameMilitaryRank.Trim();
                var anyMilRank = _context.MilitaryRank.Any(p => (String.Compare(p.NameMilitaryRank,militaryRank.NameMilitaryRank) == 0));
                if (anyMilRank)
                {
                    ModelState.AddModelError("", "Данное воинское звание уже зарегистрировано");
                    return View();
                }

                _context.Add(militaryRank);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(militaryRank);
        }

        // GET: MilitaryRanks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var militaryRank = await _context.MilitaryRank.SingleOrDefaultAsync(m => m.IdMilitaryRank == id);
            if (militaryRank == null)
            {
                return NotFound();
            }
            return View(militaryRank);
        }

        // POST: MilitaryRanks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMilitaryRank,NameMilitaryRank")] MilitaryRank militaryRank)
        {
            if (id != militaryRank.IdMilitaryRank)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    militaryRank.NameMilitaryRank = militaryRank.NameMilitaryRank.Trim();
                    var anyMilRank = _context.MilitaryRank.Any(p => (String.Compare(p.NameMilitaryRank, militaryRank.NameMilitaryRank) == 0));
                    if (anyMilRank)
                    {
                        ModelState.AddModelError("", "Данное воинское звание уже зарегистрировано");
                        return View();
                    }
                    _context.Update(militaryRank);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MilitaryRankExists(militaryRank.IdMilitaryRank))
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
            return View(militaryRank);
        }

        // GET: MilitaryRanks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var militaryRank = await _context.MilitaryRank
                .SingleOrDefaultAsync(m => m.IdMilitaryRank == id);
            if (militaryRank == null)
            {
                return NotFound();
            }

            return View(militaryRank);
        }

        // POST: MilitaryRanks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var militaryRank = await _context.MilitaryRank.SingleOrDefaultAsync(m => m.IdMilitaryRank == id);
            _context.MilitaryRank.Remove(militaryRank);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MilitaryRankExists(int id)
        {
            return _context.MilitaryRank.Any(e => e.IdMilitaryRank == id);
        }
    }
}
