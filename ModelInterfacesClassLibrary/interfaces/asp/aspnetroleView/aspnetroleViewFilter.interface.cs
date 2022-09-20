using System.Collections.Generic;

namespace ModelInterfacesClassLibrary.interfaces.asp.aspnetroleView {
    public interface IAspnetroleViewFilter
    {
        IList<System.String>  Id { get; set; }
        IList< string > idOprtr { get; set; }
        IList<System.String>  Name { get; set; }
        IList< string > nameOprtr { get; set; }
        IList< string > orderby { get; set; }
        int? page { get; set; }
        int? pagesize { get; set; }
    }
}

