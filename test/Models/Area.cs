using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace test
{
    public partial class Area
    {
        public Area()
        {
            City = new HashSet<City>();
            MilitaryUnit = new HashSet<MilitaryUnit>();
        }

        public int IdArea { get; set; }
        [Display(Name = "Район")]
        [Required (ErrorMessage = "Не указано название района")]
        [RegularExpression(@"[А-Яа-я .\-0-9]*", ErrorMessage = "Некорректное название района")]
        public string NameArea { get; set; }

        [Display(Name = "Область")]
        [Required]
        public int? IdRegion { get; set; }

        [Display(Name = "Область")]
        public Region IdRegionNavigation { get; set; }
        public ICollection<City> City { get; set; }
        public ICollection<MilitaryUnit> MilitaryUnit { get; set; }
    }
}
