using DevExpress.Xpo;
using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;

namespace SelectedObjects.Module {
    [DefaultClassOptions]
    public class Contact : Person {
        public Contact(Session session) : base(session) { }
        [SizeAttribute(SizeAttribute.Unlimited)]
        public string Notes {
            get { return GetPropertyValue<string>("Notes"); }
            set { SetPropertyValue<string>("Notes", value); }
        }
    }
}
