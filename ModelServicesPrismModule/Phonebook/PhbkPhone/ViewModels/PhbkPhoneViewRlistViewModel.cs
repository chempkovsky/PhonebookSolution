using System;
using Xamarin.Forms;
using System.Linq;
using Prism.Regions.Navigation;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using Prism.Navigation;
using Xamarin.Essentials;
using Prism.Regions;

using CommonInterfacesClassLibrary.Interfaces;
using CommonUserControlLibrary.ViewModels;
using CommonInterfacesClassLibrary.AppGlblSettingsSrvc;
using CommonInterfacesClassLibrary.Enums;
using ModelInterfacesClassLibrary.Phonebook.PhbkPhone;
/*


    "PhbkPhoneViewRlistUserControl" UserControl is defined in the "ModelServicesPrismModule"-project.
    In the file of IModule-class of "ModelServicesPrismModule"-project the following line of code must be inserted:

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ...
            // According to requirements of the "PhbkPhoneViewRlistViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            ViewModelLocationProvider.Register<PhbkPhoneViewRlistUserControl, PhbkPhoneViewRlistViewModel>();
            // According to requirements of the "PhbkPhoneViewRlistViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            containerRegistry.RegisterForRegionNavigation<PhbkPhoneViewRlistUserControl, PhbkPhoneViewRlistViewModel>("PhbkPhoneViewRlistUserControl");
            // According to requirements of the "PhbkPhoneViewRlistViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            containerRegistry.Register<ContentView, PhbkPhoneViewRlistUserControl>("PhbkPhoneViewRlistUserControl");
            ...
        }
*/

namespace ModelServicesPrismModule.Phonebook.PhbkPhone.ViewModels {

    public class PhbkPhoneViewRlistViewModel: RegionAwareViewModelBase, IRegionAware 
    {
        protected IAppGlblSettingsService GlblSettingsSrv=null;
        protected IPhbkPhoneViewService FrmSrvPhbkPhoneView = null;
        public PhbkPhoneViewRlistViewModel(IPhbkPhoneViewService _FrmSrvPhbkPhoneView, 
            IAppGlblSettingsService GlblSettingsSrv) {
            this.GlblSettingsSrv = GlblSettingsSrv;
            this.FrmSrvPhbkPhoneView = _FrmSrvPhbkPhoneView;
            PermissionMask = GlblSettingsSrv.GetViewModelMask("PhbkPhoneView");
            _TableMenuItems = GetDefaultTableMenuItems();
            _RowMenuItems = GetDefaultRowMenuItems();
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
        string _Caption = "Phones";
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


        #region NavigateToDetailCommand
        public void NavigateToDetailCommand(IPhbkPhoneView selected, string detailVwNm, string fkNvNm, string detailVwClNm) { 
            if (IsDestroyed) return;
            if (((GlblSettingsSrv.GetViewModelMask(detailVwNm) & 1) != 1 )) {
                CurrentNavigationContext.NavigationService.RequestNavigate(new Uri("AccessDeniedUserControl", UriKind.Relative), OnNavigationResult);
                return;
            }
            if(selected == null) return;
            NavigationParameters navigationParameters = new NavigationParameters();
            navigationParameters.Add("HiddenFilter", this.FrmSrvPhbkPhoneView.getHiddenFilterByRow(selected, fkNvNm));  
            CurrentNavigationContext.NavigationService.RequestNavigate(new Uri(detailVwClNm, UriKind.Relative), OnNavigationResult, navigationParameters);
        }
        #endregion

        #region RowMenuItems
        protected ObservableCollection<IWebServiceFilterMenuInterface> GetDefaultRowMenuItems() {
            return new ObservableCollection<IWebServiceFilterMenuInterface>()  {
                new WebServiceFilterMenuViewModel() { Id = "RowUpdMI", Caption="Update item", IconName="TableEdit", IconColor=Color.Default, Enabled=true, Data=null, Command = RowMenuItemsCommand},
                new WebServiceFilterMenuViewModel() { Id = "RowDelMI", Caption="Delete item", IconName="TableRemove", IconColor=Color.Default, Enabled=true, Data=null, Command = RowMenuItemsCommand},
                new WebServiceFilterMenuViewModel() { Id = "RowViewMI", Caption="View item", IconName="TableEdit", IconColor=Color.Default, Enabled=true, Data=null, Command = RowMenuItemsCommand},
//
//  Warning:
//  "01916-RlistUserControl.xaml.cs" type has not been generated for LprPhone01View
//
//
//  Warning:
//  "01916-RlistUserControl.xaml.cs" type has not been generated for LprPhone02View
//
//
//  Warning:
//  "01916-RlistUserControl.xaml.cs" type has not been generated for LprPhone03View
//
//
//  Warning:
//  "01916-RlistUserControl.xaml.cs" type has not been generated for LprPhone04View
//
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

        #region OnNavigationResult
        protected void OnNavigationResult(IRegionNavigationResult navResult) {
            if (IsDestroyed) return;
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
        public void SformAddItemCommand() {
            if (IsDestroyed) return;
            if (!CanAdd) {
                CurrentNavigationContext.NavigationService.RequestNavigate(new Uri("AccessDeniedUserControl", UriKind.Relative), OnNavigationResult);
                return;
            }

            NavigationParameters navigationParameters = new NavigationParameters();
            foreach(IWebServiceFilterRsltInterface hf in HiddenFilters) {
                navigationParameters.Add(hf.fltrName, hf.fltrValue);
            }
            navigationParameters.Add("EformModeEnum", EformModeEnum.AddMode);
            CurrentNavigationContext.NavigationService.RequestNavigate(new Uri("PhbkPhoneViewRaddUserControl", UriKind.Relative), OnNavigationResult, navigationParameters);
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
            if (IsDestroyed) return;
            if(prm == null) return;
            IWebServiceFilterMenuInterface mi = prm as IWebServiceFilterMenuInterface;
            if (mi == null) return;
            if(mi.Id == "TableAddMI") {
                SformAddItemCommand();
            }
        }
        protected bool TableMenuItemsCommandCanExecute(object prm)
        {
            IWebServiceFilterMenuInterface mi = prm as IWebServiceFilterMenuInterface;
            if (mi != null) {
                if(mi.Id == "TableAddMI") {
                    return CanAdd;
                }
            }
            return false; 
        }
        #endregion


        #region SformUpdItemCommand
        public void SformUpdItemCommand(IPhbkPhoneView selected) {
            if (IsDestroyed) return;
            if (selected == null) return;
            if (!CanUpdate) {
                CurrentNavigationContext.NavigationService.RequestNavigate(new Uri("AccessDeniedUserControl", UriKind.Relative), OnNavigationResult);
                return;
            }

            NavigationParameters navigationParameters = new NavigationParameters();
            foreach(IWebServiceFilterRsltInterface hf in HiddenFilters) {
                navigationParameters.Add(hf.fltrName, hf.fltrValue);
            }
            navigationParameters.Add("EformModeEnum", EformModeEnum.UpdateMode);
            navigationParameters.Add("pkpPhoneId", selected.PhoneId);
            CurrentNavigationContext.NavigationService.RequestNavigate(new Uri("PhbkPhoneViewRupdUserControl", UriKind.Relative), OnNavigationResult, navigationParameters);
        }
        #endregion

        #region SformDelItemCommand
        public void SformDelItemCommand(IPhbkPhoneView selected) {
            if (IsDestroyed) return;
            if (selected == null) return;
            if(!CanDelete) {
                CurrentNavigationContext.NavigationService.RequestNavigate(new Uri("AccessDeniedUserControl", UriKind.Relative), OnNavigationResult);
                return;
            }

            NavigationParameters navigationParameters = new NavigationParameters();
            foreach(IWebServiceFilterRsltInterface hf in HiddenFilters) {
                navigationParameters.Add(hf.fltrName, hf.fltrValue);
            }
            navigationParameters.Add("EformModeEnum", EformModeEnum.DeleteMode);
            navigationParameters.Add("pkpPhoneId", selected.PhoneId);
            CurrentNavigationContext.NavigationService.RequestNavigate(new Uri("PhbkPhoneViewRdelUserControl", UriKind.Relative), OnNavigationResult, navigationParameters);
        }
        #endregion
        
        #region SformViewItemCommand
        public void SformViewItemCommand(IPhbkPhoneView selected) {
            if (IsDestroyed) return;
            if (selected == null) return;
            NavigationParameters navigationParameters = new NavigationParameters();
            foreach(IWebServiceFilterRsltInterface hf in HiddenFilters) {
                navigationParameters.Add(hf.fltrName, hf.fltrValue);
            }
            navigationParameters.Add("EformModeEnum", EformModeEnum.ViewMode);
            navigationParameters.Add("pkpPhoneId", selected.PhoneId);
            CurrentNavigationContext.NavigationService.RequestNavigate(new Uri("PhbkPhoneViewRviewUserControl", UriKind.Relative), OnNavigationResult, navigationParameters);
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
            if (IsDestroyed) return;
            IWebServiceFilterMenuInterface mi = prm as IWebServiceFilterMenuInterface;
            if (mi == null) return;
            IPhbkPhoneView arow = mi.FeedbackData as IPhbkPhoneView;
            if (arow == null) return;
            switch(mi.Id) {
                case "RowUpdMI":
                    SformUpdItemCommand(arow);
                    break;
                case "RowDelMI":
                    SformDelItemCommand(arow);
                    break;
                case "RowViewMI":
                    SformViewItemCommand(arow);
                    break;

//
//  Warning:
//  "01916-RlistUserControl.xaml.cs" type has not been generated for LprPhone01View
//
//
//  Warning:
//  "01916-RlistUserControl.xaml.cs" type has not been generated for LprPhone02View
//
//
//  Warning:
//  "01916-RlistUserControl.xaml.cs" type has not been generated for LprPhone03View
//
//
//  Warning:
//  "01916-RlistUserControl.xaml.cs" type has not been generated for LprPhone04View
//
                default:
                    break;
            }         
        }
        protected bool RowMenuItemsCommandCanExecute(object prm)
        {
            if (IsDestroyed) return false;
            IWebServiceFilterMenuInterface mi = prm as IWebServiceFilterMenuInterface;
            if (mi != null) {
                switch(mi.Id) {
                    case "RowUpdMI":
                        return CanUpdate;
                    case "RowDelMI":
                        return CanDelete;
                    case "RowViewMI":
                        return true;

//
//  Warning:
//  "01916-RlistUserControl.xaml.cs" type has not been generated for LprPhone01View
//
//
//  Warning:
//  "01916-RlistUserControl.xaml.cs" type has not been generated for LprPhone02View
//
//
//  Warning:
//  "01916-RlistUserControl.xaml.cs" type has not been generated for LprPhone03View
//
//
//  Warning:
//  "01916-RlistUserControl.xaml.cs" type has not been generated for LprPhone04View
//
                    default:
                        break;
                }         
            }
            return false; 
        }
        #endregion

        #region SelectedRow
//        protected object _SelectedRow = null;
//        public object SelectedRow {
//            get {
//                return _SelectedRow;
//            }
//            set {
//                if(_SelectedRow != value) {
//                    _SelectedRow = value;
//                    OnPropertyChanged();
//                    DetailNavigateTo();
//                }
//            }
//        }
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
//           SelectedRow = prm;
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
       #region IRegionAware
       bool IsNavigatedBack = false;
       public bool IsNavigationTarget(INavigationContext navigationContext) {
            return true;
       }
       public void OnNavigatedFrom(INavigationContext navigationContext) {
            CurrentNavigationContext = null;
       }
       public async void OnNavigatedTo(INavigationContext navigationContext) {
            if (IsDestroyed) return;
            INavigationParameters prms = navigationContext.Parameters;
            PermissionMask = GlblSettingsSrv.GetViewModelMask("PhbkPhoneView");
            if ((PermissionMask & 1) != 1) {
                if (navigationContext.NavigationService.Journal.CurrentEntry.Uri.OriginalString == "AccessDeniedUserControl")
                {
                    navigationContext.NavigationService.RequestNavigate(new Uri("AccessDeniedUserControl", UriKind.Relative), OnNavigationResult);
                    return;
                }
                else if(navigationContext.NavigationService.Journal.CanGoBack) {
                    // it should be intercepted by prev item in navigation chain
                    throw new Exception("Access Denied to navigate PhbkPhoneView");
                } else {
                    // this is a first item in navigation chain, so navigationContext.Parameters are not expected
                    navigationContext.NavigationService.RequestNavigate(new Uri("AccessDeniedUserControl", UriKind.Relative), OnNavigationResult);
                    return;
                }
            }
            CurrentNavigationContext = navigationContext;

            await  MainThread.InvokeOnMainThreadAsync(() => {
                OnPropertyChanged("ShowBackBtn");
                (OnNavigationBackCommand as Command).ChangeCanExecute();
                SformAfterAddItem = null; 
                SformAfterUpdItem = null; 
                SformAfterDelItem = null; 
            });
            if ((!IsParentLoaded) || (IsNavigatedBack)) {
                ObservableCollection<IWebServiceFilterRsltInterface> hf = new ObservableCollection<IWebServiceFilterRsltInterface>();
          
                if(prms.ContainsKey("HiddenFilter")) {
                    IList<IWebServiceFilterRsltInterface> hflts = 
                        FrmSrvPhbkPhoneView.getHiddenFilterAsFltRslt(
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
                System.Int32 pkpPhoneId = default(System.Int32);
                if(prms.ContainsKey("pkpPhoneId")) {
                    pkpPhoneId = prms.GetValue<System.Int32>("pkpPhoneId");
                }
            
                if ((mode == EformModeEnum.AddMode) || (mode == EformModeEnum.UpdateMode)) {
                    // IPhbkPhoneView tdata 
                    _ = FrmSrvPhbkPhoneView.getone(
                            pkpPhoneId
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
                            IsNavigatedBack = false;
                        });
                    });
                } else {
                    IPhbkPhoneView data = FrmSrvPhbkPhoneView.CopyToModel(null,null);
                    data.PhoneId = pkpPhoneId;
                    SformAfterDelItem = data;
                    IsParentLoaded = true;
                    IsNavigatedBack = false;
                }
            } else {
                IsParentLoaded = true;
                IsNavigatedBack = false;
            }
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
            if (IsDestroyed) return;
            if (CurrentNavigationContext != null) {
                if(CurrentNavigationContext.NavigationService.Journal.CanGoBack) {
                    IsNavigatedBack = true;
                    CurrentNavigationContext.NavigationService.Journal.GoBack();
                }
            }
        }
        protected bool OnNavigationBackCommandCanExecute()
        {
            return (CurrentNavigationContext == null) ?  false : CurrentNavigationContext.NavigationService.Journal.CanGoBack;
        }
        #endregion

        public override void OnDestroy() {
            base.OnDestroy();
            _HiddenFilters = null;
            _TableMenuItems = null;
            _RowMenuItems = null;
            _Caption = null;
            _SformAfterAddItem = null;
            _SformAfterUpdItem = null;
            _SformAfterDelItem = null;
        }
    }
}



