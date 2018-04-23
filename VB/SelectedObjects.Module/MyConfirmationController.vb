Imports System
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.SystemModule
Imports SelectedObjects.Module


Public Class MyConfirmationController
    Inherits ViewController

    Private defaultMessage As String
    Private deleteObjectsViewController As DeleteObjectsViewController
    Public Sub New()
        Me.TargetObjectType = GetType(Contact)
    End Sub
    Protected Overrides Sub OnActivated()
        MyBase.OnActivated()
        deleteObjectsViewController = Frame.GetController(Of DeleteObjectsViewController)()
        If deleteObjectsViewController IsNot Nothing Then
            defaultMessage = deleteObjectsViewController.DeleteAction.GetFormattedConfirmationMessage()
            AddHandler View.SelectionChanged, AddressOf View_SelectionChanged
            UpdateConfirmationMessage()
        End If
    End Sub
    Private Sub View_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        UpdateConfirmationMessage()
    End Sub
    Private Sub UpdateConfirmationMessage()
        If View.SelectedObjects.Count = 1 Then
            deleteObjectsViewController.DeleteAction.ConfirmationMessage = String.Format("You are about to delete the '{0}' Contact. Do you want to proceed?", CType(View.CurrentObject, Contact).FullName)
        Else
            deleteObjectsViewController.DeleteAction.ConfirmationMessage = String.Format("You are about to delete {0} Contacts. Do you want to proceed?", (View.SelectedObjects.Count))
        End If
    End Sub
    Protected Overrides Sub OnDeactivated()
        MyBase.OnDeactivated()
        If deleteObjectsViewController IsNot Nothing Then
            RemoveHandler View.SelectionChanged, AddressOf View_SelectionChanged
            deleteObjectsViewController.DeleteAction.ConfirmationMessage = defaultMessage
            deleteObjectsViewController = Nothing
        End If
    End Sub
End Class
