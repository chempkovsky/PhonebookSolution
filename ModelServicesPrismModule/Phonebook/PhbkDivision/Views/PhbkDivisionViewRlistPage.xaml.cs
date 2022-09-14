using Xamarin.Forms;
using Prism.Navigation;



namespace ModelServicesPrismModule.Phonebook.PhbkDivision.Views {
    /// <summary>
    /// Interaction logic for PhbkDivisionViewRlistPage.xaml
    /// </summary>
    public partial class PhbkDivisionViewRlistPage: ContentPage, IDestructible 
    {
        public PhbkDivisionViewRlistPage()
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
            PhbkDivisionViewRlistPage inst = d as PhbkDivisionViewRlistPage;
            if (inst != null)
            {
                inst.OnDestroyed();
            }
        }
        public static readonly BindableProperty IsDestroyedProperty =
                BindableProperty.Create(
                "IsDestroyed", typeof(bool),
                typeof(PhbkDivisionViewRlistPage),
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

