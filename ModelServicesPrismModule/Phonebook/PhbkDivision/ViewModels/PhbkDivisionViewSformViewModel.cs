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
using ModelInterfacesClassLibrary.Phonebook.PhbkDivision;
using CommonInterfacesClassLibrary.AppGlblSettingsSrvc;
using CommonUserControlLibrary.UserControls;
using CommonCustomControlLibrary.Fonts;
using CommonUserControlLibrary.Classes;
using CommonCustomControlLibrary.Classes;
using ModelInterfacesClassLibrary.Phonebook.LprDivision01;
using ModelInterfacesClassLibrary.Phonebook.LpdDivision;
using ModelInterfacesClassLibrary.Phonebook.LprDivision02;
/*

    "PhbkDivisionViewSformUserControl" UserControl is defined in the "ModelServicesPrismModule"-project.
    In the file of IModule-class of "ModelServicesPrismModule"-project the following line of code must be inserted:

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ...
            // According to requirements of the "PhbkDivisionViewSformViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            ViewModelLocationProvider.Register<PhbkDivisionViewSformUserControl, PhbkDivisionViewSformViewModel>();
            // According to requirements of the "PhbkDivisionViewSformViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            containerRegistry.Register<ContentView, PhbkDivisionViewSformUserControl>("PhbkDivisionViewSformUserControl");
            ...
        }

*/

namespace ModelServicesPrismModule.Phonebook.PhbkDivision.ViewModels {
    public class PhbkDivisionViewSformViewModel: INotifyPropertyChanged, ISformViewModelInterface, IBindingContextChanged, IDestructible
    {
        protected IPhbkDivisionViewService FrmRootSrv=null;
        protected IAppGlblSettingsService GlblSettingsSrv=null;
        protected IDialogService _dialogService=null;
        protected ILprDivision01ViewService FrmSrvLprDivision01View;
        protected ILpdDivisionViewService FrmSrvLpdDivisionView;
        protected ILprDivision02ViewService FrmSrvLprDivision02View;
    

        bool CnFllscn = false;
        public PhbkDivisionViewSformViewModel(IAppGlblSettingsService GlblSettingsSrv, IPhbkDivisionViewService FrmRootSrv, 
                ILprDivision01ViewService FrmSrvLprDivision01View,
                ILpdDivisionViewService FrmSrvLpdDivisionView,
                ILprDivision02ViewService FrmSrvLprDivision02View,
    
            IDialogService dialogService) {
            this.GlblSettingsSrv = GlblSettingsSrv;
            this.FrmRootSrv = FrmRootSrv;
            this._dialogService = dialogService;
                this.FrmSrvLprDivision01View = FrmSrvLprDivision01View;
                this.FrmSrvLpdDivisionView = FrmSrvLpdDivisionView;
                this.FrmSrvLprDivision02View = FrmSrvLprDivision02View;
    
            _TableMenuItemsVM = GetDefaultTableMenuItemsVM();
            CnFllscn = (GlblSettingsSrv.GetViewModelMask("PhbkDivisionView") & 16) == 16;
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
        protected IEnumerable<IPhbkDivisionView> _DataSource = new ObservableCollection<IPhbkDivisionView>();
        public IEnumerable<IPhbkDivisionView> DataSource
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
                Name= "DivisionId", 
                Caption= "Id of the Division", 
                IsChecked= true
            }, 
            new ColumnSelectorItemDefViewModel() {
                Name= "DivisionName", 
                Caption= "Name of the Division", 
                IsChecked= true
            }, 
            new ColumnSelectorItemDefViewModel() {
                Name= "EEntrprsName", 
                Caption= "Name of the Enterprise", 
                IsChecked= true
            }, 
            new ColumnSelectorItemDefViewModel() {
                Name= "DivisionDesc", 
                Caption= "Description of the Division", 
                IsChecked= false
            }, 
            new ColumnSelectorItemDefViewModel() {
                Name= "EntrprsIdRef", 
                Caption= "Id of the Enterprise", 
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
                    new WebServiceFilterDefViewModel() {fltrName="DivisionId", fltrCaption="Id of the Division",  fltrDataType="int32", fltrMaxLen=null, fltrMin=null, fltrMax=null },
                    new WebServiceFilterDefViewModel() {fltrName="DivisionName", fltrCaption="Name of the Division",  fltrDataType="string", fltrMaxLen=20, fltrMin=null, fltrMax=null },
                    new WebServiceFilterDefViewModel() {fltrName="EntrprsIdRef", fltrCaption="Id of the Enterprise",  fltrDataType="int32", fltrMaxLen=null, fltrMin=null, fltrMax=null },
                };
            bool isDsbl = true;
            if (this.HiddenFiltersVM != null) {
                isDsbl = isDsbl && this.HiddenFiltersVM.Any(v => v.fltrName == "EntrprsIdRef");
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
                                            new WebServiceFilterDefViewModel() {fltrName="DivisionId", fltrCaption="Id of the Division",  fltrDataType="int32", fltrMaxLen=null, fltrMin=null, fltrMax=null },
                                            new WebServiceFilterDefViewModel() {fltrName="DivisionName", fltrCaption="Name of the Division",  fltrDataType="string", fltrMaxLen=20, fltrMin=null, fltrMax=null },
                                            new WebServiceFilterDefViewModel() {fltrName="EntrprsIdRef", fltrCaption="Id of the Enterprise",  fltrDataType="int32", fltrMaxLen=null, fltrMin=null, fltrMax=null },
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
                DataSource = new ObservableCollection<IPhbkDivisionView>();
                SelectedRow = null;
                IsInQuery = false;
                return;
            }

            switch (SearchMethod) {
                case "ScanByVwLprDivision01View":  
                    await SrchDoSlctRwLprDivision01View();
                    IsInQuery = false;
                    return;
                case "ScanByVwLprDivision02View":  
                    await SrchDoSlctRwLprDivision02View();
                    IsInQuery = false;
                    return;
            }

            if ((SearchMethod == "FullScan")
                || (SearchMethod == "ScanByUkPrimary")
            ) {

                IPhbkDivisionViewFilter flt  = FrmRootSrv.GetFilter();
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
                            case "DivisionId":
                                if (flt.DivisionId == null) flt.DivisionId = new List<System.Int32>();
                                flt.DivisionId.Add((System.Int32)e.fltrValue);
                                if (flt.divisionIdOprtr == null) flt.divisionIdOprtr = new List<string>();
                                flt.divisionIdOprtr.Add(e.fltrOperator);
                                break;
                            case "DivisionName":
                                if (flt.DivisionName == null) flt.DivisionName = new List<System.String>();
                                flt.DivisionName.Add((System.String)e.fltrValue);
                                if (flt.divisionNameOprtr == null) flt.divisionNameOprtr = new List<string>();
                                flt.divisionNameOprtr.Add(e.fltrOperator);
                                break;
                            case "EntrprsIdRef":
                                if (flt.EntrprsIdRef == null) flt.EntrprsIdRef = new List<System.Int32>();
                                flt.EntrprsIdRef.Add((System.Int32)e.fltrValue);
                                if (flt.entrprsIdRefOprtr == null) flt.entrprsIdRefOprtr = new List<string>();
                                flt.entrprsIdRefOprtr.Add(e.fltrOperator);
                                break;
                            default: break;
                        }
                    }
                }
                IPhbkDivisionViewPage rslt = await this.FrmRootSrv.getwithfilter(flt);
                if(rslt != null) {
                    // RowsPerPage resets CurrentPage 
                    // so the order is important: ActualRowsPerPage must be the first one and ActualCurrentPage must be the second
                    ActualRowsPerPage = rslt.pagesize;
                    ActualCurrentPage = rslt.page;
                    TotalCount = rslt.total; 
                    SelectedRow = null;
                    ObservableCollection<IPhbkDivisionView> ds = DataSource as ObservableCollection<IPhbkDivisionView>;
                    IsDsDestroyed = true;
                    if (ds == null) { ds = new ObservableCollection<IPhbkDivisionView>(); } else { ds.Clear(); }
                    IsDsDestroyed = false;
                    DataSource = null; 
                    if(rslt.items != null) {
                        foreach(IPhbkDivisionView itm in rslt.items) {
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
            IPhbkDivisionView prm = item as  IPhbkDivisionView;
            if(prm == null) return;
            ObservableCollection<IPhbkDivisionView> ds = DataSource as ObservableCollection<IPhbkDivisionView>;
            ds.Add(FrmRootSrv.CopyToModelNotify(prm, null));
            InternalContentChanged();
        }
        #endregion
        #region SformAfterUpdItemCommand
        public void SformAfterUpdItemCommand(object sender, object item) {
            IPhbkDivisionView prm = item as  IPhbkDivisionView;
            if(prm == null) return;
            ObservableCollection<IPhbkDivisionView> ds = DataSource as ObservableCollection<IPhbkDivisionView>;
            if (ds.IndexOf(prm) > -1) {
                return;
            }
            IPhbkDivisionView rw = ds.Where(d => 
                        (d.DivisionId == prm.DivisionId)
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
            IPhbkDivisionView prm = item as  IPhbkDivisionView;
            if(prm == null) return;
            ObservableCollection<IPhbkDivisionView> ds = DataSource as ObservableCollection<IPhbkDivisionView>;
            int indx = ds.IndexOf(prm);
            if (indx > -1) {
                ds.RemoveAt(indx);
                InternalContentChanged();
                return;
            }
            IPhbkDivisionView rw = ds.Where(d => 
                        (d.DivisionId == prm.DivisionId)
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

        #region ScanByVwLprDivision01ViewFilterDefinitions
        protected async Task SrchDoSlctRwLprDivision01View() {
            ILprDivision01ViewFilter dtlflt = FrmSrvLprDivision01View.GetFilter();
            dtlflt.page = this.CurrentPage; 
            dtlflt.pagesize = this.RowsPerPage;
            bool isFltSet = true;
            if(isFltSet) {
                if (ScanByVwLprDivision01ViewDivisionNameItem is null) {  
                    isFltSet = false;
                } else {
                    IList<IWebServiceFilterRsltInterface> dfltrslt = 
                        FrmSrvLprDivision01View.getHiddenFilterAsFltRslt(this.FrmSrvLpdDivisionView.getHiddenFilterByRow(ScanByVwLprDivision01ViewDivisionNameItem, "DivisionNameDict"));
                    if (dfltrslt is null) {
                        isFltSet = false;
                    } else {
                        FrmSrvLprDivision01View.FilterRslt2Filter(dfltrslt, dtlflt);
                    } 
                } 
            }
            if(!isFltSet) {
                GlblSettingsSrv.ShowErrorMessage("http", "Could not apply filter as not all attributes are set");
            }
            // by requirements all common foreignkey props have the same names for LprDivision01View and PhbkDivisionView
            foreach(var fld in reqHiddenProps["LprDivision01View"]) { 
                IWebServiceFilterRsltInterface hf = this.HiddenFiltersVM.FirstOrDefault(f => f.fltrName == fld);
                if(!(hf is null)) {
                    FrmSrvLprDivision01View.FilterRslt2Filter(hf, dtlflt);
                }
            }
            foreach(var fld in extHiddenProps["LprDivision01View"]) { 
                IWebServiceFilterRsltInterface hf = this.HiddenFiltersVM.FirstOrDefault(f => f.fltrName == fld);
                if(!(hf is null)) {
                    FrmSrvLprDivision01View.FilterRslt2Filter(hf, dtlflt);
                }
            }
            ILprDivision01ViewPage vd = await FrmSrvLprDivision01View.getmanybyrepprim(dtlflt);
            if(vd is null) {
                ClearDataSource();
                DataSource = new ObservableCollection<IPhbkDivisionView>();
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
                DataSource = new ObservableCollection<IPhbkDivisionView>();
                SelectedRow = null;
                return;
            }
            if(vd.items.Count < 1) {
                ClearDataSource();
                DataSource = new ObservableCollection<IPhbkDivisionView>();
                SelectedRow = null;
                return;
            }
            IPhbkDivisionViewFilter flt = FrmRootSrv.GetFilter();
            flt.page = 0;
            flt.pagesize = ActualCurrentPage;
            foreach(var src in vd.items) {
                // primary keys are identical for LprDivision01View and PhbkDivisionView
                FrmRootSrv.FilterRslt2Filter(FrmSrvLprDivision01View.RowPrim2FilterRslt(src), flt);
            }
            IPhbkDivisionViewPage rslt = await this.FrmRootSrv.getmanybyrepprim(flt);
            if(rslt != null) {
                // RowsPerPage resets CurrentPage 
                // so the order is important: ActualRowsPerPage must be the first one and ActualCurrentPage must be the second
                ActualRowsPerPage = rslt.pagesize;
                ActualCurrentPage = rslt.page;
                TotalCount = rslt.total; 
                SelectedRow = null;
                ObservableCollection<IPhbkDivisionView> ds = DataSource as ObservableCollection<IPhbkDivisionView>;
                IsDsDestroyed = true;
                if (ds == null) { ds = new ObservableCollection<IPhbkDivisionView>(); } else { ds.Clear(); }
                IsDsDestroyed = false;
                DataSource = null; 
                if(rslt.items != null) {
                    foreach(IPhbkDivisionView itm in rslt.items) {
                        ds.Add(FrmRootSrv.CopyToModelNotify(itm, null));
                    }
                }
                DataSource = ds;
                SelectedRow = DataSource?.FirstOrDefault();
            } else {
                ClearDataSource();
                DataSource = new ObservableCollection<IPhbkDivisionView>();
                SelectedRow = null;
            }
        }
        protected IList<IUniqServiceFilterDefInterface> _ScanByVwLprDivision01ViewFilterDefinitions = 
            new List<IUniqServiceFilterDefInterface>() {
                new UniqServiceFilterDef() { fltrName = "DivisionName", fltrDispMemb = "DivisionName", fltrTextMemb = "DivisionName", fltrCaption = "Name of the Division", fltrDataType = "string", fltrMaxLen = 20, fltrMin = null, fltrMax = null },
            };
        public IList<IUniqServiceFilterDefInterface> ScanByVwLprDivision01ViewFilterDefinitions {
            get {
                return _ScanByVwLprDivision01ViewFilterDefinitions;
            }
        }
        protected ILpdDivisionView _ScanByVwLprDivision01ViewDivisionNameItem = null;
        public ILpdDivisionView ScanByVwLprDivision01ViewDivisionNameItem {
            get {
                return _ScanByVwLprDivision01ViewDivisionNameItem;
            }
            set {
                if (_ScanByVwLprDivision01ViewDivisionNameItem != value) {
                    _ScanByVwLprDivision01ViewDivisionNameItem = value;
                    OnPropertyChanged();
                    OnPropertyChanged("ScanByVwLprDivision01ViewDivisionNameText");
                }
            }
        }
        protected IList<ILpdDivisionView> _ScanByVwLprDivision01ViewDivisionNameItemsSource = null;
        public IList<ILpdDivisionView> ScanByVwLprDivision01ViewDivisionNameItemsSource {
            get {
                return _ScanByVwLprDivision01ViewDivisionNameItemsSource;
            }
            set {
                if(_ScanByVwLprDivision01ViewDivisionNameItemsSource != value) {
                    _ScanByVwLprDivision01ViewDivisionNameItemsSource = value;
                    OnPropertyChanged();
                }
            }
        }
        protected string _ScanByVwLprDivision01ViewDivisionNameText = null;
        public string ScanByVwLprDivision01ViewDivisionNameText {
            get {
                ILpdDivisionView dmObj = ScanByVwLprDivision01ViewDivisionNameItem as ILpdDivisionView;
                if(dmObj!= null) {
                    return dmObj.DivisionName;
                } else {
                    return _ScanByVwLprDivision01ViewDivisionNameText;
                }
            }
            set {
                if(_ScanByVwLprDivision01ViewDivisionNameText != value) {
                    _ScanByVwLprDivision01ViewDivisionNameText = value;
                    OnPropertyChanged();
                }
            }
        }


        protected ICommand _ScanByVwLprDivision01ViewTextChangedCommand = null;
        public ICommand ScanByVwLprDivision01ViewTextChangedCommand
        {
            get
            {
                return _ScanByVwLprDivision01ViewTextChangedCommand ?? (_ScanByVwLprDivision01ViewTextChangedCommand = new Command((prm) => ScanByVwLprDivision01ViewTextChangedCommandExecute(prm), (prm) => ScanByVwLprDivision01ViewTextChangedCommandCanExecute(prm)));
            }
        }
        // Reason: UserInput = 0, ProgrammaticChange = 1, SuggestionChosen = 2
        protected async void ScanByVwLprDivision01ViewTextChangedCommandExecute(object prm)
        {
            if ((IsDsDestroyed) || (prm is null)) return;
            (object Cmpnt, object Sender, IUniqServiceFilterDefInterface FltDef, int Reason, string QueryText) tprm  = ((object Cmpnt, object Sender, IUniqServiceFilterDefInterface FltDef, int Reason, string QueryText))prm;
            if(tprm.Reason != 0) return;
            switch(tprm.FltDef.fltrName) {
                case "DivisionName":
                    ScanByVwLprDivision01ViewDivisionNameItem = null;
                    ScanByVwLprDivision01ViewDivisionNameText = tprm.QueryText;
                    {
                        ILpdDivisionViewFilter fltr = FrmSrvLpdDivisionView.GetFilter();
                        fltr.page = 0;
                        fltr.pagesize = 15;
                        fltr.DivisionName = new List<string>() { tprm.QueryText };
                        fltr.divisionNameOprtr = new List<string>() { "lk" };
                        ILpdDivisionViewPage rslt = await FrmSrvLpdDivisionView.getmanybyrepunqLpdDivisionNameUk(fltr);
                        if(rslt is null) {
                            ScanByVwLprDivision01ViewDivisionNameItemsSource = null;
                        } else {
                            ScanByVwLprDivision01ViewDivisionNameItemsSource = rslt.items;
                        }
                    }
                    break;
                default:
                    break;
            }            
        }
        protected bool ScanByVwLprDivision01ViewTextChangedCommandCanExecute(object prm)
        {
            return true;
        }

        protected ICommand _ScanByVwLprDivision01ViewQuerySubmitted = null;
        public ICommand ScanByVwLprDivision01ViewQuerySubmitted
        {
            get
            {
                return _ScanByVwLprDivision01ViewQuerySubmitted ?? (_ScanByVwLprDivision01ViewQuerySubmitted = new Command((prm) => ScanByVwLprDivision01ViewQuerySubmittedExecute(prm), (prm) => ScanByVwLprDivision01ViewQuerySubmittedCanExecute(prm)));
            }
        }
        protected void ScanByVwLprDivision01ViewQuerySubmittedExecute(object prm)
        {
            if ((IsDsDestroyed) || (prm is null)) return;
            (object Cmpnt, object Sender, IUniqServiceFilterDefInterface FltDef, object ChosenSuggestion, string QueryText) tprm  = 
                ((object Cmpnt, object Sender, IUniqServiceFilterDefInterface FltDef, object ChosenSuggestion, string QueryText))prm;
            switch(tprm.FltDef.fltrName) {
                case "DivisionName":
                    ScanByVwLprDivision01ViewDivisionNameItem = tprm.ChosenSuggestion as ILpdDivisionView;
                    ScanByVwLprDivision01ViewDivisionNameItemsSource = null;
                    break;
                default:
                    break;
            }
        }
        protected bool ScanByVwLprDivision01ViewQuerySubmittedCanExecute(object prm)
        {
            return true;
        }
        protected ICommand _ScanByVwLprDivision01ViewUnfocusedCommand = null;
        public ICommand ScanByVwLprDivision01ViewUnfocusedCommand
        {
            get
            {
                return _ScanByVwLprDivision01ViewUnfocusedCommand ?? (_ScanByVwLprDivision01ViewUnfocusedCommand = new Command((prm) => ScanByVwLprDivision01ViewUnfocusedCommandExecute(prm), (prm) => ScanByVwLprDivision01ViewUnfocusedCommandCanExecute(prm)));
            }
        }
        protected void ScanByVwLprDivision01ViewUnfocusedCommandExecute(object prm)
        {
            if ((IsDsDestroyed) || (prm is null)) return;
            (object Cmpnt, object Sender, IUniqServiceFilterDefInterface FltDef) tprm  = 
                ((object Cmpnt, object Sender, IUniqServiceFilterDefInterface FltDef))prm;
            switch(tprm.FltDef.fltrName) {
                case "DivisionName":
                    ScanByVwLprDivision01ViewDivisionNameItemsSource = null;
                    break;
                default:
                    break;
            }
        }
        protected bool ScanByVwLprDivision01ViewUnfocusedCommandCanExecute(object prm) {
            return true;
        }


        #endregion
        #region ScanByVwLprDivision02ViewFilterDefinitions
        protected async Task SrchDoSlctRwLprDivision02View() {
            ILprDivision02ViewFilter dtlflt = FrmSrvLprDivision02View.GetFilter();
            dtlflt.page = this.CurrentPage; 
            dtlflt.pagesize = this.RowsPerPage;
            bool isFltSet = true;
            if(isFltSet) {
                if (ScanByVwLprDivision02ViewDivisionNameItem is null) {  
                    isFltSet = false;
                } else {
                    IList<IWebServiceFilterRsltInterface> dfltrslt = 
                        FrmSrvLprDivision02View.getHiddenFilterAsFltRslt(this.FrmSrvLpdDivisionView.getHiddenFilterByRow(ScanByVwLprDivision02ViewDivisionNameItem, "DivisionNameDict"));
                    if (dfltrslt is null) {
                        isFltSet = false;
                    } else {
                        FrmSrvLprDivision02View.FilterRslt2Filter(dfltrslt, dtlflt);
                    } 
                } 
            }
            if(!isFltSet) {
                GlblSettingsSrv.ShowErrorMessage("http", "Could not apply filter as not all attributes are set");
            }
            // by requirements all common foreignkey props have the same names for LprDivision02View and PhbkDivisionView
            foreach(var fld in reqHiddenProps["LprDivision02View"]) { 
                IWebServiceFilterRsltInterface hf = this.HiddenFiltersVM.FirstOrDefault(f => f.fltrName == fld);
                if(!(hf is null)) {
                    FrmSrvLprDivision02View.FilterRslt2Filter(hf, dtlflt);
                }
            }
            foreach(var fld in extHiddenProps["LprDivision02View"]) { 
                IWebServiceFilterRsltInterface hf = this.HiddenFiltersVM.FirstOrDefault(f => f.fltrName == fld);
                if(!(hf is null)) {
                    FrmSrvLprDivision02View.FilterRslt2Filter(hf, dtlflt);
                }
            }
            ILprDivision02ViewPage vd = await FrmSrvLprDivision02View.getmanybyrepprim(dtlflt);
            if(vd is null) {
                ClearDataSource();
                DataSource = new ObservableCollection<IPhbkDivisionView>();
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
                DataSource = new ObservableCollection<IPhbkDivisionView>();
                SelectedRow = null;
                return;
            }
            if(vd.items.Count < 1) {
                ClearDataSource();
                DataSource = new ObservableCollection<IPhbkDivisionView>();
                SelectedRow = null;
                return;
            }
            IPhbkDivisionViewFilter flt = FrmRootSrv.GetFilter();
            flt.page = 0;
            flt.pagesize = ActualCurrentPage;
            foreach(var src in vd.items) {
                // primary keys are identical for LprDivision02View and PhbkDivisionView
                FrmRootSrv.FilterRslt2Filter(FrmSrvLprDivision02View.RowPrim2FilterRslt(src), flt);
            }
            IPhbkDivisionViewPage rslt = await this.FrmRootSrv.getmanybyrepprim(flt);
            if(rslt != null) {
                // RowsPerPage resets CurrentPage 
                // so the order is important: ActualRowsPerPage must be the first one and ActualCurrentPage must be the second
                ActualRowsPerPage = rslt.pagesize;
                ActualCurrentPage = rslt.page;
                TotalCount = rslt.total; 
                SelectedRow = null;
                ObservableCollection<IPhbkDivisionView> ds = DataSource as ObservableCollection<IPhbkDivisionView>;
                IsDsDestroyed = true;
                if (ds == null) { ds = new ObservableCollection<IPhbkDivisionView>(); } else { ds.Clear(); }
                IsDsDestroyed = false;
                DataSource = null; 
                if(rslt.items != null) {
                    foreach(IPhbkDivisionView itm in rslt.items) {
                        ds.Add(FrmRootSrv.CopyToModelNotify(itm, null));
                    }
                }
                DataSource = ds;
                SelectedRow = DataSource?.FirstOrDefault();
            } else {
                ClearDataSource();
                DataSource = new ObservableCollection<IPhbkDivisionView>();
                SelectedRow = null;
            }
        }
        protected IList<IUniqServiceFilterDefInterface> _ScanByVwLprDivision02ViewFilterDefinitions = 
            new List<IUniqServiceFilterDefInterface>() {
                new UniqServiceFilterDef() { fltrName = "DivisionName", fltrDispMemb = "DivisionName", fltrTextMemb = "DivisionName", fltrCaption = "Name of the Division", fltrDataType = "string", fltrMaxLen = 20, fltrMin = null, fltrMax = null },
            };
        public IList<IUniqServiceFilterDefInterface> ScanByVwLprDivision02ViewFilterDefinitions {
            get {
                return _ScanByVwLprDivision02ViewFilterDefinitions;
            }
        }
        protected ILpdDivisionView _ScanByVwLprDivision02ViewDivisionNameItem = null;
        public ILpdDivisionView ScanByVwLprDivision02ViewDivisionNameItem {
            get {
                return _ScanByVwLprDivision02ViewDivisionNameItem;
            }
            set {
                if (_ScanByVwLprDivision02ViewDivisionNameItem != value) {
                    _ScanByVwLprDivision02ViewDivisionNameItem = value;
                    OnPropertyChanged();
                    OnPropertyChanged("ScanByVwLprDivision02ViewDivisionNameText");
                }
            }
        }
        protected IList<ILpdDivisionView> _ScanByVwLprDivision02ViewDivisionNameItemsSource = null;
        public IList<ILpdDivisionView> ScanByVwLprDivision02ViewDivisionNameItemsSource {
            get {
                return _ScanByVwLprDivision02ViewDivisionNameItemsSource;
            }
            set {
                if(_ScanByVwLprDivision02ViewDivisionNameItemsSource != value) {
                    _ScanByVwLprDivision02ViewDivisionNameItemsSource = value;
                    OnPropertyChanged();
                }
            }
        }
        protected string _ScanByVwLprDivision02ViewDivisionNameText = null;
        public string ScanByVwLprDivision02ViewDivisionNameText {
            get {
                ILpdDivisionView dmObj = ScanByVwLprDivision02ViewDivisionNameItem as ILpdDivisionView;
                if(dmObj!= null) {
                    return dmObj.DivisionName;
                } else {
                    return _ScanByVwLprDivision02ViewDivisionNameText;
                }
            }
            set {
                if(_ScanByVwLprDivision02ViewDivisionNameText != value) {
                    _ScanByVwLprDivision02ViewDivisionNameText = value;
                    OnPropertyChanged();
                }
            }
        }


        protected ICommand _ScanByVwLprDivision02ViewTextChangedCommand = null;
        public ICommand ScanByVwLprDivision02ViewTextChangedCommand
        {
            get
            {
                return _ScanByVwLprDivision02ViewTextChangedCommand ?? (_ScanByVwLprDivision02ViewTextChangedCommand = new Command((prm) => ScanByVwLprDivision02ViewTextChangedCommandExecute(prm), (prm) => ScanByVwLprDivision02ViewTextChangedCommandCanExecute(prm)));
            }
        }
        // Reason: UserInput = 0, ProgrammaticChange = 1, SuggestionChosen = 2
        protected async void ScanByVwLprDivision02ViewTextChangedCommandExecute(object prm)
        {
            if ((IsDsDestroyed) || (prm is null)) return;
            (object Cmpnt, object Sender, IUniqServiceFilterDefInterface FltDef, int Reason, string QueryText) tprm  = ((object Cmpnt, object Sender, IUniqServiceFilterDefInterface FltDef, int Reason, string QueryText))prm;
            if(tprm.Reason != 0) return;
            switch(tprm.FltDef.fltrName) {
                case "DivisionName":
                    ScanByVwLprDivision02ViewDivisionNameItem = null;
                    ScanByVwLprDivision02ViewDivisionNameText = tprm.QueryText;
                    {
                        ILpdDivisionViewFilter fltr = FrmSrvLpdDivisionView.GetFilter();
                        fltr.page = 0;
                        fltr.pagesize = 15;
                        fltr.DivisionName = new List<string>() { tprm.QueryText };
                        fltr.divisionNameOprtr = new List<string>() { "lk" };
                        ILpdDivisionViewPage rslt = await FrmSrvLpdDivisionView.getmanybyrepunqLpdDivisionNameUk(fltr);
                        if(rslt is null) {
                            ScanByVwLprDivision02ViewDivisionNameItemsSource = null;
                        } else {
                            ScanByVwLprDivision02ViewDivisionNameItemsSource = rslt.items;
                        }
                    }
                    break;
                default:
                    break;
            }            
        }
        protected bool ScanByVwLprDivision02ViewTextChangedCommandCanExecute(object prm)
        {
            return true;
        }

        protected ICommand _ScanByVwLprDivision02ViewQuerySubmitted = null;
        public ICommand ScanByVwLprDivision02ViewQuerySubmitted
        {
            get
            {
                return _ScanByVwLprDivision02ViewQuerySubmitted ?? (_ScanByVwLprDivision02ViewQuerySubmitted = new Command((prm) => ScanByVwLprDivision02ViewQuerySubmittedExecute(prm), (prm) => ScanByVwLprDivision02ViewQuerySubmittedCanExecute(prm)));
            }
        }
        protected void ScanByVwLprDivision02ViewQuerySubmittedExecute(object prm)
        {
            if ((IsDsDestroyed) || (prm is null)) return;
            (object Cmpnt, object Sender, IUniqServiceFilterDefInterface FltDef, object ChosenSuggestion, string QueryText) tprm  = 
                ((object Cmpnt, object Sender, IUniqServiceFilterDefInterface FltDef, object ChosenSuggestion, string QueryText))prm;
            switch(tprm.FltDef.fltrName) {
                case "DivisionName":
                    ScanByVwLprDivision02ViewDivisionNameItem = tprm.ChosenSuggestion as ILpdDivisionView;
                    ScanByVwLprDivision02ViewDivisionNameItemsSource = null;
                    break;
                default:
                    break;
            }
        }
        protected bool ScanByVwLprDivision02ViewQuerySubmittedCanExecute(object prm)
        {
            return true;
        }
        protected ICommand _ScanByVwLprDivision02ViewUnfocusedCommand = null;
        public ICommand ScanByVwLprDivision02ViewUnfocusedCommand
        {
            get
            {
                return _ScanByVwLprDivision02ViewUnfocusedCommand ?? (_ScanByVwLprDivision02ViewUnfocusedCommand = new Command((prm) => ScanByVwLprDivision02ViewUnfocusedCommandExecute(prm), (prm) => ScanByVwLprDivision02ViewUnfocusedCommandCanExecute(prm)));
            }
        }
        protected void ScanByVwLprDivision02ViewUnfocusedCommandExecute(object prm)
        {
            if ((IsDsDestroyed) || (prm is null)) return;
            (object Cmpnt, object Sender, IUniqServiceFilterDefInterface FltDef) tprm  = 
                ((object Cmpnt, object Sender, IUniqServiceFilterDefInterface FltDef))prm;
            switch(tprm.FltDef.fltrName) {
                case "DivisionName":
                    ScanByVwLprDivision02ViewDivisionNameItemsSource = null;
                    break;
                default:
                    break;
            }
        }
        protected bool ScanByVwLprDivision02ViewUnfocusedCommandCanExecute(object prm) {
            return true;
        }


        #endregion
        #region ScanByUkPrimaryFilterDefinitions
        protected IList<IUniqServiceFilterDefInterface> _ScanByUkPrimaryFilterDefinitions =
            new List<IUniqServiceFilterDefInterface>() {
                new UniqServiceFilterDef() { fltrName = "DivisionId", fltrDispMemb = "DivisionId", fltrTextMemb = "DivisionId", fltrCaption = "Id of the Division", fltrDataType = "int32", fltrMaxLen = null, fltrMin = null, fltrMax = null },
            };
        public IList<IUniqServiceFilterDefInterface> ScanByUkPrimaryFilterDefinitions {
            get {
                return _ScanByUkPrimaryFilterDefinitions;
            }
        }

        protected IPhbkDivisionView _ScanByUkPrimaryDivisionIdItem = null;
        public IPhbkDivisionView ScanByUkPrimaryDivisionIdItem {
            get {
                return _ScanByUkPrimaryDivisionIdItem;
            }
            set {
                if (_ScanByUkPrimaryDivisionIdItem != value) {
                    _ScanByUkPrimaryDivisionIdItem = value;
                    OnPropertyChanged();
                    OnPropertyChanged("ScanByUkPrimaryDivisionIdText");
                }
            }
        }
        
        protected IList<IPhbkDivisionView> _ScanByUkPrimaryItemsSource = null;
        public IList<IPhbkDivisionView> ScanByUkPrimaryItemsSource {
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

        protected string _ScanByUkPrimaryDivisionIdText = null;
        public string ScanByUkPrimaryDivisionIdText {
            get {
                IPhbkDivisionView dmObj = ScanByUkPrimaryDivisionIdItem;
                if(dmObj != null) {
                    return dmObj.DivisionId.ToString();
                } else {
                    return _ScanByUkPrimaryDivisionIdText;
                }

            }
            set {
                if(_ScanByUkPrimaryDivisionIdText != value) {
                    _ScanByUkPrimaryDivisionIdText = value;
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
                case "DivisionId":
                    k = 0;
                    break;
                default:
                    return;
            }
            IPhbkDivisionView itm = null;
            IPhbkDivisionViewFilter fltr = FrmRootSrv.GetFilter();
            fltr.page = 0;
            fltr.pagesize = 15;
            bool runQuery = true;
            itm = ScanByUkPrimaryDivisionIdItem;
            if (k > 0)  { 
                if(itm is null) {
                    runQuery = false;
                } else {
                    fltr.DivisionId = new List<System.Int32>() { itm.DivisionId }; 
                    fltr.divisionIdOprtr = new List<string>() { "eq" };
                }
             } else if(k == 0) { 
                ScanByUkPrimaryDivisionIdItem = null;
                ScanByUkPrimaryDivisionIdText = tprm.QueryText;
                {
                    System.Int32 val;
                    if (System.Int32.TryParse(tprm.QueryText, out val)) {
                        fltr.DivisionId = new List<System.Int32>() { val };
                    }
                }
                fltr.divisionIdOprtr = new List<string>() { "lk" };
             }
            if (runQuery) {
                IPhbkDivisionViewPage rslt = await FrmRootSrv.getmanybyrepprim(fltr);
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
                case "DivisionId":
                    ScanByUkPrimaryDivisionIdItem = tprm.ChosenSuggestion as IPhbkDivisionView;
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
        IList<string> mdlDrctFkProps = new List<string>{  "EntrprsIdRef" };
        IList<string> mdlMptProps = new List<string>{  "DivisionId", "DivisionName", "EntrprsIdRef" };
        Dictionary<string, IList<string>> reqHiddenProps = new Dictionary<string, IList<string>>() {
                    {"LprDivision01View", new List<string> {  }},
                    {"LprDivision02View", new List<string> {  "EntrprsIdRef" }},
        };
        Dictionary<string, IList<string>> extHiddenProps = new Dictionary<string, IList<string>>() {
                    {"LprDivision01View", new List<string> { }},
                    {"LprDivision02View", new List<string> { }},
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
            doIns = crrMDFP.Count == this.reqHiddenProps["LprDivision01View"].Count;
            if(doIns) {
                doIns = (this.reqHiddenProps["LprDivision01View"].Count(s => crrMDFP.Contains(s))) == crrMDFP.Count;
                
                if(doIns) {
                    if(hasNtExternal) {
                        foreach (var fld in this.extHiddenProps["LprDivision01View"]) { 
                            doIns = this.HiddenFiltersVM.Any(f => f.fltrName == fld);
                            if(!doIns) break;
                        }
                    } else {
                        doIns = extHiddflt.Count == this.extHiddenProps["LprDivision01View"].Count;
                        if(doIns) doIns = extHiddflt.Count(s => this.extHiddenProps["LprDivision01View"].Contains(s)) == extHiddflt.Count;
                    }
                }
            }
            if(doIns) {
                rslt.Add( 
                    new WebServiceFilterMenuViewModel() { Id = "ScanByVwLprDivision01View", Caption="filter by Division Name ref01", IconName=IconFont.Refresh, IconColor=Color.Default, Enabled=true, Data=null, Command = TableMenuItemsCommand}
                );
            }
            doIns = crrMDFP.Count == this.reqHiddenProps["LprDivision02View"].Count;
            if(doIns) {
                doIns = (this.reqHiddenProps["LprDivision02View"].Count(s => crrMDFP.Contains(s))) == crrMDFP.Count;
                
                if(doIns) {
                    if(hasNtExternal) {
                        foreach (var fld in this.extHiddenProps["LprDivision02View"]) { 
                            doIns = this.HiddenFiltersVM.Any(f => f.fltrName == fld);
                            if(!doIns) break;
                        }
                    } else {
                        doIns = extHiddflt.Count == this.extHiddenProps["LprDivision02View"].Count;
                        if(doIns) doIns = extHiddflt.Count(s => this.extHiddenProps["LprDivision02View"].Contains(s)) == extHiddflt.Count;
                    }
                }
            }
            if(doIns) {
                rslt.Add( 
                    new WebServiceFilterMenuViewModel() { Id = "ScanByVwLprDivision02View", Caption="filter by Division Name ref02", IconName=IconFont.Refresh, IconColor=Color.Default, Enabled=true, Data=null, Command = TableMenuItemsCommand}
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

