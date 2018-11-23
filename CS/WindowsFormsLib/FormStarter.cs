using DevExpress.ExpressApp;
using DevExpress.Persistent.BaseImpl;
using DevExpress.XtraLayout;

using MyXafAppplication;
using MyXafModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsLib
{
    public class FormStarter
    {
        public FormStarter()
        {
            NonXafForm form = new NonXafForm();
            MyXafApplication winApplication = new MyXafApplication();
            winApplication.ConnectionString = AppConfigs.ConnectionString;
            winApplication.DatabaseUpdateMode = DatabaseUpdateMode.Never;
            winApplication.ApplicationName = "MyXafApplication";
            //  winApplication.ShowViewStrategy = new MyShowViewStrategy(winApplication);
            winApplication.Setup();
            if (winApplication.SplashScreen.IsStarted)
            {
                winApplication.SplashScreen.Stop();
            }

           // winApplication.Start(); //?


            IObjectSpace os = winApplication.CreateObjectSpace();
            ShowViewParameters svp = new ShowViewParameters();


            form.Text = "Form with the XAF ListView";

            LayoutControl layoutControl = new LayoutControl();
            layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            form.Controls.Add(layoutControl);

            LayoutControlItem item1 = layoutControl.Root.AddItem();
            TextBox textBox1 = new TextBox();
            item1.Text = "Company";
            item1.Control = textBox1;

            DevExpress.ExpressApp.View view = winApplication.CreateListView(os, typeof(Person), false);

            view.CreateControls();
            Frame frame = winApplication.CreateFrame(TemplateContext.NestedFrame);
            frame.CreateTemplate();
            frame.SetView(view);

            LayoutControlItem item2 = new LayoutControlItem();
            item2.Parent = layoutControl.Root;
            item2.Text = "Persons";
            item2.Control = (Control)frame.Template;



            form.ShowDialog();
        }
    }
}
