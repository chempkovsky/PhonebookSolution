

using CommonInterfacesClassLibrary.Interfaces;

namespace CommonUserControlLibrary.Classes {
    public class WebServiceFilterDef: IWebServiceFilterDefInterface
    {
        public string  fltrName { get; set; }
        public string  fltrCaption { get; set; }
        public string  fltrDataType { get; set; }
        public int?    fltrMaxLen { get; set; }
        public object  fltrMin { get; set; }
        public object  fltrMax { get; set; }
    }
}

