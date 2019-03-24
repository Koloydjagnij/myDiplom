using System;
using System.Collections.Generic;

namespace test
{
    public partial class Enrollee
    {
        public Enrollee()
        {
            ApplicationToSpeciality = new HashSet<ApplicationToSpeciality>();
            EnrolleeAchievement = new HashSet<EnrolleeAchievement>();
            EnrolleeDocuments = new HashSet<EnrolleeDocuments>();
            Family = new HashSet<Family>();
            SubjectMark = new HashSet<SubjectMark>();
        }

        public int IdEnrollee { get; set; }
        public int? NumOfPersonalFile { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public int? PassportSeries { get; set; }
        public int? PassportNumber { get; set; }
        public DateTime? PassportIssueDate { get; set; }
        public string PassportIssuedBy { get; set; }
        public string PassportUnitCode { get; set; }
        public bool? InteernationalPassport { get; set; }
        public int? CardPpo { get; set; }
        public int? AdmitSsgt { get; set; }
        public string OtherNotes { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public bool? LiveInCamp { get; set; }
        public DateTime? DateOfDeduction { get; set; }
        public int? Children { get; set; }
        public int IdSocialBackground { get; set; }
        public int IdSex { get; set; }
        public int IdMaritalStatus { get; set; }
        public int IdNationality { get; set; }
        public int IdPreemptiveRight { get; set; }
        public int IdMilitaryOffice { get; set; }
        public int IdReasonForDeduction { get; set; }
        public int IdTown { get; set; }
        public int IdFactOfProsecution { get; set; }
        public int IdEducationalInstitution { get; set; }
        public int IdEducationType { get; set; }
        public DateTime? YearOfEndingEducation { get; set; }
        public string NotesEducationalInstitution { get; set; }
        public int? PersonalNumberMs { get; set; }
        public string StockPositionMs { get; set; }
        public int IdMilitaryUnit { get; set; }
        public int IdMilitaryRank { get; set; }
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
    }
}
