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
        [RegularExpression(@"[А-Яа-я]*", ErrorMessage = "Некорректное название национальности")]
        [Required(ErrorMessage ="Не указано название национальности")]
        [Display(Name = "Национальность")]
        public string NameNationality { get; set; }

        public ICollection<Enrollee> Enrollee { get; set; }
    }
}
