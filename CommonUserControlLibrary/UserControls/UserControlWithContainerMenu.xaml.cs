using Xamarin.Forms;
using System.Collections.Generic;
using System.Windows.Input;

using CommonInterfacesClassLibrary.Interfaces;
using CommonCustomControlLibrary.Controls;


namespace CommonUserControlLibrary.UserControls {
    /// <summary>
    /// Interaction logic for UserControlWithContainerMenu.xaml
    /// </summary>
    public class UserControlWithContainerMenu: ContentViewWithBCFeedback
    {

        #region ContainerMenuItems
        public static readonly BindableProperty ContainerMenuItemsProperty =
                BindableProperty.Create(
                "ContainerMenuItems", typeof(IEnumerable<IWebServiceFilterMenuInterface>),
                typeof(UserControlWithContainerMenu),
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
            UserControlWithContainerMenu d = bindable as UserControlWithContainerMenu;
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
            typeof(UserControlWithContainerMenu), 
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
        protected bool OnContainerMenuItemsCommandCanExecute(object prm)
        {
            ICommand cmd = ContainerMenuItemsCommand;
            if (cmd != null) {
                return cmd.CanExecute(prm);
            }
            return false;
        }
        #endregion
        #region FilterHeight
        public static readonly BindableProperty FilterHeightProperty =
                BindableProperty.Create(
                "FilterHeight", typeof(double),
                typeof(UserControlWithContainerMenu),
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
        #region GridHeight
        public static readonly BindableProperty GridHeightProperty =
                BindableProperty.Create(
                "GridHeight", typeof(double),
                typeof(UserControlWithContainerMenu),
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

        #region OnDestroyed
        public override void OnDestroyed()
        {
            base.OnDestroyed();
            RemoveBinding(ContainerMenuItemsProperty);
            RemoveBinding(ContainerMenuItemsCommandProperty);
            RemoveBinding(FilterHeightProperty);
            RemoveBinding(GridHeightProperty);
            ContainerMenuItemsCommand = null;
            ContainerMenuItems = null;
            FilterHeight = - 1d; // unsubscrribe MaxHeight attachment
            GridHeight = - 1d;  // unsubscrribe MaxHeight attachment
        }
        #endregion
    }
}

