using Xamarin.Forms;
using Prism.Navigation;

namespace FeatureServicesPrismModule.Phonebook.Lforms {
    /// <summary>
    /// Interaction logic for LformsFeatureFtrUserControl.xaml
    /// </summary>
    public partial class LformsFeatureFtrUserControl: ContentPage, IDestructible
    {
        public LformsFeatureFtrUserControl()
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
            LformsFeatureFtrUserControl inst = d as LformsFeatureFtrUserControl;
            if (inst != null)
            {
                inst.OnDestroyed();
            }
        }
        public static readonly BindableProperty IsDestroyedProperty =
                BindableProperty.Create(
                "IsDestroyed", typeof(bool),
                typeof(LformsFeatureFtrUserControl),
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


