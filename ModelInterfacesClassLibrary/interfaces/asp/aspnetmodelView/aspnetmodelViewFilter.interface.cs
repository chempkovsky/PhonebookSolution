using System.Collections.Generic;

namespace ModelInterfacesClassLibrary.interfaces.asp.aspnetmodelView {
    public interface IAspnetmodelViewFilter
    {
        IList<System.Int32>  ModelPk { get; set; }
        IList< string > modelPkOprtr { get; set; }
        IList<System.String>  ModelName { get; set; }
        IList< string > modelNameOprtr { get; set; }
        IList< string > orderby { get; set; }
        int? page { get; set; }
        int? pagesize { get; set; }
    }
}

