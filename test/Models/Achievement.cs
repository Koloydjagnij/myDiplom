using System;
using System.Collections.Generic;

namespace test
{
    public partial class Achievement
    {
        public Achievement()
        {
            EnrolleeAchievement = new HashSet<EnrolleeAchievement>();
        }

        public int IdAchievement { get; set; }
        public string NameAchievement { get; set; }

        public ICollection<EnrolleeAchievement> EnrolleeAchievement { get; set; }
    }
}
