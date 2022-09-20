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
using ModelInterfacesClassLibrary.interfaces.asp.aspnetuserView;
/*



    "AspnetuserViewRupdPage" UserControl is defined in the "ModelServicesPrismModule"-project.
    In the file of IModule-class of "ModelServicesPrismModule"-project the following line of code must be inserted:

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ...
            // According to requirements of the "AspnetuserViewRupdPageViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            ViewModelLocationProvider.Register<AspnetuserViewRupdPage, AspnetuserViewRupdPageViewModel>();
            // According to requirements of the "AspnetuserViewRupdPageViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            containerRegistry.RegisterForNavigation<AspnetuserViewRupdPage, AspnetuserViewRupdPageViewModel>("AspnetuserViewRupdPage");
            // Only if you need to get an instance of controls, insert two lines below
            // According to requirements of the "AspnetuserViewRupdPageViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            // containerRegistry.Register<ContentPage, AspnetuserViewRupdPage>("AspnetuserViewRupdPage");
            ...
        }
*/

namespace ModelServicesPrismModule.asp.aspnetuserView.ViewModels {
    public class AspnetuserViewRupdPageViewModel: INotifyPropertyChanged, INavigationAware, IDestructible  
    {
        protected IAppGlblSettingsService GlblSettingsSrv=null;
        protected IAspnetuserViewService FrmSrvaspnetuserView = null;
        protected INavigationService _navigationService = null;

        public AspnetuserViewRupdPageViewModel(IAspnetuserViewService _FrmSrvaspnetuserView, IAppGlblSettingsService GlblSettingsSrv, INavigationService navigationService) {
            this.GlblSettingsSrv = GlblSettingsSrv;
            this.FrmSrvaspnetuserView = _FrmSrvaspnetuserView;
            this._navigationService = navigationService;

            PermissionMask = GlblSettingsSrv.GetViewModelMask("aspnetuserView");
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
        protected IAspnetuserView modelToReturn = null;

        #region Caption
        string _Caption = "Delete item for User";
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
        protected IAspnetuserView _FormControlModel = null;
        public IAspnetuserView FormControlModel
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
                prms.Add("pkpId", modelToReturn.Id);
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
            if ((modeToCheck == EformModeEnum.DeleteMode) && ((GlblSettingsSrv.GetViewModelMask("aspnetuserView") & 2) != 2 )) {
                throw new Exception("Access denied to delete aspnetuserView");
            } else if ((modeToCheck == EformModeEnum.UpdateMode) && ((GlblSettingsSrv.GetViewModelMask("aspnetuserView") & 4) != 4 )) {
                throw new Exception("Access denied to update aspnetuserView");
            } else if ((modeToCheck == EformModeEnum.AddMode) && ((GlblSettingsSrv.GetViewModelMask("aspnetuserView") & 8) != 8 )) {
                throw new Exception("Access denied to add aspnetuserView");
            }
            ObservableCollection<IWebServiceFilterRsltInterface> hf = new ObservableCollection<IWebServiceFilterRsltInterface>();
          
            if(prms.ContainsKey("Id")) {
                    hf.Add(new WebServiceFilterRsltViewModel() {
                        fltrName = "Id",
                        fltrDataType = "string",
                        fltrOperator = "eq",
                        fltrValue = prms.GetValue<System.String>("Id"),
                        fltrError = null
                    });
            }
          
            if(prms.ContainsKey("Email")) {
                    hf.Add(new WebServiceFilterRsltViewModel() {
                        fltrName = "Email",
                        fltrDataType = "string",
                        fltrOperator = "eq",
                        fltrValue = prms.GetValue<System.String>("Email"),
                        fltrError = null
                    });
            }
          
            if(prms.ContainsKey("EmailConfirmed")) {
                    hf.Add(new WebServiceFilterRsltViewModel() {
                        fltrName = "EmailConfirmed",
                        fltrDataType = "boolean",
                        fltrOperator = "eq",
                        fltrValue = prms.GetValue<System.Boolean>("EmailConfirmed"),
                        fltrError = null
                    });
            }
          
            if(prms.ContainsKey("PhoneNumber")) {
                    hf.Add(new WebServiceFilterRsltViewModel() {
                        fltrName = "PhoneNumber",
                        fltrDataType = "string",
                        fltrOperator = "eq",
                        fltrValue = prms.GetValue<System.String>("PhoneNumber"),
                        fltrError = null
                    });
            }
          
            if(prms.ContainsKey("PhoneNumberConfirmed")) {
                    hf.Add(new WebServiceFilterRsltViewModel() {
                        fltrName = "PhoneNumberConfirmed",
                        fltrDataType = "boolean",
                        fltrOperator = "eq",
                        fltrValue = prms.GetValue<System.Boolean>("PhoneNumberConfirmed"),
                        fltrError = null
                    });
            }
          
            if(prms.ContainsKey("TwoFactorEnabled")) {
                    hf.Add(new WebServiceFilterRsltViewModel() {
                        fltrName = "TwoFactorEnabled",
                        fltrDataType = "boolean",
                        fltrOperator = "eq",
                        fltrValue = prms.GetValue<System.Boolean>("TwoFactorEnabled"),
                        fltrError = null
                    });
            }
          
            if(prms.ContainsKey("LockoutEnd")) {
                    hf.Add(new WebServiceFilterRsltViewModel() {
                        fltrName = "LockoutEnd",
                        fltrDataType = "datetimeoffset",
                        fltrOperator = "eq",
                        fltrValue = prms.GetValue<System.DateTimeOffset ?>("LockoutEnd"),
                        fltrError = null
                    });
            }
          
            if(prms.ContainsKey("LockoutEnabled")) {
                    hf.Add(new WebServiceFilterRsltViewModel() {
                        fltrName = "LockoutEnabled",
                        fltrDataType = "boolean",
                        fltrOperator = "eq",
                        fltrValue = prms.GetValue<System.Boolean>("LockoutEnabled"),
                        fltrError = null
                    });
            }
          
            if(prms.ContainsKey("AccessFailedCount")) {
                    hf.Add(new WebServiceFilterRsltViewModel() {
                        fltrName = "AccessFailedCount",
                        fltrDataType = "int32",
                        fltrOperator = "eq",
                        fltrValue = prms.GetValue<System.Int32>("AccessFailedCount"),
                        fltrError = null
                    });
            }
          
            if(prms.ContainsKey("UserName")) {
                    hf.Add(new WebServiceFilterRsltViewModel() {
                        fltrName = "UserName",
                        fltrDataType = "string",
                        fltrOperator = "eq",
                        fltrValue = prms.GetValue<System.String>("UserName"),
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
                EformModeEnum locmode = EformModeEnum.UpdateMode;
                string locCaption = "Update item for User";
                    System.String pkpId = default(System.String);
                    if(prms.ContainsKey("pkpId")) {
                        pkpId = prms.GetValue<System.String>("pkpId");
                    }
                // IAspnetuserView data
                _ = FrmSrvaspnetuserView.getone(
                    pkpId
                ).ContinueWith((data) => {
                        MainThread.InvokeOnMainThreadAsync(() =>
                        {
                            Caption = locCaption;
                            if (resetHF) { HiddenFilters = hf; }
                            EformMode = locmode;
                            FormControlModel = FrmSrvaspnetuserView.CopyToModelNotify(data.Result, null);
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
            modelToReturn = param as IAspnetuserView;
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




