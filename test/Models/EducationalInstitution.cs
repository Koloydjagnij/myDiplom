using System;
using System.Collections.Generic;

namespace test
{
    public partial class EducationalInstitution
    {
        public EducationalInstitution()
        {
            Enrollee = new HashSet<Enrollee>();
        }

        public int IdEducationalInstitution { get; set; }
        public string NameEducationalInstitution { get; set; }
        public int? IdTown { get; set; }

        public City IdTownNavigation { get; set; }
        public ICollection<Enrollee> Enrollee { get; set; }
    }
}
