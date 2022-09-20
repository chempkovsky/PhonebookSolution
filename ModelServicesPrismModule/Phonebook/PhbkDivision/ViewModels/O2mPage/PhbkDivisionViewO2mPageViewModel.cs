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




    "PhbkDivisionViewO2mPage" UserControl is defined in the "ModelServicesPrismModule"-project.
    In the file of IModule-class of "ModelServicesPrismModule"-project the following line of code must be inserted:

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ...
            // According to requirements of the "PhbkDivisionViewO2mPageViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            ViewModelLocationProvider.Register<PhbkDivisionViewO2mPage, PhbkDivisionViewO2mPageViewModel>();
            // According to requirements of the "PhbkDivisionViewO2mPageViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            containerRegistry.RegisterForNavigation<PhbkDivisionViewO2mPage, PhbkDivisionViewO2mPageViewModel>("PhbkDivisionViewO2mPage");
            // Only if you need to get an instance of controls, insert two lines below
            // According to requirements of the "PhbkDivisionViewO2mPageViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            // containerRegistry.Register<ContentPage, PhbkDivisionViewO2mPage>("PhbkDivisionViewO2mPage");
            ...
        }
*/

using ModelInterfacesClassLibrary.Phonebook.PhbkEmployee;

namespace ModelServicesPrismModule.Phonebook.PhbkDivision.ViewModels.O2mPage {

    public class PhbkDivisionViewO2mPageViewModel: INotifyPropertyChanged, INavigationAware, IDestructible 
    {
        protected IAppGlblSettingsService GlblSettingsSrv=null;
        protected IPhbkDivisionViewService FrmRootSrvPhbkDivisionView = null;
        protected INavigationService _navigationService;
        protected IPhbkEmployeeViewService FrmSrvPhbkEmployeeView = null;
        public PhbkDivisionViewO2mPageViewModel(IPhbkDivisionViewService _FrmRootSrvPhbkDivisionView, 
            IPhbkEmployeeViewService _FrmSrvPhbkEmployeeView,
            IAppGlblSettingsService GlblSettingsSrv, INavigationService navigationService) {
            this.GlblSettingsSrv = GlblSettingsSrv;
            this.FrmRootSrvPhbkDivisionView = _FrmRootSrvPhbkDivisionView;
            this.FrmSrvPhbkEmployeeView = _FrmSrvPhbkEmployeeView;
            this._navigationService = navigationService;
            PermissionMask = GlblSettingsSrv.GetViewModelMask("PhbkDivisionView");
            _TableMenuItems = GetDefaultTableMenuItems();
            _RowMenuItems = GetDefaultRowMenuItems();
            _TableMenuItemsDetail = GetDefaultTableMenuItemsDetail();
            _RowMenuItemsDetail = GetDefaultRowMenuItemsDetail();
            _GridHeight = this.GlblSettingsSrv.ExpandedGridHeight("01699-O2mPage.xaml");
            _FilterHeight = this.GlblSettingsSrv.ExpandedFilterHeight("01699-O2mPage.xaml");
            _GridHeightDetail = this.GlblSettingsSrv.ExpandedGridHeight("01699-O2mPage.xaml");
            _FilterHeightDetail = this.GlblSettingsSrv.ExpandedFilterHeight("01699-O2mPage.xaml");  
        }
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        protected int PermissionMask = 0; 

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



       #region INavigationAware
       public bool IsNavigationTarget(INavigationParameters prms) {
            return true;
       }
       public void OnNavigatedFrom(INavigationParameters prms) {
            
       }
       public async void OnNavigatedTo(INavigationParameters prms) {
            if(IsDestroyed) return;
            PermissionMask = GlblSettingsSrv.GetViewModelMask("PhbkDivisionView");
            if ((PermissionMask & 1) != 1) {
                throw new Exception("Access Denied to navigate PhbkDivisionView");
            }
            CanAdd = (PermissionMask & 8) == 8; 
            CanUpdate = (PermissionMask & 4) == 4; 
            CanDelete = (PermissionMask & 2) == 2; 

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
            IsParentLoaded = true;
            await Device.InvokeOnMainThreadAsync(async () =>
            {
                await Task.Delay(1);
                OnPropertyChanged("IsSwitching");
            });
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

        #region CanAddDetail
        public bool CanAddDetail
        { 
            get
            {
                return (PermissionMaskDetail & 8) == 8;
            }
        }
        #endregion
        #region CanUpdateDetail
        public bool CanUpdateDetail
        { 
            get
            {
                return (PermissionMaskDetail & 4) == 4;
            }
        }
        #endregion
        #region CanDeleteDetail
        public object CanDeleteDetail
        { 
            get
            {
                return (PermissionMaskDetail & 2) == 2;
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
        #region GridHeightDetail
        protected double _GridHeightDetail = -1d;
        public double GridHeightDetail
        { 
            get
            {
                return _GridHeightDetail;
            }
            set
            {
                if (_GridHeightDetail != value)
                {
                    _GridHeightDetail = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion
        #region FilterHeightDetail
        protected double _FilterHeightDetail = -1d;
        public double FilterHeightDetail
        { 
            get
            {
                return _FilterHeightDetail;
            }
            set
            {
                if (_FilterHeightDetail != value)
                {
                    _FilterHeightDetail = value;
                    OnPropertyChanged();
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
                        tmpFlt = this.FrmSrvPhbkEmployeeView.getHiddenFilterAsFltRslt(this.FrmRootSrvPhbkDivisionView.getHiddenFilterByRow(selectedMasterRow, "Division"));
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

        #region IDestructible 
        bool _IsDestroyed = false;
        public bool IsDestroyed {
            get { return _IsDestroyed; }
            set { 
                if (_IsDestroyed != value) { 
                    if(value) {
                        _IsDestroyed = value; 
                        OnPropertyChanged();
                        OnPropertyChanged("IsDetailDestroyed");
                    }
                } 
            }
        }

        public void Destroy()
        {
            if(IsDestroyed) return;
            IsDestroyed = true;
            OnPropertyChanged("IsDetailDestroyed");
            _navigationService = null;
            _TableMenuItems = null;
            _RowMenuItems = null;
            _HiddenFilters = null;
            _SelectedRow = null;

            _TableMenuItemsDetail = null;
            _RowMenuItemsDetail = null;
            _HiddenFiltersDetail = null;
            _SelectedRowDetail = null;

            GridHeight = -1;
            FilterHeight = -1;
            GridHeightDetail = -1;
            FilterHeightDetail = -1;  

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




