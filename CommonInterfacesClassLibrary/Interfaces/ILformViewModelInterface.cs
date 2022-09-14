using System.Threading.Tasks;

namespace CommonInterfacesClassLibrary.Interfaces {
    public interface ILformViewModelInterface 
    {
        void HiddenFiltersPropertyChanged(object Sender, object OldValue, object NewValue);
        void RowMenuItemsPropertyChanged(object Sender, object OldValue, object NewValue);
        void TableMenuItemsPropertyChanged(object Sender, object OldValue, object NewValue);
        void CanAddPropertyChanged(object Sender, object OldValue, object NewValue);
        void CanUpdatePropertyChanged(object Sender, object OldValue, object NewValue);
        void CanDeletePropertyChanged(object Sender, object OldValue, object NewValue);
    }
}

