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
using ModelInterfacesClassLibrary.Phonebook.PhbkPhone;
using CommonInterfacesClassLibrary.AppGlblSettingsSrvc;
using CommonUserControlLibrary.UserControls;
using CommonCustomControlLibrary.Fonts;
using CommonUserControlLibrary.Classes;
using CommonCustomControlLibrary.Classes;
using ModelInterfacesClassLibrary.Phonebook.LprPhone01;
using ModelInterfacesClassLibrary.Phonebook.LpdPhone;
using ModelInterfacesClassLibrary.Phonebook.LprPhone02;
using ModelInterfacesClassLibrary.Phonebook.LprPhone03;
using ModelInterfacesClassLibrary.Phonebook.LprPhone04;
/*

    "PhbkPhoneViewSformUserControl" UserControl is defined in the "ModelServicesPrismModule"-project.
    In the file of IModule-class of "ModelServicesPrismModule"-project the following line of code must be inserted:

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ...
            // According to requirements of the "PhbkPhoneViewSformViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            ViewModelLocationProvider.Register<PhbkPhoneViewSformUserControl, PhbkPhoneViewSformViewModel>();
            // According to requirements of the "PhbkPhoneViewSformViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            containerRegistry.Register<ContentView, PhbkPhoneViewSformUserControl>("PhbkPhoneViewSformUserControl");
            ...
        }

*/

namespace ModelServicesPrismModule.Phonebook.PhbkPhone.ViewModels {
    public class PhbkPhoneViewSformViewModel: INotifyPropertyChanged, ISformViewModelInterface, IBindingContextChanged, IDestructible
    {
        protected IPhbkPhoneViewService FrmRootSrv=null;
        protected IAppGlblSettingsService GlblSettingsSrv=null;
        protected IDialogService _dialogService=null;
        protected ILprPhone01ViewService FrmSrvLprPhone01View;
        protected ILpdPhoneViewService FrmSrvLpdPhoneView;
        protected ILprPhone02ViewService FrmSrvLprPhone02View;
        protected ILprPhone03ViewService FrmSrvLprPhone03View;
        protected ILprPhone04ViewService FrmSrvLprPhone04View;
    

        bool CnFllscn = false;
        public PhbkPhoneViewSformViewModel(IAppGlblSettingsService GlblSettingsSrv, IPhbkPhoneViewService FrmRootSrv, 
                ILprPhone01ViewService FrmSrvLprPhone01View,
                ILpdPhoneViewService FrmSrvLpdPhoneView,
                ILprPhone02ViewService FrmSrvLprPhone02View,
                ILprPhone03ViewService FrmSrvLprPhone03View,
                ILprPhone04ViewService FrmSrvLprPhone04View,
    
            IDialogService dialogService) {
            this.GlblSettingsSrv = GlblSettingsSrv;
            this.FrmRootSrv = FrmRootSrv;
            this._dialogService = dialogService;
                this.FrmSrvLprPhone01View = FrmSrvLprPhone01View;
                this.FrmSrvLpdPhoneView = FrmSrvLpdPhoneView;
                this.FrmSrvLprPhone02View = FrmSrvLprPhone02View;
                this.FrmSrvLprPhone03View = FrmSrvLprPhone03View;
                this.FrmSrvLprPhone04View = FrmSrvLprPhone04View;
    
            _TableMenuItemsVM = GetDefaultTableMenuItemsVM();
            CnFllscn = (GlblSettingsSrv.GetViewModelMask("PhbkPhoneView") & 16) == 16;
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
        protected IEnumerable<IPhbkPhoneView> _DataSource = new ObservableCollection<IPhbkPhoneView>();
        public IEnumerable<IPhbkPhoneView> DataSource
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
                Name= "PhoneId", 
                Caption= "Phone Id", 
                IsChecked= true
            }, 
            new ColumnSelectorItemDefViewModel() {
                Name= "Phone", 
                Caption= "Phone", 
                IsChecked= true
            }, 
            new ColumnSelectorItemDefViewModel() {
                Name= "PPhoneTypeName", 
                Caption= "Phone Type Name", 
                IsChecked= true
            }, 
            new ColumnSelectorItemDefViewModel() {
                Name= "EEmpLastName", 
                Caption= "Employee Last Name", 
                IsChecked= true
            }, 
            new ColumnSelectorItemDefViewModel() {
                Name= "EEmpFirstName", 
                Caption= "Employee First Name", 
                IsChecked= true
            }, 
            new ColumnSelectorItemDefViewModel() {
                Name= "EDDivisionName", 
                Caption= "Name of the Division", 
                IsChecked= true
            }, 
            new ColumnSelectorItemDefViewModel() {
                Name= "EDEEntrprsName", 
                Caption= "Name of the Enterprise", 
                IsChecked= true
            }, 
            new ColumnSelectorItemDefViewModel() {
                Name= "EEmpSecondName", 
                Caption= "Employee Second Name", 
                IsChecked= false
            }, 
            new ColumnSelectorItemDefViewModel() {
                Name= "PhoneTypeIdRef", 
                Caption= "Phone Type Id", 
                IsChecked= false
            }, 
            new ColumnSelectorItemDefViewModel() {
                Name= "EmployeeIdRef", 
                Caption= "Id of the Employee", 
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
                    new WebServiceFilterDefViewModel() {fltrName="PhoneId", fltrCaption="Phone Id",  fltrDataType="int32", fltrMaxLen=null, fltrMin=null, fltrMax=null },
                    new WebServiceFilterDefViewModel() {fltrName="Phone", fltrCaption="Phone",  fltrDataType="string", fltrMaxLen=20, fltrMin=null, fltrMax=null },
                    new WebServiceFilterDefViewModel() {fltrName="PhoneTypeIdRef", fltrCaption="Phone Type Id",  fltrDataType="int32", fltrMaxLen=null, fltrMin=null, fltrMax=null },
                    new WebServiceFilterDefViewModel() {fltrName="EmployeeIdRef", fltrCaption="Id of the Employee",  fltrDataType="int32", fltrMaxLen=null, fltrMin=null, fltrMax=null },
                };
            bool isDsbl = true;
            if (this.HiddenFiltersVM != null) {
                isDsbl = isDsbl && this.HiddenFiltersVM.Any(v => v.fltrName == "PhoneTypeIdRef");
            } else isDsbl = false;
            if(!isDsbl) {
            }
            isDsbl = true;
            if (this.HiddenFiltersVM != null) {
                isDsbl = isDsbl && this.HiddenFiltersVM.Any(v => v.fltrName == "EmployeeIdRef");
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
                                            new WebServiceFilterDefViewModel() {fltrName="PhoneId", fltrCaption="Phone Id",  fltrDataType="int32", fltrMaxLen=null, fltrMin=null, fltrMax=null },
                                            new WebServiceFilterDefViewModel() {fltrName="Phone", fltrCaption="Phone",  fltrDataType="string", fltrMaxLen=20, fltrMin=null, fltrMax=null },
                                            new WebServiceFilterDefViewModel() {fltrName="PhoneTypeIdRef", fltrCaption="Phone Type Id",  fltrDataType="int32", fltrMaxLen=null, fltrMin=null, fltrMax=null },
                                            new WebServiceFilterDefViewModel() {fltrName="EmployeeIdRef", fltrCaption="Id of the Employee",  fltrDataType="int32", fltrMaxLen=null, fltrMin=null, fltrMax=null },
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
                DataSource = new ObservableCollection<IPhbkPhoneView>();
                SelectedRow = null;
                IsInQuery = false;
                return;
            }

            switch (SearchMethod) {
                case "ScanByVwLprPhone01View":  
                    await SrchDoSlctRwLprPhone01View();
                    IsInQuery = false;
                    return;
                case "ScanByVwLprPhone02View":  
                    await SrchDoSlctRwLprPhone02View();
                    IsInQuery = false;
                    return;
                case "ScanByVwLprPhone03View":  
                    await SrchDoSlctRwLprPhone03View();
                    IsInQuery = false;
                    return;
                case "ScanByVwLprPhone04View":  
                    await SrchDoSlctRwLprPhone04View();
                    IsInQuery = false;
                    return;
            }

            if ((SearchMethod == "FullScan")
                || (SearchMethod == "ScanByUkPrimary")
            ) {

                IPhbkPhoneViewFilter flt  = FrmRootSrv.GetFilter();
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
                            case "PhoneId":
                                if (flt.PhoneId == null) flt.PhoneId = new List<System.Int32>();
                                flt.PhoneId.Add((System.Int32)e.fltrValue);
                                if (flt.phoneIdOprtr == null) flt.phoneIdOprtr = new List<string>();
                                flt.phoneIdOprtr.Add(e.fltrOperator);
                                break;
                            case "Phone":
                                if (flt.Phone == null) flt.Phone = new List<System.String>();
                                flt.Phone.Add((System.String)e.fltrValue);
                                if (flt.phoneOprtr == null) flt.phoneOprtr = new List<string>();
                                flt.phoneOprtr.Add(e.fltrOperator);
                                break;
                            case "PhoneTypeIdRef":
                                if (flt.PhoneTypeIdRef == null) flt.PhoneTypeIdRef = new List<System.Int32>();
                                flt.PhoneTypeIdRef.Add((System.Int32)e.fltrValue);
                                if (flt.phoneTypeIdRefOprtr == null) flt.phoneTypeIdRefOprtr = new List<string>();
                                flt.phoneTypeIdRefOprtr.Add(e.fltrOperator);
                                break;
                            case "EmployeeIdRef":
                                if (flt.EmployeeIdRef == null) flt.EmployeeIdRef = new List<System.Int32>();
                                flt.EmployeeIdRef.Add((System.Int32)e.fltrValue);
                                if (flt.employeeIdRefOprtr == null) flt.employeeIdRefOprtr = new List<string>();
                                flt.employeeIdRefOprtr.Add(e.fltrOperator);
                                break;
                            default: break;
                        }
                    }
                }
                IPhbkPhoneViewPage rslt = await this.FrmRootSrv.getwithfilter(flt);
                if(rslt != null) {
                    // RowsPerPage resets CurrentPage 
                    // so the order is important: ActualRowsPerPage must be the first one and ActualCurrentPage must be the second
                    ActualRowsPerPage = rslt.pagesize;
                    ActualCurrentPage = rslt.page;
                    TotalCount = rslt.total; 
                    SelectedRow = null;
                    ObservableCollection<IPhbkPhoneView> ds = DataSource as ObservableCollection<IPhbkPhoneView>;
                    IsDsDestroyed = true;
                    if (ds == null) { ds = new ObservableCollection<IPhbkPhoneView>(); } else { ds.Clear(); }
                    IsDsDestroyed = false;
                    DataSource = null; 
                    if(rslt.items != null) {
                        foreach(IPhbkPhoneView itm in rslt.items) {
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
            IPhbkPhoneView prm = item as  IPhbkPhoneView;
            if(prm == null) return;
            ObservableCollection<IPhbkPhoneView> ds = DataSource as ObservableCollection<IPhbkPhoneView>;
            ds.Add(FrmRootSrv.CopyToModelNotify(prm, null));
            InternalContentChanged();
        }
        #endregion
        #region SformAfterUpdItemCommand
        public void SformAfterUpdItemCommand(object sender, object item) {
            IPhbkPhoneView prm = item as  IPhbkPhoneView;
            if(prm == null) return;
            ObservableCollection<IPhbkPhoneView> ds = DataSource as ObservableCollection<IPhbkPhoneView>;
            if (ds.IndexOf(prm) > -1) {
                return;
            }
            IPhbkPhoneView rw = ds.Where(d => 
                        (d.PhoneId == prm.PhoneId)
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
            IPhbkPhoneView prm = item as  IPhbkPhoneView;
            if(prm == null) return;
            ObservableCollection<IPhbkPhoneView> ds = DataSource as ObservableCollection<IPhbkPhoneView>;
            int indx = ds.IndexOf(prm);
            if (indx > -1) {
                ds.RemoveAt(indx);
                InternalContentChanged();
                return;
            }
            IPhbkPhoneView rw = ds.Where(d => 
                        (d.PhoneId == prm.PhoneId)
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

        #region ScanByVwLprPhone01ViewFilterDefinitions
        protected async Task SrchDoSlctRwLprPhone01View() {
            ILprPhone01ViewFilter dtlflt = FrmSrvLprPhone01View.GetFilter();
            dtlflt.page = this.CurrentPage; 
            dtlflt.pagesize = this.RowsPerPage;
            bool isFltSet = true;
            if(isFltSet) {
                if (ScanByVwLprPhone01ViewPhoneItem is null) {  
                    isFltSet = false;
                } else {
                    IList<IWebServiceFilterRsltInterface> dfltrslt = 
                        FrmSrvLprPhone01View.getHiddenFilterAsFltRslt(this.FrmSrvLpdPhoneView.getHiddenFilterByRow(ScanByVwLprPhone01ViewPhoneItem, "PhoneDict"));
                    if (dfltrslt is null) {
                        isFltSet = false;
                    } else {
                        FrmSrvLprPhone01View.FilterRslt2Filter(dfltrslt, dtlflt);
                    } 
                } 
            }
            if(!isFltSet) {
                GlblSettingsSrv.ShowErrorMessage("http", "Could not apply filter as not all attributes are set");
            }
            // by requirements all common foreignkey props have the same names for LprPhone01View and PhbkPhoneView
            foreach(var fld in reqHiddenProps["LprPhone01View"]) { 
                IWebServiceFilterRsltInterface hf = this.HiddenFiltersVM.FirstOrDefault(f => f.fltrName == fld);
                if(!(hf is null)) {
                    FrmSrvLprPhone01View.FilterRslt2Filter(hf, dtlflt);
                }
            }
            foreach(var fld in extHiddenProps["LprPhone01View"]) { 
                IWebServiceFilterRsltInterface hf = this.HiddenFiltersVM.FirstOrDefault(f => f.fltrName == fld);
                if(!(hf is null)) {
                    FrmSrvLprPhone01View.FilterRslt2Filter(hf, dtlflt);
                }
            }
            ILprPhone01ViewPage vd = await FrmSrvLprPhone01View.getmanybyrepprim(dtlflt);
            if(vd is null) {
                ClearDataSource();
                DataSource = new ObservableCollection<IPhbkPhoneView>();
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
                DataSource = new ObservableCollection<IPhbkPhoneView>();
                SelectedRow = null;
                return;
            }
            if(vd.items.Count < 1) {
                ClearDataSource();
                DataSource = new ObservableCollection<IPhbkPhoneView>();
                SelectedRow = null;
                return;
            }
            IPhbkPhoneViewFilter flt = FrmRootSrv.GetFilter();
            flt.page = 0;
            flt.pagesize = ActualRowsPerPage;
            foreach(var src in vd.items) {
                // primary keys are identical for LprPhone01View and PhbkPhoneView
                FrmRootSrv.FilterRslt2Filter(FrmSrvLprPhone01View.RowPrim2FilterRslt(src), flt);
            }
            IPhbkPhoneViewPage rslt = await this.FrmRootSrv.getmanybyrepprim(flt);
            if(rslt != null) {
                // RowsPerPage resets CurrentPage 
                // so the order is important: ActualRowsPerPage must be the first one and ActualCurrentPage must be the second
                ActualRowsPerPage = rslt.pagesize;
                ActualCurrentPage = rslt.page;
                TotalCount = rslt.total; 
                SelectedRow = null;
                ObservableCollection<IPhbkPhoneView> ds = DataSource as ObservableCollection<IPhbkPhoneView>;
                IsDsDestroyed = true;
                if (ds == null) { ds = new ObservableCollection<IPhbkPhoneView>(); } else { ds.Clear(); }
                IsDsDestroyed = false;
                DataSource = null; 
                if(rslt.items != null) {
                    foreach(IPhbkPhoneView itm in rslt.items) {
                        ds.Add(FrmRootSrv.CopyToModelNotify(itm, null));
                    }
                }
                DataSource = ds;
                SelectedRow = DataSource?.FirstOrDefault();
            } else {
                ClearDataSource();
                DataSource = new ObservableCollection<IPhbkPhoneView>();
                SelectedRow = null;
            }
        }
        protected IList<IUniqServiceFilterDefInterface> _ScanByVwLprPhone01ViewFilterDefinitions = 
            new List<IUniqServiceFilterDefInterface>() {
                new UniqServiceFilterDef() { fltrName = "Phone", fltrDispMemb = "Phone", fltrTextMemb = "Phone", fltrCaption = "Phone", fltrDataType = "string", fltrMaxLen = 20, fltrMin = null, fltrMax = null },
            };
        public IList<IUniqServiceFilterDefInterface> ScanByVwLprPhone01ViewFilterDefinitions {
            get {
                return _ScanByVwLprPhone01ViewFilterDefinitions;
            }
        }
        protected ILpdPhoneView _ScanByVwLprPhone01ViewPhoneItem = null;
        public ILpdPhoneView ScanByVwLprPhone01ViewPhoneItem {
            get {
                return _ScanByVwLprPhone01ViewPhoneItem;
            }
            set {
                if (_ScanByVwLprPhone01ViewPhoneItem != value) {
                    _ScanByVwLprPhone01ViewPhoneItem = value;
                    OnPropertyChanged();
                    OnPropertyChanged("ScanByVwLprPhone01ViewPhoneText");
                }
            }
        }
        protected IList<ILpdPhoneView> _ScanByVwLprPhone01ViewPhoneItemsSource = null;
        public IList<ILpdPhoneView> ScanByVwLprPhone01ViewPhoneItemsSource {
            get {
                return _ScanByVwLprPhone01ViewPhoneItemsSource;
            }
            set {
                if(_ScanByVwLprPhone01ViewPhoneItemsSource != value) {
                    _ScanByVwLprPhone01ViewPhoneItemsSource = value;
                    OnPropertyChanged();
                }
            }
        }
        protected string _ScanByVwLprPhone01ViewPhoneText = "";
        public string ScanByVwLprPhone01ViewPhoneText {
            get {
                ILpdPhoneView dmObj = ScanByVwLprPhone01ViewPhoneItem as ILpdPhoneView;
                if(dmObj!= null) {
                    return dmObj.Phone;
                } else {
                    return _ScanByVwLprPhone01ViewPhoneText;
                }
            }
            set {
                if(_ScanByVwLprPhone01ViewPhoneText != value) {
                    if(value is null)
                        _ScanByVwLprPhone01ViewPhoneText = "";
                    else
                        _ScanByVwLprPhone01ViewPhoneText = value;
                    OnPropertyChanged();
                }
            }
        }


        protected ICommand _ScanByVwLprPhone01ViewTextChangedCommand = null;
        public ICommand ScanByVwLprPhone01ViewTextChangedCommand
        {
            get
            {
                return _ScanByVwLprPhone01ViewTextChangedCommand ?? (_ScanByVwLprPhone01ViewTextChangedCommand = new Command((prm) => ScanByVwLprPhone01ViewTextChangedCommandExecute(prm), (prm) => ScanByVwLprPhone01ViewTextChangedCommandCanExecute(prm)));
            }
        }
        // Reason: UserInput = 0, ProgrammaticChange = 1, SuggestionChosen = 2
        protected async void ScanByVwLprPhone01ViewTextChangedCommandExecute(object prm)
        {
            if ((IsDsDestroyed) || (prm is null)) return;
            (object Cmpnt, object Sender, IUniqServiceFilterDefInterface FltDef, int Reason, string QueryText) tprm  = ((object Cmpnt, object Sender, IUniqServiceFilterDefInterface FltDef, int Reason, string QueryText))prm;
            if(tprm.Reason != 0) return;
            switch(tprm.FltDef.fltrName) {
                case "Phone":
                    _ScanByVwLprPhone01ViewPhoneItem = null;
                    string qstr = tprm.QueryText;
                    if(qstr is null) qstr = "";
                    if(_ScanByVwLprPhone01ViewPhoneText == qstr) return;
                    _ScanByVwLprPhone01ViewPhoneText = qstr;
                    {
                        ILpdPhoneViewFilter fltr = FrmSrvLpdPhoneView.GetFilter();
                        fltr.page = 0;
                        fltr.pagesize = 15;
                        fltr.Phone = new List<string>() { qstr };
                        fltr.phoneOprtr = new List<string>() { "lk" };
                        ILpdPhoneViewPage rslt = await FrmSrvLpdPhoneView.getmanybyrepunqLpdPhoneUK(fltr);
                        if(rslt is null) {
                            ScanByVwLprPhone01ViewPhoneItemsSource = null;
                        } else {
                            ScanByVwLprPhone01ViewPhoneItemsSource = rslt.items;
                        }
                    }
                    break;
                default:
                    break;
            }            
        }
        protected bool ScanByVwLprPhone01ViewTextChangedCommandCanExecute(object prm)
        {
            return true;
        }

        protected ICommand _ScanByVwLprPhone01ViewQuerySubmitted = null;
        public ICommand ScanByVwLprPhone01ViewQuerySubmitted
        {
            get
            {
                return _ScanByVwLprPhone01ViewQuerySubmitted ?? (_ScanByVwLprPhone01ViewQuerySubmitted = new Command((prm) => ScanByVwLprPhone01ViewQuerySubmittedExecute(prm), (prm) => ScanByVwLprPhone01ViewQuerySubmittedCanExecute(prm)));
            }
        }
        protected void ScanByVwLprPhone01ViewQuerySubmittedExecute(object prm)
        {
            if ((IsDsDestroyed) || (prm is null)) return;
            (object Cmpnt, object Sender, IUniqServiceFilterDefInterface FltDef, object ChosenSuggestion, string QueryText) tprm  = 
                ((object Cmpnt, object Sender, IUniqServiceFilterDefInterface FltDef, object ChosenSuggestion, string QueryText))prm;
            switch(tprm.FltDef.fltrName) {
                case "Phone":
                    ScanByVwLprPhone01ViewPhoneItem = tprm.ChosenSuggestion as ILpdPhoneView;
                    ScanByVwLprPhone01ViewPhoneItemsSource = null;
                    break;
                default:
                    break;
            }
        }
        protected bool ScanByVwLprPhone01ViewQuerySubmittedCanExecute(object prm)
        {
            return true;
        }
        protected ICommand _ScanByVwLprPhone01ViewUnfocusedCommand = null;
        public ICommand ScanByVwLprPhone01ViewUnfocusedCommand
        {
            get
            {
                return _ScanByVwLprPhone01ViewUnfocusedCommand ?? (_ScanByVwLprPhone01ViewUnfocusedCommand = new Command((prm) => ScanByVwLprPhone01ViewUnfocusedCommandExecute(prm), (prm) => ScanByVwLprPhone01ViewUnfocusedCommandCanExecute(prm)));
            }
        }
        protected void ScanByVwLprPhone01ViewUnfocusedCommandExecute(object prm)
        {
            if ((IsDsDestroyed) || (prm is null)) return;
            (object Cmpnt, object Sender, IUniqServiceFilterDefInterface FltDef) tprm  = 
                ((object Cmpnt, object Sender, IUniqServiceFilterDefInterface FltDef))prm;
            switch(tprm.FltDef.fltrName) {
                case "Phone":
                    ScanByVwLprPhone01ViewPhoneItemsSource = null;
                    break;
                default:
                    break;
            }
        }
        protected bool ScanByVwLprPhone01ViewUnfocusedCommandCanExecute(object prm) {
            return true;
        }


        #endregion
        #region ScanByVwLprPhone02ViewFilterDefinitions
        protected async Task SrchDoSlctRwLprPhone02View() {
            ILprPhone02ViewFilter dtlflt = FrmSrvLprPhone02View.GetFilter();
            dtlflt.page = this.CurrentPage; 
            dtlflt.pagesize = this.RowsPerPage;
            bool isFltSet = true;
            if(isFltSet) {
                if (ScanByVwLprPhone02ViewPhoneItem is null) {  
                    isFltSet = false;
                } else {
                    IList<IWebServiceFilterRsltInterface> dfltrslt = 
                        FrmSrvLprPhone02View.getHiddenFilterAsFltRslt(this.FrmSrvLpdPhoneView.getHiddenFilterByRow(ScanByVwLprPhone02ViewPhoneItem, "PhoneDict"));
                    if (dfltrslt is null) {
                        isFltSet = false;
                    } else {
                        FrmSrvLprPhone02View.FilterRslt2Filter(dfltrslt, dtlflt);
                    } 
                } 
            }
            if(!isFltSet) {
                GlblSettingsSrv.ShowErrorMessage("http", "Could not apply filter as not all attributes are set");
            }
            // by requirements all common foreignkey props have the same names for LprPhone02View and PhbkPhoneView
            foreach(var fld in reqHiddenProps["LprPhone02View"]) { 
                IWebServiceFilterRsltInterface hf = this.HiddenFiltersVM.FirstOrDefault(f => f.fltrName == fld);
                if(!(hf is null)) {
                    FrmSrvLprPhone02View.FilterRslt2Filter(hf, dtlflt);
                }
            }
            foreach(var fld in extHiddenProps["LprPhone02View"]) { 
                IWebServiceFilterRsltInterface hf = this.HiddenFiltersVM.FirstOrDefault(f => f.fltrName == fld);
                if(!(hf is null)) {
                    FrmSrvLprPhone02View.FilterRslt2Filter(hf, dtlflt);
                }
            }
            ILprPhone02ViewPage vd = await FrmSrvLprPhone02View.getmanybyrepprim(dtlflt);
            if(vd is null) {
                ClearDataSource();
                DataSource = new ObservableCollection<IPhbkPhoneView>();
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
                DataSource = new ObservableCollection<IPhbkPhoneView>();
                SelectedRow = null;
                return;
            }
            if(vd.items.Count < 1) {
                ClearDataSource();
                DataSource = new ObservableCollection<IPhbkPhoneView>();
                SelectedRow = null;
                return;
            }
            IPhbkPhoneViewFilter flt = FrmRootSrv.GetFilter();
            flt.page = 0;
            flt.pagesize = ActualRowsPerPage;
            foreach(var src in vd.items) {
                // primary keys are identical for LprPhone02View and PhbkPhoneView
                FrmRootSrv.FilterRslt2Filter(FrmSrvLprPhone02View.RowPrim2FilterRslt(src), flt);
            }
            IPhbkPhoneViewPage rslt = await this.FrmRootSrv.getmanybyrepprim(flt);
            if(rslt != null) {
                // RowsPerPage resets CurrentPage 
                // so the order is important: ActualRowsPerPage must be the first one and ActualCurrentPage must be the second
                ActualRowsPerPage = rslt.pagesize;
                ActualCurrentPage = rslt.page;
                TotalCount = rslt.total; 
                SelectedRow = null;
                ObservableCollection<IPhbkPhoneView> ds = DataSource as ObservableCollection<IPhbkPhoneView>;
                IsDsDestroyed = true;
                if (ds == null) { ds = new ObservableCollection<IPhbkPhoneView>(); } else { ds.Clear(); }
                IsDsDestroyed = false;
                DataSource = null; 
                if(rslt.items != null) {
                    foreach(IPhbkPhoneView itm in rslt.items) {
                        ds.Add(FrmRootSrv.CopyToModelNotify(itm, null));
                    }
                }
                DataSource = ds;
                SelectedRow = DataSource?.FirstOrDefault();
            } else {
                ClearDataSource();
                DataSource = new ObservableCollection<IPhbkPhoneView>();
                SelectedRow = null;
            }
        }
        protected IList<IUniqServiceFilterDefInterface> _ScanByVwLprPhone02ViewFilterDefinitions = 
            new List<IUniqServiceFilterDefInterface>() {
                new UniqServiceFilterDef() { fltrName = "Phone", fltrDispMemb = "Phone", fltrTextMemb = "Phone", fltrCaption = "Phone", fltrDataType = "string", fltrMaxLen = 20, fltrMin = null, fltrMax = null },
            };
        public IList<IUniqServiceFilterDefInterface> ScanByVwLprPhone02ViewFilterDefinitions {
            get {
                return _ScanByVwLprPhone02ViewFilterDefinitions;
            }
        }
        protected ILpdPhoneView _ScanByVwLprPhone02ViewPhoneItem = null;
        public ILpdPhoneView ScanByVwLprPhone02ViewPhoneItem {
            get {
                return _ScanByVwLprPhone02ViewPhoneItem;
            }
            set {
                if (_ScanByVwLprPhone02ViewPhoneItem != value) {
                    _ScanByVwLprPhone02ViewPhoneItem = value;
                    OnPropertyChanged();
                    OnPropertyChanged("ScanByVwLprPhone02ViewPhoneText");
                }
            }
        }
        protected IList<ILpdPhoneView> _ScanByVwLprPhone02ViewPhoneItemsSource = null;
        public IList<ILpdPhoneView> ScanByVwLprPhone02ViewPhoneItemsSource {
            get {
                return _ScanByVwLprPhone02ViewPhoneItemsSource;
            }
            set {
                if(_ScanByVwLprPhone02ViewPhoneItemsSource != value) {
                    _ScanByVwLprPhone02ViewPhoneItemsSource = value;
                    OnPropertyChanged();
                }
            }
        }
        protected string _ScanByVwLprPhone02ViewPhoneText = "";
        public string ScanByVwLprPhone02ViewPhoneText {
            get {
                ILpdPhoneView dmObj = ScanByVwLprPhone02ViewPhoneItem as ILpdPhoneView;
                if(dmObj!= null) {
                    return dmObj.Phone;
                } else {
                    return _ScanByVwLprPhone02ViewPhoneText;
                }
            }
            set {
                if(_ScanByVwLprPhone02ViewPhoneText != value) {
                    if(value is null)
                        _ScanByVwLprPhone02ViewPhoneText = "";
                    else
                        _ScanByVwLprPhone02ViewPhoneText = value;
                    OnPropertyChanged();
                }
            }
        }


        protected ICommand _ScanByVwLprPhone02ViewTextChangedCommand = null;
        public ICommand ScanByVwLprPhone02ViewTextChangedCommand
        {
            get
            {
                return _ScanByVwLprPhone02ViewTextChangedCommand ?? (_ScanByVwLprPhone02ViewTextChangedCommand = new Command((prm) => ScanByVwLprPhone02ViewTextChangedCommandExecute(prm), (prm) => ScanByVwLprPhone02ViewTextChangedCommandCanExecute(prm)));
            }
        }
        // Reason: UserInput = 0, ProgrammaticChange = 1, SuggestionChosen = 2
        protected async void ScanByVwLprPhone02ViewTextChangedCommandExecute(object prm)
        {
            if ((IsDsDestroyed) || (prm is null)) return;
            (object Cmpnt, object Sender, IUniqServiceFilterDefInterface FltDef, int Reason, string QueryText) tprm  = ((object Cmpnt, object Sender, IUniqServiceFilterDefInterface FltDef, int Reason, string QueryText))prm;
            if(tprm.Reason != 0) return;
            switch(tprm.FltDef.fltrName) {
                case "Phone":
                    _ScanByVwLprPhone02ViewPhoneItem = null;
                    string qstr = tprm.QueryText;
                    if(qstr is null) qstr = "";
                    if(_ScanByVwLprPhone02ViewPhoneText == qstr) return;
                    _ScanByVwLprPhone02ViewPhoneText = qstr;
                    {
                        ILpdPhoneViewFilter fltr = FrmSrvLpdPhoneView.GetFilter();
                        fltr.page = 0;
                        fltr.pagesize = 15;
                        fltr.Phone = new List<string>() { qstr };
                        fltr.phoneOprtr = new List<string>() { "lk" };
                        ILpdPhoneViewPage rslt = await FrmSrvLpdPhoneView.getmanybyrepunqLpdPhoneUK(fltr);
                        if(rslt is null) {
                            ScanByVwLprPhone02ViewPhoneItemsSource = null;
                        } else {
                            ScanByVwLprPhone02ViewPhoneItemsSource = rslt.items;
                        }
                    }
                    break;
                default:
                    break;
            }            
        }
        protected bool ScanByVwLprPhone02ViewTextChangedCommandCanExecute(object prm)
        {
            return true;
        }

        protected ICommand _ScanByVwLprPhone02ViewQuerySubmitted = null;
        public ICommand ScanByVwLprPhone02ViewQuerySubmitted
        {
            get
            {
                return _ScanByVwLprPhone02ViewQuerySubmitted ?? (_ScanByVwLprPhone02ViewQuerySubmitted = new Command((prm) => ScanByVwLprPhone02ViewQuerySubmittedExecute(prm), (prm) => ScanByVwLprPhone02ViewQuerySubmittedCanExecute(prm)));
            }
        }
        protected void ScanByVwLprPhone02ViewQuerySubmittedExecute(object prm)
        {
            if ((IsDsDestroyed) || (prm is null)) return;
            (object Cmpnt, object Sender, IUniqServiceFilterDefInterface FltDef, object ChosenSuggestion, string QueryText) tprm  = 
                ((object Cmpnt, object Sender, IUniqServiceFilterDefInterface FltDef, object ChosenSuggestion, string QueryText))prm;
            switch(tprm.FltDef.fltrName) {
                case "Phone":
                    ScanByVwLprPhone02ViewPhoneItem = tprm.ChosenSuggestion as ILpdPhoneView;
                    ScanByVwLprPhone02ViewPhoneItemsSource = null;
                    break;
                default:
                    break;
            }
        }
        protected bool ScanByVwLprPhone02ViewQuerySubmittedCanExecute(object prm)
        {
            return true;
        }
        protected ICommand _ScanByVwLprPhone02ViewUnfocusedCommand = null;
        public ICommand ScanByVwLprPhone02ViewUnfocusedCommand
        {
            get
            {
                return _ScanByVwLprPhone02ViewUnfocusedCommand ?? (_ScanByVwLprPhone02ViewUnfocusedCommand = new Command((prm) => ScanByVwLprPhone02ViewUnfocusedCommandExecute(prm), (prm) => ScanByVwLprPhone02ViewUnfocusedCommandCanExecute(prm)));
            }
        }
        protected void ScanByVwLprPhone02ViewUnfocusedCommandExecute(object prm)
        {
            if ((IsDsDestroyed) || (prm is null)) return;
            (object Cmpnt, object Sender, IUniqServiceFilterDefInterface FltDef) tprm  = 
                ((object Cmpnt, object Sender, IUniqServiceFilterDefInterface FltDef))prm;
            switch(tprm.FltDef.fltrName) {
                case "Phone":
                    ScanByVwLprPhone02ViewPhoneItemsSource = null;
                    break;
                default:
                    break;
            }
        }
        protected bool ScanByVwLprPhone02ViewUnfocusedCommandCanExecute(object prm) {
            return true;
        }


        #endregion
        #region ScanByVwLprPhone03ViewFilterDefinitions
        protected async Task SrchDoSlctRwLprPhone03View() {
            ILprPhone03ViewFilter dtlflt = FrmSrvLprPhone03View.GetFilter();
            dtlflt.page = this.CurrentPage; 
            dtlflt.pagesize = this.RowsPerPage;
            bool isFltSet = true;
            if(isFltSet) {
                if (ScanByVwLprPhone03ViewPhoneItem is null) {  
                    isFltSet = false;
                } else {
                    IList<IWebServiceFilterRsltInterface> dfltrslt = 
                        FrmSrvLprPhone03View.getHiddenFilterAsFltRslt(this.FrmSrvLpdPhoneView.getHiddenFilterByRow(ScanByVwLprPhone03ViewPhoneItem, "PhoneDict"));
                    if (dfltrslt is null) {
                        isFltSet = false;
                    } else {
                        FrmSrvLprPhone03View.FilterRslt2Filter(dfltrslt, dtlflt);
                    } 
                } 
            }
            if(!isFltSet) {
                GlblSettingsSrv.ShowErrorMessage("http", "Could not apply filter as not all attributes are set");
            }
            // by requirements all common foreignkey props have the same names for LprPhone03View and PhbkPhoneView
            foreach(var fld in reqHiddenProps["LprPhone03View"]) { 
                IWebServiceFilterRsltInterface hf = this.HiddenFiltersVM.FirstOrDefault(f => f.fltrName == fld);
                if(!(hf is null)) {
                    FrmSrvLprPhone03View.FilterRslt2Filter(hf, dtlflt);
                }
            }
            foreach(var fld in extHiddenProps["LprPhone03View"]) { 
                IWebServiceFilterRsltInterface hf = this.HiddenFiltersVM.FirstOrDefault(f => f.fltrName == fld);
                if(!(hf is null)) {
                    FrmSrvLprPhone03View.FilterRslt2Filter(hf, dtlflt);
                }
            }
            ILprPhone03ViewPage vd = await FrmSrvLprPhone03View.getmanybyrepprim(dtlflt);
            if(vd is null) {
                ClearDataSource();
                DataSource = new ObservableCollection<IPhbkPhoneView>();
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
                DataSource = new ObservableCollection<IPhbkPhoneView>();
                SelectedRow = null;
                return;
            }
            if(vd.items.Count < 1) {
                ClearDataSource();
                DataSource = new ObservableCollection<IPhbkPhoneView>();
                SelectedRow = null;
                return;
            }
            IPhbkPhoneViewFilter flt = FrmRootSrv.GetFilter();
            flt.page = 0;
            flt.pagesize = ActualRowsPerPage;
            foreach(var src in vd.items) {
                // primary keys are identical for LprPhone03View and PhbkPhoneView
                FrmRootSrv.FilterRslt2Filter(FrmSrvLprPhone03View.RowPrim2FilterRslt(src), flt);
            }
            IPhbkPhoneViewPage rslt = await this.FrmRootSrv.getmanybyrepprim(flt);
            if(rslt != null) {
                // RowsPerPage resets CurrentPage 
                // so the order is important: ActualRowsPerPage must be the first one and ActualCurrentPage must be the second
                ActualRowsPerPage = rslt.pagesize;
                ActualCurrentPage = rslt.page;
                TotalCount = rslt.total; 
                SelectedRow = null;
                ObservableCollection<IPhbkPhoneView> ds = DataSource as ObservableCollection<IPhbkPhoneView>;
                IsDsDestroyed = true;
                if (ds == null) { ds = new ObservableCollection<IPhbkPhoneView>(); } else { ds.Clear(); }
                IsDsDestroyed = false;
                DataSource = null; 
                if(rslt.items != null) {
                    foreach(IPhbkPhoneView itm in rslt.items) {
                        ds.Add(FrmRootSrv.CopyToModelNotify(itm, null));
                    }
                }
                DataSource = ds;
                SelectedRow = DataSource?.FirstOrDefault();
            } else {
                ClearDataSource();
                DataSource = new ObservableCollection<IPhbkPhoneView>();
                SelectedRow = null;
            }
        }
        protected IList<IUniqServiceFilterDefInterface> _ScanByVwLprPhone03ViewFilterDefinitions = 
            new List<IUniqServiceFilterDefInterface>() {
                new UniqServiceFilterDef() { fltrName = "Phone", fltrDispMemb = "Phone", fltrTextMemb = "Phone", fltrCaption = "Phone", fltrDataType = "string", fltrMaxLen = 20, fltrMin = null, fltrMax = null },
            };
        public IList<IUniqServiceFilterDefInterface> ScanByVwLprPhone03ViewFilterDefinitions {
            get {
                return _ScanByVwLprPhone03ViewFilterDefinitions;
            }
        }
        protected ILpdPhoneView _ScanByVwLprPhone03ViewPhoneItem = null;
        public ILpdPhoneView ScanByVwLprPhone03ViewPhoneItem {
            get {
                return _ScanByVwLprPhone03ViewPhoneItem;
            }
            set {
                if (_ScanByVwLprPhone03ViewPhoneItem != value) {
                    _ScanByVwLprPhone03ViewPhoneItem = value;
                    OnPropertyChanged();
                    OnPropertyChanged("ScanByVwLprPhone03ViewPhoneText");
                }
            }
        }
        protected IList<ILpdPhoneView> _ScanByVwLprPhone03ViewPhoneItemsSource = null;
        public IList<ILpdPhoneView> ScanByVwLprPhone03ViewPhoneItemsSource {
            get {
                return _ScanByVwLprPhone03ViewPhoneItemsSource;
            }
            set {
                if(_ScanByVwLprPhone03ViewPhoneItemsSource != value) {
                    _ScanByVwLprPhone03ViewPhoneItemsSource = value;
                    OnPropertyChanged();
                }
            }
        }
        protected string _ScanByVwLprPhone03ViewPhoneText = "";
        public string ScanByVwLprPhone03ViewPhoneText {
            get {
                ILpdPhoneView dmObj = ScanByVwLprPhone03ViewPhoneItem as ILpdPhoneView;
                if(dmObj!= null) {
                    return dmObj.Phone;
                } else {
                    return _ScanByVwLprPhone03ViewPhoneText;
                }
            }
            set {
                if(_ScanByVwLprPhone03ViewPhoneText != value) {
                    if(value is null)
                        _ScanByVwLprPhone03ViewPhoneText = "";
                    else
                        _ScanByVwLprPhone03ViewPhoneText = value;
                    OnPropertyChanged();
                }
            }
        }


        protected ICommand _ScanByVwLprPhone03ViewTextChangedCommand = null;
        public ICommand ScanByVwLprPhone03ViewTextChangedCommand
        {
            get
            {
                return _ScanByVwLprPhone03ViewTextChangedCommand ?? (_ScanByVwLprPhone03ViewTextChangedCommand = new Command((prm) => ScanByVwLprPhone03ViewTextChangedCommandExecute(prm), (prm) => ScanByVwLprPhone03ViewTextChangedCommandCanExecute(prm)));
            }
        }
        // Reason: UserInput = 0, ProgrammaticChange = 1, SuggestionChosen = 2
        protected async void ScanByVwLprPhone03ViewTextChangedCommandExecute(object prm)
        {
            if ((IsDsDestroyed) || (prm is null)) return;
            (object Cmpnt, object Sender, IUniqServiceFilterDefInterface FltDef, int Reason, string QueryText) tprm  = ((object Cmpnt, object Sender, IUniqServiceFilterDefInterface FltDef, int Reason, string QueryText))prm;
            if(tprm.Reason != 0) return;
            switch(tprm.FltDef.fltrName) {
                case "Phone":
                    _ScanByVwLprPhone03ViewPhoneItem = null;
                    string qstr = tprm.QueryText;
                    if(qstr is null) qstr = "";
                    if(_ScanByVwLprPhone03ViewPhoneText == qstr) return;
                    _ScanByVwLprPhone03ViewPhoneText = qstr;
                    {
                        ILpdPhoneViewFilter fltr = FrmSrvLpdPhoneView.GetFilter();
                        fltr.page = 0;
                        fltr.pagesize = 15;
                        fltr.Phone = new List<string>() { qstr };
                        fltr.phoneOprtr = new List<string>() { "lk" };
                        ILpdPhoneViewPage rslt = await FrmSrvLpdPhoneView.getmanybyrepunqLpdPhoneUK(fltr);
                        if(rslt is null) {
                            ScanByVwLprPhone03ViewPhoneItemsSource = null;
                        } else {
                            ScanByVwLprPhone03ViewPhoneItemsSource = rslt.items;
                        }
                    }
                    break;
                default:
                    break;
            }            
        }
        protected bool ScanByVwLprPhone03ViewTextChangedCommandCanExecute(object prm)
        {
            return true;
        }

        protected ICommand _ScanByVwLprPhone03ViewQuerySubmitted = null;
        public ICommand ScanByVwLprPhone03ViewQuerySubmitted
        {
            get
            {
                return _ScanByVwLprPhone03ViewQuerySubmitted ?? (_ScanByVwLprPhone03ViewQuerySubmitted = new Command((prm) => ScanByVwLprPhone03ViewQuerySubmittedExecute(prm), (prm) => ScanByVwLprPhone03ViewQuerySubmittedCanExecute(prm)));
            }
        }
        protected void ScanByVwLprPhone03ViewQuerySubmittedExecute(object prm)
        {
            if ((IsDsDestroyed) || (prm is null)) return;
            (object Cmpnt, object Sender, IUniqServiceFilterDefInterface FltDef, object ChosenSuggestion, string QueryText) tprm  = 
                ((object Cmpnt, object Sender, IUniqServiceFilterDefInterface FltDef, object ChosenSuggestion, string QueryText))prm;
            switch(tprm.FltDef.fltrName) {
                case "Phone":
                    ScanByVwLprPhone03ViewPhoneItem = tprm.ChosenSuggestion as ILpdPhoneView;
                    ScanByVwLprPhone03ViewPhoneItemsSource = null;
                    break;
                default:
                    break;
            }
        }
        protected bool ScanByVwLprPhone03ViewQuerySubmittedCanExecute(object prm)
        {
            return true;
        }
        protected ICommand _ScanByVwLprPhone03ViewUnfocusedCommand = null;
        public ICommand ScanByVwLprPhone03ViewUnfocusedCommand
        {
            get
            {
                return _ScanByVwLprPhone03ViewUnfocusedCommand ?? (_ScanByVwLprPhone03ViewUnfocusedCommand = new Command((prm) => ScanByVwLprPhone03ViewUnfocusedCommandExecute(prm), (prm) => ScanByVwLprPhone03ViewUnfocusedCommandCanExecute(prm)));
            }
        }
        protected void ScanByVwLprPhone03ViewUnfocusedCommandExecute(object prm)
        {
            if ((IsDsDestroyed) || (prm is null)) return;
            (object Cmpnt, object Sender, IUniqServiceFilterDefInterface FltDef) tprm  = 
                ((object Cmpnt, object Sender, IUniqServiceFilterDefInterface FltDef))prm;
            switch(tprm.FltDef.fltrName) {
                case "Phone":
                    ScanByVwLprPhone03ViewPhoneItemsSource = null;
                    break;
                default:
                    break;
            }
        }
        protected bool ScanByVwLprPhone03ViewUnfocusedCommandCanExecute(object prm) {
            return true;
        }


        #endregion
        #region ScanByVwLprPhone04ViewFilterDefinitions
        protected async Task SrchDoSlctRwLprPhone04View() {
            ILprPhone04ViewFilter dtlflt = FrmSrvLprPhone04View.GetFilter();
            dtlflt.page = this.CurrentPage; 
            dtlflt.pagesize = this.RowsPerPage;
            bool isFltSet = true;
            if(isFltSet) {
                if (ScanByVwLprPhone04ViewPhoneItem is null) {  
                    isFltSet = false;
                } else {
                    IList<IWebServiceFilterRsltInterface> dfltrslt = 
                        FrmSrvLprPhone04View.getHiddenFilterAsFltRslt(this.FrmSrvLpdPhoneView.getHiddenFilterByRow(ScanByVwLprPhone04ViewPhoneItem, "PhoneDict"));
                    if (dfltrslt is null) {
                        isFltSet = false;
                    } else {
                        FrmSrvLprPhone04View.FilterRslt2Filter(dfltrslt, dtlflt);
                    } 
                } 
            }
            if(!isFltSet) {
                GlblSettingsSrv.ShowErrorMessage("http", "Could not apply filter as not all attributes are set");
            }
            // by requirements all common foreignkey props have the same names for LprPhone04View and PhbkPhoneView
            foreach(var fld in reqHiddenProps["LprPhone04View"]) { 
                IWebServiceFilterRsltInterface hf = this.HiddenFiltersVM.FirstOrDefault(f => f.fltrName == fld);
                if(!(hf is null)) {
                    FrmSrvLprPhone04View.FilterRslt2Filter(hf, dtlflt);
                }
            }
            foreach(var fld in extHiddenProps["LprPhone04View"]) { 
                IWebServiceFilterRsltInterface hf = this.HiddenFiltersVM.FirstOrDefault(f => f.fltrName == fld);
                if(!(hf is null)) {
                    FrmSrvLprPhone04View.FilterRslt2Filter(hf, dtlflt);
                }
            }
            ILprPhone04ViewPage vd = await FrmSrvLprPhone04View.getmanybyrepprim(dtlflt);
            if(vd is null) {
                ClearDataSource();
                DataSource = new ObservableCollection<IPhbkPhoneView>();
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
                DataSource = new ObservableCollection<IPhbkPhoneView>();
                SelectedRow = null;
                return;
            }
            if(vd.items.Count < 1) {
                ClearDataSource();
                DataSource = new ObservableCollection<IPhbkPhoneView>();
                SelectedRow = null;
                return;
            }
            IPhbkPhoneViewFilter flt = FrmRootSrv.GetFilter();
            flt.page = 0;
            flt.pagesize = ActualRowsPerPage;
            foreach(var src in vd.items) {
                // primary keys are identical for LprPhone04View and PhbkPhoneView
                FrmRootSrv.FilterRslt2Filter(FrmSrvLprPhone04View.RowPrim2FilterRslt(src), flt);
            }
            IPhbkPhoneViewPage rslt = await this.FrmRootSrv.getmanybyrepprim(flt);
            if(rslt != null) {
                // RowsPerPage resets CurrentPage 
                // so the order is important: ActualRowsPerPage must be the first one and ActualCurrentPage must be the second
                ActualRowsPerPage = rslt.pagesize;
                ActualCurrentPage = rslt.page;
                TotalCount = rslt.total; 
                SelectedRow = null;
                ObservableCollection<IPhbkPhoneView> ds = DataSource as ObservableCollection<IPhbkPhoneView>;
                IsDsDestroyed = true;
                if (ds == null) { ds = new ObservableCollection<IPhbkPhoneView>(); } else { ds.Clear(); }
                IsDsDestroyed = false;
                DataSource = null; 
                if(rslt.items != null) {
                    foreach(IPhbkPhoneView itm in rslt.items) {
                        ds.Add(FrmRootSrv.CopyToModelNotify(itm, null));
                    }
                }
                DataSource = ds;
                SelectedRow = DataSource?.FirstOrDefault();
            } else {
                ClearDataSource();
                DataSource = new ObservableCollection<IPhbkPhoneView>();
                SelectedRow = null;
            }
        }
        protected IList<IUniqServiceFilterDefInterface> _ScanByVwLprPhone04ViewFilterDefinitions = 
            new List<IUniqServiceFilterDefInterface>() {
                new UniqServiceFilterDef() { fltrName = "Phone", fltrDispMemb = "Phone", fltrTextMemb = "Phone", fltrCaption = "Phone", fltrDataType = "string", fltrMaxLen = 20, fltrMin = null, fltrMax = null },
            };
        public IList<IUniqServiceFilterDefInterface> ScanByVwLprPhone04ViewFilterDefinitions {
            get {
                return _ScanByVwLprPhone04ViewFilterDefinitions;
            }
        }
        protected ILpdPhoneView _ScanByVwLprPhone04ViewPhoneItem = null;
        public ILpdPhoneView ScanByVwLprPhone04ViewPhoneItem {
            get {
                return _ScanByVwLprPhone04ViewPhoneItem;
            }
            set {
                if (_ScanByVwLprPhone04ViewPhoneItem != value) {
                    _ScanByVwLprPhone04ViewPhoneItem = value;
                    OnPropertyChanged();
                    OnPropertyChanged("ScanByVwLprPhone04ViewPhoneText");
                }
            }
        }
        protected IList<ILpdPhoneView> _ScanByVwLprPhone04ViewPhoneItemsSource = null;
        public IList<ILpdPhoneView> ScanByVwLprPhone04ViewPhoneItemsSource {
            get {
                return _ScanByVwLprPhone04ViewPhoneItemsSource;
            }
            set {
                if(_ScanByVwLprPhone04ViewPhoneItemsSource != value) {
                    _ScanByVwLprPhone04ViewPhoneItemsSource = value;
                    OnPropertyChanged();
                }
            }
        }
        protected string _ScanByVwLprPhone04ViewPhoneText = "";
        public string ScanByVwLprPhone04ViewPhoneText {
            get {
                ILpdPhoneView dmObj = ScanByVwLprPhone04ViewPhoneItem as ILpdPhoneView;
                if(dmObj!= null) {
                    return dmObj.Phone;
                } else {
                    return _ScanByVwLprPhone04ViewPhoneText;
                }
            }
            set {
                if(_ScanByVwLprPhone04ViewPhoneText != value) {
                    if(value is null)
                        _ScanByVwLprPhone04ViewPhoneText = "";
                    else
                        _ScanByVwLprPhone04ViewPhoneText = value;
                    OnPropertyChanged();
                }
            }
        }


        protected ICommand _ScanByVwLprPhone04ViewTextChangedCommand = null;
        public ICommand ScanByVwLprPhone04ViewTextChangedCommand
        {
            get
            {
                return _ScanByVwLprPhone04ViewTextChangedCommand ?? (_ScanByVwLprPhone04ViewTextChangedCommand = new Command((prm) => ScanByVwLprPhone04ViewTextChangedCommandExecute(prm), (prm) => ScanByVwLprPhone04ViewTextChangedCommandCanExecute(prm)));
            }
        }
        // Reason: UserInput = 0, ProgrammaticChange = 1, SuggestionChosen = 2
        protected async void ScanByVwLprPhone04ViewTextChangedCommandExecute(object prm)
        {
            if ((IsDsDestroyed) || (prm is null)) return;
            (object Cmpnt, object Sender, IUniqServiceFilterDefInterface FltDef, int Reason, string QueryText) tprm  = ((object Cmpnt, object Sender, IUniqServiceFilterDefInterface FltDef, int Reason, string QueryText))prm;
            if(tprm.Reason != 0) return;
            switch(tprm.FltDef.fltrName) {
                case "Phone":
                    _ScanByVwLprPhone04ViewPhoneItem = null;
                    string qstr = tprm.QueryText;
                    if(qstr is null) qstr = "";
                    if(_ScanByVwLprPhone04ViewPhoneText == qstr) return;
                    _ScanByVwLprPhone04ViewPhoneText = qstr;
                    {
                        ILpdPhoneViewFilter fltr = FrmSrvLpdPhoneView.GetFilter();
                        fltr.page = 0;
                        fltr.pagesize = 15;
                        fltr.Phone = new List<string>() { qstr };
                        fltr.phoneOprtr = new List<string>() { "lk" };
                        ILpdPhoneViewPage rslt = await FrmSrvLpdPhoneView.getmanybyrepunqLpdPhoneUK(fltr);
                        if(rslt is null) {
                            ScanByVwLprPhone04ViewPhoneItemsSource = null;
                        } else {
                            ScanByVwLprPhone04ViewPhoneItemsSource = rslt.items;
                        }
                    }
                    break;
                default:
                    break;
            }            
        }
        protected bool ScanByVwLprPhone04ViewTextChangedCommandCanExecute(object prm)
        {
            return true;
        }

        protected ICommand _ScanByVwLprPhone04ViewQuerySubmitted = null;
        public ICommand ScanByVwLprPhone04ViewQuerySubmitted
        {
            get
            {
                return _ScanByVwLprPhone04ViewQuerySubmitted ?? (_ScanByVwLprPhone04ViewQuerySubmitted = new Command((prm) => ScanByVwLprPhone04ViewQuerySubmittedExecute(prm), (prm) => ScanByVwLprPhone04ViewQuerySubmittedCanExecute(prm)));
            }
        }
        protected void ScanByVwLprPhone04ViewQuerySubmittedExecute(object prm)
        {
            if ((IsDsDestroyed) || (prm is null)) return;
            (object Cmpnt, object Sender, IUniqServiceFilterDefInterface FltDef, object ChosenSuggestion, string QueryText) tprm  = 
                ((object Cmpnt, object Sender, IUniqServiceFilterDefInterface FltDef, object ChosenSuggestion, string QueryText))prm;
            switch(tprm.FltDef.fltrName) {
                case "Phone":
                    ScanByVwLprPhone04ViewPhoneItem = tprm.ChosenSuggestion as ILpdPhoneView;
                    ScanByVwLprPhone04ViewPhoneItemsSource = null;
                    break;
                default:
                    break;
            }
        }
        protected bool ScanByVwLprPhone04ViewQuerySubmittedCanExecute(object prm)
        {
            return true;
        }
        protected ICommand _ScanByVwLprPhone04ViewUnfocusedCommand = null;
        public ICommand ScanByVwLprPhone04ViewUnfocusedCommand
        {
            get
            {
                return _ScanByVwLprPhone04ViewUnfocusedCommand ?? (_ScanByVwLprPhone04ViewUnfocusedCommand = new Command((prm) => ScanByVwLprPhone04ViewUnfocusedCommandExecute(prm), (prm) => ScanByVwLprPhone04ViewUnfocusedCommandCanExecute(prm)));
            }
        }
        protected void ScanByVwLprPhone04ViewUnfocusedCommandExecute(object prm)
        {
            if ((IsDsDestroyed) || (prm is null)) return;
            (object Cmpnt, object Sender, IUniqServiceFilterDefInterface FltDef) tprm  = 
                ((object Cmpnt, object Sender, IUniqServiceFilterDefInterface FltDef))prm;
            switch(tprm.FltDef.fltrName) {
                case "Phone":
                    ScanByVwLprPhone04ViewPhoneItemsSource = null;
                    break;
                default:
                    break;
            }
        }
        protected bool ScanByVwLprPhone04ViewUnfocusedCommandCanExecute(object prm) {
            return true;
        }


        #endregion
        #region ScanByUkPrimaryFilterDefinitions
        protected IList<IUniqServiceFilterDefInterface> _ScanByUkPrimaryFilterDefinitions =
            new List<IUniqServiceFilterDefInterface>() {
                new UniqServiceFilterDef() { fltrName = "PhoneId", fltrDispMemb = "PhoneId", fltrTextMemb = "PhoneId", fltrCaption = "Phone Id", fltrDataType = "int32", fltrMaxLen = null, fltrMin = null, fltrMax = null },
            };
        public IList<IUniqServiceFilterDefInterface> ScanByUkPrimaryFilterDefinitions {
            get {
                return _ScanByUkPrimaryFilterDefinitions;
            }
        }

        protected IPhbkPhoneView _ScanByUkPrimaryPhoneIdItem = null;
        public IPhbkPhoneView ScanByUkPrimaryPhoneIdItem {
            get {
                return _ScanByUkPrimaryPhoneIdItem;
            }
            set {
                if (_ScanByUkPrimaryPhoneIdItem != value) {
                    _ScanByUkPrimaryPhoneIdItem = value;
                    OnPropertyChanged();
                    OnPropertyChanged("ScanByUkPrimaryPhoneIdText");
                }
            }
        }
        
        protected IList<IPhbkPhoneView> _ScanByUkPrimaryItemsSource = null;
        public IList<IPhbkPhoneView> ScanByUkPrimaryItemsSource {
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

        protected string _ScanByUkPrimaryPhoneIdText = "";
        public string ScanByUkPrimaryPhoneIdText {
            get {
                IPhbkPhoneView dmObj = ScanByUkPrimaryPhoneIdItem;
                if(dmObj != null) {
                    return dmObj.PhoneId.ToString();
                } else {
                    return _ScanByUkPrimaryPhoneIdText;
                }

            }
            set {
                if(_ScanByUkPrimaryPhoneIdText != value) {
                    if(value is null)
                        _ScanByUkPrimaryPhoneIdText = "";
                    else
                        _ScanByUkPrimaryPhoneIdText = value;
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
                case "PhoneId":
                    k = 0;
                    break;
                default:
                    return;
            }
            IPhbkPhoneView itm = null;
            IPhbkPhoneViewFilter fltr = FrmRootSrv.GetFilter();
            fltr.page = 0;
            fltr.pagesize = 15;
            bool runQuery = true;
            itm = ScanByUkPrimaryPhoneIdItem;
            if (k > 0)  { 
                if(itm is null) {
                    runQuery = false;
                } else {
                    fltr.PhoneId = new List<System.Int32>() { itm.PhoneId }; 
                    fltr.phoneIdOprtr = new List<string>() { "eq" };
                }
             } else if(k == 0) { 
                ScanByUkPrimaryPhoneIdItem = null;
                ScanByUkPrimaryPhoneIdText = tprm.QueryText;
                string qstr = tprm.QueryText;
                if(qstr is null) qstr = "";
                if(_ScanByUkPrimaryPhoneIdText == qstr) return;
                _ScanByUkPrimaryPhoneIdText = qstr;


                {
                    System.Int32 val;
                    if (System.Int32.TryParse(qstr, out val)) {
                        fltr.PhoneId = new List<System.Int32>() { val };
                    }
                }
                fltr.phoneIdOprtr = new List<string>() { "lk" };
             }
            if (runQuery) {
                IPhbkPhoneViewPage rslt = await FrmRootSrv.getmanybyrepprim(fltr);
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
                case "PhoneId":
                    ScanByUkPrimaryPhoneIdItem = tprm.ChosenSuggestion as IPhbkPhoneView;
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
        IList<string> mdlDrctFkProps = new List<string>{  "PhoneTypeIdRef", "EmployeeIdRef" };
        IList<string> mdlMptProps = new List<string>{  "PhoneId", "Phone", "PhoneTypeIdRef", "EmployeeIdRef" };
        Dictionary<string, IList<string>> reqHiddenProps = new Dictionary<string, IList<string>>() {
                    {"LprPhone01View", new List<string> {  }},
                    {"LprPhone02View", new List<string> {  "EmployeeIdRef" }},
                    {"LprPhone03View", new List<string> {  "PhoneTypeIdRef" }},
                    {"LprPhone04View", new List<string> {  "EmployeeIdRef", "PhoneTypeIdRef" }},
        };
        Dictionary<string, IList<string>> extHiddenProps = new Dictionary<string, IList<string>>() {
                    {"LprPhone01View", new List<string> { }},
                    {"LprPhone02View", new List<string> { }},
                    {"LprPhone03View", new List<string> { }},
                    {"LprPhone04View", new List<string> { }},
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
            doIns = crrMDFP.Count == this.reqHiddenProps["LprPhone01View"].Count;
            if(doIns) {
                doIns = (this.reqHiddenProps["LprPhone01View"].Count(s => crrMDFP.Contains(s))) == crrMDFP.Count;
                
                if(doIns) {
                    if(hasNtExternal) {
                        foreach (var fld in this.extHiddenProps["LprPhone01View"]) { 
                            doIns = this.HiddenFiltersVM.Any(f => f.fltrName == fld);
                            if(!doIns) break;
                        }
                    } else {
                        doIns = extHiddflt.Count == this.extHiddenProps["LprPhone01View"].Count;
                        if(doIns) doIns = extHiddflt.Count(s => this.extHiddenProps["LprPhone01View"].Contains(s)) == extHiddflt.Count;
                    }
                }
            }
            if(doIns) {
                rslt.Add( 
                    new WebServiceFilterMenuViewModel() { Id = "ScanByVwLprPhone01View", Caption="filter by Phone Dict Ref", IconName=IconFont.Refresh, IconColor=Color.Default, Enabled=true, Data=null, Command = TableMenuItemsCommand}
                );
            }
            doIns = crrMDFP.Count == this.reqHiddenProps["LprPhone02View"].Count;
            if(doIns) {
                doIns = (this.reqHiddenProps["LprPhone02View"].Count(s => crrMDFP.Contains(s))) == crrMDFP.Count;
                
                if(doIns) {
                    if(hasNtExternal) {
                        foreach (var fld in this.extHiddenProps["LprPhone02View"]) { 
                            doIns = this.HiddenFiltersVM.Any(f => f.fltrName == fld);
                            if(!doIns) break;
                        }
                    } else {
                        doIns = extHiddflt.Count == this.extHiddenProps["LprPhone02View"].Count;
                        if(doIns) doIns = extHiddflt.Count(s => this.extHiddenProps["LprPhone02View"].Contains(s)) == extHiddflt.Count;
                    }
                }
            }
            if(doIns) {
                rslt.Add( 
                    new WebServiceFilterMenuViewModel() { Id = "ScanByVwLprPhone02View", Caption="filter by Phone Dict Ref", IconName=IconFont.Refresh, IconColor=Color.Default, Enabled=true, Data=null, Command = TableMenuItemsCommand}
                );
            }
            doIns = crrMDFP.Count == this.reqHiddenProps["LprPhone03View"].Count;
            if(doIns) {
                doIns = (this.reqHiddenProps["LprPhone03View"].Count(s => crrMDFP.Contains(s))) == crrMDFP.Count;
                
                if(doIns) {
                    if(hasNtExternal) {
                        foreach (var fld in this.extHiddenProps["LprPhone03View"]) { 
                            doIns = this.HiddenFiltersVM.Any(f => f.fltrName == fld);
                            if(!doIns) break;
                        }
                    } else {
                        doIns = extHiddflt.Count == this.extHiddenProps["LprPhone03View"].Count;
                        if(doIns) doIns = extHiddflt.Count(s => this.extHiddenProps["LprPhone03View"].Contains(s)) == extHiddflt.Count;
                    }
                }
            }
            if(doIns) {
                rslt.Add( 
                    new WebServiceFilterMenuViewModel() { Id = "ScanByVwLprPhone03View", Caption="filter by Phone Dict Ref", IconName=IconFont.Refresh, IconColor=Color.Default, Enabled=true, Data=null, Command = TableMenuItemsCommand}
                );
            }
            doIns = crrMDFP.Count == this.reqHiddenProps["LprPhone04View"].Count;
            if(doIns) {
                doIns = (this.reqHiddenProps["LprPhone04View"].Count(s => crrMDFP.Contains(s))) == crrMDFP.Count;
                
                if(doIns) {
                    if(hasNtExternal) {
                        foreach (var fld in this.extHiddenProps["LprPhone04View"]) { 
                            doIns = this.HiddenFiltersVM.Any(f => f.fltrName == fld);
                            if(!doIns) break;
                        }
                    } else {
                        doIns = extHiddflt.Count == this.extHiddenProps["LprPhone04View"].Count;
                        if(doIns) doIns = extHiddflt.Count(s => this.extHiddenProps["LprPhone04View"].Contains(s)) == extHiddflt.Count;
                    }
                }
            }
            if(doIns) {
                rslt.Add( 
                    new WebServiceFilterMenuViewModel() { Id = "ScanByVwLprPhone04View", Caption="filter by Phone Dict Ref", IconName=IconFont.Refresh, IconColor=Color.Default, Enabled=true, Data=null, Command = TableMenuItemsCommand}
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

