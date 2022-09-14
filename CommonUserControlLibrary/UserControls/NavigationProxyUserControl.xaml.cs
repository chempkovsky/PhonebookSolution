using System;
using Xamarin.Forms;
using System.Collections.Generic;

using CommonInterfacesClassLibrary.Interfaces;
using CommonInterfacesClassLibrary.Enums;

namespace CommonUserControlLibrary.UserControls {
    /// <summary>
    /// Interaction logic for NavigationProxyUserControl.xaml
    /// </summary>
    public partial class NavigationProxyUserControl: ContentView
    {
        public NavigationProxyUserControl()
        {
            InitializeComponent();
        }
        #region FilterHeight
        public static readonly BindableProperty FilterHeightProperty =
                BindableProperty.Create(
                "FilterHeight", typeof(double),
                typeof(NavigationProxyUserControl),
                double.MaxValue);
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
                typeof(NavigationProxyUserControl),
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
                typeof(NavigationProxyUserControl),
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
        #region ContainerMenuItems
        public static readonly BindableProperty ContainerMenuItemsProperty =
                BindableProperty.Create(
                "ContainerMenuItems", typeof(IEnumerable<IWebServiceFilterMenuInterface>),
                typeof(NavigationProxyUserControl),
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
        #region GridHeight
        public static readonly BindableProperty GridHeightProperty =
                BindableProperty.Create(
                "GridHeight", typeof(double),
                typeof(NavigationProxyUserControl),
                double.MaxValue);
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

        #region TableMenuItems
        public static readonly BindableProperty TableMenuItemsProperty =
                BindableProperty.Create(
                "TableMenuItems", typeof(IEnumerable<IWebServiceFilterMenuInterface>),
                typeof(NavigationProxyUserControl),
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
        #region RowMenuItems
        public static readonly BindableProperty RowMenuItemsProperty =
                BindableProperty.Create(
                "RowMenuItems", typeof(IEnumerable<IWebServiceFilterMenuInterface>),
                typeof(NavigationProxyUserControl),
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
        #region ShowSubmit
        public static readonly BindableProperty ShowSubmitProperty =
                BindableProperty.Create(
                "ShowSubmit", typeof(bool),
                typeof(NavigationProxyUserControl),
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
        #region CanAdd
        public static readonly BindableProperty CanAddProperty =
                BindableProperty.Create(
                "CanAdd", typeof(bool),
                typeof(NavigationProxyUserControl),
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
                typeof(NavigationProxyUserControl),
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
                typeof(NavigationProxyUserControl),
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
    }
}

