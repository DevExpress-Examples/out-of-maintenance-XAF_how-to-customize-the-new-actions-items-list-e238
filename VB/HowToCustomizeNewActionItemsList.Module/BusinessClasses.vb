Imports System

Imports DevExpress.Xpo

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

<NavigationItem(GroupName:="Group1"), CreatableItem()> _
Public Class DomainObject1
   Inherits BaseObject
   Public Sub New(ByVal session As Session)
      MyBase.New(session)
   End Sub
End Class
<NavigationItem(GroupName:="Group1"), CreatableItem()> _
Public Class DomainObject2
   Inherits BaseObject
   Public Sub New(ByVal session As Session)
      MyBase.New(session)
   End Sub
End Class
<NavigationItem(GroupName:="Group2"), CreatableItem()> _
Public Class DomainObject3
   Inherits BaseObject
   Public Sub New(ByVal session As Session)
      MyBase.New(session)
   End Sub
End Class
<NavigationItem(GroupName:="Group2"), CreatableItem()> _
Public Class DomainObject4
   Inherits BaseObject
   Public Sub New(ByVal session As Session)
      MyBase.New(session)
   End Sub
End Class

