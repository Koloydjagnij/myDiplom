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
using test.Views.Specialities;

namespace test.Controllers.DirectoryLib
{
    [Authorize(Roles = "Admin")]
    public class SpecialitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SpecialitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Specialities
        public async Task<IActionResult> Index()
        {
            return View(await _context.Speciality.ToListAsync());
        }
        //получаем список предметов сдаваемых на данную специальность
        private void PopulateAssignedCourseData(Speciality speciality)
        {
            var allSubject = _context.EntranceExams;
            var specialitySubject = new HashSet<int>(speciality.ExamForSpeciality.Select(c => c.IdEntranceExam));
            var viewModel = new List<AssignedSubjectData>();
            foreach (var subject in allSubject)
            {
                viewModel.Add(new AssignedSubjectData
                {
                    SubjectId = subject.IdEntranceExam,
                    Title = subject.NameEntranceExam,
                    Assigned = specialitySubject.Contains(subject.IdEntranceExam)
                });
            }
            ViewBag.Subject = viewModel;
        }
        // GET: Specialities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speciality = await _context.Speciality
                .Include(e => e.ExamForSpeciality)
                .SingleOrDefaultAsync(m => m.IdSpeciality == id);
            PopulateAssignedCourseData(speciality);
            if (speciality == null)
            {
                return NotFound();
            }

            return View(speciality);
        }

        // GET: Specialities/Create
        public IActionResult Create()
        {
            var speciality = new Speciality();
            speciality.ExamForSpeciality = new List<ExamForSpeciality>();
            PopulateAssignedCourseData(speciality);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSpeciality,NameSpeciality")] Speciality speciality, string[] selectedSubject)
        {
            if (selectedSubject != null)
            {
                speciality.ExamForSpeciality = new List<ExamForSpeciality>();
                foreach (var course in selectedSubject)
                {
                    var courseToAdd = _context.EntranceExams.Find(int.Parse(course));
                    speciality.ExamForSpeciality.Add(new ExamForSpeciality { IdSpeciality = speciality.IdSpeciality, IdEntranceExam = courseToAdd.IdEntranceExam });
                }
            }
            if (ModelState.IsValid)
            {
                _context.Add(speciality);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateAssignedCourseData(speciality);
            return View(speciality);
        }

        // GET: Specialities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speciality = await _context.Speciality
                .Include(e=> e.ExamForSpeciality)
                .SingleOrDefaultAsync(m => m.IdSpeciality == id);
            PopulateAssignedCourseData(speciality);
            if (speciality == null)
            {
                return NotFound();
            }
            return View(speciality);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSpeciality,NameSpeciality")] Speciality speciality, string[] selectedSubject)
        {
            if (id != speciality.IdSpeciality)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    UpdateSpecialitySubject(selectedSubject, speciality);
                    _context.Update(speciality);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpecialityExists(speciality.IdSpeciality))
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
            return View(speciality);
        }

        //обновление связей между предметами и  специальностью
        private void UpdateSpecialitySubject(string[] selectedSubject, Speciality specialityToUpdate)
        {
            if (selectedSubject == null)
            {
                specialityToUpdate.ExamForSpeciality = new List<ExamForSpeciality>();
                return;
            }

            //множество выбранных предметов
            var selectedCoursesHS = new HashSet<string>(selectedSubject);
            // множество 
            var specialitySubject = new HashSet<int>
                (specialityToUpdate.ExamForSpeciality.Select(c => c.IdEntranceExam));
            foreach (var subject in _context.EntranceExams)
            {
                if (selectedCoursesHS.Contains(subject.IdEntranceExam.ToString()))
                {
                    if (!specialitySubject.Contains(subject.IdEntranceExam))
                    {
                        specialityToUpdate.ExamForSpeciality.Add(new ExamForSpeciality { IdSpeciality=specialityToUpdate.IdSpeciality, IdEntranceExam=subject.IdEntranceExam});
                    }
                }
                else
                {
                    if (specialitySubject.Contains(subject.IdEntranceExam))
                    {
                        specialityToUpdate.ExamForSpeciality.Remove(new ExamForSpeciality { IdSpeciality = specialityToUpdate.IdSpeciality, IdEntranceExam = subject.IdEntranceExam });
                    }
                }
            }
        }



        // GET: Specialities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speciality = await _context.Speciality
                .SingleOrDefaultAsync(m => m.IdSpeciality == id);
            if (speciality == null)
            {
                return NotFound();
            }

            return View(speciality);
        }

        // POST: Specialities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ExDelete = _context.ExamForSpeciality.Where(m=>m.IdSpeciality==id).ToList();
            foreach (var el in ExDelete)
                _context.ExamForSpeciality.Remove(el);
            var speciality = await _context.Speciality.SingleOrDefaultAsync(m => m.IdSpeciality == id);
            _context.Speciality.Remove(speciality);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpecialityExists(int id)
        {
            return _context.Speciality.Any(e => e.IdSpeciality == id);
        }
    }
}
