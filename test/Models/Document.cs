using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace test
{
    public partial class Document
    {
        public Document()
        {
            EnrolleeDocuments = new HashSet<EnrolleeDocuments>();
        }

        public int IdDocument { get; set; }
        [Display(Name = "Наименование документа")]
        public string NameDocument { get; set; }

        public ICollection<EnrolleeDocuments> EnrolleeDocuments { get; set; }
    }
}
