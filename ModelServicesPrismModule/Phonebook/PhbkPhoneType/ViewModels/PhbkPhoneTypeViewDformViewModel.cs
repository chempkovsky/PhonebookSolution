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
using ModelInterfacesClassLibrary.Phonebook.PhbkPhoneType;
using CommonInterfacesClassLibrary.Enums;
using CommonInterfacesClassLibrary.AppGlblSettingsSrvc;
using CommonUserControlLibrary.ViewModels;
using CommonCustomControlLibrary.Classes;
/*




    "PhbkPhoneTypeViewDformUserControl" UserControl is defined in the "ModelServicesPrismModule"-project.
    In the file of IModule-class of "ModelServicesPrismModule"-project the following line of code must be inserted:

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ...
            // According to requirements of the "PhbkPhoneTypeViewDformViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            ViewModelLocationProvider.Register<PhbkPhoneTypeViewDformUserControl, PhbkPhoneTypeViewDformViewModel>();
            // According to requirements of the "PhbkPhoneTypeViewDformViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            containerRegistry.Register<ContentView, PhbkPhoneTypeViewDformUserControl>("PhbkPhoneTypeViewDformUserControl");
            ...
        }

*/

namespace ModelServicesPrismModule.Phonebook.PhbkPhoneType.ViewModels {
    public class PhbkPhoneTypeViewDformViewModel: INotifyPropertyChanged, INotifyDataErrorInfo, IEformViewModelInterface, IBindingContextChanged
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
        protected System.Int32 ? _PhoneTypeId = null;
        public System.Int32 ? PhoneTypeId {
            get { return _PhoneTypeId; }
            set { 
                if((_PhoneTypeId != value)||(value == null)) { 
                    _PhoneTypeId = value; 
                    OnPropertyChanged();
                    ValidateField(value);
                } 
            }
        }
        public void PatchPhoneTypeId(object value) {
            if(value == null) {
                if(!this._PhoneTypeId.HasValue) return;
                this._PhoneTypeId = null;
            } else {
                    var vl = Convert.ToInt32(value);
                    if(this._PhoneTypeId.HasValue) {
                        if(this._PhoneTypeId.Value == vl) return;
                    }
                    this._PhoneTypeId = vl;
            }
            OnPropertyChanged("PhoneTypeId");
            ValidateField(this._PhoneTypeId, "PhoneTypeId");
        }
        protected bool _PhoneTypeIdEnabled = true;
        public bool PhoneTypeIdEnabled {
            get { return _PhoneTypeIdEnabled; }
            set { 
                if(_PhoneTypeIdEnabled != value) 
                { 
                    _PhoneTypeIdEnabled = value; 
                    OnPropertyChanged(); 
                } 
            }
        }
        public string PhoneTypeIdSuffixError {
            get {
                return GetFirstError("PhoneTypeId");
            }
        }

        protected System.String _PhoneTypeName = null;
        public System.String PhoneTypeName {
            get { return _PhoneTypeName; }
            set { 
                if((_PhoneTypeName != value)||(value == null)) { 
                    _PhoneTypeName = value; 
                    OnPropertyChanged();
                    ValidateField(value);
                } 
            }
        }
        public void PatchPhoneTypeName(object value) {
            if (value == null) {
                if(string.IsNullOrEmpty(this._PhoneTypeName))  return;
                this._PhoneTypeName = null;
            } else {
                if(value.ToString() == this._PhoneTypeName) return;
                this._PhoneTypeName = value.ToString();
            }
            OnPropertyChanged("PhoneTypeName");
            ValidateField(this._PhoneTypeName, "PhoneTypeName");
        }
        protected bool _PhoneTypeNameEnabled = true;
        public bool PhoneTypeNameEnabled {
            get { return _PhoneTypeNameEnabled; }
            set { 
                if(_PhoneTypeNameEnabled != value) 
                { 
                    _PhoneTypeNameEnabled = value; 
                    OnPropertyChanged(); 
                } 
            }
        }
        public string PhoneTypeNameSuffixError {
            get {
                return GetFirstError("PhoneTypeName");
            }
        }

        protected System.String _PhoneTypeDesc = null;
        public System.String PhoneTypeDesc {
            get { return _PhoneTypeDesc; }
            set { 
                if((_PhoneTypeDesc != value)||(value == null)) { 
                    _PhoneTypeDesc = value; 
                    OnPropertyChanged();
                    ValidateField(value);
                } 
            }
        }
        public void PatchPhoneTypeDesc(object value) {
            if (value == null) {
                if(string.IsNullOrEmpty(this._PhoneTypeDesc))  return;
                this._PhoneTypeDesc = null;
            } else {
                if(value.ToString() == this._PhoneTypeDesc) return;
                this._PhoneTypeDesc = value.ToString();
            }
            OnPropertyChanged("PhoneTypeDesc");
            ValidateField(this._PhoneTypeDesc, "PhoneTypeDesc");
        }
        protected bool _PhoneTypeDescEnabled = true;
        public bool PhoneTypeDescEnabled {
            get { return _PhoneTypeDescEnabled; }
            set { 
                if(_PhoneTypeDescEnabled != value) 
                { 
                    _PhoneTypeDescEnabled = value; 
                    OnPropertyChanged(); 
                } 
            }
        }
        public string PhoneTypeDescSuffixError {
            get {
                return GetFirstError("PhoneTypeDesc");
            }
        }

        #endregion

        #region Helper objects and vars
        protected IAppGlblSettingsService GlblSettingsSrv = null;
        protected IDialogService dialogService = null;
        protected IPhbkPhoneTypeViewDatasource rootDataSource = null;
        #endregion

        #region Constructor
        public PhbkPhoneTypeViewDformViewModel(IPhbkPhoneTypeViewDatasource _rootDataSource,
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
            PropertyInfo propertyInfo = typeof(IPhbkPhoneTypeView).GetProperty(filedName);
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
            ValidateField(PhoneTypeId, "PhoneTypeId");
            ValidateField(PhoneTypeName, "PhoneTypeName");
            ValidateField(PhoneTypeDesc, "PhoneTypeDesc");
        }
        public void ClearValidationMessages() {
            ValidationErrors.Clear();
            ValidationDataErrors.Clear();
            RaiseErrorsChanged("PhoneTypeId");
            RaiseErrorsChanged("PhoneTypeName");
            RaiseErrorsChanged("PhoneTypeDesc");
        }
        #endregion


        #region rootDataSourceAfterPropsChanged
        public async void rootDataSourceAfterPropsChanged(object sender, EventArgs e) {
            await DorootDataSourceAfterPropsChanged(sender);
        }
        public async Task DorootDataSourceAfterPropsChanged(object sender) {
            await MainThread.InvokeOnMainThreadAsync(() => {
                this.PatchPhoneTypeId(this.rootDataSource.getValue("PhoneTypeId"));
                this.PatchPhoneTypeName(this.rootDataSource.getValue("PhoneTypeName"));
                this.PatchPhoneTypeDesc(this.rootDataSource.getValue("PhoneTypeDesc"));
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
                this.FormControlModelVM =  NewValue as IPhbkPhoneTypeView;
            });
        }
        protected IPhbkPhoneTypeView _FormControlModelVM = null;
        public IPhbkPhoneTypeView FormControlModelVM
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

