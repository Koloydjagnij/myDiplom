using System;
using System.Collections.Generic;

namespace test
{
    public partial class SocialStatus
    {
        public SocialStatus()
        {
            Parent = new HashSet<Parent>();
        }

        public int IdSocialStatus { get; set; }
        public string NameSocialStatus { get; set; }

        public ICollection<Parent> Parent { get; set; }
    }
}
