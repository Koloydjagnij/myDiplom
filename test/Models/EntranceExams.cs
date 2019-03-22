using System;
using System.Collections.Generic;

namespace test
{
    public partial class EntranceExams
    {
        public EntranceExams()
        {
            ExamForSpeciality = new HashSet<ExamForSpeciality>();
        }

        public int IdEntranceExam { get; set; }
        public string NameEntranceExam { get; set; }
        public bool? Necessarily { get; set; }

        public ICollection<ExamForSpeciality> ExamForSpeciality { get; set; }
    }
}
