
using System;
using Xamarin.Forms;
using System.ComponentModel;
using System.Windows.Input;
using Prism.Navigation;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Linq;
using CommonInterfacesClassLibrary.AppGlblLoginSrvc;
using CommonInterfacesClassLibrary.Interfaces;
using CommonInterfacesClassLibrary.AppGlblSettingsSrvc;

/*

    "ChngpswdUserPageViewModel" UserControl is defined in the "CommonServicesPrismModule"-project.
    In the file of IModule-class of "CommonServicesPrismModule"-project the following line of code must be inserted:


        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ...

            ViewModelLocationProvider.Register<ChngpswdUserPage, ChngpswdUserPageViewModel>();
            containerRegistry.RegisterForNavigation<ChngpswdUserPage, ChngpswdUserPageViewModel>("ChngpswdUserPage");
            ...
        }

*/

namespace CommonServicesPrismModule.ViewModels {
    public class ChngpswdUserPageViewModel: INotifyPropertyChanged, INotifyDataErrorInfo, IDestructible    
    {
        IAppGlblSettingsService _GlblSettingsSrv;
        IAppGlblLoginService _GlblLoginSrv;
//        protected INavigationService _navigationService;

        public ChngpswdUserPageViewModel(IAppGlblLoginService GlblLoginSrv, IAppGlblSettingsService GlblSettingsSrv) {
            _GlblLoginSrv = GlblLoginSrv;
            _GlblSettingsSrv = GlblSettingsSrv;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion
        #region INotifyDataErrorInfo
        Dictionary<string, ICollection<string>> ValidationErrors = new Dictionary<string, ICollection<string>>();
        public bool HasErrors { get { return (ValidationErrors.Count > 0) || (ValidationErrors.Count > 0); } }
        public System.Collections.IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName)) {
                return null;
            }
            if(ValidationErrors.ContainsKey(propertyName)) 
                return ValidationErrors[propertyName];
            return null;
        }
        
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        private void RaiseErrorsChanged(string propertyName)
        {
            //if (ErrorsChanged != null)
            //    ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
            OnPropertyChanged(propertyName + "Error");
        }
        public void ValidateField(object value, [CallerMemberName] string filedName = null) {
            if (string.IsNullOrEmpty(filedName)) return;
            string stringValue = value as string;
            string ErrorMsg = null;
            IList<string> rslt = null;
            switch(filedName) {
            

                case "OldPassWord":
                    if (string.IsNullOrEmpty(stringValue)) {
                        ErrorMsg = "OldPassWord is a required filed";
                    } else if (stringValue.Length < 6) {
                        ErrorMsg = "OldPassWord.Length must be large than 5";
                    }
                    break;
                case "PassWord":
                    if (string.IsNullOrEmpty(stringValue)) {
                        ErrorMsg = "PassWord is a required filed";
                    } else if (stringValue.Length < 6) {
                        ErrorMsg = "PassWord.Length must be large than 5";
                    } else if (PassWord != ConfirmPassWord) {
                        ErrorMsg = "PassWord and ConfirmPassWord must be identical";
                    }
                    break;
                case "ConfirmPassWord":
                    if (string.IsNullOrEmpty(stringValue)) {
                        ErrorMsg = "ConfirmPassWord is a required filed";
                    } else if (stringValue.Length < 6) {
                        ErrorMsg = "ConfirmPassWord.Length must be large than 5";
                    } else if (PassWord != ConfirmPassWord) {
                        ErrorMsg = "PassWord and ConfirmPassWord must be identical";
                    }
                    break;
                default:
                    break;
            }
            if (!string.IsNullOrEmpty(ErrorMsg)) {
                rslt = new List<string>() { ErrorMsg };
            }
            bool hasErrors = rslt != null;
            hasErrors = hasErrors ? (rslt.Count > 0) : false;
            if(hasErrors) {
                ValidationErrors[filedName] = rslt;
                RaiseErrorsChanged(filedName);
            } else {
                if(ValidationErrors.ContainsKey(filedName))  {
                    ValidationErrors.Remove(filedName);
                    RaiseErrorsChanged(filedName);
                }
            }
        }
        public string GetFirstError(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName)) {
                return "";
            }
            string str = null;
            if(ValidationErrors.ContainsKey(propertyName)) 
                str = ValidationErrors[propertyName].FirstOrDefault(i => !string.IsNullOrEmpty(i));
            return str==null ? "" : str;
        }
        #endregion
        #region OldPassWord
        protected string _OldPassWord = "";
        public string OldPassWord 
        {
            get { return _OldPassWord; }
            set
            {
                if (OldPassWord != value) {
                    _OldPassWord = value;
                    OnPropertyChanged();
                    ValidateField(value);
                }
            }
        }
        public string OldPassWordPropmpt {
            get { return "Enter Old Password"; }
        }
        public string OldPassWordCaption {
            get { return "Old Password"; }
        }
        #endregion
        #region PassWord
        protected string _PassWord = "";
        public string PassWord 
        {
            get { return _PassWord; }
            set
            {
                if (PassWord != value) {
                    _PassWord = value;
                    OnPropertyChanged();
                    ValidateField(value);
                    ValidateField(ConfirmPassWord, "ConfirmPassWord");
                }
            }
        }
        public string PassWordPropmpt {
            get { return "Enter Password"; }
        }
        public string PassWordCaption {
            get { return "Password"; }
        }
        #endregion
        #region ConfirmPassWord
        protected string _ConfirmPassWord = "";
        public string ConfirmPassWord 
        {
            get { return _ConfirmPassWord; }
            set
            {
                if (ConfirmPassWord != value) {
                    _ConfirmPassWord = value;
                    OnPropertyChanged();
                    ValidateField(value);
                    ValidateField(PassWord, "PassWord");
                }
            }
        }
        public string ConfirmPassWordPropmpt {
            get { return "Repeat Password"; }
        }
        public string ConfirmPassWordCaption {
            get { return "Confirm Password"; }
        }
        #endregion
        #region OldPassWordError
        public string OldPassWordError {
            get 
            {
                return GetFirstError("OldPassWord");
            }
        }
        #endregion
        #region PassWordError
        public string PassWordError {
            get 
            {
                return GetFirstError("PassWord");
            }
        }
        #endregion
        #region ConfirmPassWordError
        public string ConfirmPassWordError {
            get 
            {
                return GetFirstError("ConfirmPassWord");
            }
        }
        #endregion
        #region OldPassWordIsPassword
        protected bool _OldPassWordIsPassword = true;
        public bool OldPassWordIsPassword 
        {
            get { return _OldPassWordIsPassword; }
            set
            {
                if (OldPassWordIsPassword != value) {
                    _OldPassWordIsPassword = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion
        #region PassWordIsPassword
        protected bool _PassWordIsPassword = true;
        public bool PassWordIsPassword 
        {
            get { return _PassWordIsPassword; }
            set
            {
                if (PassWordIsPassword != value) {
                    _PassWordIsPassword = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion
        #region ConfirmPassWordIsPassword
        protected bool _ConfirmPassWordIsPassword = true;
        public bool ConfirmPassWordIsPassword 
        {
            get { return _ConfirmPassWordIsPassword; }
            set
            {
                if (ConfirmPassWordIsPassword != value) {
                    _ConfirmPassWordIsPassword = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion
        #region CancelCommand
        private ICommand _CancelCommand;
        public ICommand CancelCommand
        {
            get
            {
                return _CancelCommand ?? (_CancelCommand = new Command((param) => CancelCommandAction(param), (param) => CancelCommandCanExecute(param)));
            }
        }
        protected async void CancelCommandAction(object param)
        {
            // await _navigationService.NavigateAsync("HomePage");
            if(_GlblSettingsSrv != null) {
                _GlblSettingsSrv.NavigateTo("HomePage");
            }
        }
        protected bool CancelCommandCanExecute(object param)
        {
            return true;
        }
        #endregion
        #region OkCommand
        private ICommand _OkCommand;
        public ICommand OkCommand
        {
            get
            {
                return _OkCommand ?? (_OkCommand = new Command((param) => OkCommandAction(param), (param) => OkCommandCanExecute(param)));
            }
        }
        protected async void OkCommandAction(object param)
        {
            ValidateField(OldPassWord, "OldPassWord");
            ValidateField(PassWord, "PassWord");
            ValidateField(ConfirmPassWord, "ConfirmPassWord");
            if (HasErrors) return;
            IChangePasswordModel model = await _GlblLoginSrv.ChangePassword(OldPassWord, PassWord, ConfirmPassWord);
            if (model == null) return;
            // await _navigationService.NavigateAsync("HomePage");
            if(_GlblSettingsSrv != null) {
                _GlblSettingsSrv.NavigateTo("HomePage");
            }
        }
        protected bool OkCommandCanExecute(object param)
        {
            return true;
        }
        #endregion
        #region OldPassWordShowCommand
        private ICommand _OldPassWordShowCommand=null;
        public ICommand OldPassWordShowCommand
        {
            get
            {
                return _OldPassWordShowCommand ?? (_OldPassWordShowCommand = new Command((param) => OldPassWordShowAction(param), (param) => OldPassWordShowCanExecute(param)));
            }
        }
        protected void OldPassWordShowAction(object param)
        {
            OldPassWordIsPassword = ! OldPassWordIsPassword;
        }
        protected bool OldPassWordShowCanExecute(object param)
        {
            return true;
        }
        #endregion
        #region PassWordShowCommand
        private ICommand _PassWordShowCommand=null;
        public ICommand PassWordShowCommand
        {
            get
            {
                return _PassWordShowCommand ?? (_PassWordShowCommand = new Command((param) => PassWordShowAction(param), (param) => PassWordShowCanExecute(param)));
            }
        }
        protected void PassWordShowAction(object param)
        {
            PassWordIsPassword = ! PassWordIsPassword;
        }
        protected bool PassWordShowCanExecute(object param)
        {
            return true;
        }
        #endregion
        #region ConfirmPassWordShowCommand
        private ICommand _ConfirmPassWordShowCommand=null;
        public ICommand ConfirmPassWordShowCommand
        {
            get
            {
                return _ConfirmPassWordShowCommand ?? (_ConfirmPassWordShowCommand = new Command((param) => ConfirmPassWordShowAction(param), (param) => ConfirmPassWordShowCanExecute(param)));
            }
        }
        protected void ConfirmPassWordShowAction(object param)
        {
            ConfirmPassWordIsPassword = ! ConfirmPassWordIsPassword;
        }
        protected bool ConfirmPassWordShowCanExecute(object param)
        {
            return true;
        }
        #endregion

        #region IDestructible  
        public virtual void Destroy()
        {
            _GlblSettingsSrv = null;
            _GlblLoginSrv = null;
        }
        #endregion

    }
}

