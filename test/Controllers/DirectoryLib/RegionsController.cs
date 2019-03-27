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
using test.Views.Regions;

namespace test.Controllers.DirectoryLib
{
    [Authorize(Roles = "Admin")]
    public class RegionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Regions
        public async Task<IActionResult> Index(int page = 1)
        {
            
            int pageSize = 15;   // количество элементов на странице

            IQueryable<Region> source = _context.Region.Include(r => r.IdMilitaryDistrictNavigation); 
            var count = await source.CountAsync();
            var items = await source.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                Region = items
            };
            return View(viewModel);
            

            //var applicationDbContext = _context.Region.Include(r => r.IdMilitaryDistrictNavigation);
            //return View(await applicationDbContext.ToListAsync());
        }

        // GET: Regions/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var region = await _context.Region
                .Include(r => r.IdMilitaryDistrictNavigation)
                .SingleOrDefaultAsync(m => m.IdRegion == id);
            if (region == null)
            {
                return NotFound();
            }

            return View(region);
        }

        // GET: Regions/Create
        public IActionResult Create()
        {
            ViewData["IdMilitaryDistrict"] = new SelectList(_context.MilitaryDistrict, "IdMilitaryDistrict", "NameMilitaryDistrict");
            return View();
        }

        // POST: Regions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRegion,NameRegion,IdMilitaryDistrict")] Region region)
        {
            if (ModelState.IsValid)
            {
                _context.Add(region);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMilitaryDistrict"] = new SelectList(_context.MilitaryDistrict, "IdMilitaryDistrict", "NameMilitaryDistrict", region.IdMilitaryDistrict);
            return View(region);
        }

        // GET: Regions/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var region = await _context.Region.SingleOrDefaultAsync(m => m.IdRegion == id);
            if (region == null)
            {
                return NotFound();
            }
            ViewData["IdMilitaryDistrict"] = new SelectList(_context.MilitaryDistrict, "IdMilitaryDistrict", "NameMilitaryDistrict", region.IdMilitaryDistrict);
            return View(region);
        }

        // POST: Regions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRegion,NameRegion,IdMilitaryDistrict")] Region region)
        {
            if (id != region.IdRegion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(region);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegionExists(region.IdRegion))
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
            ViewData["IdMilitaryDistrict"] = new SelectList(_context.MilitaryDistrict, "IdMilitaryDistrict", "NameMilitaryDistrict", region.IdMilitaryDistrict);
            return View(region);
        }

        // GET: Regions/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var region = await _context.Region
                .Include(r => r.IdMilitaryDistrictNavigation)
                .SingleOrDefaultAsync(m => m.IdRegion == id);
            if (region == null)
            {
                return NotFound();
            }

            return View(region);
        }

        // POST: Regions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var region = await _context.Region.SingleOrDefaultAsync(m => m.IdRegion == id);
            _context.Region.Remove(region);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegionExists(int id)
        {
            return _context.Region.Any(e => e.IdRegion == id);
        }
    }
}
