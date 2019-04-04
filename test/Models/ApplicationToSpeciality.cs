using System;
using System.Collections.Generic;

namespace test
{
    public partial class ApplicationToSpeciality
    {
        public int IdApplicationToSpeciality { get; set; }//add 03.04.2019
        public int? PriorityNumber { get; set; }
        public int IdEnrollee { get; set; }
        public string Groupe { get; set; }
        public int IdEntranceExam { get; set; }
        public int IdSpeciality { get; set; }
        public int IdTestType { get; set; }
        public DateTime? DateOfPassingExam { get; set; }
        public int? ExamMark { get; set; }

        public ExamForSpeciality IdExamNavigation { get; set; }//03.04.2019
        public Enrollee IdEnrolleeNavigation { get; set; }
        public TestType IdTestTypeNavigation { get; set; }
    }
}
