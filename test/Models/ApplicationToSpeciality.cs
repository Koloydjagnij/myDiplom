using System;
using System.Collections.Generic;

namespace test
{
    public partial class ApplicationToSpeciality
    {
        public int? PriorityNumber { get; set; }
        public int IdEnrollee { get; set; }
        public string Groupe { get; set; }
        public int IdEntranceExam { get; set; }
        public int IdSpeciality { get; set; }
        public int IdTestType { get; set; }
        public DateTime? DateOfPassingExam { get; set; }
        public int? ExamMark { get; set; }

        public ExamForSpeciality Id { get; set; }
        public Enrollee IdEnrolleeNavigation { get; set; }
        public TestType IdTestTypeNavigation { get; set; }
    }
}
