Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.SystemModule

Namespace SelectedObjects.Module
    Public Class MyConfirmationController
        Inherits ViewController(Of DetailView)

        Private defaultMessage As String
        Public Sub New()
            TargetObjectType = GetType(Contact)
        End Sub
        Protected Overrides Sub OnFrameAssigned()
            MyBase.OnFrameAssigned()
            defaultMessage = Frame.GetController(Of DeleteObjectsViewController)().DeleteAction.GetFormattedConfirmationMessage()
        End Sub
        Protected Overrides Sub OnActivated()
            MyBase.OnActivated()
            AddHandler View.CurrentObjectChanged, AddressOf View_CurrentObjectChanged
            View_CurrentObjectChanged(View, New System.EventArgs())
        End Sub
        Private Sub View_CurrentObjectChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim disableDeleteConfirmation As Boolean = String.IsNullOrEmpty(CType(View.CurrentObject, Contact).Notes)
            Frame.GetController(Of DeleteObjectsViewController)().DeleteAction.ConfirmationMessage = If(disableDeleteConfirmation, "", defaultMessage)
        End Sub
    End Class
End Namespace