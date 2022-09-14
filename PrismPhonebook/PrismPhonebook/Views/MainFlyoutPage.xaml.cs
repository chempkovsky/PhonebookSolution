using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.Navigation;
using Xamarin.Essentials;
using CommonInterfacesClassLibrary.AppGlblSettingsSrvc;

namespace PrismPhonebook.Views {
    /// <summary>
    /// Interaction logic for MainFlyoutPage.xaml
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainFlyoutPage: FlyoutPage, IFlyoutPageOptions, IDestructible
    {
        // protected IAppGlblSettingsService _GlblSettingsSrv=null;
        public MainFlyoutPage() // IAppGlblSettingsService GlblSettingsSrv)
        {
            //_GlblSettingsSrv = GlblSettingsSrv;
            InitializeComponent();
        }
        public static readonly BindableProperty IsPresentedAfterNavigationProperty =
                    BindableProperty.Create(nameof(IsPresentedAfterNavigation), typeof(bool), typeof(MainFlyoutPage), false);
        public bool IsPresentedAfterNavigation
        {
            get => (bool)GetValue(IsPresentedAfterNavigationProperty);
            set => SetValue(IsPresentedAfterNavigationProperty, value);
        }
        public void Destroy()
        {
            //_GlblSettingsSrv = null;
            BindingContext = null;
        }
    }
}

