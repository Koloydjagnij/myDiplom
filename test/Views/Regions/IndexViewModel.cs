using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.ViewsModels;

namespace test.Views.Regions
{
    public class IndexViewModel
    {
        public IEnumerable<Region> Region { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
