using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test.Models
{
    public class ChangeHistory
    {
        public int ChangeHistoryId { get; set; }
        public string FieldName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public DateTime DateTime { get; set; }
        public string ChangedBy{ get; set; }
    }
}
