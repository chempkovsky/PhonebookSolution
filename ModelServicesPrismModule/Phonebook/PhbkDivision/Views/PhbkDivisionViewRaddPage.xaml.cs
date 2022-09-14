using Xamarin.Forms;
using Prism.Navigation;


namespace ModelServicesPrismModule.Phonebook.PhbkDivision.Views {
    /// <summary>
    /// Interaction logic for PhbkDivisionViewRaddPage.xaml
    /// </summary>
    public partial class PhbkDivisionViewRaddPage: ContentPage, IDestructible
    {
        public PhbkDivisionViewRaddPage()
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
            PhbkDivisionViewRaddPage inst = d as PhbkDivisionViewRaddPage;
            if (inst != null)
            {
                inst.OnDestroyed();
            }
        }
        public static readonly BindableProperty IsDestroyedProperty =
                BindableProperty.Create(
                "IsDestroyed", typeof(bool),
                typeof(PhbkDivisionViewRaddPage),
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


