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
using ModelInterfacesClassLibrary.Phonebook.PhbkEmployee;
/*



    "PhbkEmployeeViewRaddUserControl" UserControl is defined in the "ModelServicesPrismModule"-project.
    In the file of IModule-class of "ModelServicesPrismModule"-project the following line of code must be inserted:

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ...
            // According to requirements of the "PhbkEmployeeViewRaddViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            ViewModelLocationProvider.Register<PhbkEmployeeViewRaddUserControl, PhbkEmployeeViewRaddViewModel>();
            // According to requirements of the "PhbkEmployeeViewRaddViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            containerRegistry.RegisterForRegionNavigation<PhbkEmployeeViewRaddUserControl, PhbkEmployeeViewRaddViewModel>("PhbkEmployeeViewRaddUserControl");
            // According to requirements of the "PhbkEmployeeViewRaddViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            containerRegistry.Register<ContentView, PhbkEmployeeViewRaddUserControl>("PhbkEmployeeViewRaddUserControl");
            ...
        }
*/

namespace ModelServicesPrismModule.Phonebook.PhbkEmployee.ViewModels {
    public class PhbkEmployeeViewRaddViewModel: RegionAwareViewModelBase, IRegionAware 
    {
        protected IAppGlblSettingsService GlblSettingsSrv=null;
        protected IPhbkEmployeeViewService FrmSrvPhbkEmployeeView = null;

        public PhbkEmployeeViewRaddViewModel(IPhbkEmployeeViewService _FrmSrvPhbkEmployeeView, IAppGlblSettingsService GlblSettingsSrv) {
            this.GlblSettingsSrv = GlblSettingsSrv;
            this.FrmSrvPhbkEmployeeView = _FrmSrvPhbkEmployeeView;
            PermissionMask = GlblSettingsSrv.GetViewModelMask("PhbkEmployeeView");
        }


        protected int PermissionMask = 0; 


        protected bool IsCanceled = true;
        protected IPhbkEmployeeView modelToReturn = null;


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
        string _Caption = "Delete item for Employee";
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
        protected IPhbkEmployeeView _FormControlModel = null;
        public IPhbkEmployeeView FormControlModel
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
                prms.Add("pkpEmployeeId", modelToReturn.EmployeeId);
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
                throw new Exception("Access denied to delete PhbkEmployeeView");
            } else if ((modeToCheck == EformModeEnum.UpdateMode) && (!CanUpdate)) {
                throw new Exception("Access denied to update PhbkEmployeeView");
            } else if ((modeToCheck == EformModeEnum.AddMode) && (!CanAdd)) {
                throw new Exception("Access denied to add PhbkEmployeeView");
            }
            CurrentNavigationContext = navigationContext;

            ObservableCollection<IWebServiceFilterRsltInterface> hf = new ObservableCollection<IWebServiceFilterRsltInterface>();
          
            if(prms.ContainsKey("EmployeeId")) {
                    hf.Add(new WebServiceFilterRsltViewModel() {
                        fltrName = "EmployeeId",
                        fltrDataType = "int32",
                        fltrOperator = "eq",
                        fltrValue = prms.GetValue<System.Int32>("EmployeeId"),
                        fltrError = null
                    });
            }
          
            if(prms.ContainsKey("EmpFirstName")) {
                    hf.Add(new WebServiceFilterRsltViewModel() {
                        fltrName = "EmpFirstName",
                        fltrDataType = "string",
                        fltrOperator = "eq",
                        fltrValue = prms.GetValue<System.String>("EmpFirstName"),
                        fltrError = null
                    });
            }
          
            if(prms.ContainsKey("EmpLastName")) {
                    hf.Add(new WebServiceFilterRsltViewModel() {
                        fltrName = "EmpLastName",
                        fltrDataType = "string",
                        fltrOperator = "eq",
                        fltrValue = prms.GetValue<System.String>("EmpLastName"),
                        fltrError = null
                    });
            }
          
            if(prms.ContainsKey("EmpSecondName")) {
                    hf.Add(new WebServiceFilterRsltViewModel() {
                        fltrName = "EmpSecondName",
                        fltrDataType = "string",
                        fltrOperator = "eq",
                        fltrValue = prms.GetValue<System.String>("EmpSecondName"),
                        fltrError = null
                    });
            }
          
            if(prms.ContainsKey("DivisionIdRef")) {
                    hf.Add(new WebServiceFilterRsltViewModel() {
                        fltrName = "DivisionIdRef",
                        fltrDataType = "int32",
                        fltrOperator = "eq",
                        fltrValue = prms.GetValue<System.Int32>("DivisionIdRef"),
                        fltrError = null
                    });
            }
          
            if(prms.ContainsKey("DDivisionName")) {
                    hf.Add(new WebServiceFilterRsltViewModel() {
                        fltrName = "DDivisionName",
                        fltrDataType = "string",
                        fltrOperator = "eq",
                        fltrValue = prms.GetValue<System.String>("DDivisionName"),
                        fltrError = null
                    });
            }
          
            if(prms.ContainsKey("DEEntrprsName")) {
                    hf.Add(new WebServiceFilterRsltViewModel() {
                        fltrName = "DEEntrprsName",
                        fltrDataType = "string",
                        fltrOperator = "eq",
                        fltrValue = prms.GetValue<System.String>("DEEntrprsName"),
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

                Caption = "Add item for Employee";
                if (resetHF) { HiddenFilters = hf; }
                FormControlModel = FrmSrvPhbkEmployeeView.CopyToModelNotify(null,null); // this is correct: cleanup twice
                EformMode = EformModeEnum.AddMode;
                FormControlModel = null; // since DateTime-issue this is correct: FrmSrvPhbkEmployeeView.CopyToModelNotify(null,null);
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
            modelToReturn = param as IPhbkEmployeeView;
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



