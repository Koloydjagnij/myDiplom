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

namespace test.Controllers.DirectoryLib
{
    [Authorize(Roles = "Admin")]
    public class FamilyTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FamilyTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FamilyTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.FamilyType.ToListAsync());
        }

        // GET: FamilyTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var familyType = await _context.FamilyType
                .SingleOrDefaultAsync(m => m.IdFamilyType == id);
            if (familyType == null)
            {
                return NotFound();
            }

            return View(familyType);
        }

        // GET: FamilyTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FamilyTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFamilyType,NameFamilyType")] FamilyType familyType)
        {
            if (ModelState.IsValid)
            {
                familyType.NameFamilyType = familyType.NameFamilyType.Trim();
                var anyFT = _context.FamilyType.Any(p => (String.Compare(p.NameFamilyType,familyType.NameFamilyType) == 0));
                if (anyFT)
                {
                    ModelState.AddModelError("", "Данный тип семьи уже зарегистрирован");
                    return View();
                }
                _context.Add(familyType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(familyType);
        }

        // GET: FamilyTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var familyType = await _context.FamilyType.SingleOrDefaultAsync(m => m.IdFamilyType == id);
            if (familyType == null)
            {
                return NotFound();
            }
            return View(familyType);
        }

        // POST: FamilyTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdFamilyType,NameFamilyType")] FamilyType familyType)
        {
            if (id != familyType.IdFamilyType)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    familyType.NameFamilyType = familyType.NameFamilyType.Trim();
                    var anyFT = _context.FamilyType.Any(p => (String.Compare(p.NameFamilyType, familyType.NameFamilyType) == 0));
                    if (anyFT)
                    {
                        ModelState.AddModelError("", "Данный тип семьи уже зарегистрирован");
                        return View();
                    }
                    _context.Update(familyType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FamilyTypeExists(familyType.IdFamilyType))
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
            return View(familyType);
        }

        // GET: FamilyTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var familyType = await _context.FamilyType
                .SingleOrDefaultAsync(m => m.IdFamilyType == id);
            if (familyType == null)
            {
                return NotFound();
            }

            return View(familyType);
        }

        // POST: FamilyTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var familyType = await _context.FamilyType.SingleOrDefaultAsync(m => m.IdFamilyType == id);
            _context.FamilyType.Remove(familyType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FamilyTypeExists(int id)
        {
            return _context.FamilyType.Any(e => e.IdFamilyType == id);
        }
    }
}
