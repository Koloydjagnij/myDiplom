using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace test
{
    public partial class MilitaryUnit
    {
        public MilitaryUnit()
        {
            Enrollee = new HashSet<Enrollee>();
        }

        public int IdMilitaryUnit { get; set; }
        [Display(Name = "Войсковая часть")]
        public string NameMilitaryUnit { get; set; }
        [Display(Name = "Район")]
        public int IdArea { get; set; }

        [Display(Name = "Район")]
        public Area IdAreaNavigation { get; set; }
        public ICollection<Enrollee> Enrollee { get; set; }
    }
}
