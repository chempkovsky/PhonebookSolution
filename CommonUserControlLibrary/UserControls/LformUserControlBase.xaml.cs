using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Windows.Input;
using Prism.Navigation;
using CommonInterfacesClassLibrary.Interfaces;
using CommonCustomControlLibrary.Classes;


namespace CommonUserControlLibrary.UserControls {
    /// <summary>
    /// Interaction logic for LformUserControlBase.xaml
    /// </summary>
    public class LformUserControlBase: UserControlWithContainerMenu, INotifiedByParentInterface, IDestructible
    {
        //public LformUserControlBase()
        //{
        //    InitializeComponent();
        //}

        #region OnBindingContextFeedbackRef
        protected override void OnBindingContextFeedbackRef(object v)
        {
            BindingContextFeedback bcf = v as BindingContextFeedback;
            if(bcf == null) return;
            if(string.IsNullOrEmpty(bcf.BcfName)) return;
		    if(bcf.BcfName == "SelectedRow") {
                ICommand cmd = SelectedRowCommand; 
                if(cmd != null) {
                    if(cmd.CanExecute(bcf.BcfData))
                        cmd.Execute(bcf.BcfData);
                }
            } else if(bcf.BcfName == "RowMenuItemsCommand") {
                ICommand cmd = RowMenuItemsCommand; 
                if(cmd != null) {
                    if(cmd.CanExecute(bcf.BcfData))
                        cmd.Execute(bcf.BcfData);
                }  
            } else if(bcf.BcfName == "TableMenuItemsCommand") {
                ICommand cmd = TableMenuItemsCommand; 
                if(cmd != null) {
                    if(cmd.CanExecute(bcf.BcfData))
                        cmd.Execute(bcf.BcfData);
                }
            } else if(bcf.BcfName == "SformAfterAddItemCommand") {
                ICommand cmd = SformAfterAddItemCommand; 
                if(cmd != null) {
                    if(cmd.CanExecute(bcf.BcfData))
                        cmd.Execute(bcf.BcfData);
                }
            } else if(bcf.BcfName == "SformAfterUpdItemCommand") {
                ICommand cmd = SformAfterUpdItemCommand; 
                if(cmd != null) {
                    if(cmd.CanExecute(bcf.BcfData))
                        cmd.Execute(bcf.BcfData);
                }
            } else if(bcf.BcfName == "SformAfterDelItemCommand") {
                ICommand cmd = SformAfterDelItemCommand; 
                if(cmd != null) {
                    if(cmd.CanExecute(bcf.BcfData))
                        cmd.Execute(bcf.BcfData);
                }
            }
        }
        #endregion

        #region SformAfterAddItemCommand
        public static readonly BindableProperty SformAfterAddItemCommandProperty =
                BindableProperty.Create(
                "SformAfterAddItemCommand", typeof(ICommand),
                typeof(LformUserControlBase),
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
        #region SformAfterUpdItemCommand
        public static readonly BindableProperty SformAfterUpdItemCommandProperty =
                BindableProperty.Create(
                "SformAfterUpdItemCommand", typeof(ICommand),
                typeof(LformUserControlBase),
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
        #region SformAfterDelItemCommand
        public static readonly BindableProperty SformAfterDelItemCommandProperty =
                BindableProperty.Create(
                "SformAfterDelItemCommand", typeof(ICommand),
                typeof(LformUserControlBase),
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
        #region TableMenuItemsCommand
        public static readonly BindableProperty TableMenuItemsCommandProperty =
                BindableProperty.Create(
                "TableMenuItemsCommand", typeof(ICommand),
                typeof(LformUserControlBase),
                null);
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
        #region RowMenuItemsCommand
        public static readonly BindableProperty RowMenuItemsCommandProperty =
                BindableProperty.Create(
                "RowMenuItemsCommand", typeof(ICommand),
                typeof(LformUserControlBase),
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
        #region SelectedRowCommand
        public static readonly BindableProperty SelectedRowCommandProperty =
                BindableProperty.Create(
                "SelectedRowCommand", typeof(ICommand),
                typeof(LformUserControlBase),
                null);
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
        #region Caption
        public static readonly BindableProperty CaptionProperty =
                BindableProperty.Create(
                "Caption", typeof(string),
                typeof(LformUserControlBase),
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
        #region ShowFilter
        public static readonly BindableProperty ShowFilterProperty =
                BindableProperty.Create(
                "ShowFilter", typeof(bool),
                typeof(LformUserControlBase),
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
                typeof(LformUserControlBase),
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
        #region ShowBackBtn
        public static readonly BindableProperty ShowBackBtnProperty =
                BindableProperty.Create(
                "ShowBackBtn", typeof(bool),
                typeof(LformUserControlBase),
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
        #region TableMenuItems
        private static void TableMenuItemsChanged(BindableObject d, object oldValue, object newValue)
        {
            LformUserControlBase inst = d as LformUserControlBase;
            if (inst != null)
            {
                ILformViewModelInterface bc = inst.BindingContext as ILformViewModelInterface;
                if(bc != null)
                    bc.TableMenuItemsPropertyChanged(inst, oldValue, newValue);
           }
        }
        public static readonly BindableProperty TableMenuItemsProperty =
                BindableProperty.Create(
                "TableMenuItems", typeof(IEnumerable<IWebServiceFilterMenuInterface>),
                typeof(LformUserControlBase),
                null, propertyChanged: TableMenuItemsChanged);
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
        #region RowMenuItems
        private static void RowMenuItemsChanged(BindableObject d, object oldValue, object newValue)
        {
            LformUserControlBase inst = d as LformUserControlBase;
            if (inst != null)
            {
                ILformViewModelInterface bc = inst.BindingContext as ILformViewModelInterface;
                if(bc != null)
                    bc.RowMenuItemsPropertyChanged(inst, oldValue, newValue);
            }
        }
        public static readonly BindableProperty RowMenuItemsProperty =
                BindableProperty.Create(
                "RowMenuItems", typeof(IEnumerable<IWebServiceFilterMenuInterface>),
                typeof(LformUserControlBase),
                null, propertyChanged: RowMenuItemsChanged);
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
        #region HiddenFilters
        private static void HiddenFiltersChanged(BindableObject d, object oldValue, object newValue)
        {
            LformUserControlBase inst = d as LformUserControlBase;
            if (inst != null)
            {
                ILformViewModelInterface bc = inst.BindingContext as ILformViewModelInterface;
                if(bc != null)
                    bc.HiddenFiltersPropertyChanged(inst, oldValue, newValue);
            }
        }
        public static readonly BindableProperty HiddenFiltersProperty =
                BindableProperty.Create(
                "HiddenFilters", typeof(IEnumerable<IWebServiceFilterRsltInterface>),
                typeof(LformUserControlBase),
                null, propertyChanged: HiddenFiltersChanged);
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
        #region OnBindingContextChanged
        #endregion
        #region NavigationBackCommand
        private static void NavigationBackCommandChanged(BindableObject bindable, object oldValue, object newValue)
        {
            LformUserControlBase d = bindable as LformUserControlBase;
            if (d != null)
            {
                if (d.OnNavigationBackCommand != null)
                {
                    (d.OnNavigationBackCommand as Command).ChangeCanExecute();
                }
            }
        }
        public static readonly BindableProperty NavigationBackCommandProperty =
            BindableProperty.Create(nameof(NavigationBackCommand), typeof(ICommand), 
            typeof(LformUserControlBase), 
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
                return _OnNavigationBackCommand ?? (_OnNavigationBackCommand = new Command(() => OnNavigationBackCommandExecute(), () => OnNavigationBackCommandCanExecute()));
            }
        }
        protected void OnNavigationBackCommandExecute()
        {
            ICommand cmd = NavigationBackCommand;
            if(cmd != null) {
                if(cmd.CanExecute(this)) {
                    cmd.Execute(this);
                }
            }
        }
        protected bool OnNavigationBackCommandCanExecute()
        {
            return (NavigationBackCommand != null); 
        }
        #endregion

        #region CanAdd
        private static void CanAddChanged(BindableObject d, object oldValue, object newValue)
        {
            LformUserControlBase inst = d as LformUserControlBase;
            if (inst != null)
            {
                ILformViewModelInterface bc = inst.BindingContext as ILformViewModelInterface;
                if(bc != null)
                    bc.CanAddPropertyChanged(inst, oldValue, newValue);
            }
        }
        public static readonly BindableProperty CanAddProperty =
                BindableProperty.Create(
                "CanAdd", typeof(bool),
                typeof(LformUserControlBase),
                false, propertyChanged: CanAddChanged);
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
        private static void CanUpdateChanged(BindableObject d, object oldValue, object newValue)
        {
            LformUserControlBase inst = d as LformUserControlBase;
            if (inst != null)
            {
                ILformViewModelInterface bc = inst.BindingContext as ILformViewModelInterface;
                if(bc != null)
                    bc.CanUpdatePropertyChanged(inst, oldValue, newValue);
            }
        }
        public static readonly BindableProperty CanUpdateProperty =
                BindableProperty.Create(
                "CanUpdate", typeof(bool),
                typeof(LformUserControlBase),
                false, propertyChanged: CanUpdateChanged);
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
        private static void CanDeleteChanged(BindableObject d, object oldValue, object newValue)
        {
            LformUserControlBase inst = d as LformUserControlBase;
            if (inst != null)
            {
                ILformViewModelInterface bc = inst.BindingContext as ILformViewModelInterface;
                if(bc != null)
                    bc.CanDeletePropertyChanged(inst, oldValue, newValue);
            }
        }
        public static readonly BindableProperty CanDeleteProperty =
                BindableProperty.Create(
                "CanDelete", typeof(bool),
                typeof(LformUserControlBase),
                false, propertyChanged: CanDeleteChanged);
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
        #region IsParentLoaded
        private static async void IsParentLoadedChanged(BindableObject bindable, object oldValue, object newValue)
        {
            LformUserControlBase d = bindable as LformUserControlBase;
            if (d != null)
            {
               IBindingContextChanged bcl = d.BindingContext as IBindingContextChanged;
                if (bcl != null)
                {
                    await bcl.OnLoaded(bindable, newValue);
                }
            }
        }
        public static readonly BindableProperty IsParentLoadedProperty =
                BindableProperty.Create(
                "IsParentLoaded", typeof(bool),
                typeof(LformUserControlBase),
                false, propertyChanged: IsParentLoadedChanged);
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

        #region OnDestroyed
        public override void OnDestroyed()
        {
            base.OnDestroyed();
            IBindingContextChanged bc = BindingContext as IBindingContextChanged;
            if(bc != null) bc.OnDestroy();
            RemoveBinding(SformAfterAddItemCommandProperty);
            RemoveBinding(SformAfterUpdItemCommandProperty);
            RemoveBinding(SformAfterDelItemCommandProperty);
            RemoveBinding(TableMenuItemsCommandProperty);
            RemoveBinding(RowMenuItemsCommandProperty);
            RemoveBinding(SelectedRowCommandProperty);
            RemoveBinding(CaptionProperty);
            RemoveBinding(ShowFilterProperty);
            RemoveBinding(ShowAddFilterBtnProperty);
            RemoveBinding(ShowBackBtnProperty);
            RemoveBinding(TableMenuItemsProperty);
            RemoveBinding(RowMenuItemsProperty);
            RemoveBinding(HiddenFiltersProperty);
            RemoveBinding(NavigationBackCommandProperty);
            RemoveBinding(CanAddProperty);
            RemoveBinding(CanUpdateProperty);
            RemoveBinding(CanDeleteProperty);
            RemoveBinding(IsParentLoadedProperty);
            SformAfterAddItemCommand = null;
            SformAfterUpdItemCommand = null;
            SformAfterDelItemCommand = null;
            TableMenuItemsCommand = null;
            RowMenuItemsCommand = null;
            SelectedRowCommand = null;
            NavigationBackCommand = null;
            RowMenuItems = null;
            TableMenuItems=null;
            HiddenFilters=null;
        }
        #endregion

        #region IDestructible
        public void Destroy()
        {
            if(IsDestroyed) return;
            OnDestroyed();
        }
        #endregion
    }
}

