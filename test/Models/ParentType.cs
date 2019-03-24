using System;
using System.Collections.Generic;

namespace test
{
    public partial class ParentType
    {
        public ParentType()
        {
            Parent = new HashSet<Parent>();
        }

        public int IdParentType { get; set; }
        public string NameParentType { get; set; }

        public ICollection<Parent> Parent { get; set; }
    }
}
