using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using test.Data;

namespace test
{
    public class AddAppConfig
    {
        public static async Task InitializAddressFromFile(ApplicationDbContext applicationDbContext)
        {
            var AP = applicationDbContext.AppConfig.Where(p => p.Key == "AddressPochtaLib").FirstOrDefault();
            var AddressPochtaLib = AP.Value;
            string sql = " copy \"Pochta\" (\"Index\",\"OPSName\", \"OPSType\",\"OPSSubm\", \"Region\",\"Autonom\",\"Area\",\"City\",\"City1\",\"IndexOld\",\"ActDate\") from \'"+AddressPochtaLib +"\' delimiter \';\' csv header";
            using (applicationDbContext)
            {
                var comps = applicationDbContext.Database.ExecuteSqlCommand(sql);
            }
        }

        public static async Task InitializAppConfig(ApplicationDbContext applicationDbContext)
        {
            
            List<AppConfig> Seting = new List<AppConfig>();
            Seting.Add(new AppConfig { Key = "SendEmail", Value = "Требуется заполнить" });
            Seting.Add(new AppConfig { Key = "EmailPassword", Value = "Требуется заполнить" });
            Seting.Add(new AppConfig { Key = "host", Value = "Требуется заполнить" });
            Seting.Add(new AppConfig { Key = "port", Value = "Требуется заполнить" });
            Seting.Add(new AppConfig { Key = "useSsl", Value = "Требуется заполнить" });
            Seting.Add(new AppConfig { Key = "Sender", Value = "Требуется заполнить" });
            Seting.Add(new AppConfig { Key = "AddressPochtaLib", Value = "Требуется заполнить" });

            foreach (var i in Seting)
                if (applicationDbContext.AppConfig.Where(p => p.Key == i.Key).FirstOrDefault() == null)
                    applicationDbContext.AppConfig.AddAsync(i);
                    applicationDbContext.SaveChanges();
        }
        public static async Task InitializDefaultValue(ApplicationDbContext applicationDbContext)
        {
            string DefValue = "Не выбрано";

            var DefMilitaryDistrict = new MilitaryDistrict { NameMilitaryDistrict = DefValue };
            if (applicationDbContext.MilitaryDistrict.Where(p => p.NameMilitaryDistrict == DefValue).FirstOrDefault() == null)
                applicationDbContext.MilitaryDistrict.AddAsync(DefMilitaryDistrict);
            applicationDbContext.SaveChanges();

            var DefMilitaryDistrictId = applicationDbContext.MilitaryDistrict.Where(p => p.NameMilitaryDistrict == DefValue).FirstOrDefault().IdMilitaryDistrict;
            var DefRegion = new Region { NameRegion = DefValue, IdMilitaryDistrict=DefMilitaryDistrictId };
                if (applicationDbContext.Region.Where(p => p.NameRegion == DefValue).FirstOrDefault() == null)
                    applicationDbContext.Region.AddAsync(DefRegion);
            applicationDbContext.SaveChanges();

            var DefRegionId = applicationDbContext.Region.Where(p => p.NameRegion == DefValue).FirstOrDefault().IdRegion;
            var DefArea = new Area { NameArea = DefValue, IdRegion=DefRegionId };
            if (applicationDbContext.Area.Where(p => p.NameArea == DefValue).FirstOrDefault() == null)
                applicationDbContext.Area.AddAsync(DefArea);
            applicationDbContext.SaveChanges();

            var DefAreaId = applicationDbContext.Area.Where(p => p.NameArea == DefValue).FirstOrDefault().IdArea;
            var DefCity = new City { NameCity = DefValue };
            if (applicationDbContext.City.Where(p => p.NameCity == DefValue).FirstOrDefault() == null)
                applicationDbContext.City.AddAsync(DefCity);
            applicationDbContext.SaveChanges();

            var DefDoc = new Document { NameDocument = DefValue };
            if (applicationDbContext.Document.Where(p => p.NameDocument == DefValue).FirstOrDefault() == null)
                applicationDbContext.Document.AddAsync(DefDoc);
            applicationDbContext.SaveChanges();

            var DefCityId = applicationDbContext.City.Where(p => p.NameCity == DefValue).FirstOrDefault().IdTown; ;
            var DefEducationalInstitution = new EducationalInstitution { NameEducationalInstitution = DefValue , IdTown=DefCityId};
            if (applicationDbContext.EducationalInstitution.Where(p => p.NameEducationalInstitution == DefValue).FirstOrDefault() == null)
                applicationDbContext.EducationalInstitution.AddAsync(DefEducationalInstitution);
            applicationDbContext.SaveChanges();

            var DefEducationType = new EducationType{ NameEducationType = DefValue};
            if (applicationDbContext.EducationType.Where(p => p.NameEducationType == DefValue).FirstOrDefault() == null)
                applicationDbContext.EducationType.AddAsync(DefEducationType);
            applicationDbContext.SaveChanges();

            var DefEntranceExams = new EntranceExams { NameEntranceExam = DefValue };
            if (applicationDbContext.EntranceExams.Where(p => p.NameEntranceExam == DefValue).FirstOrDefault() == null)
                applicationDbContext.EntranceExams.AddAsync(DefEntranceExams);
            applicationDbContext.SaveChanges();

            var DefFactOfProsecution = new FactOfProsecution { NameFactOfProsecution = DefValue };
            if (applicationDbContext.FactOfProsecution.Where(p => p.NameFactOfProsecution == DefValue).FirstOrDefault() == null)
                applicationDbContext.FactOfProsecution.AddAsync(DefFactOfProsecution);
            applicationDbContext.SaveChanges();

            var DefFamilyType = new FamilyType { NameFamilyType = DefValue };
            if (applicationDbContext.FamilyType.Where(p => p.NameFamilyType == DefValue).FirstOrDefault() == null)
                applicationDbContext.FamilyType.AddAsync(DefFamilyType);
            applicationDbContext.SaveChanges();

            var DefMaritalStatus = new MaritalStatus { NameMaritalStatus = DefValue };
            if (applicationDbContext.MaritalStatus.Where(p => p.NameMaritalStatus == DefValue).FirstOrDefault() == null)
                applicationDbContext.MaritalStatus.AddAsync(DefMaritalStatus);
            applicationDbContext.SaveChanges();

            var DefMilitaryOffice = new MilitaryOffice { NameMilitaryOffice = DefValue, IdTown=DefCityId };
            if (applicationDbContext.MilitaryOffice.Where(p => p.NameMilitaryOffice == DefValue).FirstOrDefault() == null)
                applicationDbContext.MilitaryOffice.AddAsync(DefMilitaryOffice);
            applicationDbContext.SaveChanges();

            var DefMilitaryRank = new MilitaryRank { NameMilitaryRank = DefValue };
            if (applicationDbContext.MilitaryRank.Where(p => p.NameMilitaryRank == DefValue).FirstOrDefault() == null)
                applicationDbContext.MilitaryRank.AddAsync(DefMilitaryRank);
            applicationDbContext.SaveChanges();

            var DefMilitaryServiceCategory = new MilitaryServiceCategory { NameCategoryMs = DefValue };
            if (applicationDbContext.MilitaryServiceCategory.Where(p => p.NameCategoryMs == DefValue).FirstOrDefault() == null)
                applicationDbContext.MilitaryServiceCategory.AddAsync(DefMilitaryServiceCategory);
            applicationDbContext.SaveChanges();

            var DefMilitaryUnit = new MilitaryUnit { NameMilitaryUnit = DefValue, IdArea=DefAreaId };
            if (applicationDbContext.MilitaryUnit.Where(p => p.NameMilitaryUnit == DefValue).FirstOrDefault() == null)
                applicationDbContext.MilitaryUnit.AddAsync(DefMilitaryUnit);
            applicationDbContext.SaveChanges();

            var DefNationality = new Nationality { NameNationality = DefValue };
            if (applicationDbContext.Nationality.Where(p => p.NameNationality == DefValue).FirstOrDefault() == null)
                applicationDbContext.Nationality.AddAsync(DefNationality);
            applicationDbContext.SaveChanges();

            var DefParentType = new ParentType { NameParentType = DefValue };
            if (applicationDbContext.ParentType.Where(p => p.NameParentType == DefValue).FirstOrDefault() == null)
                applicationDbContext.ParentType.AddAsync(DefParentType);
            applicationDbContext.SaveChanges();

            var DefPreemptiveRight = new PreemptiveRight { NamePreemptiveRight = DefValue };
            if (applicationDbContext.PreemptiveRight.Where(p => p.NamePreemptiveRight == DefValue).FirstOrDefault() == null)
                applicationDbContext.PreemptiveRight.AddAsync(DefPreemptiveRight);
            applicationDbContext.SaveChanges();

            var DefReasonForDeduction = new ReasonForDeduction { NameReasonForDeduction = DefValue };
            if (applicationDbContext.ReasonForDeduction.Where(p => p.NameReasonForDeduction == DefValue).FirstOrDefault() == null)
                applicationDbContext.ReasonForDeduction.AddAsync(DefReasonForDeduction);
            applicationDbContext.SaveChanges();

            List<Sex> SexList = new List<Sex>();
            SexList.Add(new Sex{ NameSex = DefValue });
            SexList.Add(new Sex { NameSex = "мужской" });
            SexList.Add(new Sex { NameSex = "женский" });
            foreach (var i in SexList)
                if (applicationDbContext.Sex.Where(p => p.NameSex == i.NameSex).FirstOrDefault() == null)
                      applicationDbContext.Sex.AddAsync(i);
            applicationDbContext.SaveChanges();

            var DefSocialBackground = new SocialBackground { NameSocialBackground = DefValue };
            if (applicationDbContext.SocialBackground.Where(p => p.NameSocialBackground == DefValue).FirstOrDefault() == null)
                applicationDbContext.SocialBackground.AddAsync(DefSocialBackground);
            applicationDbContext.SaveChanges();

            var DefSocialStatus = new SocialStatus { NameSocialStatus = DefValue };
            if (applicationDbContext.SocialStatus.Where(p => p.NameSocialStatus == DefValue).FirstOrDefault() == null)
                applicationDbContext.SocialStatus.AddAsync(DefSocialStatus);
            applicationDbContext.SaveChanges();

            var DefSpeciality = new Speciality { NameSpeciality = DefValue };
            if (applicationDbContext.Speciality.Where(p => p.NameSpeciality == DefValue).FirstOrDefault() == null)
                applicationDbContext.Speciality.AddAsync(DefSpeciality);
            applicationDbContext.SaveChanges();

            var DefSubject = new Subject { NameSubject = DefValue };
            if (applicationDbContext.Subject.Where(p => p.NameSubject == DefValue).FirstOrDefault() == null)
                applicationDbContext.Subject.AddAsync(DefSubject);
            applicationDbContext.SaveChanges();

            var DefTestType = new TestType { NameTestType = DefValue };
            if (applicationDbContext.TestType.Where(p => p.NameTestType == DefValue).FirstOrDefault() == null)
                applicationDbContext.TestType.AddAsync(DefTestType);
            applicationDbContext.SaveChanges();
        }
    }
}
