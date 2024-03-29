using System;
using Xamarin.Forms;
using System.Linq;
using System.ComponentModel;
using Prism.Regions;
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
using ModelInterfacesClassLibrary.interfaces.asp.aspnetuserrolesView;
/*


    "AspnetuserrolesViewRlistPage" UserControl is defined in the "ModelServicesPrismModule"-project.
    In the file of IModule-class of "ModelServicesPrismModule"-project the following line of code must be inserted:

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ...
            // According to requirements of the "AspnetuserrolesViewRlistPageViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            ViewModelLocationProvider.Register<AspnetuserrolesViewRlistPage, AspnetuserrolesViewRlistPageViewModel>();
            // According to requirements of the "AspnetuserrolesViewRlistPageViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            containerRegistry.RegisterForNavigation<AspnetuserrolesViewRlistPage, AspnetuserrolesViewRlistPageViewModel>("AspnetuserrolesViewRlistPage");
            // Only if you need to get an instance of controls, insert two lines below
            // According to requirements of the "AspnetuserrolesViewRlistPageViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            // containerRegistry.Register<ContentPage, AspnetuserrolesViewRlistPage>("AspnetuserrolesViewRlistPage");
            ...
        }
*/

namespace ModelServicesPrismModule.asp.aspnetuserrolesView.ViewModels.RlPage {

    public class AspnetuserrolesViewRlistPageViewModel: INotifyPropertyChanged, INavigationAware, IDestructible 
    {
        protected IAppGlblSettingsService GlblSettingsSrv=null;
        protected IAspnetuserrolesViewService FrmSrvaspnetuserrolesView = null;
        protected INavigationService _navigationService;
        public AspnetuserrolesViewRlistPageViewModel(IAspnetuserrolesViewService _FrmSrvaspnetuserrolesView, 
            IAppGlblSettingsService GlblSettingsSrv, INavigationService navigationService) {
            this.GlblSettingsSrv = GlblSettingsSrv;
            this.FrmSrvaspnetuserrolesView = _FrmSrvaspnetuserrolesView;
            this._navigationService = navigationService;
            PermissionMask = GlblSettingsSrv.GetViewModelMask("aspnetuserrolesView");
            _TableMenuItems = GetDefaultTableMenuItems();
            _RowMenuItems = GetDefaultRowMenuItems();
            _GridHeight = this.GlblSettingsSrv.ExpandedGridHeight("01919-RlistPage.xaml");
            _FilterHeight = this.GlblSettingsSrv.ExpandedFilterHeight("01919-RlistPage.xaml");
        }
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        protected int PermissionMask = 0; 



        #region Caption
        string _Caption = "User Roles";
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
        #region GridHeight
        protected double _GridHeight = -1d;
        public double GridHeight
        { 
            get
            {
                return _GridHeight;
            }
            set
            {
                if (_GridHeight != value)
                {
                    _GridHeight = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion
        #region FilterHeight
        protected double _FilterHeight = -1d;
        public double FilterHeight
        { 
            get
            {
                return _FilterHeight;
            }
            set
            {
                if (_FilterHeight != value)
                {
                    _FilterHeight = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion
        #region RowMenuItems
        protected ObservableCollection<IWebServiceFilterMenuInterface> GetDefaultRowMenuItems() {
            return new ObservableCollection<IWebServiceFilterMenuInterface>()  {
                new WebServiceFilterMenuViewModel() { Id = "RowUpdMI", Caption="Update item", IconName="TableEdit", IconColor=Color.Default, Enabled=true, Data=null, Command = RowMenuItemsCommand},
                new WebServiceFilterMenuViewModel() { Id = "RowDelMI", Caption="Delete item", IconName="TableRemove", IconColor=Color.Default, Enabled=true, Data=null, Command = RowMenuItemsCommand},
                new WebServiceFilterMenuViewModel() { Id = "RowViewMI", Caption="View item", IconName="TableEdit", IconColor=Color.Default, Enabled=true, Data=null, Command = RowMenuItemsCommand},
            };
        }
        protected IEnumerable<IWebServiceFilterMenuInterface> _RowMenuItems = null;
        public IEnumerable<IWebServiceFilterMenuInterface> RowMenuItems
        { 
            get
            {
                return _RowMenuItems;
            }
            set
            {
                if (_RowMenuItems != value)
                {
                    _RowMenuItems = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion
        #region TableMenuItems
        protected ObservableCollection<IWebServiceFilterMenuInterface> GetDefaultTableMenuItems() {
            return new ObservableCollection<IWebServiceFilterMenuInterface>()  {
                new WebServiceFilterMenuViewModel() { Id = "TableAddMI", Caption="Add Item", IconName="TablePlus", IconColor=Color.Default, Enabled=true, Data=null, Command = TableMenuItemsCommand},
            };
        }
        protected IEnumerable<IWebServiceFilterMenuInterface> _TableMenuItems = null;
        public IEnumerable<IWebServiceFilterMenuInterface> TableMenuItems
        { 
            get
            {
                return _TableMenuItems;
            }
            set
            {
                if (_TableMenuItems != value)
                {
                    _TableMenuItems = value;
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

        protected void OnNavigationResult(INavigationResult navResult) {
            if(IsDestroyed) return;
            if (navResult.Success) return;
            string navErrorMsg = "Unknown Navigation Error";
            if (navResult.Exception != null)
            {
                navErrorMsg = navResult.Exception.Message;
                Exception inner = navResult.Exception.InnerException;
                while (inner != null)
                {
                    navErrorMsg = navErrorMsg + ": " + inner.Message;
                    inner = inner.InnerException;
                }
            }
            // await _navigationService.NavigateAsync("PageNotFoundPage");
            GlblSettingsSrv.NavigateTo("PageNotFoundPage");
            GlblSettingsSrv.ShowErrorMessage("Navigation Exception", navErrorMsg);
        }

        #region NavigateToDetailCommand
        public async Task NavigateToDetailCommand(IAspnetuserrolesView selected, string detailVwNm, string fkNvNm, string detailVwClNm) { 
            if(IsDestroyed) return;
            if (((GlblSettingsSrv.GetViewModelMask(detailVwNm) & 1) != 1 )) {
                INavigationResult nr1 = await _navigationService.NavigateAsync("AccessDeniedPage");
                OnNavigationResult(nr1);
                return;
            }
            if(selected == null) return;
            NavigationParameters navigationParameters = new NavigationParameters();
            navigationParameters.Add("HiddenFilter", this.FrmSrvaspnetuserrolesView.getHiddenFilterByRow(selected, fkNvNm));  
            INavigationResult nr2 = await _navigationService.NavigateAsync(detailVwClNm, navigationParameters);
            OnNavigationResult(nr2);
        }
        #endregion

        #region SformAfterAddItem
        protected object _SformAfterAddItem = null;
        public object SformAfterAddItem
        { 
            get
            {
                return _SformAfterAddItem;
            }
            set
            {
                if (_SformAfterAddItem != value)
                {
                    _SformAfterAddItem = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion
        #region SformAfterUpdItem
        protected object _SformAfterUpdItem = null;
        public object SformAfterUpdItem
        { 
            get
            {
                return _SformAfterUpdItem;
            }
            set
            {
                if (_SformAfterUpdItem != value)
                {
                    _SformAfterUpdItem = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion
        #region SformAfterDelItem
        protected object _SformAfterDelItem = null;
        public object SformAfterDelItem
        { 
            get
            {
                return _SformAfterDelItem;
            }
            set
            {
                if (_SformAfterDelItem != value)
                {
                    _SformAfterDelItem = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion
        #region SformAddItemCommand
        public async Task SformAddItemCommand() {
            if(IsDestroyed) return;
            if ((PermissionMask & 8) != 8) {
                INavigationResult nr1 = await _navigationService.NavigateAsync("AccessDeniedPage");
                OnNavigationResult(nr1);
                return;
            }

            NavigationParameters navigationParameters = new NavigationParameters();
            foreach(IWebServiceFilterRsltInterface hf in HiddenFilters) {
                navigationParameters.Add(hf.fltrName, hf.fltrValue);
            }
            navigationParameters.Add("EformModeEnum", EformModeEnum.AddMode);
            INavigationResult nr2 = await _navigationService.NavigateAsync("AspnetuserrolesViewRaddPage", navigationParameters);
            OnNavigationResult(nr2);
        }
        #endregion
        #region TableMenuItemsCommand
        protected ICommand _TableMenuItemsCommand = null;
        public ICommand TableMenuItemsCommand
        {
            get
            {
                return _TableMenuItemsCommand ?? (_TableMenuItemsCommand = new Command((p) => TableMenuItemsCommandExecute(p), (p) => TableMenuItemsCommandCanExecute(p)));
            }
        }
        protected async void TableMenuItemsCommandExecute(object prm)
        {
            if(IsDestroyed) return;
            if(prm == null) return;
            IWebServiceFilterMenuInterface mi = prm as IWebServiceFilterMenuInterface;
            if (mi == null) return;
            if(mi.Id == "TableAddMI") {
                await SformAddItemCommand();
            }
        }
        protected bool TableMenuItemsCommandCanExecute(object prm)
        {
            IWebServiceFilterMenuInterface mi = prm as IWebServiceFilterMenuInterface;
            if (mi != null) {
                if(mi.Id == "TableAddMI") {
                    return ((PermissionMask & 8) == 8);
                }
            }
            return false; 
        }
        #endregion

        #region SformUpdItemCommand
        public async Task SformUpdItemCommand(IAspnetuserrolesView selected) {
            if(IsDestroyed) return;
            if (selected == null) return;
            if ((PermissionMask & 4) != 4) {
                INavigationResult nr1 = await _navigationService.NavigateAsync("AccessDeniedPage");
                OnNavigationResult(nr1);
                return;
            }

            NavigationParameters navigationParameters = new NavigationParameters();
            foreach(IWebServiceFilterRsltInterface hf in HiddenFilters) {
                navigationParameters.Add(hf.fltrName, hf.fltrValue);
            }
            navigationParameters.Add("EformModeEnum", EformModeEnum.UpdateMode);
            navigationParameters.Add("pkpUserId", selected.UserId);
            navigationParameters.Add("pkpRoleId", selected.RoleId);
            INavigationResult nr2 = await _navigationService.NavigateAsync("AspnetuserrolesViewRupdPage", navigationParameters);
            OnNavigationResult(nr2);
        }
        #endregion

        #region SformDelItemCommand
        public async Task SformDelItemCommand(IAspnetuserrolesView selected) {
            if(IsDestroyed) return;
            if (selected == null) return;
            if((PermissionMask & 2) != 2) {
                INavigationResult nr1 = await _navigationService.NavigateAsync("AccessDeniedPage");
                OnNavigationResult(nr1);
                return;
            }

            NavigationParameters navigationParameters = new NavigationParameters();
            foreach(IWebServiceFilterRsltInterface hf in HiddenFilters) {
                navigationParameters.Add(hf.fltrName, hf.fltrValue);
            }
            navigationParameters.Add("EformModeEnum", EformModeEnum.DeleteMode);
            navigationParameters.Add("pkpUserId", selected.UserId);
            navigationParameters.Add("pkpRoleId", selected.RoleId);
            INavigationResult nr2 = await _navigationService.NavigateAsync("AspnetuserrolesViewRdelPage", navigationParameters);
            OnNavigationResult(nr2);
        }
        #endregion

        #region SformViewItemCommand
        public async Task SformViewItemCommand(IAspnetuserrolesView selected) {
            if (IsDestroyed) return;
            if (selected == null) return;
            NavigationParameters navigationParameters = new NavigationParameters();
            foreach(IWebServiceFilterRsltInterface hf in HiddenFilters) {
                navigationParameters.Add(hf.fltrName, hf.fltrValue);
            }
            navigationParameters.Add("EformModeEnum", EformModeEnum.ViewMode);
            navigationParameters.Add("pkpUserId", selected.UserId);
            navigationParameters.Add("pkpRoleId", selected.RoleId);
            INavigationResult nr2 = await _navigationService.NavigateAsync("AspnetuserrolesViewRviewPage", navigationParameters);
            OnNavigationResult(nr2);
        }
        #endregion

        #region RowMenuItemsCommand
        protected ICommand _RowMenuItemsCommand = null;
        public ICommand RowMenuItemsCommand
        {
            get
            {
                return _RowMenuItemsCommand ?? (_RowMenuItemsCommand = new Command((p) => RowMenuItemsCommandExecute(p), (p) => RowMenuItemsCommandCanExecute(p)));
            }
        }
        protected async void RowMenuItemsCommandExecute(object prm)
        {
            if(IsDestroyed) return;
            IWebServiceFilterMenuInterface mi = prm as IWebServiceFilterMenuInterface;
            if (mi == null) return;
            IAspnetuserrolesView arow = mi.FeedbackData as IAspnetuserrolesView;
            if (arow == null) return;
            switch(mi.Id) {
                case "RowUpdMI":
                    await SformUpdItemCommand(arow);
                    break;
                case "RowDelMI":
                    await SformDelItemCommand(arow);
                    break;
                case "RowViewMI":
                    await SformViewItemCommand(arow);
                    break;
                default:
                    break;
            }         
        }
        protected bool RowMenuItemsCommandCanExecute(object prm)
        {
            if(IsDestroyed) return false;
            IWebServiceFilterMenuInterface mi = prm as IWebServiceFilterMenuInterface;
            if (mi != null) {
                switch(mi.Id) {
                    case "RowUpdMI":
                        return ((PermissionMask & 4) == 4);
                    case "RowDelMI":
                        return ((PermissionMask & 2) == 2);
                    case "RowViewMI":
                        return true;
                    default:
                        break;
                }
            }
            return false; 
        }
        #endregion

        #region SelectedRow
        #endregion

       #region SelectedRowCommand
       protected ICommand _SelectedRowCommand = null;
       public ICommand SelectedRowCommand
       {
           get
           {
               return _SelectedRowCommand ?? (_SelectedRowCommand = new Command((p) => SelectedRowCommandExecute(p), (p) => SelectedRowCommandCanExecute(p)));
           }
       }
       protected void SelectedRowCommandExecute(object prm)
       {
       }
       protected bool SelectedRowCommandCanExecute(object prm)
       {
           return true; 
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
       public bool IsNavigationTarget(INavigationParameters prms) {
            return true;
       }
       public void OnNavigatedFrom(INavigationParameters prms) {
            
       }
       public void OnNavigatedTo(INavigationParameters prms) {
            if(IsDestroyed) return;
            PermissionMask = GlblSettingsSrv.GetViewModelMask("aspnetuserrolesView");
            if ((PermissionMask & 1) != 1) {
                throw new Exception("Access Denied to navigate aspnetuserrolesView");
            }
            SformAfterAddItem = null; 
            SformAfterUpdItem = null; 
            SformAfterDelItem = null; 
            if(!IsParentLoaded) {
                ObservableCollection<IWebServiceFilterRsltInterface> hf = new ObservableCollection<IWebServiceFilterRsltInterface>();
          
                if(prms.ContainsKey("HiddenFilter")) {
                    IList<IWebServiceFilterRsltInterface> hflts = 
                        FrmSrvaspnetuserrolesView.getHiddenFilterAsFltRslt(
                            prms.GetValue<Dictionary<(string viewNm, string navNm, string propNm), object>>("HiddenFilter")
                        );
                    foreach(var hflt in hflts) {
                        hf.Add(hflt);
                    }
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
                if (resetHF) { HiddenFilters = hf; }
            }
          
            if (prms.ContainsKey("EformModeEnum")) {
                EformModeEnum mode = prms.GetValue<EformModeEnum>("EformModeEnum");
                System.String pkpUserId = default(System.String);
                if(prms.ContainsKey("pkpUserId")) {
                    pkpUserId = prms.GetValue<System.String>("pkpUserId");
                }
                System.String pkpRoleId = default(System.String);
                if(prms.ContainsKey("pkpRoleId")) {
                    pkpRoleId = prms.GetValue<System.String>("pkpRoleId");
                }
                if ((mode == EformModeEnum.AddMode) || (mode == EformModeEnum.UpdateMode)) {
          
                    // IAspnetuserrolesView tdata 
                    _ = FrmSrvaspnetuserrolesView.getone(
                            pkpUserId
                          , pkpRoleId
                        ).ContinueWith((tdata) => {MainThread.InvokeOnMainThreadAsync(() =>{
                            if (tdata.Status == TaskStatus.RanToCompletion) {
                                if (mode == EformModeEnum.AddMode) {
                                    SformAfterAddItem = tdata.Result; 
                                } else {
                                    SformAfterUpdItem = tdata.Result; 
                                }
                            } else {
                                if (mode == EformModeEnum.AddMode) {
                                    SformAfterAddItem = null; 
                                } else {
                                    SformAfterUpdItem = null; 
                                }
                            }
                            IsParentLoaded = true;
                        });
                    });
          
                } else {
                    IAspnetuserrolesView data = FrmSrvaspnetuserrolesView.CopyToModel(null,null);
                    data.UserId = pkpUserId;
                    data.RoleId = pkpRoleId;
                    SformAfterDelItem = data;
                    IsParentLoaded = true;
                }
            } else {
                IsParentLoaded = true;
            }
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
            _TableMenuItems = null;
            _RowMenuItems = null;
            _GridHeight = -1;
            _FilterHeight = -1;
            _SformAfterAddItem = null;
            _SformAfterUpdItem = null;
            _SformAfterDelItem = null;
        }
        #endregion



    }
}




