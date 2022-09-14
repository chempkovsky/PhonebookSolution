using System;
using Xamarin.Forms;
using System.Linq;
using System.ComponentModel;
using Prism.Regions.Navigation;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using Prism.Navigation;
using System.Threading.Tasks;
using Xamarin.Essentials;
using CommonInterfacesClassLibrary.Interfaces;
using CommonUserControlLibrary.ViewModels;
using CommonInterfacesClassLibrary.AppGlblSettingsSrvc;
using CommonInterfacesClassLibrary.Enums;
using ModelInterfacesClassLibrary.Phonebook.PhbkEmployee;
/*


    "PhbkEmployeeViewRdlistUserControl" UserControl is defined in the "ModelServicesPrismModule"-project.
    In the file of IModule-class of "ModelServicesPrismModule"-project the following line of code must be inserted:

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ...
            // According to requirements of the "PhbkEmployeeViewRdlistViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            ViewModelLocationProvider.Register<PhbkEmployeeViewRdlistUserControl, PhbkEmployeeViewRdlistViewModel>();
            // According to requirements of the "PhbkEmployeeViewRdlistViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            containerRegistry.RegisterForRegionNavigation<PhbkEmployeeViewRdlistUserControl, PhbkEmployeeViewRdlistViewModel>("PhbkEmployeeViewRdlistUserControl");
            // According to requirements of the "PhbkEmployeeViewRdlistViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            containerRegistry.Register<ContentView, PhbkEmployeeViewRdlistUserControl>("PhbkEmployeeViewRdlistUserControl");
            ...
        }
*/

namespace ModelServicesPrismModule.Phonebook.PhbkEmployee.ViewModels {

    public class PhbkEmployeeViewRdlistViewModel: RegionAwareViewModelBase, IRegionAware
    {
        protected IAppGlblSettingsService GlblSettingsSrv=null;
        protected IPhbkEmployeeViewService FrmSrvPhbkEmployeeView = null;
        
        public PhbkEmployeeViewRdlistViewModel(IPhbkEmployeeViewService _FrmSrvPhbkEmployeeView, IAppGlblSettingsService GlblSettingsSrv) {
            this.GlblSettingsSrv = GlblSettingsSrv;
            this.FrmSrvPhbkEmployeeView = _FrmSrvPhbkEmployeeView;
            PermissionMask = GlblSettingsSrv.GetViewModelMask("PhbkEmployeeView");
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
        string _Caption = "Employees";
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
            return new ObservableCollection<IWebServiceFilterMenuInterface>()  {
//
//  Warning:
//  "02016-RdlistUserControl.xaml.cs" type has not been generated for LprEmployee01View
//
//
//  Warning:
//  "02016-RdlistUserControl.xaml.cs" type has not been generated for LprEmployee02View
//
                new WebServiceFilterMenuViewModel() { Id = "RowMIPhbkPhoneViewRdlistUserControlEmployee", Caption="Phones: Employee", IconName="ArrowRightBold", IconColor=Color.Default, Enabled=true, Data=null, FeedbackData=null, Command = RowMenuItemsCommand},
//
//  Warning:
//  "02016-RdlistUserControl.xaml.cs" type has not been generated for LprPhone02View
//
//
//  Warning:
//  "02016-RdlistUserControl.xaml.cs" type has not been generated for LprPhone04View
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

        #region NavigateToDetailCommand
        public void NavigateToDetailCommand(IPhbkEmployeeView selected, string detailVwNm, string fkNvNm, string detailVwClNm) { 
            if (IsDestroyed) return;
            if (((GlblSettingsSrv.GetViewModelMask(detailVwNm) & 1) != 1 )) {
                CurrentNavigationContext.NavigationService.RequestNavigate(new Uri("AccessDeniedUserControl", UriKind.Relative), OnNavigationResult);
                return;
            }
            if(selected == null) return;
            NavigationParameters navigationParameters = new NavigationParameters();
            navigationParameters.Add("HiddenFilter", this.FrmSrvPhbkEmployeeView.getHiddenFilterByRow(selected, fkNvNm));  
            CurrentNavigationContext.NavigationService.RequestNavigate(new Uri(detailVwClNm, UriKind.Relative), OnNavigationResult, navigationParameters);
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
        protected void RowMenuItemsCommandExecute(object prm)
        {
            if (IsDestroyed) return;
            IWebServiceFilterMenuInterface mi = prm as IWebServiceFilterMenuInterface;
            if (mi == null) return;
            IPhbkEmployeeView arow = mi.FeedbackData as IPhbkEmployeeView;
            if (arow == null) return;
            switch(mi.Id) {
//
//  Warning:
//  "02016-RdlistUserControl.xaml.cs" type has not been generated for LprEmployee01View
//
//
//  Warning:
//  "02016-RdlistUserControl.xaml.cs" type has not been generated for LprEmployee02View
//
                case "RowMIPhbkPhoneViewRdlistUserControlEmployee":
                    NavigateToDetailCommand(arow, "PhbkPhoneView", "Employee", "PhbkPhoneViewRdlistUserControl");
                    break;
//
//  Warning:
//  "02016-RdlistUserControl.xaml.cs" type has not been generated for LprPhone02View
//
//
//  Warning:
//  "02016-RdlistUserControl.xaml.cs" type has not been generated for LprPhone04View
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
//
//  Warning:
//  "02016-RdlistUserControl.xaml.cs" type has not been generated for LprEmployee01View
//
//
//  Warning:
//  "02016-RdlistUserControl.xaml.cs" type has not been generated for LprEmployee02View
//
                    case "RowMIPhbkPhoneViewRdlistUserControlEmployee":
                        return ((GlblSettingsSrv.GetViewModelMask("PhbkPhoneView") & 1) == 1 );
//
//  Warning:
//  "02016-RdlistUserControl.xaml.cs" type has not been generated for LprPhone02View
//
//
//  Warning:
//  "02016-RdlistUserControl.xaml.cs" type has not been generated for LprPhone04View
//
                    default:
                        break;
                }
            }
            return false; 
        }
        #endregion

        #region SelectedRow
        //protected object _SelectedRow = null;
        //public object SelectedRow {
        //    get {
        //    }
        //    set {
        //        if(_SelectedRow != value) {
        //            _SelectedRow = value;
        //            OnPropertyChanged();
        //        }
        //    }
        //}
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
           // SelectedRow = prm;
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
            PermissionMask = GlblSettingsSrv.GetViewModelMask("PhbkEmployeeView");
            if ((PermissionMask & 1) != 1) {
                if (navigationContext.NavigationService.Journal.CurrentEntry.Uri.OriginalString == "AccessDeniedUserControl")
                {
                    navigationContext.NavigationService.RequestNavigate(new Uri("AccessDeniedUserControl", UriKind.Relative), OnNavigationResult);
                    return;
                }
                else if(navigationContext.NavigationService.Journal.CanGoBack) {
                    // it should be intercepted by prev item in navigation chain
                    throw new Exception("Access Denied to navigate PhbkEmployeeView");
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
                OnPropertyChanged("CanAdd");
                OnPropertyChanged("CanUpdate");
                OnPropertyChanged("CanDelete");
            });
            if((!IsParentLoaded) || (IsNavigatedBack)) {
                ObservableCollection<IWebServiceFilterRsltInterface> hf = new ObservableCollection<IWebServiceFilterRsltInterface>();
          
                if(prms.ContainsKey("HiddenFilter")) {
                    IList<IWebServiceFilterRsltInterface> hflts = 
                        FrmSrvPhbkEmployeeView.getHiddenFilterAsFltRslt(
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
            IsNavigatedBack = false;
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
        }

    }
}



