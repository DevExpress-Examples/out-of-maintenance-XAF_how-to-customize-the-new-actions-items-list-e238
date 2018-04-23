# How to Customize the New Action's Items List


<p>When an application contains numerous business classes, the New Action can contain most of them in its Items list. In this instance, the use of this Action can become cumbersome. To make manipulations with this Action easier, you can add to the Action's Items list only those types that are contained in the currently selected navigation control group. To group navigation control items, use the Application Model's NavigationItems node. To customize the New Action's Items list, handle the NewObjectViewController.CollectDescendants and NewObjectViewController.CollectRoot events of the NewObjectViewController, which contains the New Action. The former event is raised when the current object type and its descendants are added to the Action's Items list, and the latter is raised when all the remaining types whose CreatableItem attribute is set to true in the Application Model are added. This example demonstrates how to do this.</p><p>See code in the BusinessClasses.cs and MyController.cs (BusinessClasses.vb and MyController.vb) files. For details, refer to the <a href="http://documentation.devexpress.com/#Xaf/CustomDocument2915">How to: Customize the New Action's Items List</a> topic in XAF documentation.</p>

<br/>


