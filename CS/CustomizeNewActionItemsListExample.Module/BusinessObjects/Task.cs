using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using DevExpress.Persistent.Base;

namespace CustomizeNewActionItemsListExample.Module.BusinessObjects {
    [DefaultClassOptions]
    public class DemoTask : Task {
        public DemoTask(Session session) : base(session) { }
        public DateTime Deadline { get; set; }
    }
}
