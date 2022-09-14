using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Windows.Input;
using Prism.Navigation;
using CommonInterfacesClassLibrary.Interfaces;
using CommonCustomControlLibrary.Classes;


namespace CommonUserControlLibrary.UserControls {
    /// <summary>
    /// Interaction logic for SformUserControlBase.xaml
    /// </summary>
    public class SformUserControlBase: UserControlWithContainerMenu, INotifiedByParentInterface, IDestructible
    {
        private static object RadioGroupNameCreator(BindableObject bindable)
        {
            return "rgn" + Guid.NewGuid().ToString("N");
        }
        public static readonly BindableProperty RadioGroupNameProperty =
                BindableProperty.Create(
                "RadioGroupName", typeof(string),
                typeof(SformUserControlBase),
                defaultValueCreator: RadioGroupNameCreator);
        public string RadioGroupName
        {
            get
            {
                return (string)GetValue(RadioGroupNameProperty);
            }
            set
            {
                SetValue(RadioGroupNameProperty, value);
            }
        }


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
            }
        }
        #endregion
        #region TableMenuItemsCommand
        public static readonly BindableProperty TableMenuItemsCommandProperty =
                BindableProperty.Create(
                "TableMenuItemsCommand", typeof(ICommand),
                typeof(SformUserControlBase),
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
                typeof(SformUserControlBase),
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
                typeof(SformUserControlBase),
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
                typeof(SformUserControlBase),
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
                typeof(SformUserControlBase),
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
                typeof(SformUserControlBase),
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
                typeof(SformUserControlBase),
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
            SformUserControlBase inst = d as SformUserControlBase;
            if (inst != null)
            {
                ISformViewModelInterface bc = inst.BindingContext as ISformViewModelInterface;
                if(bc != null)
                    bc.TableMenuItemsPropertyChanged(inst, oldValue, newValue);
           }
        }
        public static readonly BindableProperty TableMenuItemsProperty =
                BindableProperty.Create(
                "TableMenuItems", typeof(IEnumerable<IWebServiceFilterMenuInterface>),
                typeof(SformUserControlBase),
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
            SformUserControlBase inst = d as SformUserControlBase;
            if (inst != null)
            {
                ISformViewModelInterface bc = inst.BindingContext as ISformViewModelInterface;
                if(bc != null)
                    bc.RowMenuItemsPropertyChanged(inst, oldValue, newValue);
            }
        }
        public static readonly BindableProperty RowMenuItemsProperty =
                BindableProperty.Create(
                "RowMenuItems", typeof(IEnumerable<IWebServiceFilterMenuInterface>),
                typeof(SformUserControlBase),
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
        private static async void HiddenFiltersChanged(BindableObject d, object oldValue, object newValue)
        {
            SformUserControlBase inst = d as SformUserControlBase;
            if (inst != null)
            {
                ISformViewModelInterface bc = inst.BindingContext as ISformViewModelInterface;
                if(bc != null)
                    await bc.HiddenFiltersPropertyChanged(inst, oldValue, newValue);
            }
        }
        public static readonly BindableProperty HiddenFiltersProperty =
                BindableProperty.Create(
                "HiddenFilters", typeof(IEnumerable<IWebServiceFilterRsltInterface>),
                typeof(SformUserControlBase),
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
            SformUserControlBase d = bindable as SformUserControlBase;
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
            typeof(SformUserControlBase), 
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
        #region SformAfterAddItem
        private static void SformAfterAddItemChanged(BindableObject bindable, object oldValue, object newValue)
        {
            SformUserControlBase d = bindable as SformUserControlBase;
            if (d != null)
            {
                ISformViewModelInterface bc = d.BindingContext as ISformViewModelInterface;
                if (bc != null)
                {
                    bc.SformAfterAddItemCommand(d, newValue);
                }
            }
        }
        public static readonly BindableProperty SformAfterAddItemProperty =
                BindableProperty.Create(
                "SformAfterAddItem", typeof(object),
                typeof(SformUserControlBase),
                null, propertyChanged: SformAfterAddItemChanged);
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
        private static void SformAfterUpdItemChanged(BindableObject bindable, object oldValue, object newValue)
        {
            SformUserControlBase d = bindable as SformUserControlBase;
            if (d != null)
            {
                ISformViewModelInterface bc = d.BindingContext as ISformViewModelInterface;
                if (bc != null)
                {
                    bc.SformAfterUpdItemCommand(d, newValue);
                }
            }
        }
        public static readonly BindableProperty SformAfterUpdItemProperty =
                BindableProperty.Create(
                "SformAfterUpdItem", typeof(object),
                typeof(SformUserControlBase),
                null, propertyChanged: SformAfterUpdItemChanged);
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
        private static void SformAfterDelItemChanged(BindableObject bindable, object oldValue, object newValue)
        {
            SformUserControlBase d = bindable as SformUserControlBase;
            if (d != null)
            {
                ISformViewModelInterface bc = d.BindingContext as ISformViewModelInterface;
                if (bc != null)
                {
                    bc.SformAfterDelItemCommand(d, newValue);
                }
            }
        }
        public static readonly BindableProperty SformAfterDelItemProperty =
                BindableProperty.Create(
                "SformAfterDelItem", typeof(object),
                typeof(SformUserControlBase),
                null, propertyChanged: SformAfterDelItemChanged);
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
        #region IsParentLoaded
        private static async void IsParentLoadedChanged(BindableObject bindable, object oldValue, object newValue)
        {
            SformUserControlBase d = bindable as SformUserControlBase;
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
                typeof(SformUserControlBase),
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

        #region IDestructible OnDestroyed
        public override void OnDestroyed()
        {
            base.OnDestroyed();
            IBindingContextChanged bc = BindingContext as IBindingContextChanged;
            if(bc != null) bc.OnDestroy();
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
            RemoveBinding(SformAfterAddItemProperty);
            RemoveBinding(SformAfterUpdItemProperty);
            RemoveBinding(SformAfterDelItemProperty);
            RemoveBinding(IsParentLoadedProperty);
            RemoveBinding(RadioGroupNameProperty);
            RadioGroupName = null;
            TableMenuItemsCommand = null;
            RowMenuItemsCommand = null;
            SelectedRowCommand = null;
            NavigationBackCommand = null;
            TableMenuItems = null;
            RowMenuItems = null;
            SformAfterAddItem = null;
            SformAfterUpdItem = null;
            SformAfterDelItem = null;
            HiddenFilters = null; // maybe check if destroyed on method void HiddenFiltersChanged
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

