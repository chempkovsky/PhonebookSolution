using Xamarin.Forms;
using Prism.Navigation;


namespace ModelServicesPrismModule.asp.aspnetuserrolesView.Views.RdPage {
    /// <summary>
    /// Interaction logic for AspnetuserrolesViewRdelPage.xaml
    /// </summary>
    public partial class AspnetuserrolesViewRdelPage: ContentPage, IDestructible
    {
        public AspnetuserrolesViewRdelPage()
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
            AspnetuserrolesViewRdelPage inst = d as AspnetuserrolesViewRdelPage;
            if (inst != null)
            {
                inst.OnDestroyed();
            }
        }
        public static readonly BindableProperty IsDestroyedProperty =
                BindableProperty.Create(
                "IsDestroyed", typeof(bool),
                typeof(AspnetuserrolesViewRdelPage),
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


