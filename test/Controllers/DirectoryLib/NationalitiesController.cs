﻿using System;
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
    public class NationalitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NationalitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Nationalities
        public async Task<IActionResult> Index()
        {
            return View(await _context.Nationality.ToListAsync());
        }

        // GET: Nationalities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nationality = await _context.Nationality
                .SingleOrDefaultAsync(m => m.IdNationality == id);
            if (nationality == null)
            {
                return NotFound();
            }

            return View(nationality);
        }

        // GET: Nationalities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Nationalities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdNationality,NameNationality")] Nationality nationality)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nationality);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nationality);
        }

        // GET: Nationalities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nationality = await _context.Nationality.SingleOrDefaultAsync(m => m.IdNationality == id);
            if (nationality == null)
            {
                return NotFound();
            }
            return View(nationality);
        }

        // POST: Nationalities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdNationality,NameNationality")] Nationality nationality)
        {
            if (id != nationality.IdNationality)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nationality);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NationalityExists(nationality.IdNationality))
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
            return View(nationality);
        }

        // GET: Nationalities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nationality = await _context.Nationality
                .SingleOrDefaultAsync(m => m.IdNationality == id);
            if (nationality == null)
            {
                return NotFound();
            }

            return View(nationality);
        }

        // POST: Nationalities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nationality = await _context.Nationality.SingleOrDefaultAsync(m => m.IdNationality == id);
            _context.Nationality.Remove(nationality);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NationalityExists(int id)
        {
            return _context.Nationality.Any(e => e.IdNationality == id);
        }
    }
}
