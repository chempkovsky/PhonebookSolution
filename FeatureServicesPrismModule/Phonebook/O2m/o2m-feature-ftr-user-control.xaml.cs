using Xamarin.Forms;
using Prism.Navigation;

namespace FeatureServicesPrismModule.Phonebook.O2m {
    /// <summary>
    /// Interaction logic for O2mFeatureFtrUserControl.xaml
    /// </summary>
    public partial class O2mFeatureFtrUserControl: ContentPage, IDestructible
    {
        public O2mFeatureFtrUserControl()
        {
            InitializeComponent();
        }

        #region IDestructible
        public virtual void OnDestroyed()
        {
            IDestructible bc = BindingContext as IDestructible;
            if(bc != null) bc.Destroy();
            Content = null;
            BindingContext = null;
        }
        private static void IsDestroyedChanged(BindableObject d, object oldValue, object newValue)
        {
            O2mFeatureFtrUserControl inst = d as O2mFeatureFtrUserControl;
            if (inst != null)
            {
                inst.OnDestroyed();
            }
        }
        public static readonly BindableProperty IsDestroyedProperty =
                BindableProperty.Create(
                "IsDestroyed", typeof(bool),
                typeof(O2mFeatureFtrUserControl),
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


