using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using test.Models;

namespace test.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Achievement> Achievement { get; set; }
        public virtual DbSet<ApplicationToSpeciality> ApplicationToSpeciality { get; set; }
        public virtual DbSet<Area> Area { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Document> Document { get; set; }
        public virtual DbSet<EducationalInstitution> EducationalInstitution { get; set; }
        public virtual DbSet<EducationType> EducationType { get; set; }
        public virtual DbSet<Enrollee> Enrollee { get; set; }
        public virtual DbSet<EnrolleeAchievement> EnrolleeAchievement { get; set; }
        public virtual DbSet<EnrolleeDocuments> EnrolleeDocuments { get; set; }
        public virtual DbSet<EntranceExams> EntranceExams { get; set; }
        public virtual DbSet<ExamForSpeciality> ExamForSpeciality { get; set; }
        public virtual DbSet<FactOfProsecution> FactOfProsecution { get; set; }
        public virtual DbSet<Family> Family { get; set; }
        public virtual DbSet<FamilyType> FamilyType { get; set; }
        public virtual DbSet<MaritalStatus> MaritalStatus { get; set; }
        public virtual DbSet<MilitaryDistrict> MilitaryDistrict { get; set; }
        public virtual DbSet<MilitaryOffice> MilitaryOffice { get; set; }
        public virtual DbSet<MilitaryRank> MilitaryRank { get; set; }
        public virtual DbSet<MilitaryServiceCategory> MilitaryServiceCategory { get; set; }
        public virtual DbSet<MilitaryUnit> MilitaryUnit { get; set; }
        public virtual DbSet<Nationality> Nationality { get; set; }
        public virtual DbSet<Parent> Parent { get; set; }
        public virtual DbSet<ParentType> ParentType { get; set; }
        public virtual DbSet<PreemptiveRight> PreemptiveRight { get; set; }
        public virtual DbSet<ReasonForDeduction> ReasonForDeduction { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<Sex> Sex { get; set; }
        public virtual DbSet<SocialBackground> SocialBackground { get; set; }
        public virtual DbSet<SocialStatus> SocialStatus { get; set; }
        public virtual DbSet<Speciality> Speciality { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }
        public virtual DbSet<SubjectMark> SubjectMark { get; set; }
        public virtual DbSet<TestType> TestType { get; set; }
        public virtual DbSet<AppConfig> AppConfig { get; set; }
        public virtual DbSet<Pochta> Pochta { get; set; }
        public virtual DbSet<DocumentFile> DocumentFile { get; set; }
        public virtual DbSet<ChangeHistory> ChangeHistory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //создаем роли
            modelBuilder.Entity<ChangeHistory>(entity =>
            {
                entity.HasKey(e => e.ChangeHistoryId);

                entity.ToTable("change_history");

                entity.Property(e => e.ChangeHistoryId)
                    .HasColumnName("id_change_history")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.FieldName).HasColumnName("field_name");
                entity.Property(e => e.OldValue).HasColumnName("old_value");
                entity.Property(e => e.NewValue).HasColumnName("new_value");
                entity.Property(e => e.DateTime).HasColumnName("date_time");
                entity.Property(e => e.ChangedBy).HasColumnName("changeBy");


            });

            modelBuilder.Entity<DocumentFile>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("DocumentFile");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.IdEnrollee)
                    .IsRequired()
                    .HasColumnName("id_enrollee");

                entity.Property(e => e.NameFile).HasColumnName("NameFile");
                entity.Property(e => e.File).HasColumnName("File");

                entity.HasOne(d => d.IdEnrolleeNavigation)
                    .WithMany(p => p.DocumentFile)
                    .HasForeignKey(d => d.IdEnrollee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("EnrolleesDocuments");
            });

            base.OnModelCreating(modelBuilder);
           
            modelBuilder.Entity<Sex>()
                .Property(e => e.IdSex)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Achievement>(entity =>
            {
                entity.HasKey(e => e.IdAchievement);

                entity.ToTable("achievement");

                entity.Property(e => e.IdAchievement)
                    .HasColumnName("id_achievement")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.NameAchievement).HasColumnName("name_achievement");
            });

            modelBuilder.Entity<ApplicationToSpeciality>(entity =>
            {
                entity.Property(e => e.IdApplicationToSpeciality).ValueGeneratedOnAdd();
                entity.HasKey(e => e.IdApplicationToSpeciality);

                entity.ToTable("application_to_speciality");

                entity.Property(e => e.IdEnrollee).HasColumnName("id_enrollee");

                entity.Property(e => e.IdEntranceExam).HasColumnName("id_entrance_exam");

                entity.Property(e => e.IdSpeciality).HasColumnName("id_speciality");

                entity.Property(e => e.DateOfPassingExam)
                    .HasColumnName("date_of_passing_exam")
                    .HasColumnType("date");

                entity.Property(e => e.ExamMark).HasColumnName("exam_mark");

                entity.Property(e => e.Groupe).HasColumnName("groupe");

                entity.Property(e => e.IdTestType).HasColumnName("id_test_type");

                entity.Property(e => e.PriorityNumber).HasColumnName("priority_number");

                entity.HasOne(d => d.IdEnrolleeNavigation)
                    .WithMany(p => p.ApplicationToSpeciality)
                    .HasForeignKey(d => d.IdEnrollee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("r_41");

                entity.HasOne(d => d.IdTestTypeNavigation)
                    .WithMany(p => p.ApplicationToSpeciality)
                    .HasForeignKey(d => d.IdTestType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("r_78");

                entity.HasOne(d => d.IdExamNavigation)
                    .WithMany(p => p.ApplicationToSpeciality)
                    .HasForeignKey(d => d.IdEntranceExam)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("r_77");
            });

            modelBuilder.Entity<Area>(entity =>
            {
                entity.HasIndex(p => new { p.NameArea, p.IdRegion })
                .IsUnique(true);
                entity.HasKey(e => e.IdArea);

                entity.ToTable("area");

                entity.Property(e => e.IdArea)
                    .HasColumnName("id_area")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.IdRegion)
                    .IsRequired()
                    .HasColumnName("id_region");
                    //.HasColumnType("char(18)");

                entity.Property(e => e.NameArea).HasColumnName("name_area");

                entity.HasOne(d => d.IdRegionNavigation)
                    .WithMany(p => p.Area)
                    .HasForeignKey(d => d.IdRegion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("r_59");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasIndex(p => new { p.NameCity, p.IdArea })
                .IsUnique(true);
                entity.HasKey(e => e.IdTown);

                entity.ToTable("city");

                entity.Property(e => e.IdTown)
                    .HasColumnName("id_town")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.IdArea).HasColumnName("id_area");

                entity.Property(e => e.NameCity).HasColumnName("name_city");

                entity.HasOne(d => d.IdAreaNavigation)
                    .WithMany(p => p.City)
                    .HasForeignKey(d => d.IdArea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("r_58");
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.HasKey(e => e.IdDocument);

                entity.ToTable("document");

                entity.Property(e => e.IdDocument)
                    .HasColumnName("id_document")
                   .ValueGeneratedOnAdd();

                entity.Property(e => e.NameDocument).HasColumnName("name_document");
            });

            modelBuilder.Entity<EducationalInstitution>(entity =>
            {
                entity.HasKey(e => e.IdEducationalInstitution);

                entity.ToTable("educational_institution");

                entity.Property(e => e.IdEducationalInstitution)
                    .HasColumnName("id_educational_institution")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.IdTown).HasColumnName("id_town");

                entity.Property(e => e.NameEducationalInstitution).HasColumnName("name_educational_institution");

                entity.HasOne(d => d.IdTownNavigation)
                    .WithMany(p => p.EducationalInstitution)
                    .HasForeignKey(d => d.IdTown)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("r_55");
            });

            modelBuilder.Entity<EducationType>(entity =>
            {
                entity.HasKey(e => e.IdEducationType);

                entity.ToTable("education_type");

                entity.Property(e => e.IdEducationType)
                    .HasColumnName("id_education_type")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.NameEducationType).HasColumnName("name_education_type");
            });

            modelBuilder.Entity<Enrollee>(entity =>
            {
                entity.HasKey(e => e.IdEnrollee);

                entity.ToTable("enrollee");

                entity.Property(e => e.IdEnrollee)
                    .HasColumnName("id_enrollee")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AdmitSsgt).HasColumnName("admit_ssgt");

                entity.Property(e => e.ArrivalDate)
                    .HasColumnName("arrival_date")
                    .HasColumnType("date");

                entity.Property(e => e.CardPpo).HasColumnName("card_ppo");

                entity.Property(e => e.Children).HasColumnName("children");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnName("date_of_birth")
                    .HasColumnType("date");

                entity.Property(e => e.DateOfDeduction)
                    .HasColumnName("date_of_deduction")
                    .HasColumnType("date");

                entity.Property(e => e.IdCategoryMs).HasColumnName("id_category_ms");

                entity.Property(e => e.IdEducationType).HasColumnName("id_education_type");

                entity.Property(e => e.IdEducationalInstitution).HasColumnName("id_educational_institution");

                entity.Property(e => e.IdFactOfProsecution).HasColumnName("id_fact_of_prosecution");

                entity.Property(e => e.IdMaritalStatus).HasColumnName("id_marital_status");

                entity.Property(e => e.IdMilitaryOffice).HasColumnName("id_military_office");

                entity.Property(e => e.IdMilitaryRank).HasColumnName("id_military_rank");

                entity.Property(e => e.IdMilitaryUnit).HasColumnName("id_military_unit");

                entity.Property(e => e.IdNationality).HasColumnName("id_nationality");

                entity.Property(e => e.IdPreemptiveRight).HasColumnName("id_preemptive_right");

                entity.Property(e => e.IdReasonForDeduction).HasColumnName("id_reason_for_deduction");

                entity.Property(e => e.IdSex).HasColumnName("id_sex");

                entity.Property(e => e.IdSocialBackground).HasColumnName("id_social_background");

                entity.Property(e => e.IdTown).HasColumnName("id_town");

                entity.Property(e => e.InteernationalPassport).HasColumnName("inteernational_passport");

                entity.Property(e => e.LiveInCamp).HasColumnName("live_in_camp");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.NotesEducationalInstitution).HasColumnName("notes_educational_institution");

                entity.Property(e => e.NumOfPersonalFile).HasColumnName("num_of_personal_file");

                entity.Property(e => e.OtherNotes).HasColumnName("other_notes");

                entity.Property(e => e.PassportIssueDate)
                    .HasColumnName("passport_issue_date")
                    .HasColumnType("date");

                entity.Property(e => e.PassportIssuedBy).HasColumnName("passport_issued_by");

                entity.Property(e => e.PassportNumber).HasColumnName("passport_number");

                entity.Property(e => e.PassportSeries).HasColumnName("passport_series");

                entity.Property(e => e.PassportUnitCode).HasColumnName("passport_unit_code");

                entity.Property(e => e.Patronymic)
                    .HasColumnName("patronymic");

                entity.Property(e => e.PersonalNumberMs).HasColumnName("personal_number_ms");

                entity.Property(e => e.PlaceOfBirth).HasColumnName("place_of_birth");

                entity.Property(e => e.StockPositionMs).HasColumnName("stock_position_ms");

                entity.Property(e => e.Surname).HasColumnName("surname");

                entity.Property(e => e.YearOfEndingEducation)
                    .HasColumnName("year_of_ending_education")
                    .HasColumnType("date");

                entity.HasOne(d => d.IdCategoryMsNavigation)
                    .WithMany(p => p.Enrollee)
                    .HasForeignKey(d => d.IdCategoryMs)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("r_81");

                entity.HasOne(d => d.IdEducationTypeNavigation)
                    .WithMany(p => p.Enrollee)
                    .HasForeignKey(d => d.IdEducationType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("r_68");

                entity.HasOne(d => d.IdEducationalInstitutionNavigation)
                    .WithMany(p => p.Enrollee)
                    .HasForeignKey(d => d.IdEducationalInstitution)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("r_67");

                entity.HasOne(d => d.IdFactOfProsecutionNavigation)
                    .WithMany(p => p.Enrollee)
                    .HasForeignKey(d => d.IdFactOfProsecution)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("r_65");

                entity.HasOne(d => d.IdMaritalStatusNavigation)
                    .WithMany(p => p.Enrollee)
                    .HasForeignKey(d => d.IdMaritalStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("r_9");

                //entity.HasOne(d => d.IdMilitaryOfficeNavigation)
                //    .WithMany(p => p.Enrollee)
                //    .HasForeignKey(d => d.IdMilitaryOffice)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("r_17");

                entity.HasOne(d => d.IdMilitaryRankNavigation)
                    .WithMany(p => p.Enrollee)
                    .HasForeignKey(d => d.IdMilitaryRank)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("r_80");

                //entity.HasOne(d => d.IdMilitaryUnitNavigation)
                //    .WithMany(p => p.Enrollee)
                //    .HasForeignKey(d => d.IdMilitaryUnit)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("r_79");

                entity.HasOne(d => d.IdNationalityNavigation)
                    .WithMany(p => p.Enrollee)
                    .HasForeignKey(d => d.IdNationality)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("r_10");

                entity.HasOne(d => d.IdPreemptiveRightNavigation)
                    .WithMany(p => p.Enrollee)
                    .HasForeignKey(d => d.IdPreemptiveRight)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("r_16");

                entity.HasOne(d => d.IdReasonForDeductionNavigation)
                    .WithMany(p => p.Enrollee)
                    .HasForeignKey(d => d.IdReasonForDeduction)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("r_31");

                entity.HasOne(d => d.IdSexNavigation)
                    .WithMany(p => p.Enrollee)
                    .HasForeignKey(d => d.IdSex)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("r_8");

                entity.HasOne(d => d.IdSocialBackgroundNavigation)
                    .WithMany(p => p.Enrollee)
                    .HasForeignKey(d => d.IdSocialBackground)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("r_6");

                entity.HasOne(d => d.IdTownNavigation)
                    .WithMany(p => p.Enrollee)
                    .HasForeignKey(d => d.IdTown)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("r_52");
            });

            modelBuilder.Entity<EnrolleeAchievement>(entity =>
            {
                entity.Property(e => e.IdEnrolleeAchievement)
                .ValueGeneratedOnAdd();
                entity.HasKey(e => e.IdEnrolleeAchievement);

                entity.ToTable("enrollee_achievement");

                entity.Property(e => e.IdEnrollee).HasColumnName("id_enrollee");

                entity.Property(e => e.IdAchievement).HasColumnName("id_achievement");

                entity.Property(e => e.Priority).HasColumnName("priority");

                entity.HasOne(d => d.IdAchievementNavigation)
                    .WithMany(p => p.EnrolleeAchievement)
                    .HasForeignKey(d => d.IdAchievement)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("r_64");

                entity.HasOne(d => d.IdEnrolleeNavigation)
                    .WithMany(p => p.EnrolleeAchievement)
                    .HasForeignKey(d => d.IdEnrollee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("r_63");
            });

            modelBuilder.Entity<EnrolleeDocuments>(entity =>
            {
                entity.Property(e => e.IdEnrolleeDocument)
                .ValueGeneratedOnAdd();

                entity.HasKey(e => e.IdEnrolleeDocument);

                entity.ToTable("enrollee_documents");

                entity.Property(e => e.IdEnrollee).HasColumnName("id_enrollee");

                entity.Property(e => e.IdDocument).HasColumnName("id_document");

                entity.Property(e => e.LoadDate)
                    .HasColumnName("load_date")
                    .HasColumnType("date");

                entity.Property(e => e.PresenceInPersonalFile).HasColumnName("presence_in_personal_file");

                entity.HasOne(d => d.IdDocumentNavigation)
                    .WithMany(p => p.EnrolleeDocuments)
                    .HasForeignKey(d => d.IdDocument)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("r_72");

                entity.HasOne(d => d.IdEnrolleeNavigation)
                    .WithMany(p => p.EnrolleeDocuments)
                    .HasForeignKey(d => d.IdEnrollee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("r_71");
            });

            modelBuilder.Entity<EntranceExams>(entity =>
            {
                entity.HasKey(e => e.IdEntranceExam);

                entity.ToTable("entrance_exams");

                entity.Property(e => e.IdEntranceExam)
                    .HasColumnName("id_entrance_exam")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.NameEntranceExam).HasColumnName("name_entrance_exam");

                entity.Property(e => e.Necessarily).HasColumnName("necessarily");
            });

            modelBuilder.Entity<ExamForSpeciality>(entity =>
            {
                entity.Property(e => e.IdExamForSpeciality)
                .ValueGeneratedOnAdd();

                entity.HasKey(e => e.IdExamForSpeciality);

                entity.ToTable("exam_for_speciality");

                entity.Property(e => e.IdEntranceExam).HasColumnName("id_entrance_exam");

                entity.Property(e => e.IdSpeciality).HasColumnName("id_speciality");

                entity.HasOne(d => d.IdEntranceExamNavigation)
                    .WithMany(p => p.ExamForSpeciality)
                    .HasForeignKey(d => d.IdEntranceExam)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("r_73");

                entity.HasOne(d => d.IdSpecialityNavigation)
                    .WithMany(p => p.ExamForSpeciality)
                    .HasForeignKey(d => d.IdSpeciality)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("r_74");
            });

            modelBuilder.Entity<FactOfProsecution>(entity =>
            {
                entity.HasKey(e => e.IdFactOfProsecution);

                entity.ToTable("fact_of_prosecution");

                entity.Property(e => e.IdFactOfProsecution)
                    .HasColumnName("id_fact_of_prosecution")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.NameFactOfProsecution).HasColumnName("name_fact_of_prosecution");
            });

            modelBuilder.Entity<Family>(entity =>
            {
                entity.Property(e => e.IdFamily)
                .ValueGeneratedOnAdd();

                entity.HasKey(e => e.IdFamily);

                entity.ToTable("family");

                entity.Property(e => e.IdParent).HasColumnName("id_parent");

                entity.Property(e => e.IdEnrollee).HasColumnName("id_enrollee");

                entity.Property(e => e.IdFamilyType).HasColumnName("id_family_type");

                entity.HasOne(d => d.IdEnrolleeNavigation)
                    .WithMany(p => p.Family)
                    .HasForeignKey(d => d.IdEnrollee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("r_45");

                entity.HasOne(d => d.IdFamilyTypeNavigation)
                    .WithMany(p => p.Family)
                    .HasForeignKey(d => d.IdFamilyType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("r_1");

                entity.HasOne(d => d.IdParentNavigation)
                    .WithMany(p => p.Family)
                    .HasForeignKey(d => d.IdParent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("r_3");
            });

            modelBuilder.Entity<FamilyType>(entity =>
            {
                entity.HasKey(e => e.IdFamilyType);

                entity.ToTable("family_type");

                entity.Property(e => e.IdFamilyType)
                    .HasColumnName("id_family_type")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.NameFamilyType).HasColumnName("name_family_type");
            });

            modelBuilder.Entity<MaritalStatus>(entity =>
            {
                entity.HasKey(e => e.IdMaritalStatus);

                entity.ToTable("marital_status");

                entity.Property(e => e.IdMaritalStatus)
                    .HasColumnName("id_marital_status")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.NameMaritalStatus).HasColumnName("name_marital_status");
            });

            modelBuilder.Entity<MilitaryDistrict>(entity =>
            {
                entity.HasKey(e => e.IdMilitaryDistrict);

                entity.ToTable("military_district");

                entity.Property(e => e.IdMilitaryDistrict)
                    .HasColumnName("id_military_district")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.NameMilitaryDistrict).HasColumnName("name_military_district");
            });

            modelBuilder.Entity<MilitaryOffice>(entity =>
            {
                entity.HasKey(e => e.IdMilitaryOffice);

                entity.ToTable("military_office");

                entity.Property(e => e.IdMilitaryOffice)
                    .HasColumnName("id_military_office")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.IdTown).HasColumnName("id_town");

                entity.Property(e => e.MilitaryDistrict).HasColumnName("military_district");

                entity.Property(e => e.NameMilitaryOffice).HasColumnName("name_military_office");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.IdTownNavigation)
                    .WithMany(p => p.MilitaryOffice)
                    .HasForeignKey(d => d.IdTown)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("r_53");
            });

            modelBuilder.Entity<MilitaryRank>(entity =>
            {
                entity.HasKey(e => e.IdMilitaryRank);

                entity.ToTable("military_rank");

                entity.Property(e => e.IdMilitaryRank)
                    .HasColumnName("id_military_rank")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.NameMilitaryRank).HasColumnName("name_military_rank");
            });

            modelBuilder.Entity<MilitaryServiceCategory>(entity =>
            {
                entity.HasKey(e => e.IdCategoryMs);

                entity.ToTable("military_service_category");

                entity.Property(e => e.IdCategoryMs)
                    .HasColumnName("id_category_ms")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.NameCategoryMs).HasColumnName("name_category_ms");
            });

            modelBuilder.Entity<MilitaryUnit>(entity =>
            {
                entity.HasKey(e => e.IdMilitaryUnit);

                entity.ToTable("military_unit");

                entity.Property(e => e.IdMilitaryUnit)
                    .HasColumnName("id_military_unit")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.IdArea).HasColumnName("id_area");

                entity.Property(e => e.NameMilitaryUnit).HasColumnName("name_military_unit");

                entity.HasOne(d => d.IdAreaNavigation)
                    .WithMany(p => p.MilitaryUnit)
                    .HasForeignKey(d => d.IdArea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("r_61");
            });

            modelBuilder.Entity<Nationality>(entity =>
            {
                entity.HasKey(e => e.IdNationality);

                entity.ToTable("nationality");

                entity.Property(e => e.IdNationality)
                    .HasColumnName("id_nationality")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.NameNationality).HasColumnName("name_nationality");
            });

            modelBuilder.Entity<Parent>(entity =>
            {
                entity.HasKey(e => e.IdParent);

                entity.ToTable("parent");

                entity.Property(e => e.IdParent)
                    .HasColumnName("id_parent")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.IdCity).HasColumnName("id_city");

                entity.Property(e => e.IdFactOfProsecution).HasColumnName("id_fact_of_prosecution");

                entity.Property(e => e.IdParentType).HasColumnName("id_parent_type");

                entity.Property(e => e.IdSex).HasColumnName("id_sex");

                entity.Property(e => e.IdSocialStatus).HasColumnName("id_social_status");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Patronymic).HasColumnName("patronymic");

                entity.Property(e => e.Surname).HasColumnName("surname");

                entity.HasOne(d => d.IdCityNavigation)
                    .WithMany(p => p.Parent)
                    .HasForeignKey(d => d.IdCity)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("r_50");

                entity.HasOne(d => d.IdFactOfProsecutionNavigation)
                    .WithMany(p => p.Parent)
                    .HasForeignKey(d => d.IdFactOfProsecution)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("r_66");

                entity.HasOne(d => d.IdParentTypeNavigation)
                    .WithMany(p => p.Parent)
                    .HasForeignKey(d => d.IdParentType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("r_4");

                entity.HasOne(d => d.IdSexNavigation)
                    .WithMany(p => p.Parent)
                    .HasForeignKey(d => d.IdSex)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("r_48");

                entity.HasOne(d => d.IdSocialStatusNavigation)
                    .WithMany(p => p.Parent)
                    .HasForeignKey(d => d.IdSocialStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("r_49");
            });

            modelBuilder.Entity<ParentType>(entity =>
            {
                entity.HasKey(e => e.IdParentType);

                entity.ToTable("parent_type");

                entity.Property(e => e.IdParentType)
                    .HasColumnName("id_parent_type")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.NameParentType).HasColumnName("name_parent_type");
            });

            modelBuilder.Entity<PreemptiveRight>(entity =>
            {
                entity.HasKey(e => e.IdPreemptiveRight);

                entity.ToTable("preemptive_right");

                entity.Property(e => e.IdPreemptiveRight)
                    .HasColumnName("id_preemptive_right")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.NamePreemptiveRight).HasColumnName("name_preemptive_right");
            });

            modelBuilder.Entity<ReasonForDeduction>(entity =>
            {
                entity.HasKey(e => e.IdReasonForDeduction);

                entity.ToTable("reason_for_deduction");

                entity.Property(e => e.IdReasonForDeduction)
                    .HasColumnName("id_reason_for_deduction")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.NameReasonForDeduction).HasColumnName("name_reason_for_deduction");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.HasIndex(p => new { p.NameRegion, p.IdMilitaryDistrict })
                .IsUnique(true);
                entity.HasKey(e => e.IdRegion);

                entity.ToTable("region");

                entity.Property(e => e.IdRegion)
                    .HasColumnName("id_region")
                    //.HasColumnType("int")
                    .ValueGeneratedOnAdd(); ;

                entity.Property(e => e.IdMilitaryDistrict).HasColumnName("id_military_district");

                entity.Property(e => e.NameRegion).HasColumnName("name_region");

                entity.HasOne(d => d.IdMilitaryDistrictNavigation)
                    .WithMany(p => p.Region)
                    .HasForeignKey(d => d.IdMilitaryDistrict)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("r_60");
            });

            modelBuilder.Entity<Sex>(entity =>
            {
                entity.HasKey(e => e.IdSex);

                entity.ToTable("sex");

                entity.Property(e => e.IdSex)
                    .HasColumnName("id_sex")
                    .ValueGeneratedOnAdd();
                     //.HasColumnType("char(18)");

                entity.Property(e => e.NameSex)
                    .HasColumnName("name_sex");
                   
            });

            modelBuilder.Entity<SocialBackground>(entity =>
            {
                entity.HasKey(e => e.IdSocialBackground);

                entity.ToTable("social_background");

                entity.Property(e => e.IdSocialBackground)
                    .HasColumnName("id_social_background")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.NameSocialBackground).HasColumnName("name_social_background");
            });

            modelBuilder.Entity<SocialStatus>(entity =>
            {
                entity.HasKey(e => e.IdSocialStatus);

                entity.ToTable("social_status");

                entity.Property(e => e.IdSocialStatus)
                    .HasColumnName("id_social_status")
                    .ValueGeneratedOnAdd(); 

                entity.Property(e => e.NameSocialStatus).HasColumnName("name_social_status");
            });

            modelBuilder.Entity<Speciality>(entity =>
            {
                entity.HasKey(e => e.IdSpeciality);

                entity.ToTable("speciality");

                entity.Property(e => e.IdSpeciality)
                    .HasColumnName("id_speciality")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.NameSpeciality).HasColumnName("name_speciality");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasKey(e => e.IdSubject);

                entity.ToTable("subject");

                entity.Property(e => e.IdSubject)
                    .HasColumnName("id_subject")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.NameSubject).HasColumnName("name_subject");
            });

            modelBuilder.Entity<SubjectMark>(entity =>
            {                
                entity.HasKey(e => e.IdSubjectMark);
                           
                entity.ToTable("subject_mark");

                entity.Property(e => e.IdSubjectMark).HasColumnName("id_subject_mark").ValueGeneratedOnAdd();

                entity.Property(e => e.IdSubject).HasColumnName("id_subject");

                entity.Property(e => e.IdEnrollee).HasColumnName("id_enrollee");

                entity.Property(e => e.Mark).HasColumnName("mark");

                entity.HasOne(d => d.IdEnrolleeNavigation)
                    .WithMany(p => p.SubjectMark)
                    .HasForeignKey(d => d.IdEnrollee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("r_70");

                entity.HasOne(d => d.IdSubjectNavigation)
                    .WithMany(p => p.SubjectMark)
                    .HasForeignKey(d => d.IdSubject)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("r_35");
            });

            modelBuilder.Entity<TestType>(entity =>
            {
                entity.HasKey(e => e.IdTestType);

                entity.ToTable("test_type");

                entity.Property(e => e.IdTestType)
                    .HasColumnName("id_test_type")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.NameTestType).HasColumnName("name_test_type");
            });
            //nnnn
        }
    }
}
