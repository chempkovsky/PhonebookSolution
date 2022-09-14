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
using ModelInterfacesClassLibrary.Phonebook.PhbkDivision;
using CommonInterfacesClassLibrary.Enums;
using CommonInterfacesClassLibrary.AppGlblSettingsSrvc;
using CommonUserControlLibrary.ViewModels;
using CommonCustomControlLibrary.Classes;
using ModelInterfacesClassLibrary.Phonebook.PhbkEnterprise;
/*




    "PhbkDivisionViewAformUserControl" UserControl is defined in the "ModelServicesPrismModule"-project.
    In the file of IModule-class of "ModelServicesPrismModule"-project the following line of code must be inserted:

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ...
            // According to requirements of the "PhbkDivisionViewAformViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            ViewModelLocationProvider.Register<PhbkDivisionViewAformUserControl, PhbkDivisionViewAformViewModel>();
            // According to requirements of the "PhbkDivisionViewAformViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            containerRegistry.Register<ContentView, PhbkDivisionViewAformUserControl>("PhbkDivisionViewAformUserControl");
            ...
        }

*/

namespace ModelServicesPrismModule.Phonebook.PhbkDivision.ViewModels {
    public class PhbkDivisionViewAformViewModel: INotifyPropertyChanged, INotifyDataErrorInfo, IEformViewModelInterface, IBindingContextChanged
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
        protected System.Int32 ? _DivisionId = null;
        public System.Int32 ? DivisionId {
            get { return _DivisionId; }
            set { 
                if((_DivisionId != value)||(value == null)) { 
                    _DivisionId = value; 
                    OnPropertyChanged();
                    ValidateField(value);
                    this.rootDataSource.setValue("DivisionId", value);
                } 
            }
        }
        public void PatchDivisionId(object value) {
            if(value == null) {
                if(!this._DivisionId.HasValue) return;
                this._DivisionId = null;
            } else {
                    var vl = Convert.ToInt32(value);
                    if(this._DivisionId.HasValue) {
                        if(this._DivisionId.Value == vl) return;
                    }
                    this._DivisionId = vl;
            }
            OnPropertyChanged("DivisionId");
            ValidateField(this._DivisionId, "DivisionId");
        }
        protected bool _DivisionIdEnabled = true;
        public bool DivisionIdEnabled {
            get { return _DivisionIdEnabled; }
            set { 
                if(_DivisionIdEnabled != value) 
                { 
                    _DivisionIdEnabled = value; 
                    OnPropertyChanged(); 
                } 
            }
        }
        public string DivisionIdSuffixError {
            get {
                return GetFirstError("DivisionId");
            }
        }

        protected System.String _DivisionName = null;
        public System.String DivisionName {
            get { return _DivisionName; }
            set { 
                if((_DivisionName != value)||(value == null)) { 
                    _DivisionName = value; 
                    OnPropertyChanged();
                    ValidateField(value);
                    this.rootDataSource.setValue("DivisionName", value);
                } 
            }
        }
        public void PatchDivisionName(object value) {
            if (value == null) {
                if(string.IsNullOrEmpty(this._DivisionName))  return;
                this._DivisionName = null;
            } else {
                if(value.ToString() == this._DivisionName) return;
                this._DivisionName = value.ToString();
            }
            OnPropertyChanged("DivisionName");
            ValidateField(this._DivisionName, "DivisionName");
        }
        protected bool _DivisionNameEnabled = true;
        public bool DivisionNameEnabled {
            get { return _DivisionNameEnabled; }
            set { 
                if(_DivisionNameEnabled != value) 
                { 
                    _DivisionNameEnabled = value; 
                    OnPropertyChanged(); 
                } 
            }
        }
        public string DivisionNameSuffixError {
            get {
                return GetFirstError("DivisionName");
            }
        }

        protected System.String _DivisionDesc = null;
        public System.String DivisionDesc {
            get { return _DivisionDesc; }
            set { 
                if((_DivisionDesc != value)||(value == null)) { 
                    _DivisionDesc = value; 
                    OnPropertyChanged();
                    ValidateField(value);
                    this.rootDataSource.setValue("DivisionDesc", value);
                } 
            }
        }
        public void PatchDivisionDesc(object value) {
            if (value == null) {
                if(string.IsNullOrEmpty(this._DivisionDesc))  return;
                this._DivisionDesc = null;
            } else {
                if(value.ToString() == this._DivisionDesc) return;
                this._DivisionDesc = value.ToString();
            }
            OnPropertyChanged("DivisionDesc");
            ValidateField(this._DivisionDesc, "DivisionDesc");
        }
        protected bool _DivisionDescEnabled = true;
        public bool DivisionDescEnabled {
            get { return _DivisionDescEnabled; }
            set { 
                if(_DivisionDescEnabled != value) 
                { 
                    _DivisionDescEnabled = value; 
                    OnPropertyChanged(); 
                } 
            }
        }
        public string DivisionDescSuffixError {
            get {
                return GetFirstError("DivisionDesc");
            }
        }

        protected System.Int32 ? _EntrprsIdRef = null;
        public System.Int32 ? EntrprsIdRef {
            get { return _EntrprsIdRef; }
            set { 
                if((_EntrprsIdRef != value)||(value == null)) { 
                    _EntrprsIdRef = value; 
                    OnPropertyChanged();
                    ValidateField(value);
                } 
            }
        }
        public void PatchEntrprsIdRef(object value) {
            if(value == null) {
                if(!this._EntrprsIdRef.HasValue) return;
                this._EntrprsIdRef = null;
            } else {
                    var vl = Convert.ToInt32(value);
                    if(this._EntrprsIdRef.HasValue) {
                        if(this._EntrprsIdRef.Value == vl) return;
                    }
                    this._EntrprsIdRef = vl;
            }
            OnPropertyChanged("EntrprsIdRef");
            ValidateField(this._EntrprsIdRef, "EntrprsIdRef");
        }
        protected bool _EntrprsIdRefEnabled = true;
        public bool EntrprsIdRefEnabled {
            get { return _EntrprsIdRefEnabled; }
            set { 
                if(_EntrprsIdRefEnabled != value) 
                { 
                    _EntrprsIdRefEnabled = value; 
                    OnPropertyChanged(); 
                } 
            }
        }
        public string EntrprsIdRefSuffixError {
            get {
                return GetFirstError("EntrprsIdRef");
            }
        }

        protected System.String _EEntrprsName = null;
        public System.String EEntrprsName {
            get { return _EEntrprsName; }
            set { 
                if((_EEntrprsName != value)||(value == null)) { 
                    _EEntrprsName = value; 
                    OnPropertyChanged();
                    ValidateField(value);
                } 
            }
        }
        public void PatchEEntrprsName(object value) {
            if (value == null) {
                if(string.IsNullOrEmpty(this._EEntrprsName))  return;
                this._EEntrprsName = null;
            } else {
                if(value.ToString() == this._EEntrprsName) return;
                this._EEntrprsName = value.ToString();
            }
            OnPropertyChanged("EEntrprsName");
            ValidateField(this._EEntrprsName, "EEntrprsName");
        }
        protected bool _EEntrprsNameEnabled = true;
        public bool EEntrprsNameEnabled {
            get { return _EEntrprsNameEnabled; }
            set { 
                if(_EEntrprsNameEnabled != value) 
                { 
                    _EEntrprsNameEnabled = value; 
                    OnPropertyChanged(); 
                } 
            }
        }
        public string EEntrprsNameSuffixError {
            get {
                return GetFirstError("EEntrprsName");
            }
        }

        #endregion

        #region Helper objects and vars
        protected IAppGlblSettingsService GlblSettingsSrv = null;
        protected IDialogService dialogService = null;
        protected IPhbkDivisionViewDatasource rootDataSource = null;
        protected IPhbkEnterpriseViewDatasource EEntrprsNameDtSrc = null;
        protected object _EEntrprsNameCmbCntrl = null;
        public object EEntrprsNameCmbCntrl {
            get { 
                return _EEntrprsNameCmbCntrl; 
            }
            set { 
                var val = value as IPhbkEnterpriseView;
                if(_EEntrprsNameCmbCntrl != val) { 
                    _EEntrprsNameCmbCntrl = val; 
                    if(val == null) {
                        this.EEntrprsNameDtSrc.ClearPartially(true);
                    } else {
                        this.EEntrprsNameDtSrc.Interface2Values(val, true);
                    }
                    OnPropertyChanged(); 
                    ValidateField(value);
                } 
            }
        }
        public string EEntrprsNameCmbCntrlSuffixError {
            get {
                return GetFirstError("EEntrprsNameCmbCntrl");
            }
        }
        protected IList<IPhbkEnterpriseView> _EEntrprsNameCmbCntrlVals = null;
        public IList<IPhbkEnterpriseView> EEntrprsNameCmbCntrlVals {
            get { 
                return _EEntrprsNameCmbCntrlVals; 
            }
            set { 
                if(_EEntrprsNameCmbCntrlVals != value) { 
                    _EEntrprsNameCmbCntrlVals = value; 
                    OnPropertyChanged(); 
                } 
            }
        }
        #endregion

        #region Constructor
        public PhbkDivisionViewAformViewModel(IPhbkDivisionViewDatasource _rootDataSource,
            IPhbkEnterpriseViewDatasource _EEntrprsNameDtSrc,
            IAppGlblSettingsService _GlblSettingsSrv, 
            IDialogService _dialogService) {
            this.GlblSettingsSrv = _GlblSettingsSrv;
            this.dialogService = _dialogService;
            this.rootDataSource = _rootDataSource;
            this.rootDataSource.Init(null, null, new List<string>{"Enterprise"},"");
            this.rootDataSource.setIsNew(false);
            this.rootDataSource.AfterPropsChanged += this.rootDataSourceAfterPropsChanged;

            this.rootDataSource.OnAdd += this.rootDataSourceOnAdd;


            this.EEntrprsNameDtSrc = _EEntrprsNameDtSrc;
            this.EEntrprsNameDtSrc.Init("PhbkDivisionView", "Enterprise", new List<string>{},"Enterprise");
            this.EEntrprsNameDtSrc.setIsNew(false);
            this.EEntrprsNameDtSrc.AfterPropsChanged += this.EEntrprsNameAfterPropsChanged;
            this.EEntrprsNameDtSrc.AfterMasterChanged += this.EEntrprsNameAfterMasterChanged;
            this.EEntrprsNameDtSrc.OnMasterChanged += this.rootDataSource.SubmitOnMasterChanged;
            this.rootDataSource.OnDetailChanged += this.EEntrprsNameDtSrc.SubmitOnDetailChanged;

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
            PropertyInfo propertyInfo = typeof(IPhbkDivisionView).GetProperty(filedName);
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
                case "EEntrprsNameCmbCntrl":
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
            ValidateField(DivisionId, "DivisionId");
            ValidateField(DivisionName, "DivisionName");
            ValidateField(DivisionDesc, "DivisionDesc");
            ValidateField(EntrprsIdRef, "EntrprsIdRef");
            ValidateField(EEntrprsName, "EEntrprsName");
            ValidateObjectField(EEntrprsNameCmbCntrl, "EEntrprsNameCmbCntrl");
        }
        public void ClearValidationMessages() {
            ValidationErrors.Clear();
            ValidationDataErrors.Clear();
            RaiseErrorsChanged("DivisionId");
            RaiseErrorsChanged("DivisionName");
            RaiseErrorsChanged("DivisionDesc");
            RaiseErrorsChanged("EntrprsIdRef");
            RaiseErrorsChanged("EEntrprsName");
            RaiseErrorsChanged("EEntrprsNameCmbCntrl");
        }
        #endregion


        #region rootDataSourceAfterPropsChanged
        public async void rootDataSourceAfterPropsChanged(object sender, EventArgs e) {
            await DorootDataSourceAfterPropsChanged(sender);
        }
        public async Task DorootDataSourceAfterPropsChanged(object sender) {
            await MainThread.InvokeOnMainThreadAsync(() => {
                this.PatchDivisionId(this.rootDataSource.getValue("DivisionId"));
                this.PatchDivisionName(this.rootDataSource.getValue("DivisionName"));
                this.PatchDivisionDesc(this.rootDataSource.getValue("DivisionDesc"));
                this.PatchEntrprsIdRef(this.rootDataSource.getValue("EntrprsIdRef"));
                this.EEntrprsNameEnabled = 
                    (!this.rootDataSource.isUnderHiddenFilterFields("EEntrprsName")) &&
                    this.EEntrprsNameDtSrc.IsSetFilterByCurrDirMstrs();
            });
        }
        #endregion

        #region rootDataSourceOnAdd
        public async void rootDataSourceOnAdd(object sender, EventArgs e) { 
            object  itm = this.rootDataSource.Values2Interface();
            await MainThread.InvokeOnMainThreadAsync(() => {
                BindingContextFeedbackRef = new BindingContextFeedback() {
		            BcfName = "SubmitCommand",
		            BcfData = itm
                };
            });
        }
        #endregion

        #region EEntrprsNameAfterMasterChanged
        public async void EEntrprsNameAfterMasterChanged(object sender, EventArgs ea) {
            await DoEEntrprsNameAfterMasterChanged(sender);
        }
        public async Task DoEEntrprsNameAfterMasterChanged(object sender) {
                IList<IPhbkEnterpriseView> data = null;
                IPhbkEnterpriseView newItm = null;
                try {
                    data = await this.EEntrprsNameDtSrc.GetClActionByCurrDirMstrs();
                    if(data != null) {
                        if(this.EEntrprsNameDtSrc.CalcIsDefined()) {
                            IPhbkEnterpriseView currItm = this.EEntrprsNameDtSrc.Values2Interface();
                            newItm = data.Where(e => (e.EntrprsId == currItm.EntrprsId)).FirstOrDefault();
                        }
                    }
                } catch(Exception ex)
                {
                    string exceptionMsg = "EEntrprsNameAfterMasterChanged : " + ex.Message;
                    Exception inner = ex.InnerException;
                    while (inner != null)
                    {
                        exceptionMsg = exceptionMsg + ": " + inner.Message;
                        inner = inner.InnerException;
                    }
                    GlblSettingsSrv.ShowErrorMessage("http", exceptionMsg);
                }


            await MainThread.InvokeOnMainThreadAsync(() => {
                _EEntrprsNameCmbCntrl = null;
                OnPropertyChanged("EEntrprsNameCmbCntrl");
                this._EEntrprsNameCmbCntrlVals = data;
                OnPropertyChanged("EEntrprsNameCmbCntrlVals");
                this._EEntrprsNameCmbCntrl = newItm;
                OnPropertyChanged("EEntrprsNameCmbCntrl");
                ValidateObjectField(newItm, "EEntrprsNameCmbCntrl");
                if(newItm != null)
                    this.EEntrprsName = newItm.EntrprsName;
                else
                    this.EEntrprsName = null;
                if(this.EEntrprsNameDtSrc.IsSetFilterByCurrDirMstrs() &&
                  (!this.rootDataSource.isUnderHiddenFilterFields("EEntrprsName"))) {
                    this.EEntrprsNameEnabled = true;
                } else {
                    this.EEntrprsNameEnabled = false;
                }

            });
        }
        #endregion
        #region EEntrprsNameAfterPropsChanged
        public async void EEntrprsNameAfterPropsChanged(object sender, EventArgs ea) {
            await DoEEntrprsNameAfterPropsChanged(sender);
        }
        public async Task DoEEntrprsNameAfterPropsChanged(object sender) {
            await MainThread.InvokeOnMainThreadAsync(() => {

            if(this.EEntrprsNameCmbCntrlVals != null) {
                IPhbkEnterpriseView currItm = this.EEntrprsNameDtSrc.Values2Interface();
                IPhbkEnterpriseView newItm = null;
                if(currItm != null) {
                    newItm = this.EEntrprsNameCmbCntrlVals.Where(e => (e.EntrprsId == currItm.EntrprsId)).FirstOrDefault();
                }
                this._EEntrprsNameCmbCntrl = newItm;
                OnPropertyChanged("EEntrprsNameCmbCntrl");
                ValidateObjectField(newItm, "EEntrprsNameCmbCntrl");
                if(newItm != null)
                    this.PatchEEntrprsName(newItm.EntrprsName);
                else 
                    this.PatchEEntrprsName(null);
            } else {
                this._EEntrprsNameCmbCntrl = null;
                OnPropertyChanged("EEntrprsNameCmbCntrl");
                ValidateObjectField(null, "EEntrprsNameCmbCntrl");
                this.PatchEEntrprsName(null);
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
                this.rootDataSource.addone();
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
            this.rootDataSource.Clear(false);
            this.rootDataSource.setHiddenFilter(this.rootDataSource.getHiddenFilterByFltRslt(this.HiddenFiltersVM));
            this.rootDataSource.UpdateByHiddenFilterFields(false);
            this.rootDataSource.DoEmitEvent(false);
        }
        public async Task FormControlModelChanged(object sender, object OldValue, object NewValue) {
            if (IsDestroyed) return;
            await MainThread.InvokeOnMainThreadAsync(() => {
                this.FormControlModelVM =  NewValue as IPhbkDivisionView;
            });
        }
        protected IPhbkDivisionView _FormControlModelVM = null;
        public IPhbkDivisionView FormControlModelVM
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
                                await this.DoEEntrprsNameAfterMasterChanged(this.EEntrprsNameDtSrc);
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
            this.rootDataSource.OnAdd -= this.rootDataSourceOnAdd;
            this.EEntrprsNameDtSrc.AfterPropsChanged -= this.EEntrprsNameAfterPropsChanged;
            this.EEntrprsNameDtSrc.AfterMasterChanged -= this.EEntrprsNameAfterMasterChanged;
            this.EEntrprsNameDtSrc.OnMasterChanged -= this.rootDataSource.SubmitOnMasterChanged;
            this.rootDataSource.OnDetailChanged -= this.EEntrprsNameDtSrc.SubmitOnDetailChanged;

            _EEntrprsNameCmbCntrl = null;
            _EEntrprsNameCmbCntrlVals = null;
        }
        #endregion

    }
}

