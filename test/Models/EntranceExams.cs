﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace test
{
    public partial class EntranceExams
    {
        public EntranceExams()
        {
            ExamForSpeciality = new HashSet<ExamForSpeciality>();
        }

        public int IdEntranceExam { get; set; }
        [Display(Name = "Название экзамена")]
        public string NameEntranceExam { get; set; }
        [Display(Name = "Обязательность")]
        public bool? Necessarily { get; set; }

        public ICollection<ExamForSpeciality> ExamForSpeciality { get; set; }
    }
}
