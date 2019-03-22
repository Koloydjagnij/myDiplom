using System;
using System.Collections.Generic;

namespace test
{
    public partial class SocialBackground
    {
        public SocialBackground()
        {
            Enrollee = new HashSet<Enrollee>();
        }

        public int IdSocialBackground { get; set; }
        public string NameSocialBackground { get; set; }

        public ICollection<Enrollee> Enrollee { get; set; }
    }
}
