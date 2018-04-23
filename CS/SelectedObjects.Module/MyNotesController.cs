using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;

namespace SelectedObjects.Module {
    public class MyNotesController : ViewController {
        SimpleAction myAction;
        public MyNotesController() {
            myAction = new SimpleAction(this, "Add a note", "RecordEdit");
            myAction.SelectionDependencyType = SelectionDependencyType.RequireMultipleObjects;
            myAction.TargetObjectType = typeof(Contact);            
            myAction.Execute += myAction_Execute;
            Actions.Add(myAction);
        }
        void myAction_Execute(object sender, SimpleActionExecuteEventArgs e) {            
            foreach (Contact selectedObject in e.SelectedObjects)
                selectedObject.Notes += System.Environment.NewLine + "additional note";            
            if (View is DetailView && ((DetailView)View).ViewEditMode == ViewEditMode.View)
                View.ObjectSpace.CommitChanges();
        }
    }
}