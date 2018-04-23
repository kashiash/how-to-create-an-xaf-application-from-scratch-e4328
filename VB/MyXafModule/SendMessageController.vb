Imports Microsoft.VisualBasic
Imports System
Imports System.Diagnostics
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base

Namespace MyXafModule
	Public Class SendMessageController
		Inherits ObjectViewController(Of ListView, Contact)
		Public Sub New()
			Dim sendMessageAction As New SimpleAction(Me, "SendMessage", PredefinedCategory.View)
			sendMessageAction.ImageName = "BO_Contact"
			sendMessageAction.SelectionDependencyType = SelectionDependencyType.RequireSingleObject
			AddHandler sendMessageAction.Execute, Function(sender, e) AnonymousMethod1(sender, e)
		End Sub
		
		Private Function AnonymousMethod1(ByVal sender As Object, ByVal e As SimpleActionExecuteEventArgs) As Boolean
			Dim startInfo As String = String.Format("mailto:{0}?body=Hello, {1}!%0A%0A", ViewCurrentObject.Email, ViewCurrentObject.Name)
			Process.Start(startInfo)
			Return True
		End Function
	End Class
End Namespace
