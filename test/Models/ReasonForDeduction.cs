using System;
using System.Collections.Generic;

namespace test
{
    public partial class ReasonForDeduction
    {
        public ReasonForDeduction()
        {
            Enrollee = new HashSet<Enrollee>();
        }

        public int IdReasonForDeduction { get; set; }
        public string NameReasonForDeduction { get; set; }

        public ICollection<Enrollee> Enrollee { get; set; }
    }
}
