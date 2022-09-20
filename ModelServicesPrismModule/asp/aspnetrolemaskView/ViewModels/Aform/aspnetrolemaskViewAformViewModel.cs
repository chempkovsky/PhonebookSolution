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
using ModelInterfacesClassLibrary.interfaces.asp.aspnetroleView;
using ModelInterfacesClassLibrary.interfaces.asp.aspnetmodelView;
/*




    "AspnetrolemaskViewAformUserControl" UserControl is defined in the "ModelServicesPrismModule"-project.
    In the file of IModule-class of "ModelServicesPrismModule"-project the following line of code must be inserted:

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ...
            // According to requirements of the "AspnetrolemaskViewAformViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            ViewModelLocationProvider.Register<AspnetrolemaskViewAformUserControl, AspnetrolemaskViewAformViewModel>();
            // According to requirements of the "AspnetrolemaskViewAformViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            containerRegistry.Register<ContentView, AspnetrolemaskViewAformUserControl>("AspnetrolemaskViewAformUserControl");
            ...
        }

*/

namespace ModelServicesPrismModule.asp.aspnetrolemaskView.ViewModels.Aform {
    public class AspnetrolemaskViewAformViewModel: INotifyPropertyChanged, INotifyDataErrorInfo, IEformViewModelInterface, IBindingContextChanged
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
                    this.rootDataSource.setValue("RoleDescription", value);
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
                    this.rootDataSource.setValue("Mask1", value);
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
                    this.rootDataSource.setValue("Mask2", value);
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
                    this.rootDataSource.setValue("Mask3", value);
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
                    this.rootDataSource.setValue("Mask4", value);
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
                    this.rootDataSource.setValue("Mask5", value);
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
        protected IAspnetmodelViewDatasource MModelNameDtSrc = null;
        protected object _MModelNameCmbCntrl = null;
        public object MModelNameCmbCntrl {
            get { 
                return _MModelNameCmbCntrl; 
            }
            set { 
                var val = value as IAspnetmodelView;
                if(_MModelNameCmbCntrl != val) { 
                    _MModelNameCmbCntrl = val; 
                    if(val == null) {
                        this.MModelNameDtSrc.ClearPartially(true);
                    } else {
                        this.MModelNameDtSrc.Interface2Values(val, true);
                    }
                    OnPropertyChanged(); 
                    ValidateField(value);
                } 
            }
        }
        public string MModelNameCmbCntrlSuffixError {
            get {
                return GetFirstError("MModelNameCmbCntrl");
            }
        }
        protected IList<IAspnetmodelView> _MModelNameCmbCntrlVals = null;
        public IList<IAspnetmodelView> MModelNameCmbCntrlVals {
            get { 
                return _MModelNameCmbCntrlVals; 
            }
            set { 
                if(_MModelNameCmbCntrlVals != value) { 
                    _MModelNameCmbCntrlVals = value; 
                    OnPropertyChanged(); 
                } 
            }
        }
        #endregion

        #region Constructor
        public AspnetrolemaskViewAformViewModel(IAspnetrolemaskViewDatasource _rootDataSource,
            IAspnetroleViewDatasource _RNameDtSrc,
            IAspnetmodelViewDatasource _MModelNameDtSrc,
            IAppGlblSettingsService _GlblSettingsSrv, 
            IDialogService _dialogService) {
            this.GlblSettingsSrv = _GlblSettingsSrv;
            this.dialogService = _dialogService;
            this.rootDataSource = _rootDataSource;
            this.rootDataSource.Init(null, null, new List<string>{"AspNetRole", "AspNetModel"},"");
            this.rootDataSource.setIsNew(false);
            this.rootDataSource.AfterPropsChanged += this.rootDataSourceAfterPropsChanged;

            this.rootDataSource.OnAdd += this.rootDataSourceOnAdd;


            this.RNameDtSrc = _RNameDtSrc;
            this.RNameDtSrc.Init("aspnetrolemaskView", "AspNetRole", new List<string>{},"AspNetRole");
            this.RNameDtSrc.setIsNew(false);
            this.RNameDtSrc.AfterPropsChanged += this.RNameAfterPropsChanged;
            this.RNameDtSrc.AfterMasterChanged += this.RNameAfterMasterChanged;
            this.RNameDtSrc.OnMasterChanged += this.rootDataSource.SubmitOnMasterChanged;
            this.rootDataSource.OnDetailChanged += this.RNameDtSrc.SubmitOnDetailChanged;

            this.MModelNameDtSrc = _MModelNameDtSrc;
            this.MModelNameDtSrc.Init("aspnetrolemaskView", "AspNetModel", new List<string>{},"AspNetModel");
            this.MModelNameDtSrc.setIsNew(false);
            this.MModelNameDtSrc.AfterPropsChanged += this.MModelNameAfterPropsChanged;
            this.MModelNameDtSrc.AfterMasterChanged += this.MModelNameAfterMasterChanged;
            this.MModelNameDtSrc.OnMasterChanged += this.rootDataSource.SubmitOnMasterChanged;
            this.rootDataSource.OnDetailChanged += this.MModelNameDtSrc.SubmitOnDetailChanged;

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
                case "RNameCmbCntrl":
                    requiredAttribute = new RequiredAttribute();
                    msg = requiredAttribute.FormatErrorMessage(string.Empty);
                    break;
                case "MModelNameCmbCntrl":
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
            ValidateField(RName, "RName");
            ValidateField(RoleDescription, "RoleDescription");
            ValidateField(ModelPkRef, "ModelPkRef");
            ValidateField(MModelName, "MModelName");
            ValidateField(Mask1, "Mask1");
            ValidateField(Mask2, "Mask2");
            ValidateField(Mask3, "Mask3");
            ValidateField(Mask4, "Mask4");
            ValidateField(Mask5, "Mask5");
            ValidateObjectField(RNameCmbCntrl, "RNameCmbCntrl");
            ValidateObjectField(MModelNameCmbCntrl, "MModelNameCmbCntrl");
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
            RaiseErrorsChanged("RNameCmbCntrl");
            RaiseErrorsChanged("MModelNameCmbCntrl");
        }
        #endregion


        #region rootDataSourceAfterPropsChanged
        public async void rootDataSourceAfterPropsChanged(object sender, EventArgs e) {
            await DorootDataSourceAfterPropsChanged(sender);
        }
        public async Task DorootDataSourceAfterPropsChanged(object sender) {
            await MainThread.InvokeOnMainThreadAsync(() => {
                this.PatchRoleDescription(this.rootDataSource.getValue("RoleDescription"));
                this.PatchModelPkRef(this.rootDataSource.getValue("ModelPkRef"));
                this.PatchMask1(this.rootDataSource.getValue("Mask1"));
                this.PatchMask2(this.rootDataSource.getValue("Mask2"));
                this.PatchMask3(this.rootDataSource.getValue("Mask3"));
                this.PatchMask4(this.rootDataSource.getValue("Mask4"));
                this.PatchMask5(this.rootDataSource.getValue("Mask5"));
                this.RNameEnabled = 
                    (!this.rootDataSource.isUnderHiddenFilterFields("RName")) &&
                    this.RNameDtSrc.IsSetFilterByCurrDirMstrs();
                this.MModelNameEnabled = 
                    (!this.rootDataSource.isUnderHiddenFilterFields("MModelName")) &&
                    this.MModelNameDtSrc.IsSetFilterByCurrDirMstrs();
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
        #region MModelNameAfterMasterChanged
        public async void MModelNameAfterMasterChanged(object sender, EventArgs ea) {
            await DoMModelNameAfterMasterChanged(sender);
        }
        public async Task DoMModelNameAfterMasterChanged(object sender) {
                IList<IAspnetmodelView> data = null;
                IAspnetmodelView newItm = null;
                try {
                    data = await this.MModelNameDtSrc.GetClActionByCurrDirMstrs();
                    if(data != null) {
                        if(this.MModelNameDtSrc.CalcIsDefined()) {
                            IAspnetmodelView currItm = this.MModelNameDtSrc.Values2Interface();
                            newItm = data.Where(e => (e.ModelPk == currItm.ModelPk)).FirstOrDefault();
                        }
                    }
                } catch(Exception ex)
                {
                    string exceptionMsg = "MModelNameAfterMasterChanged : " + ex.Message;
                    Exception inner = ex.InnerException;
                    while (inner != null)
                    {
                        exceptionMsg = exceptionMsg + ": " + inner.Message;
                        inner = inner.InnerException;
                    }
                    GlblSettingsSrv.ShowErrorMessage("http", exceptionMsg);
                }


            await MainThread.InvokeOnMainThreadAsync(() => {
                _MModelNameCmbCntrl = null;
                OnPropertyChanged("MModelNameCmbCntrl");
                this._MModelNameCmbCntrlVals = data;
                OnPropertyChanged("MModelNameCmbCntrlVals");
                this._MModelNameCmbCntrl = newItm;
                OnPropertyChanged("MModelNameCmbCntrl");
                ValidateObjectField(newItm, "MModelNameCmbCntrl");
                if(newItm != null)
                    this.MModelName = newItm.ModelName;
                else
                    this.MModelName = null;
                if(this.MModelNameDtSrc.IsSetFilterByCurrDirMstrs() &&
                  (!this.rootDataSource.isUnderHiddenFilterFields("MModelName"))) {
                    this.MModelNameEnabled = true;
                } else {
                    this.MModelNameEnabled = false;
                }

            });
        }
        #endregion
        #region MModelNameAfterPropsChanged
        public async void MModelNameAfterPropsChanged(object sender, EventArgs ea) {
            await DoMModelNameAfterPropsChanged(sender);
        }
        public async Task DoMModelNameAfterPropsChanged(object sender) {
            await MainThread.InvokeOnMainThreadAsync(() => {

            if(this.MModelNameCmbCntrlVals != null) {
                IAspnetmodelView currItm = this.MModelNameDtSrc.Values2Interface();
                IAspnetmodelView newItm = null;
                if(currItm != null) {
                    newItm = this.MModelNameCmbCntrlVals.Where(e => (e.ModelPk == currItm.ModelPk)).FirstOrDefault();
                }
                this._MModelNameCmbCntrl = newItm;
                OnPropertyChanged("MModelNameCmbCntrl");
                ValidateObjectField(newItm, "MModelNameCmbCntrl");
                if(newItm != null)
                    this.PatchMModelName(newItm.ModelName);
                else 
                    this.PatchMModelName(null);
            } else {
                this._MModelNameCmbCntrl = null;
                OnPropertyChanged("MModelNameCmbCntrl");
                ValidateObjectField(null, "MModelNameCmbCntrl");
                this.PatchMModelName(null);
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
                                await this.DoRNameAfterMasterChanged(this.RNameDtSrc);
                                await this.DoMModelNameAfterMasterChanged(this.MModelNameDtSrc);
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
            this.RNameDtSrc.AfterPropsChanged -= this.RNameAfterPropsChanged;
            this.RNameDtSrc.AfterMasterChanged -= this.RNameAfterMasterChanged;
            this.RNameDtSrc.OnMasterChanged -= this.rootDataSource.SubmitOnMasterChanged;
            this.rootDataSource.OnDetailChanged -= this.RNameDtSrc.SubmitOnDetailChanged;

            _RNameCmbCntrl = null;
            _RNameCmbCntrlVals = null;
            this.MModelNameDtSrc.AfterPropsChanged -= this.MModelNameAfterPropsChanged;
            this.MModelNameDtSrc.AfterMasterChanged -= this.MModelNameAfterMasterChanged;
            this.MModelNameDtSrc.OnMasterChanged -= this.rootDataSource.SubmitOnMasterChanged;
            this.rootDataSource.OnDetailChanged -= this.MModelNameDtSrc.SubmitOnDetailChanged;

            _MModelNameCmbCntrl = null;
            _MModelNameCmbCntrlVals = null;
        }
        #endregion

    }
}

