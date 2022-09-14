using Prism;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions.Adapters;
using Xamarin.Forms;
using Xamarin.Essentials.Interfaces;
using Xamarin.Essentials.Implementation;
using PrismPhonebook.Views;
using PrismPhonebook.ViewModels;
using CommonUserControlLibrary.UserControls;
using PrismPhonebook.Classes;
using CommonServicesPrismModule;
using ModelServicesPrismModule;
using FeatureServicesPrismModule;
using O2mPrismModule;

namespace PrismPhonebook {

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            await NavigationService.NavigateAsync($"/MainFlyoutPage/NavigationPage/HomePage");
            //await NavigationService.NavigateAsync($"/MainFlyoutPage/NavigationPage/PageNotFoundPage");
            
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterRegionServices(configureAdapters: OnconfigureAdapters);
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainFlyoutPage, MainFlyoutPageViewModel>();
        }
        private void OnconfigureAdapters(RegionAdapterMappings obj)
        {
            obj.RegisterMapping<ProxyUserControl, ProxyUserControlRegionAdapter>();
        }
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<CommonServicesPrismModuleModule>();
            // these two lines are added to the method
            moduleCatalog.AddModule<ModelServicesPrismModuleModule>();
            moduleCatalog.AddModule<O2mPrismModuleModule>();
            moduleCatalog.AddModule<FeatureServicesPrismModuleModule>();
        }

    }
}

