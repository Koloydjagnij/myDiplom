using System;
using System.Collections.Generic;

namespace test
{
    public partial class FamilyType
    {
        public FamilyType()
        {
            Family = new HashSet<Family>();
        }

        public int IdFamilyType { get; set; }
        public string NameFamilyType { get; set; }

        public ICollection<Family> Family { get; set; }
    }
}
