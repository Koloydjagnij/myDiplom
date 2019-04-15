using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace test
{
    public partial class MilitaryRank
    {
        public MilitaryRank()
        {
            Enrollee = new HashSet<Enrollee>();
        }

        public int IdMilitaryRank { get; set; }
        [Required(ErrorMessage ="Не указано воинское звание")]
        [Display(Name = "Воинское звание")]
        public string NameMilitaryRank { get; set; }

        public ICollection<Enrollee> Enrollee { get; set; }
    }
}
