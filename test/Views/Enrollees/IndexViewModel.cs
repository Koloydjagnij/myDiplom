using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.ViewsModels;

namespace test.Views.Enrollees
{
    public class IndexViewModel
    {
        public IEnumerable<Enrollee> Enrollees { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public FilterViewModel FilterViewModel { get; set; }
        public SortViewModel SortViewModel { get; set; }
    }
}
