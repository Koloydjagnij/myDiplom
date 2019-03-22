using System;
using System.Collections.Generic;

namespace test
{
    public partial class Nationality
    {
        public Nationality()
        {
            Enrollee = new HashSet<Enrollee>();
        }

        public int IdNationality { get; set; }
        public string NameNationality { get; set; }

        public ICollection<Enrollee> Enrollee { get; set; }
    }
}
