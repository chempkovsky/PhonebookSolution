using System.Collections.Generic;

namespace ModelInterfacesClassLibrary.interfaces.asp.aspnetrolemaskView {
    public interface IAspnetrolemaskViewFilter
    {
        IList<System.Int32>  ModelPkRef { get; set; }
        IList< string > modelPkRefOprtr { get; set; }
        IList<System.String>  MModelName { get; set; }
        IList< string > mModelNameOprtr { get; set; }
        IList<System.String>  RName { get; set; }
        IList< string > rNameOprtr { get; set; }
        IList< string > orderby { get; set; }
        int? page { get; set; }
        int? pagesize { get; set; }
    }
}

