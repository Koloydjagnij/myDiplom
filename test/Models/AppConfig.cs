using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace test
{
    public partial class AppConfig
    {
        public int Id { get; set; }
        
        [Display(Name = "Ключ")]
        public string Key { get; set; }
        [Display(Name = "Значение")]
        public string Value { get; set; }

    }
}

