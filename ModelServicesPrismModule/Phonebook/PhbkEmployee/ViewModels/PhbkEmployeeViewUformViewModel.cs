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
using ModelInterfacesClassLibrary.Phonebook.PhbkEmployee;
using CommonInterfacesClassLibrary.Enums;
using CommonInterfacesClassLibrary.AppGlblSettingsSrvc;
using CommonUserControlLibrary.ViewModels;
using CommonCustomControlLibrary.Classes;
using ModelInterfacesClassLibrary.Phonebook.PhbkDivision;
using ModelInterfacesClassLibrary.Phonebook.PhbkEnterprise;
/*


        Reminder:
        "PhbkDivisionViewSdlgUserControl" UserControl is defined in the "ModelServicesPrismModule"-project.
        In the file of IModule-class of "ModelServicesPrismModule"-project the following line of code must be inserted:

            public void RegisterTypes(IContainerRegistry containerRegistry)
            {
                ...
                // According to requirements of the "PhbkDivisionViewSdlgViewModel.cs"-file of "ModelServicesPrismModule"-project. 
                containerRegistry.RegisterDialog<PhbkDivisionViewSdlgUserControl, SdlgViewModelBase>("PhbkDivisionViewSdlgViewModel");
                ...
            }

        Reminder:
        "PhbkEnterpriseViewSdlgUserControl" UserControl is defined in the "ModelServicesPrismModule"-project.
        In the file of IModule-class of "ModelServicesPrismModule"-project the following line of code must be inserted:

            public void RegisterTypes(IContainerRegistry containerRegistry)
            {
                ...
                // According to requirements of the "PhbkEnterpriseViewSdlgViewModel.cs"-file of "ModelServicesPrismModule"-project. 
                containerRegistry.RegisterDialog<PhbkEnterpriseViewSdlgUserControl, SdlgViewModelBase>("PhbkEnterpriseViewSdlgViewModel");
                ...
            }



    "PhbkEmployeeViewUformUserControl" UserControl is defined in the "ModelServicesPrismModule"-project.
    In the file of IModule-class of "ModelServicesPrismModule"-project the following line of code must be inserted:

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ...
            // According to requirements of the "PhbkEmployeeViewUformViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            ViewModelLocationProvider.Register<PhbkEmployeeViewUformUserControl, PhbkEmployeeViewUformViewModel>();
            // According to requirements of the "PhbkEmployeeViewUformViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            containerRegistry.Register<ContentView, PhbkEmployeeViewUformUserControl>("PhbkEmployeeViewUformUserControl");
            ...
        }

*/

namespace ModelServicesPrismModule.Phonebook.PhbkEmployee.ViewModels {
    public class PhbkEmployeeViewUformViewModel: INotifyPropertyChanged, INotifyDataErrorInfo, IEformViewModelInterface, IBindingContextChanged
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
        protected System.Int32 ? _EmployeeId = null;
        public System.Int32 ? EmployeeId {
            get { return _EmployeeId; }
            set { 
                if((_EmployeeId != value)||(value == null)) { 
                    _EmployeeId = value; 
                    OnPropertyChanged();
                    ValidateField(value);
                } 
            }
        }
        public void PatchEmployeeId(object value) {
            if(value == null) {
                if(!this._EmployeeId.HasValue) return;
                this._EmployeeId = null;
            } else {
                    var vl = Convert.ToInt32(value);
                    if(this._EmployeeId.HasValue) {
                        if(this._EmployeeId.Value == vl) return;
                    }
                    this._EmployeeId = vl;
            }
            OnPropertyChanged("EmployeeId");
            ValidateField(this._EmployeeId, "EmployeeId");
        }
        protected bool _EmployeeIdEnabled = true;
        public bool EmployeeIdEnabled {
            get { return _EmployeeIdEnabled; }
            set { 
                if(_EmployeeIdEnabled != value) 
                { 
                    _EmployeeIdEnabled = value; 
                    OnPropertyChanged(); 
                } 
            }
        }
        public string EmployeeIdSuffixError {
            get {
                return GetFirstError("EmployeeId");
            }
        }

        protected System.String _EmpFirstName = null;
        public System.String EmpFirstName {
            get { return _EmpFirstName; }
            set { 
                if((_EmpFirstName != value)||(value == null)) { 
                    _EmpFirstName = value; 
                    OnPropertyChanged();
                    ValidateField(value);
                    this.rootDataSource.setValue("EmpFirstName", value);
                } 
            }
        }
        public void PatchEmpFirstName(object value) {
            if (value == null) {
                if(string.IsNullOrEmpty(this._EmpFirstName))  return;
                this._EmpFirstName = null;
            } else {
                if(value.ToString() == this._EmpFirstName) return;
                this._EmpFirstName = value.ToString();
            }
            OnPropertyChanged("EmpFirstName");
            ValidateField(this._EmpFirstName, "EmpFirstName");
        }
        protected bool _EmpFirstNameEnabled = true;
        public bool EmpFirstNameEnabled {
            get { return _EmpFirstNameEnabled; }
            set { 
                if(_EmpFirstNameEnabled != value) 
                { 
                    _EmpFirstNameEnabled = value; 
                    OnPropertyChanged(); 
                } 
            }
        }
        public string EmpFirstNameSuffixError {
            get {
                return GetFirstError("EmpFirstName");
            }
        }

        protected System.String _EmpLastName = null;
        public System.String EmpLastName {
            get { return _EmpLastName; }
            set { 
                if((_EmpLastName != value)||(value == null)) { 
                    _EmpLastName = value; 
                    OnPropertyChanged();
                    ValidateField(value);
                    this.rootDataSource.setValue("EmpLastName", value);
                } 
            }
        }
        public void PatchEmpLastName(object value) {
            if (value == null) {
                if(string.IsNullOrEmpty(this._EmpLastName))  return;
                this._EmpLastName = null;
            } else {
                if(value.ToString() == this._EmpLastName) return;
                this._EmpLastName = value.ToString();
            }
            OnPropertyChanged("EmpLastName");
            ValidateField(this._EmpLastName, "EmpLastName");
        }
        protected bool _EmpLastNameEnabled = true;
        public bool EmpLastNameEnabled {
            get { return _EmpLastNameEnabled; }
            set { 
                if(_EmpLastNameEnabled != value) 
                { 
                    _EmpLastNameEnabled = value; 
                    OnPropertyChanged(); 
                } 
            }
        }
        public string EmpLastNameSuffixError {
            get {
                return GetFirstError("EmpLastName");
            }
        }

        protected System.String _EmpSecondName = null;
        public System.String EmpSecondName {
            get { return _EmpSecondName; }
            set { 
                if((_EmpSecondName != value)||(value == null)) { 
                    _EmpSecondName = value; 
                    OnPropertyChanged();
                    ValidateField(value);
                    this.rootDataSource.setValue("EmpSecondName", value);
                } 
            }
        }
        public void PatchEmpSecondName(object value) {
            if (value == null) {
                if(string.IsNullOrEmpty(this._EmpSecondName))  return;
                this._EmpSecondName = null;
            } else {
                if(value.ToString() == this._EmpSecondName) return;
                this._EmpSecondName = value.ToString();
            }
            OnPropertyChanged("EmpSecondName");
            ValidateField(this._EmpSecondName, "EmpSecondName");
        }
        protected bool _EmpSecondNameEnabled = true;
        public bool EmpSecondNameEnabled {
            get { return _EmpSecondNameEnabled; }
            set { 
                if(_EmpSecondNameEnabled != value) 
                { 
                    _EmpSecondNameEnabled = value; 
                    OnPropertyChanged(); 
                } 
            }
        }
        public string EmpSecondNameSuffixError {
            get {
                return GetFirstError("EmpSecondName");
            }
        }

        protected System.Int32 ? _DivisionIdRef = null;
        public System.Int32 ? DivisionIdRef {
            get { return _DivisionIdRef; }
            set { 
                if((_DivisionIdRef != value)||(value == null)) { 
                    _DivisionIdRef = value; 
                    OnPropertyChanged();
                    ValidateField(value);
                    this.rootDataSource.setValue("DivisionIdRef", value);
                } 
            }
        }
        public void PatchDivisionIdRef(object value) {
            if(value == null) {
                if(!this._DivisionIdRef.HasValue) return;
                this._DivisionIdRef = null;
            } else {
                    var vl = Convert.ToInt32(value);
                    if(this._DivisionIdRef.HasValue) {
                        if(this._DivisionIdRef.Value == vl) return;
                    }
                    this._DivisionIdRef = vl;
            }
            OnPropertyChanged("DivisionIdRef");
            ValidateField(this._DivisionIdRef, "DivisionIdRef");
        }
        protected bool _DivisionIdRefEnabled = true;
        public bool DivisionIdRefEnabled {
            get { return _DivisionIdRefEnabled; }
            set { 
                if(_DivisionIdRefEnabled != value) 
                { 
                    _DivisionIdRefEnabled = value; 
                    OnPropertyChanged(); 
                } 
            }
        }
        public string DivisionIdRefSuffixError {
            get {
                return GetFirstError("DivisionIdRef");
            }
        }

        protected System.String _DDivisionName = null;
        public System.String DDivisionName {
            get { return _DDivisionName; }
            set { 
                if((_DDivisionName != value)||(value == null)) { 
                    _DDivisionName = value; 
                    OnPropertyChanged();
                    ValidateField(value);
                } 
            }
        }
        public void PatchDDivisionName(object value) {
            if (value == null) {
                if(string.IsNullOrEmpty(this._DDivisionName))  return;
                this._DDivisionName = null;
            } else {
                if(value.ToString() == this._DDivisionName) return;
                this._DDivisionName = value.ToString();
            }
            OnPropertyChanged("DDivisionName");
            ValidateField(this._DDivisionName, "DDivisionName");
        }
        protected bool _DDivisionNameEnabled = true;
        public bool DDivisionNameEnabled {
            get { return _DDivisionNameEnabled; }
            set { 
                if(_DDivisionNameEnabled != value) 
                { 
                    _DDivisionNameEnabled = value; 
                    OnPropertyChanged(); 
                    (DDivisionNameSrchClckCommand as Command).ChangeCanExecute();
                } 
            }
        }
        public string DDivisionNameSuffixError {
            get {
                return GetFirstError("DDivisionName");
            }
        }

        protected System.String _DEEntrprsName = null;
        public System.String DEEntrprsName {
            get { return _DEEntrprsName; }
            set { 
                if((_DEEntrprsName != value)||(value == null)) { 
                    _DEEntrprsName = value; 
                    OnPropertyChanged();
                    ValidateField(value);
                } 
            }
        }
        public void PatchDEEntrprsName(object value) {
            if (value == null) {
                if(string.IsNullOrEmpty(this._DEEntrprsName))  return;
                this._DEEntrprsName = null;
            } else {
                if(value.ToString() == this._DEEntrprsName) return;
                this._DEEntrprsName = value.ToString();
            }
            OnPropertyChanged("DEEntrprsName");
            ValidateField(this._DEEntrprsName, "DEEntrprsName");
        }
        protected bool _DEEntrprsNameEnabled = true;
        public bool DEEntrprsNameEnabled {
            get { return _DEEntrprsNameEnabled; }
            set { 
                if(_DEEntrprsNameEnabled != value) 
                { 
                    _DEEntrprsNameEnabled = value; 
                    OnPropertyChanged(); 
                    (DEEntrprsNameSrchClckCommand as Command).ChangeCanExecute();
                } 
            }
        }
        public string DEEntrprsNameSuffixError {
            get {
                return GetFirstError("DEEntrprsName");
            }
        }

        #endregion

        #region Helper objects and vars
        protected IAppGlblSettingsService GlblSettingsSrv = null;
        protected IDialogService dialogService = null;
        protected IPhbkEmployeeViewDatasource rootDataSource = null;
        protected IPhbkDivisionViewDatasource DDivisionNameDtSrc = null;
        protected IPhbkEnterpriseViewDatasource DEEntrprsNameDtSrc = null;
        #endregion

        #region Constructor
        public PhbkEmployeeViewUformViewModel(IPhbkEmployeeViewDatasource _rootDataSource,
            IPhbkDivisionViewDatasource _DDivisionNameDtSrc,
            IPhbkEnterpriseViewDatasource _DEEntrprsNameDtSrc,
            IAppGlblSettingsService _GlblSettingsSrv, 
            IDialogService _dialogService) {
            this.GlblSettingsSrv = _GlblSettingsSrv;
            this.dialogService = _dialogService;
            this.rootDataSource = _rootDataSource;
            this.rootDataSource.Init(null, null, new List<string>{"Division"},"");
            this.rootDataSource.setIsNew(false);
            this.rootDataSource.AfterPropsChanged += this.rootDataSourceAfterPropsChanged;

            this.rootDataSource.OnUpdate += this.rootDataSourceOnUpdate;


            this.DDivisionNameDtSrc = _DDivisionNameDtSrc;
            this.DDivisionNameDtSrc.Init("PhbkEmployeeView", "Division", new List<string>{"Enterprise"},"Division");
            this.DDivisionNameDtSrc.setIsNew(false);
            this.DDivisionNameDtSrc.AfterPropsChanged += this.DDivisionNameAfterPropsChanged;
            this.DDivisionNameDtSrc.AfterMasterChanged += this.DDivisionNameAfterMasterChanged;
            this.DDivisionNameDtSrc.OnMasterChanged += this.rootDataSource.SubmitOnMasterChanged;
            this.rootDataSource.OnDetailChanged += this.DDivisionNameDtSrc.SubmitOnDetailChanged;

            this.DEEntrprsNameDtSrc = _DEEntrprsNameDtSrc;
            this.DEEntrprsNameDtSrc.Init("PhbkDivisionView", "Enterprise", new List<string>{},"Division.Enterprise");
            this.DEEntrprsNameDtSrc.setIsNew(false);
            this.DEEntrprsNameDtSrc.AfterPropsChanged += this.DEEntrprsNameAfterPropsChanged;
            this.DEEntrprsNameDtSrc.AfterMasterChanged += this.DEEntrprsNameAfterMasterChanged;
            this.DEEntrprsNameDtSrc.OnMasterChanged += this.DDivisionNameDtSrc.SubmitOnMasterChanged;
            this.DDivisionNameDtSrc.OnDetailChanged += this.DEEntrprsNameDtSrc.SubmitOnDetailChanged;
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
            PropertyInfo propertyInfo = typeof(IPhbkEmployeeView).GetProperty(filedName);
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
                case "DDivisionNameBttnItm":
                    requiredAttribute = new RequiredAttribute();
                    msg = requiredAttribute.FormatErrorMessage(string.Empty);
                    msgfiledName = "DDivisionNameBttnItm";
                    break;
*/
/*
                case "DEEntrprsNameBttnItm":
                    requiredAttribute = new RequiredAttribute();
                    msg = requiredAttribute.FormatErrorMessage(string.Empty);
                    msgfiledName = "DEEntrprsNameBttnItm";
                    break;
*/
                default:
                    break;
            }
            if (!string.IsNullOrEmpty(msg)) {
                ValidationDataErrors[msgfiledName] = new List<string>() { msg };
                RaiseErrorsChanged(msgfiledName);
            }
        }
        public void CheckIsValid() {
            ValidateField(EmployeeId, "EmployeeId");
            ValidateField(EmpFirstName, "EmpFirstName");
            ValidateField(EmpLastName, "EmpLastName");
            ValidateField(EmpSecondName, "EmpSecondName");
            ValidateField(DivisionIdRef, "DivisionIdRef");
            ValidateField(DDivisionName, "DDivisionName");
            ValidateField(DEEntrprsName, "DEEntrprsName");
/*
            ValidateObjectField(DDivisionNameBttnItm, "DDivisionNameBttnItm");
*/
/*
            ValidateObjectField(DEEntrprsNameBttnItm, "DEEntrprsNameBttnItm");
*/
        }
        public void ClearValidationMessages() {
            ValidationErrors.Clear();
            ValidationDataErrors.Clear();
            RaiseErrorsChanged("EmployeeId");
            RaiseErrorsChanged("EmpFirstName");
            RaiseErrorsChanged("EmpLastName");
            RaiseErrorsChanged("EmpSecondName");
            RaiseErrorsChanged("DivisionIdRef");
            RaiseErrorsChanged("DDivisionName");
            RaiseErrorsChanged("DEEntrprsName");
/*
            RaiseErrorsChanged("DDivisionNameBttnItm");
*/
/*
            RaiseErrorsChanged("DEEntrprsNameBttnItm");
*/
        }
        #endregion


        #region rootDataSourceAfterPropsChanged
        public async void rootDataSourceAfterPropsChanged(object sender, EventArgs e) {
            await DorootDataSourceAfterPropsChanged(sender);
        }
        public async Task DorootDataSourceAfterPropsChanged(object sender) {
            await MainThread.InvokeOnMainThreadAsync(() => {
                this.PatchEmployeeId(this.rootDataSource.getValue("EmployeeId"));
                this.PatchEmpFirstName(this.rootDataSource.getValue("EmpFirstName"));
                this.PatchEmpLastName(this.rootDataSource.getValue("EmpLastName"));
                this.PatchEmpSecondName(this.rootDataSource.getValue("EmpSecondName"));
                this.PatchDivisionIdRef(this.rootDataSource.getValue("DivisionIdRef"));
                this.DDivisionNameEnabled = 
                    (!this.rootDataSource.isUnderHiddenFilterFields("DDivisionName")) &&
                    this.DDivisionNameDtSrc.IsSetFilterByCurrDirMstrs();
                this.DEEntrprsNameEnabled = 
                    (!this.rootDataSource.isUnderHiddenFilterFields("DEEntrprsName")) &&
                    this.DEEntrprsNameDtSrc.IsSetFilterByCurrDirMstrs();
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

        #region DDivisionNameAfterMasterChanged
        public async void DDivisionNameAfterMasterChanged(object sender, EventArgs e) {
            await DoDDivisionNameAfterMasterChanged(sender);
        }
        public async Task DoDDivisionNameAfterMasterChanged(object sender) {
            await MainThread.InvokeOnMainThreadAsync(() => {
                this.DDivisionNameEnabled =
                    (!this.rootDataSource.isUnderHiddenFilterFields("DDivisionName")) ||
                    this.DDivisionNameDtSrc.IsSetFilterByCurrDirMstrs();
            });
        }
        #endregion

        #region DDivisionNameSrchClckCommand
        private ICommand _DDivisionNameSrchClckCommand;
        public ICommand DDivisionNameSrchClckCommand
        {
            get
            {
                return _DDivisionNameSrchClckCommand ?? 
                    (_DDivisionNameSrchClckCommand = 
                        new Command(
                            (param) => DDivisionNameSrchClck(param), 
                            (param) => DDivisionNameSrchClckCanExecute(param)));
            }
        }
        public bool DDivisionNameSrchClckCanExecute(object param)
        {
            return DDivisionNameEnabled;
        }
        public void DDivisionNameSrchClck(object param) {
            if (IsDestroyed) return;
            if(!this.DDivisionNameDtSrc.IsSetFilterByCurrDirMstrs()) {
                this.GlblSettingsSrv.ShowErrorMessage("Form Error", "Could not start dialog: not all master data is defined.");
                return;
            }

            IDialogParameters dlgParams = new DialogParameters();
            dlgParams.Add("Caption", "Select Item");
            dlgParams.Add("HiddenFilters", this.DDivisionNameDtSrc.GetWSFltrRsltByCurrDirMstrs());
            dialogService.ShowDialog("PhbkDivisionViewSdlgViewModel", dlgParams, (rslt) => {
                if (rslt == null) return;
                if (rslt.Parameters == null) return;
                if (!rslt.Parameters.ContainsKey("Result")) return;
                if (!rslt.Parameters.GetValue<bool>("Result")) return;
                if (rslt.Parameters.ContainsKey("SelectedItem"))
                {
                    IPhbkDivisionView itm = rslt.Parameters.GetValue<IPhbkDivisionView>("SelectedItem");
                    if (itm != null) {
                        this.DDivisionNameDtSrc.Interface2Values(itm, true);
                    }
                }
            });

        }
        #endregion

        #region DDivisionNameAfterPropsChanged
        public async void DDivisionNameAfterPropsChanged(object sender, EventArgs ea) {
            await DoDDivisionNameAfterPropsChanged(sender);
        }
        public async Task DoDDivisionNameAfterPropsChanged(object sender) {
            await MainThread.InvokeOnMainThreadAsync(() => {

            this.PatchDDivisionName(this.DDivisionNameDtSrc.getValue("DivisionName"));
            });
        }
        #endregion
        #region DEEntrprsNameAfterMasterChanged
        public async void DEEntrprsNameAfterMasterChanged(object sender, EventArgs e) {
            await DoDEEntrprsNameAfterMasterChanged(sender);
        }
        public async Task DoDEEntrprsNameAfterMasterChanged(object sender) {
            await MainThread.InvokeOnMainThreadAsync(() => {
                this.DEEntrprsNameEnabled =
                    (!this.rootDataSource.isUnderHiddenFilterFields("DEEntrprsName")) ||
                    this.DEEntrprsNameDtSrc.IsSetFilterByCurrDirMstrs();
            });
        }
        #endregion

        #region DEEntrprsNameSrchClckCommand
        private ICommand _DEEntrprsNameSrchClckCommand;
        public ICommand DEEntrprsNameSrchClckCommand
        {
            get
            {
                return _DEEntrprsNameSrchClckCommand ?? 
                    (_DEEntrprsNameSrchClckCommand = 
                        new Command(
                            (param) => DEEntrprsNameSrchClck(param), 
                            (param) => DEEntrprsNameSrchClckCanExecute(param)));
            }
        }
        public bool DEEntrprsNameSrchClckCanExecute(object param)
        {
            return DEEntrprsNameEnabled;
        }
        public void DEEntrprsNameSrchClck(object param) {
            if (IsDestroyed) return;
            if(!this.DEEntrprsNameDtSrc.IsSetFilterByCurrDirMstrs()) {
                this.GlblSettingsSrv.ShowErrorMessage("Form Error", "Could not start dialog: not all master data is defined.");
                return;
            }

            IDialogParameters dlgParams = new DialogParameters();
            dlgParams.Add("Caption", "Select Item");
            dlgParams.Add("HiddenFilters", this.DEEntrprsNameDtSrc.GetWSFltrRsltByCurrDirMstrs());
            dialogService.ShowDialog("PhbkEnterpriseViewSdlgViewModel", dlgParams, (rslt) => {
                if (rslt == null) return;
                if (rslt.Parameters == null) return;
                if (!rslt.Parameters.ContainsKey("Result")) return;
                if (!rslt.Parameters.GetValue<bool>("Result")) return;
                if (rslt.Parameters.ContainsKey("SelectedItem"))
                {
                    IPhbkEnterpriseView itm = rslt.Parameters.GetValue<IPhbkEnterpriseView>("SelectedItem");
                    if (itm != null) {
                        this.DEEntrprsNameDtSrc.Interface2Values(itm, true);
                    }
                }
            });

        }
        #endregion

        #region DEEntrprsNameAfterPropsChanged
        public async void DEEntrprsNameAfterPropsChanged(object sender, EventArgs ea) {
            await DoDEEntrprsNameAfterPropsChanged(sender);
        }
        public async Task DoDEEntrprsNameAfterPropsChanged(object sender) {
            await MainThread.InvokeOnMainThreadAsync(() => {

            this.PatchDEEntrprsName(this.DEEntrprsNameDtSrc.getValue("EntrprsName"));
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
                this.FormControlModelVM =  NewValue as IPhbkEmployeeView;
            });
        }
        protected IPhbkEmployeeView _FormControlModelVM = null;
        public IPhbkEmployeeView FormControlModelVM
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
                                await this.DoDEEntrprsNameAfterMasterChanged(this.DEEntrprsNameDtSrc);
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
            this.DDivisionNameDtSrc.AfterPropsChanged -= this.DDivisionNameAfterPropsChanged;
            this.DDivisionNameDtSrc.AfterMasterChanged -= this.DDivisionNameAfterMasterChanged;
            this.DDivisionNameDtSrc.OnMasterChanged -= this.rootDataSource.SubmitOnMasterChanged;
            this.rootDataSource.OnDetailChanged -= this.DDivisionNameDtSrc.SubmitOnDetailChanged;

/*
            _DDivisionNameBttnItm = null;
*/
            this.DEEntrprsNameDtSrc.AfterPropsChanged -= this.DEEntrprsNameAfterPropsChanged;
            this.DEEntrprsNameDtSrc.AfterMasterChanged -= this.DEEntrprsNameAfterMasterChanged;
            this.DEEntrprsNameDtSrc.OnMasterChanged -= this.DDivisionNameDtSrc.SubmitOnMasterChanged;
            this.DDivisionNameDtSrc.OnDetailChanged -= this.DEEntrprsNameDtSrc.SubmitOnDetailChanged;
/*
            _DEEntrprsNameBttnItm = null;
*/
        }
        #endregion

    }
}

