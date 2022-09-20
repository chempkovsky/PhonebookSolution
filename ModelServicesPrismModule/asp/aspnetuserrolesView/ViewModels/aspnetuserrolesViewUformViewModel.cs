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
using ModelInterfacesClassLibrary.interfaces.asp.aspnetuserrolesView;
using CommonInterfacesClassLibrary.Enums;
using CommonInterfacesClassLibrary.AppGlblSettingsSrvc;
using CommonUserControlLibrary.ViewModels;
using CommonCustomControlLibrary.Classes;
using ModelInterfacesClassLibrary.interfaces.asp.aspnetuserView;
using ModelInterfacesClassLibrary.interfaces.asp.aspnetroleView;
/*


        Reminder:
        "AspnetuserViewSdlgUserControl" UserControl is defined in the "ModelServicesPrismModule"-project.
        In the file of IModule-class of "ModelServicesPrismModule"-project the following line of code must be inserted:

            public void RegisterTypes(IContainerRegistry containerRegistry)
            {
                ...
                // According to requirements of the "AspnetuserViewSdlgViewModel.cs"-file of "ModelServicesPrismModule"-project. 
                containerRegistry.RegisterDialog<AspnetuserViewSdlgUserControl, SdlgViewModelBase>("AspnetuserViewSdlgViewModel");
                ...
            }



    "AspnetuserrolesViewUformUserControl" UserControl is defined in the "ModelServicesPrismModule"-project.
    In the file of IModule-class of "ModelServicesPrismModule"-project the following line of code must be inserted:

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ...
            // According to requirements of the "AspnetuserrolesViewUformViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            ViewModelLocationProvider.Register<AspnetuserrolesViewUformUserControl, AspnetuserrolesViewUformViewModel>();
            // According to requirements of the "AspnetuserrolesViewUformViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            containerRegistry.Register<ContentView, AspnetuserrolesViewUformUserControl>("AspnetuserrolesViewUformUserControl");
            ...
        }

*/

namespace ModelServicesPrismModule.asp.aspnetuserrolesView.ViewModels {
    public class AspnetuserrolesViewUformViewModel: INotifyPropertyChanged, INotifyDataErrorInfo, IEformViewModelInterface, IBindingContextChanged
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
        protected System.String _UserId = null;
        public System.String UserId {
            get { return _UserId; }
            set { 
                if((_UserId != value)||(value == null)) { 
                    _UserId = value; 
                    OnPropertyChanged();
                    ValidateField(value);
                } 
            }
        }
        public void PatchUserId(object value) {
            if (value == null) {
                if(string.IsNullOrEmpty(this._UserId))  return;
                this._UserId = null;
            } else {
                if(value.ToString() == this._UserId) return;
                this._UserId = value.ToString();
            }
            OnPropertyChanged("UserId");
            ValidateField(this._UserId, "UserId");
        }
        protected bool _UserIdEnabled = true;
        public bool UserIdEnabled {
            get { return _UserIdEnabled; }
            set { 
                if(_UserIdEnabled != value) 
                { 
                    _UserIdEnabled = value; 
                    OnPropertyChanged(); 
                } 
            }
        }
        public string UserIdSuffixError {
            get {
                return GetFirstError("UserId");
            }
        }

        protected System.String _UUserName = null;
        public System.String UUserName {
            get { return _UUserName; }
            set { 
                if((_UUserName != value)||(value == null)) { 
                    _UUserName = value; 
                    OnPropertyChanged();
                    ValidateField(value);
                } 
            }
        }
        public void PatchUUserName(object value) {
            if (value == null) {
                if(string.IsNullOrEmpty(this._UUserName))  return;
                this._UUserName = null;
            } else {
                if(value.ToString() == this._UUserName) return;
                this._UUserName = value.ToString();
            }
            OnPropertyChanged("UUserName");
            ValidateField(this._UUserName, "UUserName");
        }
        protected bool _UUserNameEnabled = true;
        public bool UUserNameEnabled {
            get { return _UUserNameEnabled; }
            set { 
                if(_UUserNameEnabled != value) 
                { 
                    _UUserNameEnabled = value; 
                    OnPropertyChanged(); 
                    (UUserNameSrchClckCommand as Command).ChangeCanExecute();
                } 
            }
        }
        public string UUserNameSuffixError {
            get {
                return GetFirstError("UUserName");
            }
        }

        protected System.String _RoleId = null;
        public System.String RoleId {
            get { return _RoleId; }
            set { 
                if((_RoleId != value)||(value == null)) { 
                    _RoleId = value; 
                    OnPropertyChanged();
                    ValidateField(value);
                } 
            }
        }
        public void PatchRoleId(object value) {
            if (value == null) {
                if(string.IsNullOrEmpty(this._RoleId))  return;
                this._RoleId = null;
            } else {
                if(value.ToString() == this._RoleId) return;
                this._RoleId = value.ToString();
            }
            OnPropertyChanged("RoleId");
            ValidateField(this._RoleId, "RoleId");
        }
        protected bool _RoleIdEnabled = true;
        public bool RoleIdEnabled {
            get { return _RoleIdEnabled; }
            set { 
                if(_RoleIdEnabled != value) 
                { 
                    _RoleIdEnabled = value; 
                    OnPropertyChanged(); 
                } 
            }
        }
        public string RoleIdSuffixError {
            get {
                return GetFirstError("RoleId");
            }
        }

        protected System.String _RName = null;
        public System.String RName {
            get { return _RName; }
            set { 
                if((_RName != value)||(value == null)) { 
                    _RName = value; 
                    OnPropertyChanged();
                    ValidateField(value);
                } 
            }
        }
        public void PatchRName(object value) {
            if (value == null) {
                if(string.IsNullOrEmpty(this._RName))  return;
                this._RName = null;
            } else {
                if(value.ToString() == this._RName) return;
                this._RName = value.ToString();
            }
            OnPropertyChanged("RName");
            ValidateField(this._RName, "RName");
        }
        protected bool _RNameEnabled = true;
        public bool RNameEnabled {
            get { return _RNameEnabled; }
            set { 
                if(_RNameEnabled != value) 
                { 
                    _RNameEnabled = value; 
                    OnPropertyChanged(); 
                } 
            }
        }
        public string RNameSuffixError {
            get {
                return GetFirstError("RName");
            }
        }

        protected System.DateTimeOffset ? _ULockoutEnd = null;
        public System.DateTimeOffset ? ULockoutEnd {
            get { return _ULockoutEnd; }
            set { 
                if((_ULockoutEnd != value)||(value == null)) { 
                    _ULockoutEnd = value; 
                    OnPropertyChanged();
                    ValidateField(value);
                } 
            }
        }
        public void PatchULockoutEnd(object value) {
            if(value == null) {
                if(!this._ULockoutEnd.HasValue) return;
                this._ULockoutEnd = null;
            } else {
                DateTimeOffset dtofst;
                if(DateTimeOffset.TryParse(value.ToString(), out dtofst)) {
                    if(this._ULockoutEnd.HasValue) {
                        if(dtofst.EqualsExact(this._ULockoutEnd.Value)) return;
                    }
                    this._ULockoutEnd = dtofst;
                } else {
                    if (!this._ULockoutEnd.HasValue) return;
                    this._ULockoutEnd = null;
                }
            }
            OnPropertyChanged("ULockoutEnd");
            ValidateField(this._ULockoutEnd, "ULockoutEnd");
        }
        #endregion

        #region Helper objects and vars
        protected IAppGlblSettingsService GlblSettingsSrv = null;
        protected IDialogService dialogService = null;
        protected IAspnetuserrolesViewDatasource rootDataSource = null;
        protected IAspnetuserViewDatasource UUserNameDtSrc = null;
        protected IAspnetroleViewDatasource RNameDtSrc = null;
        protected object _RNameCmbCntrl = null;
        public object RNameCmbCntrl {
            get { 
                return _RNameCmbCntrl; 
            }
            set { 
                var val = value as IAspnetroleView;
                if(_RNameCmbCntrl != val) { 
                    _RNameCmbCntrl = val; 
                    if(val == null) {
                        this.RNameDtSrc.ClearPartially(true);
                    } else {
                        this.RNameDtSrc.Interface2Values(val, true);
                    }
                    OnPropertyChanged(); 
                    ValidateField(value);
                } 
            }
        }
        public string RNameCmbCntrlSuffixError {
            get {
                return GetFirstError("RNameCmbCntrl");
            }
        }
        protected IList<IAspnetroleView> _RNameCmbCntrlVals = null;
        public IList<IAspnetroleView> RNameCmbCntrlVals {
            get { 
                return _RNameCmbCntrlVals; 
            }
            set { 
                if(_RNameCmbCntrlVals != value) { 
                    _RNameCmbCntrlVals = value; 
                    OnPropertyChanged(); 
                } 
            }
        }
        #endregion

        #region Constructor
        public AspnetuserrolesViewUformViewModel(IAspnetuserrolesViewDatasource _rootDataSource,
            IAspnetuserViewDatasource _UUserNameDtSrc,
            IAspnetroleViewDatasource _RNameDtSrc,
            IAppGlblSettingsService _GlblSettingsSrv, 
            IDialogService _dialogService) {
            this.GlblSettingsSrv = _GlblSettingsSrv;
            this.dialogService = _dialogService;
            this.rootDataSource = _rootDataSource;
            this.rootDataSource.Init(null, null, new List<string>{"AspNetUser", "AspNetRole"},"");
            this.rootDataSource.setIsNew(false);
            this.rootDataSource.AfterPropsChanged += this.rootDataSourceAfterPropsChanged;

            this.rootDataSource.OnUpdate += this.rootDataSourceOnUpdate;


            this.UUserNameDtSrc = _UUserNameDtSrc;
            this.UUserNameDtSrc.Init("aspnetuserrolesView", "AspNetUser", new List<string>{},"AspNetUser");
            this.UUserNameDtSrc.setIsNew(false);
            this.UUserNameDtSrc.AfterPropsChanged += this.UUserNameAfterPropsChanged;
            this.UUserNameDtSrc.AfterMasterChanged += this.UUserNameAfterMasterChanged;
            this.UUserNameDtSrc.OnMasterChanged += this.rootDataSource.SubmitOnMasterChanged;
            this.rootDataSource.OnDetailChanged += this.UUserNameDtSrc.SubmitOnDetailChanged;

            this.RNameDtSrc = _RNameDtSrc;
            this.RNameDtSrc.Init("aspnetuserrolesView", "AspNetRole", new List<string>{},"AspNetRole");
            this.RNameDtSrc.setIsNew(false);
            this.RNameDtSrc.AfterPropsChanged += this.RNameAfterPropsChanged;
            this.RNameDtSrc.AfterMasterChanged += this.RNameAfterMasterChanged;
            this.RNameDtSrc.OnMasterChanged += this.rootDataSource.SubmitOnMasterChanged;
            this.rootDataSource.OnDetailChanged += this.RNameDtSrc.SubmitOnDetailChanged;

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
            PropertyInfo propertyInfo = typeof(IAspnetuserrolesView).GetProperty(filedName);
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
/*
                case "UUserNameBttnItm":
                    requiredAttribute = new RequiredAttribute();
                    msg = requiredAttribute.FormatErrorMessage(string.Empty);
                    msgfiledName = "UUserNameBttnItm";
                    break;
*/
                case "RNameCmbCntrl":
                    requiredAttribute = new RequiredAttribute();
                    msg = requiredAttribute.FormatErrorMessage(string.Empty);
                    break;
                default:
                    break;
            }
            if (!string.IsNullOrEmpty(msg)) {
                ValidationDataErrors[msgfiledName] = new List<string>() { msg };
                RaiseErrorsChanged(msgfiledName);
            }
        }
        public void CheckIsValid() {
            ValidateField(UserId, "UserId");
            ValidateField(UUserName, "UUserName");
            ValidateField(RoleId, "RoleId");
            ValidateField(RName, "RName");
            ValidateField(ULockoutEnd, "ULockoutEnd");
/*
            ValidateObjectField(UUserNameBttnItm, "UUserNameBttnItm");
*/
            ValidateObjectField(RNameCmbCntrl, "RNameCmbCntrl");
        }
        public void ClearValidationMessages() {
            ValidationErrors.Clear();
            ValidationDataErrors.Clear();
            RaiseErrorsChanged("UserId");
            RaiseErrorsChanged("UUserName");
            RaiseErrorsChanged("RoleId");
            RaiseErrorsChanged("RName");
            RaiseErrorsChanged("ULockoutEnd");
/*
            RaiseErrorsChanged("UUserNameBttnItm");
*/
            RaiseErrorsChanged("RNameCmbCntrl");
        }
        #endregion


        #region rootDataSourceAfterPropsChanged
        public async void rootDataSourceAfterPropsChanged(object sender, EventArgs e) {
            await DorootDataSourceAfterPropsChanged(sender);
        }
        public async Task DorootDataSourceAfterPropsChanged(object sender) {
            await MainThread.InvokeOnMainThreadAsync(() => {
                this.PatchUserId(this.rootDataSource.getValue("UserId"));
                this.PatchRoleId(this.rootDataSource.getValue("RoleId"));
                this.UUserNameEnabled = 
                    (!this.rootDataSource.isUnderHiddenFilterFields("UUserName")) &&
                    this.UUserNameDtSrc.IsSetFilterByCurrDirMstrs();
                this.RNameEnabled = 
                    (!this.rootDataSource.isUnderHiddenFilterFields("RName")) &&
                    this.RNameDtSrc.IsSetFilterByCurrDirMstrs();
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

        #region UUserNameAfterMasterChanged
        public async void UUserNameAfterMasterChanged(object sender, EventArgs e) {
            await DoUUserNameAfterMasterChanged(sender);
        }
        public async Task DoUUserNameAfterMasterChanged(object sender) {
            await MainThread.InvokeOnMainThreadAsync(() => {
                this.UUserNameEnabled =
                    (!this.rootDataSource.isUnderHiddenFilterFields("UUserName")) ||
                    this.UUserNameDtSrc.IsSetFilterByCurrDirMstrs();
            });
        }
        #endregion

        #region UUserNameSrchClckCommand
        private ICommand _UUserNameSrchClckCommand;
        public ICommand UUserNameSrchClckCommand
        {
            get
            {
                return _UUserNameSrchClckCommand ?? 
                    (_UUserNameSrchClckCommand = 
                        new Command(
                            (param) => UUserNameSrchClck(param), 
                            (param) => UUserNameSrchClckCanExecute(param)));
            }
        }
        public bool UUserNameSrchClckCanExecute(object param)
        {
            return UUserNameEnabled;
        }
        public void UUserNameSrchClck(object param) {
            if (IsDestroyed) return;
            if(!this.UUserNameDtSrc.IsSetFilterByCurrDirMstrs()) {
                this.GlblSettingsSrv.ShowErrorMessage("Form Error", "Could not start dialog: not all master data is defined.");
                return;
            }

            IDialogParameters dlgParams = new DialogParameters();
            dlgParams.Add("Caption", "Select Item");
            dlgParams.Add("HiddenFilters", this.UUserNameDtSrc.GetWSFltrRsltByCurrDirMstrs());
            dialogService.ShowDialog("AspnetuserViewSdlgViewModel", dlgParams, (rslt) => {
                if (rslt == null) return;
                if (rslt.Parameters == null) return;
                if (!rslt.Parameters.ContainsKey("Result")) return;
                if (!rslt.Parameters.GetValue<bool>("Result")) return;
                if (rslt.Parameters.ContainsKey("SelectedItem"))
                {
                    IAspnetuserView itm = rslt.Parameters.GetValue<IAspnetuserView>("SelectedItem");
                    if (itm != null) {
                        this.UUserNameDtSrc.Interface2Values(itm, true);
                    }
                }
            });

        }
        #endregion

        #region UUserNameAfterPropsChanged
        public async void UUserNameAfterPropsChanged(object sender, EventArgs ea) {
            await DoUUserNameAfterPropsChanged(sender);
        }
        public async Task DoUUserNameAfterPropsChanged(object sender) {
            await MainThread.InvokeOnMainThreadAsync(() => {

            this.PatchUUserName(this.UUserNameDtSrc.getValue("UserName"));
            });
        }
        #endregion
        #region RNameAfterMasterChanged
        public async void RNameAfterMasterChanged(object sender, EventArgs ea) {
            await DoRNameAfterMasterChanged(sender);
        }
        public async Task DoRNameAfterMasterChanged(object sender) {
                IList<IAspnetroleView> data = null;
                IAspnetroleView newItm = null;
                try {
                    data = await this.RNameDtSrc.GetClActionByCurrDirMstrs();
                    if(data != null) {
                        if(this.RNameDtSrc.CalcIsDefined()) {
                            IAspnetroleView currItm = this.RNameDtSrc.Values2Interface();
                            newItm = data.Where(e => (e.Id == currItm.Id)).FirstOrDefault();
                        }
                    }
                } catch(Exception ex)
                {
                    string exceptionMsg = "RNameAfterMasterChanged : " + ex.Message;
                    Exception inner = ex.InnerException;
                    while (inner != null)
                    {
                        exceptionMsg = exceptionMsg + ": " + inner.Message;
                        inner = inner.InnerException;
                    }
                    GlblSettingsSrv.ShowErrorMessage("http", exceptionMsg);
                }


            await MainThread.InvokeOnMainThreadAsync(() => {
                _RNameCmbCntrl = null;
                OnPropertyChanged("RNameCmbCntrl");
                this._RNameCmbCntrlVals = data;
                OnPropertyChanged("RNameCmbCntrlVals");
                this._RNameCmbCntrl = newItm;
                OnPropertyChanged("RNameCmbCntrl");
                ValidateObjectField(newItm, "RNameCmbCntrl");
                if(newItm != null)
                    this.RName = newItm.Name;
                else
                    this.RName = null;
                if(this.RNameDtSrc.IsSetFilterByCurrDirMstrs() &&
                  (!this.rootDataSource.isUnderHiddenFilterFields("RName"))) {
                    this.RNameEnabled = true;
                } else {
                    this.RNameEnabled = false;
                }

            });
        }
        #endregion
        #region RNameAfterPropsChanged
        public async void RNameAfterPropsChanged(object sender, EventArgs ea) {
            await DoRNameAfterPropsChanged(sender);
        }
        public async Task DoRNameAfterPropsChanged(object sender) {
            await MainThread.InvokeOnMainThreadAsync(() => {

            if(this.RNameCmbCntrlVals != null) {
                IAspnetroleView currItm = this.RNameDtSrc.Values2Interface();
                IAspnetroleView newItm = null;
                if(currItm != null) {
                    newItm = this.RNameCmbCntrlVals.Where(e => (e.Id == currItm.Id)).FirstOrDefault();
                }
                this._RNameCmbCntrl = newItm;
                OnPropertyChanged("RNameCmbCntrl");
                ValidateObjectField(newItm, "RNameCmbCntrl");
                if(newItm != null)
                    this.PatchRName(newItm.Name);
                else 
                    this.PatchRName(null);
            } else {
                this._RNameCmbCntrl = null;
                OnPropertyChanged("RNameCmbCntrl");
                ValidateObjectField(null, "RNameCmbCntrl");
                this.PatchRName(null);
            }
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
                this.FormControlModelVM =  NewValue as IAspnetuserrolesView;
            });
        }
        protected IAspnetuserrolesView _FormControlModelVM = null;
        public IAspnetuserrolesView FormControlModelVM
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
                                await this.DoUUserNameAfterMasterChanged(this.UUserNameDtSrc);
                                await this.DoRNameAfterMasterChanged(this.RNameDtSrc);
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
            this.UUserNameDtSrc.AfterPropsChanged -= this.UUserNameAfterPropsChanged;
            this.UUserNameDtSrc.AfterMasterChanged -= this.UUserNameAfterMasterChanged;
            this.UUserNameDtSrc.OnMasterChanged -= this.rootDataSource.SubmitOnMasterChanged;
            this.rootDataSource.OnDetailChanged -= this.UUserNameDtSrc.SubmitOnDetailChanged;

/*
            _UUserNameBttnItm = null;
*/
            this.RNameDtSrc.AfterPropsChanged -= this.RNameAfterPropsChanged;
            this.RNameDtSrc.AfterMasterChanged -= this.RNameAfterMasterChanged;
            this.RNameDtSrc.OnMasterChanged -= this.rootDataSource.SubmitOnMasterChanged;
            this.rootDataSource.OnDetailChanged -= this.RNameDtSrc.SubmitOnDetailChanged;

            _RNameCmbCntrl = null;
            _RNameCmbCntrlVals = null;
        }
        #endregion

    }
}

