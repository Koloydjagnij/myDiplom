using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test.Views.Enrollees
{
    public class CreateViewModel
    {
        public Enrollee Enrollees { get; set; }
        public IEnumerable<Family> Families { get; set; }
    }
}
