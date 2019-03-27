using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace test
{
    public partial class Region
    {
        public Region()
        {
            Area = new HashSet<Area>();
        }

        public int IdRegion { get; set; }
        [Display(Name = "Регион")]
        [Required(ErrorMessage ="Не указано название региона")]
        public string NameRegion { get; set; }
        [Display(Name = "Военный округ")]
        [Required]
        public int IdMilitaryDistrict { get; set; }

        [Display(Name = "Военный округ")]
        public MilitaryDistrict IdMilitaryDistrictNavigation { get; set; }
        public ICollection<Area> Area { get; set; }
    }
}
