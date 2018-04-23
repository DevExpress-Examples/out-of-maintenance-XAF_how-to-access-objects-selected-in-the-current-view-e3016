using System;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Updating;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.BaseImpl;

namespace SelectedObjects.Module {
    public class Updater : ModuleUpdater {
        public Updater(IObjectSpace objectSpace, Version currentDBVersion) : base(objectSpace, currentDBVersion) { }
        public override void UpdateDatabaseAfterUpdateSchema() {
            base.UpdateDatabaseAfterUpdateSchema();
            Contact Sam = ObjectSpace.CreateObject<Contact>();
            Sam.FirstName = "Sam";
            Sam.Save();
            Contact John = ObjectSpace.CreateObject<Contact>();
            John.FirstName = "John";
            John.Notes = "note";
            John.Save();
        }
    }
}
