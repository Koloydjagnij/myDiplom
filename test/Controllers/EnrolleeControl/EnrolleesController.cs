using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using test;
using test.Data;

namespace test.Models.ArmyVIewModel
{
    public class EnrolleesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EnrolleesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Enrollees
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Enrollee.Include(e => e.IdCategoryMsNavigation).Include(e => e.IdEducationTypeNavigation).Include(e => e.IdEducationalInstitutionNavigation).Include(e => e.IdFactOfProsecutionNavigation).Include(e => e.IdMaritalStatusNavigation).Include(e => e.IdMilitaryOfficeNavigation).Include(e => e.IdMilitaryRankNavigation).Include(e => e.IdMilitaryUnitNavigation).Include(e => e.IdNationalityNavigation).Include(e => e.IdPreemptiveRightNavigation).Include(e => e.IdReasonForDeductionNavigation).Include(e => e.IdSexNavigation).Include(e => e.IdSocialBackgroundNavigation).Include(e => e.IdTownNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Enrollees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollee = await _context.Enrollee
                .Include(e => e.IdCategoryMsNavigation)
                .Include(e => e.IdEducationTypeNavigation)
                .Include(e => e.IdEducationalInstitutionNavigation)
                .Include(e => e.IdFactOfProsecutionNavigation)
                .Include(e => e.IdMaritalStatusNavigation)
                .Include(e => e.IdMilitaryOfficeNavigation)
                .Include(e => e.IdMilitaryRankNavigation)
                .Include(e => e.IdMilitaryUnitNavigation)
                .Include(e => e.IdNationalityNavigation)
                .Include(e => e.IdPreemptiveRightNavigation)
                .Include(e => e.IdReasonForDeductionNavigation)
                .Include(e => e.IdSexNavigation)
                .Include(e => e.IdSocialBackgroundNavigation)
                .Include(e => e.IdTownNavigation)
                .SingleOrDefaultAsync(m => m.IdEnrollee == id);
            if (enrollee == null)
            {
                return NotFound();
            }

            return View(enrollee);
        }

        // GET: Enrollees/Create
        public IActionResult Create()
        {
            ViewData["IdCategoryMs"] = new SelectList(_context.MilitaryServiceCategory, "IdCategoryMs", "NameCategoryMs");
            ViewData["IdEducationType"] = new SelectList(_context.EducationType, "IdEducationType", "NameEducationType");
            ViewData["IdEducationalInstitution"] = new SelectList(_context.EducationalInstitution, "IdEducationalInstitution", "NameEducationalInstitution");
            ViewData["IdFactOfProsecution"] = new SelectList(_context.FactOfProsecution, "IdFactOfProsecution", "NameFactOfProsecution");
            ViewData["IdMaritalStatus"] = new SelectList(_context.MaritalStatus, "IdMaritalStatus", "NameMaritalStatus");
            ViewData["IdMilitaryOffice"] = new SelectList(_context.MilitaryOffice, "IdMilitaryOffice", "IdMilitaryOffice");
            ViewData["IdMilitaryRank"] = new SelectList(_context.MilitaryRank, "IdMilitaryRank", "NameMilitaryRank");
            ViewData["IdMilitaryUnit"] = new SelectList(_context.MilitaryUnit, "IdMilitaryUnit", "NameMilitaryUnit");
            ViewData["IdNationality"] = new SelectList(_context.Nationality, "IdNationality", "NameNationality");
            ViewData["IdPreemptiveRight"] = new SelectList(_context.PreemptiveRight, "IdPreemptiveRight", "NamePreemptiveRight");
            ViewData["IdReasonForDeduction"] = new SelectList(_context.ReasonForDeduction, "IdReasonForDeduction", "NameReasonForDeduction");
            ViewData["IdSex"] = new SelectList(_context.Sex, "IdSex", "NameSex");
            ViewData["IdSocialBackground"] = new SelectList(_context.SocialBackground, "IdSocialBackground", "NameSocialBackground");
            ViewData["IdTown"] = new SelectList(_context.City, "IdTown", "NameCity");
            return View();
        }

        // POST: Enrollees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEnrollee,NumOfPersonalFile,Surname,Name,Patronymic,DateOfBirth,PlaceOfBirth,PassportSeries,PassportNumber,PassportIssueDate,PassportIssuedBy,PassportUnitCode,InteernationalPassport,CardPpo,AdmitSsgt,OtherNotes,ArrivalDate,LiveInCamp,DateOfDeduction,Children,IdSocialBackground,IdSex,IdMaritalStatus,IdNationality,IdPreemptiveRight,IdMilitaryOffice,IdReasonForDeduction,IdTown,IdFactOfProsecution,IdEducationalInstitution,IdEducationType,YearOfEndingEducation,NotesEducationalInstitution,PersonalNumberMs,StockPositionMs,IdMilitaryUnit,IdMilitaryRank,IdCategoryMs")] Enrollee enrollee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enrollee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCategoryMs"] = new SelectList(_context.MilitaryServiceCategory, "IdCategoryMs", "NameCategoryMs", enrollee.IdCategoryMs);
            ViewData["IdEducationType"] = new SelectList(_context.EducationType, "IdEducationType", "NameEducationType", enrollee.IdEducationType);
            ViewData["IdEducationalInstitution"] = new SelectList(_context.EducationalInstitution, "IdEducationalInstitution", "NameEducationalInstitution", enrollee.IdEducationalInstitution);
            ViewData["IdFactOfProsecution"] = new SelectList(_context.FactOfProsecution, "IdFactOfProsecution", "NameFactOfProsecution", enrollee.IdFactOfProsecution);
            ViewData["IdMaritalStatus"] = new SelectList(_context.MaritalStatus, "IdMaritalStatus", "NameMaritalStatus", enrollee.IdMaritalStatus);
            ViewData["IdMilitaryOffice"] = new SelectList(_context.MilitaryOffice, "IdMilitaryOffice", "IdMilitaryOffice", enrollee.IdMilitaryOffice);
            ViewData["IdMilitaryRank"] = new SelectList(_context.MilitaryRank, "IdMilitaryRank", "NameMilitaryRank", enrollee.IdMilitaryRank);
            ViewData["IdMilitaryUnit"] = new SelectList(_context.MilitaryUnit, "IdMilitaryUnit", "NameMilitaryUnit", enrollee.IdMilitaryUnit);
            ViewData["IdNationality"] = new SelectList(_context.Nationality, "IdNationality", "NameNationality", enrollee.IdNationality);
            ViewData["IdPreemptiveRight"] = new SelectList(_context.PreemptiveRight, "IdPreemptiveRight", "NamePreemptiveRight", enrollee.IdPreemptiveRight);
            ViewData["IdReasonForDeduction"] = new SelectList(_context.ReasonForDeduction, "IdReasonForDeduction", "NameReasonForDeduction", enrollee.IdReasonForDeduction);
            ViewData["IdSex"] = new SelectList(_context.Sex, "IdSex", "NameSex", enrollee.IdSex);
            ViewData["IdSocialBackground"] = new SelectList(_context.SocialBackground, "IdSocialBackground", "NameSocialBackground", enrollee.IdSocialBackground);
            ViewData["IdTown"] = new SelectList(_context.City, "IdTown", "NameCity", enrollee.IdTown);
            return View(enrollee);
        }

        // GET: Enrollees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollee = await _context.Enrollee.SingleOrDefaultAsync(m => m.IdEnrollee == id);
            if (enrollee == null)
            {
                return NotFound();
            }
            ViewData["IdCategoryMs"] = new SelectList(_context.MilitaryServiceCategory, "IdCategoryMs", "NameCategoryMs", enrollee.IdCategoryMs);
            ViewData["IdEducationType"] = new SelectList(_context.EducationType, "IdEducationType", "NameEducationType", enrollee.IdEducationType);
            ViewData["IdEducationalInstitution"] = new SelectList(_context.EducationalInstitution, "IdEducationalInstitution", "NameEducationalInstitution", enrollee.IdEducationalInstitution);
            ViewData["IdFactOfProsecution"] = new SelectList(_context.FactOfProsecution, "IdFactOfProsecution", "NameFactOfProsecution", enrollee.IdFactOfProsecution);
            ViewData["IdMaritalStatus"] = new SelectList(_context.MaritalStatus, "IdMaritalStatus", "NameMaritalStatus", enrollee.IdMaritalStatus);
            ViewData["IdMilitaryOffice"] = new SelectList(_context.MilitaryOffice, "IdMilitaryOffice", "IdMilitaryOffice", enrollee.IdMilitaryOffice);
            ViewData["IdMilitaryRank"] = new SelectList(_context.MilitaryRank, "IdMilitaryRank", "NameMilitaryRank", enrollee.IdMilitaryRank);
            ViewData["IdMilitaryUnit"] = new SelectList(_context.MilitaryUnit, "IdMilitaryUnit", "NameMilitaryUnit", enrollee.IdMilitaryUnit);
            ViewData["IdNationality"] = new SelectList(_context.Nationality, "IdNationality", "NameNationality", enrollee.IdNationality);
            ViewData["IdPreemptiveRight"] = new SelectList(_context.PreemptiveRight, "IdPreemptiveRight", "NamePreemptiveRight", enrollee.IdPreemptiveRight);
            ViewData["IdReasonForDeduction"] = new SelectList(_context.ReasonForDeduction, "IdReasonForDeduction", "NameReasonForDeduction", enrollee.IdReasonForDeduction);
            ViewData["IdSex"] = new SelectList(_context.Sex, "IdSex", "NameSex", enrollee.IdSex);
            ViewData["IdSocialBackground"] = new SelectList(_context.SocialBackground, "IdSocialBackground", "NameSocialBackground", enrollee.IdSocialBackground);
            ViewData["IdTown"] = new SelectList(_context.City, "IdTown", "NameCity", enrollee.IdTown);
            return View(enrollee);
        }

        // POST: Enrollees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEnrollee,NumOfPersonalFile,Surname,Name,Patronymic,DateOfBirth,PlaceOfBirth,PassportSeries,PassportNumber,PassportIssueDate,PassportIssuedBy,PassportUnitCode,InteernationalPassport,CardPpo,AdmitSsgt,OtherNotes,ArrivalDate,LiveInCamp,DateOfDeduction,Children,IdSocialBackground,IdSex,IdMaritalStatus,IdNationality,IdPreemptiveRight,IdMilitaryOffice,IdReasonForDeduction,IdTown,IdFactOfProsecution,IdEducationalInstitution,IdEducationType,YearOfEndingEducation,NotesEducationalInstitution,PersonalNumberMs,StockPositionMs,IdMilitaryUnit,IdMilitaryRank,IdCategoryMs")] Enrollee enrollee)
        {
            if (id != enrollee.IdEnrollee)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enrollee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnrolleeExists(enrollee.IdEnrollee))
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
            ViewData["IdCategoryMs"] = new SelectList(_context.MilitaryServiceCategory, "IdCategoryMs", "NameCategoryMs", enrollee.IdCategoryMs);
            ViewData["IdEducationType"] = new SelectList(_context.EducationType, "IdEducationType", "NameEducationType", enrollee.IdEducationType);
            ViewData["IdEducationalInstitution"] = new SelectList(_context.EducationalInstitution, "IdEducationalInstitution", "NameEducationalInstitution", enrollee.IdEducationalInstitution);
            ViewData["IdFactOfProsecution"] = new SelectList(_context.FactOfProsecution, "IdFactOfProsecution", "NameFactOfProsecution", enrollee.IdFactOfProsecution);
            ViewData["IdMaritalStatus"] = new SelectList(_context.MaritalStatus, "IdMaritalStatus", "NameMaritalStatus", enrollee.IdMaritalStatus);
            ViewData["IdMilitaryOffice"] = new SelectList(_context.MilitaryOffice, "IdMilitaryOffice", "IdMilitaryOffice", enrollee.IdMilitaryOffice);
            ViewData["IdMilitaryRank"] = new SelectList(_context.MilitaryRank, "IdMilitaryRank", "NameMilitaryRank", enrollee.IdMilitaryRank);
            ViewData["IdMilitaryUnit"] = new SelectList(_context.MilitaryUnit, "IdMilitaryUnit", "NameMilitaryUnit", enrollee.IdMilitaryUnit);
            ViewData["IdNationality"] = new SelectList(_context.Nationality, "IdNationality", "NameNationality", enrollee.IdNationality);
            ViewData["IdPreemptiveRight"] = new SelectList(_context.PreemptiveRight, "IdPreemptiveRight", "NamePreemptiveRight", enrollee.IdPreemptiveRight);
            ViewData["IdReasonForDeduction"] = new SelectList(_context.ReasonForDeduction, "IdReasonForDeduction", "NameReasonForDeduction", enrollee.IdReasonForDeduction);
            ViewData["IdSex"] = new SelectList(_context.Sex, "IdSex", "NameSex", enrollee.IdSex);
            ViewData["IdSocialBackground"] = new SelectList(_context.SocialBackground, "IdSocialBackground", "NameSocialBackground", enrollee.IdSocialBackground);
            ViewData["IdTown"] = new SelectList(_context.City, "IdTown", "NameCity", enrollee.IdTown);
            return View(enrollee);
        }

        // GET: Enrollees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollee = await _context.Enrollee
                .Include(e => e.IdCategoryMsNavigation)
                .Include(e => e.IdEducationTypeNavigation)
                .Include(e => e.IdEducationalInstitutionNavigation)
                .Include(e => e.IdFactOfProsecutionNavigation)
                .Include(e => e.IdMaritalStatusNavigation)
                .Include(e => e.IdMilitaryOfficeNavigation)
                .Include(e => e.IdMilitaryRankNavigation)
                .Include(e => e.IdMilitaryUnitNavigation)
                .Include(e => e.IdNationalityNavigation)
                .Include(e => e.IdPreemptiveRightNavigation)
                .Include(e => e.IdReasonForDeductionNavigation)
                .Include(e => e.IdSexNavigation)
                .Include(e => e.IdSocialBackgroundNavigation)
                .Include(e => e.IdTownNavigation)
                .SingleOrDefaultAsync(m => m.IdEnrollee == id);
            if (enrollee == null)
            {
                return NotFound();
            }

            return View(enrollee);
        }

        // POST: Enrollees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enrollee = await _context.Enrollee.SingleOrDefaultAsync(m => m.IdEnrollee == id);
            _context.Enrollee.Remove(enrollee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnrolleeExists(int id)
        {
            return _context.Enrollee.Any(e => e.IdEnrollee == id);
        }
    }
}
