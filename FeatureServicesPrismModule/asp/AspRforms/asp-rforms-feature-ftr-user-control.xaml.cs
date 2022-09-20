using Xamarin.Forms;
using Prism.Navigation;

namespace FeatureServicesPrismModule.asp.AspRforms {
    /// <summary>
    /// Interaction logic for AspRformsFeatureFtrUserControl.xaml
    /// </summary>
    public partial class AspRformsFeatureFtrUserControl: ContentPage, IDestructible
    {
        public AspRformsFeatureFtrUserControl()
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
            AspRformsFeatureFtrUserControl inst = d as AspRformsFeatureFtrUserControl;
            if (inst != null)
            {
                inst.OnDestroyed();
            }
        }
        public static readonly BindableProperty IsDestroyedProperty =
                BindableProperty.Create(
                "IsDestroyed", typeof(bool),
                typeof(AspRformsFeatureFtrUserControl),
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


