using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;

using DevExpress.ExpressApp.Win.SystemModule;
using DevExpress.ExpressApp.SystemModule;

namespace HowToCustomizeNewActionItemsList.Module.Win {
public partial class MyController : WinNewObjectViewController {
	//Subscribe the required events
	protected override void OnActivated() {
		//Get the ShowNavigationItemController,
		//then get its ShowNavigationItemAction and subscribe the SelectedItemChanged event
		Frame.GetController<ShowNavigationItemController>().ShowNavigationItemAction.SelectedItemChanged +=
			new EventHandler(ShowNavigationItemAction_SelectedItemChanged);
		CollectCreatableItemTypes += new EventHandler<DevExpress.ExpressApp.SystemModule.CollectTypesEventArgs>(MyController_CollectCreatableItemTypes);
		CollectDescendantTypes += new EventHandler<DevExpress.ExpressApp.SystemModule.CollectTypesEventArgs>(MyController_CollectDescendantTypes);
		base.OnActivated();
	}
	void MyController_CollectDescendantTypes(object sender, DevExpress.ExpressApp.SystemModule.CollectTypesEventArgs e) {
		CustomizeList(e.Types);
	}
	void MyController_CollectCreatableItemTypes(object sender, DevExpress.ExpressApp.SystemModule.CollectTypesEventArgs e) {
		CustomizeList(e.Types);
	}
	void ShowNavigationItemAction_SelectedItemChanged(object sender, EventArgs e) {
		this.UpdateActionState();
	}
	public void CustomizeList(ICollection<Type> types) {
		//Get the ShowNavigationItemController, then get its ShowNavigationItemAction
		SingleChoiceAction showNavigationItemAction =
			Frame.GetController<ShowNavigationItemController>().ShowNavigationItemAction;
		//Get the item selected in the navigation control
		ChoiceActionItem selectedItem = showNavigationItemAction.SelectedItem;
		ChoiceActionItem currentGroup = null;
		if(selectedItem != null) {
			//Get the selected item's parent group
			currentGroup = selectedItem.ParentItem;
			List<Type> unusableTypes = new List<Type>();
			//Collect the types that must be deleted
			foreach(Type type in types) {
				bool deletionRequired = true;
				foreach(ChoiceActionItem item in currentGroup.Items) {
					ViewShortcut shortcut = item.Data as ViewShortcut;
					if(shortcut.ViewId == Application.FindListViewId(type)) {
						deletionRequired = false;
					}
				}
				if(deletionRequired == true)
					unusableTypes.Add(type);
			}
			//Remove the collected types
			foreach(Type type in unusableTypes)
				types.Remove(type);
		}
	}
	//Unsubscribe from the events
	protected override void OnDeactivated() {
		Frame.GetController<ShowNavigationItemController>().ShowNavigationItemAction.SelectedItemChanged -=
			new EventHandler(ShowNavigationItemAction_SelectedItemChanged);
		CollectCreatableItemTypes -= new EventHandler<CollectTypesEventArgs>(MyController_CollectCreatableItemTypes);
		CollectDescendantTypes -= new EventHandler<CollectTypesEventArgs>(MyController_CollectDescendantTypes);
        base.OnDeactivated();
	}
}
}
