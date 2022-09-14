using System.ComponentModel;
using System.Runtime.CompilerServices;

using CommonInterfacesClassLibrary.Interfaces;

namespace CommonUserControlLibrary.ViewModels {
    public class O2mListItemViewModel: IO2mListItemInterface, INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        protected string  _Caption = null;
        public string  Caption 
        { 
            get { return _Caption; }

            set { if(_Caption != value) {_Caption = value; OnPropertyChanged(); } }
        }

        string  _Region = null;
        public string  Region
        { 
            get { return _Region; }

            set { if(_Region != value) {_Region = value; OnPropertyChanged(); } }
        }

        string  _ForeignKeyDetails = null;
        public string  ForeignKeyDetails
        { 
            get { return _ForeignKeyDetails; }

            set { if(_ForeignKeyDetails != value) {_ForeignKeyDetails = value; OnPropertyChanged(); } }
        }

    }
}

