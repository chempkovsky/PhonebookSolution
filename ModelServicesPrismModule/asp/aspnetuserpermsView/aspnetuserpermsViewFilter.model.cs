using System.Collections.Generic;
using ModelInterfacesClassLibrary.interfaces.asp.aspnetuserpermsView;

namespace ModelServicesPrismModule.asp.aspnetuserpermsView {
    public class AspnetuserpermsViewFilter: IAspnetuserpermsViewFilter 
    {
        public IList< string > orderby { get; set; }
        public int? page { get; set; }
        public int? pagesize { get; set; }
    }
}

