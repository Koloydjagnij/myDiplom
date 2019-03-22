using System;
using System.Collections.Generic;

namespace test
{
    public partial class TestType
    {
        public TestType()
        {
            ApplicationToSpeciality = new HashSet<ApplicationToSpeciality>();
        }

        public int IdTestType { get; set; }
        public string NameTestType { get; set; }

        public ICollection<ApplicationToSpeciality> ApplicationToSpeciality { get; set; }
    }
}
