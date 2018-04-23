Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports DevExpress.Data.Filtering
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Updating

Namespace MyXafModule
	Public Class MyModuleUpdater
		Inherits ModuleUpdater
		Public Sub New(ByVal objectSpace As IObjectSpace, ByVal currentDBVersion As Version)
			MyBase.New(objectSpace, currentDBVersion)
		End Sub
		Public Overrides Sub UpdateDatabaseAfterUpdateSchema()
			MyBase.UpdateDatabaseAfterUpdateSchema()
			Dim contactJane As Contact = ObjectSpace.FindObject(Of Contact)(New BinaryOperator("Name", "Jane Smith"))
			If contactJane Is Nothing Then
				contactJane = ObjectSpace.CreateObject(Of Contact)()
				contactJane.Name = "Jane Smith"
				contactJane.Email = "jane.smith@example.com"
			End If
			Dim contactJohn As Contact = ObjectSpace.FindObject(Of Contact)(New BinaryOperator("Name", "John Smith"))
			If contactJohn Is Nothing Then
				contactJohn = ObjectSpace.CreateObject(Of Contact)()
				contactJohn.Name = "John Smith"
				contactJohn.Email = "john.smith@example.com"
			End If
		End Sub
	End Class
End Namespace
