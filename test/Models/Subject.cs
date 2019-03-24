using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace test
{
    public partial class Subject
    {
        public Subject()
        {
            SubjectMark = new HashSet<SubjectMark>();
        }

        public int IdSubject { get; set; }
        [Display(Name = "Предмет")]
        public string NameSubject { get; set; }

        public ICollection<SubjectMark> SubjectMark { get; set; }
    }
}
