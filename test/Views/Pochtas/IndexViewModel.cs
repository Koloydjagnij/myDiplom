﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.Models;
using test.ViewsModels;

namespace test.Views.Pochtas
{
    public class IndexViewModel
    {
        public IEnumerable<Pochta> Pochta { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
