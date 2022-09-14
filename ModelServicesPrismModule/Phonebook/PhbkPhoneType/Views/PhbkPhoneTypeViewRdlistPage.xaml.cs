using Xamarin.Forms;
using Prism.Navigation;


namespace ModelServicesPrismModule.Phonebook.PhbkPhoneType.Views {
    /// <summary>
    /// Interaction logic for PhbkPhoneTypeViewRdlistPage.xaml
    /// </summary>
    public partial class PhbkPhoneTypeViewRdlistPage: ContentPage, IDestructible 
    {
        public PhbkPhoneTypeViewRdlistPage()
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
            PhbkPhoneTypeViewRdlistPage inst = d as PhbkPhoneTypeViewRdlistPage;
            if (inst != null)
            {
                inst.OnDestroyed();
            }
        }
        public static readonly BindableProperty IsDestroyedProperty =
                BindableProperty.Create(
                "IsDestroyed", typeof(bool),
                typeof(PhbkPhoneTypeViewRdlistPage),
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

