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
        [RegularExpression(@"[А-Яа-я \-0-9.]*", ErrorMessage = "Некорректное название типа испытания")]
        [Required(ErrorMessage ="Не указано название типа испытания")]
        public string NameTestType { get; set; }

        public ICollection<ApplicationToSpeciality> ApplicationToSpeciality { get; set; }
    }
}
