using DevExpress.ExpressApp;

using DevExpress.ExpressApp.SystemModule;

namespace MyXafModule.Controllers
{
    public class ShowCustomStartupNavigationItemController : WindowController
    {
        private ShowNavigationItemController navigationController;
        public ShowCustomStartupNavigationItemController()
        {
            TargetWindowType = WindowType.Main;
        }

        private void WinShowNavigationItemController_StartupWindowShown(object sender, EventArgs e)
        {
            ((WinShowViewStrategyBase)Application.ShowViewStrategy).StartupWindowShown -= WinShowNavigationItemController_StartupWindowShown;
            var controller = Window.GetController<ShowNavigationItemController>();
            ShowStartupNavigationItem(controller);
        }
        protected virtual void ShowStartupNavigationItem(ShowNavigationItemController controller)
        {
            var args = Environment.GetCommandLineArgs();

            if (args.Length >= 2)
            {
                var sc = ViewShortcut.FromString(args[1]);

                var item = new ChoiceActionItem("CommandLineArgument", sc);
                controller.ShowNavigationItemAction.DoExecute(item);
            }
        }



        protected override void OnActivated()
        {
            base.OnActivated();
            navigationController = Frame.GetController<ShowNavigationItemController>();
            if (navigationController != null)
            {
                navigationController.CustomShowNavigationItem += OnCustomShowNavigationItem;
            }
        }
        void OnCustomShowNavigationItem(object sender, CustomShowNavigationItemEventArgs e)
        {
            navigationController.CustomShowNavigationItem -= OnCustomShowNavigationItem;//It is important to unsubscribe from this event immediately.
            ShowViewParameters svp = e.ActionArguments.ShowViewParameters;
            IObjectSpace os = Application.CreateObjectSpace();
            object theObjectToBeShown = os.FindObject<Contact>(null);
            DetailView dv = Application.CreateDetailView(os, theObjectToBeShown, true);
            dv.ViewEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.Edit;
            svp.CreatedView = dv;
            e.Handled = true;
        }
        protected override void OnDeactivated()
        {
            navigationController.CustomShowNavigationItem -= OnCustomShowNavigationItem;
            base.OnDeactivated();
        }
    }
}