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

using CommonInterfacesClassLibrary.Interfaces;
using CommonUserControlLibrary.ViewModels;
using CommonInterfacesClassLibrary.AppGlblSettingsSrvc;
using CommonInterfacesClassLibrary.Enums;
using ModelInterfacesClassLibrary.interfaces.asp.aspnetmodelView;
/*


    "AspnetmodelViewRdlistPage" UserControl is defined in the "ModelServicesPrismModule"-project.
    In the file of IModule-class of "ModelServicesPrismModule"-project the following line of code must be inserted:

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ...
            // According to requirements of the "AspnetmodelViewRdlistPageViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            ViewModelLocationProvider.Register<AspnetmodelViewRdlistPage, AspnetmodelViewRdlistPageViewModel>();
            // According to requirements of the "AspnetmodelViewRdlistPageViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            containerRegistry.RegisterForNavigation<AspnetmodelViewRdlistPage, AspnetmodelViewRdlistPageViewModel>("AspnetmodelViewRdlistPage");
            // Only if you need to get an instance of controls, insert two lines below
            // According to requirements of the "AspnetmodelViewRdlistPageViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            // containerRegistry.Register<ContentPage, AspnetmodelViewRdlistPage>("AspnetmodelViewRdlistPage");
            ...
        }
*/

namespace ModelServicesPrismModule.asp.aspnetmodelView.ViewModels.RldPage {

    public class AspnetmodelViewRdlistPageViewModel: INotifyPropertyChanged, INavigationAware, IDestructible  
    {
        protected IAppGlblSettingsService GlblSettingsSrv=null;
        protected IAspnetmodelViewService FrmSrvaspnetmodelView = null;
        protected INavigationService _navigationService;
        protected IRegionManager regionManager;
        public AspnetmodelViewRdlistPageViewModel(IRegionManager _regionManager, IAspnetmodelViewService _FrmSrvaspnetmodelView, 
            IAppGlblSettingsService GlblSettingsSrv, INavigationService navigationService) {
            this.GlblSettingsSrv = GlblSettingsSrv;
            this.FrmSrvaspnetmodelView = _FrmSrvaspnetmodelView;
            this._navigationService = navigationService;
            PermissionMask = GlblSettingsSrv.GetViewModelMask("aspnetmodelView");
            _TableMenuItems = GetDefaultTableMenuItems();
            _RowMenuItems = GetDefaultRowMenuItems();
            this.regionManager = _regionManager;
            this._DetailsList = this.getDetailsList();
            this._SelectedDetailsListItem = this._DetailsList[0];
            _GridHeight = this.GlblSettingsSrv.DefaultGridHeight("02019-RdlistPage.xaml");
            _FilterHeight = this.GlblSettingsSrv.DefaultFilterHeight("02019-RdlistPage.xaml");
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
        string _Caption = "Models";
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
                new WebServiceFilterMenuViewModel() { Id = "RowMIAspnetrolemaskViewRdlistPageAspNetModel", Caption="Role Masks: AspNetModel", IconName="ArrowRightBold", IconColor=Color.Default, Enabled=true, Data=null, FeedbackData=null, Command = RowMenuItemsCommand},
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
            return new ObservableCollection<IWebServiceFilterMenuInterface>()  {};
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
        public async Task NavigateToDetailCommand(IAspnetmodelView selected, string detailVwNm, string fkNvNm, string detailVwClNm) { 
            if(IsDestroyed) return;
            if (((GlblSettingsSrv.GetViewModelMask(detailVwNm) & 1) != 1 )) {
                INavigationResult nr1 = await _navigationService.NavigateAsync("AccessDeniedPage");
                OnNavigationResult(nr1);
                return;
            }
            if(selected == null) return;
            NavigationParameters navigationParameters = new NavigationParameters();
            navigationParameters.Add("HiddenFilter", this.FrmSrvaspnetmodelView.getHiddenFilterByRow(selected, fkNvNm));  
            INavigationResult nr2 = await _navigationService.NavigateAsync(detailVwClNm, navigationParameters);
            OnNavigationResult(nr2);
        }
        #endregion

        #region CanAdd
        protected bool _CanAdd = false;
        public bool CanAdd
        { 
            get
            {
                return _CanAdd;
            }
            set
            {
                if (_CanAdd != value)
                {
                    _CanAdd = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion
        #region CanUpdate
        protected bool _CanUpdate = false;
        public bool CanUpdate
        { 
            get
            {
                return _CanUpdate;
            }
            set
            {
                if (_CanUpdate != value)
                {
                    _CanUpdate = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion
        #region CanDelete
        protected object _CanDelete = false;
        public object CanDelete
        { 
            get
            {
                return _CanDelete;
            }
            set
            {
                if (_CanDelete != value)
                {
                    _CanDelete = value;
                    OnPropertyChanged();
                }
            }
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
        protected void TableMenuItemsCommandExecute(object prm)
        {
        }
        protected bool TableMenuItemsCommandCanExecute(object prm)
        {
            return true; 
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
            IAspnetmodelView arow = mi.FeedbackData as IAspnetmodelView;
            if (arow == null) return;
            switch(mi.Id) {
                    case "RowMIAspnetrolemaskViewRdlistPageAspNetModel":
                        await NavigateToDetailCommand(arow, "aspnetrolemaskView", "AspNetModel", "AspnetrolemaskViewRdlistPage");
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
                    case "RowMIAspnetrolemaskViewRdlistPageAspNetModel":
                        return ((GlblSettingsSrv.GetViewModelMask("aspnetrolemaskView") & 1) == 1);
                    default:
                        break;
                }
            }
            return false; 
        }
        #endregion

        #region SelectedRow
        protected object _SelectedRow = null;
        public object SelectedRow {
            get {
                return _SelectedRow;
            }
            set {
                if(_SelectedRow != value) {
                    _SelectedRow = value;
                    OnPropertyChanged();
                    OnPropertyChanged("IsDetailVisible");
                }
            }
        }
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
           SelectedRow = prm;
           NavigateToO2m();
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
            PermissionMask = GlblSettingsSrv.GetViewModelMask("aspnetmodelView");
            if ((PermissionMask & 1) != 1) {
                throw new Exception("Access Denied to navigate aspnetmodelView");
            }
            CanAdd = (PermissionMask & 8) == 8; 
            CanUpdate = (PermissionMask & 4) == 4; 
            CanDelete = (PermissionMask & 2) == 2; 

            if(!IsParentLoaded) {
                ObservableCollection<IWebServiceFilterRsltInterface> hf = new ObservableCollection<IWebServiceFilterRsltInterface>();
          
                if(prms.ContainsKey("HiddenFilter")) {
                    IList<IWebServiceFilterRsltInterface> hflts = 
                        FrmSrvaspnetmodelView.getHiddenFilterAsFltRslt(
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
            IsParentLoaded = true;
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
            _GridHeight = -1d;
            _FilterHeight = -1d;
        }
        #endregion

        #region IsDetailVisible
        public bool IsDetailVisible {
            get {
                if ((SelectedRow is null) || (SelectedDetailsListItem is null)) return false;
                return (!string.IsNullOrEmpty(SelectedDetailsListItem.ForeignKeyDetails));
            }
        }
        #endregion

        #region SelectedDetailsListItem
        protected IO2mListItemInterface _SelectedDetailsListItem = null;
        public IO2mListItemInterface SelectedDetailsListItem 
        {
            get { return _SelectedDetailsListItem; }
            set {
                if(_SelectedDetailsListItem != value) {
                    _SelectedDetailsListItem = value;
                    OnPropertyChanged();
                    OnPropertyChanged("IsDetailVisible");
                    NavigateToO2m();
                }
            }
        }
        #endregion

        #region DetailsList
        ObservableCollection<IO2mListItemInterface> _DetailsList;
        public IEnumerable<IO2mListItemInterface> DetailsList { get { return _DetailsList; } }
        ObservableCollection<IO2mListItemInterface> getDetailsList() {
            ObservableCollection<IO2mListItemInterface> rslt = new ObservableCollection<IO2mListItemInterface>() {
                    new O2mListItemViewModel() {Caption = "Hide Details", ForeignKeyDetails = "",  Region = "" }
                };
                if((GlblSettingsSrv.GetViewModelMask("aspnetrolemaskView") & 1) == 1)
                    rslt.Add(new O2mListItemViewModel() {Caption = "Role Masks: AspNetModel", ForeignKeyDetails = "AspNetModel",  Region = "AspnetrolemaskViewRdlistUserControl" });
            return rslt;
        }
        #endregion

        #region NavigateToO2m
        public void NavigateToO2m() {
            if (IsDestroyed || (SelectedDetailsListItem is null) || (SelectedRow is null)) return;
            if (string.IsNullOrEmpty(SelectedDetailsListItem.ForeignKeyDetails)) return;
            var rgn = regionManager.Regions["AspnetmodelViewRdlistPageDetailRegion"];
            if(rgn != null) {
                foreach (var vw in rgn.Views)
                {
                    if(vw.BindingContext != null)
                    {
                        var prop = vw.BindingContext.GetType().GetProperty("IsParentLoaded");
                        if(prop != null)
                            prop.SetValue(vw.BindingContext, false);
                    }
                }
                rgn.NavigationService.Journal.Clear();
            }
            INavigationParameters navigationParameters = new NavigationParameters();
            navigationParameters.Add("HiddenFilter", this.FrmSrvaspnetmodelView.getHiddenFilterByRow(SelectedRow as IAspnetmodelView, SelectedDetailsListItem.ForeignKeyDetails));  
            regionManager.RequestNavigate("AspnetmodelViewRdlistPageDetailRegion", SelectedDetailsListItem.Region, OnRegionNavigationResult, navigationParameters);
        }
        #endregion

        #region OnRegionNavigationResult
        protected void OnRegionNavigationResult(IRegionNavigationResult navResult) {
                if(IsDestroyed) return;
                if(navResult.Result.HasValue) { if(navResult.Result.Value) return; }
                string navErrorMsg = "Unknown Navigation Error";
                if (navResult.Error != null)
                {
                    navErrorMsg = navResult.Error.Message;
                    Exception inner = navResult.Error.InnerException;
                    while (inner != null)
                    {
                        navErrorMsg = navErrorMsg + ": " + inner.Message;
                        inner = inner.InnerException;
                    }
                }
                GlblSettingsSrv.ShowErrorMessage("Navigation Exception", navErrorMsg);
        }
        #endregion


    }
}




