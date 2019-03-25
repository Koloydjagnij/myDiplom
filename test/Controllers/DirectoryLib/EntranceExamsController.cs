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
    public class EntranceExamsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EntranceExamsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EntranceExams
        public async Task<IActionResult> Index()
        {
            return View(await _context.EntranceExams.ToListAsync());
        }

        // GET: EntranceExams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entranceExams = await _context.EntranceExams
                .SingleOrDefaultAsync(m => m.IdEntranceExam == id);
            if (entranceExams == null)
            {
                return NotFound();
            }

            return View(entranceExams);
        }

        // GET: EntranceExams/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EntranceExams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEntranceExam,NameEntranceExam,Necessarily")] EntranceExams entranceExams)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entranceExams);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(entranceExams);
        }

        // GET: EntranceExams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entranceExams = await _context.EntranceExams.SingleOrDefaultAsync(m => m.IdEntranceExam == id);
            if (entranceExams == null)
            {
                return NotFound();
            }
            return View(entranceExams);
        }

        // POST: EntranceExams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEntranceExam,NameEntranceExam,Necessarily")] EntranceExams entranceExams)
        {
            if (id != entranceExams.IdEntranceExam)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entranceExams);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntranceExamsExists(entranceExams.IdEntranceExam))
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
            return View(entranceExams);
        }

        // GET: EntranceExams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entranceExams = await _context.EntranceExams
                .SingleOrDefaultAsync(m => m.IdEntranceExam == id);
            if (entranceExams == null)
            {
                return NotFound();
            }

            return View(entranceExams);
        }

        // POST: EntranceExams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entranceExams = await _context.EntranceExams.SingleOrDefaultAsync(m => m.IdEntranceExam == id);
            _context.EntranceExams.Remove(entranceExams);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntranceExamsExists(int id)
        {
            return _context.EntranceExams.Any(e => e.IdEntranceExam == id);
        }
    }
}
