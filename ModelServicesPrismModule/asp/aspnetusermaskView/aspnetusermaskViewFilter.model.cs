using System.Collections.Generic;
using ModelInterfacesClassLibrary.interfaces.asp.aspnetusermaskView;

namespace ModelServicesPrismModule.asp.aspnetusermaskView {
    public class AspnetusermaskViewFilter: IAspnetusermaskViewFilter 
    {
        public IList<System.String>  UserId { get; set; }
        public IList< string > userIdOprtr { get; set; }
        public IList< string > orderby { get; set; }
        public int? page { get; set; }
        public int? pagesize { get; set; }
    }
}

