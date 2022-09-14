

namespace CommonInterfacesClassLibrary.Interfaces {
    public interface IWebServiceFilterDefInterface
    {
        string  fltrName { get; set; }
        string  fltrCaption { get; set; }
        string  fltrDataType { get; set; }
        int?    fltrMaxLen { get; set; }
        object  fltrMin { get; set; }
        object  fltrMax { get; set; }
    }
}

