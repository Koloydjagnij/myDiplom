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

namespace test.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MilitaryDistrictsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MilitaryDistrictsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MilitaryDistricts
        public async Task<IActionResult> Index()
        {
            return View(await _context.MilitaryDistrict.ToListAsync());
        }

        // GET: MilitaryDistricts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var militaryDistrict = await _context.MilitaryDistrict
                .SingleOrDefaultAsync(m => m.IdMilitaryDistrict == id);
            if (militaryDistrict == null)
            {
                return NotFound();
            }

            return View(militaryDistrict);
        }

        // GET: MilitaryDistricts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MilitaryDistricts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMilitaryDistrict,NameMilitaryDistrict")] MilitaryDistrict militaryDistrict)
        {
            if (ModelState.IsValid)
            {
                _context.Add(militaryDistrict);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(militaryDistrict);
        }

        // GET: MilitaryDistricts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var militaryDistrict = await _context.MilitaryDistrict.SingleOrDefaultAsync(m => m.IdMilitaryDistrict == id);
            if (militaryDistrict == null)
            {
                return NotFound();
            }
            return View(militaryDistrict);
        }

        // POST: MilitaryDistricts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMilitaryDistrict,NameMilitaryDistrict")] MilitaryDistrict militaryDistrict)
        {
            if (id != militaryDistrict.IdMilitaryDistrict)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(militaryDistrict);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MilitaryDistrictExists(militaryDistrict.IdMilitaryDistrict))
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
            return View(militaryDistrict);
        }

        // GET: MilitaryDistricts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var militaryDistrict = await _context.MilitaryDistrict
                .SingleOrDefaultAsync(m => m.IdMilitaryDistrict == id);
            if (militaryDistrict == null)
            {
                return NotFound();
            }

            return View(militaryDistrict);
        }

        // POST: MilitaryDistricts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var militaryDistrict = await _context.MilitaryDistrict.SingleOrDefaultAsync(m => m.IdMilitaryDistrict == id);
            _context.MilitaryDistrict.Remove(militaryDistrict);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MilitaryDistrictExists(int id)
        {
            return _context.MilitaryDistrict.Any(e => e.IdMilitaryDistrict == id);
        }
    }
}
