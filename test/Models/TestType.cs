using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace test
{
    public partial class TestType
    {
        public TestType()
        {
            ApplicationToSpeciality = new HashSet<ApplicationToSpeciality>();
        }

        public int IdTestType { get; set; }
        [Display(Name = "Тип испытания")]
        [Required(ErrorMessage ="Не указано название типа испытания")]
        public string NameTestType { get; set; }

        public ICollection<ApplicationToSpeciality> ApplicationToSpeciality { get; set; }
    }
}
