using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace test.Models
{
    public class Group
    {
        [Display(Name = "ID группы")]
        public int IdGroup { get; set; }

        [Display(Name = "Название группы")]
        public string GroupName { get; set; }

        [Display(Name = "Людей в группе (норма)")]
        public int CountEnrolleeInGroup { get; set; }

        public ICollection<Enrollee> Enrollees { get; set; }
    }
}
