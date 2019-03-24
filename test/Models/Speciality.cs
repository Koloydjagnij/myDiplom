using System;
using System.Collections.Generic;

namespace test
{
    public partial class Speciality
    {
        public Speciality()
        {
            ExamForSpeciality = new HashSet<ExamForSpeciality>();
        }

        public int IdSpeciality { get; set; }
        public string NameSpeciality { get; set; }

        public ICollection<ExamForSpeciality> ExamForSpeciality { get; set; }
    }
}
