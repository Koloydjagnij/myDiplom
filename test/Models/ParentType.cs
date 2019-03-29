using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace test
{
    public partial class ParentType
    {
        public ParentType()
        {
            Parent = new HashSet<Parent>();
        }

        public int IdParentType { get; set; }
        [RegularExpression(@"[А-Яа-я]*", ErrorMessage = "Некорректное название типа родителя")]
        [Required(ErrorMessage ="Не указано название типа родителя")]
        [Display(Name = "Тип родителя")]
        public string NameParentType { get; set; }

        public ICollection<Parent> Parent { get; set; }
    }
}
