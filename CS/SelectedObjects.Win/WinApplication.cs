using System;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.ExpressApp.Win;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp;

namespace SelectedObjects.Win {
    public partial class SelectedObjectsWindowsFormsApplication : WinApplication {
        public SelectedObjectsWindowsFormsApplication() {
            InitializeComponent();
            DelayedViewItemsInitialization = true;
        }

        private void SelectedObjectsWindowsFormsApplication_DatabaseVersionMismatch(object sender, DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs e) {
            e.Updater.Update();
            e.Handled = true;
        }
    }
}
