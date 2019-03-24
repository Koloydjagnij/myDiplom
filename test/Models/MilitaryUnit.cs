using System;
using System.Collections.Generic;

namespace test
{
    public partial class MilitaryUnit
    {
        public MilitaryUnit()
        {
            Enrollee = new HashSet<Enrollee>();
        }

        public int IdMilitaryUnit { get; set; }
        public string NameMilitaryUnit { get; set; }
        public int IdArea { get; set; }

        public Area IdAreaNavigation { get; set; }
        public ICollection<Enrollee> Enrollee { get; set; }
    }
}
