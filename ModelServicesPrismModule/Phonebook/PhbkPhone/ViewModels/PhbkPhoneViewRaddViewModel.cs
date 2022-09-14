using System;
using Xamarin.Forms;
using System.Linq;
using System.ComponentModel;
using Prism.Regions.Navigation;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using Prism.Navigation;
using Xamarin.Essentials;

using CommonInterfacesClassLibrary.Interfaces;
using CommonUserControlLibrary.ViewModels;
using CommonInterfacesClassLibrary.AppGlblSettingsSrvc;
using CommonInterfacesClassLibrary.Enums;
using ModelInterfacesClassLibrary.Phonebook.PhbkPhone;
/*



    "PhbkPhoneViewRaddUserControl" UserControl is defined in the "ModelServicesPrismModule"-project.
    In the file of IModule-class of "ModelServicesPrismModule"-project the following line of code must be inserted:

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ...
            // According to requirements of the "PhbkPhoneViewRaddViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            ViewModelLocationProvider.Register<PhbkPhoneViewRaddUserControl, PhbkPhoneViewRaddViewModel>();
            // According to requirements of the "PhbkPhoneViewRaddViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            containerRegistry.RegisterForRegionNavigation<PhbkPhoneViewRaddUserControl, PhbkPhoneViewRaddViewModel>("PhbkPhoneViewRaddUserControl");
            // According to requirements of the "PhbkPhoneViewRaddViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            containerRegistry.Register<ContentView, PhbkPhoneViewRaddUserControl>("PhbkPhoneViewRaddUserControl");
            ...
        }
*/

namespace ModelServicesPrismModule.Phonebook.PhbkPhone.ViewModels {
    public class PhbkPhoneViewRaddViewModel: RegionAwareViewModelBase, IRegionAware 
    {
        protected IAppGlblSettingsService GlblSettingsSrv=null;
        protected IPhbkPhoneViewService FrmSrvPhbkPhoneView = null;

        public PhbkPhoneViewRaddViewModel(IPhbkPhoneViewService _FrmSrvPhbkPhoneView, IAppGlblSettingsService GlblSettingsSrv) {
            this.GlblSettingsSrv = GlblSettingsSrv;
            this.FrmSrvPhbkPhoneView = _FrmSrvPhbkPhoneView;
            PermissionMask = GlblSettingsSrv.GetViewModelMask("PhbkPhoneView");
        }


        protected int PermissionMask = 0; 


        protected bool IsCanceled = true;
        protected IPhbkPhoneView modelToReturn = null;


        public bool CanAdd
        { 
            get
            {
                return ((PermissionMask & 8) == 8) && CanAddParent;
            }
        }
        public bool CanUpdate
        { 
            get
            {
                return ((PermissionMask & 4) == 4) && CanUpdateParent;
            }
        }
        public bool CanDelete
        { 
            get
            {
                return ((PermissionMask & 2) == 2) && CanDeleteParent;
            }
        }

        public bool CanAddDetail
        { 
            get
            {
                return CanAddDetailParent;
            }
        }
        public bool CanUpdateDetail
        { 
            get
            {
                return CanUpdateDetailParent;
            }
        }
        public bool CanDeleteDetail
        { 
            get
            {
                return CanDeleteDetailParent;
            }
        }

        #region Caption
        string _Caption = "Delete item for Phone";
        public string Caption
        { 
            get
            {
                return _Caption;
            }
            set {
                if(_Caption != value) {
                    _Caption = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion
        #region EformMode
        protected EformModeEnum _EformMode = EformModeEnum.ViewMode;
        public EformModeEnum EformMode
        {
            get
            {
                return _EformMode;
            }
            set
            {
                if (_EformMode != value) {
                    _EformMode = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion
        #region FormControlModel
        protected IPhbkPhoneView _FormControlModel = null;
        public IPhbkPhoneView FormControlModel
        {
            get
            {
                return _FormControlModel;
            }
            set
            {
                if (_FormControlModel != value) {
                    _FormControlModel = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion


        #region HiddenFilters
        IEnumerable<IWebServiceFilterRsltInterface> _HiddenFilters = new ObservableCollection<IWebServiceFilterRsltInterface>();
        public IEnumerable<IWebServiceFilterRsltInterface> HiddenFilters
        {
            get
            {
                return _HiddenFilters;
            }
            set
            {
                if (_HiddenFilters != value)
                {
                    _HiddenFilters = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion
        #region IsParentLoaded
        bool _IsParentLoaded = false;
        public bool IsParentLoaded
        { 
            get
            {
                return _IsParentLoaded;
            }
            set {
                if(_IsParentLoaded != value) {
                    _IsParentLoaded = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        #region IRegionAware
        public bool IsNavigationTarget(INavigationContext navigationContext) {
            return true;
        }
        public void OnNavigatedFrom(INavigationContext navigationContext) {
            if (IsDestroyed) return;
            if(!IsCanceled) {
                INavigationParameters prms = navigationContext.Parameters;
                prms.Add("pkpPhoneId", modelToReturn.PhoneId);
                prms.Add("EformModeEnum", EformMode);
            }
            CurrentNavigationContext = null;
            IsParentLoaded = false; // important to set
        }
        public void OnNavigatedTo(INavigationContext navigationContext) {
            if (IsDestroyed) return;
            INavigationParameters prms = navigationContext.Parameters;
            IsCanceled = true;
            EformModeEnum modeToCheck = EformModeEnum.ViewMode;

            if(prms.ContainsKey("EformModeEnum")) {
                modeToCheck = prms.GetValue<EformModeEnum>("EformModeEnum");
            }
            if ((modeToCheck == EformModeEnum.DeleteMode) && (!CanDelete)) {
                throw new Exception("Access denied to delete PhbkPhoneView");
            } else if ((modeToCheck == EformModeEnum.UpdateMode) && (!CanUpdate)) {
                throw new Exception("Access denied to update PhbkPhoneView");
            } else if ((modeToCheck == EformModeEnum.AddMode) && (!CanAdd)) {
                throw new Exception("Access denied to add PhbkPhoneView");
            }
            CurrentNavigationContext = navigationContext;

            ObservableCollection<IWebServiceFilterRsltInterface> hf = new ObservableCollection<IWebServiceFilterRsltInterface>();
          
            if(prms.ContainsKey("PhoneId")) {
                    hf.Add(new WebServiceFilterRsltViewModel() {
                        fltrName = "PhoneId",
                        fltrDataType = "int32",
                        fltrOperator = "eq",
                        fltrValue = prms.GetValue<System.Int32>("PhoneId"),
                        fltrError = null
                    });
            }
          
            if(prms.ContainsKey("Phone")) {
                    hf.Add(new WebServiceFilterRsltViewModel() {
                        fltrName = "Phone",
                        fltrDataType = "string",
                        fltrOperator = "eq",
                        fltrValue = prms.GetValue<System.String>("Phone"),
                        fltrError = null
                    });
            }
          
            if(prms.ContainsKey("PhoneTypeIdRef")) {
                    hf.Add(new WebServiceFilterRsltViewModel() {
                        fltrName = "PhoneTypeIdRef",
                        fltrDataType = "int32",
                        fltrOperator = "eq",
                        fltrValue = prms.GetValue<System.Int32>("PhoneTypeIdRef"),
                        fltrError = null
                    });
            }
          
            if(prms.ContainsKey("EmployeeIdRef")) {
                    hf.Add(new WebServiceFilterRsltViewModel() {
                        fltrName = "EmployeeIdRef",
                        fltrDataType = "int32",
                        fltrOperator = "eq",
                        fltrValue = prms.GetValue<System.Int32>("EmployeeIdRef"),
                        fltrError = null
                    });
            }
          
            if(prms.ContainsKey("PPhoneTypeName")) {
                    hf.Add(new WebServiceFilterRsltViewModel() {
                        fltrName = "PPhoneTypeName",
                        fltrDataType = "string",
                        fltrOperator = "eq",
                        fltrValue = prms.GetValue<System.String>("PPhoneTypeName"),
                        fltrError = null
                    });
            }
          
            if(prms.ContainsKey("EEmpFirstName")) {
                    hf.Add(new WebServiceFilterRsltViewModel() {
                        fltrName = "EEmpFirstName",
                        fltrDataType = "string",
                        fltrOperator = "eq",
                        fltrValue = prms.GetValue<System.String>("EEmpFirstName"),
                        fltrError = null
                    });
            }
          
            if(prms.ContainsKey("EEmpLastName")) {
                    hf.Add(new WebServiceFilterRsltViewModel() {
                        fltrName = "EEmpLastName",
                        fltrDataType = "string",
                        fltrOperator = "eq",
                        fltrValue = prms.GetValue<System.String>("EEmpLastName"),
                        fltrError = null
                    });
            }
          
            if(prms.ContainsKey("EEmpSecondName")) {
                    hf.Add(new WebServiceFilterRsltViewModel() {
                        fltrName = "EEmpSecondName",
                        fltrDataType = "string",
                        fltrOperator = "eq",
                        fltrValue = prms.GetValue<System.String>("EEmpSecondName"),
                        fltrError = null
                    });
            }
          
            if(prms.ContainsKey("EDDivisionName")) {
                    hf.Add(new WebServiceFilterRsltViewModel() {
                        fltrName = "EDDivisionName",
                        fltrDataType = "string",
                        fltrOperator = "eq",
                        fltrValue = prms.GetValue<System.String>("EDDivisionName"),
                        fltrError = null
                    });
            }
          
            if(prms.ContainsKey("EDEEntrprsName")) {
                    hf.Add(new WebServiceFilterRsltViewModel() {
                        fltrName = "EDEEntrprsName",
                        fltrDataType = "string",
                        fltrOperator = "eq",
                        fltrValue = prms.GetValue<System.String>("EDEEntrprsName"),
                        fltrError = null
                    });
            }
          
            ObservableCollection<IWebServiceFilterRsltInterface> chf = HiddenFilters as ObservableCollection<IWebServiceFilterRsltInterface>;
            bool resetHF = chf.Count != hf.Count;
            if ((!resetHF) && (hf.Count > 0)) {
                foreach(IWebServiceFilterRsltInterface citm in chf) {
                    IWebServiceFilterRsltInterface itm = hf.Where(h => h.fltrName == citm.fltrName).FirstOrDefault();
                    if(itm == null)
                    {
                        resetHF = true;
                        break;
                    }
                    if (!(itm.fltrValue == citm.fltrValue))
                    {
                        resetHF = true;
                        break;
                    }
                }
            } 

                Caption = "Add item for Phone";
                if (resetHF) { HiddenFilters = hf; }
                FormControlModel = FrmSrvPhbkPhoneView.CopyToModelNotify(null,null); // this is correct: cleanup twice
                EformMode = EformModeEnum.AddMode;
                FormControlModel = null; // since DateTime-issue this is correct: FrmSrvPhbkPhoneView.CopyToModelNotify(null,null);
                IsParentLoaded = true;
        }
        #endregion

        #region NavigationBackCommand
        public void  NavigationBackCommand() { 
            if (IsDestroyed) return;
            if (CurrentNavigationContext != null) {
                if(CurrentNavigationContext.NavigationService.Journal.CanGoBack) {
                    CurrentNavigationContext.NavigationService.Journal.GoBack();
                }
            }
        } 
        #endregion


        #region SubmitCommand
        private ICommand _SubmitCommand;
        public ICommand SubmitCommand
        {
            get
            {
                return _SubmitCommand ?? (_SubmitCommand = new Command((param) => SubmitCommandAction(param), (param) => SubmitCommandCanExecute(param)));
            }
        }
        protected void SubmitCommandAction(object param)
        {
            if (IsDestroyed) return;
            modelToReturn = param as IPhbkPhoneView;
            IsCanceled = false;
            NavigationBackCommand();
        }
        protected bool SubmitCommandCanExecute(object param)
        {
            return true;
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
            IsCanceled = true;
            NavigationBackCommand();
        }
        protected bool CancelCommandCanExecute(object param)
        {
            return true;
        }
        #endregion

        public override void OnDestroy() {
            base.OnDestroy();
            _HiddenFilters = null;
            _FormControlModel = null;
            _Caption = null;
        }

    }
}



