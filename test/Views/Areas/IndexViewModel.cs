using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.ViewsModels;

namespace test.Views.Areas
{
    public class IndexViewModel
    {
        public IEnumerable<Area> Area { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
