using System.Threading.Tasks;

namespace CommonInterfacesClassLibrary.Interfaces {
    public interface ISformViewModelInterface 
    {
        void SformAfterAddItemCommand(object Sender, object item);
        void SformAfterUpdItemCommand(object Sender, object item);
        void SformAfterDelItemCommand(object Sender, object item);

        Task HiddenFiltersPropertyChanged(object Sender, object OldValue, object NewValue);
        void RowMenuItemsPropertyChanged(object Sender, object OldValue, object NewValue);
        void TableMenuItemsPropertyChanged(object Sender, object OldValue, object NewValue);
    }
}

