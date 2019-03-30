using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace test
{
    public partial class City
    {
        public City()
        {
            EducationalInstitution = new HashSet<EducationalInstitution>();
            Enrollee = new HashSet<Enrollee>();
            MilitaryOffice = new HashSet<MilitaryOffice>();
            Parent = new HashSet<Parent>();
        }

        public int IdTown { get; set; }
        [Display(Name = "Город")]
        [Required(ErrorMessage = "Не указано название города")]
        [RegularExpression(@"[А-Яа-я .\-0-9]*", ErrorMessage = "Некорректное название города")]
        public string NameCity { get; set; }
        [Display(Name = "Район")]
        [Required]
        public int? IdArea { get; set; }

        [Display(Name = "Район")]
        public Area IdAreaNavigation { get; set; }
        public ICollection<EducationalInstitution> EducationalInstitution { get; set; }
        public ICollection<Enrollee> Enrollee { get; set; }
        public ICollection<MilitaryOffice> MilitaryOffice { get; set; }
        public ICollection<Parent> Parent { get; set; }
    }
}
