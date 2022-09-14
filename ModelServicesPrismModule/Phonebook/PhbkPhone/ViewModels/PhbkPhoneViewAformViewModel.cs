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
using ModelInterfacesClassLibrary.Phonebook.PhbkPhoneType;
using ModelInterfacesClassLibrary.Phonebook.PhbkEmployee;
using ModelInterfacesClassLibrary.Phonebook.PhbkDivision;
using ModelInterfacesClassLibrary.Phonebook.PhbkEnterprise;
/*


        Reminder:
        "PhbkEmployeeViewSdlgUserControl" UserControl is defined in the "ModelServicesPrismModule"-project.
        In the file of IModule-class of "ModelServicesPrismModule"-project the following line of code must be inserted:

            public void RegisterTypes(IContainerRegistry containerRegistry)
            {
                ...
                // According to requirements of the "PhbkEmployeeViewSdlgViewModel.cs"-file of "ModelServicesPrismModule"-project. 
                containerRegistry.RegisterDialog<PhbkEmployeeViewSdlgUserControl, SdlgViewModelBase>("PhbkEmployeeViewSdlgViewModel");
                ...
            }

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



    "PhbkPhoneViewAformUserControl" UserControl is defined in the "ModelServicesPrismModule"-project.
    In the file of IModule-class of "ModelServicesPrismModule"-project the following line of code must be inserted:

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ...
            // According to requirements of the "PhbkPhoneViewAformViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            ViewModelLocationProvider.Register<PhbkPhoneViewAformUserControl, PhbkPhoneViewAformViewModel>();
            // According to requirements of the "PhbkPhoneViewAformViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            containerRegistry.Register<ContentView, PhbkPhoneViewAformUserControl>("PhbkPhoneViewAformUserControl");
            ...
        }

*/

namespace ModelServicesPrismModule.Phonebook.PhbkPhone.ViewModels {
    public class PhbkPhoneViewAformViewModel: INotifyPropertyChanged, INotifyDataErrorInfo, IEformViewModelInterface, IBindingContextChanged
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
                    this.rootDataSource.setValue("Phone", value);
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
                    (EEmpLastNameSrchClckCommand as Command).ChangeCanExecute();
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
                    (EDDivisionNameSrchClckCommand as Command).ChangeCanExecute();
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
                    (EDEEntrprsNameSrchClckCommand as Command).ChangeCanExecute();
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
        protected IPhbkPhoneTypeViewDatasource PPhoneTypeNameDtSrc = null;
        protected object _PPhoneTypeNameCmbCntrl = null;
        public object PPhoneTypeNameCmbCntrl {
            get { 
                return _PPhoneTypeNameCmbCntrl; 
            }
            set { 
                var val = value as IPhbkPhoneTypeView;
                if(_PPhoneTypeNameCmbCntrl != val) { 
                    _PPhoneTypeNameCmbCntrl = val; 
                    if(val == null) {
                        this.PPhoneTypeNameDtSrc.ClearPartially(true);
                    } else {
                        this.PPhoneTypeNameDtSrc.Interface2Values(val, true);
                    }
                    OnPropertyChanged(); 
                    ValidateField(value);
                } 
            }
        }
        public string PPhoneTypeNameCmbCntrlSuffixError {
            get {
                return GetFirstError("PPhoneTypeNameCmbCntrl");
            }
        }
        protected IList<IPhbkPhoneTypeView> _PPhoneTypeNameCmbCntrlVals = null;
        public IList<IPhbkPhoneTypeView> PPhoneTypeNameCmbCntrlVals {
            get { 
                return _PPhoneTypeNameCmbCntrlVals; 
            }
            set { 
                if(_PPhoneTypeNameCmbCntrlVals != value) { 
                    _PPhoneTypeNameCmbCntrlVals = value; 
                    OnPropertyChanged(); 
                } 
            }
        }
        protected IPhbkEmployeeViewDatasource EEmpLastNameDtSrc = null;
        protected IPhbkDivisionViewDatasource EDDivisionNameDtSrc = null;
        protected IPhbkEnterpriseViewDatasource EDEEntrprsNameDtSrc = null;
        #endregion

        #region Constructor
        public PhbkPhoneViewAformViewModel(IPhbkPhoneViewDatasource _rootDataSource,
            IPhbkPhoneTypeViewDatasource _PPhoneTypeNameDtSrc,
            IPhbkEmployeeViewDatasource _EEmpLastNameDtSrc,
            IPhbkDivisionViewDatasource _EDDivisionNameDtSrc,
            IPhbkEnterpriseViewDatasource _EDEEntrprsNameDtSrc,
            IAppGlblSettingsService _GlblSettingsSrv, 
            IDialogService _dialogService) {
            this.GlblSettingsSrv = _GlblSettingsSrv;
            this.dialogService = _dialogService;
            this.rootDataSource = _rootDataSource;
            this.rootDataSource.Init(null, null, new List<string>{"PhoneType", "Employee"},"");
            this.rootDataSource.setIsNew(false);
            this.rootDataSource.AfterPropsChanged += this.rootDataSourceAfterPropsChanged;

            this.rootDataSource.OnAdd += this.rootDataSourceOnAdd;


            this.PPhoneTypeNameDtSrc = _PPhoneTypeNameDtSrc;
            this.PPhoneTypeNameDtSrc.Init("PhbkPhoneView", "PhoneType", new List<string>{},"PhoneType");
            this.PPhoneTypeNameDtSrc.setIsNew(false);
            this.PPhoneTypeNameDtSrc.AfterPropsChanged += this.PPhoneTypeNameAfterPropsChanged;
            this.PPhoneTypeNameDtSrc.AfterMasterChanged += this.PPhoneTypeNameAfterMasterChanged;
            this.PPhoneTypeNameDtSrc.OnMasterChanged += this.rootDataSource.SubmitOnMasterChanged;
            this.rootDataSource.OnDetailChanged += this.PPhoneTypeNameDtSrc.SubmitOnDetailChanged;

            this.EEmpLastNameDtSrc = _EEmpLastNameDtSrc;
            this.EEmpLastNameDtSrc.Init("PhbkPhoneView", "Employee", new List<string>{"Division"},"Employee");
            this.EEmpLastNameDtSrc.setIsNew(false);
            this.EEmpLastNameDtSrc.AfterPropsChanged += this.EEmpLastNameAfterPropsChanged;
            this.EEmpLastNameDtSrc.AfterMasterChanged += this.EEmpLastNameAfterMasterChanged;
            this.EEmpLastNameDtSrc.OnMasterChanged += this.rootDataSource.SubmitOnMasterChanged;
            this.rootDataSource.OnDetailChanged += this.EEmpLastNameDtSrc.SubmitOnDetailChanged;

            this.EDDivisionNameDtSrc = _EDDivisionNameDtSrc;
            this.EDDivisionNameDtSrc.Init("PhbkEmployeeView", "Division", new List<string>{"Enterprise"},"Employee.Division");
            this.EDDivisionNameDtSrc.setIsNew(false);
            this.EDDivisionNameDtSrc.AfterPropsChanged += this.EDDivisionNameAfterPropsChanged;
            this.EDDivisionNameDtSrc.AfterMasterChanged += this.EDDivisionNameAfterMasterChanged;
            this.EDDivisionNameDtSrc.OnMasterChanged += this.EEmpLastNameDtSrc.SubmitOnMasterChanged;
            this.EEmpLastNameDtSrc.OnDetailChanged += this.EDDivisionNameDtSrc.SubmitOnDetailChanged;
            this.EDEEntrprsNameDtSrc = _EDEEntrprsNameDtSrc;
            this.EDEEntrprsNameDtSrc.Init("PhbkDivisionView", "Enterprise", new List<string>{},"Employee.Division.Enterprise");
            this.EDEEntrprsNameDtSrc.setIsNew(false);
            this.EDEEntrprsNameDtSrc.AfterPropsChanged += this.EDEEntrprsNameAfterPropsChanged;
            this.EDEEntrprsNameDtSrc.AfterMasterChanged += this.EDEEntrprsNameAfterMasterChanged;
            this.EDEEntrprsNameDtSrc.OnMasterChanged += this.EDDivisionNameDtSrc.SubmitOnMasterChanged;
            this.EDDivisionNameDtSrc.OnDetailChanged += this.EDEEntrprsNameDtSrc.SubmitOnDetailChanged;
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
                case "PPhoneTypeNameCmbCntrl":
                    requiredAttribute = new RequiredAttribute();
                    msg = requiredAttribute.FormatErrorMessage(string.Empty);
                    break;
/*
                case "EEmpLastNameBttnItm":
                    requiredAttribute = new RequiredAttribute();
                    msg = requiredAttribute.FormatErrorMessage(string.Empty);
                    msgfiledName = "EEmpLastNameBttnItm";
                    break;
*/
/*
                case "EDDivisionNameBttnItm":
                    requiredAttribute = new RequiredAttribute();
                    msg = requiredAttribute.FormatErrorMessage(string.Empty);
                    msgfiledName = "EDDivisionNameBttnItm";
                    break;
*/
/*
                case "EDEEntrprsNameBttnItm":
                    requiredAttribute = new RequiredAttribute();
                    msg = requiredAttribute.FormatErrorMessage(string.Empty);
                    msgfiledName = "EDEEntrprsNameBttnItm";
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
            ValidateObjectField(PPhoneTypeNameCmbCntrl, "PPhoneTypeNameCmbCntrl");
/*
            ValidateObjectField(EEmpLastNameBttnItm, "EEmpLastNameBttnItm");
*/
/*
            ValidateObjectField(EDDivisionNameBttnItm, "EDDivisionNameBttnItm");
*/
/*
            ValidateObjectField(EDEEntrprsNameBttnItm, "EDEEntrprsNameBttnItm");
*/
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
            RaiseErrorsChanged("PPhoneTypeNameCmbCntrl");
/*
            RaiseErrorsChanged("EEmpLastNameBttnItm");
*/
/*
            RaiseErrorsChanged("EDDivisionNameBttnItm");
*/
/*
            RaiseErrorsChanged("EDEEntrprsNameBttnItm");
*/
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
                this.PatchEmployeeIdRef(this.rootDataSource.getValue("EmployeeIdRef"));
                this.PatchPhoneTypeIdRef(this.rootDataSource.getValue("PhoneTypeIdRef"));
                this.PPhoneTypeNameEnabled = 
                    (!this.rootDataSource.isUnderHiddenFilterFields("PPhoneTypeName")) &&
                    this.PPhoneTypeNameDtSrc.IsSetFilterByCurrDirMstrs();
                this.EEmpLastNameEnabled = 
                    (!this.rootDataSource.isUnderHiddenFilterFields("EEmpLastName")) &&
                    this.EEmpLastNameDtSrc.IsSetFilterByCurrDirMstrs();
                this.EDDivisionNameEnabled = 
                    (!this.rootDataSource.isUnderHiddenFilterFields("EDDivisionName")) &&
                    this.EDDivisionNameDtSrc.IsSetFilterByCurrDirMstrs();
                this.EDEEntrprsNameEnabled = 
                    (!this.rootDataSource.isUnderHiddenFilterFields("EDEEntrprsName")) &&
                    this.EDEEntrprsNameDtSrc.IsSetFilterByCurrDirMstrs();
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

        #region PPhoneTypeNameAfterMasterChanged
        public async void PPhoneTypeNameAfterMasterChanged(object sender, EventArgs ea) {
            await DoPPhoneTypeNameAfterMasterChanged(sender);
        }
        public async Task DoPPhoneTypeNameAfterMasterChanged(object sender) {
                IList<IPhbkPhoneTypeView> data = null;
                IPhbkPhoneTypeView newItm = null;
                try {
                    data = await this.PPhoneTypeNameDtSrc.GetClActionByCurrDirMstrs();
                    if(data != null) {
                        if(this.PPhoneTypeNameDtSrc.CalcIsDefined()) {
                            IPhbkPhoneTypeView currItm = this.PPhoneTypeNameDtSrc.Values2Interface();
                            newItm = data.Where(e => (e.PhoneTypeId == currItm.PhoneTypeId)).FirstOrDefault();
                        }
                    }
                } catch(Exception ex)
                {
                    string exceptionMsg = "PPhoneTypeNameAfterMasterChanged : " + ex.Message;
                    Exception inner = ex.InnerException;
                    while (inner != null)
                    {
                        exceptionMsg = exceptionMsg + ": " + inner.Message;
                        inner = inner.InnerException;
                    }
                    GlblSettingsSrv.ShowErrorMessage("http", exceptionMsg);
                }


            await MainThread.InvokeOnMainThreadAsync(() => {
                _PPhoneTypeNameCmbCntrl = null;
                OnPropertyChanged("PPhoneTypeNameCmbCntrl");
                this._PPhoneTypeNameCmbCntrlVals = data;
                OnPropertyChanged("PPhoneTypeNameCmbCntrlVals");
                this._PPhoneTypeNameCmbCntrl = newItm;
                OnPropertyChanged("PPhoneTypeNameCmbCntrl");
                ValidateObjectField(newItm, "PPhoneTypeNameCmbCntrl");
                if(newItm != null)
                    this.PPhoneTypeName = newItm.PhoneTypeName;
                else
                    this.PPhoneTypeName = null;
                if(this.PPhoneTypeNameDtSrc.IsSetFilterByCurrDirMstrs() &&
                  (!this.rootDataSource.isUnderHiddenFilterFields("PPhoneTypeName"))) {
                    this.PPhoneTypeNameEnabled = true;
                } else {
                    this.PPhoneTypeNameEnabled = false;
                }

            });
        }
        #endregion
        #region PPhoneTypeNameAfterPropsChanged
        public async void PPhoneTypeNameAfterPropsChanged(object sender, EventArgs ea) {
            await DoPPhoneTypeNameAfterPropsChanged(sender);
        }
        public async Task DoPPhoneTypeNameAfterPropsChanged(object sender) {
            await MainThread.InvokeOnMainThreadAsync(() => {

            if(this.PPhoneTypeNameCmbCntrlVals != null) {
                IPhbkPhoneTypeView currItm = this.PPhoneTypeNameDtSrc.Values2Interface();
                IPhbkPhoneTypeView newItm = null;
                if(currItm != null) {
                    newItm = this.PPhoneTypeNameCmbCntrlVals.Where(e => (e.PhoneTypeId == currItm.PhoneTypeId)).FirstOrDefault();
                }
                this._PPhoneTypeNameCmbCntrl = newItm;
                OnPropertyChanged("PPhoneTypeNameCmbCntrl");
                ValidateObjectField(newItm, "PPhoneTypeNameCmbCntrl");
                if(newItm != null)
                    this.PatchPPhoneTypeName(newItm.PhoneTypeName);
                else 
                    this.PatchPPhoneTypeName(null);
            } else {
                this._PPhoneTypeNameCmbCntrl = null;
                OnPropertyChanged("PPhoneTypeNameCmbCntrl");
                ValidateObjectField(null, "PPhoneTypeNameCmbCntrl");
                this.PatchPPhoneTypeName(null);
            }
            });
        }
        #endregion
        #region EEmpLastNameAfterMasterChanged
        public async void EEmpLastNameAfterMasterChanged(object sender, EventArgs e) {
            await DoEEmpLastNameAfterMasterChanged(sender);
        }
        public async Task DoEEmpLastNameAfterMasterChanged(object sender) {
            await MainThread.InvokeOnMainThreadAsync(() => {
                this.EEmpLastNameEnabled =
                    (!this.rootDataSource.isUnderHiddenFilterFields("EEmpLastName")) ||
                    this.EEmpLastNameDtSrc.IsSetFilterByCurrDirMstrs();
            });
        }
        #endregion

        #region EEmpLastNameSrchClckCommand
        private ICommand _EEmpLastNameSrchClckCommand;
        public ICommand EEmpLastNameSrchClckCommand
        {
            get
            {
                return _EEmpLastNameSrchClckCommand ?? 
                    (_EEmpLastNameSrchClckCommand = 
                        new Command(
                            (param) => EEmpLastNameSrchClck(param), 
                            (param) => EEmpLastNameSrchClckCanExecute(param)));
            }
        }
        public bool EEmpLastNameSrchClckCanExecute(object param)
        {
            return EEmpLastNameEnabled;
        }
        public void EEmpLastNameSrchClck(object param) {
            if (IsDestroyed) return;
            if(!this.EEmpLastNameDtSrc.IsSetFilterByCurrDirMstrs()) {
                this.GlblSettingsSrv.ShowErrorMessage("Form Error", "Could not start dialog: not all master data is defined.");
                return;
            }

            IDialogParameters dlgParams = new DialogParameters();
            dlgParams.Add("Caption", "Select Item");
            dlgParams.Add("HiddenFilters", this.EEmpLastNameDtSrc.GetWSFltrRsltByCurrDirMstrs());
            dialogService.ShowDialog("PhbkEmployeeViewSdlgViewModel", dlgParams, (rslt) => {
                if (rslt == null) return;
                if (rslt.Parameters == null) return;
                if (!rslt.Parameters.ContainsKey("Result")) return;
                if (!rslt.Parameters.GetValue<bool>("Result")) return;
                if (rslt.Parameters.ContainsKey("SelectedItem"))
                {
                    IPhbkEmployeeView itm = rslt.Parameters.GetValue<IPhbkEmployeeView>("SelectedItem");
                    if (itm != null) {
                        this.EEmpLastNameDtSrc.Interface2Values(itm, true);
                    }
                }
            });

        }
        #endregion

        #region EEmpLastNameAfterPropsChanged
        public async void EEmpLastNameAfterPropsChanged(object sender, EventArgs ea) {
            await DoEEmpLastNameAfterPropsChanged(sender);
        }
        public async Task DoEEmpLastNameAfterPropsChanged(object sender) {
            await MainThread.InvokeOnMainThreadAsync(() => {

            this.PatchEEmpFirstName(this.EEmpLastNameDtSrc.getByOrgValue("EmpFirstName", ""));
            this.PatchEEmpSecondName(this.EEmpLastNameDtSrc.getByOrgValue("EmpSecondName", ""));
            this.PatchEEmpLastName(this.EEmpLastNameDtSrc.getValue("EmpLastName"));
            });
        }
        #endregion
        #region EDDivisionNameAfterMasterChanged
        public async void EDDivisionNameAfterMasterChanged(object sender, EventArgs e) {
            await DoEDDivisionNameAfterMasterChanged(sender);
        }
        public async Task DoEDDivisionNameAfterMasterChanged(object sender) {
            await MainThread.InvokeOnMainThreadAsync(() => {
                this.EDDivisionNameEnabled =
                    (!this.rootDataSource.isUnderHiddenFilterFields("EDDivisionName")) ||
                    this.EDDivisionNameDtSrc.IsSetFilterByCurrDirMstrs();
            });
        }
        #endregion

        #region EDDivisionNameSrchClckCommand
        private ICommand _EDDivisionNameSrchClckCommand;
        public ICommand EDDivisionNameSrchClckCommand
        {
            get
            {
                return _EDDivisionNameSrchClckCommand ?? 
                    (_EDDivisionNameSrchClckCommand = 
                        new Command(
                            (param) => EDDivisionNameSrchClck(param), 
                            (param) => EDDivisionNameSrchClckCanExecute(param)));
            }
        }
        public bool EDDivisionNameSrchClckCanExecute(object param)
        {
            return EDDivisionNameEnabled;
        }
        public void EDDivisionNameSrchClck(object param) {
            if (IsDestroyed) return;
            if(!this.EDDivisionNameDtSrc.IsSetFilterByCurrDirMstrs()) {
                this.GlblSettingsSrv.ShowErrorMessage("Form Error", "Could not start dialog: not all master data is defined.");
                return;
            }

            IDialogParameters dlgParams = new DialogParameters();
            dlgParams.Add("Caption", "Select Item");
            dlgParams.Add("HiddenFilters", this.EDDivisionNameDtSrc.GetWSFltrRsltByCurrDirMstrs());
            dialogService.ShowDialog("PhbkDivisionViewSdlgViewModel", dlgParams, (rslt) => {
                if (rslt == null) return;
                if (rslt.Parameters == null) return;
                if (!rslt.Parameters.ContainsKey("Result")) return;
                if (!rslt.Parameters.GetValue<bool>("Result")) return;
                if (rslt.Parameters.ContainsKey("SelectedItem"))
                {
                    IPhbkDivisionView itm = rslt.Parameters.GetValue<IPhbkDivisionView>("SelectedItem");
                    if (itm != null) {
                        this.EDDivisionNameDtSrc.Interface2Values(itm, true);
                    }
                }
            });

        }
        #endregion

        #region EDDivisionNameAfterPropsChanged
        public async void EDDivisionNameAfterPropsChanged(object sender, EventArgs ea) {
            await DoEDDivisionNameAfterPropsChanged(sender);
        }
        public async Task DoEDDivisionNameAfterPropsChanged(object sender) {
            await MainThread.InvokeOnMainThreadAsync(() => {

            this.PatchEDDivisionName(this.EDDivisionNameDtSrc.getValue("DivisionName"));
            });
        }
        #endregion
        #region EDEEntrprsNameAfterMasterChanged
        public async void EDEEntrprsNameAfterMasterChanged(object sender, EventArgs e) {
            await DoEDEEntrprsNameAfterMasterChanged(sender);
        }
        public async Task DoEDEEntrprsNameAfterMasterChanged(object sender) {
            await MainThread.InvokeOnMainThreadAsync(() => {
                this.EDEEntrprsNameEnabled =
                    (!this.rootDataSource.isUnderHiddenFilterFields("EDEEntrprsName")) ||
                    this.EDEEntrprsNameDtSrc.IsSetFilterByCurrDirMstrs();
            });
        }
        #endregion

        #region EDEEntrprsNameSrchClckCommand
        private ICommand _EDEEntrprsNameSrchClckCommand;
        public ICommand EDEEntrprsNameSrchClckCommand
        {
            get
            {
                return _EDEEntrprsNameSrchClckCommand ?? 
                    (_EDEEntrprsNameSrchClckCommand = 
                        new Command(
                            (param) => EDEEntrprsNameSrchClck(param), 
                            (param) => EDEEntrprsNameSrchClckCanExecute(param)));
            }
        }
        public bool EDEEntrprsNameSrchClckCanExecute(object param)
        {
            return EDEEntrprsNameEnabled;
        }
        public void EDEEntrprsNameSrchClck(object param) {
            if (IsDestroyed) return;
            if(!this.EDEEntrprsNameDtSrc.IsSetFilterByCurrDirMstrs()) {
                this.GlblSettingsSrv.ShowErrorMessage("Form Error", "Could not start dialog: not all master data is defined.");
                return;
            }

            IDialogParameters dlgParams = new DialogParameters();
            dlgParams.Add("Caption", "Select Item");
            dlgParams.Add("HiddenFilters", this.EDEEntrprsNameDtSrc.GetWSFltrRsltByCurrDirMstrs());
            dialogService.ShowDialog("PhbkEnterpriseViewSdlgViewModel", dlgParams, (rslt) => {
                if (rslt == null) return;
                if (rslt.Parameters == null) return;
                if (!rslt.Parameters.ContainsKey("Result")) return;
                if (!rslt.Parameters.GetValue<bool>("Result")) return;
                if (rslt.Parameters.ContainsKey("SelectedItem"))
                {
                    IPhbkEnterpriseView itm = rslt.Parameters.GetValue<IPhbkEnterpriseView>("SelectedItem");
                    if (itm != null) {
                        this.EDEEntrprsNameDtSrc.Interface2Values(itm, true);
                    }
                }
            });

        }
        #endregion

        #region EDEEntrprsNameAfterPropsChanged
        public async void EDEEntrprsNameAfterPropsChanged(object sender, EventArgs ea) {
            await DoEDEEntrprsNameAfterPropsChanged(sender);
        }
        public async Task DoEDEEntrprsNameAfterPropsChanged(object sender) {
            await MainThread.InvokeOnMainThreadAsync(() => {

            this.PatchEDEEntrprsName(this.EDEEntrprsNameDtSrc.getValue("EntrprsName"));
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
            this.rootDataSource.setValue("PhoneId", 0);
            this.rootDataSource.setHiddenFilter(this.rootDataSource.getHiddenFilterByFltRslt(this.HiddenFiltersVM));
            this.rootDataSource.UpdateByHiddenFilterFields(false);
            this.rootDataSource.DoEmitEvent(false);
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
                                await this.DoPPhoneTypeNameAfterMasterChanged(this.PPhoneTypeNameDtSrc);
                                await this.DoEDEEntrprsNameAfterMasterChanged(this.EDEEntrprsNameDtSrc);
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
            this.PPhoneTypeNameDtSrc.AfterPropsChanged -= this.PPhoneTypeNameAfterPropsChanged;
            this.PPhoneTypeNameDtSrc.AfterMasterChanged -= this.PPhoneTypeNameAfterMasterChanged;
            this.PPhoneTypeNameDtSrc.OnMasterChanged -= this.rootDataSource.SubmitOnMasterChanged;
            this.rootDataSource.OnDetailChanged -= this.PPhoneTypeNameDtSrc.SubmitOnDetailChanged;

            _PPhoneTypeNameCmbCntrl = null;
            _PPhoneTypeNameCmbCntrlVals = null;
            this.EEmpLastNameDtSrc.AfterPropsChanged -= this.EEmpLastNameAfterPropsChanged;
            this.EEmpLastNameDtSrc.AfterMasterChanged -= this.EEmpLastNameAfterMasterChanged;
            this.EEmpLastNameDtSrc.OnMasterChanged -= this.rootDataSource.SubmitOnMasterChanged;
            this.rootDataSource.OnDetailChanged -= this.EEmpLastNameDtSrc.SubmitOnDetailChanged;

/*
            _EEmpLastNameBttnItm = null;
*/
            this.EDDivisionNameDtSrc.AfterPropsChanged -= this.EDDivisionNameAfterPropsChanged;
            this.EDDivisionNameDtSrc.AfterMasterChanged -= this.EDDivisionNameAfterMasterChanged;
            this.EDDivisionNameDtSrc.OnMasterChanged -= this.EEmpLastNameDtSrc.SubmitOnMasterChanged;
            this.EEmpLastNameDtSrc.OnDetailChanged -= this.EDDivisionNameDtSrc.SubmitOnDetailChanged;
/*
            _EDDivisionNameBttnItm = null;
*/
            this.EDEEntrprsNameDtSrc.AfterPropsChanged -= this.EDEEntrprsNameAfterPropsChanged;
            this.EDEEntrprsNameDtSrc.AfterMasterChanged -= this.EDEEntrprsNameAfterMasterChanged;
            this.EDEEntrprsNameDtSrc.OnMasterChanged -= this.EDDivisionNameDtSrc.SubmitOnMasterChanged;
            this.EDDivisionNameDtSrc.OnDetailChanged -= this.EDEEntrprsNameDtSrc.SubmitOnDetailChanged;
/*
            _EDEEntrprsNameBttnItm = null;
*/
        }
        #endregion

    }
}

