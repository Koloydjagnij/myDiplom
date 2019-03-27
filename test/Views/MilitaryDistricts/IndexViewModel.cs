using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.ViewsModels;

namespace test.Views.MilitaryDistricts
{
    public class IndexViewModel
    {
        public IEnumerable<MilitaryDistrict> MilitaryDistrict { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
