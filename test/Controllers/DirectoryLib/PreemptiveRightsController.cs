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
    public class PreemptiveRightsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PreemptiveRightsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PreemptiveRights
        public async Task<IActionResult> Index()
        {
            return View(await _context.PreemptiveRight.ToListAsync());
        }

        // GET: PreemptiveRights/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var preemptiveRight = await _context.PreemptiveRight
                .SingleOrDefaultAsync(m => m.IdPreemptiveRight == id);
            if (preemptiveRight == null)
            {
                return NotFound();
            }

            return View(preemptiveRight);
        }

        // GET: PreemptiveRights/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PreemptiveRights/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPreemptiveRight,NamePreemptiveRight")] PreemptiveRight preemptiveRight)
        {
            if (ModelState.IsValid)
            {
                preemptiveRight.NamePreemptiveRight = preemptiveRight.NamePreemptiveRight.Trim();
                var any = _context.PreemptiveRight.Any(p => (String.Compare(p.NamePreemptiveRight,preemptiveRight.NamePreemptiveRight) == 0));
                if (any)
                {
                    ModelState.AddModelError("", "Данное приемущественное право уже зарегистрировано");
                    return View();
                }
                _context.Add(preemptiveRight);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(preemptiveRight);
        }

        // GET: PreemptiveRights/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var preemptiveRight = await _context.PreemptiveRight.SingleOrDefaultAsync(m => m.IdPreemptiveRight == id);
            if (preemptiveRight == null)
            {
                return NotFound();
            }
            return View(preemptiveRight);
        }

        // POST: PreemptiveRights/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPreemptiveRight,NamePreemptiveRight")] PreemptiveRight preemptiveRight)
        {
            if (id != preemptiveRight.IdPreemptiveRight)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    preemptiveRight.NamePreemptiveRight = preemptiveRight.NamePreemptiveRight.Trim();
                    var any = _context.PreemptiveRight.Any(p => (String.Compare(p.NamePreemptiveRight, preemptiveRight.NamePreemptiveRight) == 0));
                    if (any)
                    {
                        ModelState.AddModelError("", "Данное приемущественное право уже зарегистрировано");
                        return View();
                    }
                    _context.Update(preemptiveRight);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PreemptiveRightExists(preemptiveRight.IdPreemptiveRight))
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
            return View(preemptiveRight);
        }

        // GET: PreemptiveRights/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var preemptiveRight = await _context.PreemptiveRight
                .SingleOrDefaultAsync(m => m.IdPreemptiveRight == id);
            if (preemptiveRight == null)
            {
                return NotFound();
            }

            return View(preemptiveRight);
        }

        // POST: PreemptiveRights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var preemptiveRight = await _context.PreemptiveRight.SingleOrDefaultAsync(m => m.IdPreemptiveRight == id);
            _context.PreemptiveRight.Remove(preemptiveRight);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PreemptiveRightExists(int id)
        {
            return _context.PreemptiveRight.Any(e => e.IdPreemptiveRight == id);
        }
    }
}
