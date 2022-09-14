using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommonInterfacesClassLibrary.Interfaces;

namespace CommonUserControlLibrary.ViewModels {
    public class WebServiceFilterOperatorViewModel: IWebServiceFilterOperatorInterface, INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion
        protected string _oName;
        public string oName { get { return _oName; } set { if(_oName != value) { _oName = value; OnPropertyChanged(); } } }
        protected string _oCaption;
        public string oCaption { get { return _oCaption; } set { if(_oCaption != value) { _oCaption = value; OnPropertyChanged(); } } }
    }
}

