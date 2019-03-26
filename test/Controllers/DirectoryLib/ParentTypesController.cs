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
    public class ParentTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ParentTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ParentTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ParentType.ToListAsync());
        }

        // GET: ParentTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parentType = await _context.ParentType
                .SingleOrDefaultAsync(m => m.IdParentType == id);
            if (parentType == null)
            {
                return NotFound();
            }

            return View(parentType);
        }

        // GET: ParentTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ParentTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdParentType,NameParentType")] ParentType parentType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parentType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(parentType);
        }

        // GET: ParentTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parentType = await _context.ParentType.SingleOrDefaultAsync(m => m.IdParentType == id);
            if (parentType == null)
            {
                return NotFound();
            }
            return View(parentType);
        }

        // POST: ParentTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdParentType,NameParentType")] ParentType parentType)
        {
            if (id != parentType.IdParentType)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parentType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParentTypeExists(parentType.IdParentType))
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
            return View(parentType);
        }

        // GET: ParentTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parentType = await _context.ParentType
                .SingleOrDefaultAsync(m => m.IdParentType == id);
            if (parentType == null)
            {
                return NotFound();
            }

            return View(parentType);
        }

        // POST: ParentTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parentType = await _context.ParentType.SingleOrDefaultAsync(m => m.IdParentType == id);
            _context.ParentType.Remove(parentType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParentTypeExists(int id)
        {
            return _context.ParentType.Any(e => e.IdParentType == id);
        }
    }
}
