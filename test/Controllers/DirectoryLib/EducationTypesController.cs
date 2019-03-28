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
    public class EducationTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EducationTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EducationTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.EducationType.ToListAsync());
        }

        // GET: EducationTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var educationType = await _context.EducationType
                .SingleOrDefaultAsync(m => m.IdEducationType == id);
            if (educationType == null)
            {
                return NotFound();
            }

            return View(educationType);
        }

        // GET: EducationTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EducationTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEducationType,NameEducationType")] EducationType educationType)
        {
            if (ModelState.IsValid)
            {
                educationType.NameEducationType = educationType.NameEducationType.Trim();
                var anyEdType = _context.EducationType.Any(p => (String.Compare(p.NameEducationType, educationType.NameEducationType) == 0));
                if (anyEdType)
                {
                    ModelState.AddModelError("", "Тип образования с таким названием уже зарегистрирован");
                    return View(educationType);
                }
                _context.Add(educationType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(educationType);
        }

        // GET: EducationTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var educationType = await _context.EducationType.SingleOrDefaultAsync(m => m.IdEducationType == id);
            if (educationType == null)
            {
                return NotFound();
            }
            return View(educationType);
        }

        // POST: EducationTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEducationType,NameEducationType")] EducationType educationType)
        {
            if (id != educationType.IdEducationType)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    educationType.NameEducationType = educationType.NameEducationType.Trim();
                    var anyEdType = _context.EducationType.Any(p => (String.Compare(p.NameEducationType, educationType.NameEducationType) == 0));
                    if (anyEdType)
                    {
                        ModelState.AddModelError("", "Тип образования с таким названием уже зарегистрирован");
                        return View(educationType);
                    }
                    _context.Update(educationType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EducationTypeExists(educationType.IdEducationType))
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
            return View(educationType);
        }

        // GET: EducationTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var educationType = await _context.EducationType
                .SingleOrDefaultAsync(m => m.IdEducationType == id);
            if (educationType == null)
            {
                return NotFound();
            }

            return View(educationType);
        }

        // POST: EducationTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var educationType = await _context.EducationType.SingleOrDefaultAsync(m => m.IdEducationType == id);
            _context.EducationType.Remove(educationType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EducationTypeExists(int id)
        {
            return _context.EducationType.Any(e => e.IdEducationType == id);
        }
    }
}
