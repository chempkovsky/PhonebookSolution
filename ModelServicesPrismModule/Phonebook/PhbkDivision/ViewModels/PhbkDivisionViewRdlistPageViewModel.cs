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


    "PhbkDivisionViewRdlistPage" UserControl is defined in the "ModelServicesPrismModule"-project.
    In the file of IModule-class of "ModelServicesPrismModule"-project the following line of code must be inserted:

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ...
            // According to requirements of the "PhbkDivisionViewRdlistPageViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            ViewModelLocationProvider.Register<PhbkDivisionViewRdlistPage, PhbkDivisionViewRdlistPageViewModel>();
            // According to requirements of the "PhbkDivisionViewRdlistPageViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            containerRegistry.RegisterForNavigation<PhbkDivisionViewRdlistPage, PhbkDivisionViewRdlistPageViewModel>("PhbkDivisionViewRdlistPage");
            // Only if you need to get an instance of controls, insert two lines below
            // According to requirements of the "PhbkDivisionViewRdlistPageViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            // containerRegistry.Register<ContentPage, PhbkDivisionViewRdlistPage>("PhbkDivisionViewRdlistPage");
            ...
        }
*/

namespace ModelServicesPrismModule.Phonebook.PhbkDivision.ViewModels {

    public class PhbkDivisionViewRdlistPageViewModel: INotifyPropertyChanged, INavigationAware, IDestructible  
    {
        protected IAppGlblSettingsService GlblSettingsSrv=null;
        protected IPhbkDivisionViewService FrmSrvPhbkDivisionView = null;
        protected INavigationService _navigationService;
        public PhbkDivisionViewRdlistPageViewModel(IPhbkDivisionViewService _FrmSrvPhbkDivisionView, IAppGlblSettingsService GlblSettingsSrv, INavigationService navigationService) {
            this.GlblSettingsSrv = GlblSettingsSrv;
            this.FrmSrvPhbkDivisionView = _FrmSrvPhbkDivisionView;
            this._navigationService = navigationService;
            PermissionMask = GlblSettingsSrv.GetViewModelMask("PhbkDivisionView");
            _TableMenuItems = GetDefaultTableMenuItems();
            _RowMenuItems = GetDefaultRowMenuItems();
            _GridHeight = this.GlblSettingsSrv.ExpandedGridHeight("02019-RdlistPage.xaml");
            _FilterHeight = this.GlblSettingsSrv.ExpandedFilterHeight("02019-RdlistPage.xaml");
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
//
//  Warning:
//  "02017-RdlistPage.xaml.cs" type has not been generated for LprDivision01View
//
//
//  Warning:
//  "02017-RdlistPage.xaml.cs" type has not been generated for LprDivision02View
//
                new WebServiceFilterMenuViewModel() { Id = "RowMIPhbkEmployeeViewRdlistPageDivision", Caption="Employees: Division", IconName="ArrowRightBold", IconColor=Color.Default, Enabled=true, Data=null, FeedbackData=null},
//
//  Warning:
//  "02017-RdlistPage.xaml.cs" type has not been generated for LprEmployee02View
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
        public async Task NavigateToDetailCommand(IPhbkDivisionView selected, string detailVwNm, string fkNvNm, string detailVwClNm) { 
            if(IsDestroyed) return;
            if (((GlblSettingsSrv.GetViewModelMask(detailVwNm) & 1) != 1 )) {
                INavigationResult nr1 = await _navigationService.NavigateAsync("AccessDeniedPage");
                OnNavigationResult(nr1);
                return;
            }
            if(selected == null) return;
            NavigationParameters navigationParameters = new NavigationParameters();
            navigationParameters.Add("HiddenFilter", this.FrmSrvPhbkDivisionView.getHiddenFilterByRow(selected, fkNvNm));  
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
            IPhbkDivisionView arow = mi.FeedbackData as IPhbkDivisionView;
            if (arow == null) return;
            switch(mi.Id) {
//
//  Warning:
//  "02017-RdlistPage.xaml.cs" type has not been generated for LprDivision01View
//
//
//  Warning:
//  "02017-RdlistPage.xaml.cs" type has not been generated for LprDivision02View
//
                case "RowMIPhbkEmployeeViewRdlistPageDivision":
                    await NavigateToDetailCommand(arow, "PhbkEmployeeView", "Division", "PhbkEmployeeViewRdlistPage");
                    break;
//
//  Warning:
//  "02017-RdlistPage.xaml.cs" type has not been generated for LprEmployee02View
//
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
//
//  Warning:
//  "02017-RdlistPage.xaml.cs" type has not been generated for LprDivision01View
//
//
//  Warning:
//  "02017-RdlistPage.xaml.cs" type has not been generated for LprDivision02View
//
                    case "RowMIPhbkEmployeeViewRdlistPageDivision":
                        return ((GlblSettingsSrv.GetViewModelMask("PhbkEmployeeView") & 1) == 1 );
//
//  Warning:
//  "02017-RdlistPage.xaml.cs" type has not been generated for LprEmployee02View
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

       #region INavigationAware
       public bool IsNavigationTarget(INavigationParameters prms) {
            return true;
       }
       public void OnNavigatedFrom(INavigationParameters prms) {
            
       }
       public void OnNavigatedTo(INavigationParameters prms) {
            if(IsDestroyed) return;
            PermissionMask = GlblSettingsSrv.GetViewModelMask("PhbkDivisionView");
            if ((PermissionMask & 1) != 1) {
                throw new Exception("Access Denied to navigate PhbkDivisionView");
            }
            CanAdd = (PermissionMask & 8) == 8; 
            CanUpdate = (PermissionMask & 4) == 4; 
            CanDelete = (PermissionMask & 2) == 2; 

            if(!IsParentLoaded) {
                ObservableCollection<IWebServiceFilterRsltInterface> hf = new ObservableCollection<IWebServiceFilterRsltInterface>();
          
                if(prms.ContainsKey("HiddenFilter")) {
                    IList<IWebServiceFilterRsltInterface> hflts = 
                        FrmSrvPhbkDivisionView.getHiddenFilterAsFltRslt(
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

    }
}



