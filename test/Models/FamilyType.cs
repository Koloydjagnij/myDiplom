using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace test
{
    public partial class FamilyType
    {
        public FamilyType()
        {
            Family = new HashSet<Family>();
        }

        public int IdFamilyType { get; set; }
        [Display(Name = "Тип семьи")]
        public string NameFamilyType { get; set; }

        public ICollection<Family> Family { get; set; }
    }
}
