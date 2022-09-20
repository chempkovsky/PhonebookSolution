using System.Collections.Generic;
using ModelInterfacesClassLibrary.interfaces.asp.aspnetuserView;

namespace ModelServicesPrismModule.asp.aspnetuserView {
    public class AspnetuserViewFilter: IAspnetuserViewFilter 
    {
        public IList<System.String>  Id { get; set; }
        public IList< string > idOprtr { get; set; }
        public IList<System.String>  Email { get; set; }
        public IList< string > emailOprtr { get; set; }
        public IList<System.String>  PhoneNumber { get; set; }
        public IList< string > phoneNumberOprtr { get; set; }
        public IList<System.String>  UserName { get; set; }
        public IList< string > userNameOprtr { get; set; }
        public IList< string > orderby { get; set; }
        public int? page { get; set; }
        public int? pagesize { get; set; }
    }
}

