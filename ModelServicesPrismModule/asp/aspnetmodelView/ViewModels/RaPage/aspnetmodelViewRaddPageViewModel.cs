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
using ModelInterfacesClassLibrary.interfaces.asp.aspnetmodelView;
/*



    "AspnetmodelViewRaddPage" UserControl is defined in the "ModelServicesPrismModule"-project.
    In the file of IModule-class of "ModelServicesPrismModule"-project the following line of code must be inserted:

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ...
            // According to requirements of the "AspnetmodelViewRaddPageViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            ViewModelLocationProvider.Register<AspnetmodelViewRaddPage, AspnetmodelViewRaddPageViewModel>();
            // According to requirements of the "AspnetmodelViewRaddPageViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            containerRegistry.RegisterForNavigation<AspnetmodelViewRaddPage, AspnetmodelViewRaddPageViewModel>("AspnetmodelViewRaddPage");
            // Only if you need to get an instance of controls, insert two lines below
            // According to requirements of the "AspnetmodelViewRaddPageViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            // containerRegistry.Register<ContentPage, AspnetmodelViewRaddPage>("AspnetmodelViewRaddPage");
            ...
        }
*/

namespace ModelServicesPrismModule.asp.aspnetmodelView.ViewModels.RaPage {
    public class AspnetmodelViewRaddPageViewModel: INotifyPropertyChanged, INavigationAware, IDestructible  
    {
        protected IAppGlblSettingsService GlblSettingsSrv=null;
        protected IAspnetmodelViewService FrmSrvaspnetmodelView = null;
        protected INavigationService _navigationService = null;

        public AspnetmodelViewRaddPageViewModel(IAspnetmodelViewService _FrmSrvaspnetmodelView, IAppGlblSettingsService GlblSettingsSrv, INavigationService navigationService) {
            this.GlblSettingsSrv = GlblSettingsSrv;
            this.FrmSrvaspnetmodelView = _FrmSrvaspnetmodelView;
            this._navigationService = navigationService;

            PermissionMask = GlblSettingsSrv.GetViewModelMask("aspnetmodelView");
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
        protected IAspnetmodelView modelToReturn = null;

        #region Caption
        string _Caption = "Delete item for Model";
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
        protected IAspnetmodelView _FormControlModel = null;
        public IAspnetmodelView FormControlModel
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
                prms.Add("pkpModelPk", modelToReturn.ModelPk);
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
            if ((modeToCheck == EformModeEnum.DeleteMode) && ((GlblSettingsSrv.GetViewModelMask("aspnetmodelView") & 2) != 2 )) {
                throw new Exception("Access denied to delete aspnetmodelView");
            } else if ((modeToCheck == EformModeEnum.UpdateMode) && ((GlblSettingsSrv.GetViewModelMask("aspnetmodelView") & 4) != 4 )) {
                throw new Exception("Access denied to update aspnetmodelView");
            } else if ((modeToCheck == EformModeEnum.AddMode) && ((GlblSettingsSrv.GetViewModelMask("aspnetmodelView") & 8) != 8 )) {
                throw new Exception("Access denied to add aspnetmodelView");
            }
            ObservableCollection<IWebServiceFilterRsltInterface> hf = new ObservableCollection<IWebServiceFilterRsltInterface>();
          
            if(prms.ContainsKey("ModelPk")) {
                    hf.Add(new WebServiceFilterRsltViewModel() {
                        fltrName = "ModelPk",
                        fltrDataType = "int32",
                        fltrOperator = "eq",
                        fltrValue = prms.GetValue<System.Int32>("ModelPk"),
                        fltrError = null
                    });
            }
          
            if(prms.ContainsKey("ModelName")) {
                    hf.Add(new WebServiceFilterRsltViewModel() {
                        fltrName = "ModelName",
                        fltrDataType = "string",
                        fltrOperator = "eq",
                        fltrValue = prms.GetValue<System.String>("ModelName"),
                        fltrError = null
                    });
            }
          
            if(prms.ContainsKey("ModelDescription")) {
                    hf.Add(new WebServiceFilterRsltViewModel() {
                        fltrName = "ModelDescription",
                        fltrDataType = "string",
                        fltrOperator = "eq",
                        fltrValue = prms.GetValue<System.String>("ModelDescription"),
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
                Caption = "Add item for Model";
                if (resetHF) { HiddenFilters = hf; }
                FormControlModel = FrmSrvaspnetmodelView.CopyToModelNotify(null,null); // this is correct: cleanup twice
                EformMode = EformModeEnum.AddMode;
                FormControlModel = null; // since DateTime-issue this is correct: FrmSrvaspnetmodelView.CopyToModelNotify(null,null);
                IsParentLoaded = true;
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
            modelToReturn = param as IAspnetmodelView;
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




