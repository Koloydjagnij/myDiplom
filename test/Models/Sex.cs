﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test
{
    public partial class Sex
    {
        public Sex()
        {
            Enrollee = new HashSet<Enrollee>();
            Parent = new HashSet<Parent>();
        }
        
        public int IdSex { get; set; }
        [RegularExpression(@"[А-Яа-я]*", ErrorMessage = "Некорректное название пола")]
        [Display(Name = "Пол")]
        [Required (ErrorMessage = "Не указано название пола")]
        public string NameSex { get; set; }

        public ICollection<Enrollee> Enrollee { get; set; }
        public ICollection<Parent> Parent { get; set; }
    }
}
