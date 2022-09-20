using System.Collections.Generic;
using ModelInterfacesClassLibrary.interfaces.asp.aspnetrolemaskView;

namespace ModelServicesPrismModule.asp.aspnetrolemaskView {
    public class AspnetrolemaskViewFilter: IAspnetrolemaskViewFilter 
    {
        public IList<System.Int32>  ModelPkRef { get; set; }
        public IList< string > modelPkRefOprtr { get; set; }
        public IList<System.String>  MModelName { get; set; }
        public IList< string > mModelNameOprtr { get; set; }
        public IList<System.String>  RName { get; set; }
        public IList< string > rNameOprtr { get; set; }
        public IList< string > orderby { get; set; }
        public int? page { get; set; }
        public int? pagesize { get; set; }
    }
}

