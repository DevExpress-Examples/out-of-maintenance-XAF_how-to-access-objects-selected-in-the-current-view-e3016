using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using System.Collections;
using System;

namespace SelectedObjects.Module {
    public class MyNotesController : ViewController {
        public MyNotesController() {
            SimpleAction myAction = new SimpleAction(this, "Salary Info", "Edit");
            myAction.SelectionDependencyType = SelectionDependencyType.RequireMultipleObjects;
            myAction.TargetObjectType = typeof(Contact);
            myAction.Execute += myAction_Execute;
            Actions.Add(myAction);
        }
        void myAction_Execute(object sender, SimpleActionExecuteEventArgs e) {
            ArrayList SelectedContacts = new ArrayList();
            if ((e.SelectedObjects.Count > 0) && (e.SelectedObjects[0] is XafDataViewRecord)) {
                foreach (var selectedObject in e.SelectedObjects) {
                    SelectedContacts.Add((Contact)ObjectSpace.GetObject(selectedObject));
                }
            }
            else {
                SelectedContacts = (ArrayList)e.SelectedObjects;
            }
            foreach (Contact selectedContact in SelectedContacts) {
                DateTime now = DateTime.Now;
                selectedContact.Notes += "\r\n[INFO] Your salary is transfered " +
                    now.ToString("M/d/yy") + " at " + now.ToString("hh:mm");
            }
            ObjectSpace.CommitChanges();
            ObjectSpace.Refresh();
        }
    }
}