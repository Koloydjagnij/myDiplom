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
    public class SpecialitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SpecialitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Specialities
        public async Task<IActionResult> Index()
        {
            return View(await _context.Speciality.ToListAsync());
        }

        // GET: Specialities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speciality = await _context.Speciality
                .SingleOrDefaultAsync(m => m.IdSpeciality == id);
            if (speciality == null)
            {
                return NotFound();
            }

            return View(speciality);
        }

        // GET: Specialities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Specialities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSpeciality,NameSpeciality")] Speciality speciality)
        {
            if (ModelState.IsValid)
            {
                speciality.NameSpeciality = speciality.NameSpeciality.Trim();
                var anySpeciality = _context.Speciality.Any(p => (String.Compare(p.NameSpeciality, speciality.NameSpeciality) == 0));
                if (anySpeciality)
                {
                    ModelState.AddModelError("", "Данная специальность уже зарегистрирована");
                    return View(speciality);
                }
                _context.Add(speciality);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(speciality);
        }

        // GET: Specialities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speciality = await _context.Speciality.SingleOrDefaultAsync(m => m.IdSpeciality == id);
            if (speciality == null)
            {
                return NotFound();
            }
            return View(speciality);
        }

        // POST: Specialities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSpeciality,NameSpeciality")] Speciality speciality)
        {
            if (id != speciality.IdSpeciality)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    speciality.NameSpeciality = speciality.NameSpeciality.Trim();
                    var anySpeciality = _context.Speciality.Any(p => (String.Compare(p.NameSpeciality, speciality.NameSpeciality) == 0));
                    if (anySpeciality)
                    {
                        ModelState.AddModelError("", "Данная специальность уже зарегистрирована");
                        return View(speciality);
                    }
                    _context.Update(speciality);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpecialityExists(speciality.IdSpeciality))
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
            return View(speciality);
        }

        // GET: Specialities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speciality = await _context.Speciality
                .SingleOrDefaultAsync(m => m.IdSpeciality == id);
            if (speciality == null)
            {
                return NotFound();
            }

            return View(speciality);
        }

        // POST: Specialities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var speciality = await _context.Speciality.SingleOrDefaultAsync(m => m.IdSpeciality == id);
            _context.Speciality.Remove(speciality);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpecialityExists(int id)
        {
            return _context.Speciality.Any(e => e.IdSpeciality == id);
        }
    }
}
