using System;
using System.Collections.Generic;

namespace test
{
    public partial class FactOfProsecution
    {
        public FactOfProsecution()
        {
            Enrollee = new HashSet<Enrollee>();
            Parent = new HashSet<Parent>();
        }

        public int IdFactOfProsecution { get; set; }
        public string NameFactOfProsecution { get; set; }

        public ICollection<Enrollee> Enrollee { get; set; }
        public ICollection<Parent> Parent { get; set; }
    }
}
