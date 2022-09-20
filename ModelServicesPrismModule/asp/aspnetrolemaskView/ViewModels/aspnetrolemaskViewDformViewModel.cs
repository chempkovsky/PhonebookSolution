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
using ModelInterfacesClassLibrary.interfaces.asp.aspnetrolemaskView;
using CommonInterfacesClassLibrary.Enums;
using CommonInterfacesClassLibrary.AppGlblSettingsSrvc;
using CommonUserControlLibrary.ViewModels;
using CommonCustomControlLibrary.Classes;
/*




    "AspnetrolemaskViewDformUserControl" UserControl is defined in the "ModelServicesPrismModule"-project.
    In the file of IModule-class of "ModelServicesPrismModule"-project the following line of code must be inserted:

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ...
            // According to requirements of the "AspnetrolemaskViewDformViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            ViewModelLocationProvider.Register<AspnetrolemaskViewDformUserControl, AspnetrolemaskViewDformViewModel>();
            // According to requirements of the "AspnetrolemaskViewDformViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            containerRegistry.Register<ContentView, AspnetrolemaskViewDformUserControl>("AspnetrolemaskViewDformUserControl");
            ...
        }

*/

namespace ModelServicesPrismModule.asp.aspnetrolemaskView.ViewModels {
    public class AspnetrolemaskViewDformViewModel: INotifyPropertyChanged, INotifyDataErrorInfo, IEformViewModelInterface, IBindingContextChanged
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

        protected System.String _RoleDescription = null;
        public System.String RoleDescription {
            get { return _RoleDescription; }
            set { 
                if((_RoleDescription != value)||(value == null)) { 
                    _RoleDescription = value; 
                    OnPropertyChanged();
                    ValidateField(value);
                } 
            }
        }
        public void PatchRoleDescription(object value) {
            if (value == null) {
                if(string.IsNullOrEmpty(this._RoleDescription))  return;
                this._RoleDescription = null;
            } else {
                if(value.ToString() == this._RoleDescription) return;
                this._RoleDescription = value.ToString();
            }
            OnPropertyChanged("RoleDescription");
            ValidateField(this._RoleDescription, "RoleDescription");
        }
        protected bool _RoleDescriptionEnabled = true;
        public bool RoleDescriptionEnabled {
            get { return _RoleDescriptionEnabled; }
            set { 
                if(_RoleDescriptionEnabled != value) 
                { 
                    _RoleDescriptionEnabled = value; 
                    OnPropertyChanged(); 
                } 
            }
        }
        public string RoleDescriptionSuffixError {
            get {
                return GetFirstError("RoleDescription");
            }
        }

        protected System.Int32 ? _ModelPkRef = null;
        public System.Int32 ? ModelPkRef {
            get { return _ModelPkRef; }
            set { 
                if((_ModelPkRef != value)||(value == null)) { 
                    _ModelPkRef = value; 
                    OnPropertyChanged();
                    ValidateField(value);
                } 
            }
        }
        public void PatchModelPkRef(object value) {
            if(value == null) {
                if(!this._ModelPkRef.HasValue) return;
                this._ModelPkRef = null;
            } else {
                    var vl = Convert.ToInt32(value);
                    if(this._ModelPkRef.HasValue) {
                        if(this._ModelPkRef.Value == vl) return;
                    }
                    this._ModelPkRef = vl;
            }
            OnPropertyChanged("ModelPkRef");
            ValidateField(this._ModelPkRef, "ModelPkRef");
        }
        protected bool _ModelPkRefEnabled = true;
        public bool ModelPkRefEnabled {
            get { return _ModelPkRefEnabled; }
            set { 
                if(_ModelPkRefEnabled != value) 
                { 
                    _ModelPkRefEnabled = value; 
                    OnPropertyChanged(); 
                } 
            }
        }
        public string ModelPkRefSuffixError {
            get {
                return GetFirstError("ModelPkRef");
            }
        }

        protected System.String _MModelName = null;
        public System.String MModelName {
            get { return _MModelName; }
            set { 
                if((_MModelName != value)||(value == null)) { 
                    _MModelName = value; 
                    OnPropertyChanged();
                    ValidateField(value);
                } 
            }
        }
        public void PatchMModelName(object value) {
            if (value == null) {
                if(string.IsNullOrEmpty(this._MModelName))  return;
                this._MModelName = null;
            } else {
                if(value.ToString() == this._MModelName) return;
                this._MModelName = value.ToString();
            }
            OnPropertyChanged("MModelName");
            ValidateField(this._MModelName, "MModelName");
        }
        protected bool _MModelNameEnabled = true;
        public bool MModelNameEnabled {
            get { return _MModelNameEnabled; }
            set { 
                if(_MModelNameEnabled != value) 
                { 
                    _MModelNameEnabled = value; 
                    OnPropertyChanged(); 
                } 
            }
        }
        public string MModelNameSuffixError {
            get {
                return GetFirstError("MModelName");
            }
        }

        protected System.Boolean ? _Mask1 = null;
        public System.Boolean ? Mask1 {
            get { return _Mask1; }
            set { 
                if((_Mask1 != value)||(value == null)) { 
                    _Mask1 = value; 
                    OnPropertyChanged();
                    ValidateField(value);
                } 
            }
        }
        public void PatchMask1(object value) {
            if(value == null) {
                if(!this._Mask1.HasValue) return;
                this._Mask1 = null;
            } else {
                    var vl = Convert.ToBoolean(value);
                    if(this._Mask1.HasValue) {
                        if(this._Mask1.Value == vl) return;
                    }
                    this._Mask1 = vl;
            }
            OnPropertyChanged("Mask1");
            ValidateField(this._Mask1, "Mask1");
        }
        protected bool _Mask1Enabled = true;
        public bool Mask1Enabled {
            get { return _Mask1Enabled; }
            set { 
                if(_Mask1Enabled != value) 
                { 
                    _Mask1Enabled = value; 
                    OnPropertyChanged(); 
                } 
            }
        }
        public string Mask1SuffixError {
            get {
                return GetFirstError("Mask1");
            }
        }

        protected System.Boolean ? _Mask2 = null;
        public System.Boolean ? Mask2 {
            get { return _Mask2; }
            set { 
                if((_Mask2 != value)||(value == null)) { 
                    _Mask2 = value; 
                    OnPropertyChanged();
                    ValidateField(value);
                } 
            }
        }
        public void PatchMask2(object value) {
            if(value == null) {
                if(!this._Mask2.HasValue) return;
                this._Mask2 = null;
            } else {
                    var vl = Convert.ToBoolean(value);
                    if(this._Mask2.HasValue) {
                        if(this._Mask2.Value == vl) return;
                    }
                    this._Mask2 = vl;
            }
            OnPropertyChanged("Mask2");
            ValidateField(this._Mask2, "Mask2");
        }
        protected bool _Mask2Enabled = true;
        public bool Mask2Enabled {
            get { return _Mask2Enabled; }
            set { 
                if(_Mask2Enabled != value) 
                { 
                    _Mask2Enabled = value; 
                    OnPropertyChanged(); 
                } 
            }
        }
        public string Mask2SuffixError {
            get {
                return GetFirstError("Mask2");
            }
        }

        protected System.Boolean ? _Mask3 = null;
        public System.Boolean ? Mask3 {
            get { return _Mask3; }
            set { 
                if((_Mask3 != value)||(value == null)) { 
                    _Mask3 = value; 
                    OnPropertyChanged();
                    ValidateField(value);
                } 
            }
        }
        public void PatchMask3(object value) {
            if(value == null) {
                if(!this._Mask3.HasValue) return;
                this._Mask3 = null;
            } else {
                    var vl = Convert.ToBoolean(value);
                    if(this._Mask3.HasValue) {
                        if(this._Mask3.Value == vl) return;
                    }
                    this._Mask3 = vl;
            }
            OnPropertyChanged("Mask3");
            ValidateField(this._Mask3, "Mask3");
        }
        protected bool _Mask3Enabled = true;
        public bool Mask3Enabled {
            get { return _Mask3Enabled; }
            set { 
                if(_Mask3Enabled != value) 
                { 
                    _Mask3Enabled = value; 
                    OnPropertyChanged(); 
                } 
            }
        }
        public string Mask3SuffixError {
            get {
                return GetFirstError("Mask3");
            }
        }

        protected System.Boolean ? _Mask4 = null;
        public System.Boolean ? Mask4 {
            get { return _Mask4; }
            set { 
                if((_Mask4 != value)||(value == null)) { 
                    _Mask4 = value; 
                    OnPropertyChanged();
                    ValidateField(value);
                } 
            }
        }
        public void PatchMask4(object value) {
            if(value == null) {
                if(!this._Mask4.HasValue) return;
                this._Mask4 = null;
            } else {
                    var vl = Convert.ToBoolean(value);
                    if(this._Mask4.HasValue) {
                        if(this._Mask4.Value == vl) return;
                    }
                    this._Mask4 = vl;
            }
            OnPropertyChanged("Mask4");
            ValidateField(this._Mask4, "Mask4");
        }
        protected bool _Mask4Enabled = true;
        public bool Mask4Enabled {
            get { return _Mask4Enabled; }
            set { 
                if(_Mask4Enabled != value) 
                { 
                    _Mask4Enabled = value; 
                    OnPropertyChanged(); 
                } 
            }
        }
        public string Mask4SuffixError {
            get {
                return GetFirstError("Mask4");
            }
        }

        protected System.Boolean ? _Mask5 = null;
        public System.Boolean ? Mask5 {
            get { return _Mask5; }
            set { 
                if((_Mask5 != value)||(value == null)) { 
                    _Mask5 = value; 
                    OnPropertyChanged();
                    ValidateField(value);
                } 
            }
        }
        public void PatchMask5(object value) {
            if(value == null) {
                if(!this._Mask5.HasValue) return;
                this._Mask5 = null;
            } else {
                    var vl = Convert.ToBoolean(value);
                    if(this._Mask5.HasValue) {
                        if(this._Mask5.Value == vl) return;
                    }
                    this._Mask5 = vl;
            }
            OnPropertyChanged("Mask5");
            ValidateField(this._Mask5, "Mask5");
        }
        protected bool _Mask5Enabled = true;
        public bool Mask5Enabled {
            get { return _Mask5Enabled; }
            set { 
                if(_Mask5Enabled != value) 
                { 
                    _Mask5Enabled = value; 
                    OnPropertyChanged(); 
                } 
            }
        }
        public string Mask5SuffixError {
            get {
                return GetFirstError("Mask5");
            }
        }

        #endregion

        #region Helper objects and vars
        protected IAppGlblSettingsService GlblSettingsSrv = null;
        protected IDialogService dialogService = null;
        protected IAspnetrolemaskViewDatasource rootDataSource = null;
        #endregion

        #region Constructor
        public AspnetrolemaskViewDformViewModel(IAspnetrolemaskViewDatasource _rootDataSource,
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
            PropertyInfo propertyInfo = typeof(IAspnetrolemaskView).GetProperty(filedName);
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
            ValidateField(RName, "RName");
            ValidateField(RoleDescription, "RoleDescription");
            ValidateField(ModelPkRef, "ModelPkRef");
            ValidateField(MModelName, "MModelName");
            ValidateField(Mask1, "Mask1");
            ValidateField(Mask2, "Mask2");
            ValidateField(Mask3, "Mask3");
            ValidateField(Mask4, "Mask4");
            ValidateField(Mask5, "Mask5");
        }
        public void ClearValidationMessages() {
            ValidationErrors.Clear();
            ValidationDataErrors.Clear();
            RaiseErrorsChanged("RName");
            RaiseErrorsChanged("RoleDescription");
            RaiseErrorsChanged("ModelPkRef");
            RaiseErrorsChanged("MModelName");
            RaiseErrorsChanged("Mask1");
            RaiseErrorsChanged("Mask2");
            RaiseErrorsChanged("Mask3");
            RaiseErrorsChanged("Mask4");
            RaiseErrorsChanged("Mask5");
        }
        #endregion


        #region rootDataSourceAfterPropsChanged
        public async void rootDataSourceAfterPropsChanged(object sender, EventArgs e) {
            await DorootDataSourceAfterPropsChanged(sender);
        }
        public async Task DorootDataSourceAfterPropsChanged(object sender) {
            await MainThread.InvokeOnMainThreadAsync(() => {
                this.PatchRName(this.rootDataSource.getValue("RName"));
                this.PatchRoleDescription(this.rootDataSource.getValue("RoleDescription"));
                this.PatchModelPkRef(this.rootDataSource.getValue("ModelPkRef"));
                this.PatchMModelName(this.rootDataSource.getValue("MModelName"));
                this.PatchMask1(this.rootDataSource.getValue("Mask1"));
                this.PatchMask2(this.rootDataSource.getValue("Mask2"));
                this.PatchMask3(this.rootDataSource.getValue("Mask3"));
                this.PatchMask4(this.rootDataSource.getValue("Mask4"));
                this.PatchMask5(this.rootDataSource.getValue("Mask5"));
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
                this.FormControlModelVM =  NewValue as IAspnetrolemaskView;
            });
        }
        protected IAspnetrolemaskView _FormControlModelVM = null;
        public IAspnetrolemaskView FormControlModelVM
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

