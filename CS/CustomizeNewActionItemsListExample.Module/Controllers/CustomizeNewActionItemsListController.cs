using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.ExpressApp;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp.SystemModule;

namespace CustomizeNewActionItemsListExample.Module.Controllers {
    public class CustomizeNewActionItemsListController : ObjectViewController<ObjectView, Task> {
        protected override void OnActivated() {
            base.OnActivated();
            NewObjectViewController controller = Frame.GetController<NewObjectViewController>();
            if (controller != null) {
                controller.CollectCreatableItemTypes += NewObjectViewController_CollectCreatableItemTypes;
                controller.CollectDescendantTypes += NewObjectViewController_CollectDescendantTypes;
                if (controller.Active) {
                    controller.UpdateNewObjectAction();
                }
            }
        }
        private void NewObjectViewController_CollectDescendantTypes(object sender, CollectTypesEventArgs e) {
            CustomizeList(e.Types);
        }
        private void NewObjectViewController_CollectCreatableItemTypes(object sender, CollectTypesEventArgs e) {
            CustomizeList(e.Types);
        }
        private void CustomizeList(ICollection<Type> types) {
            List<Type> unusableTypes = new List<Type>();
            foreach (Type item in types) {
                if (item == typeof(Task)) {
                    unusableTypes.Add(item);
                }
            }
            foreach (Type item in unusableTypes) {
                types.Remove(item);
            }
        }
        protected override void OnDeactivated() {
            NewObjectViewController controller = Frame.GetController<NewObjectViewController>();
            if (controller != null) {
                controller.CollectCreatableItemTypes -= NewObjectViewController_CollectCreatableItemTypes;
                controller.CollectDescendantTypes -= NewObjectViewController_CollectDescendantTypes;
            }
            base.OnDeactivated();   
        }
    }
 }

