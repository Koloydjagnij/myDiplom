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
        [RegularExpression(@"[А-Яа-я]*", ErrorMessage = "Некорректное название семейного положения")]
        [Required(ErrorMessage ="Введите название семейного положения")]
        [Display(Name = "Семейное положение")]
        public string NameMaritalStatus { get; set; }

        public ICollection<Enrollee> Enrollee { get; set; }
    }
}
