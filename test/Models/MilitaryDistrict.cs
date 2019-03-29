using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace test
{
    public partial class MilitaryDistrict
    {
        public MilitaryDistrict()
        {
            Region = new HashSet<Region>();
        }

        public int IdMilitaryDistrict { get; set; }
        [RegularExpression(@"[А-Яа-я \-]*", ErrorMessage = "Некорректное название военного округа")]
        [Required (ErrorMessage = "Не указано название военного округа")]
        [Display(Name = "Военный округ")]
        public string NameMilitaryDistrict { get; set; }

        public ICollection<Region> Region { get; set; }
    }
}
