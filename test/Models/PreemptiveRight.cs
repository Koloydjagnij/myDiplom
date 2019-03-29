using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace test
{
    public partial class PreemptiveRight
    {
        public PreemptiveRight()
        {
            Enrollee = new HashSet<Enrollee>();
        }

        public int IdPreemptiveRight { get; set; }
        [RegularExpression(@"[А-Яа-я \-0-9]*", ErrorMessage = "Некорректное название типа приемущественного права")]
        [Required(ErrorMessage ="Не указан тип примемущественного права")]
        [Display(Name = "Преимущественное право")]
        public string NamePreemptiveRight { get; set; }

        public ICollection<Enrollee> Enrollee { get; set; }
    }
}
