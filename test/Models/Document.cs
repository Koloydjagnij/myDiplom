using System;
using System.Collections.Generic;

namespace test
{
    public partial class Document
    {
        public Document()
        {
            EnrolleeDocuments = new HashSet<EnrolleeDocuments>();
        }

        public int IdDocument { get; set; }
        public string NameDocument { get; set; }

        public ICollection<EnrolleeDocuments> EnrolleeDocuments { get; set; }
    }
}
