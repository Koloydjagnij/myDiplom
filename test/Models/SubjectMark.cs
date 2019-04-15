using System;
using System.Collections.Generic;

namespace test
{
    public partial class SubjectMark
    {
        public int IdSubjectMark { get; set; }//add 03.04.2019
        public int? Mark { get; set; }
        public int IdSubject { get; set; }
        public int IdEnrollee { get; set; }

        public Enrollee IdEnrolleeNavigation { get; set; }
        public Subject IdSubjectNavigation { get; set; }
    }
}
