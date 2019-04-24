using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test.Models
{
    public class DocumentFile
    {
        public int Id { get; set; }
        public string NameFile { get; set; }
        public string TypeFile { get; set; }
        public byte[] File { get; set; }
        public int IdEnrollee { get; set; }

        public Enrollee IdEnrolleeNavigation { get; set; }

    }
}
