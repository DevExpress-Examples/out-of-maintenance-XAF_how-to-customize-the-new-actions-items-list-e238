Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.ExpressApp.SystemModule

Namespace CustomizeNewActionItemsListExample.Module.Controllers
    Public Class CustomizeNewActionItemsListController
        Inherits ObjectViewController(Of ObjectView, Task)

        Protected Overrides Sub OnActivated()
            MyBase.OnActivated()
            Dim controller As NewObjectViewController = Frame.GetController(Of NewObjectViewController)()
            If controller IsNot Nothing Then
                AddHandler controller.CollectCreatableItemTypes, AddressOf NewObjectViewController_CollectCreatableItemTypes
                AddHandler controller.CollectDescendantTypes, AddressOf NewObjectViewController_CollectDescendantTypes
                If controller.Active Then
                    controller.UpdateNewObjectAction()
                End If
            End If
        End Sub
        Private Sub NewObjectViewController_CollectDescendantTypes(ByVal sender As Object, ByVal e As CollectTypesEventArgs)
            CustomizeList(e.Types)
        End Sub
        Private Sub NewObjectViewController_CollectCreatableItemTypes(ByVal sender As Object, ByVal e As CollectTypesEventArgs)
            CustomizeList(e.Types)
        End Sub
        Private Sub CustomizeList(ByVal types As ICollection(Of Type))
            Dim unusableTypes As New List(Of Type)()
            For Each item As Type In types
                If item Is GetType(Task) Then
                    unusableTypes.Add(item)
                End If
            Next item
            For Each item As Type In unusableTypes
                types.Remove(item)
            Next item
        End Sub
        Protected Overrides Sub OnDeactivated()
            Dim controller As NewObjectViewController = Frame.GetController(Of NewObjectViewController)()
            If controller IsNot Nothing Then
                RemoveHandler controller.CollectCreatableItemTypes, AddressOf NewObjectViewController_CollectCreatableItemTypes
                RemoveHandler controller.CollectDescendantTypes, AddressOf NewObjectViewController_CollectDescendantTypes
            End If
            MyBase.OnDeactivated()
        End Sub
    End Class
End Namespace

