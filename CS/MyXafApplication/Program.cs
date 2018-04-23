using System;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Win;
using DevExpress.ExpressApp.Xpo;
using DevExpress.ExpressApp.Reports.Win;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Security.Strategy;
using MyXafModule;

namespace MyXafAppplication {
    public class MyXafApplication : WinApplication {
        protected override void CreateDefaultObjectSpaceProvider(CreateCustomObjectSpaceProviderEventArgs args) {
            args.ObjectSpaceProvider = new XPObjectSpaceProvider(ConnectionString, Connection);
        }
        protected override void OnDatabaseVersionMismatch(DatabaseVersionMismatchEventArgs args) {
            args.Updater.Update();
            args.Handled = true;
        }
    }
    static class Program {
        [STAThread]
        static void Main() {
            MyXafApplication myXafApplication = new MyXafApplication();
            myXafApplication.ApplicationName = "MyXafApplication";
            myXafApplication.ConnectionString = "Integrated Security=SSPI;Pooling=false;Data Source=(local);Initial Catalog=MyXafApplication";
            AuthenticationActiveDirectory authentication = new AuthenticationActiveDirectory() { CreateUserAutomatically = true};
            myXafApplication.Security = new SecurityStrategyComplex(typeof(SecuritySystemUser), typeof(SecuritySystemRole), authentication);
            myXafApplication.Modules.Add(new MyModule());
            myXafApplication.Modules.Add(new ReportsWindowsFormsModule());
            myXafApplication.Setup();
            myXafApplication.Start();
        }
    }
}
