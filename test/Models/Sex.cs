using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test
{
    public partial class Sex
    {
        public Sex()
        {
            Enrollee = new HashSet<Enrollee>();
            Parent = new HashSet<Parent>();
        }
        
        public int IdSex { get; set; }
        public string NameSex { get; set; }

        public ICollection<Enrollee> Enrollee { get; set; }
        public ICollection<Parent> Parent { get; set; }
    }
}
