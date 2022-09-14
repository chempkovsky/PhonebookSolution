
using System;
using Xamarin.Forms;
using System.ComponentModel;
using System.Windows.Input;
using Prism.Navigation;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Net.Http.Headers;
using CommonInterfacesClassLibrary.AppGlblLoginSrvc;
using CommonInterfacesClassLibrary.Interfaces;
using CommonInterfacesClassLibrary.AppGlblSettingsSrvc;

/*

    "LoginUserPageViewModel" UserControl is defined in the "CommonServicesPrismModule"-project.
    In the file of IModule-class of "CommonServicesPrismModule"-project the following line of code must be inserted:


        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ...

            ViewModelLocationProvider.Register<LoginUserPage, LoginUserPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginUserPage, LoginUserPageViewModel>("LoginUserPage");
            ...
        }

*/

namespace CommonServicesPrismModule.ViewModels {
    public class LoginUserPageViewModel: INotifyPropertyChanged, INotifyDataErrorInfo, IDestructible    
    {
        IAppGlblSettingsService _GlblSettingsSrv;
        IAppGlblLoginService _GlblLoginSrv;
        public LoginUserPageViewModel(IAppGlblLoginService GlblLoginSrv, IAppGlblSettingsService GlblSettingsSrv) {
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
            if (HasErrors) return;
            IBearerTokenModel model = await _GlblLoginSrv.Login(UserName , PassWord);
            if (model == null) return;
            if(_GlblSettingsSrv != null) {
                _GlblSettingsSrv.AuthInfo = model;
                _GlblSettingsSrv.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(model.token_type, model.access_token);
                // this line must be the last. It activates notification
                _GlblSettingsSrv.UserName = model.userName;

                // this line was used at development time
                // _GlblSettingsSrv.NavigateTo("HomePage");
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
        
        #region IDestructible  
        public virtual void Destroy()
        {
            _GlblSettingsSrv = null;
            _GlblLoginSrv = null;
        }
        #endregion

    }
}

