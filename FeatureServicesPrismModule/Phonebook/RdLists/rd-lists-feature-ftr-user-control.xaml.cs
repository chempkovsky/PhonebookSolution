using Xamarin.Forms;
using Prism.Navigation;

namespace FeatureServicesPrismModule.Phonebook.RdLists {
    /// <summary>
    /// Interaction logic for RdListsFeatureFtrUserControl.xaml
    /// </summary>
    public partial class RdListsFeatureFtrUserControl: ContentPage, IDestructible
    {
        public RdListsFeatureFtrUserControl()
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
            RdListsFeatureFtrUserControl inst = d as RdListsFeatureFtrUserControl;
            if (inst != null)
            {
                inst.OnDestroyed();
            }
        }
        public static readonly BindableProperty IsDestroyedProperty =
                BindableProperty.Create(
                "IsDestroyed", typeof(bool),
                typeof(RdListsFeatureFtrUserControl),
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


