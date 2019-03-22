using System;
using System.Collections.Generic;

namespace test
{
    public partial class MaritalStatus
    {
        public MaritalStatus()
        {
            Enrollee = new HashSet<Enrollee>();
        }

        public int IdMaritalStatus { get; set; }
        public string NameMaritalStatus { get; set; }

        public ICollection<Enrollee> Enrollee { get; set; }
    }
}
