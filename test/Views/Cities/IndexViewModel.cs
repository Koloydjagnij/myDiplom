using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.ViewsModels;

namespace test.Views.Cities
{
    public class IndexViewModel
    {
        public IEnumerable<City> City { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
