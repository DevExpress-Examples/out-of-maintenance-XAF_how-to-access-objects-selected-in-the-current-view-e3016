Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Xpo
Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl

Namespace SelectedObjects.Module
	<DefaultClassOptions> _
	Public Class Contact
		Inherits Person
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub
		<SizeAttribute(SizeAttribute.Unlimited)> _
		Public Property Notes() As String
			Get
				Return GetPropertyValue(Of String)("Notes")
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)("Notes", value)
			End Set
		End Property
	End Class
End Namespace
