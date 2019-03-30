using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace test
{
    public partial class MilitaryOffice
    {
        public MilitaryOffice()
        {
            Enrollee = new HashSet<Enrollee>();
        }

        public int IdMilitaryOffice { get; set; }
        public string MilitaryDistrict { get; set; }
        public string Status { get; set; }
        [RegularExpression(@"[А-Яа-я \-]*", ErrorMessage = "Некорректное название военного комиссариата")]
        [Required(ErrorMessage = "Не указано название военного комиссариата")]
        [Display(Name = "Военный комиссариат")]
        public string NameMilitaryOffice { get; set; }
        public int IdTown { get; set; }

        public City IdTownNavigation { get; set; }
        public ICollection<Enrollee> Enrollee { get; set; }
    }
}
