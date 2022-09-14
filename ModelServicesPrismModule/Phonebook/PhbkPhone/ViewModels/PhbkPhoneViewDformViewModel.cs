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
using ModelInterfacesClassLibrary.Phonebook.PhbkPhone;
using CommonInterfacesClassLibrary.Enums;
using CommonInterfacesClassLibrary.AppGlblSettingsSrvc;
using CommonUserControlLibrary.ViewModels;
using CommonCustomControlLibrary.Classes;
/*




    "PhbkPhoneViewDformUserControl" UserControl is defined in the "ModelServicesPrismModule"-project.
    In the file of IModule-class of "ModelServicesPrismModule"-project the following line of code must be inserted:

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ...
            // According to requirements of the "PhbkPhoneViewDformViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            ViewModelLocationProvider.Register<PhbkPhoneViewDformUserControl, PhbkPhoneViewDformViewModel>();
            // According to requirements of the "PhbkPhoneViewDformViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            containerRegistry.Register<ContentView, PhbkPhoneViewDformUserControl>("PhbkPhoneViewDformUserControl");
            ...
        }

*/

namespace ModelServicesPrismModule.Phonebook.PhbkPhone.ViewModels {
    public class PhbkPhoneViewDformViewModel: INotifyPropertyChanged, INotifyDataErrorInfo, IEformViewModelInterface, IBindingContextChanged
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
        protected System.Int32 ? _PhoneId = null;
        public System.Int32 ? PhoneId {
            get { return _PhoneId; }
            set { 
                if((_PhoneId != value)||(value == null)) { 
                    _PhoneId = value; 
                    OnPropertyChanged();
                    ValidateField(value);
                } 
            }
        }
        public void PatchPhoneId(object value) {
            if(value == null) {
                if(!this._PhoneId.HasValue) return;
                this._PhoneId = null;
            } else {
                    var vl = Convert.ToInt32(value);
                    if(this._PhoneId.HasValue) {
                        if(this._PhoneId.Value == vl) return;
                    }
                    this._PhoneId = vl;
            }
            OnPropertyChanged("PhoneId");
            ValidateField(this._PhoneId, "PhoneId");
        }
        protected bool _PhoneIdEnabled = true;
        public bool PhoneIdEnabled {
            get { return _PhoneIdEnabled; }
            set { 
                if(_PhoneIdEnabled != value) 
                { 
                    _PhoneIdEnabled = value; 
                    OnPropertyChanged(); 
                } 
            }
        }
        public string PhoneIdSuffixError {
            get {
                return GetFirstError("PhoneId");
            }
        }

        protected System.String _Phone = null;
        public System.String Phone {
            get { return _Phone; }
            set { 
                if((_Phone != value)||(value == null)) { 
                    _Phone = value; 
                    OnPropertyChanged();
                    ValidateField(value);
                } 
            }
        }
        public void PatchPhone(object value) {
            if (value == null) {
                if(string.IsNullOrEmpty(this._Phone))  return;
                this._Phone = null;
            } else {
                if(value.ToString() == this._Phone) return;
                this._Phone = value.ToString();
            }
            OnPropertyChanged("Phone");
            ValidateField(this._Phone, "Phone");
        }
        protected bool _PhoneEnabled = true;
        public bool PhoneEnabled {
            get { return _PhoneEnabled; }
            set { 
                if(_PhoneEnabled != value) 
                { 
                    _PhoneEnabled = value; 
                    OnPropertyChanged(); 
                } 
            }
        }
        public string PhoneSuffixError {
            get {
                return GetFirstError("Phone");
            }
        }

        protected System.String _PPhoneTypeName = null;
        public System.String PPhoneTypeName {
            get { return _PPhoneTypeName; }
            set { 
                if((_PPhoneTypeName != value)||(value == null)) { 
                    _PPhoneTypeName = value; 
                    OnPropertyChanged();
                    ValidateField(value);
                } 
            }
        }
        public void PatchPPhoneTypeName(object value) {
            if (value == null) {
                if(string.IsNullOrEmpty(this._PPhoneTypeName))  return;
                this._PPhoneTypeName = null;
            } else {
                if(value.ToString() == this._PPhoneTypeName) return;
                this._PPhoneTypeName = value.ToString();
            }
            OnPropertyChanged("PPhoneTypeName");
            ValidateField(this._PPhoneTypeName, "PPhoneTypeName");
        }
        protected bool _PPhoneTypeNameEnabled = true;
        public bool PPhoneTypeNameEnabled {
            get { return _PPhoneTypeNameEnabled; }
            set { 
                if(_PPhoneTypeNameEnabled != value) 
                { 
                    _PPhoneTypeNameEnabled = value; 
                    OnPropertyChanged(); 
                } 
            }
        }
        public string PPhoneTypeNameSuffixError {
            get {
                return GetFirstError("PPhoneTypeName");
            }
        }

        protected System.String _EEmpLastName = null;
        public System.String EEmpLastName {
            get { return _EEmpLastName; }
            set { 
                if((_EEmpLastName != value)||(value == null)) { 
                    _EEmpLastName = value; 
                    OnPropertyChanged();
                    ValidateField(value);
                } 
            }
        }
        public void PatchEEmpLastName(object value) {
            if (value == null) {
                if(string.IsNullOrEmpty(this._EEmpLastName))  return;
                this._EEmpLastName = null;
            } else {
                if(value.ToString() == this._EEmpLastName) return;
                this._EEmpLastName = value.ToString();
            }
            OnPropertyChanged("EEmpLastName");
            ValidateField(this._EEmpLastName, "EEmpLastName");
        }
        protected bool _EEmpLastNameEnabled = true;
        public bool EEmpLastNameEnabled {
            get { return _EEmpLastNameEnabled; }
            set { 
                if(_EEmpLastNameEnabled != value) 
                { 
                    _EEmpLastNameEnabled = value; 
                    OnPropertyChanged(); 
                } 
            }
        }
        public string EEmpLastNameSuffixError {
            get {
                return GetFirstError("EEmpLastName");
            }
        }

        protected System.String _EEmpFirstName = null;
        public System.String EEmpFirstName {
            get { return _EEmpFirstName; }
            set { 
                if((_EEmpFirstName != value)||(value == null)) { 
                    _EEmpFirstName = value; 
                    OnPropertyChanged();
                    ValidateField(value);
                } 
            }
        }
        public void PatchEEmpFirstName(object value) {
            if (value == null) {
                if(string.IsNullOrEmpty(this._EEmpFirstName))  return;
                this._EEmpFirstName = null;
            } else {
                if(value.ToString() == this._EEmpFirstName) return;
                this._EEmpFirstName = value.ToString();
            }
            OnPropertyChanged("EEmpFirstName");
            ValidateField(this._EEmpFirstName, "EEmpFirstName");
        }
        protected bool _EEmpFirstNameEnabled = true;
        public bool EEmpFirstNameEnabled {
            get { return _EEmpFirstNameEnabled; }
            set { 
                if(_EEmpFirstNameEnabled != value) 
                { 
                    _EEmpFirstNameEnabled = value; 
                    OnPropertyChanged(); 
                } 
            }
        }
        public string EEmpFirstNameSuffixError {
            get {
                return GetFirstError("EEmpFirstName");
            }
        }

        protected System.String _EEmpSecondName = null;
        public System.String EEmpSecondName {
            get { return _EEmpSecondName; }
            set { 
                if((_EEmpSecondName != value)||(value == null)) { 
                    _EEmpSecondName = value; 
                    OnPropertyChanged();
                    ValidateField(value);
                } 
            }
        }
        public void PatchEEmpSecondName(object value) {
            if (value == null) {
                if(string.IsNullOrEmpty(this._EEmpSecondName))  return;
                this._EEmpSecondName = null;
            } else {
                if(value.ToString() == this._EEmpSecondName) return;
                this._EEmpSecondName = value.ToString();
            }
            OnPropertyChanged("EEmpSecondName");
            ValidateField(this._EEmpSecondName, "EEmpSecondName");
        }
        protected bool _EEmpSecondNameEnabled = true;
        public bool EEmpSecondNameEnabled {
            get { return _EEmpSecondNameEnabled; }
            set { 
                if(_EEmpSecondNameEnabled != value) 
                { 
                    _EEmpSecondNameEnabled = value; 
                    OnPropertyChanged(); 
                } 
            }
        }
        public string EEmpSecondNameSuffixError {
            get {
                return GetFirstError("EEmpSecondName");
            }
        }

        protected System.String _EDDivisionName = null;
        public System.String EDDivisionName {
            get { return _EDDivisionName; }
            set { 
                if((_EDDivisionName != value)||(value == null)) { 
                    _EDDivisionName = value; 
                    OnPropertyChanged();
                    ValidateField(value);
                } 
            }
        }
        public void PatchEDDivisionName(object value) {
            if (value == null) {
                if(string.IsNullOrEmpty(this._EDDivisionName))  return;
                this._EDDivisionName = null;
            } else {
                if(value.ToString() == this._EDDivisionName) return;
                this._EDDivisionName = value.ToString();
            }
            OnPropertyChanged("EDDivisionName");
            ValidateField(this._EDDivisionName, "EDDivisionName");
        }
        protected bool _EDDivisionNameEnabled = true;
        public bool EDDivisionNameEnabled {
            get { return _EDDivisionNameEnabled; }
            set { 
                if(_EDDivisionNameEnabled != value) 
                { 
                    _EDDivisionNameEnabled = value; 
                    OnPropertyChanged(); 
                } 
            }
        }
        public string EDDivisionNameSuffixError {
            get {
                return GetFirstError("EDDivisionName");
            }
        }

        protected System.String _EDEEntrprsName = null;
        public System.String EDEEntrprsName {
            get { return _EDEEntrprsName; }
            set { 
                if((_EDEEntrprsName != value)||(value == null)) { 
                    _EDEEntrprsName = value; 
                    OnPropertyChanged();
                    ValidateField(value);
                } 
            }
        }
        public void PatchEDEEntrprsName(object value) {
            if (value == null) {
                if(string.IsNullOrEmpty(this._EDEEntrprsName))  return;
                this._EDEEntrprsName = null;
            } else {
                if(value.ToString() == this._EDEEntrprsName) return;
                this._EDEEntrprsName = value.ToString();
            }
            OnPropertyChanged("EDEEntrprsName");
            ValidateField(this._EDEEntrprsName, "EDEEntrprsName");
        }
        protected bool _EDEEntrprsNameEnabled = true;
        public bool EDEEntrprsNameEnabled {
            get { return _EDEEntrprsNameEnabled; }
            set { 
                if(_EDEEntrprsNameEnabled != value) 
                { 
                    _EDEEntrprsNameEnabled = value; 
                    OnPropertyChanged(); 
                } 
            }
        }
        public string EDEEntrprsNameSuffixError {
            get {
                return GetFirstError("EDEEntrprsName");
            }
        }

        protected System.Int32 ? _EmployeeIdRef = null;
        public System.Int32 ? EmployeeIdRef {
            get { return _EmployeeIdRef; }
            set { 
                if((_EmployeeIdRef != value)||(value == null)) { 
                    _EmployeeIdRef = value; 
                    OnPropertyChanged();
                    ValidateField(value);
                    this.rootDataSource.setValue("EmployeeIdRef", value);
                } 
            }
        }
        public void PatchEmployeeIdRef(object value) {
            if(value == null) {
                if(!this._EmployeeIdRef.HasValue) return;
                this._EmployeeIdRef = null;
            } else {
                    var vl = Convert.ToInt32(value);
                    if(this._EmployeeIdRef.HasValue) {
                        if(this._EmployeeIdRef.Value == vl) return;
                    }
                    this._EmployeeIdRef = vl;
            }
            OnPropertyChanged("EmployeeIdRef");
            ValidateField(this._EmployeeIdRef, "EmployeeIdRef");
        }
        protected bool _EmployeeIdRefEnabled = true;
        public bool EmployeeIdRefEnabled {
            get { return _EmployeeIdRefEnabled; }
            set { 
                if(_EmployeeIdRefEnabled != value) 
                { 
                    _EmployeeIdRefEnabled = value; 
                    OnPropertyChanged(); 
                } 
            }
        }
        public string EmployeeIdRefSuffixError {
            get {
                return GetFirstError("EmployeeIdRef");
            }
        }

        protected System.Int32 ? _PhoneTypeIdRef = null;
        public System.Int32 ? PhoneTypeIdRef {
            get { return _PhoneTypeIdRef; }
            set { 
                if((_PhoneTypeIdRef != value)||(value == null)) { 
                    _PhoneTypeIdRef = value; 
                    OnPropertyChanged();
                    ValidateField(value);
                    this.rootDataSource.setValue("PhoneTypeIdRef", value);
                } 
            }
        }
        public void PatchPhoneTypeIdRef(object value) {
            if(value == null) {
                if(!this._PhoneTypeIdRef.HasValue) return;
                this._PhoneTypeIdRef = null;
            } else {
                    var vl = Convert.ToInt32(value);
                    if(this._PhoneTypeIdRef.HasValue) {
                        if(this._PhoneTypeIdRef.Value == vl) return;
                    }
                    this._PhoneTypeIdRef = vl;
            }
            OnPropertyChanged("PhoneTypeIdRef");
            ValidateField(this._PhoneTypeIdRef, "PhoneTypeIdRef");
        }
        protected bool _PhoneTypeIdRefEnabled = true;
        public bool PhoneTypeIdRefEnabled {
            get { return _PhoneTypeIdRefEnabled; }
            set { 
                if(_PhoneTypeIdRefEnabled != value) 
                { 
                    _PhoneTypeIdRefEnabled = value; 
                    OnPropertyChanged(); 
                } 
            }
        }
        public string PhoneTypeIdRefSuffixError {
            get {
                return GetFirstError("PhoneTypeIdRef");
            }
        }

        #endregion

        #region Helper objects and vars
        protected IAppGlblSettingsService GlblSettingsSrv = null;
        protected IDialogService dialogService = null;
        protected IPhbkPhoneViewDatasource rootDataSource = null;
        #endregion

        #region Constructor
        public PhbkPhoneViewDformViewModel(IPhbkPhoneViewDatasource _rootDataSource,
            IAppGlblSettingsService _GlblSettingsSrv, 
            IDialogService _dialogService) {
            this.GlblSettingsSrv = _GlblSettingsSrv;
            this.dialogService = _dialogService;
            this.rootDataSource = _rootDataSource;
            this.rootDataSource.Init(null, null, new List<string>{},"");
            this.rootDataSource.setIsNew(false);
            this.rootDataSource.AfterPropsChanged += this.rootDataSourceAfterPropsChanged;

            this.rootDataSource.OnDelete += this.rootDataSourceOnDelete;


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
            PropertyInfo propertyInfo = typeof(IPhbkPhoneView).GetProperty(filedName);
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
            ValidateField(PhoneId, "PhoneId");
            ValidateField(Phone, "Phone");
            ValidateField(PPhoneTypeName, "PPhoneTypeName");
            ValidateField(EEmpLastName, "EEmpLastName");
            ValidateField(EEmpFirstName, "EEmpFirstName");
            ValidateField(EEmpSecondName, "EEmpSecondName");
            ValidateField(EDDivisionName, "EDDivisionName");
            ValidateField(EDEEntrprsName, "EDEEntrprsName");
            ValidateField(EmployeeIdRef, "EmployeeIdRef");
            ValidateField(PhoneTypeIdRef, "PhoneTypeIdRef");
        }
        public void ClearValidationMessages() {
            ValidationErrors.Clear();
            ValidationDataErrors.Clear();
            RaiseErrorsChanged("PhoneId");
            RaiseErrorsChanged("Phone");
            RaiseErrorsChanged("PPhoneTypeName");
            RaiseErrorsChanged("EEmpLastName");
            RaiseErrorsChanged("EEmpFirstName");
            RaiseErrorsChanged("EEmpSecondName");
            RaiseErrorsChanged("EDDivisionName");
            RaiseErrorsChanged("EDEEntrprsName");
            RaiseErrorsChanged("EmployeeIdRef");
            RaiseErrorsChanged("PhoneTypeIdRef");
        }
        #endregion


        #region rootDataSourceAfterPropsChanged
        public async void rootDataSourceAfterPropsChanged(object sender, EventArgs e) {
            await DorootDataSourceAfterPropsChanged(sender);
        }
        public async Task DorootDataSourceAfterPropsChanged(object sender) {
            await MainThread.InvokeOnMainThreadAsync(() => {
                this.PatchPhoneId(this.rootDataSource.getValue("PhoneId"));
                this.PatchPhone(this.rootDataSource.getValue("Phone"));
                this.PatchPPhoneTypeName(this.rootDataSource.getValue("PPhoneTypeName"));
                this.PatchEEmpLastName(this.rootDataSource.getValue("EEmpLastName"));
                this.PatchEEmpFirstName(this.rootDataSource.getValue("EEmpFirstName"));
                this.PatchEEmpSecondName(this.rootDataSource.getValue("EEmpSecondName"));
                this.PatchEDDivisionName(this.rootDataSource.getValue("EDDivisionName"));
                this.PatchEDEEntrprsName(this.rootDataSource.getValue("EDEEntrprsName"));
                this.PatchEmployeeIdRef(this.rootDataSource.getValue("EmployeeIdRef"));
                this.PatchPhoneTypeIdRef(this.rootDataSource.getValue("PhoneTypeIdRef"));
            });
        }
        #endregion

        #region rootDataSourceOnDelete
        public async void rootDataSourceOnDelete(object sender, EventArgs e) { 
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
                this.rootDataSource.deleteone();
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
                this.FormControlModelVM =  NewValue as IPhbkPhoneView;
            });
        }
        protected IPhbkPhoneView _FormControlModelVM = null;
        public IPhbkPhoneView FormControlModelVM
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
            this.rootDataSource.OnDelete -= this.rootDataSourceOnDelete;
        }
        #endregion

    }
}

