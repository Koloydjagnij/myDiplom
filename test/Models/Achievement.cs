using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace test
{
    public partial class Achievement
    {
        public Achievement()
        {
            EnrolleeAchievement = new HashSet<EnrolleeAchievement>();
        }

        public int IdAchievement { get; set; }
        [Display(Name = "Достижение")]
        [Required (ErrorMessage = "Не указано название достижения")]
        public string NameAchievement { get; set; }

        public ICollection<EnrolleeAchievement> EnrolleeAchievement { get; set; }
    }
}
