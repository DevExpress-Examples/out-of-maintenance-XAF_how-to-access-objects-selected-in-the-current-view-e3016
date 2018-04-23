Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.SystemModule

Namespace SelectedObjects.Module
	Public Class MyConfirmationController
		Inherits ViewController(Of DetailView)
		Private defaultMessage As String
		Protected Overrides Sub OnFrameAssigned()
			MyBase.OnFrameAssigned()
			TargetObjectType = GetType(Contact)
			defaultMessage = Frame.GetController(Of DeleteObjectsViewController)().DeleteAction.GetFormattedConfirmationMessage()
		End Sub
		Protected Overrides Sub OnActivated()
			MyBase.OnActivated()
			AddHandler View.CurrentObjectChanged, AddressOf View_CurrentObjectChanged
			View_CurrentObjectChanged(View, New System.EventArgs())
		End Sub
		Private Sub View_CurrentObjectChanged(ByVal sender As Object, ByVal e As System.EventArgs)
			Dim disableDeleteConfirmation As Boolean = String.IsNullOrEmpty((CType(View.CurrentObject, Contact)).Notes)
			If disableDeleteConfirmation Then
				Frame.GetController(Of DeleteObjectsViewController)().DeleteAction.ConfirmationMessage = ""
			Else
				Frame.GetController(Of DeleteObjectsViewController)().DeleteAction.ConfirmationMessage = defaultMessage
			End If
		End Sub
	End Class
End Namespace