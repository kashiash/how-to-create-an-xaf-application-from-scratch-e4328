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

        protected override void OnActivated()
        {
            base.OnActivated();
            //navigationController = Frame.GetController<ShowNavigationItemController>();
            //if (navigationController != null)
            //{
            //    navigationController.CustomShowNavigationItem += OnCustomShowNavigationItem;
            //}
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
           // navigationController.CustomShowNavigationItem -= OnCustomShowNavigationItem;
            base.OnDeactivated();
        }
    }
}