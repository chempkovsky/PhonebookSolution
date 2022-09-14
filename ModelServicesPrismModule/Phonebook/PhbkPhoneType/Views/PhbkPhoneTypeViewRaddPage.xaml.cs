using Xamarin.Forms;
using Prism.Navigation;


namespace ModelServicesPrismModule.Phonebook.PhbkPhoneType.Views {
    /// <summary>
    /// Interaction logic for PhbkPhoneTypeViewRaddPage.xaml
    /// </summary>
    public partial class PhbkPhoneTypeViewRaddPage: ContentPage, IDestructible
    {
        public PhbkPhoneTypeViewRaddPage()
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
            PhbkPhoneTypeViewRaddPage inst = d as PhbkPhoneTypeViewRaddPage;
            if (inst != null)
            {
                inst.OnDestroyed();
            }
        }
        public static readonly BindableProperty IsDestroyedProperty =
                BindableProperty.Create(
                "IsDestroyed", typeof(bool),
                typeof(PhbkPhoneTypeViewRaddPage),
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


