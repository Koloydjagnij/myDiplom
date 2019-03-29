using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [RegularExpression(@"[А-Яа-я \-0-9]*", ErrorMessage = "Некорректное название факта привлечения")]
        [Required(ErrorMessage ="Название факта привлечения к ответственности")]
        [Display(Name = "Факт привлечения к ответственности")]
        public string NameFactOfProsecution { get; set; }

        public ICollection<Enrollee> Enrollee { get; set; }
        public ICollection<Parent> Parent { get; set; }
    }
}
