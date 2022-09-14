using System.Collections.Generic;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using System.Threading.Tasks;
using CommonInterfacesClassLibrary.Interfaces;
using CommonUserControlLibrary.ViewModels;
using CommonUserControlLibrary.Classes;
using CommonCustomControlLibrary.Helpers;


namespace CommonUserControlLibrary.UserControls {
    /// <summary>
    /// Interaction logic for WebServiceFilterUserControl.xaml
    /// </summary>
    public partial class WebServiceFilterUserControl: ContentView
    {

        public WebServiceFilterUserControl()
        {
            InitializeComponent();
        }
        #region Caption
        public static readonly BindableProperty CaptionProperty =
                BindableProperty.Create(
                "Caption", typeof(string),
                typeof(WebServiceFilterUserControl),
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
        #region ShowBackBtn
        public static readonly BindableProperty ShowBackBtnProperty =
                BindableProperty.Create(
                "ShowBackBtn", typeof(bool),
                typeof(WebServiceFilterUserControl),
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
        #region ShowAddFilterBtn
        public static readonly BindableProperty ShowAddFilterBtnProperty =
                BindableProperty.Create(
                "ShowAddFilterBtn", typeof(bool),
                typeof(WebServiceFilterUserControl),
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
        #region OnNavigationBackCommand
        public static readonly BindableProperty NavigationBackCommandProperty =
            BindableProperty.Create(nameof(NavigationBackCommand), typeof(ICommand), typeof(WebServiceFilterUserControl), null);
        public ICommand NavigationBackCommand
        {
            get { return (ICommand)GetValue(NavigationBackCommandProperty); }
            set { SetValue(NavigationBackCommandProperty, value); }
        }

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
            if(IsDestroyed) return;
            ICommand cmd = NavigationBackCommand;
            if(cmd != null) {
                if(cmd.CanExecute(this)) cmd.Execute(this);
            }
        }
        protected bool OnNavigationBackCommandCanExecute()
        {
            return true;
        }
        #endregion
        #region OnAddWebServiceFilterItemCommand
        protected ICommand _OnAddWebServiceFilterItemCommand = null;
        public ICommand OnAddWebServiceFilterItemCommand
        {
            get
            {
                return _OnAddWebServiceFilterItemCommand ?? (_OnAddWebServiceFilterItemCommand = new Command(() => OnAddWebServiceFilterItemCommandExecute(), () => OnAddWebServiceFilterItemCommandCanExecute()));
            }
        }
        protected void OnAddWebServiceFilterItemCommandExecute()
        {
            if(IsDestroyed) return;
            Filters.Add(new WebServiceFilterRsltViewModel());
            InternalContentChanged();
        }
        protected bool OnAddWebServiceFilterItemCommandCanExecute()
        {
            return true;
        }
        #endregion
        #region HiddenFilters
        public static readonly BindableProperty HiddenFiltersProperty =
                BindableProperty.Create(
                "HiddenFilters", typeof(IEnumerable<IWebServiceFilterRsltInterface>),
                typeof(WebServiceFilterUserControl),
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
        #region Filters
        public void ClearFilters() {
                foreach(IWebServiceFilterRsltInterface itm in Filters) itm.IsDestroyed = true;
                Filters.Clear();
        }
        ObservableCollection<IWebServiceFilterRsltInterface> _Filters = new ObservableCollection<IWebServiceFilterRsltInterface>()
        {
            new WebServiceFilterRsltViewModel()
        };
        public ObservableCollection<IWebServiceFilterRsltInterface> Filters
        {
            get
            {
                return _Filters;
            }
        }
        #endregion
        
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
        #region FilterOperators
        public static readonly BindableProperty FilterOperatorsProperty =
                BindableProperty.Create(
                "FilterOperators", typeof(IEnumerable<IWebServiceFilterOperatorInterface>),
                typeof(WebServiceFilterUserControl),
                new ObservableCollection<IWebServiceFilterOperatorInterface>()
                {
                    new WebServiceFilterOperatorViewModel(){oName= "eq", oCaption= "=="},
                    new WebServiceFilterOperatorViewModel(){oName= "gt", oCaption= ">="},
                    new WebServiceFilterOperatorViewModel(){oName= "lt", oCaption= "=<"},
                    new WebServiceFilterOperatorViewModel(){oName= "ne", oCaption= "<>"},
                    new WebServiceFilterOperatorViewModel(){oName= "lk", oCaption= "Like"},
                });
        public IEnumerable<IWebServiceFilterOperatorInterface> FilterOperators
        {
            get
            {
                return (IEnumerable<IWebServiceFilterOperatorInterface>)GetValue(FilterOperatorsProperty);
            }
            set
            {
                SetValue(FilterOperatorsProperty, value);
            }
        }
        #endregion
        #region FilterDefinitions
        private static void FilterDefinitionsChanged(BindableObject d, object oldValue, object newValue)
        {
            WebServiceFilterUserControl inst = d as WebServiceFilterUserControl;
            if (inst != null)
            {
                if(inst.IsDestroyed) return;
                inst.ClearFilters();
                inst.Filters.Add(new WebServiceFilterRsltViewModel());
                inst.InternalContentChanged();
            }
        }
        public static readonly BindableProperty FilterDefinitionsProperty =
                BindableProperty.Create(
                "FilterDefinitions", typeof(IEnumerable<IWebServiceFilterDefInterface>),
                typeof(WebServiceFilterUserControl),
                null, propertyChanged: FilterDefinitionsChanged);
        public IEnumerable<IWebServiceFilterDefInterface> FilterDefinitions
        {
            get
            {
                return (IEnumerable<IWebServiceFilterDefInterface>)GetValue(FilterDefinitionsProperty);
            }
            set
            {
                SetValue(FilterDefinitionsProperty, value);
            }
        }
        #endregion
        #region CurrentContainerMenuItems
        protected ObservableCollection<IWebServiceFilterMenuInterface> _CurrentContainerMenuItems = new ObservableCollection<IWebServiceFilterMenuInterface>();
        public ObservableCollection<IWebServiceFilterMenuInterface> CurrentContainerMenuItems { get {return _CurrentContainerMenuItems; } }
        public void CurrentContainerMenuItemsClear() {
            if(_CurrentContainerMenuItems != null) {
                foreach(IWebServiceFilterMenuInterface itm in _CurrentContainerMenuItems) {
                    itm.IsDestroyed = true;
                }
                _CurrentContainerMenuItems.Clear();
            }
        }
        #endregion
        #region ContainerMenuItems
        private static void ContainerMenuItemsChanged(BindableObject d, object oldValue, object newValue)
        {
            WebServiceFilterUserControl inst = d as WebServiceFilterUserControl;
            if (inst != null)
            {
                inst.CurrentContainerMenuItemsClear();
                if(inst.IsDestroyed) return;
                IEnumerable<IWebServiceFilterMenuInterface> cmitms =  newValue as IEnumerable<IWebServiceFilterMenuInterface>;
                if(cmitms != null) {
                    foreach(IWebServiceFilterMenuInterface itm in cmitms) {
                        inst.CurrentContainerMenuItems.Add(
                            new WebServiceFilterMenuViewModel() {
                                Id = itm.Id,
                                Caption = itm.Caption,
                                IconName = itm.IconName,
                                IconColor = itm.IconColor,
                                Enabled = itm.Enabled,
                                Data = itm.Data,
                                FeedbackData = itm.FeedbackData,
                                Command = itm.Command,
                                IsDestroyed = itm.IsDestroyed
                            }
                        );
                    }
                }
            }
        }
        public static readonly BindableProperty ContainerMenuItemsProperty =
                BindableProperty.Create(
                "ContainerMenuItems", typeof(IEnumerable<IWebServiceFilterMenuInterface>),
                typeof(WebServiceFilterUserControl),
                propertyChanged: ContainerMenuItemsChanged);
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
        #region FilterCommand
        public static readonly BindableProperty FilterCommandProperty =
            BindableProperty.Create(nameof(FilterCommand), typeof(ICommand), typeof(WebServiceFilterUserControl), 
            null); 
        public ICommand FilterCommand
        {
            get { return (ICommand)GetValue(FilterCommandProperty); }
            set { SetValue(FilterCommandProperty, value); }
        }
        #endregion
        #region OnFilterCommand
        protected IList<IWebServiceFilterRsltInterface> InternalDefineFilter()
        {
            IList<IWebServiceFilterRsltInterface> rslt = new List<IWebServiceFilterRsltInterface>();
            if (Filters != null)
            {
                foreach (IWebServiceFilterRsltInterface flt in Filters)
                {
                    if (string.IsNullOrEmpty(flt.fltrError))
                    {
                        if ((flt.fltrValue != null) && (!string.IsNullOrEmpty(flt.fltrDataType)) && (!string.IsNullOrEmpty(flt.fltrOperator)))
                        {
                            object v = ConvertHelper.TryToConvert(flt.fltrDataType, flt.fltrValue);
                            if (v != null)
                            {
                                rslt.Add(new WebServiceFilterRslt() { fltrName = flt.fltrName, fltrDataType = flt.fltrDataType, fltrOperator = flt.fltrOperator, fltrValue = v });
                            }
                        }
                    }
                }
            }
            if (HiddenFilters != null)
            {
                foreach (IWebServiceFilterRsltInterface flt in HiddenFilters)
                {
                    if (string.IsNullOrEmpty(flt.fltrError))
                    {
                        if ((flt.fltrValue != null) && (!string.IsNullOrEmpty(flt.fltrDataType)) && (!string.IsNullOrEmpty(flt.fltrOperator)))
                        {
                            object v = ConvertHelper.TryToConvert(flt.fltrDataType, flt.fltrValue);
                            if (v != null)
                            {
                                rslt.Add(new WebServiceFilterRslt() { fltrName = flt.fltrName, fltrDataType = flt.fltrDataType, fltrOperator = flt.fltrOperator, fltrValue = v });
                            }
                        }
                    }
                }
            }
            return rslt;
        }
        protected ICommand _OnFilterCommand = null;
        public ICommand OnFilterCommand
        {
            get
            {
                return _OnFilterCommand ?? (_OnFilterCommand = new Command(() => OnFilterCommandExecute(), () => OnFilterCommandCanExecute()));
            }
        }
        protected void OnFilterCommandExecute()
        {
            if(IsDestroyed) return;
            ICommand cmd = FilterCommand;
            if (cmd != null)
            {
                IList<IWebServiceFilterRsltInterface> rslt = InternalDefineFilter();
                if(cmd.CanExecute(rslt)) cmd.Execute(rslt);
            }
        }
        protected bool OnFilterCommandCanExecute()
        {
            return true;
        }
        #endregion
        #region OnRemoveWebServiceFilterItemCommand
        protected ICommand _OnRemoveWebServiceFilterItemCommand = null;
        public ICommand OnRemoveWebServiceFilterItemCommand
        {
            get
            {
                return _OnRemoveWebServiceFilterItemCommand ?? (_OnRemoveWebServiceFilterItemCommand = new Command((prm) => OnRemoveWebServiceFilterItemCommandExecute(prm), (prm) => OnRemoveWebServiceFilterItemCommandCanExecute(prm)));
            }
        }
        protected void OnRemoveWebServiceFilterItemCommandExecute(object prm)
        {
            if(IsDestroyed) return;
            if (Filters.Count < 1)
            {
                Filters.Add(new WebServiceFilterRsltViewModel());
                InternalContentChanged();
                return;
            }
            if (Filters.Count < 2)
            {
                return;
            }
            IWebServiceFilterRsltInterface itm = prm as IWebServiceFilterRsltInterface;
            if (itm != null)
            {
                itm.IsDestroyed = true;
                Filters.Remove(itm);
                InternalContentChanged();
            }
        }
        protected bool OnRemoveWebServiceFilterItemCommandCanExecute(object prm)
        {
            return (prm as IWebServiceFilterRsltInterface) != null;
        }
        #endregion
        #region OnRemoveAllWebServiceFilterItemCommand
        protected ICommand _OnRemoveAllWebServiceFilterItemCommand = null;
        public ICommand OnRemoveAllWebServiceFilterItemCommand
        {
            get
            {
                return _OnRemoveAllWebServiceFilterItemCommand ?? (_OnRemoveAllWebServiceFilterItemCommand = new Command(() => OnRemoveAllWebServiceFilterItemCommandExecute(), () => OnRemoveAllWebServiceFilterItemCommandCanExecute()));
            }
        }
        private void OnRemoveAllWebServiceFilterItemCommandExecute()
        {
            if(IsDestroyed) return;
            ClearFilters();
            Filters.Add(new WebServiceFilterRsltViewModel());
            InternalContentChanged();
        }
        private bool OnRemoveAllWebServiceFilterItemCommandCanExecute() {
            return  true;
        }
        #endregion
        #region OnContainerMenuItemsCommand
        public static readonly BindableProperty ContainerMenuItemsCommandProperty =
            BindableProperty.Create(nameof(ContainerMenuItemsCommand), typeof(ICommand), typeof(WebServiceFilterUserControl), 
            null); 
        public ICommand ContainerMenuItemsCommand
        {
            get { return (ICommand)GetValue(ContainerMenuItemsCommandProperty); }
            set { SetValue(ContainerMenuItemsCommandProperty, value); }
        }

        protected ICommand _OnContainerMenuItemsCommand = null;
        public ICommand OnContainerMenuItemsCommand
        {
            get
            {
                return _OnContainerMenuItemsCommand ?? (_OnContainerMenuItemsCommand = new Command((p) => OnContainerMenuItemsCommandExecute(p), (p) => OnContainerMenuItemsCommandCanExecute(p)));
            }
        }
        protected void OnContainerMenuItemsCommandExecute(object p)
        {
            if(IsDestroyed) return;
            ICommand cmd = ContainerMenuItemsCommand;
            if(cmd != null) {
                if(cmd.CanExecute(p)) cmd.Execute(p);
            }
        }
        protected bool OnContainerMenuItemsCommandCanExecute(object p)
        {
            return true;
        }
        #endregion

        #region FilterHeight
        public static readonly BindableProperty FilterHeightProperty =
                BindableProperty.Create(
                "FilterHeight", typeof(double),
                typeof(WebServiceFilterUserControl),
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

        #region IsGridFlexProperty
        public static readonly BindableProperty IsGridFlexProperty =
                BindableProperty.Create(
                "IsGridFlex", typeof(bool),
                typeof(WebServiceFilterUserControl),
                true);
        public bool IsGridFlex
        {
            get
            {
                return (bool)GetValue(IsGridFlexProperty);
            }
            set
            {
                SetValue(IsGridFlexProperty, value);
            }
        }
        #endregion

        public virtual void OnDestroyed()
        {
            RemoveBinding(IsDestroyedProperty);
            IsDestroyed = true;
            RemoveBinding(IsGridFlexProperty);
            RemoveBinding(CaptionProperty);
            RemoveBinding(ShowBackBtnProperty);
            RemoveBinding(ShowAddFilterBtnProperty);
            RemoveBinding(NavigationBackCommandProperty);
            RemoveBinding(HiddenFiltersProperty);
            RemoveBinding(FilterOperatorsProperty);
            RemoveBinding(FilterDefinitionsProperty);
            RemoveBinding(ContainerMenuItemsProperty);
            RemoveBinding(FilterCommandProperty);
            RemoveBinding(ContainerMenuItemsCommandProperty);
            RemoveBinding(FilterHeightProperty);
            IsGridFlex = false;
            FilterHeight = -1d; // unsubscribe from event
            ClearFilters();
            NavigationBackCommand = null;
            ContainerMenuItems = null;
            FilterCommand = null;
            ContainerMenuItemsCommand = null;
            CurrentContainerMenuItemsClear();
        }
        private static void IsDestroyedChanged(BindableObject d, object oldValue, object newValue)
        {
            WebServiceFilterUserControl inst = d as WebServiceFilterUserControl;
            if (inst != null) 
            {
                inst.OnDestroyed();
            }
        }
        public static readonly BindableProperty IsDestroyedProperty =
                BindableProperty.Create(
                "IsDestroyed", typeof(bool),
                typeof(WebServiceFilterUserControl),
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

    }
}

