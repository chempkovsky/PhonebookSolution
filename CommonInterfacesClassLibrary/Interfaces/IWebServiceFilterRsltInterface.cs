

namespace CommonInterfacesClassLibrary.Interfaces {
    public interface IWebServiceFilterRsltInterface
    {
        string  fltrName { get; set; }
        string  fltrDataType { get; set; }
        string  fltrOperator { get; set; }
        object  fltrValue { get; set; }
        string  fltrError { get; set; }
        bool    IsDestroyed { get; set; } // memory leak issue
    }
}

