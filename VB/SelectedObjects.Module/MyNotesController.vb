Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.ExpressApp.Editors
Imports System.Collections
Imports System

Namespace SelectedObjects.Module
    Public Class MyNotesController
        Inherits ViewController

        Public Sub New()
            Dim myAction As New SimpleAction(Me, "Salary Info", "Edit")
            myAction.SelectionDependencyType = SelectionDependencyType.RequireMultipleObjects
            myAction.TargetObjectType = GetType(Contact)
            AddHandler myAction.Execute, AddressOf myAction_Execute
            Actions.Add(myAction)
        End Sub
        Private Sub myAction_Execute(ByVal sender As Object, ByVal e As SimpleActionExecuteEventArgs)
            Dim SelectedContacts As New ArrayList()
            If (e.SelectedObjects.Count > 0) AndAlso (TypeOf e.SelectedObjects(0) Is XafDataViewRecord) Then
                For Each selectedObject In e.SelectedObjects
                    SelectedContacts.Add(CType(ObjectSpace.GetObject(selectedObject), Contact))
                Next selectedObject
            Else
                SelectedContacts = CType(e.SelectedObjects, ArrayList)
            End If
            For Each selectedContact As Contact In SelectedContacts
                Dim now As Date = Date.Now
                selectedContact.Notes &= ControlChars.CrLf & "[INFO] Your salary is transfered " & now.ToString("M/d/yy") & " at " & now.ToString("hh:mm")
            Next selectedContact
            ObjectSpace.CommitChanges()
            ObjectSpace.Refresh()
        End Sub
    End Class
End Namespace