using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace test
{
    public partial class EducationType
    {
        public EducationType()
        {
            Enrollee = new HashSet<Enrollee>();
        }

        public int IdEducationType { get; set; }
        [Display(Name = "Тип обучения")]
        public string NameEducationType { get; set; }

        public ICollection<Enrollee> Enrollee { get; set; }
    }
}
