﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using test;
using test.Data;
using test.ViewsModels;
using test.Views.Enrollees;
using Microsoft.AspNetCore.Authorization;

namespace test.Controllers.EnrolleeControl
{
    [Authorize(Roles = "Admin,ListAbitur")]
    public class EnrolleesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EnrolleesController(ApplicationDbContext context)
        {
            _context = context;
        }
        // получить список районов в выбранном регионе
        public ActionResult GetItemsAreas(int id)
        {
            return PartialView(_context.Area.Where(c => c.IdRegion == id|| c.NameArea=="Не выбрано").ToList());
        }
        //получиь список городов в выбранном районе
        public ActionResult GetItemsCities(int id)
        {
            return PartialView(_context.City.Where(c => c.IdArea == id|| c.NameCity=="Не выбрано").ToList());
        }
        //виды сортировки
        public enum SortState
        {
            NameAsc,    // по имени по возрастанию
            NameDesc,   // по имени по убыванию
            SurnameAsc, // по фамилии по возрастанию по умолчанию
            SurnameDesc,    // по фамилии по убыванию
            GroupAsc, // по группе по возрастанию
            GroupDesc, // по группе по убыванию
            ProfNumAsc, //по номеру дела по возрастанию
            ProfNumDesc// по номеру дела по убыванию
        }

        // GET: Enrollees
        [Authorize(Roles = "Admin,ListAbitur")]
        public async Task<IActionResult> Index(int? eduType, int? maritalStatus, int? preemptiveRight, string name, int page = 1, SortState sortOrder = SortState.SurnameAsc)
        {
            ViewData["NameSort"] = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            ViewData["SurnameSort"] = sortOrder == SortState.SurnameAsc ? SortState.SurnameDesc : SortState.SurnameAsc;
            //ViewData["GroupSort"] = sortOrder == SortState.GroupAsc ? SortState.GroupDesc : SortState.GroupAsc;
            ViewData["ProfNumSort"] = sortOrder == SortState.ProfNumAsc ? SortState.ProfNumDesc : SortState.ProfNumAsc;

            int pageSize = 15;   // количество элементов на странице

            IQueryable<Enrollee> source = _context.Enrollee;

            //фильтрация 
            if (eduType != null && eduType != 0)
            {
                source = source.Where(p => p.IdEducationType == eduType);
            }
            if (maritalStatus != null && maritalStatus != 0)
            {
                source = source.Where(p => p.IdMaritalStatus == maritalStatus);
            }
            if (preemptiveRight != null && preemptiveRight != 0)
            {
                source = source.Where(p => p.IdPreemptiveRight == preemptiveRight);
            }
            if (!String.IsNullOrEmpty(name))
            {
                source = source.Where(p => (p.Surname+" "+p.Name+" "+p.Patronymic).ToUpper().Contains(name.ToUpper()));
            }

            //сортировка
            switch (sortOrder)
            {
                case SortState.NameDesc:
                    source = source.OrderByDescending(s => s.Name);
                    break;
                case SortState.NameAsc:
                    source = source.OrderBy(s => s.Name);
                    break;
                case SortState.SurnameDesc:
                    source = source.OrderByDescending(s => s.Surname);
                    break;
                case SortState.ProfNumAsc:
                    source = source.OrderBy(s => s.NumOfPersonalFile);
                    break;
                case SortState.ProfNumDesc:
                    source = source.OrderByDescending(s => s.NumOfPersonalFile);
                    break;
                default:
                    source = source.OrderBy(s => s.Surname);
                    break;
            }
            var count = await source.CountAsync();
            var items = await source.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                FilterViewModel = new FilterViewModel(_context.EducationType.ToList(), eduType, _context.MaritalStatus.ToList(), maritalStatus, _context.PreemptiveRight.ToList(), preemptiveRight, name),
                SortViewModel = new SortViewModel(sortOrder),
                Enrollees = items
            };
            return View(viewModel);

        }

        // GET: Enrollees/Details/5
        [Authorize(Roles = "Admin,FullDetailAbitur")]
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
                .Include(e => e.IdPreemptiveRightNavigation)
                .Include(e => e.IdReasonForDeductionNavigation)
                .Include(e => e.IdSexNavigation)
                .Include(e => e.IdSocialBackgroundNavigation)
                .Include(e => e.IdTownNavigation)
                .Include(e => e.Family) //добавляем семью
                .SingleOrDefaultAsync(m => m.IdEnrollee == id);

         var EnrolleView = new CreateViewModel();
            EnrolleView.Enrollees = enrollee;
            if (enrollee == null)
            {
                return NotFound();
            }

            return View(EnrolleView);
        }

        // GET: Enrollees/Create
        [Authorize(Roles = "Admin,AddAbitur")]
        public IActionResult Create()
        {
            ViewData["IdCategoryMs"] = new SelectList(_context.MilitaryServiceCategory, "IdCategoryMs", "NameCategoryMs");
            ViewData["IdEducationType"] = new SelectList(_context.EducationType, "IdEducationType", "NameEducationType");
            ViewData["IdEducationalInstitution"] = new SelectList(_context.EducationalInstitution, "IdEducationalInstitution", "NameEducationalInstitution");
            ViewData["IdFactOfProsecution"] = new SelectList(_context.FactOfProsecution, "IdFactOfProsecution", "NameFactOfProsecution");
            ViewData["IdMaritalStatus"] = new SelectList(_context.MaritalStatus, "IdMaritalStatus", "NameMaritalStatus");
            ViewData["IdMilitaryOffice"] = new SelectList(_context.MilitaryOffice, "IdMilitaryOffice", "NameMilitaryOffice");
            ViewData["IdMilitaryRank"] = new SelectList(_context.MilitaryRank, "IdMilitaryRank", "NameMilitaryRank");
            ViewData["IdMilitaryUnit"] = new SelectList(_context.MilitaryUnit, "IdMilitaryUnit", "NameMilitaryUnit");
            ViewData["IdNationality"] = new SelectList(_context.Nationality, "IdNationality", "NameNationality");
            ViewData["IdPreemptiveRight"] = new SelectList(_context.PreemptiveRight, "IdPreemptiveRight", "NamePreemptiveRight");
            ViewData["IdReasonForDeduction"] = new SelectList(_context.ReasonForDeduction, "IdReasonForDeduction", "NameReasonForDeduction");
            ViewData["IdSex"] = new SelectList(_context.Sex, "IdSex", "NameSex");
            ViewData["IdSocialBackground"] = new SelectList(_context.SocialBackground, "IdSocialBackground", "NameSocialBackground");
            ViewData["IdTown"] = new SelectList(_context.City.Where(c=>c.NameCity=="Не выбрано").OrderBy(c=>c.NameCity), "IdTown", "NameCity");
            ViewData["IdSocialStatus"] = new SelectList(_context.SocialStatus, "IdSocialStatus", "NameSocialStatus");
            ViewData["IdFamilyType"] = new SelectList(_context.FamilyType, "IdFamilyType", "NameFamilyType");
            ViewData["IdParentType"] = new SelectList(_context.ParentType, "IdParentType", "NameParentType");
            ViewData["IdRegion"] = new SelectList(_context.Region.OrderBy(r=>r.NameRegion), "IdRegion", "NameRegion");
            ViewData["IdArea"] = new SelectList(_context.Area.Where(a=>a.NameArea=="Не выбрано").OrderBy(a=>a.NameArea), "IdArea", "NameArea");

            var EnrolleeView = new CreateViewModel();
            EnrolleeView.Enrollees = new Enrollee();
            EnrolleeView.Enrollees.Family = new List<Family>();

            return View(EnrolleeView);
        }

        // POST: Enrollees/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,AddAbitur")]
        public async Task<IActionResult> Create(CreateViewModel createViewModel)
        //public async Task<IActionResult> Create([Bind("IdEnrollee,NumOfPersonalFile,Surname,Name,Patronymic,DateOfBirth,PlaceOfBirth,PassportSeries,PassportNumber,PassportIssueDate,PassportIssuedBy,PassportUnitCode,InteernationalPassport,CardPpo,AdmitSsgt,OtherNotes,ArrivalDate,LiveInCamp,DateOfDeduction,Children,IdSocialBackground,IdSex,IdMaritalStatus,IdNationality,IdPreemptiveRight,IdMilitaryOffice,IdReasonForDeduction,IdTown,IdFactOfProsecution,IdEducationalInstitution,IdEducationType,YearOfEndingEducation,NotesEducationalInstitution,PersonalNumberMs,StockPositionMs,IdMilitaryUnit,IdMilitaryRank,IdCategoryMs")] Enrollee enrollee)
        {
            var enrollee = createViewModel.Enrollees;
            enrollee.CreatedTo = DateTime.Now;
            _context.Add(enrollee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            ViewData["IdCategoryMs"] = new SelectList(_context.MilitaryServiceCategory, "IdCategoryMs", "NameCategoryMs", enrollee.IdCategoryMs);
            ViewData["IdEducationType"] = new SelectList(_context.EducationType, "IdEducationType", "NameEducationType", enrollee.IdEducationType);
            ViewData["IdEducationalInstitution"] = new SelectList(_context.EducationalInstitution, "IdEducationalInstitution", "NameEducationalInstitution", enrollee.IdEducationalInstitution);
            ViewData["IdFactOfProsecution"] = new SelectList(_context.FactOfProsecution, "IdFactOfProsecution", "NameFactOfProsecution", enrollee.IdFactOfProsecution);
            ViewData["IdMaritalStatus"] = new SelectList(_context.MaritalStatus, "IdMaritalStatus", "NameMaritalStatus", enrollee.IdMaritalStatus);
            ViewData["IdMilitaryOffice"] = new SelectList(_context.MilitaryOffice, "IdMilitaryOffice", "NameMilitaryOffice", enrollee.IdMilitaryOffice);
            ViewData["IdMilitaryRank"] = new SelectList(_context.MilitaryRank, "IdMilitaryRank", "NameMilitaryRank", enrollee.IdMilitaryRank);
            ViewData["IdMilitaryUnit"] = new SelectList(_context.MilitaryUnit, "IdMilitaryUnit", "NameMilitaryUnit", enrollee.IdMilitaryUnit);
            ViewData["IdNationality"] = new SelectList(_context.Nationality, "IdNationality", "NameNationality", enrollee.IdNationality);
            ViewData["IdPreemptiveRight"] = new SelectList(_context.PreemptiveRight, "IdPreemptiveRight", "NamePreemptiveRight", enrollee.IdPreemptiveRight);
            ViewData["IdReasonForDeduction"] = new SelectList(_context.ReasonForDeduction, "IdReasonForDeduction", "NameReasonForDeduction", enrollee.IdReasonForDeduction);
            ViewData["IdSex"] = new SelectList(_context.Sex, "IdSex", "NameSex", enrollee.IdSex);
            ViewData["IdSocialBackground"] = new SelectList(_context.SocialBackground, "IdSocialBackground", "NameSocialBackground", enrollee.IdSocialBackground);
            ViewData["IdTown"] = new SelectList(_context.City.Where(c=>c.IdArea==enrollee.IdArea||c.NameCity=="Не выбрано").OrderBy(c=>c.NameCity), "IdTown", "NameCity", enrollee.IdTown);
            ViewData["IdSocialStatus"] = new SelectList(_context.SocialStatus, "IdSocialStatus", "NameSocialStatus");
            ViewData["IdFamilyType"] = new SelectList(_context.FamilyType, "IdFamilyType", "NameFamilyType");
            ViewData["IdParentType"] = new SelectList(_context.ParentType, "IdParentType", "NameParentType");
            ViewData["IdRegion"] = new SelectList(_context.Region.OrderBy(r=>r.NameRegion), "IdRegion", "NameRegion");
            ViewData["IdArea"] = new SelectList(_context.Area.Where(a=>a.IdRegion==enrollee.IdRegion|| a.NameArea=="Не выбрано").OrderBy(a=>a.NameArea), "IdArea", "NameArea");
            return View(createViewModel);
        }

        // GET: Enrollees/Edit/5
        [Authorize(Roles = "Admin,EditAbitur")]
        public async Task<IActionResult> Edit(int? id)
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
                .Include(e => e.IdPreemptiveRightNavigation)
                .Include(e => e.IdReasonForDeductionNavigation)
                .Include(e => e.IdSexNavigation)
                .Include(e => e.IdSocialBackgroundNavigation)
                .Include(e => e.IdTownNavigation)
                    .ThenInclude(m=>m.IdAreaNavigation)
                        .ThenInclude(r=>r.IdRegionNavigation)
                .Include(e => e.Family) //добавляем семью
                .SingleOrDefaultAsync(m => m.IdEnrollee == id);
            
            
            if (enrollee == null)
            {
                return NotFound();
            } 
          
            var EnrolleeView = new CreateViewModel();
            EnrolleeView.Enrollees = enrollee;
            EnrolleeView.Families = EnrolleeView.Enrollees.Family.ToList();



            ViewData["IdCategoryMs"] = new SelectList(_context.MilitaryServiceCategory, "IdCategoryMs", "NameCategoryMs", enrollee.IdCategoryMs);
            ViewData["IdEducationType"] = new SelectList(_context.EducationType, "IdEducationType", "NameEducationType", enrollee.IdEducationType);
            ViewData["IdEducationalInstitution"] = new SelectList(_context.EducationalInstitution, "IdEducationalInstitution", "NameEducationalInstitution", enrollee.IdEducationalInstitution);
            ViewData["IdFactOfProsecution"] = new SelectList(_context.FactOfProsecution, "IdFactOfProsecution", "NameFactOfProsecution", enrollee.IdFactOfProsecution);
            ViewData["IdMaritalStatus"] = new SelectList(_context.MaritalStatus, "IdMaritalStatus", "NameMaritalStatus", enrollee.IdMaritalStatus);
            ViewData["IdMilitaryOffice"] = new SelectList(_context.MilitaryOffice, "IdMilitaryOffice", "NameMilitaryOffice", enrollee.IdMilitaryOffice);
            ViewData["IdMilitaryRank"] = new SelectList(_context.MilitaryRank, "IdMilitaryRank", "NameMilitaryRank", enrollee.IdMilitaryRank);
            ViewData["IdMilitaryUnit"] = new SelectList(_context.MilitaryUnit, "IdMilitaryUnit", "NameMilitaryUnit", enrollee.IdMilitaryUnit);
            ViewData["IdNationality"] = new SelectList(_context.Nationality, "IdNationality", "NameNationality", enrollee.IdNationality);
            ViewData["IdPreemptiveRight"] = new SelectList(_context.PreemptiveRight, "IdPreemptiveRight", "NamePreemptiveRight", enrollee.IdPreemptiveRight);
            ViewData["IdReasonForDeduction"] = new SelectList(_context.ReasonForDeduction, "IdReasonForDeduction", "NameReasonForDeduction", enrollee.IdReasonForDeduction);
            ViewData["IdSex"] = new SelectList(_context.Sex, "IdSex", "NameSex", EnrolleeView.Enrollees.IdSex);
            ViewData["IdSocialBackground"] = new SelectList(_context.SocialBackground, "IdSocialBackground", "NameSocialBackground", enrollee.IdSocialBackground);
            ViewData["IdTown"] = new SelectList(_context.City.Where(c=>c.IdArea==enrollee.IdArea||c.NameCity=="Не выбрано").OrderBy(c=>c.NameCity), "IdTown", "NameCity", enrollee.IdTown);
            ViewData["IdSocialStatus"] = new SelectList(_context.SocialStatus, "IdSocialStatus", "NameSocialStatus");
            ViewData["IdFamilyType"] = new SelectList(_context.FamilyType, "IdFamilyType", "NameFamilyType");
            ViewData["IdParentType"] = new SelectList(_context.ParentType, "IdParentType", "NameParentType");
            ViewData["IdRegion"] = new SelectList(_context.Region.OrderBy(r=>r.NameRegion), "IdRegion", "NameRegion");
            ViewData["IdArea"] = new SelectList(_context.Area.Where(a=>a.IdRegion==enrollee.IdRegion|| a.NameArea=="Не выбрано").OrderBy(a=>a.NameArea), "IdArea", "NameArea");



            return View(EnrolleeView);
        }

        // POST: Enrollees/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,EditAbitur")]
        public async Task<IActionResult> Edit(int id, [FromForm] CreateViewModel createViewModel )
        {

            var allFields = this.Request.Form.ToList();
            var allKeys = this.Request.Form.Keys.ToList();
            var familiesType = allFields.ToArray();
            var ps = familiesType[31].Value.ToArray();
            

            var enrollee = createViewModel.Enrollees;

            if (id != enrollee.IdEnrollee)
            {
                return NotFound();
            }

            
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
            
            ViewData["IdCategoryMs"] = new SelectList(_context.MilitaryServiceCategory, "IdCategoryMs", "NameCategoryMs", enrollee.IdCategoryMs);
            ViewData["IdEducationType"] = new SelectList(_context.EducationType, "IdEducationType", "NameEducationType", enrollee.IdEducationType);
            ViewData["IdEducationalInstitution"] = new SelectList(_context.EducationalInstitution, "IdEducationalInstitution", "NameEducationalInstitution", enrollee.IdEducationalInstitution);
            ViewData["IdFactOfProsecution"] = new SelectList(_context.FactOfProsecution, "IdFactOfProsecution", "NameFactOfProsecution", enrollee.IdFactOfProsecution);
            ViewData["IdMaritalStatus"] = new SelectList(_context.MaritalStatus, "IdMaritalStatus", "NameMaritalStatus", enrollee.IdMaritalStatus);
            ViewData["IdMilitaryOffice"] = new SelectList(_context.MilitaryOffice, "IdMilitaryOffice", "NameMilitaryOffice", enrollee.IdMilitaryOffice);
            ViewData["IdMilitaryRank"] = new SelectList(_context.MilitaryRank, "IdMilitaryRank", "NameMilitaryRank", enrollee.IdMilitaryRank);
            ViewData["IdMilitaryUnit"] = new SelectList(_context.MilitaryUnit, "IdMilitaryUnit", "NameMilitaryUnit", enrollee.IdMilitaryUnit);
            ViewData["IdNationality"] = new SelectList(_context.Nationality, "IdNationality", "NameNationality", enrollee.IdNationality);
            ViewData["IdPreemptiveRight"] = new SelectList(_context.PreemptiveRight, "IdPreemptiveRight", "NamePreemptiveRight", enrollee.IdPreemptiveRight);
            ViewData["IdReasonForDeduction"] = new SelectList(_context.ReasonForDeduction, "IdReasonForDeduction", "NameReasonForDeduction", enrollee.IdReasonForDeduction);
            ViewData["IdSex"] = new SelectList(_context.Sex, "IdSex", "NameSex", enrollee.IdSex);
            ViewData["IdSocialBackground"] = new SelectList(_context.SocialBackground, "IdSocialBackground", "NameSocialBackground", enrollee.IdSocialBackground);
            ViewData["IdTown"] = new SelectList(_context.City.Where(c=>(c.IdArea==enrollee.IdArea||c.NameCity=="Не выбрано")).OrderBy(c=>c.NameCity), "IdTown", "NameCity", enrollee.IdTown);
            ViewData["IdSocialStatus"] = new SelectList(_context.SocialStatus, "IdSocialStatus", "NameSocialStatus");
            ViewData["IdFamilyType"] = new SelectList(_context.FamilyType, "IdFamilyType", "NameFamilyType");
            ViewData["IdParentType"] = new SelectList(_context.ParentType, "IdParentType", "NameParentType");
            ViewData["IdRegion"] = new SelectList(_context.Region.OrderBy(r=>r.NameRegion), "IdRegion", "NameRegion");
            ViewData["IdArea"] = new SelectList(_context.Area.Where(a=>a.IdRegion==enrollee.IdRegion||a.NameArea=="Не выбрано").OrderBy(a=>a.NameArea), "IdArea", "NameArea");
            return View(createViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeFamily(Family family)
        {
            return View(family);
        }


        // GET: Enrollees/Delete/5
        [Authorize(Roles = "Admin,DeleteAbitur")]
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
                    .ThenInclude(m=>m.IdAreaNavigation)
                        .ThenInclude(r=>r.IdRegionNavigation)
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
        [Authorize(Roles = "Admin,DeleteAbitur")]
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
        
        [HttpPost, ActionName("EditFamily")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditFamily(int id)
        {
            var family = await _context.Family.SingleOrDefaultAsync(m => m.IdFamily == id);
            _context.Family.Remove(family);
            await _context.SaveChangesAsync();
            return Ok();// RedirectToAction(nameof(Index));
        }

        [HttpPost, ActionName("DeleteFmily")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteFamily(int id, int redirectId)
        {
            var family = await _context.Family.SingleOrDefaultAsync(m => m.IdFamily == id);
            if (family == null)
            {
                return NotFound();
            }
            var parent = await _context.Parent.SingleOrDefaultAsync(m => m.IdParent == family.IdParent);
            if (parent == null)
            {
                return NotFound();
            }
            _context.Parent.Remove(parent);
            _context.Family.Remove(family);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Edit), new { id = redirectId });
        }

        
        public async Task<IActionResult> AddFamily(int id)
        {
            var parent = new Parent { IdParentType = 1, IdCity = 1, IdSex = 1, IdSocialStatus = 1, IdFactOfProsecution=1 };
            await _context.Parent.AddAsync(parent);
            var pId = parent.IdParent;
            var family = new Family { IdEnrollee = id, IdParent=pId, IdFamilyType=1 };
                await _context.Family.AddAsync(family);
            await _context.SaveChangesAsync();
            
            return  RedirectToAction(nameof(Edit), new { id = id });// RedirectTon(nameof(Index)); 
        }
    }
}
