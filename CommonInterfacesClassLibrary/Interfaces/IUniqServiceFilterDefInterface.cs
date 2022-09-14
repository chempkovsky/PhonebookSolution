

namespace CommonInterfacesClassLibrary.Interfaces {
    public interface IUniqServiceFilterDefInterface
    {
        string  fltrName { get; set; }
        string  fltrDispMemb { get; set; }
        string  fltrTextMemb { get; set; }
        string  fltrCaption { get; set; }
        string  fltrDataType { get; set; }
        int?    fltrMaxLen { get; set; }
        object  fltrMin { get; set; }
        object  fltrMax { get; set; }
    }
}

