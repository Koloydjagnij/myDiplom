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
    public class AppConfigsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AppConfigsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AppConfigs
        public async Task<IActionResult> Index()
        {
            return View(await _context.AppConfig.ToListAsync());
        }

        // GET: AppConfigs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appConfig = await _context.AppConfig
                .SingleOrDefaultAsync(m => m.Id == id);
            if (appConfig == null)
            {
                return NotFound();
            }

            return View(appConfig);
        }



        // GET: AppConfigs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appConfig = await _context.AppConfig.SingleOrDefaultAsync(m => m.Id == id);
            if (appConfig == null)
            {
                return NotFound();
            }
            return View(appConfig);
        }

        // POST: AppConfigs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Key,Value")] AppConfig appConfig)
        {
            if (id != appConfig.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appConfig);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppConfigExists(appConfig.Id))
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
            return View(appConfig);
        }

        

        private bool AppConfigExists(int id)
        {
            return _context.AppConfig.Any(e => e.Id == id);
        }
    }
}
