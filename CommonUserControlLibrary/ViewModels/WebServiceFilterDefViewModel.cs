using System.ComponentModel;
using System.Runtime.CompilerServices;

using CommonInterfacesClassLibrary.Interfaces;

namespace CommonUserControlLibrary.ViewModels {
    public class WebServiceFilterDefViewModel: IWebServiceFilterDefInterface, INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion
        protected string _fltrName;
        public string  fltrName { get { return _fltrName; } set { if(_fltrName != value) { _fltrName = value; OnPropertyChanged(); } } }
        protected string _fltrCaption;
        public string  fltrCaption { get { return _fltrCaption; } set { if(_fltrCaption != value) { _fltrCaption = value; OnPropertyChanged(); } } }
        protected string _fltrDataType;
        public string  fltrDataType { get { return _fltrDataType; } set { if(_fltrDataType != value) { _fltrDataType = value; OnPropertyChanged(); } } }
        protected int? _fltrMaxLen;
        public int?    fltrMaxLen { get { return _fltrMaxLen; } set { if(_fltrMaxLen != value) { _fltrMaxLen = value; OnPropertyChanged(); } } }
        protected object _fltrMin;
        public object fltrMin { get { return _fltrMin; } set { if(_fltrMin != value) { _fltrMin = value; OnPropertyChanged(); } } }
        protected object _fltrMax;
        public object fltrMax { get { return _fltrMax; } set { if(_fltrMax != value) { _fltrMax = value; OnPropertyChanged(); } } }
    }
}

