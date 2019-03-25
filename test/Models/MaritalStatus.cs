using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace test
{
    public partial class MaritalStatus
    {
        public MaritalStatus()
        {
            Enrollee = new HashSet<Enrollee>();
        }

        public int IdMaritalStatus { get; set; }
        [Display(Name = "Семейное положение")]
        public string NameMaritalStatus { get; set; }

        public ICollection<Enrollee> Enrollee { get; set; }
    }
}
