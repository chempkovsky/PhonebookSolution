using System.Collections.Generic;
using ModelInterfacesClassLibrary.interfaces.asp.aspnetmodelView;

namespace ModelServicesPrismModule.asp.aspnetmodelView {
    public class AspnetmodelViewFilter: IAspnetmodelViewFilter 
    {
        public IList<System.Int32>  ModelPk { get; set; }
        public IList< string > modelPkOprtr { get; set; }
        public IList<System.String>  ModelName { get; set; }
        public IList< string > modelNameOprtr { get; set; }
        public IList< string > orderby { get; set; }
        public int? page { get; set; }
        public int? pagesize { get; set; }
    }
}

