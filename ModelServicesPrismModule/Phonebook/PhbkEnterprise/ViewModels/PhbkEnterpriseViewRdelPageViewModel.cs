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
using Prism.Navigation;

using CommonInterfacesClassLibrary.Interfaces;
using CommonUserControlLibrary.ViewModels;
using CommonInterfacesClassLibrary.AppGlblSettingsSrvc;
using CommonInterfacesClassLibrary.Enums;
using ModelInterfacesClassLibrary.Phonebook.PhbkEnterprise;
/*



    "PhbkEnterpriseViewRdelPage" UserControl is defined in the "ModelServicesPrismModule"-project.
    In the file of IModule-class of "ModelServicesPrismModule"-project the following line of code must be inserted:

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ...
            // According to requirements of the "PhbkEnterpriseViewRdelPageViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            ViewModelLocationProvider.Register<PhbkEnterpriseViewRdelPage, PhbkEnterpriseViewRdelPageViewModel>();
            // According to requirements of the "PhbkEnterpriseViewRdelPageViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            containerRegistry.RegisterForNavigation<PhbkEnterpriseViewRdelPage, PhbkEnterpriseViewRdelPageViewModel>("PhbkEnterpriseViewRdelPage");
            // Only if you need to get an instance of controls, insert two lines below
            // According to requirements of the "PhbkEnterpriseViewRdelPageViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            // containerRegistry.Register<ContentPage, PhbkEnterpriseViewRdelPage>("PhbkEnterpriseViewRdelPage");
            ...
        }
*/

namespace ModelServicesPrismModule.Phonebook.PhbkEnterprise.ViewModels {
    public class PhbkEnterpriseViewRdelPageViewModel: INotifyPropertyChanged, INavigationAware, IDestructible  
    {
        protected IAppGlblSettingsService GlblSettingsSrv=null;
        protected IPhbkEnterpriseViewService FrmSrvPhbkEnterpriseView = null;
        protected INavigationService _navigationService = null;

        public PhbkEnterpriseViewRdelPageViewModel(IPhbkEnterpriseViewService _FrmSrvPhbkEnterpriseView, IAppGlblSettingsService GlblSettingsSrv, INavigationService navigationService) {
            this.GlblSettingsSrv = GlblSettingsSrv;
            this.FrmSrvPhbkEnterpriseView = _FrmSrvPhbkEnterpriseView;
            this._navigationService = navigationService;

            PermissionMask = GlblSettingsSrv.GetViewModelMask("PhbkEnterpriseView");
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        protected int PermissionMask = 0; 
        protected bool IsCanceled = true;
        protected IPhbkEnterpriseView modelToReturn = null;

        #region Caption
        string _Caption = "Delete item for Enterprise";
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
        protected EformModeEnum _EformMode = EformModeEnum.DeleteMode;
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
        protected IPhbkEnterpriseView _FormControlModel = null;
        public IPhbkEnterpriseView FormControlModel
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

        #region INavigationAware
        // public bool IsNavigationTarget(NavigationContext navigationContext) {
        //     return true;
        // }
        public void OnNavigatedFrom(INavigationParameters prms) {
            if(IsDestroyed) return;
            if(!IsCanceled) {
                prms.Add("pkpEntrprsId", modelToReturn.EntrprsId);
                prms.Add("EformModeEnum", EformMode);
            }
        }
        public void OnNavigatedTo(INavigationParameters prms) {
            if(IsDestroyed) return;
            IsCanceled = true;
            EformModeEnum modeToCheck = EformModeEnum.DeleteMode;
            if(prms.ContainsKey("EformModeEnum")) {
                modeToCheck = prms.GetValue<EformModeEnum>("EformModeEnum");
            }
            if ((modeToCheck == EformModeEnum.DeleteMode) && ((GlblSettingsSrv.GetViewModelMask("PhbkEnterpriseView") & 2) != 2 )) {
                throw new Exception("Access denied to delete PhbkEnterpriseView");
            } else if ((modeToCheck == EformModeEnum.UpdateMode) && ((GlblSettingsSrv.GetViewModelMask("PhbkEnterpriseView") & 4) != 4 )) {
                throw new Exception("Access denied to update PhbkEnterpriseView");
            } else if ((modeToCheck == EformModeEnum.AddMode) && ((GlblSettingsSrv.GetViewModelMask("PhbkEnterpriseView") & 8) != 8 )) {
                throw new Exception("Access denied to add PhbkEnterpriseView");
            }
            ObservableCollection<IWebServiceFilterRsltInterface> hf = new ObservableCollection<IWebServiceFilterRsltInterface>();
          
            if(prms.ContainsKey("EntrprsId")) {
                    hf.Add(new WebServiceFilterRsltViewModel() {
                        fltrName = "EntrprsId",
                        fltrDataType = "int32",
                        fltrOperator = "eq",
                        fltrValue = prms.GetValue<System.Int32>("EntrprsId"),
                        fltrError = null
                    });
            }
          
            if(prms.ContainsKey("EntrprsName")) {
                    hf.Add(new WebServiceFilterRsltViewModel() {
                        fltrName = "EntrprsName",
                        fltrDataType = "string",
                        fltrOperator = "eq",
                        fltrValue = prms.GetValue<System.String>("EntrprsName"),
                        fltrError = null
                    });
            }
          
            if(prms.ContainsKey("EntrprsDesc")) {
                    hf.Add(new WebServiceFilterRsltViewModel() {
                        fltrName = "EntrprsDesc",
                        fltrDataType = "string",
                        fltrOperator = "eq",
                        fltrValue = prms.GetValue<System.String>("EntrprsDesc"),
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
                EformModeEnum locmode = EformModeEnum.DeleteMode;
                string locCaption = "Delete item for Enterprise";
                    System.Int32 pkpEntrprsId = default(System.Int32);
                    if(prms.ContainsKey("pkpEntrprsId")) {
                        pkpEntrprsId = prms.GetValue<System.Int32>("pkpEntrprsId");
                    }
                // IPhbkEnterpriseView data
                _ = FrmSrvPhbkEnterpriseView.getone(
                    pkpEntrprsId
                ).ContinueWith((data) => {
                        MainThread.InvokeOnMainThreadAsync(() =>
                        {
                            Caption = locCaption;
                            if (resetHF) { HiddenFilters = hf; }
                            EformMode = locmode;
                            FormControlModel = FrmSrvPhbkEnterpriseView.CopyToModelNotify(data.Result, null);
                            IsParentLoaded = true;
                        });
                });
        }
        #endregion

        #region NavigationBackCommand
        public async Task  NavigationBackCommand() { 
            if(IsDestroyed) return;
            INavigationResult rslt = await _navigationService.GoBackAsync();
            if (rslt.Success) return;
            string exceptionMsg = "Can not navigate back:";
            if(rslt.Exception != null)
            {
                exceptionMsg = exceptionMsg + rslt.Exception.Message;
                Exception inner = rslt.Exception.InnerException;
                while (inner != null)
                {
                    exceptionMsg = exceptionMsg + ": " + inner.Message;
                    inner = inner.InnerException;
                }
                
            }
            GlblSettingsSrv.ShowErrorMessage("Page Navigation error", exceptionMsg);
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
        protected async void SubmitCommandAction(object param)
        {
            if(IsDestroyed) return;
            modelToReturn = param as IPhbkEnterpriseView;
            IsCanceled = false;
            await NavigationBackCommand();
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
        protected async void CancelCommandAction(object param)
        {
            IsCanceled = true;
            await NavigationBackCommand();
        }
        protected bool CancelCommandCanExecute(object param)
        {
            return true;
        }
        #endregion

        #region IDestructible 
        bool _IsDestroyed = false;
        public bool IsDestroyed {
            get { return _IsDestroyed; }
            set { if (_IsDestroyed != value) { _IsDestroyed = value; OnPropertyChanged();} }
        }
        public void Destroy()
        {
            if(IsDestroyed) return;
            IsDestroyed = true;
            _navigationService = null;
            _HiddenFilters = null;
            _FormControlModel = null;
        }
        #endregion
    }
}




