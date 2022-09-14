using System.ComponentModel;

namespace ModelInterfacesClassLibrary.Phonebook.PhbkEmployee {
    public interface IPhbkEmployeeViewNotify: IPhbkEmployeeView, INotifyPropertyChanged 
    {
    }
}

