using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using test;
using test.Data;

namespace test.Controllers.DirectoryLib
{
    public class SocialStatusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SocialStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SocialStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.SocialStatus.ToListAsync());
        }

        // GET: SocialStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socialStatus = await _context.SocialStatus
                .SingleOrDefaultAsync(m => m.IdSocialStatus == id);
            if (socialStatus == null)
            {
                return NotFound();
            }

            return View(socialStatus);
        }

        // GET: SocialStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SocialStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSocialStatus,NameSocialStatus")] SocialStatus socialStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(socialStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(socialStatus);
        }

        // GET: SocialStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socialStatus = await _context.SocialStatus.SingleOrDefaultAsync(m => m.IdSocialStatus == id);
            if (socialStatus == null)
            {
                return NotFound();
            }
            return View(socialStatus);
        }

        // POST: SocialStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSocialStatus,NameSocialStatus")] SocialStatus socialStatus)
        {
            if (id != socialStatus.IdSocialStatus)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(socialStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SocialStatusExists(socialStatus.IdSocialStatus))
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
            return View(socialStatus);
        }

        // GET: SocialStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socialStatus = await _context.SocialStatus
                .SingleOrDefaultAsync(m => m.IdSocialStatus == id);
            if (socialStatus == null)
            {
                return NotFound();
            }

            return View(socialStatus);
        }

        // POST: SocialStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var socialStatus = await _context.SocialStatus.SingleOrDefaultAsync(m => m.IdSocialStatus == id);
            _context.SocialStatus.Remove(socialStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SocialStatusExists(int id)
        {
            return _context.SocialStatus.Any(e => e.IdSocialStatus == id);
        }
    }
}
