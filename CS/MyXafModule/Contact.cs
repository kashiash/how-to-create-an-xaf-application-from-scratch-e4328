using DevExpress.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;

namespace MyXafModule {
    [DefaultClassOptions, ImageName("BO_Contact")]
    public class Contact : BaseObject {
        public Contact(Session session) : base(session) { }
        private string name;
        public string Name {
            get { return name; }
            set { SetPropertyValue("Name", ref name, value); }
        }
        private string email;
        public string Email {
            get { return email; }
            set { SetPropertyValue("Email", ref email, value); }
        }
    }
}