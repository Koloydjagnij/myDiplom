using System;
using System.Collections.Generic;

namespace test
{
    public partial class MilitaryServiceCategory
    {
        public MilitaryServiceCategory()
        {
            Enrollee = new HashSet<Enrollee>();
        }

        public int IdCategoryMs { get; set; }
        public string NameCategoryMs { get; set; }

        public ICollection<Enrollee> Enrollee { get; set; }
    }
}
