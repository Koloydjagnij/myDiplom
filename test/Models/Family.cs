using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace test
{
    public partial class Family
    {
        public int IdFamily { get; set; }//add 03.04.2019

        [Display(Name = "Тип семьи")]
        public int IdFamilyType { get; set; }
        public int IdParent { get; set; }
        public int IdEnrollee { get; set; }

        public Enrollee IdEnrolleeNavigation { get; set; }
        public FamilyType IdFamilyTypeNavigation { get; set; }
        public Parent IdParentNavigation { get; set; }
    }
}
