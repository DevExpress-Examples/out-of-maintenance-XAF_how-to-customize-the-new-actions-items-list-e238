using System;

using DevExpress.Xpo;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace HowToCustomizeNewActionItemsList.Module {
	[NavigationItem(GroupName="Group1")]
	[CreatableItem()]
	public class DomainObject1 : BaseObject {
		public DomainObject1(Session session)
			: base(session) {
		}
	}
	[NavigationItem(GroupName = "Group1")]
	[CreatableItem()]
	public class DomainObject2 : BaseObject {
		public DomainObject2(Session session)
			: base(session) {
		}
	}
	[NavigationItem(GroupName = "Group2")]
	[CreatableItem()]
	public class DomainObject3 : BaseObject {
		public DomainObject3(Session session)
			: base(session) {
		}
	}
	[NavigationItem(GroupName = "Group2")]
	[CreatableItem()]
	public class DomainObject4 : BaseObject {
		public DomainObject4(Session session)
			: base(session) {
		}
	}
}
