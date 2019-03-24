using System;
using System.Collections.Generic;

namespace test
{
    public partial class Region
    {
        public Region()
        {
            Area = new HashSet<Area>();
        }

        public int IdRegion { get; set; }
        public string NameRegion { get; set; }
        public int IdMilitaryDistrict { get; set; }

        public MilitaryDistrict IdMilitaryDistrictNavigation { get; set; }
        public ICollection<Area> Area { get; set; }
    }
}
