﻿using System;
using System.Collections.Generic;

namespace test
{
    public partial class ExamForSpeciality
    {
        public ExamForSpeciality()
        {
            ApplicationToSpeciality = new HashSet<ApplicationToSpeciality>();
        }
        public int IdExamForSpeciality { get; set; }//add 03.04.2019
        public int IdEntranceExam { get; set; }
        public int IdSpeciality { get; set; }

        public EntranceExams IdEntranceExamNavigation { get; set; }
        public Speciality IdSpecialityNavigation { get; set; }
        public ICollection<ApplicationToSpeciality> ApplicationToSpeciality { get; set; }
    }
}
