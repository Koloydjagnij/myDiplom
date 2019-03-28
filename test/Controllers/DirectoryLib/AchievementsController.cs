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
    public class AchievementsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AchievementsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Achievements
        public async Task<IActionResult> Index()
        {
            return View(await _context.Achievement.ToListAsync());
        }

        // GET: Achievements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var achievement = await _context.Achievement
                .SingleOrDefaultAsync(m => m.IdAchievement == id);
            if (achievement == null)
            {
                return NotFound();
            }

            return View(achievement);
        }

        // GET: Achievements/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Achievements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAchievement,NameAchievement")] Achievement achievement)
        {
            if (ModelState.IsValid)
            {
                achievement.NameAchievement = achievement.NameAchievement.Trim();
                var anyAchievment = _context.Achievement.Any(p=> string.Compare(p.NameAchievement,achievement.NameAchievement)==0);
                if (anyAchievment)
                {
                    ModelState.AddModelError("", "Достижение с таким названием уже зарегистрированно");
                    return View(achievement);
                }
                _context.Add(achievement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(achievement);
        }

        // GET: Achievements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var achievement = await _context.Achievement.SingleOrDefaultAsync(m => m.IdAchievement == id);
            if (achievement == null)
            {
                return NotFound();
            }
            return View(achievement);
        }

        // POST: Achievements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAchievement,NameAchievement")] Achievement achievement)
        {
            if (id != achievement.IdAchievement)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    achievement.NameAchievement = achievement.NameAchievement.Trim();
                    var anyAchievment = _context.Achievement.Any(p => string.Compare(p.NameAchievement, achievement.NameAchievement) == 0);
                    if (anyAchievment)
                    {
                        ModelState.AddModelError("", "Достижение с таким названием уже зарегистрированно");
                        return View(achievement);
                    }
                    _context.Update(achievement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AchievementExists(achievement.IdAchievement))
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
            return View(achievement);
        }

        // GET: Achievements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var achievement = await _context.Achievement
                .SingleOrDefaultAsync(m => m.IdAchievement == id);
            if (achievement == null)
            {
                return NotFound();
            }

            return View(achievement);
        }

        // POST: Achievements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var achievement = await _context.Achievement.SingleOrDefaultAsync(m => m.IdAchievement == id);
            _context.Achievement.Remove(achievement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AchievementExists(int id)
        {
            return _context.Achievement.Any(e => e.IdAchievement == id);
        }
    }
}
