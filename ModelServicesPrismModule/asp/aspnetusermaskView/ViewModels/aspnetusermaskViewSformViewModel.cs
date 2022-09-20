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
using ModelInterfacesClassLibrary.interfaces.asp.aspnetusermaskView;
using CommonInterfacesClassLibrary.AppGlblSettingsSrvc;
using CommonUserControlLibrary.UserControls;
using CommonCustomControlLibrary.Fonts;
using CommonUserControlLibrary.Classes;
using CommonCustomControlLibrary.Classes;
/*

    "AspnetusermaskViewSformUserControl" UserControl is defined in the "ModelServicesPrismModule"-project.
    In the file of IModule-class of "ModelServicesPrismModule"-project the following line of code must be inserted:

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ...
            // According to requirements of the "AspnetusermaskViewSformViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            ViewModelLocationProvider.Register<AspnetusermaskViewSformUserControl, AspnetusermaskViewSformViewModel>();
            // According to requirements of the "AspnetusermaskViewSformViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            containerRegistry.Register<ContentView, AspnetusermaskViewSformUserControl>("AspnetusermaskViewSformUserControl");
            ...
        }

*/

namespace ModelServicesPrismModule.asp.aspnetusermaskView.ViewModels {
    public class AspnetusermaskViewSformViewModel: INotifyPropertyChanged, ISformViewModelInterface, IBindingContextChanged, IDestructible
    {
        protected IAspnetusermaskViewService FrmRootSrv=null;
        protected IAppGlblSettingsService GlblSettingsSrv=null;
        protected IDialogService _dialogService=null;
    

        bool CnFllscn = false;
        public AspnetusermaskViewSformViewModel(IAppGlblSettingsService GlblSettingsSrv, IAspnetusermaskViewService FrmRootSrv, 
    
            IDialogService dialogService) {
            this.GlblSettingsSrv = GlblSettingsSrv;
            this.FrmRootSrv = FrmRootSrv;
            this._dialogService = dialogService;
    
            _TableMenuItemsVM = GetDefaultTableMenuItemsVM();
            CnFllscn = (GlblSettingsSrv.GetViewModelMask("aspnetusermaskView") & 16) == 16;
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
        protected IEnumerable<IAspnetusermaskView> _DataSource = new ObservableCollection<IAspnetusermaskView>();
        public IEnumerable<IAspnetusermaskView> DataSource
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
                Name= "UEmail", 
                Caption= "User Email", 
                IsChecked= true
            }, 
            new ColumnSelectorItemDefViewModel() {
                Name= "UUserName", 
                Caption= "User Name", 
                IsChecked= true
            }, 
            new ColumnSelectorItemDefViewModel() {
                Name= "MModelName", 
                Caption= "Model Name", 
                IsChecked= true
            }, 
            new ColumnSelectorItemDefViewModel() {
                Name= "Mask1", 
                Caption= "Permission to Sel", 
                IsChecked= true
            }, 
            new ColumnSelectorItemDefViewModel() {
                Name= "Mask2", 
                Caption= "Permission to Del", 
                IsChecked= true
            }, 
            new ColumnSelectorItemDefViewModel() {
                Name= "Mask3", 
                Caption= "Permission to Upd", 
                IsChecked= true
            }, 
            new ColumnSelectorItemDefViewModel() {
                Name= "Mask4", 
                Caption= "Permission to Add", 
                IsChecked= true
            }, 
            new ColumnSelectorItemDefViewModel() {
                Name= "Mask5", 
                Caption= "Full scan permission", 
                IsChecked= true
            }, 
            new ColumnSelectorItemDefViewModel() {
                Name= "UserId", 
                Caption= "User Id", 
                IsChecked= false
            }, 
            new ColumnSelectorItemDefViewModel() {
                Name= "ModelPkRef", 
                Caption= "Model Id", 
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
                    new WebServiceFilterDefViewModel() {fltrName="UserId", fltrCaption="User Id",  fltrDataType="string", fltrMaxLen=128, fltrMin=null, fltrMax=null },
                };
            bool isDsbl = true;
            if (this.HiddenFiltersVM != null) {
                isDsbl = isDsbl && this.HiddenFiltersVM.Any(v => v.fltrName == "UserId");
            } else isDsbl = false;
            if(!isDsbl) {
            }
            isDsbl = true;
            if (this.HiddenFiltersVM != null) {
                isDsbl = isDsbl && this.HiddenFiltersVM.Any(v => v.fltrName == "ModelPkRef");
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
                                            new WebServiceFilterDefViewModel() {fltrName="UserId", fltrCaption="User Id",  fltrDataType="string", fltrMaxLen=128, fltrMin=null, fltrMax=null },
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
                DataSource = new ObservableCollection<IAspnetusermaskView>();
                SelectedRow = null;
                IsInQuery = false;
                return;
            }


            if ((SearchMethod == "FullScan")
            ) {

                IAspnetusermaskViewFilter flt  = FrmRootSrv.GetFilter();
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
                            case "UserId":
                                if (flt.UserId == null) flt.UserId = new List<System.String>();
                                flt.UserId.Add((System.String)e.fltrValue);
                                if (flt.userIdOprtr == null) flt.userIdOprtr = new List<string>();
                                flt.userIdOprtr.Add(e.fltrOperator);
                                break;
                            default: break;
                        }
                    }
                }
                IaspnetusermaskViewPage rslt = await this.FrmRootSrv.getwithfilter(flt);
                if(rslt != null) {
                    // RowsPerPage resets CurrentPage 
                    // so the order is important: ActualRowsPerPage must be the first one and ActualCurrentPage must be the second
                    ActualRowsPerPage = rslt.pagesize;
                    ActualCurrentPage = rslt.page;
                    TotalCount = rslt.total; 
                    SelectedRow = null;
                    ObservableCollection<IAspnetusermaskView> ds = DataSource as ObservableCollection<IAspnetusermaskView>;
                    IsDsDestroyed = true;
                    if (ds == null) { ds = new ObservableCollection<IAspnetusermaskView>(); } else { ds.Clear(); }
                    IsDsDestroyed = false;
                    DataSource = null; 
                    if(rslt.items != null) {
                        foreach(IAspnetusermaskView itm in rslt.items) {
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
            IAspnetusermaskView prm = item as  IAspnetusermaskView;
            if(prm == null) return;
            ObservableCollection<IAspnetusermaskView> ds = DataSource as ObservableCollection<IAspnetusermaskView>;
            ds.Add(FrmRootSrv.CopyToModelNotify(prm, null));
            InternalContentChanged();
        }
        #endregion
        #region SformAfterUpdItemCommand
        public void SformAfterUpdItemCommand(object sender, object item) {
            IAspnetusermaskView prm = item as  IAspnetusermaskView;
            if(prm == null) return;
            ObservableCollection<IAspnetusermaskView> ds = DataSource as ObservableCollection<IAspnetusermaskView>;
            if (ds.IndexOf(prm) > -1) {
                return;
            }
            IAspnetusermaskView rw = ds.Where(d => 
                        (d.UserId == prm.UserId)
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
            IAspnetusermaskView prm = item as  IAspnetusermaskView;
            if(prm == null) return;
            ObservableCollection<IAspnetusermaskView> ds = DataSource as ObservableCollection<IAspnetusermaskView>;
            int indx = ds.IndexOf(prm);
            if (indx > -1) {
                ds.RemoveAt(indx);
                InternalContentChanged();
                return;
            }
            IAspnetusermaskView rw = ds.Where(d => 
                        (d.UserId == prm.UserId)
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

        #region SearchMethod
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

