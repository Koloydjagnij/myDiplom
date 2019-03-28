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
    public class SocialBackgroundsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SocialBackgroundsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SocialBackgrounds
        public async Task<IActionResult> Index()
        {
            return View(await _context.SocialBackground.ToListAsync());
        }

        // GET: SocialBackgrounds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socialBackground = await _context.SocialBackground
                .SingleOrDefaultAsync(m => m.IdSocialBackground == id);
            if (socialBackground == null)
            {
                return NotFound();
            }

            return View(socialBackground);
        }

        // GET: SocialBackgrounds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SocialBackgrounds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSocialBackground,NameSocialBackground")] SocialBackground socialBackground)
        {
            if (ModelState.IsValid)
            {
                socialBackground.NameSocialBackground = socialBackground.NameSocialBackground.Trim();
                var any = _context.SocialBackground.Any(p => (String.Compare(p.NameSocialBackground,socialBackground.NameSocialBackground) == 0));
                if (any)
                {
                    ModelState.AddModelError("", "Данный тип социального происхождения уже зарегистрирован");
                    return View();
                }
                _context.Add(socialBackground);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(socialBackground);
        }

        // GET: SocialBackgrounds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socialBackground = await _context.SocialBackground.SingleOrDefaultAsync(m => m.IdSocialBackground == id);
            if (socialBackground == null)
            {
                return NotFound();
            }
            return View(socialBackground);
        }

        // POST: SocialBackgrounds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSocialBackground,NameSocialBackground")] SocialBackground socialBackground)
        {
            if (id != socialBackground.IdSocialBackground)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    socialBackground.NameSocialBackground = socialBackground.NameSocialBackground.Trim();
                    var any = _context.SocialBackground.Any(p => (String.Compare(p.NameSocialBackground, socialBackground.NameSocialBackground) == 0));
                    if (any)
                    {
                        ModelState.AddModelError("", "Данный тип социального происхождения уже зарегистрирован");
                        return View();
                    }
                    _context.Update(socialBackground);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SocialBackgroundExists(socialBackground.IdSocialBackground))
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
            return View(socialBackground);
        }

        // GET: SocialBackgrounds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socialBackground = await _context.SocialBackground
                .SingleOrDefaultAsync(m => m.IdSocialBackground == id);
            if (socialBackground == null)
            {
                return NotFound();
            }

            return View(socialBackground);
        }

        // POST: SocialBackgrounds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var socialBackground = await _context.SocialBackground.SingleOrDefaultAsync(m => m.IdSocialBackground == id);
            _context.SocialBackground.Remove(socialBackground);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SocialBackgroundExists(int id)
        {
            return _context.SocialBackground.Any(e => e.IdSocialBackground == id);
        }
    }
}
