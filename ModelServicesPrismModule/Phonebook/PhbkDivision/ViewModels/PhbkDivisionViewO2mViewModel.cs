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

using CommonInterfacesClassLibrary.Interfaces;
using CommonUserControlLibrary.ViewModels;
using CommonInterfacesClassLibrary.AppGlblSettingsSrvc;
using CommonInterfacesClassLibrary.Enums;
using ModelInterfacesClassLibrary.Phonebook.PhbkDivision;
/*



    "PhbkDivisionViewO2mUserControl" UserControl is defined in the "ModelServicesPrismModule"-project.
    In the file of IModule-class of "ModelServicesPrismModule"-project the following line of code must be inserted:

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ...
            // According to requirements of the "PhbkDivisionViewO2mViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            ViewModelLocationProvider.Register<PhbkDivisionViewO2mUserControl, PhbkDivisionViewO2mViewModel>();
            // According to requirements of the "PhbkDivisionViewO2mViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            containerRegistry.RegisterForRegionNavigation<PhbkDivisionViewO2mUserControl, PhbkDivisionViewO2mViewModel>("PhbkDivisionViewO2mUserControl");
            // According to requirements of the "PhbkDivisionViewO2mViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            containerRegistry.Register<ContentView, PhbkDivisionViewO2mUserControl>("PhbkDivisionViewO2mUserControl");
            ...
        }
*/

namespace ModelServicesPrismModule.Phonebook.PhbkDivision.ViewModels {

    public class PhbkDivisionViewO2mViewModel: RegionAwareViewModelBase, IRegionAware 
    {
        protected IAppGlblSettingsService GlblSettingsSrv=null;
        protected IPhbkDivisionViewService FrmSrvPhbkDivisionView = null;
        public PhbkDivisionViewO2mViewModel(IPhbkDivisionViewService _FrmSrvPhbkDivisionView, IAppGlblSettingsService GlblSettingsSrv) {
            this.GlblSettingsSrv = GlblSettingsSrv;
            this.FrmSrvPhbkDivisionView = _FrmSrvPhbkDivisionView;
            PermissionMask = GlblSettingsSrv.GetViewModelMask("PhbkDivisionView");
            _TableMenuItems = GetDefaultTableMenuItems();
            _RowMenuItems = GetDefaultRowMenuItems();
            _TableMenuItemsDetail = GetDefaultTableMenuItemsDetail();
            _RowMenuItemsDetail = GetDefaultRowMenuItemsDetail();
        }

        protected int PermissionMask = 0; 

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
                return CanAddDetailParent && ((PermissionMaskDetail & 8) == 8);
            }
        }
        public bool CanUpdateDetail
        { 
            get
            {
                return CanUpdateDetailParent && ((PermissionMaskDetail & 4) == 4);
            }
        }
        public bool CanDeleteDetail
        { 
            get
            {
                return CanDeleteDetailParent && ((PermissionMaskDetail & 2) == 2);
            }
        }

        public bool IsSwitching
        {
            get { return !IsParentLoaded; }
        }

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

        #region Caption
        string _Caption = "Divisions";
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
        #region RowMenuItems
        protected ObservableCollection<IWebServiceFilterMenuInterface> GetDefaultRowMenuItems() {
            return new ObservableCollection<IWebServiceFilterMenuInterface>();
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
            return new ObservableCollection<IWebServiceFilterMenuInterface>();
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

        protected void OnNavigationResult(IRegionNavigationResult navResult) {
            if (navResult.Result.HasValue) {
                if (navResult.Result.Value) return;
            }
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
            navResult.Context.NavigationService.RequestNavigate(new Uri("PageNotFoundUserControl", UriKind.Relative));
            GlblSettingsSrv.ShowErrorMessage("Navigation Exception", navErrorMsg);
        }
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
        protected void RowMenuItemsCommandExecute(object prm)
        {
        }
        protected bool RowMenuItemsCommandCanExecute(object prm)
        {
            return true; 
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
                    DefineHiddenDetailFilter();
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
       }
       protected bool SelectedRowCommandCanExecute(object prm)
       {
           return true; 
       }
       #endregion

       #region IRegionAware
       public bool IsNavigationTarget(INavigationContext navigationContext) {
            return true;
       }
       public void OnNavigatedFrom(INavigationContext navigationContext) {
            CurrentNavigationContext = null;
       }
       public async void OnNavigatedTo(INavigationContext navigationContext) {
            if(IsDestroyed) return;
            INavigationParameters prms = navigationContext.Parameters;
            PermissionMask = GlblSettingsSrv.GetViewModelMask("PhbkDivisionView");
            if ((PermissionMask & 1) != 1) {
                if (navigationContext.NavigationService.Journal.CurrentEntry.Uri.OriginalString == "AccessDeniedUserControl")
                {
                    navigationContext.NavigationService.RequestNavigate(new Uri("AccessDeniedUserControl", UriKind.Relative), OnNavigationResult);
                    return;
                }
                else if(navigationContext.NavigationService.Journal.CanGoBack) {
                    // it should be intercepted by prev item in navigation chain
                    throw new Exception("Access Denied to navigate PhbkDivisionView");
                } else {
                    // this is a first item in navigation chain, so navigationContext.Parameters are not expected
                    navigationContext.NavigationService.RequestNavigate(new Uri("AccessDeniedUserControl", UriKind.Relative), OnNavigationResult);
                    return;
                }
            }
            CurrentNavigationContext = navigationContext;
            OnPropertyChanged("ShowBackBtn");
            (OnNavigationBackCommand as Command).ChangeCanExecute();
            OnPropertyChanged("CanAdd");
            OnPropertyChanged("CanUpdate");
            OnPropertyChanged("CanDelete");

            if(!IsParentLoaded) {
                ObservableCollection<IWebServiceFilterRsltInterface> hf = new ObservableCollection<IWebServiceFilterRsltInterface>();
          
                if(prms.ContainsKey("DivisionId")) {
                        hf.Add(new WebServiceFilterRsltViewModel() {
                            fltrName = "DivisionId",
                            fltrDataType = "int32",
                            fltrOperator = "eq",
                            fltrValue = prms.GetValue<System.Int32>("DivisionId"),
                            fltrError = null
                        });
                }
          
                if(prms.ContainsKey("DivisionName")) {
                        hf.Add(new WebServiceFilterRsltViewModel() {
                            fltrName = "DivisionName",
                            fltrDataType = "string",
                            fltrOperator = "eq",
                            fltrValue = prms.GetValue<System.String>("DivisionName"),
                            fltrError = null
                        });
                }
          
                if(prms.ContainsKey("DivisionDesc")) {
                        hf.Add(new WebServiceFilterRsltViewModel() {
                            fltrName = "DivisionDesc",
                            fltrDataType = "string",
                            fltrOperator = "eq",
                            fltrValue = prms.GetValue<System.String>("DivisionDesc"),
                            fltrError = null
                        });
                }
          
                if(prms.ContainsKey("EntrprsIdRef")) {
                        hf.Add(new WebServiceFilterRsltViewModel() {
                            fltrName = "EntrprsIdRef",
                            fltrDataType = "int32",
                            fltrOperator = "eq",
                            fltrValue = prms.GetValue<System.Int32>("EntrprsIdRef"),
                            fltrError = null
                        });
                }
          
                if(prms.ContainsKey("EEntrprsName")) {
                        hf.Add(new WebServiceFilterRsltViewModel() {
                            fltrName = "EEntrprsName",
                            fltrDataType = "string",
                            fltrOperator = "eq",
                            fltrValue = prms.GetValue<System.String>("EEntrprsName"),
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
                if (resetHF) { HiddenFilters = hf; }
            }
            IsParentLoaded = true;
            await Device.InvokeOnMainThreadAsync(async () =>
            {
                await Task.Delay(1);
                OnPropertyChanged("IsSwitching");
            });
        }
        #endregion
        #region ShowBackBtn
        public bool ShowBackBtn {
            get {
                return (CurrentNavigationContext == null) ?  false : CurrentNavigationContext.NavigationService.Journal.CanGoBack;
            }
        }
        #endregion
        #region OnNavigationBackCommand
        protected ICommand _OnNavigationBackCommand = null;
        public ICommand OnNavigationBackCommand
        {
            get
            {
                return _OnNavigationBackCommand ?? (_OnNavigationBackCommand = new Command(() => OnNavigationBackCommandExecute(), () => OnNavigationBackCommandCanExecute()));
            }
        }
        protected void OnNavigationBackCommandExecute()
        {
            if(IsDestroyed) return;
            if (CurrentNavigationContext != null) {
                if(CurrentNavigationContext.NavigationService.Journal.CanGoBack) {
                    CurrentNavigationContext.NavigationService.Journal.GoBack();
                }
            }
        }
        protected bool OnNavigationBackCommandCanExecute()
        {
            return (CurrentNavigationContext == null) ?  false : CurrentNavigationContext.NavigationService.Journal.CanGoBack;
        }
        #endregion

        #region TableMenuItemsDetail
        protected ObservableCollection<IWebServiceFilterMenuInterface> GetDefaultTableMenuItemsDetail() {
            return new ObservableCollection<IWebServiceFilterMenuInterface>();
        }
        protected IEnumerable<IWebServiceFilterMenuInterface> _TableMenuItemsDetail = null;
        public IEnumerable<IWebServiceFilterMenuInterface> TableMenuItemsDetail
        { 
            get
            {
                return _TableMenuItemsDetail;
            }
            set
            {
                if (_TableMenuItemsDetail != value)
                {
                    _TableMenuItemsDetail = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion
        #region RowMenuItemsDetail
        protected ObservableCollection<IWebServiceFilterMenuInterface> GetDefaultRowMenuItemsDetail() {
            return new ObservableCollection<IWebServiceFilterMenuInterface>();
        }
        protected IEnumerable<IWebServiceFilterMenuInterface> _RowMenuItemsDetail = null;
        public IEnumerable<IWebServiceFilterMenuInterface> RowMenuItemsDetail
        { 
            get
            {
                return _RowMenuItemsDetail;
            }
            set
            {
                if (_RowMenuItemsDetail != value)
                {
                    _RowMenuItemsDetail = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion
        #region TableMenuItemsCommandDetail
        protected ICommand _TableMenuItemsCommandDetail = null;
        public ICommand TableMenuItemsCommandDetail
        {
            get
            {
                return _TableMenuItemsCommandDetail ?? (_TableMenuItemsCommandDetail = new Command((p) => TableMenuItemsCommandDetailExecute(p), (p) => TableMenuItemsCommandDetailCanExecute(p)));
            }
        }
        protected async void TableMenuItemsCommandDetailExecute(object prm)
        {
        }
        protected bool TableMenuItemsCommandDetailCanExecute(object prm)
        {
            return true; 
        }
        #endregion
        #region RowMenuItemsCommandDetail
        protected ICommand _RowMenuItemsCommandDetail = null;
        public ICommand RowMenuItemsCommandDetail
        {
            get
            {
                return _RowMenuItemsCommandDetail ?? (_RowMenuItemsCommandDetail = new Command((p) => RowMenuItemsCommandDetailExecute(p), (p) => RowMenuItemsCommandDetailCanExecute(p)));
            }
        }
        protected void RowMenuItemsCommandDetailExecute(object prm)
        {
        }
        protected bool RowMenuItemsCommandDetailCanExecute(object prm)
        {
            return true; 
        }
        #endregion
        #region SelectedRowCommandDetail
        protected ICommand _SelectedRowCommandDetail = null;
        public ICommand SelectedRowCommandDetail
        {
            get
            {
                return _SelectedRowCommandDetail ?? (_SelectedRowCommandDetail = new Command((p) => SelectedRowCommandDetailExecute(p), (p) => SelectedRowCommandDetailCanExecute(p)));
            }
        }
        protected void SelectedRowCommandDetailExecute(object prm)
        {
            SelectedRowDetail = prm;
        }
        protected bool SelectedRowCommandDetailCanExecute(object prm)
        {
            return true; 
        }
        #endregion
        #region SelectedRowDetail
        protected object _SelectedRowDetail = null;
        public object SelectedRowDetail {
            get {
                return _SelectedRowDetail;
            }
            set {
                if(_SelectedRowDetail != value) {
                    _SelectedRowDetail = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion


        #region IsDetailReady
        protected int PermissionMaskDetail = 0; 
        public bool IsDetailReady
        { 
            get
            {
                 return HiddenFiltersDetail.Any() && (SelectedRow != null) && ((PermissionMaskDetail & 1) == 1);
            }
        }
        #endregion
        #region HiddenFiltersDetail
        IEnumerable<IWebServiceFilterRsltInterface> _HiddenFiltersDetail = new ObservableCollection<IWebServiceFilterRsltInterface>();
        public IEnumerable<IWebServiceFilterRsltInterface> HiddenFiltersDetail
        {
            get
            {
                return _HiddenFiltersDetail;
            }
            set
            {
                if (_HiddenFiltersDetail != value)
                {
                    _HiddenFiltersDetail = value;
                    OnPropertyChanged();
                    OnPropertyChanged("IsDetailDestroyed");
                    OnPropertyChanged("IsDetailReady");
                    OnPropertyChanged("CanDeleteDetail");
                    OnPropertyChanged("CanUpdateDetail");
                    OnPropertyChanged("CanAddDetail");
                }
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
                    IsDetailDestroyed = true;
                    IsDetailDestroyed = false;
                    _SelectedDetailsListItem = value;
                    OnPropertyChanged();
                    DefineHiddenDetailFilter();
                }
            }
        }
        #endregion
        #region DetailsList
        ObservableCollection<IO2mListItemInterface> _DetailsList = new ObservableCollection<IO2mListItemInterface>() {
                new O2mListItemViewModel() {Caption = "Employees: Division", ForeignKeyDetails = "PhbkEmployeeViewLformUserControl:Division",  Region = "PhbkEmployeeViewLformUserControlDetailRegion" },
        };
        public IEnumerable<IO2mListItemInterface> DetailsList { get { return _DetailsList; } }
        #endregion

        #region DefineHiddenDetailFilter
        protected void DefineHiddenDetailFilter() {
            if(IsDestroyed) return;
            PermissionMaskDetail = 0;
            ObservableCollection<IWebServiceFilterRsltInterface> chfd = new ObservableCollection<IWebServiceFilterRsltInterface>();
            IList<IWebServiceFilterRsltInterface> tmpFlt = null;
            IPhbkDivisionView  selectedMasterRow  = SelectedRow as IPhbkDivisionView;
            if((SelectedDetailsListItem != null) && (selectedMasterRow != null)) {
                switch(SelectedDetailsListItem.ForeignKeyDetails) {
                    case "PhbkEmployeeViewLformUserControl:Division":
                        PermissionMaskDetail = GlblSettingsSrv.GetViewModelMask("PhbkEmployeeView");
                        tmpFlt = this.FrmSrvPhbkDivisionView.getHiddenFilterAsFltRslt(this.FrmSrvPhbkDivisionView.getHiddenFilterByRow(selectedMasterRow, "Division"));
                        break;
                    default:
                        break;
                }
            }
            if(tmpFlt != null) {
                foreach(var fltItm in tmpFlt) {
                    chfd.Add(fltItm);
                }
            }
            HiddenFiltersDetail = chfd;
        }
        #endregion

        #region OnDestroy
        public override void OnDestroy() {
            base.OnDestroy();
            OnPropertyChanged("IsDetailDestroyed");
            _TableMenuItems = null;
            _RowMenuItems = null;
            _TableMenuItemsDetail = null;
            _RowMenuItemsDetail = null;
            _HiddenFiltersDetail = null;
            _SelectedRowDetail = null;
            _SelectedRow = null;
        }
        #endregion

        #region IsDetailDestroyed
        protected bool _IsDetailDestroyed = false;
        public bool IsDetailDestroyed {
            get {
                return _IsDetailDestroyed || IsDestroyed || (!IsDetailReady);
            }
            set {
                if(_IsDetailDestroyed != value) {
                    _IsDetailDestroyed = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

    }
}



