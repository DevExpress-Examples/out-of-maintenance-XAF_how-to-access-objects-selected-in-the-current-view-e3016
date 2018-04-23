Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.ExpressApp.Editors

Namespace SelectedObjects.Module
	Public Class MyNotesController
		Inherits ViewController
		Private myAction As SimpleAction
		Public Sub New()
			myAction = New SimpleAction(Me, "Add a note", "RecordEdit")
			myAction.SelectionDependencyType = SelectionDependencyType.RequireMultipleObjects
			myAction.TargetObjectType = GetType(Contact)
			AddHandler myAction.Execute, AddressOf myAction_Execute
			Actions.Add(myAction)
		End Sub
		Private Sub myAction_Execute(ByVal sender As Object, ByVal e As SimpleActionExecuteEventArgs)
			For Each selectedObject As Contact In e.SelectedObjects
				selectedObject.Notes += System.Environment.NewLine & "additional note"
			Next selectedObject
			If TypeOf View Is DetailView AndAlso (CType(View, DetailView)).ViewEditMode = ViewEditMode.View Then
				View.ObjectSpace.CommitChanges()
			End If
		End Sub
	End Class
End Namespace