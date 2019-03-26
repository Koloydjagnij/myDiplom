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

namespace test.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cities
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.City.Include(c => c.IdAreaNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Cities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = await _context.City
                .Include(c => c.IdAreaNavigation)
                .SingleOrDefaultAsync(m => m.IdTown == id);
            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        // GET: Cities/Create
        public IActionResult Create()
        {
            ViewData["IdArea"] = new SelectList(_context.Area, "IdArea", "NameArea");
            return View();
        }

        // POST: Cities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTown,NameCity,IdArea")] City city)
        {
            if (ModelState.IsValid)
            {
                city.NameCity = city.NameCity.ToUpper().Trim();
                var anyCity = _context.City.Any(p => (string.Compare(p.NameCity, city.NameCity) == 0)&&(p.IdArea==city.IdArea));
                if (anyCity)
                {
                    ModelState.AddModelError("", "Город с таким названием  и в данном районе уже зарегистрирован");
                    ViewData["IdArea"] = new SelectList(_context.Area, "IdArea", "NameArea", city.IdArea);
                    return View(city); ;
                }
                _context.Add(city);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdArea"] = new SelectList(_context.Area, "IdArea", "NameArea", city.IdArea);
            return View(city);
        }

        private IActionResult AddErrors(string v)
        {
            throw new NotImplementedException();
        }

        // GET: Cities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = await _context.City.SingleOrDefaultAsync(m => m.IdTown == id);
            if (city == null)
            {
                return NotFound();
            }
            ViewData["IdArea"] = new SelectList(_context.Area, "IdArea", "NameArea", city.IdArea);
            return View(city);
        }

        // POST: Cities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTown,NameCity,IdArea")] City city)
        {
            if (id != city.IdTown)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    city.NameCity = city.NameCity.ToUpper().Trim();
                    var anyCity = _context.City.Any(p => (string.Compare(p.NameCity, city.NameCity) == 0) && (p.IdArea == city.IdArea));
                    if (anyCity)
                    {
                        ModelState.AddModelError("", "Город с таким названием  и в данном районе уже зарегистрирован");
                        ViewData["IdArea"] = new SelectList(_context.Area, "IdArea", "NameArea", city.IdArea);
                        return View(city); ;
                    }
                    _context.Update(city);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CityExists(city.IdTown))
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
            ViewData["IdArea"] = new SelectList(_context.Area, "IdArea", "NameArea", city.IdArea);
            return View(city);
        }

        // GET: Cities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = await _context.City
                .Include(c => c.IdAreaNavigation)
                .SingleOrDefaultAsync(m => m.IdTown == id);
            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        // POST: Cities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var city = await _context.City.SingleOrDefaultAsync(m => m.IdTown == id);
            _context.City.Remove(city);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CityExists(int id)
        {
            return _context.City.Any(e => e.IdTown == id);
        }
    }
}
