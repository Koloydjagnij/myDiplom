using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace test
{
    public partial class SocialStatus
    {
        public SocialStatus()
        {
            Parent = new HashSet<Parent>();
        }

        public int IdSocialStatus { get; set; }
        [RegularExpression(@"[А-Яа-я]*", ErrorMessage = "Некорректное название соц. статуса")]
        [Required(ErrorMessage ="Не указано название социального статуса")]
        [Display(Name = "Социальный статус")]
        public string NameSocialStatus { get; set; }

        public ICollection<Parent> Parent { get; set; }
    }
}
