using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using test;
using test.Data;
using test.Models;

namespace test.Controllers.DirectoryLib
{
    public class ExamForSpecialitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExamForSpecialitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ExamForSpecialities
        public async Task<IActionResult> Index()
        {
            return View(await _context.Speciality.ToListAsync());
        }

        // GET: ExamForSpecialities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spec = await _context.Speciality.SingleOrDefaultAsync(m => m.IdSpeciality == id);
            ViewBag.nameSpec = spec.NameSpeciality;

            var checkedExams = from t in _context.EntranceExams
                               join p in _context.ExamForSpeciality on t.IdEntranceExam equals p.IdEntranceExam
                               where p.IdSpeciality.Equals(id)
                               select new { id = t.IdEntranceExam, name=t.NameEntranceExam, check=true};
            var uncheckedExams = from t in _context.EntranceExams
                           where !checkedExams.Any(p=>p.id==t.IdEntranceExam)
                           select new { id = t.IdEntranceExam, name = t.NameEntranceExam, check = false}; ;
            var allExams = checkedExams.Union(uncheckedExams);

            ExamCheck[] exCheck = new ExamCheck[allExams.Count()];
            int i = 0;
            foreach (var el in allExams)
            {
                exCheck[i] = new ExamCheck();
                exCheck[i].id = el.id;
                exCheck[i].name = el.name;
                exCheck[i].check = el.check;
                i++;
            }
            ViewBag.allExams = exCheck;
            return View();
        }

        // POST: ExamForSpecialities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, int[] choise)
        {
            var ids = from t in _context.ExamForSpeciality
                      where t.IdSpeciality.Equals(id)
                      select new { id_efs = t.IdExamForSpeciality,id_ex=t.IdEntranceExam };
            foreach (var el in ids)
            {
                if (!IsIncluded(el.id_ex, choise))
                {
                    var efs_for_delete = await _context.ExamForSpeciality.SingleOrDefaultAsync(m => m.IdExamForSpeciality == el.id_efs);
                    _context.ExamForSpeciality.Remove(efs_for_delete);
                    await _context.SaveChangesAsync();
                }
            }
            foreach (int el in choise)
            {
                var notExists = !(_context.ExamForSpeciality.Any(p=>(p.IdSpeciality==id)&&(p.IdEntranceExam==el)));
                if (notExists)
                {
                    ExamForSpeciality efs = new ExamForSpeciality();
                    efs.IdSpeciality = id;
                    efs.IdEntranceExam = el;
                    _context.Add(efs);
                    await _context.SaveChangesAsync();
                }
            }
            return RedirectToAction("Edit",id); 
        }
        //Проверка на включение id-шника в список id-шников
        bool IsIncluded(int id,int[] ids)
        {
            foreach (int el in ids)
            {
                if (el==id) return true;
            }
            return false;
        }
    }
}
