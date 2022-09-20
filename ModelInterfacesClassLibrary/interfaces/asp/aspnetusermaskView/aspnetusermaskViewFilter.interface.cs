using System.Collections.Generic;

namespace ModelInterfacesClassLibrary.interfaces.asp.aspnetusermaskView {
    public interface IAspnetusermaskViewFilter
    {
        IList<System.String>  UserId { get; set; }
        IList< string > userIdOprtr { get; set; }
        IList< string > orderby { get; set; }
        int? page { get; set; }
        int? pagesize { get; set; }
    }
}

