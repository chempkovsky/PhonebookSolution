
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

    "RegisterUserPageViewModel" UserControl is defined in the "CommonServicesPrismModule"-project.
    In the file of IModule-class of "CommonServicesPrismModule"-project the following line of code must be inserted:


        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ...

            ViewModelLocationProvider.Register<RegisterUserPage, RegisterUserPageViewModel>();
            containerRegistry.RegisterForNavigation<RegisterUserPage, RegisterUserPageViewModel>("RegisterUserPage");
            ...
        }

*/

namespace CommonServicesPrismModule.ViewModels {
    public class RegisterUserPageViewModel: INotifyPropertyChanged, INotifyDataErrorInfo, IDestructible    
    {
        protected IAppGlblSettingsService _GlblSettingsSrv=null;
        protected IAppGlblLoginService _GlblLoginSrv;
        public RegisterUserPageViewModel(IAppGlblLoginService GlblLoginSrv, IAppGlblSettingsService GlblSettingsSrv) {
            _GlblSettingsSrv = GlblSettingsSrv;
            _GlblLoginSrv = GlblLoginSrv;
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
                case "UserName":
                    if (string.IsNullOrEmpty(stringValue)) {
                        ErrorMsg = "UserName is a required filed";
                    } else if (stringValue.Length < 3) {
                        ErrorMsg = "UserName.Length must be large than 2";
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

        #region UserName
        protected string _UserName = "";
        public string UserName 
        {
            get { return _UserName; }
            set
            {
                if (UserName != value) {
                    _UserName = value;
                    OnPropertyChanged();
                    ValidateField(value);
                }
            }
        }
        public string UserNamePropmpt {
            get { return "Enter User Name"; }
        }
        public string UserNameCaption {
            get { return "User Name"; }
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
        #region UserNameError
        public string UserNameError {
            get 
            {
                return GetFirstError("UserName");
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
            ValidateField(UserName, "UserName");
            ValidateField(PassWord, "PassWord");
            ValidateField(ConfirmPassWord, "ConfirmPassWord");
            if (HasErrors) return;
            IRegisterModel model = await _GlblLoginSrv.Register(UserName , PassWord, ConfirmPassWord);
            if (model == null) return;
            if(_GlblSettingsSrv != null) {
                _GlblSettingsSrv.NavigateTo("HomePage");
            }
        }
        protected bool OkCommandCanExecute(object param)
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

