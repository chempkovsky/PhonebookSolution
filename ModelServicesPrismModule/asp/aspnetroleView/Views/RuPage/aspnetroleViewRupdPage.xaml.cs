using Xamarin.Forms;
using Prism.Navigation;


namespace ModelServicesPrismModule.asp.aspnetroleView.Views.RuPage {
    /// <summary>
    /// Interaction logic for AspnetroleViewRupdPage.xaml
    /// </summary>
    public partial class AspnetroleViewRupdPage: ContentPage, IDestructible
    {
        public AspnetroleViewRupdPage()
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
            AspnetroleViewRupdPage inst = d as AspnetroleViewRupdPage;
            if (inst != null)
            {
                inst.OnDestroyed();
            }
        }
        public static readonly BindableProperty IsDestroyedProperty =
                BindableProperty.Create(
                "IsDestroyed", typeof(bool),
                typeof(AspnetroleViewRupdPage),
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


