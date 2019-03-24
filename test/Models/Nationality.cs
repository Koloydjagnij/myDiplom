using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace test
{
    public partial class Nationality
    {
        public Nationality()
        {
            Enrollee = new HashSet<Enrollee>();
        }

        public int IdNationality { get; set; }
        [Display(Name = "Национальность")]
        public string NameNationality { get; set; }

        public ICollection<Enrollee> Enrollee { get; set; }
    }
}
