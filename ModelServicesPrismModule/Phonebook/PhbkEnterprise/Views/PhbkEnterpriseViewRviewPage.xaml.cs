using Xamarin.Forms;
using Prism.Navigation;


namespace ModelServicesPrismModule.Phonebook.PhbkEnterprise.Views {
    /// <summary>
    /// Interaction logic for PhbkEnterpriseViewRviewPage.xaml
    /// </summary>
    public partial class PhbkEnterpriseViewRviewPage: ContentPage, IDestructible
    {
        public PhbkEnterpriseViewRviewPage()
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
            PhbkEnterpriseViewRviewPage inst = d as PhbkEnterpriseViewRviewPage;
            if (inst != null)
            {
                inst.OnDestroyed();
            }
        }
        public static readonly BindableProperty IsDestroyedProperty =
                BindableProperty.Create(
                "IsDestroyed", typeof(bool),
                typeof(PhbkEnterpriseViewRviewPage),
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


