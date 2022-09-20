using System.Collections.Generic;

namespace ModelInterfacesClassLibrary.interfaces.asp.aspnetuserpermsView {
    public interface IAspnetuserpermsViewFilter
    {
        IList< string > orderby { get; set; }
        int? page { get; set; }
        int? pagesize { get; set; }
    }
}

