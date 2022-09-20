using Xamarin.Forms;
using Prism.Navigation;



namespace ModelServicesPrismModule.asp.aspnetroleView.Views {
    /// <summary>
    /// Interaction logic for AspnetroleViewRlistPage.xaml
    /// </summary>
    public partial class AspnetroleViewRlistPage: ContentPage, IDestructible 
    {
        public AspnetroleViewRlistPage()
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
            AspnetroleViewRlistPage inst = d as AspnetroleViewRlistPage;
            if (inst != null)
            {
                inst.OnDestroyed();
            }
        }
        public static readonly BindableProperty IsDestroyedProperty =
                BindableProperty.Create(
                "IsDestroyed", typeof(bool),
                typeof(AspnetroleViewRlistPage),
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

