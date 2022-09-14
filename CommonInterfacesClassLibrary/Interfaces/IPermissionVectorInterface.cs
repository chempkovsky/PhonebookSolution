using System.Windows.Input;

namespace CommonInterfacesClassLibrary.Interfaces {
    public interface IPermissionVectorInterface 
    {
        void PermissionVectorPropertyChanged(object Sender, object OldValue, object NewValue);
        void IsPermissionEditablePropertyChanged(object Sender, object OldValue, object NewValue);
        ICommand PermissionChangedCommand { get; }
    }
}

