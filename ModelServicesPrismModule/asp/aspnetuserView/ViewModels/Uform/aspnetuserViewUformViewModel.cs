using System;
using Xamarin.Forms;
using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System.Threading.Tasks;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using Xamarin.Essentials;
using CommonInterfacesClassLibrary.Interfaces;
using ModelInterfacesClassLibrary.interfaces.asp.aspnetuserView;
using CommonInterfacesClassLibrary.Enums;
using CommonInterfacesClassLibrary.AppGlblSettingsSrvc;
using CommonUserControlLibrary.ViewModels;
using CommonCustomControlLibrary.Classes;
/*




    "AspnetuserViewUformUserControl" UserControl is defined in the "ModelServicesPrismModule"-project.
    In the file of IModule-class of "ModelServicesPrismModule"-project the following line of code must be inserted:

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ...
            // According to requirements of the "AspnetuserViewUformViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            ViewModelLocationProvider.Register<AspnetuserViewUformUserControl, AspnetuserViewUformViewModel>();
            // According to requirements of the "AspnetuserViewUformViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            containerRegistry.Register<ContentView, AspnetuserViewUformUserControl>("AspnetuserViewUformUserControl");
            ...
        }

*/

namespace ModelServicesPrismModule.asp.aspnetuserView.ViewModels.Uform {
    public class AspnetuserViewUformViewModel: INotifyPropertyChanged, INotifyDataErrorInfo, IEformViewModelInterface, IBindingContextChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        #region BindingContextFeedbackRef
        object _BindingContextFeedbackRef = null;
        public object BindingContextFeedbackRef {
            get { return _BindingContextFeedbackRef; }
            set { 
                if(_BindingContextFeedbackRef != value) {
                    _BindingContextFeedbackRef = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        #region MVVM props
        protected System.String _Id = null;
        public System.String Id {
            get { return _Id; }
            set { 
                if((_Id != value)||(value == null)) { 
                    _Id = value; 
                    OnPropertyChanged();
                    ValidateField(value);
                } 
            }
        }
        public void PatchId(object value) {
            if (value == null) {
                if(string.IsNullOrEmpty(this._Id))  return;
                this._Id = null;
            } else {
                if(value.ToString() == this._Id) return;
                this._Id = value.ToString();
            }
            OnPropertyChanged("Id");
            ValidateField(this._Id, "Id");
        }
        protected bool _IdEnabled = true;
        public bool IdEnabled {
            get { return _IdEnabled; }
            set { 
                if(_IdEnabled != value) 
                { 
                    _IdEnabled = value; 
                    OnPropertyChanged(); 
                } 
            }
        }
        public string IdSuffixError {
            get {
                return GetFirstError("Id");
            }
        }

        protected System.String _UserName = null;
        public System.String UserName {
            get { return _UserName; }
            set { 
                if((_UserName != value)||(value == null)) { 
                    _UserName = value; 
                    OnPropertyChanged();
                    ValidateField(value);
                    this.rootDataSource.setValue("UserName", value);
                } 
            }
        }
        public void PatchUserName(object value) {
            if (value == null) {
                if(string.IsNullOrEmpty(this._UserName))  return;
                this._UserName = null;
            } else {
                if(value.ToString() == this._UserName) return;
                this._UserName = value.ToString();
            }
            OnPropertyChanged("UserName");
            ValidateField(this._UserName, "UserName");
        }
        protected bool _UserNameEnabled = true;
        public bool UserNameEnabled {
            get { return _UserNameEnabled; }
            set { 
                if(_UserNameEnabled != value) 
                { 
                    _UserNameEnabled = value; 
                    OnPropertyChanged(); 
                } 
            }
        }
        public string UserNameSuffixError {
            get {
                return GetFirstError("UserName");
            }
        }

        protected System.String _Email = null;
        public System.String Email {
            get { return _Email; }
            set { 
                if((_Email != value)||(value == null)) { 
                    _Email = value; 
                    OnPropertyChanged();
                    ValidateField(value);
                    this.rootDataSource.setValue("Email", value);
                } 
            }
        }
        public void PatchEmail(object value) {
            if (value == null) {
                if(string.IsNullOrEmpty(this._Email))  return;
                this._Email = null;
            } else {
                if(value.ToString() == this._Email) return;
                this._Email = value.ToString();
            }
            OnPropertyChanged("Email");
            ValidateField(this._Email, "Email");
        }
        protected bool _EmailEnabled = true;
        public bool EmailEnabled {
            get { return _EmailEnabled; }
            set { 
                if(_EmailEnabled != value) 
                { 
                    _EmailEnabled = value; 
                    OnPropertyChanged(); 
                } 
            }
        }
        public string EmailSuffixError {
            get {
                return GetFirstError("Email");
            }
        }

        protected System.Boolean ? _EmailConfirmed = null;
        public System.Boolean ? EmailConfirmed {
            get { return _EmailConfirmed; }
            set { 
                if((_EmailConfirmed != value)||(value == null)) { 
                    _EmailConfirmed = value; 
                    OnPropertyChanged();
                    ValidateField(value);
                    this.rootDataSource.setValue("EmailConfirmed", value);
                } 
            }
        }
        public void PatchEmailConfirmed(object value) {
            if(value == null) {
                if(!this._EmailConfirmed.HasValue) return;
                this._EmailConfirmed = null;
            } else {
                    var vl = Convert.ToBoolean(value);
                    if(this._EmailConfirmed.HasValue) {
                        if(this._EmailConfirmed.Value == vl) return;
                    }
                    this._EmailConfirmed = vl;
            }
            OnPropertyChanged("EmailConfirmed");
            ValidateField(this._EmailConfirmed, "EmailConfirmed");
        }
        protected bool _EmailConfirmedEnabled = true;
        public bool EmailConfirmedEnabled {
            get { return _EmailConfirmedEnabled; }
            set { 
                if(_EmailConfirmedEnabled != value) 
                { 
                    _EmailConfirmedEnabled = value; 
                    OnPropertyChanged(); 
                } 
            }
        }
        public string EmailConfirmedSuffixError {
            get {
                return GetFirstError("EmailConfirmed");
            }
        }

        protected System.String _PhoneNumber = null;
        public System.String PhoneNumber {
            get { return _PhoneNumber; }
            set { 
                if((_PhoneNumber != value)||(value == null)) { 
                    _PhoneNumber = value; 
                    OnPropertyChanged();
                    ValidateField(value);
                    this.rootDataSource.setValue("PhoneNumber", value);
                } 
            }
        }
        public void PatchPhoneNumber(object value) {
            if (value == null) {
                if(string.IsNullOrEmpty(this._PhoneNumber))  return;
                this._PhoneNumber = null;
            } else {
                if(value.ToString() == this._PhoneNumber) return;
                this._PhoneNumber = value.ToString();
            }
            OnPropertyChanged("PhoneNumber");
            ValidateField(this._PhoneNumber, "PhoneNumber");
        }
        protected bool _PhoneNumberEnabled = true;
        public bool PhoneNumberEnabled {
            get { return _PhoneNumberEnabled; }
            set { 
                if(_PhoneNumberEnabled != value) 
                { 
                    _PhoneNumberEnabled = value; 
                    OnPropertyChanged(); 
                } 
            }
        }
        public string PhoneNumberSuffixError {
            get {
                return GetFirstError("PhoneNumber");
            }
        }

        protected System.Boolean ? _PhoneNumberConfirmed = null;
        public System.Boolean ? PhoneNumberConfirmed {
            get { return _PhoneNumberConfirmed; }
            set { 
                if((_PhoneNumberConfirmed != value)||(value == null)) { 
                    _PhoneNumberConfirmed = value; 
                    OnPropertyChanged();
                    ValidateField(value);
                    this.rootDataSource.setValue("PhoneNumberConfirmed", value);
                } 
            }
        }
        public void PatchPhoneNumberConfirmed(object value) {
            if(value == null) {
                if(!this._PhoneNumberConfirmed.HasValue) return;
                this._PhoneNumberConfirmed = null;
            } else {
                    var vl = Convert.ToBoolean(value);
                    if(this._PhoneNumberConfirmed.HasValue) {
                        if(this._PhoneNumberConfirmed.Value == vl) return;
                    }
                    this._PhoneNumberConfirmed = vl;
            }
            OnPropertyChanged("PhoneNumberConfirmed");
            ValidateField(this._PhoneNumberConfirmed, "PhoneNumberConfirmed");
        }
        protected bool _PhoneNumberConfirmedEnabled = true;
        public bool PhoneNumberConfirmedEnabled {
            get { return _PhoneNumberConfirmedEnabled; }
            set { 
                if(_PhoneNumberConfirmedEnabled != value) 
                { 
                    _PhoneNumberConfirmedEnabled = value; 
                    OnPropertyChanged(); 
                } 
            }
        }
        public string PhoneNumberConfirmedSuffixError {
            get {
                return GetFirstError("PhoneNumberConfirmed");
            }
        }

        protected System.Boolean ? _TwoFactorEnabled = null;
        public System.Boolean ? TwoFactorEnabled {
            get { return _TwoFactorEnabled; }
            set { 
                if((_TwoFactorEnabled != value)||(value == null)) { 
                    _TwoFactorEnabled = value; 
                    OnPropertyChanged();
                    ValidateField(value);
                    this.rootDataSource.setValue("TwoFactorEnabled", value);
                } 
            }
        }
        public void PatchTwoFactorEnabled(object value) {
            if(value == null) {
                if(!this._TwoFactorEnabled.HasValue) return;
                this._TwoFactorEnabled = null;
            } else {
                    var vl = Convert.ToBoolean(value);
                    if(this._TwoFactorEnabled.HasValue) {
                        if(this._TwoFactorEnabled.Value == vl) return;
                    }
                    this._TwoFactorEnabled = vl;
            }
            OnPropertyChanged("TwoFactorEnabled");
            ValidateField(this._TwoFactorEnabled, "TwoFactorEnabled");
        }
        protected bool _TwoFactorEnabledEnabled = true;
        public bool TwoFactorEnabledEnabled {
            get { return _TwoFactorEnabledEnabled; }
            set { 
                if(_TwoFactorEnabledEnabled != value) 
                { 
                    _TwoFactorEnabledEnabled = value; 
                    OnPropertyChanged(); 
                } 
            }
        }
        public string TwoFactorEnabledSuffixError {
            get {
                return GetFirstError("TwoFactorEnabled");
            }
        }

        protected System.Boolean ? _LockoutEnabled = null;
        public System.Boolean ? LockoutEnabled {
            get { return _LockoutEnabled; }
            set { 
                if((_LockoutEnabled != value)||(value == null)) { 
                    _LockoutEnabled = value; 
                    OnPropertyChanged();
                    ValidateField(value);
                    this.rootDataSource.setValue("LockoutEnabled", value);
                } 
            }
        }
        public void PatchLockoutEnabled(object value) {
            if(value == null) {
                if(!this._LockoutEnabled.HasValue) return;
                this._LockoutEnabled = null;
            } else {
                    var vl = Convert.ToBoolean(value);
                    if(this._LockoutEnabled.HasValue) {
                        if(this._LockoutEnabled.Value == vl) return;
                    }
                    this._LockoutEnabled = vl;
            }
            OnPropertyChanged("LockoutEnabled");
            ValidateField(this._LockoutEnabled, "LockoutEnabled");
        }
        protected bool _LockoutEnabledEnabled = true;
        public bool LockoutEnabledEnabled {
            get { return _LockoutEnabledEnabled; }
            set { 
                if(_LockoutEnabledEnabled != value) 
                { 
                    _LockoutEnabledEnabled = value; 
                    OnPropertyChanged(); 
                } 
            }
        }
        public string LockoutEnabledSuffixError {
            get {
                return GetFirstError("LockoutEnabled");
            }
        }

        protected System.Int32 ? _AccessFailedCount = null;
        public System.Int32 ? AccessFailedCount {
            get { return _AccessFailedCount; }
            set { 
                if((_AccessFailedCount != value)||(value == null)) { 
                    _AccessFailedCount = value; 
                    OnPropertyChanged();
                    ValidateField(value);
                    this.rootDataSource.setValue("AccessFailedCount", value);
                } 
            }
        }
        public void PatchAccessFailedCount(object value) {
            if(value == null) {
                if(!this._AccessFailedCount.HasValue) return;
                this._AccessFailedCount = null;
            } else {
                    var vl = Convert.ToInt32(value);
                    if(this._AccessFailedCount.HasValue) {
                        if(this._AccessFailedCount.Value == vl) return;
                    }
                    this._AccessFailedCount = vl;
            }
            OnPropertyChanged("AccessFailedCount");
            ValidateField(this._AccessFailedCount, "AccessFailedCount");
        }
        protected bool _AccessFailedCountEnabled = true;
        public bool AccessFailedCountEnabled {
            get { return _AccessFailedCountEnabled; }
            set { 
                if(_AccessFailedCountEnabled != value) 
                { 
                    _AccessFailedCountEnabled = value; 
                    OnPropertyChanged(); 
                } 
            }
        }
        public string AccessFailedCountSuffixError {
            get {
                return GetFirstError("AccessFailedCount");
            }
        }

        protected System.DateTimeOffset ? _LockoutEnd = null;
        public System.DateTimeOffset ? LockoutEnd {
            get { return _LockoutEnd; }
            set { 
                if((_LockoutEnd != value)||(value == null)) { 
                    _LockoutEnd = value; 
                    OnPropertyChanged();
                    ValidateField(value);
                } 
            }
        }
        public void PatchLockoutEnd(object value) {
            if(value == null) {
                if(!this._LockoutEnd.HasValue) return;
                this._LockoutEnd = null;
            } else {
                DateTimeOffset dtofst;
                if(DateTimeOffset.TryParse(value.ToString(), out dtofst)) {
                    if(this._LockoutEnd.HasValue) {
                        if(dtofst.EqualsExact(this._LockoutEnd.Value)) return;
                    }
                    this._LockoutEnd = dtofst;
                } else {
                    if (!this._LockoutEnd.HasValue) return;
                    this._LockoutEnd = null;
                }
            }
            OnPropertyChanged("LockoutEnd");
            ValidateField(this._LockoutEnd, "LockoutEnd");
        }
        #endregion

        #region Helper objects and vars
        protected IAppGlblSettingsService GlblSettingsSrv = null;
        protected IDialogService dialogService = null;
        protected IAspnetuserViewDatasource rootDataSource = null;
        #endregion

        #region Constructor
        public AspnetuserViewUformViewModel(IAspnetuserViewDatasource _rootDataSource,
            IAppGlblSettingsService _GlblSettingsSrv, 
            IDialogService _dialogService) {
            this.GlblSettingsSrv = _GlblSettingsSrv;
            this.dialogService = _dialogService;
            this.rootDataSource = _rootDataSource;
            this.rootDataSource.Init(null, null, new List<string>{},"");
            this.rootDataSource.setIsNew(false);
            this.rootDataSource.AfterPropsChanged += this.rootDataSourceAfterPropsChanged;

            this.rootDataSource.OnUpdate += this.rootDataSourceOnUpdate;


        }
        #endregion

        #region Validation
        Dictionary<string, ICollection<string>> ValidationErrors = new Dictionary<string, ICollection<string>>();
        Dictionary<string, ICollection<string>> ValidationDataErrors = new Dictionary<string, ICollection<string>>();
        public bool HasErrors { get { return (ValidationErrors.Count > 0) || (ValidationDataErrors.Count > 0); } }
        public System.Collections.IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName)) {
                return null;
            }
            if(ValidationErrors.ContainsKey(propertyName)) 
                return ValidationErrors[propertyName];
            if (ValidationDataErrors.ContainsKey(propertyName))
                return ValidationDataErrors[propertyName];
            return null;
        }
        public string GetFirstError(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName)) {
                return "";
            }
            string str = null;
            if(ValidationErrors.ContainsKey(propertyName)) 
                str = ValidationErrors[propertyName].FirstOrDefault(i => !string.IsNullOrEmpty(i));
            if(string.IsNullOrEmpty(str))
                if (ValidationDataErrors.ContainsKey(propertyName))
                    str = ValidationDataErrors[propertyName].FirstOrDefault(i => !string.IsNullOrEmpty(i));
            return str==null ? "" : str;
        }
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        private void RaiseErrorsChanged(string propertyName)
        {
            //if (ErrorsChanged != null)
            //    ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
            OnPropertyChanged(propertyName + "SuffixError");
        }
        public void ValidateField(object value, [CallerMemberName] string filedName = null) {
            if(IsLoading) return;
            if (string.IsNullOrEmpty(filedName)) return;
            PropertyInfo propertyInfo = typeof(IAspnetuserView).GetProperty(filedName);
            if(propertyInfo == null) return;
            IList<string> rslt = 
                    (from validationAttribute in propertyInfo.GetCustomAttributes(true).OfType<ValidationAttribute>()
                     where !validationAttribute.IsValid(value)
                     select validationAttribute.FormatErrorMessage(string.Empty)).ToList();
            bool hasErrors = rslt != null;
            hasErrors = hasErrors ? (rslt.Count > 0) : false;
            if(hasErrors) {
                ValidationDataErrors[filedName] = rslt;
                RaiseErrorsChanged(filedName);
            } else {
                if(ValidationDataErrors.ContainsKey(filedName))  {
                    ValidationDataErrors.Remove(filedName);
                    RaiseErrorsChanged(filedName);
                }
            }
        }
        public void ValidateObjectField(object value, [CallerMemberName] string filedName = null) {
            if(IsLoading) return;
            if (string.IsNullOrEmpty(filedName)) return;
            if (value != null) {
                if(ValidationDataErrors.ContainsKey(filedName))  {
                    ValidationDataErrors.Remove(filedName);
                    RaiseErrorsChanged(filedName);
                }
                return;
            }
            string msgfiledName = filedName;
            RequiredAttribute requiredAttribute;
            string msg = null;
            switch(filedName) {
                default:
                    break;
            }
            if (!string.IsNullOrEmpty(msg)) {
                ValidationDataErrors[msgfiledName] = new List<string>() { msg };
                RaiseErrorsChanged(msgfiledName);
            }
        }
        public void CheckIsValid() {
            ValidateField(Id, "Id");
            ValidateField(UserName, "UserName");
            ValidateField(Email, "Email");
            ValidateField(EmailConfirmed, "EmailConfirmed");
            ValidateField(PhoneNumber, "PhoneNumber");
            ValidateField(PhoneNumberConfirmed, "PhoneNumberConfirmed");
            ValidateField(TwoFactorEnabled, "TwoFactorEnabled");
            ValidateField(LockoutEnabled, "LockoutEnabled");
            ValidateField(AccessFailedCount, "AccessFailedCount");
            ValidateField(LockoutEnd, "LockoutEnd");
        }
        public void ClearValidationMessages() {
            ValidationErrors.Clear();
            ValidationDataErrors.Clear();
            RaiseErrorsChanged("Id");
            RaiseErrorsChanged("UserName");
            RaiseErrorsChanged("Email");
            RaiseErrorsChanged("EmailConfirmed");
            RaiseErrorsChanged("PhoneNumber");
            RaiseErrorsChanged("PhoneNumberConfirmed");
            RaiseErrorsChanged("TwoFactorEnabled");
            RaiseErrorsChanged("LockoutEnabled");
            RaiseErrorsChanged("AccessFailedCount");
            RaiseErrorsChanged("LockoutEnd");
        }
        #endregion


        #region rootDataSourceAfterPropsChanged
        public async void rootDataSourceAfterPropsChanged(object sender, EventArgs e) {
            await DorootDataSourceAfterPropsChanged(sender);
        }
        public async Task DorootDataSourceAfterPropsChanged(object sender) {
            await MainThread.InvokeOnMainThreadAsync(() => {
                this.PatchId(this.rootDataSource.getValue("Id"));
                this.PatchUserName(this.rootDataSource.getValue("UserName"));
                this.PatchEmail(this.rootDataSource.getValue("Email"));
                this.PatchEmailConfirmed(this.rootDataSource.getValue("EmailConfirmed"));
                this.PatchPhoneNumber(this.rootDataSource.getValue("PhoneNumber"));
                this.PatchPhoneNumberConfirmed(this.rootDataSource.getValue("PhoneNumberConfirmed"));
                this.PatchTwoFactorEnabled(this.rootDataSource.getValue("TwoFactorEnabled"));
                this.PatchLockoutEnabled(this.rootDataSource.getValue("LockoutEnabled"));
                this.PatchAccessFailedCount(this.rootDataSource.getValue("AccessFailedCount"));
            });
        }
        #endregion

        #region rootDataSourceOnUpdate
        public async void rootDataSourceOnUpdate(object sender, EventArgs e) { 
            object  itm = this.rootDataSource.Values2Interface();
            await MainThread.InvokeOnMainThreadAsync(() => {
                BindingContextFeedbackRef = new BindingContextFeedback() {
		            BcfName = "SubmitCommand",
		            BcfData = itm
                };
            });
        }
        #endregion


        #region SubmitCommand
        private ICommand _SubmitCommand;
        public ICommand SubmitCommand
        {
            get
            {
                return _SubmitCommand ?? (_SubmitCommand = new Command(() => SubmitCommandAction(), () => SubmitCommandCanExecute()));
            }
        }
        protected void SubmitCommandAction()
        {
            this.DoSubmit();
        }
        protected bool SubmitCommandCanExecute()
        {
            return !HasErrors;
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
        protected void CancelCommandAction(object param)
        {
            // notify EformUserControl
            if (IsDestroyed) return;
            BindingContextFeedbackRef = new BindingContextFeedback() {
		        BcfName = "CancelCommand",
		        BcfData = null
            };
        }
        protected bool CancelCommandCanExecute(object param)
        {
            return true;
        }
        #endregion

        #region DoSubmit
        public void DoSubmit() {
            if (IsDestroyed) return;
            CheckIsValid();
            if(HasErrors) return;
            if (!this.rootDataSource.RefreshIsDefined()) {
                GlblSettingsSrv.ShowErrorMessage("Http Error", "Could not update. Not all properties are set.");
                return;
            }
            Task.Run(() => {
                this.rootDataSource.updateone();
            }).ConfigureAwait(false);

        }
        #endregion

        #region AutoSuggestBox

        // Reason: UserInput = 0, ProgrammaticChange = 1, SuggestionChosen = 2
        public void OnAutoSuggestBoxTextChanged(object Sender, object AutoSggstBx, string PropName, int Reason, string QueryText)
        {
            if (IsDestroyed) return;
        }
        // IF (ChosenSuggestion != null) THEN User selected an item from the suggestion list, take an action on it here.
        public void OnAutoSuggestBoxQuerySubmitted(object Sender, object AutoSggstBx, string PropName, object ChosenSuggestion, string QueryText)
        {
            if (IsDestroyed) return;
        }
        #endregion

        #region HiddenFilter
        public async Task HiddenFiltersPropertyChanged(object sender, object OldValue, object NewValue) {
            if(IsDestroyed) return;
            IList<IWebServiceFilterRsltInterface> nwval = NewValue as IList<IWebServiceFilterRsltInterface>;
            await MainThread.InvokeOnMainThreadAsync(() => {
                this.HiddenFiltersVM = nwval;
            });
        }
        protected IList<IWebServiceFilterRsltInterface> _HiddenFiltersVM = new List<IWebServiceFilterRsltInterface>();
        public IList<IWebServiceFilterRsltInterface> HiddenFiltersVM
        {
            get
            {
                return _HiddenFiltersVM;
            }
            set
            {
                if (_HiddenFiltersVM != value) {
                    _HiddenFiltersVM = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        #region FormControlModelVM
        protected async Task OnFormControlModelChanged() {
            this.rootDataSource.setHiddenFilter(this.rootDataSource.getHiddenFilterByFltRslt(this.HiddenFiltersVM));
            bool hasChanged  = this.rootDataSource.Interface2Values(this._FormControlModelVM, false);
            hasChanged = this.rootDataSource.UpdateByHiddenFilterFields(false) || hasChanged;
            if(hasChanged) {
                await this.rootDataSource.Refresh();
            } else {
                this.rootDataSource.DoEmitEvent(false);
            }
        }
        public async Task FormControlModelChanged(object sender, object OldValue, object NewValue) {
            if (IsDestroyed) return;
            await MainThread.InvokeOnMainThreadAsync(() => {
                this.FormControlModelVM =  NewValue as IAspnetuserView;
            });
        }
        protected IAspnetuserView _FormControlModelVM = null;
        public IAspnetuserView FormControlModelVM
        {
            get
            {
                return _FormControlModelVM;
            }
            set
            {
                if (_FormControlModelVM != value) {
                    _FormControlModelVM = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        #region EformModeVM
        public async Task EformModeChanged(object sender, object OldValue, object NewValue) {
            if (IsDestroyed) return;
            if(NewValue != null) {
                EformModeEnum nwval = (EformModeEnum)NewValue; 
                await MainThread.InvokeOnMainThreadAsync(() => {
                    _EformModeVM = nwval;
                    OnPropertyChanged("EformModeVM");
                });
            }
        }
        protected EformModeEnum _EformModeVM = EformModeEnum.DeleteMode;
        public EformModeEnum EformModeVM
        {
            get
            {
                return _EformModeVM;
            }
            set
            {
                if (_EformModeVM != value) {
                    _EformModeVM = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        #region OnLoaded
        public async Task OnLoaded(object sender, object newValue) {
            if (IsDestroyed) return;
            if (newValue is bool) {
                bool v = (bool)newValue;
                if ((!IsOnLoadedCalled) && v) {
                        await MainThread.InvokeOnMainThreadAsync(() => {
                            IsLoading = true;
                        });
                        _ = Task.Run(async () => {
                            try {
                                await OnFormControlModelChanged();
                                await DorootDataSourceAfterPropsChanged(this.rootDataSource);
                                await MainThread.InvokeOnMainThreadAsync(() => {
                                    ClearValidationMessages();
                                    IsOnLoadedCalled = true;
                                });
                            } finally {
                                await MainThread.InvokeOnMainThreadAsync(() => {
                                    IsLoading = false;
                                });
                            }
                        }).ConfigureAwait(false);
                } else {
                    IsOnLoadedCalled = v;
                }
            }
        }
        #endregion

        #region Loaded and Loading
        protected bool IsOnLoadedCalled = false;
        protected bool _IsLoading = true;
        public bool IsLoading
        {
            get { return _IsLoading; }
            set { if(_IsLoading != value) { _IsLoading = value; OnPropertyChanged(); } }
        }
        #endregion

        #region IsDestroyed
        protected bool _IsDestroyed = false;
        public bool IsDestroyed {
            get { return _IsDestroyed; }
            set { 
                if(_IsDestroyed != value) {
                    _IsDestroyed = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion


        #region OnDestroy
        public void OnDestroy() {
            IsDestroyed = true;
            IsLoading = false;
            IsOnLoadedCalled = false;
            _HiddenFiltersVM = null;
            _FormControlModelVM = null;
            _BindingContextFeedbackRef = null;


            this.rootDataSource.AfterPropsChanged -= this.rootDataSourceAfterPropsChanged;
            this.rootDataSource.OnUpdate -= this.rootDataSourceOnUpdate;
        }
        #endregion

    }
}

