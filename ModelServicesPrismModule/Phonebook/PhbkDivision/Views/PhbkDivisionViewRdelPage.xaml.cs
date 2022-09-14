using Xamarin.Forms;
using Prism.Navigation;


namespace ModelServicesPrismModule.Phonebook.PhbkDivision.Views {
    /// <summary>
    /// Interaction logic for PhbkDivisionViewRdelPage.xaml
    /// </summary>
    public partial class PhbkDivisionViewRdelPage: ContentPage, IDestructible
    {
        public PhbkDivisionViewRdelPage()
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
            PhbkDivisionViewRdelPage inst = d as PhbkDivisionViewRdelPage;
            if (inst != null)
            {
                inst.OnDestroyed();
            }
        }
        public static readonly BindableProperty IsDestroyedProperty =
                BindableProperty.Create(
                "IsDestroyed", typeof(bool),
                typeof(PhbkDivisionViewRdelPage),
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


