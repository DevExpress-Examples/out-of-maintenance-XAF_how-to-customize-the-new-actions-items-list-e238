Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base
Imports DevExpress.ExpressApp.Win.SystemModule
Imports DevExpress.ExpressApp.SystemModule


Partial Public Class MyController
   Inherits WinNewObjectViewController
   'Subscribe the required events
   Protected Overrides Sub OnActivated()
      'Get the ShowNavigationItemController,
      'then get its ShowNavigationItemAction and subscribe the SelectedItemChanged event
      AddHandler Frame.GetController(Of ShowNavigationItemController)().ShowNavigationItemAction.SelectedItemChanged, AddressOf ShowNavigationItemAction_SelectedItemChanged
      AddHandler CollectCreatableItemTypes, AddressOf MyController_CollectCreatableItemTypes
      AddHandler CollectDescendantTypes, AddressOf MyController_CollectDescendantTypes
      MyBase.OnActivated()
   End Sub
   Private Sub MyController_CollectDescendantTypes(ByVal sender As Object, ByVal e As DevExpress.ExpressApp.SystemModule.CollectTypesEventArgs)
      CustomizeList(e.Types)
   End Sub
   Private Sub MyController_CollectCreatableItemTypes(ByVal sender As Object, ByVal e As DevExpress.ExpressApp.SystemModule.CollectTypesEventArgs)
      CustomizeList(e.Types)
   End Sub
   Private Sub ShowNavigationItemAction_SelectedItemChanged(ByVal sender As Object, ByVal e As EventArgs)
      Me.UpdateActionState()
   End Sub
   Public Sub CustomizeList(ByVal types As ICollection(Of Type))
      'Get the ShowNavigationItemController, then get its ShowNavigationItemAction
      Dim showNavigationItemAction As SingleChoiceAction = Frame.GetController(Of ShowNavigationItemController)().ShowNavigationItemAction
      'Get the item selected in the navigation control
      Dim selectedItem As ChoiceActionItem = showNavigationItemAction.SelectedItem
      Dim currentGroup As ChoiceActionItem = Nothing
      If Not selectedItem Is Nothing Then
         'Get the selected item's parent group
         currentGroup = selectedItem.ParentItem
         Dim unusableTypes As List(Of Type) = New List(Of Type)()
         'Collect the types that must be deleted
         For Each type As Type In types
            Dim deletionRequired As Boolean = True
            For Each item As ChoiceActionItem In currentGroup.Items
               Dim shortcut As ViewShortcut = TryCast(item.Data, ViewShortcut)
               If shortcut.ViewId = Application.FindListViewId(type) Then
                  deletionRequired = False
               End If
            Next item
            If deletionRequired = True Then
               unusableTypes.Add(type)
            End If
         Next type
         'Remove the collected types
         For Each type As Type In unusableTypes
            types.Remove(type)
         Next type
      End If
   End Sub
   'Unsubscribe from the events
    Protected Overrides Sub OnDeactivated()
        RemoveHandler Frame.GetController(Of ShowNavigationItemController)().ShowNavigationItemAction.SelectedItemChanged, AddressOf ShowNavigationItemAction_SelectedItemChanged
        RemoveHandler CollectCreatableItemTypes, AddressOf MyController_CollectCreatableItemTypes
        RemoveHandler CollectDescendantTypes, AddressOf MyController_CollectDescendantTypes
        MyBase.OnDeactivated()
    End Sub
End Class

