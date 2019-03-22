using System;
using System.Collections.Generic;

namespace test
{
    public partial class PreemptiveRight
    {
        public PreemptiveRight()
        {
            Enrollee = new HashSet<Enrollee>();
        }

        public int IdPreemptiveRight { get; set; }
        public string NamePreemptiveRight { get; set; }

        public ICollection<Enrollee> Enrollee { get; set; }
    }
}
