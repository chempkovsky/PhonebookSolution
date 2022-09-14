
using CommonInterfacesClassLibrary.Interfaces;

namespace CommonUserControlLibrary.Classes {
    public class WebServiceFilterRslt: IWebServiceFilterRsltInterface
    {
        public string fltrName { get; set; }
        public string fltrDataType { get; set; }
        public string fltrOperator { get; set; }
        public object fltrValue { get; set; }
        public string fltrError { get; set; }
        public bool   IsDestroyed { get; set; } // memory leak issue
    }
}

