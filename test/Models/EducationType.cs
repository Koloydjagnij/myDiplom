using System;
using System.Collections.Generic;

namespace test
{
    public partial class EducationType
    {
        public EducationType()
        {
            Enrollee = new HashSet<Enrollee>();
        }

        public int IdEducationType { get; set; }
        public string NameEducationType { get; set; }

        public ICollection<Enrollee> Enrollee { get; set; }
    }
}
