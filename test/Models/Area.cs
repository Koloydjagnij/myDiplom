using System;
using System.Collections.Generic;

namespace test
{
    public partial class Area
    {
        public Area()
        {
            City = new HashSet<City>();
            MilitaryUnit = new HashSet<MilitaryUnit>();
        }

        public int IdArea { get; set; }
        public string NameArea { get; set; }
        public int? IdRegion { get; set; }

        public Region IdRegionNavigation { get; set; }
        public ICollection<City> City { get; set; }
        public ICollection<MilitaryUnit> MilitaryUnit { get; set; }
    }
}
