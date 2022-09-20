using Xamarin.Forms;
using Prism.Navigation;


namespace ModelServicesPrismModule.asp.aspnetuserrolesView.Views.RvPage {
    /// <summary>
    /// Interaction logic for AspnetuserrolesViewRviewPage.xaml
    /// </summary>
    public partial class AspnetuserrolesViewRviewPage: ContentPage, IDestructible
    {
        public AspnetuserrolesViewRviewPage()
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
            AspnetuserrolesViewRviewPage inst = d as AspnetuserrolesViewRviewPage;
            if (inst != null)
            {
                inst.OnDestroyed();
            }
        }
        public static readonly BindableProperty IsDestroyedProperty =
                BindableProperty.Create(
                "IsDestroyed", typeof(bool),
                typeof(AspnetuserrolesViewRviewPage),
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


