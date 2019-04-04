using System;
using System.Collections.Generic;

namespace test
{
    public partial class EnrolleeAchievement
    {
        public int IdEnrolleeAchievement { get; set; }// add 03.04.2019
        public int IdEnrollee { get; set; }
        public int IdAchievement { get; set; }
        public int? Priority { get; set; }

        public Achievement IdAchievementNavigation { get; set; }
        public Enrollee IdEnrolleeNavigation { get; set; }
    }
}
