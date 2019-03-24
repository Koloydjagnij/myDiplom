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
    public class SexesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SexesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sexes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sex.ToListAsync());
        }

        // GET: Sexes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sex = await _context.Sex
                .SingleOrDefaultAsync(m => m.IdSex == id);
            if (sex == null)
            {
                return NotFound();
            }

            return View(sex);
        }

        // GET: Sexes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sexes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSex,NameSex")] Sex sex)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sex);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sex);
        }

        // GET: Sexes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sex = await _context.Sex.SingleOrDefaultAsync(m => m.IdSex == id);
            if (sex == null)
            {
                return NotFound();
            }
            return View(sex);
        }

        // POST: Sexes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSex,NameSex")] Sex sex)
        {
            if (id != sex.IdSex)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sex);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SexExists(sex.IdSex))
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
            return View(sex);
        }

        // GET: Sexes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sex = await _context.Sex
                .SingleOrDefaultAsync(m => m.IdSex == id);
            if (sex == null)
            {
                return NotFound();
            }

            return View(sex);
        }

        // POST: Sexes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sex = await _context.Sex.SingleOrDefaultAsync(m => m.IdSex == id);
            _context.Sex.Remove(sex);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SexExists(int id)
        {
            return _context.Sex.Any(e => e.IdSex == id);
        }
    }
}
