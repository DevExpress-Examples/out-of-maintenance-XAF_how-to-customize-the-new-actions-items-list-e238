Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Xpo
Imports DevExpress.Persistent.Base

Namespace CustomizeNewActionItemsListExample.Module.BusinessObjects
    <DefaultClassOptions> _
    Public Class DemoTask
        Inherits Task

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Public Property Deadline() As Date
    End Class
End Namespace
