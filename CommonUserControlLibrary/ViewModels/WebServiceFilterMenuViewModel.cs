using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using CommonInterfacesClassLibrary.Interfaces;

namespace CommonUserControlLibrary.ViewModels {
    public class WebServiceFilterMenuViewModel: IWebServiceFilterMenuInterface, INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion
        protected string _Id;
        public string Id { get { return _Id; } set { if(_Id != value) { _Id = value; OnPropertyChanged(); } } }
        protected string _Caption;
        public string Caption { get { return _Caption; } set { if(_Caption != value) { _Caption = value; OnPropertyChanged(); } } }
        protected string _IconName;
        public string IconName { get { return _IconName; } set { if(_IconName != value) { _IconName = value; OnPropertyChanged(); } } }
        protected Color _IconColor;
        public Color IconColor { get { return _IconColor; } set { if(_IconColor != value) { _IconColor = value; OnPropertyChanged(); } } }
        protected bool _Enabled;
        public bool Enabled { get { return _Enabled; } set { if(_Enabled != value) { _Enabled = value; OnPropertyChanged(); } } }
        protected object _Data;
        public object Data { get { return _Data; } set { if(_Data != value) { _Data = value; OnPropertyChanged(); } } }
        protected object  _FeedbackData;
        public object  FeedbackData { get { return _FeedbackData; } set { if (_FeedbackData != value) { _FeedbackData = value; OnPropertyChanged(); } } }
        protected ICommand  _Command;
        public ICommand  Command { get { return _Command; } set { if (_Command != value) { _Command = value; OnPropertyChanged(); } } }
        protected bool _IsDestroyed = false;
        public bool IsDestroyed { get { return _IsDestroyed; } set { if(_IsDestroyed != value) { _IsDestroyed = value; OnPropertyChanged(); } } }
    }
}

