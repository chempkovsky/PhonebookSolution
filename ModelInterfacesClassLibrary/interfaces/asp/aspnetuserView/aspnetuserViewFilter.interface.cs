using System.Collections.Generic;

namespace ModelInterfacesClassLibrary.interfaces.asp.aspnetuserView {
    public interface IAspnetuserViewFilter
    {
        IList<System.String>  Id { get; set; }
        IList< string > idOprtr { get; set; }
        IList<System.String>  Email { get; set; }
        IList< string > emailOprtr { get; set; }
        IList<System.String>  PhoneNumber { get; set; }
        IList< string > phoneNumberOprtr { get; set; }
        IList<System.String>  UserName { get; set; }
        IList< string > userNameOprtr { get; set; }
        IList< string > orderby { get; set; }
        int? page { get; set; }
        int? pagesize { get; set; }
    }
}

