using System;
using System.Collections.Generic;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Updating;

namespace MyXafModule {
    public class MyModuleUpdater : ModuleUpdater {
        public MyModuleUpdater(IObjectSpace objectSpace, Version currentDBVersion) :
            base(objectSpace, currentDBVersion) { }
        public override void UpdateDatabaseAfterUpdateSchema() {
            base.UpdateDatabaseAfterUpdateSchema();
            Contact contactJane = ObjectSpace.FindObject<Contact>(
                new BinaryOperator("Name", "Jane Smith"));
            if (contactJane == null) {
                contactJane = ObjectSpace.CreateObject<Contact>();
                contactJane.Name = "Jane Smith";
                contactJane.Email = "jane.smith@example.com";
            }
            Contact contactJohn = ObjectSpace.FindObject<Contact>(
                new BinaryOperator("Name", "John Smith"));
            if (contactJohn == null) {
                contactJohn = ObjectSpace.CreateObject<Contact>();
                contactJohn.Name = "John Smith";
                contactJohn.Email = "john.smith@example.com";
            }
        }
    }
}
