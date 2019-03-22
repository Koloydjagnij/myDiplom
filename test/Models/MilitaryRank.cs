using System;
using System.Collections.Generic;

namespace test
{
    public partial class MilitaryRank
    {
        public MilitaryRank()
        {
            Enrollee = new HashSet<Enrollee>();
        }

        public int IdMilitaryRank { get; set; }
        public string NameMilitaryRank { get; set; }

        public ICollection<Enrollee> Enrollee { get; set; }
    }
}
