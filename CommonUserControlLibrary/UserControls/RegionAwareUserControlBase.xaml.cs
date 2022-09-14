using Xamarin.Forms;
using System.Collections.Generic;
using System.Windows.Input;
using Prism.Navigation;
using CommonInterfacesClassLibrary.Interfaces;

namespace CommonUserControlLibrary.UserControls {
    /// <summary>
    /// Interaction logic for RegionAwareUserControlBase.xaml
    /// </summary>
    public class RegionAwareUserControlBase: ContentView, IDestructible
    {
        // public RegionAwareUserControlBase()
        // {
        //     InitializeComponent();
        //     OnLoaded(); 
        // }

        #region OnLoaded
        // "async void" is correct for this method
        protected virtual void OnLoaded()
        {
            IRegionAwareViewModelInterface bc = BindingContext as IRegionAwareViewModelInterface;
            if (bc != null)
            {
                bc.FilterHeightChanged(this, -1d, FilterHeight);
                bc.GridHeightChanged(this, -1d, GridHeight);
                bc.ShowFilterChanged(this, false, ShowFilter);
                bc.ShowAddFilterBtnChanged(this, false, ShowAddFilterBtn);
                bc.CanAddChanged(this, false, CanAdd);
                bc.CanUpdateChanged(this, false, CanUpdate);
                bc.CanDeleteChanged(this, false, CanDelete);

                bc.FilterHeightDetailChanged(this, -1d, FilterHeightDetail);
                bc.GridHeightDetailChanged(this, -1d, GridHeightDetail);
                bc.ShowFilterDetailChanged(this, false, ShowFilterDetail);
                bc.ShowAddFilterBtnDetailChanged(this, false, ShowAddFilterBtnDetail);
                bc.CanAddDetailChanged(this, false, CanAddDetail);
                bc.CanUpdateDetailChanged(this, false, CanUpdateDetail);
                bc.CanDeleteDetailChanged(this, false, CanDeleteDetail);
            }
        }
        #endregion

        #region ContainerMenuItems
        public static readonly BindableProperty ContainerMenuItemsProperty =
                BindableProperty.Create(
                "ContainerMenuItems", typeof(IEnumerable<IWebServiceFilterMenuInterface>),
                typeof(RegionAwareUserControlBase),
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
            RegionAwareUserControlBase d = bindable as RegionAwareUserControlBase;
            if (d != null)
            {
                if (d.OnContainerMenuItemsCommand != null)
                {
                    (d.OnContainerMenuItemsCommand as Command).ChangeCanExecute();
                }
            }
        }
        public static readonly BindableProperty ContainerMenuItemsCommandProperty =
            BindableProperty.Create(nameof(ContainerMenuItemsCommand), typeof(ICommand), 
            typeof(RegionAwareUserControlBase), 
            null, 
            propertyChanged: ContainerMenuItemsCommandChanged);
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
        protected bool OnContainerMenuItemsCommandCanExecute(object p)
        {
            return (ContainerMenuItemsCommand != null); 
        }
        #endregion

        #region FilterHeight
        private static void FilterHeightChanged(BindableObject d, object oldValue, object newValue)
        {
            RegionAwareUserControlBase inst = d as RegionAwareUserControlBase;
            if (inst != null)
            {
                IRegionAwareViewModelInterface bc = inst.BindingContext as IRegionAwareViewModelInterface;
                if ((bc != null) && (newValue is double) && (oldValue is double))
                    bc.FilterHeightChanged(inst, (double)oldValue, (double)newValue);
           }
        }
        public static readonly BindableProperty FilterHeightProperty =
                BindableProperty.Create(
                "FilterHeight", typeof(double),
                typeof(RegionAwareUserControlBase),
                -1d, propertyChanged: FilterHeightChanged);
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

        #region GridHeight
        private static void GridHeightChanged(BindableObject d, object oldValue, object newValue)
        {
            RegionAwareUserControlBase inst = d as RegionAwareUserControlBase;
            if (inst != null)
            {
                IRegionAwareViewModelInterface bc = inst.BindingContext as IRegionAwareViewModelInterface;
                if ((bc != null) && (newValue is double) && (oldValue is double))
                    bc.GridHeightChanged(inst, (double)oldValue, (double)newValue);
           }
        }
        public static readonly BindableProperty GridHeightProperty =
                BindableProperty.Create(
                "GridHeight", typeof(double),
                typeof(RegionAwareUserControlBase),
                -1d, propertyChanged: GridHeightChanged);
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

        #region ShowFilter
        private static void ShowFilterChanged(BindableObject d, object oldValue, object newValue)
        {
            RegionAwareUserControlBase inst = d as RegionAwareUserControlBase;
            if (inst != null)
            {
                IRegionAwareViewModelInterface bc = inst.BindingContext as IRegionAwareViewModelInterface;
                if ((bc != null) && (newValue is bool) && (oldValue is bool))
                    bc.ShowFilterChanged(inst, (bool)oldValue, (bool)newValue);
           }
        }
        public static readonly BindableProperty ShowFilterProperty =
                BindableProperty.Create(
                "ShowFilter", typeof(bool),
                typeof(RegionAwareUserControlBase),
                false, propertyChanged: ShowFilterChanged);
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
        private static void ShowAddFilterBtnChanged(BindableObject d, object oldValue, object newValue)
        {
            RegionAwareUserControlBase inst = d as RegionAwareUserControlBase;
            if (inst != null)
            {
                IRegionAwareViewModelInterface bc = inst.BindingContext as IRegionAwareViewModelInterface;
                if ((bc != null) && (newValue is bool) && (oldValue is bool))
                    bc.ShowAddFilterBtnChanged(inst, (bool)oldValue, (bool)newValue);
           }
        }
        public static readonly BindableProperty ShowAddFilterBtnProperty =
                BindableProperty.Create(
                "ShowAddFilterBtn", typeof(bool),
                typeof(RegionAwareUserControlBase),
                false, propertyChanged: ShowAddFilterBtnChanged);
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


        #region CanAdd
        private static void CanAddChanged(BindableObject d, object oldValue, object newValue)
        {
            RegionAwareUserControlBase inst = d as RegionAwareUserControlBase;
            if (inst != null)
            {
                IRegionAwareViewModelInterface bc = inst.BindingContext as IRegionAwareViewModelInterface;
                if ((bc != null) && (newValue is bool) && (oldValue is bool))
                    bc.CanAddChanged(inst, (bool)oldValue, (bool)newValue);
           }
        }
        public static readonly BindableProperty CanAddProperty =
                BindableProperty.Create(
                "CanAdd", typeof(bool),
                typeof(RegionAwareUserControlBase),
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
            RegionAwareUserControlBase inst = d as RegionAwareUserControlBase;
            if (inst != null)
            {
                IRegionAwareViewModelInterface bc = inst.BindingContext as IRegionAwareViewModelInterface;
                if ((bc != null) && (newValue is bool) && (oldValue is bool))
                    bc.CanUpdateChanged(inst, (bool)oldValue, (bool)newValue);
           }
        }
        public static readonly BindableProperty CanUpdateProperty =
                BindableProperty.Create(
                "CanUpdate", typeof(bool),
                typeof(RegionAwareUserControlBase),
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
            RegionAwareUserControlBase inst = d as RegionAwareUserControlBase;
            if (inst != null)
            {
                IRegionAwareViewModelInterface bc = inst.BindingContext as IRegionAwareViewModelInterface;
                if ((bc != null) && (newValue is bool) && (oldValue is bool))
                    bc.CanDeleteChanged(inst, (bool)oldValue, (bool)newValue);
           }
        }
        public static readonly BindableProperty CanDeleteProperty =
                BindableProperty.Create(
                "CanDelete", typeof(bool),
                typeof(RegionAwareUserControlBase),
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

        #region FilterHeightDetail
        private static void FilterHeightDetailChanged(BindableObject d, object oldValue, object newValue)
        {
            RegionAwareUserControlBase inst = d as RegionAwareUserControlBase;
            if (inst != null)
            {
                IRegionAwareViewModelInterface bc = inst.BindingContext as IRegionAwareViewModelInterface;
                if ((bc != null) && (newValue is double) && (oldValue is double))
                    bc.FilterHeightDetailChanged(inst, (double)oldValue, (double)newValue);
           }
        }
        public static readonly BindableProperty FilterHeightDetailProperty =
                BindableProperty.Create(
                "FilterHeightDetail", typeof(double),
                typeof(RegionAwareUserControlBase),
                -1d, propertyChanged: FilterHeightDetailChanged);
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

        #region GridHeightDetail
        private static void GridHeightDetailChanged(BindableObject d, object oldValue, object newValue)
        {
            RegionAwareUserControlBase inst = d as RegionAwareUserControlBase;
            if (inst != null)
            {
                IRegionAwareViewModelInterface bc = inst.BindingContext as IRegionAwareViewModelInterface;
                if ((bc != null) && (newValue is double) && (oldValue is double))
                    bc.GridHeightDetailChanged(inst, (double)oldValue, (double)newValue);
           }
        }
        public static readonly BindableProperty GridHeightDetailProperty =
                BindableProperty.Create(
                "GridHeightDetail", typeof(double),
                typeof(RegionAwareUserControlBase),
                -1d, propertyChanged: GridHeightDetailChanged);
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

        #region ShowFilterDetail
        private static void ShowFilterDetailChanged(BindableObject d, object oldValue, object newValue)
        {
            RegionAwareUserControlBase inst = d as RegionAwareUserControlBase;
            if (inst != null)
            {
                IRegionAwareViewModelInterface bc = inst.BindingContext as IRegionAwareViewModelInterface;
                if ((bc != null) && (newValue is bool) && (oldValue is bool))
                    bc.ShowFilterDetailChanged(inst, (bool)oldValue, (bool)newValue);
           }
        }
        public static readonly BindableProperty ShowFilterDetailProperty =
                BindableProperty.Create(
                "ShowFilterDetail", typeof(bool),
                typeof(RegionAwareUserControlBase),
                false, propertyChanged: ShowFilterDetailChanged);
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
        private static void ShowAddFilterBtnDetailChanged(BindableObject d, object oldValue, object newValue)
        {
            RegionAwareUserControlBase inst = d as RegionAwareUserControlBase;
            if (inst != null)
            {
                IRegionAwareViewModelInterface bc = inst.BindingContext as IRegionAwareViewModelInterface;
                if ((bc != null) && (newValue is bool) && (oldValue is bool))
                    bc.ShowAddFilterBtnDetailChanged(inst, (bool)oldValue, (bool)newValue);
           }
        }
        public static readonly BindableProperty ShowAddFilterBtnDetailProperty =
                BindableProperty.Create(
                "ShowAddFilterBtnDetail", typeof(bool),
                typeof(RegionAwareUserControlBase),
                false, propertyChanged: ShowAddFilterBtnDetailChanged);
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

        #region CanAddDetail
        private static void CanAddDetailChanged(BindableObject d, object oldValue, object newValue)
        {
            RegionAwareUserControlBase inst = d as RegionAwareUserControlBase;
            if (inst != null)
            {
                IRegionAwareViewModelInterface bc = inst.BindingContext as IRegionAwareViewModelInterface;
                if ((bc != null) && (newValue is bool) && (oldValue is bool))
                    bc.CanAddDetailChanged(inst, (bool)oldValue, (bool)newValue);
           }
        }
        public static readonly BindableProperty CanAddDetailProperty =
                BindableProperty.Create(
                "CanAddDetail", typeof(bool),
                typeof(RegionAwareUserControlBase),
                false, propertyChanged: CanAddDetailChanged);
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
        private static void CanUpdateDetailChanged(BindableObject d, object oldValue, object newValue)
        {
            RegionAwareUserControlBase inst = d as RegionAwareUserControlBase;
            if (inst != null)
            {
                IRegionAwareViewModelInterface bc = inst.BindingContext as IRegionAwareViewModelInterface;
                if ((bc != null) && (newValue is bool) && (oldValue is bool))
                    bc.CanUpdateDetailChanged(inst, (bool)oldValue, (bool)newValue);
           }
        }
        public static readonly BindableProperty CanUpdateDetailProperty =
                BindableProperty.Create(
                "CanUpdateDetail", typeof(bool),
                typeof(RegionAwareUserControlBase),
                false, propertyChanged: CanUpdateDetailChanged);
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
        private static void CanDeleteDetailChanged(BindableObject d, object oldValue, object newValue)
        {
            RegionAwareUserControlBase inst = d as RegionAwareUserControlBase;
            if (inst != null)
            {
                IRegionAwareViewModelInterface bc = inst.BindingContext as IRegionAwareViewModelInterface;
                if ((bc != null) && (newValue is bool) && (oldValue is bool))
                    bc.CanDeleteDetailChanged(inst, (bool)oldValue, (bool)newValue);
           }
        }
        public static readonly BindableProperty CanDeleteDetailProperty =
                BindableProperty.Create(
                "CanDeleteDetail", typeof(bool),
                typeof(RegionAwareUserControlBase),
                false, propertyChanged: CanDeleteDetailChanged);
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

        public virtual void OnDestroyed()
        {
            RemoveBinding(IsDestroyedProperty);
            IsDestroyed = true;
            IRegionAwareViewModelInterface bc = BindingContext as IRegionAwareViewModelInterface;
            if(bc != null) bc.OnDestroy();
            RemoveBinding(ContainerMenuItemsProperty);
            RemoveBinding(ContainerMenuItemsCommandProperty);
            RemoveBinding(FilterHeightProperty);
            RemoveBinding(GridHeightProperty);
            RemoveBinding(ShowFilterProperty);
            RemoveBinding(ShowAddFilterBtnProperty);
            RemoveBinding(CanAddProperty);
            RemoveBinding(CanUpdateProperty);
            RemoveBinding(CanDeleteProperty);
            RemoveBinding(FilterHeightDetailProperty);
            RemoveBinding(GridHeightDetailProperty);
            RemoveBinding(ShowFilterDetailProperty);
            RemoveBinding(ShowAddFilterBtnDetailProperty);
            RemoveBinding(CanAddDetailProperty);
            RemoveBinding(CanUpdateDetailProperty);
            RemoveBinding(CanDeleteDetailProperty);
            ContainerMenuItems = null;
            ContainerMenuItemsCommand = null;
            FilterHeight = -1d;
            GridHeight = -1d;
            FilterHeightDetail = -1d;
            GridHeightDetail = -1d;
            BindingContext = null;
            Content = null;
        }
        private static void IsDestroyedChanged(BindableObject d, object oldValue, object newValue)
        {
            RegionAwareUserControlBase inst = d as RegionAwareUserControlBase;
            if (inst != null)
            {
                inst.OnDestroyed();
            }
        }
        public static readonly BindableProperty IsDestroyedProperty =
                BindableProperty.Create(
                "IsDestroyed", typeof(bool),
                typeof(RegionAwareUserControlBase),
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

