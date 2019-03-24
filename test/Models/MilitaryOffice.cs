using System;
using System.Collections.Generic;

namespace test
{
    public partial class MilitaryOffice
    {
        public MilitaryOffice()
        {
            Enrollee = new HashSet<Enrollee>();
        }

        public int IdMilitaryOffice { get; set; }
        public string MilitaryDistrict { get; set; }
        public string Status { get; set; }
        public string NameMilitaryOffice { get; set; }
        public int IdTown { get; set; }

        public City IdTownNavigation { get; set; }
        public ICollection<Enrollee> Enrollee { get; set; }
    }
}
