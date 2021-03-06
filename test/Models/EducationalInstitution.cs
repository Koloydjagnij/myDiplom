﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace test
{
    public partial class EducationalInstitution
    {
        public EducationalInstitution()
        {
            Enrollee = new HashSet<Enrollee>();
        }

        public int IdEducationalInstitution { get; set; }
        [Display(Name = "Учебное заведение")]
        public string NameEducationalInstitution { get; set; }
        [Display(Name = "Город")]
        public int? IdTown { get; set; }

        [Display(Name = "Город")]
        public City IdTownNavigation { get; set; }
        public ICollection<Enrollee> Enrollee { get; set; }
    }
}
