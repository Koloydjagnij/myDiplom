using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using test.Data;
using test.Models;
using test.Views.Pochtas;

namespace test.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PochtasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PochtasController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult LoadAddressPochtaFromFile()
        {
            AddAppConfig.InitializAddressFromFile(_context).Wait();
            return RedirectToAction(nameof(Index));
        }

        // GET: Pochtas
        public async Task<IActionResult> Index(int page = 1)
        {
            int pageSize = 15;   // количество элементов на странице

            IQueryable<Pochta> source = _context.Pochta;//.ToListAsync();// Include(x => x.Company);
            var count = await source.CountAsync();
            var items = await source.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                Pochta = items
            };
            return View(viewModel);
        }


        // GET: Pochtas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pochta = await _context.Pochta
                .SingleOrDefaultAsync(m => m.Id == id);
            if (pochta == null)
            {
                return NotFound();
            }

            return View(pochta);
        }

        // GET: Pochtas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pochtas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Index,OPSName,OPSType,OPSSubm,Region,Autonom,Area,City,City1,ActDate,IndexOld")] Pochta pochta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pochta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pochta);
        }

        // GET: Pochtas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pochta = await _context.Pochta.SingleOrDefaultAsync(m => m.Id == id);
            if (pochta == null)
            {
                return NotFound();
            }
            return View(pochta);
        }

        // POST: Pochtas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Index,OPSName,OPSType,OPSSubm,Region,Autonom,Area,City,City1,ActDate,IndexOld")] Pochta pochta)
        {
            if (id != pochta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pochta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PochtaExists(pochta.Id))
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
            return View(pochta);
        }

        // GET: Pochtas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pochta = await _context.Pochta
                .SingleOrDefaultAsync(m => m.Id == id);
            if (pochta == null)
            {
                return NotFound();
            }

            return View(pochta);
        }

        // POST: Pochtas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pochta = await _context.Pochta.SingleOrDefaultAsync(m => m.Id == id);
            _context.Pochta.Remove(pochta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PochtaExists(int id)
        {
            return _context.Pochta.Any(e => e.Id == id);
        }
    }
}
