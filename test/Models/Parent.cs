using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace test
{
    public partial class Parent
    {
        public Parent()
        {
            Family = new HashSet<Family>();
        }

        public int IdParent { get; set; }

        [Display(Name = "Фамилия")]
        public string Surname { get; set; }

        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }

        [Display(Name = "Тип родства")]
        public int IdParentType { get; set; }

        [Display(Name = "Пол")]
        public int IdSex { get; set; }

        [Display(Name = "Социальный статус")]
        public int IdSocialStatus { get; set; }

        [Display(Name = "Город")]
        public int IdCity { get; set; }

        [Display(Name = "Привлечение к ответсвенности")]
        public int IdFactOfProsecution { get; set; }

        public City IdCityNavigation { get; set; }
        public FactOfProsecution IdFactOfProsecutionNavigation { get; set; }
        public ParentType IdParentTypeNavigation { get; set; }
        public Sex IdSexNavigation { get; set; }
        public SocialStatus IdSocialStatusNavigation { get; set; }
        public ICollection<Family> Family { get; set; }
    }
}
