using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace test
{
    public partial class EducationalInstitution
    {
        public EducationalInstitution()
        {
            Enrollee = new HashSet<Enrollee>();
        }

        public int IdEducationalInstitution { get; set; }
        [Display(Name = "Учебное заведение")]
        [RegularExpression(@"[А-Яа-я \-0-9]*", ErrorMessage = "Некорректное название учебного заведения")]
        [Required(ErrorMessage ="Не указано название учебного заведения")]
        public string NameEducationalInstitution { get; set; }
        [Required]
        [Display(Name = "Город")]
        public int? IdTown { get; set; }

        [Display(Name = "Город")]
        public City IdTownNavigation { get; set; }
        public ICollection<Enrollee> Enrollee { get; set; }
    }
}
