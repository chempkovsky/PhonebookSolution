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
using ModelInterfacesClassLibrary.Phonebook.PhbkEnterprise;
using CommonInterfacesClassLibrary.Enums;
using CommonInterfacesClassLibrary.AppGlblSettingsSrvc;
using CommonUserControlLibrary.ViewModels;
using CommonCustomControlLibrary.Classes;
/*




    "PhbkEnterpriseViewVformUserControl" UserControl is defined in the "ModelServicesPrismModule"-project.
    In the file of IModule-class of "ModelServicesPrismModule"-project the following line of code must be inserted:

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ...
            // According to requirements of the "PhbkEnterpriseViewVformViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            ViewModelLocationProvider.Register<PhbkEnterpriseViewVformUserControl, PhbkEnterpriseViewVformViewModel>();
            // According to requirements of the "PhbkEnterpriseViewVformViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            containerRegistry.Register<ContentView, PhbkEnterpriseViewVformUserControl>("PhbkEnterpriseViewVformUserControl");
            ...
        }

*/

namespace ModelServicesPrismModule.Phonebook.PhbkEnterprise.ViewModels {
    public class PhbkEnterpriseViewVformViewModel: INotifyPropertyChanged, INotifyDataErrorInfo, IEformViewModelInterface, IBindingContextChanged
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
        protected System.Int32 ? _EntrprsId = null;
        public System.Int32 ? EntrprsId {
            get { return _EntrprsId; }
            set { 
                if((_EntrprsId != value)||(value == null)) { 
                    _EntrprsId = value; 
                    OnPropertyChanged();
                    ValidateField(value);
                } 
            }
        }
        public void PatchEntrprsId(object value) {
            if(value == null) {
                if(!this._EntrprsId.HasValue) return;
                this._EntrprsId = null;
            } else {
                    var vl = Convert.ToInt32(value);
                    if(this._EntrprsId.HasValue) {
                        if(this._EntrprsId.Value == vl) return;
                    }
                    this._EntrprsId = vl;
            }
            OnPropertyChanged("EntrprsId");
            ValidateField(this._EntrprsId, "EntrprsId");
        }
        protected bool _EntrprsIdEnabled = true;
        public bool EntrprsIdEnabled {
            get { return _EntrprsIdEnabled; }
            set { 
                if(_EntrprsIdEnabled != value) 
                { 
                    _EntrprsIdEnabled = value; 
                    OnPropertyChanged(); 
                } 
            }
        }
        public string EntrprsIdSuffixError {
            get {
                return GetFirstError("EntrprsId");
            }
        }

        protected System.String _EntrprsName = null;
        public System.String EntrprsName {
            get { return _EntrprsName; }
            set { 
                if((_EntrprsName != value)||(value == null)) { 
                    _EntrprsName = value; 
                    OnPropertyChanged();
                    ValidateField(value);
                } 
            }
        }
        public void PatchEntrprsName(object value) {
            if (value == null) {
                if(string.IsNullOrEmpty(this._EntrprsName))  return;
                this._EntrprsName = null;
            } else {
                if(value.ToString() == this._EntrprsName) return;
                this._EntrprsName = value.ToString();
            }
            OnPropertyChanged("EntrprsName");
            ValidateField(this._EntrprsName, "EntrprsName");
        }
        protected bool _EntrprsNameEnabled = true;
        public bool EntrprsNameEnabled {
            get { return _EntrprsNameEnabled; }
            set { 
                if(_EntrprsNameEnabled != value) 
                { 
                    _EntrprsNameEnabled = value; 
                    OnPropertyChanged(); 
                } 
            }
        }
        public string EntrprsNameSuffixError {
            get {
                return GetFirstError("EntrprsName");
            }
        }

        protected System.String _EntrprsDesc = null;
        public System.String EntrprsDesc {
            get { return _EntrprsDesc; }
            set { 
                if((_EntrprsDesc != value)||(value == null)) { 
                    _EntrprsDesc = value; 
                    OnPropertyChanged();
                    ValidateField(value);
                } 
            }
        }
        public void PatchEntrprsDesc(object value) {
            if (value == null) {
                if(string.IsNullOrEmpty(this._EntrprsDesc))  return;
                this._EntrprsDesc = null;
            } else {
                if(value.ToString() == this._EntrprsDesc) return;
                this._EntrprsDesc = value.ToString();
            }
            OnPropertyChanged("EntrprsDesc");
            ValidateField(this._EntrprsDesc, "EntrprsDesc");
        }
        protected bool _EntrprsDescEnabled = true;
        public bool EntrprsDescEnabled {
            get { return _EntrprsDescEnabled; }
            set { 
                if(_EntrprsDescEnabled != value) 
                { 
                    _EntrprsDescEnabled = value; 
                    OnPropertyChanged(); 
                } 
            }
        }
        public string EntrprsDescSuffixError {
            get {
                return GetFirstError("EntrprsDesc");
            }
        }

        #endregion

        #region Helper objects and vars
        protected IAppGlblSettingsService GlblSettingsSrv = null;
        protected IDialogService dialogService = null;
        protected IPhbkEnterpriseViewDatasource rootDataSource = null;
        #endregion

        #region Constructor
        public PhbkEnterpriseViewVformViewModel(IPhbkEnterpriseViewDatasource _rootDataSource,
            IAppGlblSettingsService _GlblSettingsSrv, 
            IDialogService _dialogService) {
            this.GlblSettingsSrv = _GlblSettingsSrv;
            this.dialogService = _dialogService;
            this.rootDataSource = _rootDataSource;
            this.rootDataSource.Init(null, null, new List<string>{},"");
            this.rootDataSource.setIsNew(false);
            this.rootDataSource.AfterPropsChanged += this.rootDataSourceAfterPropsChanged;



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
            PropertyInfo propertyInfo = typeof(IPhbkEnterpriseView).GetProperty(filedName);
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
            ValidateField(EntrprsId, "EntrprsId");
            ValidateField(EntrprsName, "EntrprsName");
            ValidateField(EntrprsDesc, "EntrprsDesc");
        }
        public void ClearValidationMessages() {
            ValidationErrors.Clear();
            ValidationDataErrors.Clear();
            RaiseErrorsChanged("EntrprsId");
            RaiseErrorsChanged("EntrprsName");
            RaiseErrorsChanged("EntrprsDesc");
        }
        #endregion


        #region rootDataSourceAfterPropsChanged
        public async void rootDataSourceAfterPropsChanged(object sender, EventArgs e) {
            await DorootDataSourceAfterPropsChanged(sender);
        }
        public async Task DorootDataSourceAfterPropsChanged(object sender) {
            await MainThread.InvokeOnMainThreadAsync(() => {
                this.PatchEntrprsId(this.rootDataSource.getValue("EntrprsId"));
                this.PatchEntrprsName(this.rootDataSource.getValue("EntrprsName"));
                this.PatchEntrprsDesc(this.rootDataSource.getValue("EntrprsDesc"));
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
                this.CancelCommandAction(null);

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
                this.FormControlModelVM =  NewValue as IPhbkEnterpriseView;
            });
        }
        protected IPhbkEnterpriseView _FormControlModelVM = null;
        public IPhbkEnterpriseView FormControlModelVM
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
        }
        #endregion

    }
}

