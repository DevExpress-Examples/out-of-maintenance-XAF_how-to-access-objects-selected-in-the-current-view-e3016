Imports Microsoft.VisualBasic
Imports System

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Updating
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Imports DevExpress.Persistent.BaseImpl

Namespace SelectedObjects.Module
	Public Class Updater
		Inherits ModuleUpdater
		Public Sub New(ByVal objectSpace As ObjectSpace, ByVal currentDBVersion As Version)
			MyBase.New(objectSpace, currentDBVersion)
		End Sub
		Public Overrides Sub UpdateDatabaseAfterUpdateSchema()
			MyBase.UpdateDatabaseAfterUpdateSchema()
			Dim Sam As Contact = ObjectSpace.CreateObject(Of Contact)()
			Sam.FirstName = "Sam"
			Sam.Save()
			Dim John As Contact = ObjectSpace.CreateObject(Of Contact)()
			John.FirstName = "John"
			John.Notes = "note"
			John.Save()
		End Sub
	End Class
End Namespace
