;#DropDB CustomizeNewActionItemsListExampleEasyTest

#Application CustomizeNewActionItemsListExample.Win
#Application CustomizeNewActionItemsListExample.Web
#IfDef CustomizeNewActionItemsListExample.Win

*Action About...
 
*Action OK

#EndIf

#IfDef CustomizeNewActionItemsListExample.Web
!Action Navigation(My Details)
#EndIf
