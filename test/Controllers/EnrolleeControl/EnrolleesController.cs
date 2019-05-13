using System;
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
using System.IO;
using test.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.ObjectModel;
using System.Globalization;

namespace test.Controllers.EnrolleeControl
{
    public class EnumType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    [Authorize(Roles = "Admin,ListAbitur")]
    public class EnrolleesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EnrolleesController(ApplicationDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// получить список районов в выбранном регионе
        /// </summary>
        /// <param name="id"> ID региона</param>
        /// <returns></returns>
        public ActionResult GetItemsAreas(int id)
        {
            return PartialView(_context.Area.Where(c => c.IdRegion == id|| c.NameArea=="Не выбрано").ToList());
        }
        /// <summary>
        /// получиь список городов в выбранном районе
        /// </summary>

        public ActionResult GetItemsCities(int id)
        {
            return PartialView(_context.City.Where(c => c.IdArea == id|| c.NameCity=="Не выбрано").ToList());
        }

        //получаем списки для выпадающих полей
        private void GetEnumList(Enrollee enrollee)
        {
            List<EnumType> cardPPO = new List<EnumType>();
            cardPPO.Add(new EnumType { Id = 0, Name = "Не выбрано" });
            cardPPO.Add(new EnumType { Id = 1, Name = "I группа" });
            cardPPO.Add(new EnumType { Id = 2, Name = "II группа" });
            cardPPO.Add(new EnumType { Id = 3, Name = "III группа" });
            cardPPO.Add(new EnumType { Id = 4, Name = "IV группа" });
            ViewData["cardPPOType"] = new SelectList(cardPPO, "Id", "Name");

            List<EnumType> AdmitSsgt = new List<EnumType>();
            AdmitSsgt.Add(new EnumType { Id = 0, Name = "Не выбрано" });
            AdmitSsgt.Add(new EnumType { Id = 1, Name = "1 форма" });
            AdmitSsgt.Add(new EnumType { Id = 2, Name = "2 форма" });
            AdmitSsgt.Add(new EnumType { Id = 3, Name = "3 форма" });
            ViewData["AdmitSsgtType"] = new SelectList(AdmitSsgt, "Id", "Name");

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
            ViewData["IdTown"] = new SelectList(_context.City.Where(c => (c.IdArea == enrollee.IdArea || c.NameCity == "Не выбрано")).OrderBy(c => c.NameCity), "IdTown", "NameCity", enrollee.IdTown);
            ViewData["IdSocialStatus"] = new SelectList(_context.SocialStatus, "IdSocialStatus", "NameSocialStatus");
            ViewData["IdFamilyType"] = new SelectList(_context.FamilyType, "IdFamilyType", "NameFamilyType");
            ViewData["IdParentType"] = new SelectList(_context.ParentType, "IdParentType", "NameParentType");
            ViewData["IdRegion"] = new SelectList(_context.Region.OrderBy(r => r.NameRegion), "IdRegion", "NameRegion");
            ViewData["IdArea"] = new SelectList(_context.Area.Where(a => a.IdRegion == enrollee.IdRegion || a.NameArea == "Не выбрано").OrderBy(a => a.NameArea), "IdArea", "NameArea");
            ViewData["IdFirstSpec"] = new SelectList(_context.Speciality, "IdSpeciality", "NameSpeciality", enrollee.IdFirstSpec);
            ViewData["IdSecondSpec"] = new SelectList(_context.Speciality, "IdSpeciality", "NameSpeciality", enrollee.IdSecondSpec);
            ViewData["IdThirdSpec"] = new SelectList(_context.Speciality, "IdSpeciality", "NameSpeciality", enrollee.IdThirdSpec);
            ViewData["IdReserveSpec"] = new SelectList(_context.Speciality, "IdSpeciality", "NameSpeciality", enrollee.IdReserveSpec);
            ViewData["IdCurrentSpec"] = new SelectList(_context.Speciality, "IdSpeciality", "NameSpeciality", enrollee.IdCurrentSpec);
            ViewData["IdGroup"] = new SelectList(_context.Groups, "IdGroup", "GroupName", enrollee.IdGroup);

        }

        //виды сортировки
        public enum SortState
        {
            NameAsc,    // по имени по возрастанию 0
            NameDesc,   // по имени по убыванию 1

            SurnameAsc, // по фамилии по возрастанию по умолчанию 2
            SurnameDesc,    // по фамилии по убыванию 3

            GroupAsc, // по группе по возрастанию 4
            GroupDesc, // по группе по убыванию 5

            ProfNumAsc, //по номеру дела по возрастанию 6
            ProfNumDesc,// по номеру дела по убыванию 7

            EduYearAsc, // 8
            EduYearDesc,// 9 

            DateOfBirthAsc,// 10
            DateOfBirthDesc,// 11

            DateArrivedAsc,// 12
            DateArrivedDesc,// 13 

            DateDeducAsc,// 14 
            DateDeducDesc,// 15

            gpAVG_Asc,// 16 
            gpAVG_Desc,// 17

            EduTypeAsc,// 18
            EduTypeDesc,// 19

            fSpecAsc,// 20
            fSpecDesc,// 21

            cSpecAsc,// 22
            cSpecDesc,// 23

            PatrAsc,// 24
            PatrDesc// 25
        }

        /// <summary>
        /// Возвращает список абитуриентов с учетом фильтров и постраничной навигации
        /// </summary>
        /// <param name="eduType">Массив из ID типов образования для фильтрации</param>
        /// <param name="maritalStatus"></param>
        /// <param name="preemptiveRight"></param>
        /// <param name="name">Поиск по ФИО</param>
        /// <param name="page"> Номер станицы при большом количестве данных</param>
        /// <param name="sortOrder"> Способ и столбец по которому сортируем</param>
        /// <returns>Возвращает список абитуриентов с учетом фильтров и постраничной навигации</returns>
        [Authorize(Roles = "Admin,ListAbitur")]
        public async Task<IActionResult> Index(int[] groups, int[] fSpec, int[] cSpec, int[] eduType, 
            int? maritalStatus, int? preemptiveRight, string name, string NumFile,  string maxYear,DateTime? DateOfDeducMin,
            DateTime? DateOfDeducMax, DateTime? DateOfBirthMin, DateTime? DateOfBirthMax, 
            DateTime? DateOfArrivedMin, DateTime? DateOfArrivedMax,
            string minGradePoint = "0", string maxGradePoint = "500", string minYear ="1970",  int page = 1,
            SortState sortOrder = SortState.SurnameAsc, int PageViewModel_PageSize = 10)
        {


            #region SortedAndFiltratedAbitur
            ViewData["NameSort"] = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            ViewData["SurnameSort"] = sortOrder == SortState.SurnameAsc ? SortState.SurnameDesc : SortState.SurnameAsc;
            ViewData["GroupSort"] = sortOrder == SortState.GroupAsc ? SortState.GroupDesc : SortState.GroupAsc;
            ViewData["ProfNumSort"] = sortOrder == SortState.ProfNumAsc ? SortState.ProfNumDesc : SortState.ProfNumAsc;
            ViewData["PatrSort"] = sortOrder == SortState.PatrAsc ? SortState.PatrDesc : SortState.PatrAsc;
            ViewData["EduYearSort"] = sortOrder == SortState.EduYearAsc ? SortState.EduYearDesc : SortState.EduYearAsc;
            ViewData["DateOfBirthSort"] = sortOrder == SortState.DateOfBirthAsc ? SortState.DateOfBirthDesc : SortState.DateOfBirthAsc;
            ViewData["DateArrivedSort"] = sortOrder == SortState.DateArrivedAsc ? SortState.DateArrivedDesc : SortState.DateArrivedAsc;
            ViewData["DateDeducSort"] = sortOrder == SortState.DateDeducAsc ? SortState.DateDeducDesc : SortState.DateOfBirthAsc;
            ViewData["gpAVGSort"] = sortOrder == SortState.gpAVG_Asc ? SortState.gpAVG_Desc : SortState.gpAVG_Asc;
            ViewData["EduTypeSort"] = sortOrder == SortState.EduTypeAsc ? SortState.EduTypeDesc: SortState.EduTypeAsc;
            ViewData["fSpecSort"] = sortOrder == SortState.fSpecAsc ? SortState.fSpecDesc : SortState.fSpecAsc;
            ViewData["cSpecSort"] = sortOrder == SortState.cSpecAsc ? SortState.cSpecDesc : SortState.cSpecAsc;
            

            IQueryable<Enrollee> source = _context.Enrollee;

            //фильтрация 
            #region Filters      
            //по группе
            if ((groups.Length != 0 && (groups.Length == 1 && groups[0] != 0)) || (groups.Length > 1))
            {
                source = source.Where(p => Array.IndexOf(groups, p.IdGroup) >= 0);
            }
            //по первому приоритету
            if ((fSpec.Length != 0 && (fSpec.Length == 1 && fSpec[0] != 0)) || (fSpec.Length > 1))
            {
                source = source.Where(p => Array.IndexOf(fSpec, p.IdFirstSpec) >= 0);
            }
            // по текущему приоритету
            if ((cSpec.Length != 0 && (cSpec.Length == 1 && cSpec[0] != 0)) || (cSpec.Length > 1))
            {
                source = source.Where(p => Array.IndexOf(cSpec, p.IdCurrentSpec) >= 0);
            }
            // по типу образования
            if ((eduType.Length != 0 && (eduType.Length == 1 && eduType[0] != 0)) || (eduType.Length > 1))
            {
                source = source.Where(p => Array.IndexOf(eduType, p.IdEducationType)>=0);
            }
            //по семейному положению
            if (maritalStatus != null && maritalStatus != 0)
            {
                source = source.Where(p => p.IdMaritalStatus == maritalStatus);
            }
            //по преимущественным правам
            if (preemptiveRight != null && preemptiveRight != 0)
            {
                source = source.Where(p => p.IdPreemptiveRight == preemptiveRight);
            }
            //по фио
            if (!String.IsNullOrEmpty(name))
            {
                source = source.Where(p => (p.Surname+" "+p.Name+" "+p.Patronymic).ToUpper().Contains(name.ToUpper()));
            }
            //по личному делу
            if (!String.IsNullOrEmpty(NumFile))
            {
                source = source.Where(p => p.NumOfPersonalFile.Contains(NumFile.ToUpper()));
            }
            //по среднему баллу
            float minPoint = float.Parse(minGradePoint) / 100;
            float maxPoint = float.Parse(maxGradePoint) / 100;
            if (minPoint > 0 || maxPoint < 5)
            {
                source = source.Where(p => p.GradePointAVG >= minPoint && p.GradePointAVG <= maxPoint);
            }
            //по году выпуска
            if (!string.IsNullOrEmpty(maxYear)&&( Int32.Parse(minYear) > 1970 || Int32.Parse(maxYear) < DateTime.Now.Year + 5))
            {
                source = source.Where(p => p.YearOfEndingEducation.Value.Year >= Int32.Parse(minYear) && p.YearOfEndingEducation.Value.Year <= Int32.Parse(maxYear));
            }
            //по дате рождения 
            if (DateOfBirthMin != null && DateOfBirthMax != null)
            {
                source = source.Where(p => p.DateOfBirth>=DateOfBirthMin&& p.DateOfBirth<=DateOfBirthMax);
            } else if (DateOfBirthMin != null && DateOfBirthMax == null)
                    {
                         source = source.Where(p => p.DateOfBirth >= DateOfBirthMin);
                    } else if (DateOfBirthMin == null && DateOfBirthMax != null)
                            {
                                source = source.Where(p => p.DateOfBirth <= DateOfBirthMax);
                            }
            //по дате прибытия
            if (DateOfArrivedMin != null && DateOfArrivedMax != null)
            {
                source = source.Where(p => p.ArrivalDate >= DateOfArrivedMin && p.ArrivalDate <= DateOfArrivedMax);
            }
            else if (DateOfArrivedMin != null && DateOfArrivedMax == null)
            {
                source = source.Where(p => p.ArrivalDate >= DateOfArrivedMin);
            }
            else if (DateOfArrivedMin == null && DateOfBirthMax != null)
            {
                source = source.Where(p => p.ArrivalDate <= DateOfArrivedMax);
            }
            //по дате отчисления
            if (DateOfDeducMin != null && DateOfDeducMax != null)
            {
                source = source.Where(p => p.DateOfDeduction >= DateOfDeducMin && p.DateOfDeduction <= DateOfDeducMax);
            }
            else if (DateOfDeducMin != null && DateOfDeducMax == null)
            {
                source = source.Where(p => p.DateOfDeduction >= DateOfDeducMin);
            }
            else if (DateOfDeducMin == null && DateOfDeducMax != null)
            {
                source = source.Where(p => p.DateOfDeduction <= DateOfDeducMax);
            }

            #endregion
            //сортировка
            #region Sorts
            switch (sortOrder)
            {
                case SortState.EduTypeAsc:
                    source = source.OrderBy(s => s.IdEducationTypeNavigation.NameEducationType);
                    break;
                case SortState.EduTypeDesc:
                    source = source.OrderByDescending(s => s.IdEducationTypeNavigation.NameEducationType);
                    break;

                case SortState.GroupAsc:
                    source = source.OrderBy(s => s.IdGroupNavigation.GroupName);
                    break;
                case SortState.GroupDesc:
                    source = source.OrderByDescending(s => s.IdGroupNavigation.GroupName);
                    break;

                case SortState.fSpecAsc:
                    source = source.OrderBy(s => s.IdFirstSpecNavigation.NameSpeciality);
                    break;
                case SortState.fSpecDesc:
                    source = source.OrderByDescending(s => s.IdFirstSpecNavigation.NameSpeciality);
                    break;

                case SortState.cSpecAsc:
                    source = source.OrderBy(s => s.IdCurrentSpecNavigation.NameSpeciality);
                    break;
                case SortState.cSpecDesc:
                    source = source.OrderByDescending(s => s.IdCurrentSpecNavigation.NameSpeciality);
                    break;

                case SortState.EduYearAsc:
                    source = source.OrderBy(s => s.YearOfEndingEducation);
                    break;
                case SortState.EduYearDesc:
                    source = source.OrderByDescending(s => s.YearOfEndingEducation);
                    break;


                case SortState.gpAVG_Asc:
                    source = source.OrderBy(s => s.GradePointAVG);
                    break;
                case SortState.gpAVG_Desc:
                    source = source.OrderByDescending(s => s.GradePointAVG);
                    break;

                case SortState.DateArrivedAsc:
                    source = source.OrderBy(s => s.ArrivalDate);
                    break;
                case SortState.DateArrivedDesc:
                    source = source.OrderByDescending(s => s.ArrivalDate);
                    break;

                case SortState.DateDeducAsc:
                    source = source.OrderBy(s => s.DateOfDeduction);
                    break;
                case SortState.DateDeducDesc:
                    source = source.OrderByDescending(s => s.DateOfDeduction);
                    break;

                case SortState.DateOfBirthAsc:
                    source = source.OrderBy(s => s.DateOfBirth);
                    break;
                case SortState.DateOfBirthDesc:
                    source = source.OrderByDescending(s => s.DateOfBirth);
                    break;

                case SortState.NameDesc:
                    source = source.OrderByDescending(s => s.Name);
                    break;
                case SortState.NameAsc:
                    source = source.OrderBy(s => s.Name);
                    break;
                case SortState.SurnameDesc:
                    source = source.OrderByDescending(s => s.Surname);
                    break;
                case SortState.PatrAsc:
                    source = source.OrderBy(s => s.Patronymic);
                    break;
                case SortState.PatrDesc:
                    source = source.OrderByDescending(s => s.Patronymic);
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
            #endregion
            var count = await source.CountAsync();
            var items = await source.Skip((page - 1) * PageViewModel_PageSize).Take(PageViewModel_PageSize).ToListAsync();
            PageViewModel pageViewModel = new PageViewModel(count, page, PageViewModel_PageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                FilterViewModel = new FilterViewModel(_context.Groups.ToList(), groups, _context.Speciality.ToList(), 
                                    fSpec, cSpec, _context.EducationType.ToList(), eduType, _context.MaritalStatus.ToList(),
                                    maritalStatus, _context.PreemptiveRight.ToList(), preemptiveRight, name, NumFile, 
                                    Int32.Parse(minGradePoint, CultureInfo.InvariantCulture), Int32.Parse(maxGradePoint,
                                    CultureInfo.InvariantCulture), Int32.Parse(minYear), 
                                    string.IsNullOrEmpty(maxYear) ?DateTime.Now.Year+5: Int32.Parse(maxYear), DateOfDeducMin,
                                    DateOfDeducMax, DateOfBirthMin, DateOfBirthMax, DateOfArrivedMin, DateOfArrivedMax),
                SortViewModel = new SortViewModel(sortOrder),
                Enrollees = items
            };
            #endregion



            return View(viewModel);

        }

        /// <summary>
        /// Создает список всех необходимых документов
        /// </summary>
        /// <param name="enrollee">Абитуриент</param>
        private void PopulateAssignedDocumentData(Enrollee enrollee)
        {
            var allDocuments = _context.Document.Where(c=>c.NameDocument!="Не выбрано");
            var enrolleeDocuments = new HashSet<int>(enrollee.EnrolleeDocuments.Select(c => c.IdDocument));
            var viewModel = new List<AssignedDocumentData>();
            foreach (var doc in allDocuments)
            {
                viewModel.Add(new AssignedDocumentData
                {
                    DocumentId = doc.IdDocument,
                    Title = doc.NameDocument,
                    Assigned = enrolleeDocuments.Contains(doc.IdDocument)
                });
            }
            ViewBag.Documents = viewModel;
        }


        [Authorize(Roles = "Admin,FullDetailAbitur,FullDetailNotMarkAbitur")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            #region LoadRelationships
            var enrollee = await _context.Enrollee
                .Include(e => e.IdCategoryMsNavigation)
                .Include(e => e.IdEducationTypeNavigation)
                .Include(e => e.IdEducationalInstitutionNavigation)
                .Include(e => e.IdFactOfProsecutionNavigation)
                .Include(e => e.IdMaritalStatusNavigation)
                .Include(e=>e.IdFirstSpecNavigation)
                .Include(e=>e.IdSecondSpecNavigation)
                .Include(e=>e.IdThirdSpecNavigation)
                .Include(e=>e.IdReserveSpec)
                .Include(e=>e.IdGroupNavigation)
                //.Include(e => e.IdMilitaryOfficeNavigation)
                .Include(e => e.IdMilitaryRankNavigation)
                //.Include(e => e.IdMilitaryUnitNavigation)
                .Include(e => e.IdNationalityNavigation)
                .Include(e => e.IdPreemptiveRightNavigation)
                .Include(e => e.IdPreemptiveRightNavigation)
                .Include(e => e.IdReasonForDeductionNavigation)
                .Include(e => e.IdSexNavigation)
                .Include(e => e.IdSocialBackgroundNavigation)
                .Include(e => e.IdTownNavigation)
                .Include(e=>e.ChangeHistory)
                .Include(e => e.Family)
                .Include(e => e.IdTownNavigation)
                    .ThenInclude(m => m.IdAreaNavigation)
                        .ThenInclude(r => r.IdRegionNavigation)
                            .ThenInclude(mu => mu.IdMilitaryDistrictNavigation)
                .Include(f => f.Family)
                    .ThenInclude(p => p.IdFamilyTypeNavigation)
                .Include(f => f.Family)
                    .ThenInclude(f => f.IdParentNavigation)
                    .ThenInclude(f => f.IdCityNavigation)
                .Include(f => f.Family)
                    .ThenInclude(f => f.IdParentNavigation)
                    .ThenInclude(f => f.IdFactOfProsecutionNavigation)
                .Include(f => f.Family)
                    .ThenInclude(f => f.IdParentNavigation)
                    .ThenInclude(f => f.IdSexNavigation)
                .Include(f => f.Family)
                    .ThenInclude(f => f.IdParentNavigation)
                    .ThenInclude(f => f.IdSocialStatusNavigation)
                .Include(f => f.Family)
                    .ThenInclude(f => f.IdParentNavigation)
                    .ThenInclude(f => f.IdParentTypeNavigation)//добавляем семью
                .SingleOrDefaultAsync(m => m.IdEnrollee == id);
            #endregion
            var EnrolleView = new CreateViewModel();
            EnrolleView.Enrollees = enrollee;
            if (enrollee == null)
            {
                return NotFound();
            }

            return View(EnrolleView);
        }


        [Authorize(Roles = "Admin,AddAbitur")]
        public IActionResult Create()
        {
            #region LoadViewData
            List<EnumType> cardPPO = new List<EnumType>();
            cardPPO.Add(new EnumType { Id = 0, Name = "Не выбрано" });
            cardPPO.Add(new EnumType { Id = 1, Name = "I группа" });
            cardPPO.Add(new EnumType { Id = 2, Name = "II группа" });
            cardPPO.Add(new EnumType { Id = 3, Name = "III группа" });
            cardPPO.Add(new EnumType { Id = 4, Name = "IV группа" });
            ViewData["cardPPOType"] = new SelectList(cardPPO, "Id", "Name");

            List<EnumType> AdmitSsgt = new List<EnumType>();
            AdmitSsgt.Add(new EnumType { Id = 0, Name = "Не выбрано" });
            AdmitSsgt.Add(new EnumType { Id = 1, Name = "1 форма" });
            AdmitSsgt.Add(new EnumType { Id = 2, Name = "2 форма" });
            AdmitSsgt.Add(new EnumType { Id = 3, Name = "3 форма" });
            ViewData["AdmitSsgtType"] = new SelectList(AdmitSsgt, "Id", "Name");

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
            ViewData["IdFirstSpec"] = new SelectList(_context.Speciality.ToList(), "IdSpeciality", "NameSpeciality");
            ViewData["IdSecondSpec"] = new SelectList(_context.Speciality, "IdSpeciality", "NameSpeciality");
            ViewData["IdThirdSpec"] = new SelectList(_context.Speciality, "IdSpeciality", "NameSpeciality");
            ViewData["IdReserveSpec"] = new SelectList(_context.Speciality, "IdSpeciality", "NameSpeciality");
            ViewData["IdCurrentSpec"] = new SelectList(_context.Speciality, "IdSpeciality", "NameSpeciality");
            ViewData["IdGroup"] = new SelectList(_context.Groups, "IdGroup", "GroupName");

            #endregion
            var EnrolleeView = new CreateViewModel();
            EnrolleeView.SubjectMarks = _context.SubjectMark.Include(m => m.IdSubjectNavigation).ToList();
            EnrolleeView.Enrollees = new Enrollee();
            EnrolleeView.Enrollees.Family = new List<Family>();
            PopulateAssignedDocumentData(EnrolleeView.Enrollees);

            return View(EnrolleeView);
        }

        // POST: Enrollees/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,AddAbitur")]
        public async Task<IActionResult> Create(CreateViewModel createViewModel, string[] selectedDocuments )
        {
            var enrollee = createViewModel.Enrollees;
            //фиксируетсяс дата создания
            enrollee.CreatedTo = DateTime.Now;
            //gгенерируется номер личного дела
            var countLastName = _context.Enrollee.Where(m => m.Surname.Substring(0, 1).ToUpper() == enrollee.Surname.Substring(0, 1).ToUpper()).Count();
            enrollee.NumOfPersonalFile = enrollee.Surname.Substring(0, 1).ToUpper() + "-" + String.Format("{0:000}",countLastName+1);
            UpdateEnrolleeDocuments(selectedDocuments, enrollee);
            //сохраняются изменения в базе данных
            _context.Add(enrollee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            GetEnumList(enrollee);

            return View(createViewModel);
        }
        private void UpdateSubjectMark(Enrollee enrollee, int[] Enrollees_SubjectMark_IdSubject, string[] Enrollees_SubjectMark_Mark)
        {
            List<SubjectMark> sm = new List<SubjectMark>();
            var smE = _context.SubjectMark.Where(m => m.IdEnrollee == enrollee.IdEnrollee).ToList();

            int countMarkNotNull = 0;
            int sumMarkNotNull = 0;
            for (int i = 0; i < Enrollees_SubjectMark_IdSubject.Length; i++)
            {
                if (!string.IsNullOrEmpty(Enrollees_SubjectMark_Mark[i]) && Int32.Parse(Enrollees_SubjectMark_Mark[i]) > 0 && Int32.Parse(Enrollees_SubjectMark_Mark[i]) <= 5)
                {
                    countMarkNotNull++;
                    sumMarkNotNull += Int32.Parse(Enrollees_SubjectMark_Mark[i]);
                }
                if (smE.Exists(m => m.IdSubject == Enrollees_SubjectMark_IdSubject[i]))
                {

                    var item = smE.Where(m => m.IdSubject == Enrollees_SubjectMark_IdSubject[i]).FirstOrDefault();

                    item.Mark = string.IsNullOrEmpty(Enrollees_SubjectMark_Mark[i]) ? 0 : Int32.Parse(Enrollees_SubjectMark_Mark[i]);
                    //_context.SubjectMark.Update(item);
                    sm.Add(item);

                }
                else
                {
                    //sm.Add(new SubjectMark { IdEnrollee = enrollee.IdEnrollee, IdSubject = Enrollees_SubjectMark_IdSubject[i], Mark = string.IsNullOrEmpty(Enrollees_SubjectMark_Mark[i]) ? 0 : Int32.Parse(Enrollees_SubjectMark_Mark[i]) });
                    _context.SubjectMark.Add(new SubjectMark { IdEnrollee = enrollee.IdEnrollee, IdSubject = Enrollees_SubjectMark_IdSubject[i], Mark = string.IsNullOrEmpty(Enrollees_SubjectMark_Mark[i]) ? 0 : Int32.Parse(Enrollees_SubjectMark_Mark[i]) });
                }
            }

            enrollee.SubjectMark = sm;
            if (countMarkNotNull > 0) { enrollee.GradePointAVG = (float)sumMarkNotNull / (float)countMarkNotNull; }
            
        }

        [Authorize(Roles = "Admin,EditAbitur")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            #region LoadRelationships
            var enrollee = await _context.Enrollee
                .Include(e => e.IdCategoryMsNavigation)
                .Include(e => e.IdEducationTypeNavigation)
                .Include(e => e.IdEducationalInstitutionNavigation)
                .Include(e => e.IdFactOfProsecutionNavigation)
                .Include(e => e.IdMaritalStatusNavigation)
                .Include(e => e.IdFirstSpecNavigation)
                .Include(e => e.IdSecondSpecNavigation)
                .Include(e => e.IdThirdSpecNavigation)
                .Include(e => e.IdReserveSpecNavigation)
                .Include(e => e.IdGroupNavigation)
                //.Include(e => e.IdMilitaryOfficeNavigation)
                .Include(e => e.IdMilitaryRankNavigation)
                //.Include(e => e.IdMilitaryUnitNavigation)
                .Include(e => e.IdNationalityNavigation)
                .Include(e => e.IdPreemptiveRightNavigation)
                .Include(e => e.IdPreemptiveRightNavigation)
                .Include(e => e.IdReasonForDeductionNavigation)
                .Include(e => e.IdSexNavigation)
                .Include(e => e.IdSocialBackgroundNavigation)
                .Include(e => e.EnrolleeDocuments)
                .Include(e=> e.DocumentFile)
                .Include(sm=>sm.SubjectMark)
                    .ThenInclude(sm=>sm.IdSubjectNavigation)
                .Include(e=>e.ChangeHistory)
                .Include(e => e.IdTownNavigation)
                    .ThenInclude(m=>m.IdAreaNavigation)
                        .ThenInclude(r=>r.IdRegionNavigation)
                            .ThenInclude(mu=>mu.IdMilitaryDistrictNavigation)
                .Include(f => f.Family)
                    .ThenInclude(p=>p.IdFamilyTypeNavigation)
                .Include(f => f.Family)
                    .ThenInclude(f=>f.IdParentNavigation)
                    .ThenInclude(f=>f.IdCityNavigation)
                .Include(f => f.Family)
                    .ThenInclude(f => f.IdParentNavigation)
                    .ThenInclude(f => f.IdFactOfProsecutionNavigation)
                .Include(f => f.Family)
                    .ThenInclude(f => f.IdParentNavigation)
                    .ThenInclude(f => f.IdSexNavigation)
                .Include(f => f.Family)
                    .ThenInclude(f => f.IdParentNavigation)
                    .ThenInclude(f => f.IdSocialStatusNavigation)
                .Include(f => f.Family)
                    .ThenInclude(f => f.IdParentNavigation)
                    .ThenInclude(f => f.IdParentTypeNavigation)
                //добавляем семью
                .SingleOrDefaultAsync(m => m.IdEnrollee == id);
            #endregion
            PopulateAssignedDocumentData(enrollee);
            
            if (enrollee == null)
            {
                return NotFound();
            } 
            
            var EnrolleeView = new CreateViewModel();
            EnrolleeView.SubjectMarks = _context.SubjectMark.Include(m=>m.IdSubjectNavigation).Where(m => m.IdEnrollee == enrollee.IdEnrollee).ToList();
            var fullSubject = _context.Subject.ToList();
            foreach (var sub in fullSubject)
            {
                if (!EnrolleeView.SubjectMarks.Exists(s => s.IdSubject == sub.IdSubject)) {
                    EnrolleeView.SubjectMarks.Add(new SubjectMark { IdSubject = sub.IdSubject, IdEnrollee = enrollee.IdEnrollee, Mark = 0 , IdSubjectNavigation=sub});
                }
            }

            EnrolleeView.Enrollees = enrollee;
            EnrolleeView.Families = EnrolleeView.Enrollees.Family.ToList();
            EnrolleeView.SexList = _context.Sex;
            EnrolleeView.SocialStatusList = _context.SocialStatus;
            EnrolleeView.FamilyTypeList = _context.FamilyType;
            EnrolleeView.ParentTypeList = _context.ParentType;
            EnrolleeView.RegionList = _context.Region;
            EnrolleeView.AreaList = _context.Area;
            EnrolleeView.CityList = _context.City;
            EnrolleeView.FactOfProsecutionList = _context.FactOfProsecution;



            #region LoadViewData
            GetEnumList(enrollee);
            #endregion

            return View(EnrolleeView);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,EditAbitur")]
        public async Task<IActionResult> Edit(int id, CreateViewModel createViewModel, string[] selectedDocuments,
            int[] Enrollees_SubjectMark_IdSubject, string[] Enrollees_SubjectMark_Mark)
        {

            var enrollee = createViewModel.Enrollees;

            UpdateSubjectMark(enrollee, Enrollees_SubjectMark_IdSubject, Enrollees_SubjectMark_Mark);
            List<Family> FamiliesForm = new List<Family>();
            List<Parent> ParentsForm = new List<Parent>();
            UpdateEnrolleeDocuments(selectedDocuments, enrollee);
            #region LoadFiles
            if (createViewModel.Files != null)
            {
                foreach (var unloadFile in createViewModel.Files)
                {
                    byte[] imageData = null;
                    string fileName = "";
                    string fileType = "";
                    // считываем переданный файл в массив байтов
                    using (var binaryReader = new BinaryReader(unloadFile.OpenReadStream()))
                    {
                        imageData = binaryReader.ReadBytes((int)unloadFile.Length);
                        fileName = unloadFile.FileName;
                        fileType = unloadFile.ContentType;
                    }
                    // установка массива байтов
                    DocumentFile file = new DocumentFile();
                    file.File = imageData;
                    file.IdEnrollee = createViewModel.Enrollees.IdEnrollee;
                    file.NameFile = fileName;
                    file.TypeFile = fileType;
                    _context.Add(file);
                }
            }
            #endregion
            #region LoadFamilies
            //все значения с формы
            var allFamilyFields =this.Request.Form.ToArray();
            //список ключей
            var allKeys = this.Request.Form.Keys.ToArray();

            // получаем ключи на данные
            var ParentSurnameKey = Array.IndexOf(allKeys, "family.IdParentNavigation.Surname");
            var ParentNameKey = Array.IndexOf(allKeys, "family.IdParentNavigation.Name");
            var ParentPatronymicKey = Array.IndexOf(allKeys, "family.IdParentNavigation.Patronymic");
            var ParentIdSexKey = Array.IndexOf(allKeys, "family.IdParentNavigation.IdSex");
            var ParentIdFactOfProsecutionKey = Array.IndexOf(allKeys, "family.IdParentNavigation.IdFactOfProsecution");
            var IdParentKey = Array.IndexOf(allKeys, "family.IdParent");
            var IdParentTypeKey = Array.IndexOf(allKeys, "family.IdParentNavigation.IdParentType");
            var IdFamilyTypeKey = Array.IndexOf(allKeys, "family.IdFamilyType");
            var ParentIdSocialStatusKey = Array.IndexOf(allKeys, "family.IdParentNavigation.IdSocialStatus");
            var ParentIdCityKey = Array.IndexOf(allKeys, "family.IdParentNavigation.IdCity");
            var FamilyIdKey = Array.IndexOf(allKeys, "family.IdFamily");

            if (ParentSurnameKey >= 0 || ParentNameKey >= 0 || ParentPatronymicKey >= 0 || ParentIdSexKey >= 0 || ParentIdFactOfProsecutionKey >= 0
                || IdParentKey >= 0 || IdParentTypeKey >= 0 || IdFamilyTypeKey >= 0 || ParentIdSocialStatusKey >= 0 || ParentIdCityKey >= 0
                || FamilyIdKey >= 0)
            {
                // массивы данных для связанных сущностей
                var ParentSurnameArr = allFamilyFields[ParentSurnameKey].Value.ToArray();
                var ParentNameArr = allFamilyFields[ParentNameKey].Value.ToArray();
                var ParentPatronymicArr = allFamilyFields[ParentPatronymicKey].Value.ToArray();
                var ParentIdSexArr = allFamilyFields[ParentIdSexKey].Value.ToArray();
                var ParentIdFactOfProsecutionArr = allFamilyFields[ParentIdFactOfProsecutionKey].Value.ToArray();
                var IdParentArr = allFamilyFields[IdParentKey].Value.ToArray();
                var IdParentTypeArr = allFamilyFields[IdParentTypeKey].Value.ToArray();
                var IdFamilyTypeArr = allFamilyFields[IdFamilyTypeKey].Value.ToArray();
                var ParentIdSocialStatusArr = allFamilyFields[ParentIdSocialStatusKey].Value.ToArray();
                var ParentIdCityArr = allFamilyFields[ParentIdCityKey].Value.ToArray();
                var FamilyIdArr = allFamilyFields[FamilyIdKey].Value.ToArray();

                
                for (int i = 0; i < FamilyIdArr.Length; i++)
                {
                    ParentsForm.Add(new Parent { IdParent = Int32.Parse(IdParentArr[i]), Surname = ParentSurnameArr[i], Name = ParentNameArr[i], Patronymic = ParentPatronymicArr[i], IdCity = Int32.Parse(ParentIdCityArr[i]), IdSex = Int32.Parse(ParentIdSexArr[i]), IdFactOfProsecution = Int32.Parse(ParentIdFactOfProsecutionArr[i]), IdSocialStatus = Int32.Parse(ParentIdSocialStatusArr[i]), IdParentType = Int32.Parse(IdParentTypeArr[i]) });
                    FamiliesForm.Add(new Family { IdFamily = Int32.Parse(FamilyIdArr[i]), IdEnrollee = id, IdParent = Int32.Parse(IdParentArr[i]), IdFamilyType = Int32.Parse(IdFamilyTypeArr[i]), IdParentNavigation = new Parent { IdParent = Int32.Parse(IdParentArr[i]), Surname = ParentSurnameArr[i], Name = ParentNameArr[i], Patronymic = ParentPatronymicArr[i], IdCity = Int32.Parse(ParentIdCityArr[i]), IdSex = Int32.Parse(ParentIdSexArr[i]), IdFactOfProsecution = Int32.Parse(ParentIdFactOfProsecutionArr[i]), IdSocialStatus = Int32.Parse(ParentIdSocialStatusArr[i]), IdParentType = Int32.Parse(IdParentTypeArr[i]) } });
                }
                enrollee.Family = FamiliesForm;
            }
            #endregion



            if (id != enrollee.IdEnrollee)
            {
                return NotFound();
            }
            
            try
                {
                foreach (var par in ParentsForm)
                {
                    _context.Update(par);

                }
                foreach (var fam in FamiliesForm)
                {
                    _context.Update(fam);
                }


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

            GetEnumList(enrollee);

            return View(createViewModel);
        }

        //обновление связей между документами и абитуриентом
        private void UpdateEnrolleeDocuments(string[] selectedDocument, Enrollee enrolleeToUpdate)
        {
            if (selectedDocument == null)
            {
                enrolleeToUpdate.EnrolleeDocuments = new List<EnrolleeDocuments>();
                return;
            }

            //множество выбранных документов
            var selectedDocumentsHS = new HashSet<string>(selectedDocument);
            // множество уже выбранных документов
            var enrolleeDocuments = new HashSet<int>
                (_context.EnrolleeDocuments.Where(e=>e.IdEnrollee==enrolleeToUpdate.IdEnrollee).Select(c => c.IdDocument));
            foreach (var document in _context.Document)
            {
                if (selectedDocumentsHS.Contains(document.IdDocument.ToString()))
                {
                    if (!enrolleeDocuments.Contains(document.IdDocument))
                    {
                        enrolleeToUpdate.EnrolleeDocuments.Add(new EnrolleeDocuments { IdEnrollee = enrolleeToUpdate.IdEnrollee, IdDocument = document.IdDocument });
                    }
                }
                else
                {
                    if (enrolleeDocuments.Contains(document.IdDocument))
                    {
                        var ed = _context.EnrolleeDocuments.FirstOrDefault(e => e.IdEnrollee == enrolleeToUpdate.IdEnrollee && e.IdDocument == document.IdDocument);
                        _context.EnrolleeDocuments.Remove(ed);
                        //enrolleeToUpdate.EnrolleeDocuments.Remove(new EnrolleeDocuments { IdEnrollee = enrolleeToUpdate.IdEnrollee, IdDocument = document.IdDocument });
                    }
                }
            }
        }



        [Authorize(Roles = "Admin,DeleteAbitur")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            #region LoadRelationships
            var enrollee = await _context.Enrollee
                .Include(e => e.IdCategoryMsNavigation)
                .Include(e => e.IdEducationTypeNavigation)
                .Include(e => e.IdEducationalInstitutionNavigation)
                .Include(e => e.IdFactOfProsecutionNavigation)
                .Include(e => e.IdMaritalStatusNavigation)
                .Include(e => e.IdFirstSpecNavigation)
                .Include(e => e.IdSecondSpecNavigation)
                .Include(e => e.IdThirdSpecNavigation)
                .Include(e => e.IdReserveSpecNavigation)
                .Include(e => e.IdGroupNavigation)
                // .Include(e => e.IdMilitaryOfficeNavigation)
                .Include(e => e.IdMilitaryRankNavigation)
                //.Include(e => e.IdMilitaryUnitNavigation)
                .Include(e => e.IdNationalityNavigation)
                .Include(e => e.IdPreemptiveRightNavigation)
                .Include(e => e.IdReasonForDeductionNavigation)
                .Include(e => e.IdSexNavigation)
                .Include(e=>e.ChangeHistory)
                .Include(e => e.IdSocialBackgroundNavigation)
                .Include(e => e.IdTownNavigation)
                    .ThenInclude(m=>m.IdAreaNavigation)
                        .ThenInclude(r=>r.IdRegionNavigation)
                .SingleOrDefaultAsync(m => m.IdEnrollee == id);
            #endregion
            if (enrollee == null)
            {
                return NotFound();
            }

            return View(enrollee);
        }


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
        /// <summary>
        /// Загружает файл из базы в браузер для скачивания
        /// </summary>
        /// <param name="id">Id файла в базе данных</param>
        /// <returns></returns>
        public FileResult GetFile(int id)
        {
            var documentFile = _context.DocumentFile.SingleOrDefault(m => m.Id == id);
            byte[] mas = documentFile.File;
            string file_type = documentFile.TypeFile;
            string file_name = documentFile.NameFile;
            return File(mas, file_type, file_name);
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


        public async Task<IActionResult> AddFamily(int id, CreateViewModel model)
        {
            var parent = new Parent { IdParentType = 1, IdCity = 1, IdSex = 1, IdSocialStatus = 1, IdFactOfProsecution=1 };
            await _context.Parent.AddAsync(parent);
            var pId = parent.IdParent;
            var family = new Family { IdEnrollee = id, IdParent=pId, IdFamilyType=1 };
                await _context.Family.AddAsync(family);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Edit), new { id = id });// RedirectTon(nameof(Index)); 
        }

    }
}
