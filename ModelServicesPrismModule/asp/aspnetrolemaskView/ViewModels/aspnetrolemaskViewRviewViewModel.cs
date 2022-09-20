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
using ModelInterfacesClassLibrary.interfaces.asp.aspnetrolemaskView;
/*



    "AspnetrolemaskViewRviewUserControl" UserControl is defined in the "ModelServicesPrismModule"-project.
    In the file of IModule-class of "ModelServicesPrismModule"-project the following line of code must be inserted:

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ...
            // According to requirements of the "AspnetrolemaskViewRviewViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            ViewModelLocationProvider.Register<AspnetrolemaskViewRviewUserControl, AspnetrolemaskViewRviewViewModel>();
            // According to requirements of the "AspnetrolemaskViewRviewViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            containerRegistry.RegisterForRegionNavigation<AspnetrolemaskViewRviewUserControl, AspnetrolemaskViewRviewViewModel>("AspnetrolemaskViewRviewUserControl");
            // According to requirements of the "AspnetrolemaskViewRviewViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            containerRegistry.Register<ContentView, AspnetrolemaskViewRviewUserControl>("AspnetrolemaskViewRviewUserControl");
            ...
        }
*/

namespace ModelServicesPrismModule.asp.aspnetrolemaskView.ViewModels {
    public class AspnetrolemaskViewRviewViewModel: RegionAwareViewModelBase, IRegionAware 
    {
        protected IAppGlblSettingsService GlblSettingsSrv=null;
        protected IAspnetrolemaskViewService FrmSrvaspnetrolemaskView = null;

        public AspnetrolemaskViewRviewViewModel(IAspnetrolemaskViewService _FrmSrvaspnetrolemaskView, IAppGlblSettingsService GlblSettingsSrv) {
            this.GlblSettingsSrv = GlblSettingsSrv;
            this.FrmSrvaspnetrolemaskView = _FrmSrvaspnetrolemaskView;
            PermissionMask = GlblSettingsSrv.GetViewModelMask("aspnetrolemaskView");
        }


        protected int PermissionMask = 0; 


        protected bool IsCanceled = true;
        protected IAspnetrolemaskView modelToReturn = null;


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
        string _Caption = "Delete item for Role Mask";
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
        protected IAspnetrolemaskView _FormControlModel = null;
        public IAspnetrolemaskView FormControlModel
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
                prms.Add("pkpRName", modelToReturn.RName);
                prms.Add("pkpModelPkRef", modelToReturn.ModelPkRef);
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
                throw new Exception("Access denied to delete aspnetrolemaskView");
            } else if ((modeToCheck == EformModeEnum.UpdateMode) && (!CanUpdate)) {
                throw new Exception("Access denied to update aspnetrolemaskView");
            } else if ((modeToCheck == EformModeEnum.AddMode) && (!CanAdd)) {
                throw new Exception("Access denied to add aspnetrolemaskView");
            }
            CurrentNavigationContext = navigationContext;

            ObservableCollection<IWebServiceFilterRsltInterface> hf = new ObservableCollection<IWebServiceFilterRsltInterface>();
          
            if(prms.ContainsKey("RoleDescription")) {
                    hf.Add(new WebServiceFilterRsltViewModel() {
                        fltrName = "RoleDescription",
                        fltrDataType = "string",
                        fltrOperator = "eq",
                        fltrValue = prms.GetValue<System.String>("RoleDescription"),
                        fltrError = null
                    });
            }
          
            if(prms.ContainsKey("Mask1")) {
                    hf.Add(new WebServiceFilterRsltViewModel() {
                        fltrName = "Mask1",
                        fltrDataType = "boolean",
                        fltrOperator = "eq",
                        fltrValue = prms.GetValue<System.Boolean>("Mask1"),
                        fltrError = null
                    });
            }
          
            if(prms.ContainsKey("Mask2")) {
                    hf.Add(new WebServiceFilterRsltViewModel() {
                        fltrName = "Mask2",
                        fltrDataType = "boolean",
                        fltrOperator = "eq",
                        fltrValue = prms.GetValue<System.Boolean>("Mask2"),
                        fltrError = null
                    });
            }
          
            if(prms.ContainsKey("Mask3")) {
                    hf.Add(new WebServiceFilterRsltViewModel() {
                        fltrName = "Mask3",
                        fltrDataType = "boolean",
                        fltrOperator = "eq",
                        fltrValue = prms.GetValue<System.Boolean>("Mask3"),
                        fltrError = null
                    });
            }
          
            if(prms.ContainsKey("Mask4")) {
                    hf.Add(new WebServiceFilterRsltViewModel() {
                        fltrName = "Mask4",
                        fltrDataType = "boolean",
                        fltrOperator = "eq",
                        fltrValue = prms.GetValue<System.Boolean>("Mask4"),
                        fltrError = null
                    });
            }
          
            if(prms.ContainsKey("Mask5")) {
                    hf.Add(new WebServiceFilterRsltViewModel() {
                        fltrName = "Mask5",
                        fltrDataType = "boolean",
                        fltrOperator = "eq",
                        fltrValue = prms.GetValue<System.Boolean>("Mask5"),
                        fltrError = null
                    });
            }
          
            if(prms.ContainsKey("ModelPkRef")) {
                    hf.Add(new WebServiceFilterRsltViewModel() {
                        fltrName = "ModelPkRef",
                        fltrDataType = "int32",
                        fltrOperator = "eq",
                        fltrValue = prms.GetValue<System.Int32>("ModelPkRef"),
                        fltrError = null
                    });
            }
          
            if(prms.ContainsKey("MModelName")) {
                    hf.Add(new WebServiceFilterRsltViewModel() {
                        fltrName = "MModelName",
                        fltrDataType = "string",
                        fltrOperator = "eq",
                        fltrValue = prms.GetValue<System.String>("MModelName"),
                        fltrError = null
                    });
            }
          
            if(prms.ContainsKey("RName")) {
                    hf.Add(new WebServiceFilterRsltViewModel() {
                        fltrName = "RName",
                        fltrDataType = "string",
                        fltrOperator = "eq",
                        fltrValue = prms.GetValue<System.String>("RName"),
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

                EformModeEnum locmode = EformModeEnum.ViewMode;
                string locCaption = "View item for Role Mask";
                System.String pkpRName = default(System.String);
                if(prms.ContainsKey("pkpRName")) {
                    pkpRName = prms.GetValue<System.String>("pkpRName");
                }
                System.Int32 pkpModelPkRef = default(System.Int32);
                if(prms.ContainsKey("pkpModelPkRef")) {
                    pkpModelPkRef = prms.GetValue<System.Int32>("pkpModelPkRef");
                }
                // IAspnetrolemaskView data
                _ = FrmSrvaspnetrolemaskView.getone(
                    pkpRName
                  , pkpModelPkRef
                ).ContinueWith((data) => {
                        MainThread.InvokeOnMainThreadAsync(() =>
                        {
                            Caption = locCaption;
                            if (resetHF) { HiddenFilters = hf; }
                            EformMode = locmode;
                            FormControlModel = FrmSrvaspnetrolemaskView.CopyToModelNotify(data.Result, null);
                            IsParentLoaded = true;
                        });
                });
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
            modelToReturn = param as IAspnetrolemaskView;
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



