using System;
using System.Collections.Generic;

namespace test
{
    public partial class Parent
    {
        public Parent()
        {
            Family = new HashSet<Family>();
        }

        public int IdParent { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public int IdParentType { get; set; }
        public int IdSex { get; set; }
        public int IdSocialStatus { get; set; }
        public int IdCity { get; set; }
        public int IdFactOfProsecution { get; set; }

        public City IdCityNavigation { get; set; }
        public FactOfProsecution IdFactOfProsecutionNavigation { get; set; }
        public ParentType IdParentTypeNavigation { get; set; }
        public Sex IdSexNavigation { get; set; }
        public SocialStatus IdSocialStatusNavigation { get; set; }
        public ICollection<Family> Family { get; set; }
    }
}
