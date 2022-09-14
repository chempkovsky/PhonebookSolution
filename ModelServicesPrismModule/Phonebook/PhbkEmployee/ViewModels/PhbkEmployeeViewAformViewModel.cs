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



    "PhbkEmployeeViewAformUserControl" UserControl is defined in the "ModelServicesPrismModule"-project.
    In the file of IModule-class of "ModelServicesPrismModule"-project the following line of code must be inserted:

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ...
            // According to requirements of the "PhbkEmployeeViewAformViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            ViewModelLocationProvider.Register<PhbkEmployeeViewAformUserControl, PhbkEmployeeViewAformViewModel>();
            // According to requirements of the "PhbkEmployeeViewAformViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            containerRegistry.Register<ContentView, PhbkEmployeeViewAformUserControl>("PhbkEmployeeViewAformUserControl");
            ...
        }

*/

namespace ModelServicesPrismModule.Phonebook.PhbkEmployee.ViewModels {
    public class PhbkEmployeeViewAformViewModel: INotifyPropertyChanged, INotifyDataErrorInfo, IEformViewModelInterface, IBindingContextChanged
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
                    this.rootDataSource.setValue("EmployeeId", value);
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
        public IList<IPhbkDivisionView> _DDivisionNameTphdCntrlItemsSource = null;
        public IList<IPhbkDivisionView> DDivisionNameTphdCntrlItemsSource {
            get { 
                return _DDivisionNameTphdCntrlItemsSource; 
            }
            set { 
                if(_DDivisionNameTphdCntrlItemsSource != value) { 
                    _DDivisionNameTphdCntrlItemsSource = value;
                    OnPropertyChanged(); 
                }    
            }
        }
        public object _DDivisionNameTphdCntrl = null;
        public object DDivisionNameTphdCntrl {
            get { 
                return _DDivisionNameTphdCntrl; 
            }
            set { 
                if(_DDivisionNameTphdCntrl != value) { 
                    _DDivisionNameTphdCntrl = value; 
                    OnPropertyChanged(); 
                    OnPropertyChanged("DDivisionNameTphdCntrlText"); 
                    ValidateObjectField(value);
                }
            }
        }
        public string DDivisionNameTphdCntrlSuffixError {
            get {
                return GetFirstError("DDivisionNameTphdCntrl");
            }
        }
        object _DDivisionNameTphdCntrlText = null;
        public object DDivisionNameTphdCntrlText {
            get 
            {
                IPhbkDivisionView dmObj = DDivisionNameTphdCntrl as IPhbkDivisionView;
                if(dmObj!= null) {
                    return dmObj.DivisionName;
                } else {
                    return _DDivisionNameTphdCntrlText;
                }

            }
            set 
            {
                if(_DDivisionNameTphdCntrlText != value) {
                    _DDivisionNameTphdCntrlText = value;
                    OnPropertyChanged(); 
                }
            }
        }
        protected IPhbkEnterpriseViewDatasource DEEntrprsNameDtSrc = null;
        public IList<IPhbkEnterpriseView> _DEEntrprsNameTphdCntrlItemsSource = null;
        public IList<IPhbkEnterpriseView> DEEntrprsNameTphdCntrlItemsSource {
            get { 
                return _DEEntrprsNameTphdCntrlItemsSource; 
            }
            set { 
                if(_DEEntrprsNameTphdCntrlItemsSource != value) { 
                    _DEEntrprsNameTphdCntrlItemsSource = value;
                    OnPropertyChanged(); 
                }    
            }
        }
        public object _DEEntrprsNameTphdCntrl = null;
        public object DEEntrprsNameTphdCntrl {
            get { 
                return _DEEntrprsNameTphdCntrl; 
            }
            set { 
                if(_DEEntrprsNameTphdCntrl != value) { 
                    _DEEntrprsNameTphdCntrl = value; 
                    OnPropertyChanged(); 
                    OnPropertyChanged("DEEntrprsNameTphdCntrlText"); 
                    ValidateObjectField(value);
                }
            }
        }
        public string DEEntrprsNameTphdCntrlSuffixError {
            get {
                return GetFirstError("DEEntrprsNameTphdCntrl");
            }
        }
        object _DEEntrprsNameTphdCntrlText = null;
        public object DEEntrprsNameTphdCntrlText {
            get 
            {
                IPhbkEnterpriseView dmObj = DEEntrprsNameTphdCntrl as IPhbkEnterpriseView;
                if(dmObj!= null) {
                    return dmObj.EntrprsName;
                } else {
                    return _DEEntrprsNameTphdCntrlText;
                }

            }
            set 
            {
                if(_DEEntrprsNameTphdCntrlText != value) {
                    _DEEntrprsNameTphdCntrlText = value;
                    OnPropertyChanged(); 
                }
            }
        }
        #endregion

        #region Constructor
        public PhbkEmployeeViewAformViewModel(IPhbkEmployeeViewDatasource _rootDataSource,
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

            this.rootDataSource.OnAdd += this.rootDataSourceOnAdd;


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
                case "DDivisionNameTphdCntrl":
                    requiredAttribute = new RequiredAttribute();
                    msg = requiredAttribute.FormatErrorMessage(string.Empty);
                    break;
                case "DEEntrprsNameTphdCntrl":
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
            ValidateField(EmployeeId, "EmployeeId");
            ValidateField(EmpFirstName, "EmpFirstName");
            ValidateField(EmpLastName, "EmpLastName");
            ValidateField(EmpSecondName, "EmpSecondName");
            ValidateField(DivisionIdRef, "DivisionIdRef");
            ValidateField(DDivisionName, "DDivisionName");
            ValidateField(DEEntrprsName, "DEEntrprsName");
            ValidateObjectField(DDivisionNameTphdCntrl, "DDivisionNameTphdCntrl");
            ValidateObjectField(DEEntrprsNameTphdCntrl, "DEEntrprsNameTphdCntrl");
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
            RaiseErrorsChanged("DDivisionNameTphdCntrl");
            RaiseErrorsChanged("DEEntrprsNameTphdCntrl");
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

        #region DDivisionNameAfterMasterChanged
        public async void DDivisionNameAfterMasterChanged(object sender, EventArgs e) {
            await DoDDivisionNameAfterMasterChanged(sender);
        }
        public async Task DoDDivisionNameAfterMasterChanged(object sender) {
            await MainThread.InvokeOnMainThreadAsync(() => {
                if(this.DDivisionNameDtSrc.IsSetFilterByCurrDirMstrs() &&
                  (!this.rootDataSource.isUnderHiddenFilterFields("DDivisionName"))) {
                    this.DDivisionNameEnabled = true;
                } else {
                    this.DDivisionNameEnabled = false;
                }
                if(this.DDivisionNameDtSrc.CalcIsDefined()) {
                    this.PatchDDivisionName(this.DDivisionNameDtSrc.getValue("DivisionName"));
                    this.DDivisionNameTphdCntrl = this.DDivisionNameDtSrc.Values2Interface();
                } else {
                    this.PatchDDivisionName(null);
                    this.DDivisionNameTphdCntrl = null;
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
            if(this.DDivisionNameDtSrc.CalcIsDefined()) {
                this.DDivisionNameTphdCntrl = this.DDivisionNameDtSrc.Values2Interface();
            } else {
                this.DDivisionNameTphdCntrl = null;
            }


            });
        }
        #endregion
        #region DEEntrprsNameAfterMasterChanged
        public async void DEEntrprsNameAfterMasterChanged(object sender, EventArgs e) {
            await DoDEEntrprsNameAfterMasterChanged(sender);
        }
        public async Task DoDEEntrprsNameAfterMasterChanged(object sender) {
            await MainThread.InvokeOnMainThreadAsync(() => {
                if(this.DEEntrprsNameDtSrc.IsSetFilterByCurrDirMstrs() &&
                  (!this.rootDataSource.isUnderHiddenFilterFields("DEEntrprsName"))) {
                    this.DEEntrprsNameEnabled = true;
                } else {
                    this.DEEntrprsNameEnabled = false;
                }
                if(this.DEEntrprsNameDtSrc.CalcIsDefined()) {
                    this.PatchDEEntrprsName(this.DEEntrprsNameDtSrc.getValue("EntrprsName"));
                    this.DEEntrprsNameTphdCntrl = this.DEEntrprsNameDtSrc.Values2Interface();
                } else {
                    this.PatchDEEntrprsName(null);
                    this.DEEntrprsNameTphdCntrl = null;
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
            if(this.DEEntrprsNameDtSrc.CalcIsDefined()) {
                this.DEEntrprsNameTphdCntrl = this.DEEntrprsNameDtSrc.Values2Interface();
            } else {
                this.DEEntrprsNameTphdCntrl = null;
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
            switch(PropName) {
                case "DDivisionName":
                    // Clear ItemsSource
                    if(Reason == 0) {
                        Task.Run(async () => {
                            IList<IPhbkDivisionView> itms = null;
                            try {
                                this.DDivisionNameDtSrc.ClearPartially(true);
                                itms = await this.DDivisionNameDtSrc.GetClActionByFldFilter("DivisionName", QueryText);
                            } catch(Exception ex) {
                                string exceptionMsg = "DDivisionNameAfterMasterChanged : " + ex.Message;
                                Exception inner = ex.InnerException;
                                while (inner != null)
                                {
                                    exceptionMsg = exceptionMsg + ": " + inner.Message;
                                    inner = inner.InnerException;
                                }
                                GlblSettingsSrv.ShowErrorMessage("http", exceptionMsg);
                            }
                            await MainThread.InvokeOnMainThreadAsync(() => {
                                this.DDivisionNameTphdCntrlItemsSource = itms;
                            });
                        }).ConfigureAwait(false);
                    }
                    break;
                case "DEEntrprsName":
                    // Clear ItemsSource
                    if(Reason == 0) {
                        Task.Run(async () => {
                            IList<IPhbkEnterpriseView> itms = null;
                            try {
                                this.DEEntrprsNameDtSrc.ClearPartially(true);
                                itms = await this.DEEntrprsNameDtSrc.GetClActionByFldFilter("EntrprsName", QueryText);
                            } catch(Exception ex) {
                                string exceptionMsg = "DEEntrprsNameAfterMasterChanged : " + ex.Message;
                                Exception inner = ex.InnerException;
                                while (inner != null)
                                {
                                    exceptionMsg = exceptionMsg + ": " + inner.Message;
                                    inner = inner.InnerException;
                                }
                                GlblSettingsSrv.ShowErrorMessage("http", exceptionMsg);
                            }
                            await MainThread.InvokeOnMainThreadAsync(() => {
                                this.DEEntrprsNameTphdCntrlItemsSource = itms;
                            });
                        }).ConfigureAwait(false);
                    }
                    break;
                default:
                    break;
            }
        }
        // IF (ChosenSuggestion != null) THEN User selected an item from the suggestion list, take an action on it here.
        public void OnAutoSuggestBoxQuerySubmitted(object Sender, object AutoSggstBx, string PropName, object ChosenSuggestion, string QueryText)
        {
            if (IsDestroyed) return;
            switch(PropName) {
                case "DDivisionName":
                    DDivisionNameTphdCntrlItemsSource = null;
                    {
                        _= Task.Run(() => {
                            IPhbkDivisionView itm = ChosenSuggestion as IPhbkDivisionView;
                            if(itm == null) {
                                this.DDivisionNameDtSrc.ClearPartially(true);
                            } else {
                                this.DDivisionNameDtSrc.Interface2Values(itm, true);
                            }
                        }).ConfigureAwait(false);
                    }
                    break;
                case "DEEntrprsName":
                    DEEntrprsNameTphdCntrlItemsSource = null;
                    {
                        _= Task.Run(() => {
                            IPhbkEnterpriseView itm = ChosenSuggestion as IPhbkEnterpriseView;
                            if(itm == null) {
                                this.DEEntrprsNameDtSrc.ClearPartially(true);
                            } else {
                                this.DEEntrprsNameDtSrc.Interface2Values(itm, true);
                            }
                        }).ConfigureAwait(false);
                    }
                    break;
                default:
                    break;
            }
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
            this.rootDataSource.setValue("EmployeeId", 0);
            this.rootDataSource.setHiddenFilter(this.rootDataSource.getHiddenFilterByFltRslt(this.HiddenFiltersVM));
            this.rootDataSource.UpdateByHiddenFilterFields(false);
            this.rootDataSource.DoEmitEvent(false);
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
            this.rootDataSource.OnAdd -= this.rootDataSourceOnAdd;
            this.DDivisionNameDtSrc.AfterPropsChanged -= this.DDivisionNameAfterPropsChanged;
            this.DDivisionNameDtSrc.AfterMasterChanged -= this.DDivisionNameAfterMasterChanged;
            this.DDivisionNameDtSrc.OnMasterChanged -= this.rootDataSource.SubmitOnMasterChanged;
            this.rootDataSource.OnDetailChanged -= this.DDivisionNameDtSrc.SubmitOnDetailChanged;

            _DDivisionNameTphdCntrlItemsSource = null;
            _DDivisionNameTphdCntrl = null;
            _DDivisionNameTphdCntrlText=null;
            this.DEEntrprsNameDtSrc.AfterPropsChanged -= this.DEEntrprsNameAfterPropsChanged;
            this.DEEntrprsNameDtSrc.AfterMasterChanged -= this.DEEntrprsNameAfterMasterChanged;
            this.DEEntrprsNameDtSrc.OnMasterChanged -= this.DDivisionNameDtSrc.SubmitOnMasterChanged;
            this.DDivisionNameDtSrc.OnDetailChanged -= this.DEEntrprsNameDtSrc.SubmitOnDetailChanged;
            _DEEntrprsNameTphdCntrlItemsSource = null;
            _DEEntrprsNameTphdCntrl = null;
            _DEEntrprsNameTphdCntrlText=null;
        }
        #endregion

    }
}

