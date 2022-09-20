using Xamarin.Forms;
using Prism.Navigation;


namespace ModelServicesPrismModule.asp.aspnetroleView.Views.O2mPage {
    /// <summary>
    /// Interaction logic for AspnetroleViewO2mPage.xaml
    /// </summary>
    public partial class AspnetroleViewO2mPage: ContentPage, IDestructible
    {
        public AspnetroleViewO2mPage()
        {
            InitializeComponent();
        }
        #region IDestructible
        public virtual void OnDestroyed()
        {
            IDestructible bc = BindingContext as IDestructible;
            if(bc != null) bc.Destroy();
            BindingContext = null;
            Content = null;
        }
        private static void IsDestroyedChanged(BindableObject d, object oldValue, object newValue)
        {
            AspnetroleViewO2mPage inst = d as AspnetroleViewO2mPage;
            if (inst != null)
            {
                inst.OnDestroyed();
            }
        }
        public static readonly BindableProperty IsDestroyedProperty =
                BindableProperty.Create(
                "IsDestroyed", typeof(bool),
                typeof(AspnetroleViewO2mPage),
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

        public void Destroy()
        {
            IsDestroyed = true;
        }
        #endregion
    }
}

