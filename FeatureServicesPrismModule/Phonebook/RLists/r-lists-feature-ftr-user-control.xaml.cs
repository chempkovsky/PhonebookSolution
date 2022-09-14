using Xamarin.Forms;
using Prism.Navigation;

namespace FeatureServicesPrismModule.Phonebook.RLists {
    /// <summary>
    /// Interaction logic for RListsFeatureFtrUserControl.xaml
    /// </summary>
    public partial class RListsFeatureFtrUserControl: ContentPage, IDestructible
    {
        public RListsFeatureFtrUserControl()
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
            RListsFeatureFtrUserControl inst = d as RListsFeatureFtrUserControl;
            if (inst != null)
            {
                inst.OnDestroyed();
            }
        }
        public static readonly BindableProperty IsDestroyedProperty =
                BindableProperty.Create(
                "IsDestroyed", typeof(bool),
                typeof(RListsFeatureFtrUserControl),
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


