using System.ComponentModel;
using System.Runtime.CompilerServices;

using CommonInterfacesClassLibrary.Interfaces;

namespace CommonUserControlLibrary.ViewModels {
    public class ColumnSelectorItemDefViewModel: IColumnSelectorItemDefInterface, INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        string _Name=string.Empty;
        public string Name 
        { 
            get {
                return _Name; 
            } 
            set {
                if(_Name != value) {
                    _Name = value;
                    OnPropertyChanged();
                }
            }
        }

        string _Caption=string.Empty;
        public string Caption 
        { 
            get {
                return _Caption; 
            } 
            set {
                if(_Caption != value) {
                    _Caption = value;
                    OnPropertyChanged();
                }
            }
        }

        bool _IsChecked=false;
        public bool IsChecked 
        { 
            get {
                return _IsChecked; 
            } 
            set {
                if(_IsChecked != value) {
                    _IsChecked = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}

