using System.Collections.Generic;
using ModelInterfacesClassLibrary.interfaces.asp.aspnetroleView;

namespace ModelServicesPrismModule.asp.aspnetroleView {
    public class AspnetroleViewFilter: IAspnetroleViewFilter 
    {
        public IList<System.String>  Id { get; set; }
        public IList< string > idOprtr { get; set; }
        public IList<System.String>  Name { get; set; }
        public IList< string > nameOprtr { get; set; }
        public IList< string > orderby { get; set; }
        public int? page { get; set; }
        public int? pagesize { get; set; }
    }
}

