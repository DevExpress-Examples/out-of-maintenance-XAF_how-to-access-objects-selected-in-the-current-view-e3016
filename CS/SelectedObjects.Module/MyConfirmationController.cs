using System;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.SystemModule;
using SelectedObjects.Module;


public class MyConfirmationController : ViewController {
    private string defaultMessage;
    DeleteObjectsViewController deleteObjectsViewController;
    public MyConfirmationController() {
        this.TargetObjectType = typeof(Contact);
    }
    protected override void OnActivated() {
        base.OnActivated();
        deleteObjectsViewController = Frame.GetController<DeleteObjectsViewController>();
        if (deleteObjectsViewController != null) {
            defaultMessage = deleteObjectsViewController.DeleteAction.GetFormattedConfirmationMessage();
            View.SelectionChanged += View_SelectionChanged;
            UpdateConfirmationMessage();                
        }
    }
    void View_SelectionChanged(object sender, System.EventArgs e) {
        UpdateConfirmationMessage();
    }
    private void UpdateConfirmationMessage() {
        if (View.SelectedObjects.Count == 1) {
            deleteObjectsViewController.DeleteAction.ConfirmationMessage =
                String.Format("You are about to delete the '{0}' Contact. Do you want to proceed?",
                ((Contact)View.CurrentObject).FullName);
        }
        else {
            deleteObjectsViewController.DeleteAction.ConfirmationMessage =
                String.Format("You are about to delete {0} Contacts. Do you want to proceed?",
                (View.SelectedObjects.Count));
        }
    }
    protected override void OnDeactivated() {
        base.OnDeactivated();
        if (deleteObjectsViewController != null) {
            View.SelectionChanged -= View_SelectionChanged;
            deleteObjectsViewController.DeleteAction.ConfirmationMessage = defaultMessage;
            deleteObjectsViewController = null;
        }
    }
}
