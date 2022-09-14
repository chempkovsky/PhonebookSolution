using Xamarin.Forms;
using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Prism.Navigation;
using CommonInterfacesClassLibrary.Interfaces;
using CommonUserControlLibrary.ViewModels;
using ModelInterfacesClassLibrary.Phonebook.PhbkEmployee;
using CommonInterfacesClassLibrary.AppGlblSettingsSrvc;
using CommonUserControlLibrary.UserControls;
using CommonCustomControlLibrary.Fonts;
using CommonUserControlLibrary.Classes;
using CommonCustomControlLibrary.Classes;
using ModelInterfacesClassLibrary.Phonebook.LprEmployee01;
using ModelInterfacesClassLibrary.Phonebook.LpdEmpLastName;
using ModelInterfacesClassLibrary.Phonebook.LpdEmpFirstName;
using ModelInterfacesClassLibrary.Phonebook.LpdEmpSecondName;
using ModelInterfacesClassLibrary.Phonebook.LprEmployee02;
/*

    "PhbkEmployeeViewSformUserControl" UserControl is defined in the "ModelServicesPrismModule"-project.
    In the file of IModule-class of "ModelServicesPrismModule"-project the following line of code must be inserted:

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ...
            // According to requirements of the "PhbkEmployeeViewSformViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            ViewModelLocationProvider.Register<PhbkEmployeeViewSformUserControl, PhbkEmployeeViewSformViewModel>();
            // According to requirements of the "PhbkEmployeeViewSformViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            containerRegistry.Register<ContentView, PhbkEmployeeViewSformUserControl>("PhbkEmployeeViewSformUserControl");
            ...
        }

*/

namespace ModelServicesPrismModule.Phonebook.PhbkEmployee.ViewModels {
    public class PhbkEmployeeViewSformViewModel: INotifyPropertyChanged, ISformViewModelInterface, IBindingContextChanged, IDestructible
    {
        protected IPhbkEmployeeViewService FrmRootSrv=null;
        protected IAppGlblSettingsService GlblSettingsSrv=null;
        protected IDialogService _dialogService=null;
        protected ILprEmployee01ViewService FrmSrvLprEmployee01View;
        protected ILpdEmpLastNameViewService FrmSrvLpdEmpLastNameView;
        protected ILpdEmpFirstNameViewService FrmSrvLpdEmpFirstNameView;
        protected ILpdEmpSecondNameViewService FrmSrvLpdEmpSecondNameView;
        protected ILprEmployee02ViewService FrmSrvLprEmployee02View;
    

        bool CnFllscn = false;
        public PhbkEmployeeViewSformViewModel(IAppGlblSettingsService GlblSettingsSrv, IPhbkEmployeeViewService FrmRootSrv, 
                ILprEmployee01ViewService FrmSrvLprEmployee01View,
                ILpdEmpLastNameViewService FrmSrvLpdEmpLastNameView,
                ILpdEmpFirstNameViewService FrmSrvLpdEmpFirstNameView,
                ILpdEmpSecondNameViewService FrmSrvLpdEmpSecondNameView,
                ILprEmployee02ViewService FrmSrvLprEmployee02View,
    
            IDialogService dialogService) {
            this.GlblSettingsSrv = GlblSettingsSrv;
            this.FrmRootSrv = FrmRootSrv;
            this._dialogService = dialogService;
                this.FrmSrvLprEmployee01View = FrmSrvLprEmployee01View;
                this.FrmSrvLpdEmpLastNameView = FrmSrvLpdEmpLastNameView;
                this.FrmSrvLpdEmpFirstNameView = FrmSrvLpdEmpFirstNameView;
                this.FrmSrvLpdEmpSecondNameView = FrmSrvLpdEmpSecondNameView;
                this.FrmSrvLprEmployee02View = FrmSrvLprEmployee02View;
    
            _TableMenuItemsVM = GetDefaultTableMenuItemsVM();
            CnFllscn = (GlblSettingsSrv.GetViewModelMask("PhbkEmployeeView") & 16) == 16;
        }
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion


        object _BindingContextFeedbackRef = null;
        public object BindingContextFeedbackRef {
            get { return _BindingContextFeedbackRef; }
            set { 
                if(_BindingContextFeedbackRef != value) {
                    _BindingContextFeedbackRef = value;
                    OnPropertyChanged();
                }
            }
        }


        #region SelectedRow
        public object _SelectedRow = null;
        public object SelectedRow {
            get { return _SelectedRow;}
            set { 
                if (_SelectedRow != value) {
                    _SelectedRow = value;
                    OnPropertyChanged();
                    BindingContextFeedbackRef = new BindingContextFeedback() {
		                BcfName = "SelectedRow",
		                BcfData = _SelectedRow
                    };
                }
            }
        }
        #endregion


        public async Task OnLoaded(object sender, object newValue)
        {
            if (newValue is bool) {
                bool v = (bool)newValue;
                if ((!IsOnLoadedCalled) && v) {
                    IsOnLoadedCalled = true;
                    defineSearchMethod();
                    await onFilter();
                } else {
                    IsOnLoadedCalled = v;
                }
            }
        }
        protected bool IsOnLoadedCalled = false;
        protected IEnumerable<IWebServiceFilterRsltInterface> CurrentFilter = null;

        #region InternalContent
        int _InternalContent = 0;
        protected void InternalContentChanged()
        {
            if (_InternalContent < 10) _InternalContent++; else _InternalContent = 0;
            MainThread.InvokeOnMainThreadAsync(async () =>
            {
                await Task.Delay(1);
                this.OnPropertyChanged("InternalContent");
            });
        }
        public int InternalContent
        {
            get { return _InternalContent; }
        }
        #endregion

        #region DataSource
        protected IEnumerable<IPhbkEmployeeView> _DataSource = new ObservableCollection<IPhbkEmployeeView>();
        public IEnumerable<IPhbkEmployeeView> DataSource
        { 
            get
            {
                return _DataSource;
            }
            set
            {
                if (_DataSource != value)
                {
                    _DataSource = value;
                    OnPropertyChanged();
                    InternalContentChanged();
                }
            }
        }
        #endregion
        #region ApplyFilterCommand
        protected ICommand _ApplyFilterCommand = null;
        public ICommand ApplyFilterCommand
        {
            get
            {
                return _ApplyFilterCommand ?? (_ApplyFilterCommand = new Command((prm) => ApplyFilterCommandExecute(prm), (prm) => ApplyFilterCommandCanExecute(prm)));
            }
        }
        protected async void ApplyFilterCommandExecute(object prm)
        {
            CurrentFilter = prm as IEnumerable<IWebServiceFilterRsltInterface>;
            ActualCurrentPage = 0;
            await onFilter();
        }
        protected bool ApplyFilterCommandCanExecute(object prm)
        {
            return !IsInQuery;
        }
        #endregion
        #region RefreshSformCommand
        public async void RefreshSformCommand() {
            await onFilter();
        }
        #endregion
        
        #region SelectedColumns
        protected IEnumerable<IColumnSelectorItemDefInterface> _SelectedColumns = new ObservableCollection<IColumnSelectorItemDefInterface>() {
            new ColumnSelectorItemDefViewModel() {
                Name= "EmployeeId", 
                Caption= "Id of the Employee", 
                IsChecked= true
            }, 
            new ColumnSelectorItemDefViewModel() {
                Name= "EmpFirstName", 
                Caption= "Employee First Name", 
                IsChecked= true
            }, 
            new ColumnSelectorItemDefViewModel() {
                Name= "EmpLastName", 
                Caption= "Employee Last Name", 
                IsChecked= true
            }, 
            new ColumnSelectorItemDefViewModel() {
                Name= "EmpSecondName", 
                Caption= "Employee Second Name", 
                IsChecked= true
            }, 
            new ColumnSelectorItemDefViewModel() {
                Name= "DDivisionName", 
                Caption= "Name of the Division", 
                IsChecked= true
            }, 
            new ColumnSelectorItemDefViewModel() {
                Name= "DEEntrprsName", 
                Caption= "Name of the Enterprise", 
                IsChecked= false
            }, 
            new ColumnSelectorItemDefViewModel() {
                Name= "DivisionIdRef", 
                Caption= "Id of the Division", 
                IsChecked= false
            }, 
        };
        public IEnumerable<IColumnSelectorItemDefInterface> SelectedColumns
        { 
            get
            {
                return _SelectedColumns;
            }
            set
            {
                if (_SelectedColumns != value)
                {
                    _SelectedColumns = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        #region SelectColumnsCommand
        protected void SelectColumnsCommandCallback(IDialogResult rslt)
        {
            if ((!rslt.Parameters.ContainsKey("Result")) || (!rslt.Parameters.ContainsKey("Columns"))) return;
            bool aResult =  rslt.Parameters["Result"] is bool;
            if(aResult) aResult = (bool)rslt.Parameters["Result"];
            if (!aResult) return;
            if(rslt.Parameters.ContainsKey("Columns")) {
                IEnumerable<IColumnSelectorItemDefInterface> clms = rslt.Parameters.GetValue<IEnumerable<IColumnSelectorItemDefInterface>>("Columns");
                foreach(IColumnSelectorItemDefInterface c in clms) {
                    IColumnSelectorItemDefInterface r = SelectedColumns.Where(i => i.Name == c.Name).FirstOrDefault();
                    if(r != null) r.IsChecked = c.IsChecked;
                }
            }
        }
        public void SelectColumnsCommand() {
            ObservableCollection<IColumnSelectorItemDefInterface> columns = new ObservableCollection<IColumnSelectorItemDefInterface>();
            foreach(IColumnSelectorItemDefInterface sc  in SelectedColumns) {
                columns.Add( new ColumnSelectorItemDefViewModel() {Name = sc.Name, Caption=sc.Caption, IsChecked=sc.IsChecked });
            }
            IDialogParameters prms = new DialogParameters();
            prms.Add("Title", "Select columns");
            prms.Add("Columns", columns);
            this._dialogService.ShowDialog("ColumnSelectorDlg", prms, SelectColumnsCommandCallback);
        }
        #endregion

        #region RowMenuItemsPropertyChanged
        public void RowMenuItemsPropertyChanged(object Sender, object OldValue, object NewValue) {
            if (IsDestroyed) return;
            ObservableCollection<IWebServiceFilterMenuInterface> tmis = new ObservableCollection<IWebServiceFilterMenuInterface>();
            IEnumerable<IWebServiceFilterMenuInterface> intmis = NewValue as IEnumerable<IWebServiceFilterMenuInterface>;
            if(intmis != null) {
                foreach(IWebServiceFilterMenuInterface tmi  in intmis) {
                    tmis.Add( new WebServiceFilterMenuViewModel() {Id = tmi.Id, Caption=tmi.Caption,  IconName=tmi.IconName, IconColor=tmi.IconColor, Enabled=tmi.Enabled, Data=tmi.Data, Command = tmi.Command});
                }
            }
            RowMenuItemsVM = tmis;
        }
        protected IEnumerable<IWebServiceFilterMenuInterface> _RowMenuItemsVM = null;
        public IEnumerable<IWebServiceFilterMenuInterface> RowMenuItemsVM
        { 
            get
            {
                return _RowMenuItemsVM;
            }
            set
            {
                if (_RowMenuItemsVM != value)
                {
                    _RowMenuItemsVM = value;
                    OnPropertyChanged();
                    (RowMenuItemsCommand as Command).ChangeCanExecute();
                }
            }
        }
        #endregion
        #region RowMenuItemsCommand
        protected ICommand _RowMenuItemsCommand = null;
        public ICommand RowMenuItemsCommand
        {
            get
            {
                return _RowMenuItemsCommand ?? (_RowMenuItemsCommand = new Command((prm) => RowMenuItemsCommandExecute(prm), (prm) => RowMenuItemsCommandCanExecute(prm)));
            }
        }
        protected async void RowMenuItemsCommandExecute(object prm)
        {
            List<string> lst = new List<string>();
            foreach(IWebServiceFilterMenuInterface mi in RowMenuItemsVM) {
                if (mi.Command != null) {
                    mi.FeedbackData = prm;
                    if(mi.Command.CanExecute(mi)) lst.Add(mi.Caption);
                } else lst.Add(mi.Caption);
            }
            string action = await Application.Current.MainPage.DisplayActionSheet("Row commands:", "Cancel", null, lst.ToArray());
            foreach(IWebServiceFilterMenuInterface mi in RowMenuItemsVM) {
                if(mi.Caption == action) {
                    IWebServiceFilterMenuInterface miToSend = new WebServiceFilterMenuViewModel() {Id = mi.Id, Caption = mi.Caption,  IconName = mi.IconName, IconColor = mi.IconColor, Enabled = mi.Enabled, Data = mi.Data,  FeedbackData = prm};
                    BindingContextFeedbackRef = new BindingContextFeedback() {
		                BcfName = "RowMenuItemsCommand",
		                BcfData = miToSend
                    };
                    return;
                }
            }
        }
        protected bool RowMenuItemsCommandCanExecute(object prm)
        {
            bool rslt = (RowMenuItemsVM != null);
            if (rslt) rslt = RowMenuItemsVM.Any();
            return rslt;
        }

        #endregion

        #region TableMenuItemsVM
        protected ObservableCollection<IWebServiceFilterMenuInterface> GetDefaultTableMenuItemsVM() {
            return new ObservableCollection<IWebServiceFilterMenuInterface>()  {
                new WebServiceFilterMenuViewModel() { Id = "TableRefreshMI", Caption="Refresh table", IconName=IconFont.Refresh, IconColor=Color.Default, Enabled=true, Data=null, Command = TableMenuItemsCommand},
                new WebServiceFilterMenuViewModel() { Id = "TableSettingsMI", Caption="Table columns", IconName=IconFont.Settings, IconColor=Color.Default, Enabled=true, Data=null, Command = TableMenuItemsCommand},
            };
        }
        public void TableMenuItemsPropertyChanged(object Sender, object OldValue, object NewValue) {
            if (IsDestroyed) return;
            ObservableCollection<IWebServiceFilterMenuInterface> tmis = GetDefaultTableMenuItemsVM();
            IEnumerable<IWebServiceFilterMenuInterface> intmis = NewValue as IEnumerable<IWebServiceFilterMenuInterface>;
            if(intmis != null) {
                foreach(IWebServiceFilterMenuInterface tmi  in intmis) {
                    tmis.Add( new WebServiceFilterMenuViewModel() {Id = tmi.Id, Caption=tmi.Caption,  IconName=tmi.IconName, IconColor=tmi.IconColor, Enabled=tmi.Enabled, Data=tmi.Data, Command = tmi.Command});
                }
            }
            TableMenuItemsVM = tmis;
        }
        protected IEnumerable<IWebServiceFilterMenuInterface> _TableMenuItemsVM = null;
        public IEnumerable<IWebServiceFilterMenuInterface> TableMenuItemsVM
        { 
            get
            {
                return _TableMenuItemsVM;
            }
            set
            {
                if (_TableMenuItemsVM != value)
                {
                    _TableMenuItemsVM = value;
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
                return _TableMenuItemsCommand ?? (_TableMenuItemsCommand = new Command(() => TableMenuItemsCommandExecute(), () => TableMenuItemsCommandCanExecute()));
            }
        }
        protected async void TableMenuItemsCommandExecute()
        {
            List<string> lst = new List<string>();
            foreach(IWebServiceFilterMenuInterface mi in TableMenuItemsVM) {
                if (mi.Command != null) {
                    if(mi.Command.CanExecute(mi)) lst.Add(mi.Caption);
                } else lst.Add(mi.Caption);
            }
            IList<IWebServiceFilterMenuInterface> timis = defineSearchMethodMenuItemsData();
            foreach(IWebServiceFilterMenuInterface mi in timis) {
                lst.Add(mi.Caption);
            }
            string action = await Application.Current.MainPage.DisplayActionSheet("Table commands:", "Cancel", null, lst.ToArray());
            if(action == "Cancel") return;
            foreach(IWebServiceFilterMenuInterface mi in timis) {
                if(mi.Caption == action) {
                    if(SearchMethod == mi.Id) return;
                    IsSearchGridFlex = false;
                    IsSearchDestroyed = true;
                    IsSearchGridFlex = true;
                    IsSearchDestroyed = false;
                    SearchMethod = mi.Id;
                    return;
                }
            }
            foreach(IWebServiceFilterMenuInterface mi in TableMenuItemsVM) {
                if(mi.Caption == action) {
                    if(mi.Id == "TableRefreshMI") {
                        RefreshSformCommand();
                    } else if(mi.Id == "TableSettingsMI") {
                        SelectColumnsCommand();
                    } else {
                        BindingContextFeedbackRef = new BindingContextFeedback() {
		                    BcfName = "TableMenuItemsCommand",
		                    BcfData = mi
                        };
                    };
                    return;
                }
            }
        }
        protected bool TableMenuItemsCommandCanExecute()
        {
            return true;
        }
        #endregion




        #region HiddenFiltersVM
        public async Task HiddenFiltersPropertyChanged(object Sender, object OldValue, object NewValue)
        {
            if(IsDestroyed) return;
            if(NewValue == null) {
                if(_HiddenFiltersVM == null) return;
                if(!_HiddenFiltersVM.Any()) return;
            }
            IEnumerable<IWebServiceFilterRsltInterface> hfs = NewValue as IEnumerable<IWebServiceFilterRsltInterface>;
            ObservableCollection<IWebServiceFilterRsltInterface> newhfs = new ObservableCollection<IWebServiceFilterRsltInterface>();
            if(hfs != null) {
                foreach(IWebServiceFilterRsltInterface hf  in hfs) {
                    newhfs.Add( new WebServiceFilterRsltViewModel() {fltrName=hf.fltrName, fltrDataType=hf.fltrDataType,  fltrOperator=hf.fltrOperator, fltrValue=hf.fltrValue, fltrError=hf.fltrError });
                }
            }
            HiddenFiltersVM = newhfs;
            CurrentFilter = newhfs;

            ObservableCollection<IWebServiceFilterDefInterface> fltDf = 
                new ObservableCollection<IWebServiceFilterDefInterface>() {
                    new WebServiceFilterDefViewModel() {fltrName="EmployeeId", fltrCaption="Id of the Employee",  fltrDataType="int32", fltrMaxLen=null, fltrMin=null, fltrMax=null },
                    new WebServiceFilterDefViewModel() {fltrName="EmpFirstName", fltrCaption="Employee First Name",  fltrDataType="string", fltrMaxLen=25, fltrMin=null, fltrMax=null },
                    new WebServiceFilterDefViewModel() {fltrName="EmpLastName", fltrCaption="Employee Last Name",  fltrDataType="string", fltrMaxLen=40, fltrMin=null, fltrMax=null },
                    new WebServiceFilterDefViewModel() {fltrName="DivisionIdRef", fltrCaption="Id of the Division",  fltrDataType="int32", fltrMaxLen=null, fltrMin=null, fltrMax=null },
                };
            bool isDsbl = true;
            if (this.HiddenFiltersVM != null) {
                isDsbl = isDsbl && this.HiddenFiltersVM.Any(v => v.fltrName == "DivisionIdRef");
            } else isDsbl = false;
            if(!isDsbl) {
            }
            ActualCurrentPage = 0;
            defineSearchMethod();
            await onFilter();
        }
        IEnumerable<IWebServiceFilterRsltInterface> _HiddenFiltersVM = new ObservableCollection<IWebServiceFilterRsltInterface>();
        public IEnumerable<IWebServiceFilterRsltInterface> HiddenFiltersVM
        {
            get
            {
                return _HiddenFiltersVM;
            }
            set
            {
                if (_HiddenFiltersVM != value)
                {
                    _HiddenFiltersVM = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        #region FilterDefinitions
        IEnumerable<IWebServiceFilterDefInterface> _FilterDefinitions = new ObservableCollection<IWebServiceFilterDefInterface>()
        {
                                            new WebServiceFilterDefViewModel() {fltrName="EmployeeId", fltrCaption="Id of the Employee",  fltrDataType="int32", fltrMaxLen=null, fltrMin=null, fltrMax=null },
                                            new WebServiceFilterDefViewModel() {fltrName="EmpFirstName", fltrCaption="Employee First Name",  fltrDataType="string", fltrMaxLen=25, fltrMin=null, fltrMax=null },
                                            new WebServiceFilterDefViewModel() {fltrName="EmpLastName", fltrCaption="Employee Last Name",  fltrDataType="string", fltrMaxLen=40, fltrMin=null, fltrMax=null },
                                            new WebServiceFilterDefViewModel() {fltrName="DivisionIdRef", fltrCaption="Id of the Division",  fltrDataType="int32", fltrMaxLen=null, fltrMin=null, fltrMax=null },
                        };
        public IEnumerable<IWebServiceFilterDefInterface> FilterDefinitions
        { 
            get
            {
                return _FilterDefinitions;
            }
            set
            {
                if (_FilterDefinitions != value)
                {
                    _FilterDefinitions = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        #region IsInQuery
        protected bool _IsInQuery = false;
        public bool IsInQuery {
            get { return _IsInQuery; }
            set { if(_IsInQuery != value) { _IsInQuery = value; OnPropertyChanged(); } }
        }
        #endregion

        #region RowsPerPageOptions
        protected IEnumerable<int> _RowsPerPageOptions = new ObservableCollection<int>() {10,25,50,100};
        public IEnumerable<int> RowsPerPageOptions {
            get { return _RowsPerPageOptions; }
            set { if(_RowsPerPageOptions != value) { _RowsPerPageOptions = value; OnPropertyChanged(); } }
        }
        #endregion

        #region TotalCount
        protected int _TotalCount = 0;
        public int TotalCount {
            get { return _TotalCount; }
            set { if(_TotalCount != value) { _TotalCount = value; OnPropertyChanged(); } }
        }
        #endregion

        #region CurrentPage
        protected int _ActualCurrentPage = 0;
        protected int ActualCurrentPage
        {
            get { return _ActualCurrentPage; }
            set
            {
                _ActualCurrentPage = value;
                CurrentPage = _ActualCurrentPage;
            }
        }
        protected int _CurrentPage = 0;
        public int CurrentPage {
            get { return _CurrentPage; }
            set { 
                if(_CurrentPage != value) { 
                    _CurrentPage = value; 
                    OnPropertyChanged(); 
                } 
            }
        }
        #endregion

        #region RowsPerPage
        protected int _ActualRowsPerPage = 10;
        protected int ActualRowsPerPage
        {
            get { return _ActualRowsPerPage; }
            set
            {
                if (_ActualRowsPerPage != value)
                {
                    _ActualRowsPerPage = value;
                    ActualCurrentPage = 0;
                }
                RowsPerPage = _ActualRowsPerPage;
            }
        }
        protected int _RowsPerPage = 10;
        public int RowsPerPage {
            get { return _RowsPerPage; }
            set { 
                if(_RowsPerPage != value) { 
                    bool cpc = _CurrentPage != 0;
                    _CurrentPage = 0;
                    _RowsPerPage = value; 
                    OnPropertyChanged(); 
                    if(cpc) OnPropertyChanged("CurrentPage"); 
                } 
            }
        }
        #endregion

        #region OnRowsPerPageChangedCommand
        protected ICommand _OnRowsPerPageChangedCommand = null;
        public ICommand OnRowsPerPageChangedCommand
        {
            get
            {
                return _OnRowsPerPageChangedCommand ?? (_OnRowsPerPageChangedCommand = new Command((prm) => OnRowsPerPageChangedCommandExecute(prm), (prm) => OnRowsPerPageChangedCommandCanExecute(prm)));
            }
        }
        protected async void OnRowsPerPageChangedCommandExecute(object prm)
        {
            ValueChangedCmdParam<int> val = prm as ValueChangedCmdParam<int>;
            if (val != null) {
                if (ActualRowsPerPage != val.NewVal)
                {
                    await onFilter();
                }
            }
        }
        protected bool OnRowsPerPageChangedCommandCanExecute(object prm)
        {
            return true;
        }
        #endregion

        #region OnCurrentPageChangedCommand
        protected ICommand _OnCurrentPageChangedCommand = null;
        public ICommand OnCurrentPageChangedCommand
        {
            get
            {
                return _OnCurrentPageChangedCommand ?? (_OnCurrentPageChangedCommand = new Command((prm) => OnCurrentPageChangedCommandExecute(prm), (prm) => OnCurrentPageChangedCommandCanExecute(prm)));
            }
        }
        protected async void OnCurrentPageChangedCommandExecute(object prm)
        {
            ValueChangedCmdParam<int> val = prm as ValueChangedCmdParam<int>;
            if (val != null) {
                if (ActualCurrentPage != val.NewVal)
                {
                    await onFilter();
                }
            }
        }
        protected bool OnCurrentPageChangedCommandCanExecute(object prm)
        {
            return true;
        }
        #endregion


        #region Sort
        public string CurrentSortInfo {
            get { 
                if(string.IsNullOrEmpty(CurrentSortColumn)) return null;
                return CurrentSortColumn + " " + CurrentSortdirection;
            }
        }
        protected string CurrentSortColumn = "";
        protected string CurrentSortdirection  = "";
        protected ICommand _OnSortCommand = null;
        public ICommand OnSortCommand
        {
            get
            {
                return _OnSortCommand ?? (_OnSortCommand = new Command((prm) => OnSortCommandExecute(prm), (prm) => OnSortCommandCanExecute(prm)));
            }
        }
        protected async void OnSortCommandExecute(object prm)
        {
            string val = prm as string;
            if(string.IsNullOrEmpty(val)) return;
            if (val != CurrentSortColumn) {
                CurrentSortColumn = val;
                CurrentSortdirection  = "";
            }
            if (CurrentSortdirection  == "")
                CurrentSortdirection  = "asc";
            else if (CurrentSortdirection  == "asc")
                CurrentSortdirection = "desc";
            else CurrentSortdirection = "";
            OnPropertyChanged("CurrentSortInfo"); 
            await onFilter();
        }
        protected bool OnSortCommandCanExecute(object prm)
        {
            return true;
        }
        #endregion

        #region IsDsDestroyed
        protected bool _IsDsDestroyed = false;
        public bool IsDsDestroyed
        {
            get { return _IsDsDestroyed; }
            set { if (_IsDsDestroyed != value) { _IsDsDestroyed = value; OnPropertyChanged(); } }
        }
        #endregion
        #region IsDestroyed
        protected bool _IsDestroyed = false;
        public bool IsDestroyed
        {
            get { return _IsDestroyed; }
            set { 
                if (_IsDestroyed != value) { 
                    _IsDestroyed = value; 
                    OnPropertyChanged(); 
                    OnPropertyChanged("IsSearchDestroyed");
                } 
            }
        }
        #endregion

        #region Filter
        protected void ClearDataSource() {
                IsDsDestroyed = true;
                DataSource = null;
                IsDsDestroyed = false;
        }
        protected async Task onFilter() {
            if(IsDsDestroyed) return;
            if ((IsInQuery) || (!IsOnLoadedCalled)) return;
            IsInQuery = true;
            if(SearchMethod == "NoSearchMethod") {
                ClearDataSource();
                DataSource = new ObservableCollection<IPhbkEmployeeView>();
                SelectedRow = null;
                IsInQuery = false;
                return;
            }

            switch (SearchMethod) {
                case "ScanByVwLprEmployee01View":  
                    await SrchDoSlctRwLprEmployee01View();
                    IsInQuery = false;
                    return;
                case "ScanByVwLprEmployee02View":  
                    await SrchDoSlctRwLprEmployee02View();
                    IsInQuery = false;
                    return;
            }

            if ((SearchMethod == "FullScan")
                || (SearchMethod == "ScanByUkPrimary")
            ) {

                IPhbkEmployeeViewFilter flt  = FrmRootSrv.GetFilter();
                flt.page = this.CurrentPage; 
                flt.pagesize = this.RowsPerPage;
                if(!string.IsNullOrEmpty(CurrentSortColumn)) {
                    string asc = "";
                    if("desc".Equals(CurrentSortdirection, System.StringComparison.OrdinalIgnoreCase)) {
                        asc = "-";
                    }
                    flt.orderby = new List<string>() { asc + CurrentSortColumn };
                }
                if(CurrentFilter != null) {
                    foreach(IWebServiceFilterRsltInterface e in CurrentFilter) {
                        if((!string.IsNullOrEmpty(e.fltrError)) || string.IsNullOrEmpty(e.fltrName)) continue;
                        switch(e.fltrName) {
                            case "EmployeeId":
                                if (flt.EmployeeId == null) flt.EmployeeId = new List<System.Int32>();
                                flt.EmployeeId.Add((System.Int32)e.fltrValue);
                                if (flt.employeeIdOprtr == null) flt.employeeIdOprtr = new List<string>();
                                flt.employeeIdOprtr.Add(e.fltrOperator);
                                break;
                            case "EmpFirstName":
                                if (flt.EmpFirstName == null) flt.EmpFirstName = new List<System.String>();
                                flt.EmpFirstName.Add((System.String)e.fltrValue);
                                if (flt.empFirstNameOprtr == null) flt.empFirstNameOprtr = new List<string>();
                                flt.empFirstNameOprtr.Add(e.fltrOperator);
                                break;
                            case "EmpLastName":
                                if (flt.EmpLastName == null) flt.EmpLastName = new List<System.String>();
                                flt.EmpLastName.Add((System.String)e.fltrValue);
                                if (flt.empLastNameOprtr == null) flt.empLastNameOprtr = new List<string>();
                                flt.empLastNameOprtr.Add(e.fltrOperator);
                                break;
                            case "DivisionIdRef":
                                if (flt.DivisionIdRef == null) flt.DivisionIdRef = new List<System.Int32>();
                                flt.DivisionIdRef.Add((System.Int32)e.fltrValue);
                                if (flt.divisionIdRefOprtr == null) flt.divisionIdRefOprtr = new List<string>();
                                flt.divisionIdRefOprtr.Add(e.fltrOperator);
                                break;
                            default: break;
                        }
                    }
                }
                IPhbkEmployeeViewPage rslt = await this.FrmRootSrv.getwithfilter(flt);
                if(rslt != null) {
                    // RowsPerPage resets CurrentPage 
                    // so the order is important: ActualRowsPerPage must be the first one and ActualCurrentPage must be the second
                    ActualRowsPerPage = rslt.pagesize;
                    ActualCurrentPage = rslt.page;
                    TotalCount = rslt.total; 
                    SelectedRow = null;
                    ObservableCollection<IPhbkEmployeeView> ds = DataSource as ObservableCollection<IPhbkEmployeeView>;
                    IsDsDestroyed = true;
                    if (ds == null) { ds = new ObservableCollection<IPhbkEmployeeView>(); } else { ds.Clear(); }
                    IsDsDestroyed = false;
                    DataSource = null; 
                    if(rslt.items != null) {
                        foreach(IPhbkEmployeeView itm in rslt.items) {
                            ds.Add(FrmRootSrv.CopyToModelNotify(itm, null));
                        }
                    }
                    DataSource = ds;
                    SelectedRow = DataSource?.FirstOrDefault();
                    // InternalContentChanged();
                }
                IsInQuery = false;
            }
        }
        #endregion
        #region SformAfterAddItemCommand
        public void SformAfterAddItemCommand(object sender, object item) {
            IPhbkEmployeeView prm = item as  IPhbkEmployeeView;
            if(prm == null) return;
            ObservableCollection<IPhbkEmployeeView> ds = DataSource as ObservableCollection<IPhbkEmployeeView>;
            ds.Add(FrmRootSrv.CopyToModelNotify(prm, null));
            InternalContentChanged();
        }
        #endregion
        #region SformAfterUpdItemCommand
        public void SformAfterUpdItemCommand(object sender, object item) {
            IPhbkEmployeeView prm = item as  IPhbkEmployeeView;
            if(prm == null) return;
            ObservableCollection<IPhbkEmployeeView> ds = DataSource as ObservableCollection<IPhbkEmployeeView>;
            if (ds.IndexOf(prm) > -1) {
                return;
            }
            IPhbkEmployeeView rw = ds.Where(d => 
                        (d.EmployeeId == prm.EmployeeId)
                    ).FirstOrDefault();
            if (rw != null) {
                FrmRootSrv.CopyToModel(prm, rw);
            } else {
                ds.Add(FrmRootSrv.CopyToModelNotify(prm, null));
            }
            InternalContentChanged();
        }
        #endregion
        #region SformAfterDelItemCommand
        public void SformAfterDelItemCommand(object sender, object item) {
            IPhbkEmployeeView prm = item as  IPhbkEmployeeView;
            if(prm == null) return;
            ObservableCollection<IPhbkEmployeeView> ds = DataSource as ObservableCollection<IPhbkEmployeeView>;
            int indx = ds.IndexOf(prm);
            if (indx > -1) {
                ds.RemoveAt(indx);
                InternalContentChanged();
                return;
            }
            IPhbkEmployeeView rw = ds.Where(d => 
                        (d.EmployeeId == prm.EmployeeId)
                    ).FirstOrDefault();
            if (rw != null) {
                indx = ds.IndexOf(rw);
                if (indx > -1) {
                    ClearDataSource();
                    ds.RemoveAt(indx);
                    DataSource = ds;
                    //InternalContentChanged();
                    return;
                }
            }
        }
        #endregion
        public void OnDestroy() {
            IsDestroyed = true;
            IsDsDestroyed = true; // notify UI
            _RowMenuItemsVM = null; 
            _TableMenuItemsVM = null;
            _FilterDefinitions = null; 
            _HiddenFiltersVM = null;
            _BindingContextFeedbackRef = null;
            _SelectedRow = null; 
            DataSource = null; 
        }
        #region IDestructible

        public void Destroy()
        {
            if(IsDestroyed) return;
            OnDestroy();
        }
        #endregion


        #region SearchMethod
        protected string _SearchMethod = "NoSearchMethod";
        public string SearchMethod {
            get {
                return _SearchMethod;
            }
            set {
                if(_SearchMethod != value) {
                    _SearchMethod = value;
                    OnPropertyChanged(); 
                }
            }
        }
        #endregion

        #region IsSearchDestroyed
        protected bool _IsSearchDestroyed = false;
        public bool IsSearchDestroyed
        {
            get { return _IsSearchDestroyed || _IsDestroyed; }
            set { 
                if (_IsSearchDestroyed != value) { 
                    _IsSearchDestroyed = value; 
                    OnPropertyChanged(); 
                } 
            }
        }
        #endregion

        #region IsSearchGridFlex
        protected bool _IsSearchGridFlex = false;
        public bool IsSearchGridFlex
        {
            get { return _IsSearchGridFlex; }
            set { 
                if (_IsSearchGridFlex != value) { 
                    _IsSearchGridFlex = value; 
                    OnPropertyChanged(); 
                } 
            }
        }
        #endregion

        #region ScanByVwLprEmployee01ViewFilterDefinitions
        protected async Task SrchDoSlctRwLprEmployee01View() {
            ILprEmployee01ViewFilter dtlflt = FrmSrvLprEmployee01View.GetFilter();
            dtlflt.page = this.CurrentPage; 
            dtlflt.pagesize = this.RowsPerPage;
            bool isFltSet = true;
            if(isFltSet) {
                if (ScanByVwLprEmployee01ViewEmpLastNameItem is null) {  
                    isFltSet = false;
                } else {
                    IList<IWebServiceFilterRsltInterface> dfltrslt = 
                        FrmSrvLprEmployee01View.getHiddenFilterAsFltRslt(this.FrmSrvLpdEmpLastNameView.getHiddenFilterByRow(ScanByVwLprEmployee01ViewEmpLastNameItem, "EmpLastNameDict"));
                    if (dfltrslt is null) {
                        isFltSet = false;
                    } else {
                        FrmSrvLprEmployee01View.FilterRslt2Filter(dfltrslt, dtlflt);
                    } 
                } 
            }
            if(isFltSet) {
                if (ScanByVwLprEmployee01ViewEmpFirstNameItem is null) {  
                    isFltSet = false;
                } else {
                    IList<IWebServiceFilterRsltInterface> dfltrslt = 
                        FrmSrvLprEmployee01View.getHiddenFilterAsFltRslt(this.FrmSrvLpdEmpFirstNameView.getHiddenFilterByRow(ScanByVwLprEmployee01ViewEmpFirstNameItem, "EmpFirstNameDict"));
                    if (dfltrslt is null) {
                        isFltSet = false;
                    } else {
                        FrmSrvLprEmployee01View.FilterRslt2Filter(dfltrslt, dtlflt);
                    } 
                } 
            }
            if(isFltSet) {
                if (ScanByVwLprEmployee01ViewEmpSecondNameItem is null) {  
                    isFltSet = false;
                } else {
                    IList<IWebServiceFilterRsltInterface> dfltrslt = 
                        FrmSrvLprEmployee01View.getHiddenFilterAsFltRslt(this.FrmSrvLpdEmpSecondNameView.getHiddenFilterByRow(ScanByVwLprEmployee01ViewEmpSecondNameItem, "EmpSecondNameDict"));
                    if (dfltrslt is null) {
                        isFltSet = false;
                    } else {
                        FrmSrvLprEmployee01View.FilterRslt2Filter(dfltrslt, dtlflt);
                    } 
                } 
            }
            if(!isFltSet) {
                GlblSettingsSrv.ShowErrorMessage("http", "Could not apply filter as not all attributes are set");
            }
            // by requirements all common foreignkey props have the same names for LprEmployee01View and PhbkEmployeeView
            foreach(var fld in reqHiddenProps["LprEmployee01View"]) { 
                IWebServiceFilterRsltInterface hf = this.HiddenFiltersVM.FirstOrDefault(f => f.fltrName == fld);
                if(!(hf is null)) {
                    FrmSrvLprEmployee01View.FilterRslt2Filter(hf, dtlflt);
                }
            }
            foreach(var fld in extHiddenProps["LprEmployee01View"]) { 
                IWebServiceFilterRsltInterface hf = this.HiddenFiltersVM.FirstOrDefault(f => f.fltrName == fld);
                if(!(hf is null)) {
                    FrmSrvLprEmployee01View.FilterRslt2Filter(hf, dtlflt);
                }
            }
            ILprEmployee01ViewPage vd = await FrmSrvLprEmployee01View.getmanybyrepprim(dtlflt);
            if(vd is null) {
                ClearDataSource();
                DataSource = new ObservableCollection<IPhbkEmployeeView>();
                SelectedRow = null;
                return;
            }
            // RowsPerPage resets CurrentPage 
            // so the order is important: ActualRowsPerPage must be the first one and ActualCurrentPage must be the second
            ActualRowsPerPage = vd.pagesize;
            ActualCurrentPage = vd.page;
            TotalCount = vd.total; 
            if(vd.items is null) {
                ClearDataSource();
                DataSource = new ObservableCollection<IPhbkEmployeeView>();
                SelectedRow = null;
                return;
            }
            if(vd.items.Count < 1) {
                ClearDataSource();
                DataSource = new ObservableCollection<IPhbkEmployeeView>();
                SelectedRow = null;
                return;
            }
            IPhbkEmployeeViewFilter flt = FrmRootSrv.GetFilter();
            flt.page = 0;
            flt.pagesize = ActualCurrentPage;
            foreach(var src in vd.items) {
                // primary keys are identical for LprEmployee01View and PhbkEmployeeView
                FrmRootSrv.FilterRslt2Filter(FrmSrvLprEmployee01View.RowPrim2FilterRslt(src), flt);
            }
            IPhbkEmployeeViewPage rslt = await this.FrmRootSrv.getmanybyrepprim(flt);
            if(rslt != null) {
                // RowsPerPage resets CurrentPage 
                // so the order is important: ActualRowsPerPage must be the first one and ActualCurrentPage must be the second
                ActualRowsPerPage = rslt.pagesize;
                ActualCurrentPage = rslt.page;
                TotalCount = rslt.total; 
                SelectedRow = null;
                ObservableCollection<IPhbkEmployeeView> ds = DataSource as ObservableCollection<IPhbkEmployeeView>;
                IsDsDestroyed = true;
                if (ds == null) { ds = new ObservableCollection<IPhbkEmployeeView>(); } else { ds.Clear(); }
                IsDsDestroyed = false;
                DataSource = null; 
                if(rslt.items != null) {
                    foreach(IPhbkEmployeeView itm in rslt.items) {
                        ds.Add(FrmRootSrv.CopyToModelNotify(itm, null));
                    }
                }
                DataSource = ds;
                SelectedRow = DataSource?.FirstOrDefault();
            } else {
                ClearDataSource();
                DataSource = new ObservableCollection<IPhbkEmployeeView>();
                SelectedRow = null;
            }
        }
        protected IList<IUniqServiceFilterDefInterface> _ScanByVwLprEmployee01ViewFilterDefinitions = 
            new List<IUniqServiceFilterDefInterface>() {
                new UniqServiceFilterDef() { fltrName = "EmpLastName", fltrDispMemb = "EmpLastName", fltrTextMemb = "EmpLastName", fltrCaption = "Employee Last Name", fltrDataType = "string", fltrMaxLen = 40, fltrMin = null, fltrMax = null },
                new UniqServiceFilterDef() { fltrName = "EmpFirstName", fltrDispMemb = "EmpFirstName", fltrTextMemb = "EmpFirstName", fltrCaption = "Employee First Name", fltrDataType = "string", fltrMaxLen = 25, fltrMin = null, fltrMax = null },
                new UniqServiceFilterDef() { fltrName = "EmpSecondName", fltrDispMemb = "EmpSecondName", fltrTextMemb = "EmpSecondName", fltrCaption = "Employee Second Name", fltrDataType = "string", fltrMaxLen = 25, fltrMin = null, fltrMax = null },
            };
        public IList<IUniqServiceFilterDefInterface> ScanByVwLprEmployee01ViewFilterDefinitions {
            get {
                return _ScanByVwLprEmployee01ViewFilterDefinitions;
            }
        }
        protected ILpdEmpLastNameView _ScanByVwLprEmployee01ViewEmpLastNameItem = null;
        public ILpdEmpLastNameView ScanByVwLprEmployee01ViewEmpLastNameItem {
            get {
                return _ScanByVwLprEmployee01ViewEmpLastNameItem;
            }
            set {
                if (_ScanByVwLprEmployee01ViewEmpLastNameItem != value) {
                    _ScanByVwLprEmployee01ViewEmpLastNameItem = value;
                    OnPropertyChanged();
                    OnPropertyChanged("ScanByVwLprEmployee01ViewEmpLastNameText");
                }
            }
        }
        protected IList<ILpdEmpLastNameView> _ScanByVwLprEmployee01ViewEmpLastNameItemsSource = null;
        public IList<ILpdEmpLastNameView> ScanByVwLprEmployee01ViewEmpLastNameItemsSource {
            get {
                return _ScanByVwLprEmployee01ViewEmpLastNameItemsSource;
            }
            set {
                if(_ScanByVwLprEmployee01ViewEmpLastNameItemsSource != value) {
                    _ScanByVwLprEmployee01ViewEmpLastNameItemsSource = value;
                    OnPropertyChanged();
                }
            }
        }
        protected string _ScanByVwLprEmployee01ViewEmpLastNameText = null;
        public string ScanByVwLprEmployee01ViewEmpLastNameText {
            get {
                ILpdEmpLastNameView dmObj = ScanByVwLprEmployee01ViewEmpLastNameItem as ILpdEmpLastNameView;
                if(dmObj!= null) {
                    return dmObj.EmpLastName;
                } else {
                    return _ScanByVwLprEmployee01ViewEmpLastNameText;
                }
            }
            set {
                if(_ScanByVwLprEmployee01ViewEmpLastNameText != value) {
                    _ScanByVwLprEmployee01ViewEmpLastNameText = value;
                    OnPropertyChanged();
                }
            }
        }

        protected ILpdEmpFirstNameView _ScanByVwLprEmployee01ViewEmpFirstNameItem = null;
        public ILpdEmpFirstNameView ScanByVwLprEmployee01ViewEmpFirstNameItem {
            get {
                return _ScanByVwLprEmployee01ViewEmpFirstNameItem;
            }
            set {
                if (_ScanByVwLprEmployee01ViewEmpFirstNameItem != value) {
                    _ScanByVwLprEmployee01ViewEmpFirstNameItem = value;
                    OnPropertyChanged();
                    OnPropertyChanged("ScanByVwLprEmployee01ViewEmpFirstNameText");
                }
            }
        }
        protected IList<ILpdEmpFirstNameView> _ScanByVwLprEmployee01ViewEmpFirstNameItemsSource = null;
        public IList<ILpdEmpFirstNameView> ScanByVwLprEmployee01ViewEmpFirstNameItemsSource {
            get {
                return _ScanByVwLprEmployee01ViewEmpFirstNameItemsSource;
            }
            set {
                if(_ScanByVwLprEmployee01ViewEmpFirstNameItemsSource != value) {
                    _ScanByVwLprEmployee01ViewEmpFirstNameItemsSource = value;
                    OnPropertyChanged();
                }
            }
        }
        protected string _ScanByVwLprEmployee01ViewEmpFirstNameText = null;
        public string ScanByVwLprEmployee01ViewEmpFirstNameText {
            get {
                ILpdEmpFirstNameView dmObj = ScanByVwLprEmployee01ViewEmpFirstNameItem as ILpdEmpFirstNameView;
                if(dmObj!= null) {
                    return dmObj.EmpFirstName;
                } else {
                    return _ScanByVwLprEmployee01ViewEmpFirstNameText;
                }
            }
            set {
                if(_ScanByVwLprEmployee01ViewEmpFirstNameText != value) {
                    _ScanByVwLprEmployee01ViewEmpFirstNameText = value;
                    OnPropertyChanged();
                }
            }
        }

        protected ILpdEmpSecondNameView _ScanByVwLprEmployee01ViewEmpSecondNameItem = null;
        public ILpdEmpSecondNameView ScanByVwLprEmployee01ViewEmpSecondNameItem {
            get {
                return _ScanByVwLprEmployee01ViewEmpSecondNameItem;
            }
            set {
                if (_ScanByVwLprEmployee01ViewEmpSecondNameItem != value) {
                    _ScanByVwLprEmployee01ViewEmpSecondNameItem = value;
                    OnPropertyChanged();
                    OnPropertyChanged("ScanByVwLprEmployee01ViewEmpSecondNameText");
                }
            }
        }
        protected IList<ILpdEmpSecondNameView> _ScanByVwLprEmployee01ViewEmpSecondNameItemsSource = null;
        public IList<ILpdEmpSecondNameView> ScanByVwLprEmployee01ViewEmpSecondNameItemsSource {
            get {
                return _ScanByVwLprEmployee01ViewEmpSecondNameItemsSource;
            }
            set {
                if(_ScanByVwLprEmployee01ViewEmpSecondNameItemsSource != value) {
                    _ScanByVwLprEmployee01ViewEmpSecondNameItemsSource = value;
                    OnPropertyChanged();
                }
            }
        }
        protected string _ScanByVwLprEmployee01ViewEmpSecondNameText = null;
        public string ScanByVwLprEmployee01ViewEmpSecondNameText {
            get {
                ILpdEmpSecondNameView dmObj = ScanByVwLprEmployee01ViewEmpSecondNameItem as ILpdEmpSecondNameView;
                if(dmObj!= null) {
                    return dmObj.EmpSecondName;
                } else {
                    return _ScanByVwLprEmployee01ViewEmpSecondNameText;
                }
            }
            set {
                if(_ScanByVwLprEmployee01ViewEmpSecondNameText != value) {
                    _ScanByVwLprEmployee01ViewEmpSecondNameText = value;
                    OnPropertyChanged();
                }
            }
        }


        protected ICommand _ScanByVwLprEmployee01ViewTextChangedCommand = null;
        public ICommand ScanByVwLprEmployee01ViewTextChangedCommand
        {
            get
            {
                return _ScanByVwLprEmployee01ViewTextChangedCommand ?? (_ScanByVwLprEmployee01ViewTextChangedCommand = new Command((prm) => ScanByVwLprEmployee01ViewTextChangedCommandExecute(prm), (prm) => ScanByVwLprEmployee01ViewTextChangedCommandCanExecute(prm)));
            }
        }
        // Reason: UserInput = 0, ProgrammaticChange = 1, SuggestionChosen = 2
        protected async void ScanByVwLprEmployee01ViewTextChangedCommandExecute(object prm)
        {
            if ((IsDsDestroyed) || (prm is null)) return;
            (object Cmpnt, object Sender, IUniqServiceFilterDefInterface FltDef, int Reason, string QueryText) tprm  = ((object Cmpnt, object Sender, IUniqServiceFilterDefInterface FltDef, int Reason, string QueryText))prm;
            if(tprm.Reason != 0) return;
            switch(tprm.FltDef.fltrName) {
                case "EmpLastName":
                    ScanByVwLprEmployee01ViewEmpLastNameItem = null;
                    ScanByVwLprEmployee01ViewEmpLastNameText = tprm.QueryText;
                    {
                        ILpdEmpLastNameViewFilter fltr = FrmSrvLpdEmpLastNameView.GetFilter();
                        fltr.page = 0;
                        fltr.pagesize = 15;
                        fltr.EmpLastName = new List<string>() { tprm.QueryText };
                        fltr.empLastNameOprtr = new List<string>() { "lk" };
                        ILpdEmpLastNameViewPage rslt = await FrmSrvLpdEmpLastNameView.getmanybyrepunqLpdEmpLastNameUK(fltr);
                        if(rslt is null) {
                            ScanByVwLprEmployee01ViewEmpLastNameItemsSource = null;
                        } else {
                            ScanByVwLprEmployee01ViewEmpLastNameItemsSource = rslt.items;
                        }
                    }
                    break;
                case "EmpFirstName":
                    ScanByVwLprEmployee01ViewEmpFirstNameItem = null;
                    ScanByVwLprEmployee01ViewEmpFirstNameText = tprm.QueryText;
                    {
                        ILpdEmpFirstNameViewFilter fltr = FrmSrvLpdEmpFirstNameView.GetFilter();
                        fltr.page = 0;
                        fltr.pagesize = 15;
                        fltr.EmpFirstName = new List<string>() { tprm.QueryText };
                        fltr.empFirstNameOprtr = new List<string>() { "lk" };
                        ILpdEmpFirstNameViewPage rslt = await FrmSrvLpdEmpFirstNameView.getmanybyrepunqLpdEmpFirstNameUK(fltr);
                        if(rslt is null) {
                            ScanByVwLprEmployee01ViewEmpFirstNameItemsSource = null;
                        } else {
                            ScanByVwLprEmployee01ViewEmpFirstNameItemsSource = rslt.items;
                        }
                    }
                    break;
                case "EmpSecondName":
                    ScanByVwLprEmployee01ViewEmpSecondNameItem = null;
                    ScanByVwLprEmployee01ViewEmpSecondNameText = tprm.QueryText;
                    {
                        ILpdEmpSecondNameViewFilter fltr = FrmSrvLpdEmpSecondNameView.GetFilter();
                        fltr.page = 0;
                        fltr.pagesize = 15;
                        fltr.EmpSecondName = new List<string>() { tprm.QueryText };
                        fltr.empSecondNameOprtr = new List<string>() { "lk" };
                        ILpdEmpSecondNameViewPage rslt = await FrmSrvLpdEmpSecondNameView.getmanybyrepunqLpdEmpSecondNameUK(fltr);
                        if(rslt is null) {
                            ScanByVwLprEmployee01ViewEmpSecondNameItemsSource = null;
                        } else {
                            ScanByVwLprEmployee01ViewEmpSecondNameItemsSource = rslt.items;
                        }
                    }
                    break;
                default:
                    break;
            }            
        }
        protected bool ScanByVwLprEmployee01ViewTextChangedCommandCanExecute(object prm)
        {
            return true;
        }

        protected ICommand _ScanByVwLprEmployee01ViewQuerySubmitted = null;
        public ICommand ScanByVwLprEmployee01ViewQuerySubmitted
        {
            get
            {
                return _ScanByVwLprEmployee01ViewQuerySubmitted ?? (_ScanByVwLprEmployee01ViewQuerySubmitted = new Command((prm) => ScanByVwLprEmployee01ViewQuerySubmittedExecute(prm), (prm) => ScanByVwLprEmployee01ViewQuerySubmittedCanExecute(prm)));
            }
        }
        protected void ScanByVwLprEmployee01ViewQuerySubmittedExecute(object prm)
        {
            if ((IsDsDestroyed) || (prm is null)) return;
            (object Cmpnt, object Sender, IUniqServiceFilterDefInterface FltDef, object ChosenSuggestion, string QueryText) tprm  = 
                ((object Cmpnt, object Sender, IUniqServiceFilterDefInterface FltDef, object ChosenSuggestion, string QueryText))prm;
            switch(tprm.FltDef.fltrName) {
                case "EmpLastName":
                    ScanByVwLprEmployee01ViewEmpLastNameItem = tprm.ChosenSuggestion as ILpdEmpLastNameView;
                    ScanByVwLprEmployee01ViewEmpLastNameItemsSource = null;
                    break;
                case "EmpFirstName":
                    ScanByVwLprEmployee01ViewEmpFirstNameItem = tprm.ChosenSuggestion as ILpdEmpFirstNameView;
                    ScanByVwLprEmployee01ViewEmpFirstNameItemsSource = null;
                    break;
                case "EmpSecondName":
                    ScanByVwLprEmployee01ViewEmpSecondNameItem = tprm.ChosenSuggestion as ILpdEmpSecondNameView;
                    ScanByVwLprEmployee01ViewEmpSecondNameItemsSource = null;
                    break;
                default:
                    break;
            }
        }
        protected bool ScanByVwLprEmployee01ViewQuerySubmittedCanExecute(object prm)
        {
            return true;
        }
        protected ICommand _ScanByVwLprEmployee01ViewUnfocusedCommand = null;
        public ICommand ScanByVwLprEmployee01ViewUnfocusedCommand
        {
            get
            {
                return _ScanByVwLprEmployee01ViewUnfocusedCommand ?? (_ScanByVwLprEmployee01ViewUnfocusedCommand = new Command((prm) => ScanByVwLprEmployee01ViewUnfocusedCommandExecute(prm), (prm) => ScanByVwLprEmployee01ViewUnfocusedCommandCanExecute(prm)));
            }
        }
        protected void ScanByVwLprEmployee01ViewUnfocusedCommandExecute(object prm)
        {
            if ((IsDsDestroyed) || (prm is null)) return;
            (object Cmpnt, object Sender, IUniqServiceFilterDefInterface FltDef) tprm  = 
                ((object Cmpnt, object Sender, IUniqServiceFilterDefInterface FltDef))prm;
            switch(tprm.FltDef.fltrName) {
                case "EmpLastName":
                    ScanByVwLprEmployee01ViewEmpLastNameItemsSource = null;
                    break;
                case "EmpFirstName":
                    ScanByVwLprEmployee01ViewEmpFirstNameItemsSource = null;
                    break;
                case "EmpSecondName":
                    ScanByVwLprEmployee01ViewEmpSecondNameItemsSource = null;
                    break;
                default:
                    break;
            }
        }
        protected bool ScanByVwLprEmployee01ViewUnfocusedCommandCanExecute(object prm) {
            return true;
        }


        #endregion
        #region ScanByVwLprEmployee02ViewFilterDefinitions
        protected async Task SrchDoSlctRwLprEmployee02View() {
            ILprEmployee02ViewFilter dtlflt = FrmSrvLprEmployee02View.GetFilter();
            dtlflt.page = this.CurrentPage; 
            dtlflt.pagesize = this.RowsPerPage;
            bool isFltSet = true;
            if(isFltSet) {
                if (ScanByVwLprEmployee02ViewEmpLastNameItem is null) {  
                    isFltSet = false;
                } else {
                    IList<IWebServiceFilterRsltInterface> dfltrslt = 
                        FrmSrvLprEmployee02View.getHiddenFilterAsFltRslt(this.FrmSrvLpdEmpLastNameView.getHiddenFilterByRow(ScanByVwLprEmployee02ViewEmpLastNameItem, "EmpLastNameDict"));
                    if (dfltrslt is null) {
                        isFltSet = false;
                    } else {
                        FrmSrvLprEmployee02View.FilterRslt2Filter(dfltrslt, dtlflt);
                    } 
                } 
            }
            if(isFltSet) {
                if (ScanByVwLprEmployee02ViewEmpFirstNameItem is null) {  
                    isFltSet = false;
                } else {
                    IList<IWebServiceFilterRsltInterface> dfltrslt = 
                        FrmSrvLprEmployee02View.getHiddenFilterAsFltRslt(this.FrmSrvLpdEmpFirstNameView.getHiddenFilterByRow(ScanByVwLprEmployee02ViewEmpFirstNameItem, "EmpFirstNameDict"));
                    if (dfltrslt is null) {
                        isFltSet = false;
                    } else {
                        FrmSrvLprEmployee02View.FilterRslt2Filter(dfltrslt, dtlflt);
                    } 
                } 
            }
            if(isFltSet) {
                if (ScanByVwLprEmployee02ViewEmpSecondNameItem is null) {  
                    isFltSet = false;
                } else {
                    IList<IWebServiceFilterRsltInterface> dfltrslt = 
                        FrmSrvLprEmployee02View.getHiddenFilterAsFltRslt(this.FrmSrvLpdEmpSecondNameView.getHiddenFilterByRow(ScanByVwLprEmployee02ViewEmpSecondNameItem, "EmpSecondNameDict"));
                    if (dfltrslt is null) {
                        isFltSet = false;
                    } else {
                        FrmSrvLprEmployee02View.FilterRslt2Filter(dfltrslt, dtlflt);
                    } 
                } 
            }
            if(!isFltSet) {
                GlblSettingsSrv.ShowErrorMessage("http", "Could not apply filter as not all attributes are set");
            }
            // by requirements all common foreignkey props have the same names for LprEmployee02View and PhbkEmployeeView
            foreach(var fld in reqHiddenProps["LprEmployee02View"]) { 
                IWebServiceFilterRsltInterface hf = this.HiddenFiltersVM.FirstOrDefault(f => f.fltrName == fld);
                if(!(hf is null)) {
                    FrmSrvLprEmployee02View.FilterRslt2Filter(hf, dtlflt);
                }
            }
            foreach(var fld in extHiddenProps["LprEmployee02View"]) { 
                IWebServiceFilterRsltInterface hf = this.HiddenFiltersVM.FirstOrDefault(f => f.fltrName == fld);
                if(!(hf is null)) {
                    FrmSrvLprEmployee02View.FilterRslt2Filter(hf, dtlflt);
                }
            }
            ILprEmployee02ViewPage vd = await FrmSrvLprEmployee02View.getmanybyrepprim(dtlflt);
            if(vd is null) {
                ClearDataSource();
                DataSource = new ObservableCollection<IPhbkEmployeeView>();
                SelectedRow = null;
                return;
            }
            // RowsPerPage resets CurrentPage 
            // so the order is important: ActualRowsPerPage must be the first one and ActualCurrentPage must be the second
            ActualRowsPerPage = vd.pagesize;
            ActualCurrentPage = vd.page;
            TotalCount = vd.total; 
            if(vd.items is null) {
                ClearDataSource();
                DataSource = new ObservableCollection<IPhbkEmployeeView>();
                SelectedRow = null;
                return;
            }
            if(vd.items.Count < 1) {
                ClearDataSource();
                DataSource = new ObservableCollection<IPhbkEmployeeView>();
                SelectedRow = null;
                return;
            }
            IPhbkEmployeeViewFilter flt = FrmRootSrv.GetFilter();
            flt.page = 0;
            flt.pagesize = ActualCurrentPage;
            foreach(var src in vd.items) {
                // primary keys are identical for LprEmployee02View and PhbkEmployeeView
                FrmRootSrv.FilterRslt2Filter(FrmSrvLprEmployee02View.RowPrim2FilterRslt(src), flt);
            }
            IPhbkEmployeeViewPage rslt = await this.FrmRootSrv.getmanybyrepprim(flt);
            if(rslt != null) {
                // RowsPerPage resets CurrentPage 
                // so the order is important: ActualRowsPerPage must be the first one and ActualCurrentPage must be the second
                ActualRowsPerPage = rslt.pagesize;
                ActualCurrentPage = rslt.page;
                TotalCount = rslt.total; 
                SelectedRow = null;
                ObservableCollection<IPhbkEmployeeView> ds = DataSource as ObservableCollection<IPhbkEmployeeView>;
                IsDsDestroyed = true;
                if (ds == null) { ds = new ObservableCollection<IPhbkEmployeeView>(); } else { ds.Clear(); }
                IsDsDestroyed = false;
                DataSource = null; 
                if(rslt.items != null) {
                    foreach(IPhbkEmployeeView itm in rslt.items) {
                        ds.Add(FrmRootSrv.CopyToModelNotify(itm, null));
                    }
                }
                DataSource = ds;
                SelectedRow = DataSource?.FirstOrDefault();
            } else {
                ClearDataSource();
                DataSource = new ObservableCollection<IPhbkEmployeeView>();
                SelectedRow = null;
            }
        }
        protected IList<IUniqServiceFilterDefInterface> _ScanByVwLprEmployee02ViewFilterDefinitions = 
            new List<IUniqServiceFilterDefInterface>() {
                new UniqServiceFilterDef() { fltrName = "EmpLastName", fltrDispMemb = "EmpLastName", fltrTextMemb = "EmpLastName", fltrCaption = "Employee Last Name", fltrDataType = "string", fltrMaxLen = 40, fltrMin = null, fltrMax = null },
                new UniqServiceFilterDef() { fltrName = "EmpFirstName", fltrDispMemb = "EmpFirstName", fltrTextMemb = "EmpFirstName", fltrCaption = "Employee First Name", fltrDataType = "string", fltrMaxLen = 25, fltrMin = null, fltrMax = null },
                new UniqServiceFilterDef() { fltrName = "EmpSecondName", fltrDispMemb = "EmpSecondName", fltrTextMemb = "EmpSecondName", fltrCaption = "Employee Second Name", fltrDataType = "string", fltrMaxLen = 25, fltrMin = null, fltrMax = null },
            };
        public IList<IUniqServiceFilterDefInterface> ScanByVwLprEmployee02ViewFilterDefinitions {
            get {
                return _ScanByVwLprEmployee02ViewFilterDefinitions;
            }
        }
        protected ILpdEmpLastNameView _ScanByVwLprEmployee02ViewEmpLastNameItem = null;
        public ILpdEmpLastNameView ScanByVwLprEmployee02ViewEmpLastNameItem {
            get {
                return _ScanByVwLprEmployee02ViewEmpLastNameItem;
            }
            set {
                if (_ScanByVwLprEmployee02ViewEmpLastNameItem != value) {
                    _ScanByVwLprEmployee02ViewEmpLastNameItem = value;
                    OnPropertyChanged();
                    OnPropertyChanged("ScanByVwLprEmployee02ViewEmpLastNameText");
                }
            }
        }
        protected IList<ILpdEmpLastNameView> _ScanByVwLprEmployee02ViewEmpLastNameItemsSource = null;
        public IList<ILpdEmpLastNameView> ScanByVwLprEmployee02ViewEmpLastNameItemsSource {
            get {
                return _ScanByVwLprEmployee02ViewEmpLastNameItemsSource;
            }
            set {
                if(_ScanByVwLprEmployee02ViewEmpLastNameItemsSource != value) {
                    _ScanByVwLprEmployee02ViewEmpLastNameItemsSource = value;
                    OnPropertyChanged();
                }
            }
        }
        protected string _ScanByVwLprEmployee02ViewEmpLastNameText = null;
        public string ScanByVwLprEmployee02ViewEmpLastNameText {
            get {
                ILpdEmpLastNameView dmObj = ScanByVwLprEmployee02ViewEmpLastNameItem as ILpdEmpLastNameView;
                if(dmObj!= null) {
                    return dmObj.EmpLastName;
                } else {
                    return _ScanByVwLprEmployee02ViewEmpLastNameText;
                }
            }
            set {
                if(_ScanByVwLprEmployee02ViewEmpLastNameText != value) {
                    _ScanByVwLprEmployee02ViewEmpLastNameText = value;
                    OnPropertyChanged();
                }
            }
        }

        protected ILpdEmpFirstNameView _ScanByVwLprEmployee02ViewEmpFirstNameItem = null;
        public ILpdEmpFirstNameView ScanByVwLprEmployee02ViewEmpFirstNameItem {
            get {
                return _ScanByVwLprEmployee02ViewEmpFirstNameItem;
            }
            set {
                if (_ScanByVwLprEmployee02ViewEmpFirstNameItem != value) {
                    _ScanByVwLprEmployee02ViewEmpFirstNameItem = value;
                    OnPropertyChanged();
                    OnPropertyChanged("ScanByVwLprEmployee02ViewEmpFirstNameText");
                }
            }
        }
        protected IList<ILpdEmpFirstNameView> _ScanByVwLprEmployee02ViewEmpFirstNameItemsSource = null;
        public IList<ILpdEmpFirstNameView> ScanByVwLprEmployee02ViewEmpFirstNameItemsSource {
            get {
                return _ScanByVwLprEmployee02ViewEmpFirstNameItemsSource;
            }
            set {
                if(_ScanByVwLprEmployee02ViewEmpFirstNameItemsSource != value) {
                    _ScanByVwLprEmployee02ViewEmpFirstNameItemsSource = value;
                    OnPropertyChanged();
                }
            }
        }
        protected string _ScanByVwLprEmployee02ViewEmpFirstNameText = null;
        public string ScanByVwLprEmployee02ViewEmpFirstNameText {
            get {
                ILpdEmpFirstNameView dmObj = ScanByVwLprEmployee02ViewEmpFirstNameItem as ILpdEmpFirstNameView;
                if(dmObj!= null) {
                    return dmObj.EmpFirstName;
                } else {
                    return _ScanByVwLprEmployee02ViewEmpFirstNameText;
                }
            }
            set {
                if(_ScanByVwLprEmployee02ViewEmpFirstNameText != value) {
                    _ScanByVwLprEmployee02ViewEmpFirstNameText = value;
                    OnPropertyChanged();
                }
            }
        }

        protected ILpdEmpSecondNameView _ScanByVwLprEmployee02ViewEmpSecondNameItem = null;
        public ILpdEmpSecondNameView ScanByVwLprEmployee02ViewEmpSecondNameItem {
            get {
                return _ScanByVwLprEmployee02ViewEmpSecondNameItem;
            }
            set {
                if (_ScanByVwLprEmployee02ViewEmpSecondNameItem != value) {
                    _ScanByVwLprEmployee02ViewEmpSecondNameItem = value;
                    OnPropertyChanged();
                    OnPropertyChanged("ScanByVwLprEmployee02ViewEmpSecondNameText");
                }
            }
        }
        protected IList<ILpdEmpSecondNameView> _ScanByVwLprEmployee02ViewEmpSecondNameItemsSource = null;
        public IList<ILpdEmpSecondNameView> ScanByVwLprEmployee02ViewEmpSecondNameItemsSource {
            get {
                return _ScanByVwLprEmployee02ViewEmpSecondNameItemsSource;
            }
            set {
                if(_ScanByVwLprEmployee02ViewEmpSecondNameItemsSource != value) {
                    _ScanByVwLprEmployee02ViewEmpSecondNameItemsSource = value;
                    OnPropertyChanged();
                }
            }
        }
        protected string _ScanByVwLprEmployee02ViewEmpSecondNameText = null;
        public string ScanByVwLprEmployee02ViewEmpSecondNameText {
            get {
                ILpdEmpSecondNameView dmObj = ScanByVwLprEmployee02ViewEmpSecondNameItem as ILpdEmpSecondNameView;
                if(dmObj!= null) {
                    return dmObj.EmpSecondName;
                } else {
                    return _ScanByVwLprEmployee02ViewEmpSecondNameText;
                }
            }
            set {
                if(_ScanByVwLprEmployee02ViewEmpSecondNameText != value) {
                    _ScanByVwLprEmployee02ViewEmpSecondNameText = value;
                    OnPropertyChanged();
                }
            }
        }


        protected ICommand _ScanByVwLprEmployee02ViewTextChangedCommand = null;
        public ICommand ScanByVwLprEmployee02ViewTextChangedCommand
        {
            get
            {
                return _ScanByVwLprEmployee02ViewTextChangedCommand ?? (_ScanByVwLprEmployee02ViewTextChangedCommand = new Command((prm) => ScanByVwLprEmployee02ViewTextChangedCommandExecute(prm), (prm) => ScanByVwLprEmployee02ViewTextChangedCommandCanExecute(prm)));
            }
        }
        // Reason: UserInput = 0, ProgrammaticChange = 1, SuggestionChosen = 2
        protected async void ScanByVwLprEmployee02ViewTextChangedCommandExecute(object prm)
        {
            if ((IsDsDestroyed) || (prm is null)) return;
            (object Cmpnt, object Sender, IUniqServiceFilterDefInterface FltDef, int Reason, string QueryText) tprm  = ((object Cmpnt, object Sender, IUniqServiceFilterDefInterface FltDef, int Reason, string QueryText))prm;
            if(tprm.Reason != 0) return;
            switch(tprm.FltDef.fltrName) {
                case "EmpLastName":
                    ScanByVwLprEmployee02ViewEmpLastNameItem = null;
                    ScanByVwLprEmployee02ViewEmpLastNameText = tprm.QueryText;
                    {
                        ILpdEmpLastNameViewFilter fltr = FrmSrvLpdEmpLastNameView.GetFilter();
                        fltr.page = 0;
                        fltr.pagesize = 15;
                        fltr.EmpLastName = new List<string>() { tprm.QueryText };
                        fltr.empLastNameOprtr = new List<string>() { "lk" };
                        ILpdEmpLastNameViewPage rslt = await FrmSrvLpdEmpLastNameView.getmanybyrepunqLpdEmpLastNameUK(fltr);
                        if(rslt is null) {
                            ScanByVwLprEmployee02ViewEmpLastNameItemsSource = null;
                        } else {
                            ScanByVwLprEmployee02ViewEmpLastNameItemsSource = rslt.items;
                        }
                    }
                    break;
                case "EmpFirstName":
                    ScanByVwLprEmployee02ViewEmpFirstNameItem = null;
                    ScanByVwLprEmployee02ViewEmpFirstNameText = tprm.QueryText;
                    {
                        ILpdEmpFirstNameViewFilter fltr = FrmSrvLpdEmpFirstNameView.GetFilter();
                        fltr.page = 0;
                        fltr.pagesize = 15;
                        fltr.EmpFirstName = new List<string>() { tprm.QueryText };
                        fltr.empFirstNameOprtr = new List<string>() { "lk" };
                        ILpdEmpFirstNameViewPage rslt = await FrmSrvLpdEmpFirstNameView.getmanybyrepunqLpdEmpFirstNameUK(fltr);
                        if(rslt is null) {
                            ScanByVwLprEmployee02ViewEmpFirstNameItemsSource = null;
                        } else {
                            ScanByVwLprEmployee02ViewEmpFirstNameItemsSource = rslt.items;
                        }
                    }
                    break;
                case "EmpSecondName":
                    ScanByVwLprEmployee02ViewEmpSecondNameItem = null;
                    ScanByVwLprEmployee02ViewEmpSecondNameText = tprm.QueryText;
                    {
                        ILpdEmpSecondNameViewFilter fltr = FrmSrvLpdEmpSecondNameView.GetFilter();
                        fltr.page = 0;
                        fltr.pagesize = 15;
                        fltr.EmpSecondName = new List<string>() { tprm.QueryText };
                        fltr.empSecondNameOprtr = new List<string>() { "lk" };
                        ILpdEmpSecondNameViewPage rslt = await FrmSrvLpdEmpSecondNameView.getmanybyrepunqLpdEmpSecondNameUK(fltr);
                        if(rslt is null) {
                            ScanByVwLprEmployee02ViewEmpSecondNameItemsSource = null;
                        } else {
                            ScanByVwLprEmployee02ViewEmpSecondNameItemsSource = rslt.items;
                        }
                    }
                    break;
                default:
                    break;
            }            
        }
        protected bool ScanByVwLprEmployee02ViewTextChangedCommandCanExecute(object prm)
        {
            return true;
        }

        protected ICommand _ScanByVwLprEmployee02ViewQuerySubmitted = null;
        public ICommand ScanByVwLprEmployee02ViewQuerySubmitted
        {
            get
            {
                return _ScanByVwLprEmployee02ViewQuerySubmitted ?? (_ScanByVwLprEmployee02ViewQuerySubmitted = new Command((prm) => ScanByVwLprEmployee02ViewQuerySubmittedExecute(prm), (prm) => ScanByVwLprEmployee02ViewQuerySubmittedCanExecute(prm)));
            }
        }
        protected void ScanByVwLprEmployee02ViewQuerySubmittedExecute(object prm)
        {
            if ((IsDsDestroyed) || (prm is null)) return;
            (object Cmpnt, object Sender, IUniqServiceFilterDefInterface FltDef, object ChosenSuggestion, string QueryText) tprm  = 
                ((object Cmpnt, object Sender, IUniqServiceFilterDefInterface FltDef, object ChosenSuggestion, string QueryText))prm;
            switch(tprm.FltDef.fltrName) {
                case "EmpLastName":
                    ScanByVwLprEmployee02ViewEmpLastNameItem = tprm.ChosenSuggestion as ILpdEmpLastNameView;
                    ScanByVwLprEmployee02ViewEmpLastNameItemsSource = null;
                    break;
                case "EmpFirstName":
                    ScanByVwLprEmployee02ViewEmpFirstNameItem = tprm.ChosenSuggestion as ILpdEmpFirstNameView;
                    ScanByVwLprEmployee02ViewEmpFirstNameItemsSource = null;
                    break;
                case "EmpSecondName":
                    ScanByVwLprEmployee02ViewEmpSecondNameItem = tprm.ChosenSuggestion as ILpdEmpSecondNameView;
                    ScanByVwLprEmployee02ViewEmpSecondNameItemsSource = null;
                    break;
                default:
                    break;
            }
        }
        protected bool ScanByVwLprEmployee02ViewQuerySubmittedCanExecute(object prm)
        {
            return true;
        }
        protected ICommand _ScanByVwLprEmployee02ViewUnfocusedCommand = null;
        public ICommand ScanByVwLprEmployee02ViewUnfocusedCommand
        {
            get
            {
                return _ScanByVwLprEmployee02ViewUnfocusedCommand ?? (_ScanByVwLprEmployee02ViewUnfocusedCommand = new Command((prm) => ScanByVwLprEmployee02ViewUnfocusedCommandExecute(prm), (prm) => ScanByVwLprEmployee02ViewUnfocusedCommandCanExecute(prm)));
            }
        }
        protected void ScanByVwLprEmployee02ViewUnfocusedCommandExecute(object prm)
        {
            if ((IsDsDestroyed) || (prm is null)) return;
            (object Cmpnt, object Sender, IUniqServiceFilterDefInterface FltDef) tprm  = 
                ((object Cmpnt, object Sender, IUniqServiceFilterDefInterface FltDef))prm;
            switch(tprm.FltDef.fltrName) {
                case "EmpLastName":
                    ScanByVwLprEmployee02ViewEmpLastNameItemsSource = null;
                    break;
                case "EmpFirstName":
                    ScanByVwLprEmployee02ViewEmpFirstNameItemsSource = null;
                    break;
                case "EmpSecondName":
                    ScanByVwLprEmployee02ViewEmpSecondNameItemsSource = null;
                    break;
                default:
                    break;
            }
        }
        protected bool ScanByVwLprEmployee02ViewUnfocusedCommandCanExecute(object prm) {
            return true;
        }


        #endregion
        #region ScanByUkPrimaryFilterDefinitions
        protected IList<IUniqServiceFilterDefInterface> _ScanByUkPrimaryFilterDefinitions =
            new List<IUniqServiceFilterDefInterface>() {
                new UniqServiceFilterDef() { fltrName = "EmployeeId", fltrDispMemb = "EmployeeId", fltrTextMemb = "EmployeeId", fltrCaption = "Id of the Employee", fltrDataType = "int32", fltrMaxLen = null, fltrMin = null, fltrMax = null },
            };
        public IList<IUniqServiceFilterDefInterface> ScanByUkPrimaryFilterDefinitions {
            get {
                return _ScanByUkPrimaryFilterDefinitions;
            }
        }

        protected IPhbkEmployeeView _ScanByUkPrimaryEmployeeIdItem = null;
        public IPhbkEmployeeView ScanByUkPrimaryEmployeeIdItem {
            get {
                return _ScanByUkPrimaryEmployeeIdItem;
            }
            set {
                if (_ScanByUkPrimaryEmployeeIdItem != value) {
                    _ScanByUkPrimaryEmployeeIdItem = value;
                    OnPropertyChanged();
                    OnPropertyChanged("ScanByUkPrimaryEmployeeIdText");
                }
            }
        }
        
        protected IList<IPhbkEmployeeView> _ScanByUkPrimaryItemsSource = null;
        public IList<IPhbkEmployeeView> ScanByUkPrimaryItemsSource {
            get {
                return _ScanByUkPrimaryItemsSource;
            }
            set {
                if(_ScanByUkPrimaryItemsSource != value) {
                    _ScanByUkPrimaryItemsSource = value;
                    OnPropertyChanged();
                }
            }
        }

        protected string _ScanByUkPrimaryEmployeeIdText = null;
        public string ScanByUkPrimaryEmployeeIdText {
            get {
                IPhbkEmployeeView dmObj = ScanByUkPrimaryEmployeeIdItem;
                if(dmObj != null) {
                    return dmObj.EmployeeId.ToString();
                } else {
                    return _ScanByUkPrimaryEmployeeIdText;
                }

            }
            set {
                if(_ScanByUkPrimaryEmployeeIdText != value) {
                    _ScanByUkPrimaryEmployeeIdText = value;
                    OnPropertyChanged();
                }
            }
        }
        protected ICommand _ScanByUkPrimaryTextChangedCommand = null;
        public ICommand ScanByUkPrimaryTextChangedCommand
        {
            get
            {
                return _ScanByUkPrimaryTextChangedCommand ?? (_ScanByUkPrimaryTextChangedCommand = new Command((prm) => ScanByUkPrimaryTextChangedCommandExecute(prm), (prm) => ScanByUkPrimaryTextChangedCommandCanExecute(prm)));
            }
        }
        // Reason: UserInput = 0, ProgrammaticChange = 1, SuggestionChosen = 2
        protected async void ScanByUkPrimaryTextChangedCommandExecute(object prm)
        {
            if ((IsDsDestroyed) || (prm is null)) return;
            (object Cmpnt, object Sender, IUniqServiceFilterDefInterface FltDef, int Reason, string QueryText) tprm  = ((object Cmpnt, object Sender, IUniqServiceFilterDefInterface FltDef, int Reason, string QueryText))prm;
            if(tprm.Reason != 0) return;
            int k = -1;
            switch(tprm.FltDef.fltrName) {
                case "EmployeeId":
                    k = 0;
                    break;
                default:
                    return;
            }
            IPhbkEmployeeView itm = null;
            IPhbkEmployeeViewFilter fltr = FrmRootSrv.GetFilter();
            fltr.page = 0;
            fltr.pagesize = 15;
            bool runQuery = true;
            itm = ScanByUkPrimaryEmployeeIdItem;
            if (k > 0)  { 
                if(itm is null) {
                    runQuery = false;
                } else {
                    fltr.EmployeeId = new List<System.Int32>() { itm.EmployeeId }; 
                    fltr.employeeIdOprtr = new List<string>() { "eq" };
                }
             } else if(k == 0) { 
                ScanByUkPrimaryEmployeeIdItem = null;
                ScanByUkPrimaryEmployeeIdText = tprm.QueryText;
                {
                    System.Int32 val;
                    if (System.Int32.TryParse(tprm.QueryText, out val)) {
                        fltr.EmployeeId = new List<System.Int32>() { val };
                    }
                }
                fltr.employeeIdOprtr = new List<string>() { "lk" };
             }
            if (runQuery) {
                IPhbkEmployeeViewPage rslt = await FrmRootSrv.getmanybyrepprim(fltr);
                if(rslt is null) {
                    ScanByUkPrimaryItemsSource = null;
                } else {
                    ScanByUkPrimaryItemsSource = rslt.items;
                }
            } else {
                ScanByUkPrimaryItemsSource = null;
            }
        }
        protected bool ScanByUkPrimaryTextChangedCommandCanExecute(object prm)
        {
            return true;
        }
        protected ICommand _ScanByUkPrimaryQuerySubmitted = null;
        public ICommand ScanByUkPrimaryQuerySubmitted
        {
            get
            {
                return _ScanByUkPrimaryQuerySubmitted ?? (_ScanByUkPrimaryQuerySubmitted = new Command((prm) => ScanByUkPrimaryQuerySubmittedExecute(prm), (prm) => ScanByUkPrimaryQuerySubmittedCanExecute(prm)));
            }
        }
        protected void ScanByUkPrimaryQuerySubmittedExecute(object prm)
        {
            if ((IsDsDestroyed) || (prm is null)) return;
            (object Cmpnt, object Sender, IUniqServiceFilterDefInterface FltDef, object ChosenSuggestion, string QueryText) tprm  = 
                ((object Cmpnt, object Sender, IUniqServiceFilterDefInterface FltDef, object ChosenSuggestion, string QueryText))prm;
            switch(tprm.FltDef.fltrName) {
                case "EmployeeId":
                    ScanByUkPrimaryEmployeeIdItem = tprm.ChosenSuggestion as IPhbkEmployeeView;
                    break;
                default:
                    return;
            }
            ScanByUkPrimaryItemsSource = null;
        }
        protected bool ScanByUkPrimaryQuerySubmittedCanExecute(object prm) {
            return true;
        }
        protected ICommand _ScanByUkPrimaryUnfocusedCommand = null;
        public ICommand ScanByUkPrimaryUnfocusedCommand
        {
            get
            {
                return _ScanByUkPrimaryUnfocusedCommand ?? (_ScanByUkPrimaryUnfocusedCommand = new Command((prm) => ScanByUkPrimaryUnfocusedCommandExecute(prm), (prm) => ScanByUkPrimaryUnfocusedCommandCanExecute(prm)));
            }
        }
        protected void ScanByUkPrimaryUnfocusedCommandExecute(object prm)
        {
            if ((IsDsDestroyed) || (prm is null)) return;
            ScanByUkPrimaryItemsSource = null;
        }
        protected bool ScanByUkPrimaryUnfocusedCommandCanExecute(object prm) {
            return true;
        }
        #endregion
        #region SearchMethod
        IList<string> mdlDrctFkProps = new List<string>{  "DivisionIdRef" };
        IList<string> mdlMptProps = new List<string>{  "EmployeeId", "EmpFirstName", "EmpLastName", "DivisionIdRef" };
        Dictionary<string, IList<string>> reqHiddenProps = new Dictionary<string, IList<string>>() {
                    {"LprEmployee01View", new List<string> {  }},
                    {"LprEmployee02View", new List<string> {  "DivisionIdRef" }},
        };
        Dictionary<string, IList<string>> extHiddenProps = new Dictionary<string, IList<string>>() {
                    {"LprEmployee01View", new List<string> { }},
                    {"LprEmployee02View", new List<string> { }},
        };
        public void defineSearchMethod() {
            if (IsDsDestroyed) return;
            IList<IWebServiceFilterMenuInterface> timis = defineSearchMethodMenuItemsData();
            if(timis is null) {
                SearchMethod = "NoSearchMethod";
                return;
            }
            if (timis.Any(t => t.Id == SearchMethod)) return;
            if(timis.Count < 1) {
                SearchMethod = "NoSearchMethod";
                return;
            }
            SearchMethod = timis[0].Id;
        }
        public IList<IWebServiceFilterMenuInterface> defineSearchMethodMenuItemsData() {
            if (IsDsDestroyed) return null;
            IList<IWebServiceFilterMenuInterface> rslt = new List<IWebServiceFilterMenuInterface>();
            bool hasNtExternal = true;
            IList<string> extHiddflt = new List<string>();
            foreach(var f in HiddenFiltersVM) {
                if(!mdlMptProps.Contains(f.fltrName)) extHiddflt.Add(f.fltrName);
            }
            hasNtExternal = extHiddflt.Count == 0;
            IList<string> crrMDFP = new List<string>();
            foreach(var fld in mdlDrctFkProps) { 
                if (HiddenFiltersVM.Any(f => f.fltrName == fld)) crrMDFP.Add(fld);
            }
            bool doIns = false;
            doIns = crrMDFP.Count == this.reqHiddenProps["LprEmployee01View"].Count;
            if(doIns) {
                doIns = (this.reqHiddenProps["LprEmployee01View"].Count(s => crrMDFP.Contains(s))) == crrMDFP.Count;
                
                if(doIns) {
                    if(hasNtExternal) {
                        foreach (var fld in this.extHiddenProps["LprEmployee01View"]) { 
                            doIns = this.HiddenFiltersVM.Any(f => f.fltrName == fld);
                            if(!doIns) break;
                        }
                    } else {
                        doIns = extHiddflt.Count == this.extHiddenProps["LprEmployee01View"].Count;
                        if(doIns) doIns = extHiddflt.Count(s => this.extHiddenProps["LprEmployee01View"].Contains(s)) == extHiddflt.Count;
                    }
                }
            }
            if(doIns) {
                rslt.Add( 
                    new WebServiceFilterMenuViewModel() { Id = "ScanByVwLprEmployee01View", Caption="filter by Employee Dict Ref", IconName=IconFont.Refresh, IconColor=Color.Default, Enabled=true, Data=null, Command = TableMenuItemsCommand}
                );
            }
            doIns = crrMDFP.Count == this.reqHiddenProps["LprEmployee02View"].Count;
            if(doIns) {
                doIns = (this.reqHiddenProps["LprEmployee02View"].Count(s => crrMDFP.Contains(s))) == crrMDFP.Count;
                
                if(doIns) {
                    if(hasNtExternal) {
                        foreach (var fld in this.extHiddenProps["LprEmployee02View"]) { 
                            doIns = this.HiddenFiltersVM.Any(f => f.fltrName == fld);
                            if(!doIns) break;
                        }
                    } else {
                        doIns = extHiddflt.Count == this.extHiddenProps["LprEmployee02View"].Count;
                        if(doIns) doIns = extHiddflt.Count(s => this.extHiddenProps["LprEmployee02View"].Contains(s)) == extHiddflt.Count;
                    }
                }
            }
            if(doIns) {
                rslt.Add( 
                    new WebServiceFilterMenuViewModel() { Id = "ScanByVwLprEmployee02View", Caption="filter by Employee Dict Ref", IconName=IconFont.Refresh, IconColor=Color.Default, Enabled=true, Data=null, Command = TableMenuItemsCommand}
                );
            }
            if(hasNtExternal) {
                IList<string> reqFkPrps = new List<string>{};
                if(this.HiddenFiltersVM.Count() == reqFkPrps.Count) {
                    bool insmi = true;
                    foreach(var vmfn in reqFkPrps) {
                        if(! HiddenFiltersVM.Any(hfp => vmfn == hfp.fltrName)) {
                            insmi = false;
                            break;
                        }
                    }
                    if(insmi) {
                        rslt.Add( 
                            new WebServiceFilterMenuViewModel() { Id = "ScanByUkPrimary", Caption="filter by Primary", IconName=IconFont.Refresh, IconColor=Color.Default, Enabled=true, Data=null, Command = TableMenuItemsCommand}
                        );
                    }
                }
            }

            if(hasNtExternal && this.CnFllscn) {
                rslt.Insert(
                    0, new WebServiceFilterMenuViewModel() { Id = "FullScan", Caption="full scan", IconName=IconFont.Refresh, IconColor=Color.Default, Enabled=true, Data=null, Command = TableMenuItemsCommand}
                );
            }
            return rslt;
        }
        #endregion
    }
}

