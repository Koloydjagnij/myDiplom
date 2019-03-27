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
using test.ViewsModels;
using test.Views.Areas;

namespace test.Controllers.DirectoryLib
{
    [Authorize(Roles = "Admin")]
    public class AreasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AreasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Areas
        public async Task<IActionResult> Index(int page = 1)
        {
            int pageSize = 15;   // количество элементов на странице

            IQueryable<Area> source = _context.Area.Include(a => a.IdRegionNavigation); ;//.ToListAsync();// Include(x => x.Company);
            var count = await source.CountAsync();
            var items = await source.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                Area = items
            };
            return View(viewModel);


            //var applicationDbContext = _context.Area.Include(a => a.IdRegionNavigation);
            //return View(await applicationDbContext.ToListAsync());
        }

        // GET: Areas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var area = await _context.Area
                .Include(a => a.IdRegionNavigation)
                .SingleOrDefaultAsync(m => m.IdArea == id);
            if (area == null)
            {
                return NotFound();
            }

            return View(area);
        }

        // GET: Areas/Create
        public IActionResult Create()
        {
            ViewData["IdRegion"] = new SelectList(_context.Region, "IdRegion", "NameRegion");
            return View();
        }

        // POST: Areas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdArea,NameArea,IdRegion")] Area area)
        {
            if (ModelState.IsValid)
            {
                area.NameArea = area.NameArea.ToUpper().Trim();
                var anyArea = _context.Area.Any(p => (string.Compare(p.NameArea,area.NameArea)==0)&&(p.IdRegion==area.IdRegion));
                if (anyArea)
                {
                    ModelState.AddModelError("", "Район с таким названием в данном регионе уже зарегистрирован");
                    ViewData["IdRegion"] = new SelectList(_context.Region, "IdRegion", "NameRegion", area.IdRegion);
                    return View(area);
                }
                _context.Add(area);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdRegion"] = new SelectList(_context.Region, "IdRegion", "NameRegion", area.IdRegion);
            return View(area);
        }

        // GET: Areas/Edit/5

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var area = await _context.Area.SingleOrDefaultAsync(m => m.IdArea == id);
            if (area == null)
            {
                return NotFound();
            }
            ViewData["IdRegion"] = new SelectList(_context.Region, "IdRegion", "NameRegion", area.IdRegion);
            return View(area);
        }

        // POST: Areas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdArea,NameArea,IdRegion")] Area area)
        {
            if (id != area.IdArea)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    area.NameArea = area.NameArea.ToUpper().Trim();
                    var anyArea = _context.Area.Any(p => (string.Compare(p.NameArea, area.NameArea) == 0) && (p.IdRegion == area.IdRegion));
                    if (anyArea)
                    {
                        ModelState.AddModelError("", "Район с таким названием в данном регионе уже зарегистрирован");
                        ViewData["IdRegion"] = new SelectList(_context.Region, "IdRegion", "NameRegion", area.IdRegion);
                        return View(area);
                    }
                    _context.Update(area);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AreaExists(area.IdArea))
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
            ViewData["IdRegion"] = new SelectList(_context.Region, "IdRegion", "NameRegion", area.IdRegion);
            return View(area);
        }

        // GET: Areas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var area = await _context.Area
                .Include(a => a.IdRegionNavigation)
                .SingleOrDefaultAsync(m => m.IdArea == id);
            if (area == null)
            {
                return NotFound();
            }

            return View(area);
        }

        // POST: Areas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var area = await _context.Area.SingleOrDefaultAsync(m => m.IdArea == id);
            _context.Area.Remove(area);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AreaExists(int id)
        {
            return _context.Area.Any(e => e.IdArea == id);
        }
    }
}
