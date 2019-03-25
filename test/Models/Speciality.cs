using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace test
{
    public partial class Speciality
    {
        public Speciality()
        {
            ExamForSpeciality = new HashSet<ExamForSpeciality>();
        }

        public int IdSpeciality { get; set; }
        [Display(Name = "Специальность")]
        public string NameSpeciality { get; set; }

        public ICollection<ExamForSpeciality> ExamForSpeciality { get; set; }
    }
}
