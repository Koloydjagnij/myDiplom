using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test.Views.Enrollees
{
    public class CreateViewModel
    {
        public Enrollee Enrollees { get; set; }

        //справочники
        public IEnumerable<Sex> SexList { get; set; }
        public IEnumerable<City> CityList { get; set; }
        public IEnumerable<SocialStatus> SocialStatusList { get; set; }
        public IEnumerable<FamilyType> FamilyTypeList { get; set; }
        public IEnumerable<ParentType> ParentTypeList { get; set; }
        public IEnumerable<Region> RegionList { get; set; }
        public IEnumerable<Area> AreaList { get; set; }
        public IEnumerable<FactOfProsecution> FactOfProsecutionList { get; set; }
        public IList<Family> Families { get; set; }
    }
}
