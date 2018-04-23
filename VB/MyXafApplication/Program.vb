Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Win
Imports DevExpress.ExpressApp.Xpo
Imports DevExpress.ExpressApp.Reports.Win
Imports DevExpress.ExpressApp.Security
Imports DevExpress.ExpressApp.Security.Strategy
Imports MyXafModule

Namespace MyXafAppplication
	Public Class MyXafApplication
		Inherits WinApplication
		Protected Overrides Sub CreateDefaultObjectSpaceProvider(ByVal args As CreateCustomObjectSpaceProviderEventArgs)
			args.ObjectSpaceProvider = New XPObjectSpaceProvider(ConnectionString, Connection)
		End Sub
		Protected Overrides Sub OnDatabaseVersionMismatch(ByVal args As DatabaseVersionMismatchEventArgs)
			args.Updater.Update()
			args.Handled = True
		End Sub
	End Class
	Friend NotInheritable Class Program
		Private Sub New()
		End Sub
		<STAThread> _
		Shared Sub Main()
			Dim myXafApplication As New MyXafApplication()
			myXafApplication.ApplicationName = "MyXafApplication"
			myXafApplication.ConnectionString = "Integrated Security=SSPI;Pooling=false;Data Source=(local);Initial Catalog=MyXafApplication"
			Dim authentication As New AuthenticationActiveDirectory() With {.CreateUserAutomatically = True}
			myXafApplication.Security = New SecurityStrategyComplex(GetType(SecuritySystemUser), GetType(SecuritySystemRole), authentication)
			myXafApplication.Modules.Add(New MyModule())
			myXafApplication.Modules.Add(New ReportsWindowsFormsModule())
			myXafApplication.Setup()
			myXafApplication.Start()
		End Sub
	End Class
End Namespace
