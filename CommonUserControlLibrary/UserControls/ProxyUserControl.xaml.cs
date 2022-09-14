using Xamarin.Forms;
using System.Collections.Generic;
using System.Windows.Input;
using System.Collections.Specialized;
using System.Reflection;
using Prism.Regions;
using Prism.Navigation;
using System.Linq;
using CommonInterfacesClassLibrary.Interfaces;
using CommonInterfacesClassLibrary.Enums;

namespace CommonUserControlLibrary.UserControls {
    /// <summary>
    /// Interaction logic for ProxyUserControl.xaml
    /// </summary>
    public partial class ProxyUserControl: ContentView, IDestructible
    {
        public ProxyUserControl()
        {
            InitializeComponent();
        }
        #region Caption
        public static readonly BindableProperty CaptionProperty =
                BindableProperty.Create(
                "Caption", typeof(string),
                typeof(ProxyUserControl),
                null);
        public string Caption
        {
            get
            {
                return (string)GetValue(CaptionProperty);
            }
            set
            {
                SetValue(CaptionProperty, value);
            }
        }
        #endregion
        #region FilterHeight
        public static readonly BindableProperty FilterHeightProperty =
                BindableProperty.Create(
                "FilterHeight", typeof(double),
                typeof(ProxyUserControl),
                -1d);
        public double FilterHeight
        {
            get
            {
                return (double)GetValue(FilterHeightProperty);
            }
            set
            {
                SetValue(FilterHeightProperty, value);
            }
        }
        #endregion
        #region ShowFilter
        public static readonly BindableProperty ShowFilterProperty =
                BindableProperty.Create(
                "ShowFilter", typeof(bool),
                typeof(ProxyUserControl),
                true);
        public bool ShowFilter
        {
            get
            {
                return (bool)GetValue(ShowFilterProperty);
            }
            set
            {
                SetValue(ShowFilterProperty, value);
            }
        }
        #endregion
        #region ShowAddFilterBtn
        public static readonly BindableProperty ShowAddFilterBtnProperty =
                BindableProperty.Create(
                "ShowAddFilterBtn", typeof(bool),
                typeof(ProxyUserControl),
                true);
        public bool ShowAddFilterBtn
        {
            get
            {
                return (bool)GetValue(ShowAddFilterBtnProperty);
            }
            set
            {
                SetValue(ShowAddFilterBtnProperty, value);
            }
        }
        #endregion
        #region GridHeight
        public static readonly BindableProperty GridHeightProperty =
                BindableProperty.Create(
                "GridHeight", typeof(double),
                typeof(ProxyUserControl),
                -1d);
        public double GridHeight
        {
            get
            {
                return (double)GetValue(GridHeightProperty);
            }
            set
            {
                SetValue(GridHeightProperty, value);
            }
        }
        #endregion
        #region ShowBackBtn
        public static readonly BindableProperty ShowBackBtnProperty =
                BindableProperty.Create(
                "ShowBackBtn", typeof(bool),
                typeof(ProxyUserControl),
                false);
        public bool ShowBackBtn
        {
            get
            {
                return (bool)GetValue(ShowBackBtnProperty);
            }
            set
            {
                SetValue(ShowBackBtnProperty, value);
            }
        }
        #endregion
        #region NavigationBackCommand
        private static void NavigationBackCommandChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ProxyUserControl d = bindable as ProxyUserControl;
            if (d != null)
            {
                (d.OnNavigationBackCommand as Command).ChangeCanExecute();
            }
        }
        public static readonly BindableProperty NavigationBackCommandProperty =
            BindableProperty.Create(nameof(NavigationBackCommand), typeof(ICommand), 
            typeof(ProxyUserControl), 
            propertyChanged: NavigationBackCommandChanged);
        public ICommand NavigationBackCommand
        {
            get { return (ICommand)GetValue(NavigationBackCommandProperty); }
            set { SetValue(NavigationBackCommandProperty, value); }
        }
        #endregion
        #region OnNavigationBackCommand
        protected ICommand _OnNavigationBackCommand = null;
        public ICommand OnNavigationBackCommand
        {
            get
            {
                return _OnNavigationBackCommand ?? (_OnNavigationBackCommand = new Command((prm) => OnNavigationBackCommandExecute(prm), (prm) => OnNavigationBackCommandCanExecute(prm)));
            }
        }
        protected void OnNavigationBackCommandExecute(object  prm)
        {
            ICommand cmd = NavigationBackCommand;
            if(cmd != null) {
                if(cmd.CanExecute(prm)) {
                    cmd.Execute(prm);
                }
            }
        }
        protected bool OnNavigationBackCommandCanExecute(object  prm)
        {
            return (NavigationBackCommand != null); 
//
//            ICommand cmd = NavigationBackCommand;
//            if (cmd != null)
//              return cmd.CanExecute(prm);
//            else
//              return false;

        }
        #endregion
        #region TableMenuItems
        public static readonly BindableProperty TableMenuItemsProperty =
                BindableProperty.Create(
                "TableMenuItems", typeof(IEnumerable<IWebServiceFilterMenuInterface>),
                typeof(ProxyUserControl),
                null);
        public IEnumerable<IWebServiceFilterMenuInterface> TableMenuItems
        {
            get
            {
                return (IEnumerable<IWebServiceFilterMenuInterface>)GetValue(TableMenuItemsProperty);
            }
            set
            {
                SetValue(TableMenuItemsProperty, value);
            }
        }
        #endregion
        #region TableMenuItemsCommand
        private static void TableMenuItemsCommandChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ProxyUserControl d = bindable as ProxyUserControl;
            if (d != null)
            {
                (d.OnTableMenuItemsCommand as Command).ChangeCanExecute();
            }
        }
        public static readonly BindableProperty TableMenuItemsCommandProperty =
                BindableProperty.Create(
                "TableMenuItemsCommand", typeof(ICommand),
                typeof(ProxyUserControl),
                null, propertyChanged: TableMenuItemsCommandChanged);
        public ICommand TableMenuItemsCommand
        {
            get
            {
                return (ICommand)GetValue(TableMenuItemsCommandProperty);
            }
            set
            {
                SetValue(TableMenuItemsCommandProperty, value);
            }
        }
        #endregion
        #region OnTableMenuItemsCommand
        protected ICommand _OnTableMenuItemsCommand = null;
        public ICommand OnTableMenuItemsCommand
        {
            get
            {
                return _OnTableMenuItemsCommand ?? (_OnTableMenuItemsCommand = new Command((prm) => OnTableMenuItemsCommandExecute(prm), (prm) => OnTableMenuItemsCommandCanExecute(prm)));
            }
        }
        protected void OnTableMenuItemsCommandExecute(object  prm)
        {
            ICommand cmd = TableMenuItemsCommand;
            if(cmd != null) {
                if(cmd.CanExecute(prm)) {
                    cmd.Execute(prm);
                }
            }
        }
        protected bool OnTableMenuItemsCommandCanExecute(object  prm)
        {
            return (TableMenuItemsCommand != null); 
//
//            ICommand cmd = TableMenuItemsCommand;
//            if (cmd != null)
//              return cmd.CanExecute(prm);
//            else
//              return false;

        }
        #endregion
        #region RowMenuItems
        public static readonly BindableProperty RowMenuItemsProperty =
                BindableProperty.Create(
                "RowMenuItems", typeof(IEnumerable<IWebServiceFilterMenuInterface>),
                typeof(ProxyUserControl),
                null);
        public IEnumerable<IWebServiceFilterMenuInterface> RowMenuItems
        {
            get
            {
                return (IEnumerable<IWebServiceFilterMenuInterface>)GetValue(RowMenuItemsProperty);
            }
            set
            {
                SetValue(RowMenuItemsProperty, value);
            }
        }
        #endregion
        #region RowMenuItemsCommand
        private static void RowMenuItemsCommandChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ProxyUserControl d = bindable as ProxyUserControl;
            if (d != null)
            {
                (d.OnRowMenuItemsCommand as Command).ChangeCanExecute();
            }
        }
        public static readonly BindableProperty RowMenuItemsCommandProperty =
                BindableProperty.Create(
                "RowMenuItemsCommand", typeof(ICommand),
                typeof(ProxyUserControl),
                null);
        public ICommand RowMenuItemsCommand
        {
            get
            {
                return (ICommand)GetValue(RowMenuItemsCommandProperty);
            }
            set
            {
                SetValue(RowMenuItemsCommandProperty, value);
            }
        }
        #endregion
        #region OnRowMenuItemsCommand
        protected ICommand _OnRowMenuItemsCommand = null;
        public ICommand OnRowMenuItemsCommand
        {
            get
            {
                return _OnRowMenuItemsCommand ?? (_OnRowMenuItemsCommand = new Command((prm) => OnRowMenuItemsCommandExecute(prm), (prm) => OnRowMenuItemsCommandCanExecute(prm)));
            }
        }
        protected void OnRowMenuItemsCommandExecute(object  prm)
        {
            ICommand cmd = RowMenuItemsCommand;
            if(cmd != null) {
                if(cmd.CanExecute(prm)) {
                    cmd.Execute(prm);
                }
            }
        }
        protected bool OnRowMenuItemsCommandCanExecute(object  prm)
        {
            return (RowMenuItemsCommand != null); 
//
//            ICommand cmd = RowMenuItemsCommand;
//            if (cmd != null)
//              return cmd.CanExecute(prm);
//            else
//              return false;

        }
        #endregion
        #region ContainerMenuItems
        public static readonly BindableProperty ContainerMenuItemsProperty =
                BindableProperty.Create(
                "ContainerMenuItems", typeof(IEnumerable<IWebServiceFilterMenuInterface>),
                typeof(ProxyUserControl),
                null);
        public IEnumerable<IWebServiceFilterMenuInterface> ContainerMenuItems
        {
            get
            {
                return (IEnumerable<IWebServiceFilterMenuInterface>)GetValue(ContainerMenuItemsProperty);
            }
            set
            {
                SetValue(ContainerMenuItemsProperty, value);
            }
        }
        #endregion
        #region ContainerMenuItemsCommand
        private static void ContainerMenuItemsCommandChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ProxyUserControl d = bindable as ProxyUserControl;
            if (d != null)
            {
                (d.OnContainerMenuItemsCommand as Command).ChangeCanExecute();
            }
        }
        public static readonly BindableProperty ContainerMenuItemsCommandProperty =
            BindableProperty.Create(nameof(ContainerMenuItemsCommand), typeof(ICommand), 
            typeof(ProxyUserControl), 
            null, propertyChanged: ContainerMenuItemsCommandChanged);
        public ICommand ContainerMenuItemsCommand
        {
            get { return (ICommand)GetValue(ContainerMenuItemsCommandProperty); }
            set { SetValue(ContainerMenuItemsCommandProperty, value); }
        }
        #endregion
        #region OnContainerMenuItemsCommand
        protected ICommand _OnContainerMenuItemsCommand = null;
        public ICommand OnContainerMenuItemsCommand
        {
            get
            {
                return _OnContainerMenuItemsCommand ?? (_OnContainerMenuItemsCommand = new Command((p) => OnContainerMenuItemsCommandExecute(p), (p) => OnContainerMenuItemsCommandCanExecute(p)));
            }
        }
        protected void OnContainerMenuItemsCommandExecute(object prm)
        {
            ICommand cmd = ContainerMenuItemsCommand;
            if(cmd != null) {
                if(cmd.CanExecute(prm)) {
                    cmd.Execute(prm);
                }
            }
        }
        protected bool OnContainerMenuItemsCommandCanExecute(object prm)
        {
            return (ContainerMenuItemsCommand != null); 

//
//            ICommand cmd = ContainerMenuItemsCommand;
//            if (cmd != null)
//              return cmd.CanExecute(prm);
//            else
//              return false;

        }
        #endregion
        #region SelectedRowCommand
        private static void SelectedRowCommandChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ProxyUserControl d = bindable as ProxyUserControl;
            if (d != null)
            {
                (d.OnSelectedRowCommand as Command).ChangeCanExecute();
            }
        }
        public static readonly BindableProperty SelectedRowCommandProperty =
                BindableProperty.Create(
                "SelectedRowCommand", typeof(ICommand),
                typeof(ProxyUserControl),
                null, propertyChanged: SelectedRowCommandChanged);
        public ICommand SelectedRowCommand
        {
            get
            {
                return (ICommand)GetValue(SelectedRowCommandProperty);
            }
            set
            {
                SetValue(SelectedRowCommandProperty, value);
            }
        }
        #endregion
        #region OnSelectedRowCommand
        protected ICommand _OnSelectedRowCommand = null;
        public ICommand OnSelectedRowCommand
        {
            get
            {
                return _OnSelectedRowCommand ?? (_OnSelectedRowCommand = new Command((p) => OnSelectedRowCommandExecute(p), (p) => OnSelectedRowCommandCanExecute(p)));
            }
        }
        protected void OnSelectedRowCommandExecute(object prm)
        {
            ICommand cmd = SelectedRowCommand;
            if(cmd != null) {
                if(cmd.CanExecute(prm)) {
                    cmd.Execute(prm);
                }
            }
        }
        protected bool OnSelectedRowCommandCanExecute(object prm)
        {
            return (SelectedRowCommand != null); 

//
//            ICommand cmd = ContainerMenuItemsCommand;
//            if (cmd != null)
//              return cmd.CanExecute(prm);
//            else
//              return false;

        }
        #endregion
        #region HiddenFilters
        public static readonly BindableProperty HiddenFiltersProperty =
                BindableProperty.Create(
                "HiddenFilters", typeof(IEnumerable<IWebServiceFilterRsltInterface>),
                typeof(ProxyUserControl),
                null);
        public IEnumerable<IWebServiceFilterRsltInterface> HiddenFilters
        {
            get
            {
                return (IEnumerable<IWebServiceFilterRsltInterface>)GetValue(HiddenFiltersProperty);
            }
            set
            {
                SetValue(HiddenFiltersProperty, value);
            }
        }
        #endregion
        #region SformAfterAddItem
        public static readonly BindableProperty SformAfterAddItemProperty =
                BindableProperty.Create(
                "SformAfterAddItem", typeof(object),
                typeof(ProxyUserControl),
                null);
        public object SformAfterAddItem
        {
            get
            {
                return (object)GetValue(SformAfterAddItemProperty);
            }
            set
            {
                SetValue(SformAfterAddItemProperty, value);
            }
        }
        #endregion
        #region SformAfterUpdItem
        public static readonly BindableProperty SformAfterUpdItemProperty =
                BindableProperty.Create(
                "SformAfterUpdItem", typeof(object),
                typeof(ProxyUserControl),
                null);
        public object SformAfterUpdItem
        {
            get
            {
                return (object)GetValue(SformAfterUpdItemProperty);
            }
            set
            {
                SetValue(SformAfterUpdItemProperty, value);
            }
        }
        #endregion
        #region SformAfterDelItem
        public static readonly BindableProperty SformAfterDelItemProperty =
                BindableProperty.Create(
                "SformAfterDelItem", typeof(object),
                typeof(ProxyUserControl),
                null);
        public object SformAfterDelItem
        {
            get
            {
                return (object)GetValue(SformAfterDelItemProperty);
            }
            set
            {
                SetValue(SformAfterDelItemProperty, value);
            }
        }
        #endregion 
        #region SubmitCommand
        private static void SubmitCommandChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ProxyUserControl d = bindable as ProxyUserControl;
            if (d != null)
            {
                if (d.OnSubmitCommand != null)
                {
                    (d.OnSubmitCommand as Command).ChangeCanExecute();
                }
            }
        }
        public static readonly BindableProperty SubmitCommandProperty =
            BindableProperty.Create(nameof(SubmitCommand), typeof(ICommand), 
            typeof(ProxyUserControl), 
            null, 
            propertyChanged: SubmitCommandChanged);
        public ICommand SubmitCommand
        {
            get { return (ICommand)GetValue(SubmitCommandProperty); }
            set { SetValue(SubmitCommandProperty, value); }
        }
        #endregion

        #region OnSubmitCommand
        protected ICommand _OnSubmitCommand = null;
        public ICommand OnSubmitCommand
        {
            get
            {
                return _OnSubmitCommand ?? (_OnSubmitCommand = new Command((p) => OnSubmitCommandExecute(p), (p) => OnSubmitCommandCanExecute(p)));
            }
        }
        protected void OnSubmitCommandExecute(object prm)
        {
            ICommand cmd = SubmitCommand;
            if(cmd != null) {
                if(cmd.CanExecute(prm)) {
                    cmd.Execute(prm);
                }
            }
        }
        protected bool OnSubmitCommandCanExecute(object p)
        {
            return (SubmitCommand != null); 
        }
        #endregion

        #region CancelCommand
        private static void CancelCommandChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ProxyUserControl d = bindable as ProxyUserControl;
            if (d != null)
            {
                if (d.OnCancelCommand != null)
                {
                    (d.OnCancelCommand as Command).ChangeCanExecute();
                }
            }
        }
        public static readonly BindableProperty CancelCommandProperty =
            BindableProperty.Create(nameof(CancelCommand), typeof(ICommand), 
            typeof(ProxyUserControl), 
            null, 
            propertyChanged: CancelCommandChanged);
        public ICommand CancelCommand
        {
            get { return (ICommand)GetValue(CancelCommandProperty); }
            set { SetValue(CancelCommandProperty, value); }
        }
        #endregion

        #region OnCancelCommand
        protected ICommand _OnCancelCommand = null;
        public ICommand OnCancelCommand
        {
            get
            {
                return _OnCancelCommand ?? (_OnCancelCommand = new Command((p) => OnCancelCommandExecute(p), (p) => OnCancelCommandCanExecute(p)));
            }
        }
        protected void OnCancelCommandExecute(object prm)
        {
            ICommand cmd = CancelCommand;
            if(cmd != null) {
                if(cmd.CanExecute(prm)) {
                    cmd.Execute(prm);
                }
            }
        }
        protected bool OnCancelCommandCanExecute(object p)
        {
            return (CancelCommand != null); 
        }
        #endregion

        #region ShowSubmit
        public static readonly BindableProperty ShowSubmitProperty =
                BindableProperty.Create(
                "ShowSubmit", typeof(bool),
                typeof(ProxyUserControl),
                true);
        public bool ShowSubmit
        {
            get
            {
                return (bool)GetValue(ShowSubmitProperty);
            }
            set
            {
                SetValue(ShowSubmitProperty, value);
            }
        }
        #endregion
        #region FormControlModel
        public static readonly BindableProperty FormControlModelProperty =
                BindableProperty.Create(
                "FormControlModel", typeof(object),
                typeof(ProxyUserControl),
                null);
        public object FormControlModel
        {
            get
            {
                return (object)GetValue(FormControlModelProperty);
            }
            set
            {
                SetValue(FormControlModelProperty, value);
            }
        }
        #endregion
        #region EformMode
        public static readonly BindableProperty EformModeProperty =
                BindableProperty.Create(
                "EformMode", typeof(EformModeEnum),
                typeof(ProxyUserControl),
                EformModeEnum.DeleteMode);
        public EformModeEnum EformMode
        {
            get
            {
                return (EformModeEnum)GetValue(EformModeProperty);
            }
            set
            {
                SetValue(EformModeProperty, value);
            }
        }
        #endregion
        #region CanAdd
        public static readonly BindableProperty CanAddProperty =
                BindableProperty.Create(
                "CanAdd", typeof(bool),
                typeof(ProxyUserControl),
                false);
        public bool CanAdd
        {
            get
            {
                return (bool)GetValue(CanAddProperty);
            }
            set
            {
                SetValue(CanAddProperty, value);
            }
        }
        #endregion
        #region CanUpdate
        public static readonly BindableProperty CanUpdateProperty =
                BindableProperty.Create(
                "CanUpdate", typeof(bool),
                typeof(ProxyUserControl),
                false);
        public bool CanUpdate
        {
            get
            {
                return (bool)GetValue(CanUpdateProperty);
            }
            set
            {
                SetValue(CanUpdateProperty, value);
            }
        }
        #endregion
        #region CanDelete
        public static readonly BindableProperty CanDeleteProperty =
                BindableProperty.Create(
                "CanDelete", typeof(bool),
                typeof(ProxyUserControl),
                false);
        public bool CanDelete
        {
            get
            {
                return (bool)GetValue(CanDeleteProperty);
            }
            set
            {
                SetValue(CanDeleteProperty, value);
            }
        }
        #endregion
        #region SformAfterAddItemCommand
        public static readonly BindableProperty SformAfterAddItemCommandProperty =
                BindableProperty.Create(
                "SformAfterAddItemCommand", typeof(ICommand),
                typeof(ProxyUserControl),
                null);
        public ICommand SformAfterAddItemCommand
        {
            get
            {
                return (ICommand)GetValue(SformAfterAddItemCommandProperty);
            }
            set
            {
                SetValue(SformAfterAddItemCommandProperty, value);
            }
        }
        #endregion
        #region OnSformAfterAddItemCommand
        protected ICommand _OnSformAfterAddItemCommand = null;
        public ICommand OnSformAfterAddItemCommand
        {
            get
            {
                return _OnSformAfterAddItemCommand ?? (_OnSformAfterAddItemCommand = new Command((p) => OnSformAfterAddItemCommandExecute(p), (p) => OnSformAfterAddItemCommandCanExecute(p)));
            }
        }
        protected void OnSformAfterAddItemCommandExecute(object prm)
        {
            ICommand cmd = SformAfterAddItemCommand;
            if(cmd != null) {
                if(cmd.CanExecute(prm)) {
                    cmd.Execute(prm);
                }
            }
        }
        protected bool OnSformAfterAddItemCommandCanExecute(object p)
        {
            return (SformAfterAddItemCommand != null); 
        }
        #endregion
        #region SformAfterUpdItemCommand
        public static readonly BindableProperty SformAfterUpdItemCommandProperty =
                BindableProperty.Create(
                "SformAfterUpdItemCommand", typeof(ICommand),
                typeof(ProxyUserControl),
                null);
        public ICommand SformAfterUpdItemCommand
        {
            get
            {
                return (ICommand)GetValue(SformAfterUpdItemCommandProperty);
            }
            set
            {
                SetValue(SformAfterUpdItemCommandProperty, value);
            }
        }
        #endregion
        #region OnSformAfterUpdItemCommand
        protected ICommand _OnSformAfterUpdItemCommand = null;
        public ICommand OnSformAfterUpdItemCommand
        {
            get
            {
                return _OnSformAfterUpdItemCommand ?? (_OnSformAfterUpdItemCommand = new Command((p) => OnSformAfterUpdItemCommandExecute(p), (p) => OnSformAfterUpdItemCommandCanExecute(p)));
            }
        }
        protected void OnSformAfterUpdItemCommandExecute(object prm)
        {
            ICommand cmd = SformAfterUpdItemCommand;
            if(cmd != null) {
                if(cmd.CanExecute(prm)) {
                    cmd.Execute(prm);
                }
            }
        }
        protected bool OnSformAfterUpdItemCommandCanExecute(object p)
        {
            return (SformAfterUpdItemCommand != null); 
        }
        #endregion
        #region SformAfterDelItemCommand
        public static readonly BindableProperty SformAfterDelItemCommandProperty =
                BindableProperty.Create(
                "SformAfterDelItemCommand", typeof(ICommand),
                typeof(ProxyUserControl),
                null);
        public ICommand SformAfterDelItemCommand
        {
            get
            {
                return (ICommand)GetValue(SformAfterDelItemCommandProperty);
            }
            set
            {
                SetValue(SformAfterDelItemCommandProperty, value);
            }
        }
        #endregion
        #region OnSformAfterDelItemCommand
        protected ICommand _OnSformAfterDelItemCommand = null;
        public ICommand OnSformAfterDelItemCommand
        {
            get
            {
                return _OnSformAfterDelItemCommand ?? (_OnSformAfterDelItemCommand = new Command((p) => OnSformAfterDelItemCommandExecute(p), (p) => OnSformAfterDelItemCommandCanExecute(p)));
            }
        }
        protected void OnSformAfterDelItemCommandExecute(object prm)
        {
            ICommand cmd = SformAfterUpdItemCommand;
            if(cmd != null) {
                if(cmd.CanExecute(prm)) {
                    cmd.Execute(prm);
                }
            }
        }
        protected bool OnSformAfterDelItemCommandCanExecute(object p)
        {
            return (SformAfterUpdItemCommand != null); 
        }
        #endregion
        #region IsParentLoaded
        public static readonly BindableProperty IsParentLoadedProperty =
                BindableProperty.Create(
                "IsParentLoaded", typeof(bool),
                typeof(ProxyUserControl),
                false);
        public bool IsParentLoaded
        {
            get
            {
                return (bool)GetValue(IsParentLoadedProperty);
            }
            set
            {
                SetValue(IsParentLoadedProperty, value);
            }
        }
        #endregion






        #region CanAddDetail
        public static readonly BindableProperty CanAddDetailProperty =
                BindableProperty.Create(
                "CanAddDetail", typeof(bool),
                typeof(ProxyUserControl),
                false);
        public bool CanAddDetail
        {
            get
            {
                return (bool)GetValue(CanAddDetailProperty);
            }
            set
            {
                SetValue(CanAddDetailProperty, value);
            }
        }
        #endregion

        #region CanUpdateDetail
        public static readonly BindableProperty CanUpdateDetailProperty =
                BindableProperty.Create(
                "CanUpdateDetail", typeof(bool),
                typeof(ProxyUserControl),
                false);
        public bool CanUpdateDetail
        {
            get
            {
                return (bool)GetValue(CanUpdateDetailProperty);
            }
            set
            {
                SetValue(CanUpdateDetailProperty, value);
            }
        }
        #endregion

        #region CanDeleteDetail
        public static readonly BindableProperty CanDeleteDetailProperty =
                BindableProperty.Create(
                "CanDeleteDetail", typeof(bool),
                typeof(ProxyUserControl),
                false);
        public bool CanDeleteDetail
        {
            get
            {
                return (bool)GetValue(CanDeleteDetailProperty);
            }
            set
            {
                SetValue(CanDeleteDetailProperty, value);
            }
        }
        #endregion

        #region FilterHeightDetail
        public static readonly BindableProperty FilterHeightDetailProperty =
                BindableProperty.Create(
                "FilterHeightDetail", typeof(double),
                typeof(ProxyUserControl),
                -1d);
        public double FilterHeightDetail
        {
            get
            {
                return (double)GetValue(FilterHeightDetailProperty);
            }
            set
            {
                SetValue(FilterHeightDetailProperty, value);
            }
        }
        #endregion

        #region ShowFilterDetail
        public static readonly BindableProperty ShowFilterDetailProperty =
                BindableProperty.Create(
                "ShowFilterDetail", typeof(bool),
                typeof(ProxyUserControl),
                true);
        public bool ShowFilterDetail
        {
            get
            {
                return (bool)GetValue(ShowFilterDetailProperty);
            }
            set
            {
                SetValue(ShowFilterDetailProperty, value);
            }
        }
        #endregion

        #region ShowAddFilterBtnDetail
        public static readonly BindableProperty ShowAddFilterBtnDetailProperty =
                BindableProperty.Create(
                "ShowAddFilterBtnDetail", typeof(bool),
                typeof(ProxyUserControl),
                true);
        public bool ShowAddFilterBtnDetail
        {
            get
            {
                return (bool)GetValue(ShowAddFilterBtnDetailProperty);
            }
            set
            {
                SetValue(ShowAddFilterBtnDetailProperty, value);
            }
        }
        #endregion

        #region GridHeightDetail
        public static readonly BindableProperty GridHeightDetailProperty =
                BindableProperty.Create(
                "GridHeightDetail", typeof(double),
                typeof(ProxyUserControl),
                -1d);
        public double GridHeightDetail
        {
            get
            {
                return (double)GetValue(GridHeightDetailProperty);
            }
            set
            {
                SetValue(GridHeightDetailProperty, value);
            }
        }
        #endregion

        #region HiddenFiltersDetail
        public static readonly BindableProperty HiddenFiltersDetailProperty =
                BindableProperty.Create(
                "HiddenFiltersDetail", typeof(IEnumerable<IWebServiceFilterRsltInterface>),
                typeof(ProxyUserControl),
                null);
        public IEnumerable<IWebServiceFilterRsltInterface> HiddenFiltersDetail
        {
            get
            {
                return (IEnumerable<IWebServiceFilterRsltInterface>)GetValue(HiddenFiltersDetailProperty);
            }
            set
            {
                SetValue(HiddenFiltersDetailProperty, value);
            }
        }
        #endregion

        #region RowMenuItemsDetail
        public static readonly BindableProperty RowMenuItemsDetailProperty =
                BindableProperty.Create(
                "RowMenuItemsDetail", typeof(IEnumerable<IWebServiceFilterMenuInterface>),
                typeof(ProxyUserControl),
                null);
        public IEnumerable<IWebServiceFilterMenuInterface> RowMenuItemsDetail
        {
            get
            {
                return (IEnumerable<IWebServiceFilterMenuInterface>)GetValue(RowMenuItemsDetailProperty);
            }
            set
            {
                SetValue(RowMenuItemsDetailProperty, value);
            }
        }
        #endregion

        #region TableMenuItemsDetail
        public static readonly BindableProperty TableMenuItemsDetailProperty =
                BindableProperty.Create(
                "TableMenuItemsDetail", typeof(IEnumerable<IWebServiceFilterMenuInterface>),
                typeof(ProxyUserControl),
                null);
        public IEnumerable<IWebServiceFilterMenuInterface> TableMenuItemsDetail
        {
            get
            {
                return (IEnumerable<IWebServiceFilterMenuInterface>)GetValue(TableMenuItemsDetailProperty);
            }
            set
            {
                SetValue(TableMenuItemsDetailProperty, value);
            }
        }
        #endregion

        #region IsPermissionEditable
        public static readonly BindableProperty IsPermissionEditableProperty =
                BindableProperty.Create(
                "IsPermissionEditable", typeof(bool),
                typeof(ProxyUserControl),
                false);
        public bool IsPermissionEditable
        {
            get
            {
                return (bool)GetValue(IsPermissionEditableProperty);
            }
            set
            {
                SetValue(IsPermissionEditableProperty, value);
            }
        }
        #endregion

        #region PermissionVector
        public static readonly BindableProperty PermissionVectorProperty =
                BindableProperty.Create(
                "PermissionVector", typeof(int[]),
                typeof(ProxyUserControl),
                null);
        public int[] PermissionVector
        {
            get
            {
                return (int[])GetValue(PermissionVectorProperty);
            }
            set
            {
                SetValue(PermissionVectorProperty, value);
            }
        }
        #endregion

        #region PermissionChangedCommand
        public static readonly BindableProperty PermissionChangedCommandProperty =
                BindableProperty.Create(
                "PermissionChangedCommand", typeof(ICommand),
                typeof(ProxyUserControl),
                null);
        public ICommand PermissionChangedCommand
        {
            get
            {
                return (ICommand)GetValue(PermissionChangedCommandProperty);
            }
            set
            {
                SetValue(PermissionChangedCommandProperty, value);
            }
        }
        #endregion
        #region OnPermissionChangedCommand
        protected ICommand _OnPermissionChangedCommand = null;
        public ICommand OnPermissionChangedCommand
        {
            get
            {
                return _OnPermissionChangedCommand ?? (_OnPermissionChangedCommand = new Command((p) => OnPermissionChangedCommandExecute(p), (p) => OnPermissionChangedCommandCanExecute(p)));
            }
        }
        protected void OnPermissionChangedCommandExecute(object prm)
        {
            ICommand cmd = PermissionChangedCommand;
            if(cmd != null) {
                if(cmd.CanExecute(prm)) {
                    cmd.Execute(prm);
                }
            }
        }
        protected bool OnPermissionChangedCommandCanExecute(object p)
        {
            return (PermissionChangedCommand != null); 
        }
        #endregion
        /*
        protected override void OnParentSet()
        {
            base.OnParentSet();
            if (Parent == null) {
                NavigationBackCommand = null;
                TableMenuItems = null;
                TableMenuItemsCommand = null;
                RowMenuItems = null;
                RowMenuItemsCommand = null;
                ContainerMenuItems = null;
                ContainerMenuItemsCommand = null;
                SelectedRowCommand = null;
                HiddenFilters = null;
                SformAfterAddItem = null;
                SformAfterUpdItem = null;
                SformAfterDelItem = null;
                SubmitCommand = null;
                CancelCommand = null;
                FormControlModel = null;
                SformAfterAddItemCommand = null;
                SformAfterUpdItemCommand = null;
                SformAfterDelItemCommand = null;
                HiddenFiltersDetail = null;
                RowMenuItemsDetail = null;
                TableMenuItemsDetail = null;
                PermissionChangedCommand = null;
            }
        }
        */

        protected void SetBinding(BindableObject element, BindingMode mode, string propertyName, string sourcePropertyName) {
            var fieldInfo = element.GetType().GetField(propertyName + "Property", BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
            if(fieldInfo!= null)
            {
                BindableProperty dp = fieldInfo.GetValue(null) as BindableProperty;
                if(dp != null)
                {
                    element.SetBinding(dp, new Binding(path: sourcePropertyName, mode: mode, source: this));
                }
            }
        }
        protected void ClearBinding(BindableObject element, string propertyName) {
            var fieldInfo = element.GetType().GetField(propertyName + "Property", BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
            if (fieldInfo != null)
            {
                BindableProperty dp = fieldInfo.GetValue(null) as BindableProperty;
                if (dp != null)
                {
                    element.RemoveBinding(dp);
                }
            }
        }
        public void OnViewsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e) {
                if (e.Action == NotifyCollectionChangedAction.Remove)
                {
                    if (e.OldItems != null) {
                        foreach (View element in e.OldItems)
                        {
                            ClearBinding(element, "Caption");
                            ClearBinding(element, "FilterHeight");
                            ClearBinding(element, "ShowFilter");
                            ClearBinding(element, "ShowAddFilterBtn");
                            ClearBinding(element, "GridHeight");
                            ClearBinding(element, "ShowBackBtn");
                            ClearBinding(element, "NavigationBackCommand");
                            ClearBinding(element, "TableMenuItems");
                            ClearBinding(element, "TableMenuItemsCommand");
                            ClearBinding(element, "RowMenuItems");
                            ClearBinding(element, "RowMenuItemsCommand");
                            ClearBinding(element, "ContainerMenuItems");
                            ClearBinding(element, "ContainerMenuItemsCommand");
                            ClearBinding(element, "SelectedRowCommand");
                            ClearBinding(element, "HiddenFilters");
                            ClearBinding(element, "SformAfterAddItem");
                            ClearBinding(element, "SformAfterUpdItem");
                            ClearBinding(element, "SformAfterDelItem");
                            ClearBinding(element, "ShowSubmit");
                            ClearBinding(element, "FormControlModel");
                            ClearBinding(element, "EformMode");
                            ClearBinding(element, "SubmitCommand");
                            ClearBinding(element, "CancelCommand");
                            ClearBinding(element, "CanAdd");
                            ClearBinding(element, "CanUpdate");
                            ClearBinding(element, "CanDelete");
                            ClearBinding(element, "SformAfterAddItemCommand");
                            ClearBinding(element, "SformAfterUpdItemCommand");
                            ClearBinding(element, "SformAfterDelItemCommand");
                            ClearBinding(element, "IsParentLoaded");

                            ClearBinding(element, "FilterHeightDetail");
                            ClearBinding(element, "ShowFilterDetail");
                            ClearBinding(element, "ShowAddFilterBtnDetail");
                            ClearBinding(element, "GridHeightDetail");
                            ClearBinding(element, "HiddenFiltersDetail");
                            ClearBinding(element, "TableMenuItemsDetail");
                            ClearBinding(element, "RowMenuItemsDetail");
                            ClearBinding(element, "CanAddDetail");
                            ClearBinding(element, "CanUpdateDetail");
                            ClearBinding(element, "CanDeleteDetail");

                            ClearBinding(element, "IsPermissionEditable");
                            ClearBinding(element, "PermissionVector");
                            ClearBinding(element, "PermissionChangedCommand");

                            if (this.Content == element) this.Content = null;
                        }
                    }
                }
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    if(e.NewItems != null) {
                        foreach (View element in e.NewItems)
                        {
                            this.Content = element;
                            SetBinding(element,  BindingMode.OneWay, "Caption",                     "Caption");
                            SetBinding(element,  BindingMode.OneWay, "FilterHeight",                "FilterHeight");
                            SetBinding(element,  BindingMode.OneWay, "ShowFilter",                  "ShowFilter");
                            SetBinding(element,  BindingMode.OneWay, "ShowAddFilterBtn",            "ShowAddFilterBtn");
                            SetBinding(element,  BindingMode.OneWay, "GridHeight",                  "GridHeight");
                            SetBinding(element,  BindingMode.OneWay, "ShowBackBtn",                 "ShowBackBtn");
                            SetBinding(element,  BindingMode.OneWay, "NavigationBackCommand",       "OnNavigationBackCommand");
                            SetBinding(element,  BindingMode.OneWay, "TableMenuItems",              "TableMenuItems");
                            SetBinding(element,  BindingMode.OneWay, "TableMenuItemsCommand",       "OnTableMenuItemsCommand");
                            SetBinding(element,  BindingMode.OneWay, "RowMenuItems",                "RowMenuItems");
                            SetBinding(element,  BindingMode.OneWay, "RowMenuItemsCommand",         "OnRowMenuItemsCommand");
                            SetBinding(element,  BindingMode.OneWay, "ContainerMenuItems",          "ContainerMenuItems");
                            SetBinding(element,  BindingMode.OneWay, "ContainerMenuItemsCommand",   "OnContainerMenuItemsCommand");
                            SetBinding(element,  BindingMode.OneWay, "SelectedRowCommand",          "OnSelectedRowCommand");
                            SetBinding(element,  BindingMode.OneWay, "HiddenFilters",               "HiddenFilters");
                            SetBinding(element,  BindingMode.OneWay, "SformAfterAddItem",           "SformAfterAddItem");
                            SetBinding(element,  BindingMode.OneWay, "SformAfterUpdItem",           "SformAfterUpdItem");
                            SetBinding(element,  BindingMode.OneWay, "SformAfterDelItem",           "SformAfterDelItem");
                            SetBinding(element,  BindingMode.OneWay, "ShowSubmit",                  "ShowSubmit");
                            SetBinding(element,  BindingMode.OneWay, "FormControlModel",            "FormControlModel");
                            SetBinding(element,  BindingMode.OneWay, "EformMode",                   "EformMode");
                            SetBinding(element,  BindingMode.OneWay, "SubmitCommand",               "OnSubmitCommand");
                            SetBinding(element,  BindingMode.OneWay, "CancelCommand",               "OnCancelCommand");
                            SetBinding(element,  BindingMode.OneWay, "CanAdd",                      "CanAdd");
                            SetBinding(element,  BindingMode.OneWay, "CanUpdate",                      "CanUpdate");
                            SetBinding(element,  BindingMode.OneWay, "CanDelete",                      "CanDelete");
                            SetBinding(element,  BindingMode.OneWay, "SformAfterAddItemCommand",    "OnSformAfterAddItemCommand");
                            SetBinding(element,  BindingMode.OneWay, "SformAfterUpdItemCommand",    "OnSformAfterUpdItemCommand");
                            SetBinding(element,  BindingMode.OneWay, "SformAfterDelItemCommand",    "OnSformAfterDelItemCommand");
                            SetBinding(element,  BindingMode.OneWay, "IsParentLoaded",              "IsParentLoaded");

                            SetBinding(element, BindingMode.OneWay, "FilterHeightDetail"               , "FilterHeightDetail"    );
                            SetBinding(element, BindingMode.OneWay, "ShowFilterDetail"                 , "ShowFilterDetail"      );
                            SetBinding(element, BindingMode.OneWay, "ShowAddFilterBtnDetail"           , "ShowAddFilterBtnDetail");
                            SetBinding(element, BindingMode.OneWay, "GridHeightDetail"                 , "GridHeightDetail"      );
                            SetBinding(element, BindingMode.OneWay, "HiddenFiltersDetail"              , "HiddenFiltersDetail"   );
                            SetBinding(element, BindingMode.OneWay, "TableMenuItemsDetail"             , "TableMenuItemsDetail"  );
                            SetBinding(element, BindingMode.OneWay, "RowMenuItemsDetail"               , "RowMenuItemsDetail"    );
                            SetBinding(element, BindingMode.OneWay, "CanAddDetail"                     , "CanAddDetail"          );
                            SetBinding(element, BindingMode.OneWay, "CanUpdateDetail"                     , "CanUpdateDetail"          );
                            SetBinding(element, BindingMode.OneWay, "CanDeleteDetail"                     , "CanDeleteDetail"          );

                            SetBinding(element, BindingMode.OneWay, "IsPermissionEditable"             , "IsPermissionEditable"   );
                            SetBinding(element, BindingMode.OneWay, "PermissionVector"                 , "PermissionVector"       );
                            SetBinding(element, BindingMode.OneWay, "PermissionChangedCommand"         ,"OnPermissionChangedCommand");
                        }
                    }
                }
        }
        public void OnActiveViewsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (ProxyRegion == null) return;
            var c = ProxyRegion.ActiveViews.FirstOrDefault();
            if (c != null) Content = c as View;
        }

        public IRegion ProxyRegion = null;


        public virtual void OnDestroyed()
        {
            if(ProxyRegion == null) return;
            RemoveBinding(IsDestroyedProperty);
            IsDestroyed = true;
            IRegion proxyRegion = ProxyRegion;
            ProxyRegion = null;
            if (proxyRegion != null) {
                proxyRegion.Views.CollectionChanged -= OnViewsCollectionChanged;
                proxyRegion.ActiveViews.CollectionChanged -= OnActiveViewsCollectionChanged;
            }

            RemoveBinding(CaptionProperty);
            RemoveBinding(FilterHeightProperty);
            RemoveBinding(ShowFilterProperty);
            RemoveBinding(ShowAddFilterBtnProperty);
            RemoveBinding(GridHeightProperty);
            RemoveBinding(ShowBackBtnProperty);
            RemoveBinding(NavigationBackCommandProperty);
            RemoveBinding(TableMenuItemsProperty);
            RemoveBinding(TableMenuItemsCommandProperty);
            RemoveBinding(RowMenuItemsProperty);
            RemoveBinding(RowMenuItemsCommandProperty);
            RemoveBinding(ContainerMenuItemsProperty);
            RemoveBinding(ContainerMenuItemsCommandProperty);
            RemoveBinding(SelectedRowCommandProperty);
            RemoveBinding(HiddenFiltersProperty);
            RemoveBinding(SformAfterAddItemProperty);
            RemoveBinding(SformAfterUpdItemProperty);
            RemoveBinding(SformAfterDelItemProperty);
            RemoveBinding(ShowSubmitProperty);
            RemoveBinding(FormControlModelProperty);
            RemoveBinding(EformModeProperty);
            RemoveBinding(SubmitCommandProperty);
            RemoveBinding(CancelCommandProperty);
            RemoveBinding(CanAddProperty);
            RemoveBinding(CanUpdateProperty);
            RemoveBinding(CanDeleteProperty);
            RemoveBinding(SformAfterAddItemCommandProperty);
            RemoveBinding(SformAfterUpdItemCommandProperty);
            RemoveBinding(SformAfterDelItemCommandProperty);
            RemoveBinding(IsParentLoadedProperty);
            RemoveBinding(FilterHeightDetailProperty);
            RemoveBinding(ShowFilterDetailProperty);
            RemoveBinding(ShowAddFilterBtnDetailProperty);
            RemoveBinding(GridHeightDetailProperty);
            RemoveBinding(HiddenFiltersDetailProperty);
            RemoveBinding(TableMenuItemsDetailProperty);
            RemoveBinding(RowMenuItemsDetailProperty);
            RemoveBinding(CanAddDetailProperty);
            RemoveBinding(CanUpdateDetailProperty);
            RemoveBinding(CanDeleteDetailProperty);
            RemoveBinding(IsPermissionEditableProperty);
            RemoveBinding(PermissionVectorProperty);
            RemoveBinding(PermissionChangedCommandProperty);

            NavigationBackCommand = null;
            TableMenuItemsCommand = null;
            RowMenuItemsCommand = null;
            ContainerMenuItemsCommand = null;
            SelectedRowCommand = null;
            SubmitCommand = null;
            CancelCommand = null;
            SformAfterAddItemCommand = null;
            SformAfterUpdItemCommand = null;
            SformAfterDelItemCommand = null;
            PermissionChangedCommand = null;
            TableMenuItems = null;
            RowMenuItems = null;
            ContainerMenuItems = null;
            TableMenuItemsDetail = null;
            RowMenuItemsDetail = null;

            if (proxyRegion != null) {
                proxyRegion.RemoveAll();
                proxyRegion.RegionManager.Regions.Remove(proxyRegion.Name);
                proxyRegion.Context = null;
                Content = null;
            }
        }
        private static void IsDestroyedChanged(BindableObject d, object oldValue, object newValue)
        {
            ProxyUserControl inst = d as ProxyUserControl;
            if (inst != null)
            {
                inst.OnDestroyed();
            }
        }
        public static readonly BindableProperty IsDestroyedProperty =
                BindableProperty.Create(
                "IsDestroyed", typeof(bool),
                typeof(ProxyUserControl),
                false, propertyChanged: IsDestroyedChanged);
        public bool IsDestroyed
        {
            get
            {
                return (bool)GetValue(IsDestroyedProperty);
            }
            set
            {
                SetValue(IsDestroyedProperty, value);
            }
        }
        #region IDestructible
        public void Destroy()
        {
            if(IsDestroyed) return;
            OnDestroyed();
        }
        #endregion

    }
}

