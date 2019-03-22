using System;
using System.Collections.Generic;

namespace test
{
    public partial class MilitaryDistrict
    {
        public MilitaryDistrict()
        {
            Region = new HashSet<Region>();
        }

        public int IdMilitaryDistrict { get; set; }
        public string NameMilitaryDistrict { get; set; }

        public ICollection<Region> Region { get; set; }
    }
}
