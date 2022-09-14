using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommonInterfacesClassLibrary.Interfaces;

namespace CommonUserControlLibrary.ViewModels {
    public class WebServiceFilterRsltViewModel: IWebServiceFilterRsltInterface, INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion
        protected string _fltrName;
        public string fltrName { get { return _fltrName; } set { if(_fltrName != value) { _fltrName = value; OnPropertyChanged(); } } }
        protected string _fltrDataType;
        public string fltrDataType { get { return _fltrDataType; } set { if(_fltrDataType != value) { _fltrDataType = value; OnPropertyChanged(); } } }
        protected string _fltrOperator;
        public string fltrOperator { get { return _fltrOperator; } set { if(_fltrOperator != value) { _fltrOperator = value; OnPropertyChanged(); } } }
        protected object _fltrValue;
        public object fltrValue { get { return _fltrValue; } set { if(_fltrValue != value) { _fltrValue = value; OnPropertyChanged(); } } }
        protected string _fltrError;
        public string fltrError { get { return _fltrError; } set { if(_fltrError != value) { _fltrError = value; OnPropertyChanged(); } } }
        protected bool _IsDestroyed = false; // memory leak issue
        public bool IsDestroyed { get { return _IsDestroyed; } set { if(_IsDestroyed != value) { _IsDestroyed = value; OnPropertyChanged(); } } }
    }
}

