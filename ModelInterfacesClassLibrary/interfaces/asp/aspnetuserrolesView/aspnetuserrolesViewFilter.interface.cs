using System.Collections.Generic;

namespace ModelInterfacesClassLibrary.interfaces.asp.aspnetuserrolesView {
    public interface IAspnetuserrolesViewFilter
    {
        IList<System.String>  UserId { get; set; }
        IList< string > userIdOprtr { get; set; }
        IList<System.String>  RoleId { get; set; }
        IList< string > roleIdOprtr { get; set; }
        IList<System.String>  UUserName { get; set; }
        IList< string > uUserNameOprtr { get; set; }
        IList<System.String>  RName { get; set; }
        IList< string > rNameOprtr { get; set; }
        IList< string > orderby { get; set; }
        int? page { get; set; }
        int? pagesize { get; set; }
    }
}

