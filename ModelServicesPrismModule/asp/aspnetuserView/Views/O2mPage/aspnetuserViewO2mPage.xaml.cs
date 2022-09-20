using Xamarin.Forms;
using Prism.Navigation;


namespace ModelServicesPrismModule.asp.aspnetuserView.Views.O2mPage {
    /// <summary>
    /// Interaction logic for AspnetuserViewO2mPage.xaml
    /// </summary>
    public partial class AspnetuserViewO2mPage: ContentPage, IDestructible
    {
        public AspnetuserViewO2mPage()
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
            AspnetuserViewO2mPage inst = d as AspnetuserViewO2mPage;
            if (inst != null)
            {
                inst.OnDestroyed();
            }
        }
        public static readonly BindableProperty IsDestroyedProperty =
                BindableProperty.Create(
                "IsDestroyed", typeof(bool),
                typeof(AspnetuserViewO2mPage),
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

