﻿using System;
using System.Collections.Generic;

namespace test
{
    public partial class EnrolleeDocuments
    {
        public int IdEnrollee { get; set; }
        public int IdDocument { get; set; }
        public DateTime? LoadDate { get; set; }
        public bool? PresenceInPersonalFile { get; set; }

        public Document IdDocumentNavigation { get; set; }
        public Enrollee IdEnrolleeNavigation { get; set; }
    }
}
