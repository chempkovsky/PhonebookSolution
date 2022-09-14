

namespace CommonInterfacesClassLibrary.Interfaces {
    public interface IScopedRegionNavigationUserControlInterface
    {
        object DataContext { get; set; }
        object ScopedRegionManager { get; set; }
        string RequestNavigateSource { get; set; }
        string ScopedRegionName { get; set; }
    }
}

