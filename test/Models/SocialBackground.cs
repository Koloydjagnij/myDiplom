using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace test
{
    public partial class SocialBackground
    {
        public SocialBackground()
        {
            Enrollee = new HashSet<Enrollee>();
        }

        public int IdSocialBackground { get; set; }
        [RegularExpression(@"[А-Яа-я]*", ErrorMessage = "Некорректное название социального положения")]
        [Required(ErrorMessage ="Не указано социальное происхождение")]
        [Display(Name = "Социальное происхождение")]
        public string NameSocialBackground { get; set; }

        public ICollection<Enrollee> Enrollee { get; set; }
    }
}
