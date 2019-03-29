using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace test
{
    public partial class MilitaryServiceCategory
    {
        public MilitaryServiceCategory()
        {
            Enrollee = new HashSet<Enrollee>();
        }

        public int IdCategoryMs { get; set; }
        [RegularExpression(@"[А-Яа-я \-0-9]*", ErrorMessage = "Некорректное название категории в/с")]
        [Required(ErrorMessage ="Не указана категория в/с")]
        [Display(Name = "Категория военной службы")]
        public string NameCategoryMs { get; set; }

        public ICollection<Enrollee> Enrollee { get; set; }
    }
}
