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
    public class FactOfProsecutionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FactOfProsecutionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FactOfProsecutions
        public async Task<IActionResult> Index()
        {
            return View(await _context.FactOfProsecution.ToListAsync());
        }

        // GET: FactOfProsecutions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factOfProsecution = await _context.FactOfProsecution
                .SingleOrDefaultAsync(m => m.IdFactOfProsecution == id);
            if (factOfProsecution == null)
            {
                return NotFound();
            }

            return View(factOfProsecution);
        }

        // GET: FactOfProsecutions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FactOfProsecutions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFactOfProsecution,NameFactOfProsecution")] FactOfProsecution factOfProsecution)
        {
            if (ModelState.IsValid)
            {
                _context.Add(factOfProsecution);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(factOfProsecution);
        }

        // GET: FactOfProsecutions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factOfProsecution = await _context.FactOfProsecution.SingleOrDefaultAsync(m => m.IdFactOfProsecution == id);
            if (factOfProsecution == null)
            {
                return NotFound();
            }
            return View(factOfProsecution);
        }

        // POST: FactOfProsecutions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdFactOfProsecution,NameFactOfProsecution")] FactOfProsecution factOfProsecution)
        {
            if (id != factOfProsecution.IdFactOfProsecution)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(factOfProsecution);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FactOfProsecutionExists(factOfProsecution.IdFactOfProsecution))
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
            return View(factOfProsecution);
        }

        // GET: FactOfProsecutions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factOfProsecution = await _context.FactOfProsecution
                .SingleOrDefaultAsync(m => m.IdFactOfProsecution == id);
            if (factOfProsecution == null)
            {
                return NotFound();
            }

            return View(factOfProsecution);
        }

        // POST: FactOfProsecutions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var factOfProsecution = await _context.FactOfProsecution.SingleOrDefaultAsync(m => m.IdFactOfProsecution == id);
            _context.FactOfProsecution.Remove(factOfProsecution);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FactOfProsecutionExists(int id)
        {
            return _context.FactOfProsecution.Any(e => e.IdFactOfProsecution == id);
        }
    }
}
