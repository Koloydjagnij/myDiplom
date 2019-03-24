using System;
using System.Collections.Generic;

namespace test
{
    public partial class Family
    {
        public int IdFamilyType { get; set; }
        public int IdParent { get; set; }
        public int IdEnrollee { get; set; }

        public Enrollee IdEnrolleeNavigation { get; set; }
        public FamilyType IdFamilyTypeNavigation { get; set; }
        public Parent IdParentNavigation { get; set; }
    }
}
