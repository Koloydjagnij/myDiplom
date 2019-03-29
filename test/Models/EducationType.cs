using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace test
{
    public partial class EducationType
    {
        public EducationType()
        {
            Enrollee = new HashSet<Enrollee>();
        }

        public int IdEducationType { get; set; }
        [Display(Name = "Тип обучения")]
        [RegularExpression(@"[А-Яа-я \-]*", ErrorMessage = "Некорректное название типа образования")]
        [Required(ErrorMessage ="Не указано название типа образования")]
        public string NameEducationType { get; set; }

        public ICollection<Enrollee> Enrollee { get; set; }
    }
}
