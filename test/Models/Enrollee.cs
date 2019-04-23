using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using test.Models;

namespace test
{
    public partial class Enrollee

    {
        public Enrollee()
        {
            ApplicationToSpeciality = new HashSet<ApplicationToSpeciality>();
            EnrolleeAchievement = new HashSet<EnrolleeAchievement>();
            EnrolleeDocuments = new HashSet<EnrolleeDocuments>();
            Family = new List<Family>();
            SubjectMark = new HashSet<SubjectMark>();
            DocumentFile = new List<DocumentFile>();
        }
        [Display(Name = "Запись создана")]
        [DataType(DataType.DateTime)]
        public DateTime? CreatedTo { get; set; }

        public int IdEnrollee { get; set; }
        [Display(Name = "Личное дело")]
        public virtual string PersonalFile
        {
            get { return Surname.Substring(0, 1) + "-" + NumOfPersonalFile; }
        }
        [Display(Name = "Номер личного дела")]
        public int? NumOfPersonalFile { get; set; }

        [Required]
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }

        [Required]
        [Display(Name = "Дата рождения")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [Required]
        [Display(Name = "Место рождения")]
        public string PlaceOfBirth { get; set; }

        [Display(Name = "Серия паспорта")]
        public int? PassportSeries { get; set; }

        [Display(Name = "Номер паспорта")]
        public int? PassportNumber { get; set; }

        [Display(Name = "Дата выдачи паспорта")]
        [DataType(DataType.Date)]
        public DateTime? PassportIssueDate { get; set; }

        [Display(Name = "Кем выдан")]
        public string PassportIssuedBy { get; set; }

        [Display(Name = "Код подразделени выдавшего паспорт")]
        public string PassportUnitCode { get; set; }

        [Display(Name = "Наличие загранпаспорта")]
        public bool? InteernationalPassport { get; set; }

        [Display(Name = "Карта ППО")]
        public int? CardPpo { get; set; }

        [Display(Name = "Допуск ССГТ")]
        public int? AdmitSsgt { get; set; }

        [Display(Name = "Прочие примечания")]
        public string OtherNotes { get; set; }

        [Display(Name = "Дата прибытия")]
        [DataType(DataType.Date)]
        public DateTime? ArrivalDate { get; set; }

        [Display(Name = "Проживание в лагере")]
         public bool? LiveInCamp { get; set; }

        [Display(Name = "Дата отчисления")]
        [DataType(DataType.Date)]
        public DateTime? DateOfDeduction { get; set; }

        [Display(Name = "Дети")]
        public int? Children { get; set; }

        [Display(Name = "Социальное происхождение")]
        public int IdSocialBackground { get; set; }

        [Required]
        [Display(Name = "Пол")]
        public int IdSex { get; set; }

        [Required]
        [Display(Name = "Семейное положение")]
        public int IdMaritalStatus { get; set; }

        [Display(Name = "Национальность")]
        public int IdNationality { get; set; }

        [Display(Name = "Преимущественное право")]
        public int IdPreemptiveRight { get; set; }

        [Display(Name = "Военкомат")]
        public int IdMilitaryOffice { get; set; }

        [Display(Name = "Причина отчисления")]
        public int IdReasonForDeduction { get; set; }

        [Required]
        [Display(Name = "Город")]
        public int IdTown { get; set; }

        [Required]
        [Display(Name = "Регион")]
        virtual public int IdRegion { get; set; }
        [Required]
        [Display(Name = "Район")]
        public int IdArea{ get;  set; }

        [Display(Name = "Факт привлечения к ответсвенности")]
        public int IdFactOfProsecution { get; set; }

        [Display(Name = "Учебное заведение")]
        public int IdEducationalInstitution { get; set; }

        [Display(Name = "Тип образования")]
        public int IdEducationType { get; set; }

        
        [Display(Name = "Год выпуска")]
        [DataType(DataType.Date)]
        public DateTime? YearOfEndingEducation { get; set; }

        [Display(Name = "Примечания учебное заведение")]
        public string NotesEducationalInstitution { get; set; }

        [Display(Name = "Личный номер ВС")]
        public int? PersonalNumberMs { get; set; }

        [Display(Name = "Должность запаса ВС")]
        public string StockPositionMs { get; set; }

        [Display(Name = "Военная часть")]
        public int IdMilitaryUnit { get; set; }

        [Display(Name = "Воинское звание")]
        public int IdMilitaryRank { get; set; }

        [Display(Name = "Категория ВС")]
        public int IdCategoryMs { get; set; }

        public MilitaryServiceCategory IdCategoryMsNavigation { get; set; }
        public EducationType IdEducationTypeNavigation { get; set; }
        public EducationalInstitution IdEducationalInstitutionNavigation { get; set; }
        public FactOfProsecution IdFactOfProsecutionNavigation { get; set; }
        public MaritalStatus IdMaritalStatusNavigation { get; set; }
        public MilitaryOffice IdMilitaryOfficeNavigation { get; set; }
        public MilitaryRank IdMilitaryRankNavigation { get; set; }
        public MilitaryUnit IdMilitaryUnitNavigation { get; set; }
        public Nationality IdNationalityNavigation { get; set; }
        public PreemptiveRight IdPreemptiveRightNavigation { get; set; }
        public ReasonForDeduction IdReasonForDeductionNavigation { get; set; }
        public Sex IdSexNavigation { get; set; }
        public SocialBackground IdSocialBackgroundNavigation { get; set; }
        public City IdTownNavigation { get; set; }
        public ICollection<ApplicationToSpeciality> ApplicationToSpeciality { get; set; }
        public ICollection<EnrolleeAchievement> EnrolleeAchievement { get; set; }
        public ICollection<EnrolleeDocuments> EnrolleeDocuments { get; set; }
        public ICollection<Family> Family { get; set; }
        public ICollection<SubjectMark> SubjectMark { get; set; }
        public ICollection<DocumentFile> DocumentFile { get; set; }
    }
}
