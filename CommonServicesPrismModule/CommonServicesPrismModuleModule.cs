using Prism.Ioc;
using Prism.Modularity;

namespace CommonServicesPrismModule
{
    public class CommonServicesPrismModuleModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            CommonInterfacesClassLibrary.AppGlblSettingsSrvc.IAppGlblSettingsService s = new AppGlblSettingsSrvc.AppGlblSettingsService();
            containerRegistry.RegisterInstance<CommonInterfacesClassLibrary.AppGlblSettingsSrvc.IAppGlblSettingsService>(s);

            containerRegistry.Register<CommonInterfacesClassLibrary.AppGlblLoginSrvc.IAppGlblLoginService, CommonServicesPrismModule.AppGlblLoginSrvc.AppGlblLoginService>();
            containerRegistry.RegisterDialog<CommonServicesPrismModule.UserControls.ColumnSelectorDlgUserControl, CommonServicesPrismModule.ViewModels.ColumnSelectorDlgViewModel>("ColumnSelectorDlg");
            containerRegistry.RegisterDialog<CommonServicesPrismModule.UserControls.MessageDlgUserControl, CommonServicesPrismModule.ViewModels.MessageDlgViewModel>("MessageDlg");
            Prism.Mvvm.ViewModelLocationProvider.Register<CommonServicesPrismModule.Views.AccessDeniedPage, CommonServicesPrismModule.ViewModels.AccessDeniedPageViewModel>();
            containerRegistry.RegisterForNavigation<CommonServicesPrismModule.Views.AccessDeniedPage, CommonServicesPrismModule.ViewModels.AccessDeniedPageViewModel>("AccessDeniedPage");
            Prism.Mvvm.ViewModelLocationProvider.Register<CommonServicesPrismModule.UserControls.AccessDeniedUserControl, CommonServicesPrismModule.ViewModels.AccessDeniedViewModel>();
            containerRegistry.RegisterForRegionNavigation<CommonServicesPrismModule.UserControls.AccessDeniedUserControl, CommonServicesPrismModule.ViewModels.AccessDeniedViewModel>("AccessDeniedUserControl");
            containerRegistry.Register<Xamarin.Forms.ContentView, CommonServicesPrismModule.UserControls.AccessDeniedUserControl>("AccessDeniedUserControl");
            Prism.Mvvm.ViewModelLocationProvider.Register<CommonServicesPrismModule.Views.PageNotFoundPage, CommonServicesPrismModule.ViewModels.PageNotFoundPageViewModel>();
            containerRegistry.RegisterForNavigation<CommonServicesPrismModule.Views.PageNotFoundPage, CommonServicesPrismModule.ViewModels.PageNotFoundPageViewModel>("PageNotFoundPage");
            Prism.Mvvm.ViewModelLocationProvider.Register<CommonServicesPrismModule.UserControls.PageNotFoundUserControl, CommonServicesPrismModule.ViewModels.PageNotFoundViewModel>();
            containerRegistry.RegisterForRegionNavigation<CommonServicesPrismModule.UserControls.PageNotFoundUserControl, CommonServicesPrismModule.ViewModels.PageNotFoundViewModel>("PageNotFoundUserControl");
            containerRegistry.Register<Xamarin.Forms.ContentView, CommonServicesPrismModule.UserControls.PageNotFoundUserControl>("PageNotFoundUserControl");
            Prism.Mvvm.ViewModelLocationProvider.Register<CommonServicesPrismModule.Views.HomePage, CommonServicesPrismModule.ViewModels.HomePageViewModel>();
            containerRegistry.RegisterForNavigation<CommonServicesPrismModule.Views.HomePage, CommonServicesPrismModule.ViewModels.HomePageViewModel>("HomePage");
            Prism.Mvvm.ViewModelLocationProvider.Register<CommonServicesPrismModule.Views.RegisterUserPage, CommonServicesPrismModule.ViewModels.RegisterUserPageViewModel>();
            containerRegistry.RegisterForNavigation<CommonServicesPrismModule.Views.RegisterUserPage, CommonServicesPrismModule.ViewModels.RegisterUserPageViewModel>("RegisterUserPage");
            Prism.Mvvm.ViewModelLocationProvider.Register<CommonServicesPrismModule.Views.LoginUserPage, CommonServicesPrismModule.ViewModels.LoginUserPageViewModel>();
            containerRegistry.RegisterForNavigation<CommonServicesPrismModule.Views.LoginUserPage, CommonServicesPrismModule.ViewModels.LoginUserPageViewModel>("LoginUserPage");
            Prism.Mvvm.ViewModelLocationProvider.Register<CommonServicesPrismModule.Views.LogoutUserPage, CommonServicesPrismModule.ViewModels.LogoutUserPageViewModel>();
            containerRegistry.RegisterForNavigation<CommonServicesPrismModule.Views.LogoutUserPage, CommonServicesPrismModule.ViewModels.LogoutUserPageViewModel>("LogoutUserPage");
            Prism.Mvvm.ViewModelLocationProvider.Register<CommonServicesPrismModule.Views.ChngpswdUserPage, CommonServicesPrismModule.ViewModels.ChngpswdUserPageViewModel>();
            containerRegistry.RegisterForNavigation<CommonServicesPrismModule.Views.ChngpswdUserPage, CommonServicesPrismModule.ViewModels.ChngpswdUserPageViewModel>("ChngpswdUserPage");
        }
    }
}
