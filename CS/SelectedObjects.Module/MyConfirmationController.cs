using DevExpress.ExpressApp;
using DevExpress.ExpressApp.SystemModule;

namespace SelectedObjects.Module {
    public class MyConfirmationController : ViewController<DetailView> {
        private string defaultMessage;
        public MyConfirmationController() {
            TargetObjectType = typeof(Contact);
        }
        protected override void OnFrameAssigned() {
            base.OnFrameAssigned();
            defaultMessage = Frame.GetController<DeleteObjectsViewController>().DeleteAction.
                GetFormattedConfirmationMessage();
        }
        protected override void OnActivated() {
            base.OnActivated();
            View.CurrentObjectChanged += View_CurrentObjectChanged;
            View_CurrentObjectChanged(View, new System.EventArgs());
        }
        void View_CurrentObjectChanged(object sender, System.EventArgs e) {
            bool disableDeleteConfirmation = string.IsNullOrEmpty(((Contact)View.CurrentObject).Notes);
            Frame.GetController<DeleteObjectsViewController>().DeleteAction.ConfirmationMessage =
                disableDeleteConfirmation ? "" : defaultMessage;
        }
    }
}