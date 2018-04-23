using System;
using System.Diagnostics;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;

namespace MyXafModule {
    public class SendMessageController : ObjectViewController<ListView, Contact> {
        public SendMessageController() {
            SimpleAction sendMessageAction = new SimpleAction(this, "SendMessage", PredefinedCategory.View);
            sendMessageAction.ImageName = "BO_Contact";
            sendMessageAction.SelectionDependencyType = SelectionDependencyType.RequireSingleObject;
            sendMessageAction.Execute += delegate(object sender, SimpleActionExecuteEventArgs e) {
                string startInfo = String.Format(
                    "mailto:{0}?body=Hello, {1}!%0A%0A", ViewCurrentObject.Email, ViewCurrentObject.Name);
                Process.Start(startInfo);
            };
        }
    }
}
