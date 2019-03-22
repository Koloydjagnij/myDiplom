using System;
using System.Collections.Generic;

namespace test
{
    public partial class Subject
    {
        public Subject()
        {
            SubjectMark = new HashSet<SubjectMark>();
        }

        public int IdSubject { get; set; }
        public string NameSubject { get; set; }

        public ICollection<SubjectMark> SubjectMark { get; set; }
    }
}
