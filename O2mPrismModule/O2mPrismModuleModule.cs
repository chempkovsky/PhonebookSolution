using Prism.Ioc;
using Prism.Modularity;

namespace O2mPrismModule
{
    public class O2mPrismModuleModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            Prism.Mvvm.ViewModelLocationProvider.Register<O2mPrismModule.Phonebook.PhbkEmployee.UserControls.O2m.PhbkEmployeeViewO2mUserControl, O2mPrismModule.Phonebook.PhbkEmployee.ViewModels.O2m.PhbkEmployeeViewO2mViewModel>();
            containerRegistry.RegisterForRegionNavigation<O2mPrismModule.Phonebook.PhbkEmployee.UserControls.O2m.PhbkEmployeeViewO2mUserControl, O2mPrismModule.Phonebook.PhbkEmployee.ViewModels.O2m.PhbkEmployeeViewO2mViewModel>("PhbkEmployeeViewO2mUserControl");
            containerRegistry.Register<Xamarin.Forms.ContentView, O2mPrismModule.Phonebook.PhbkEmployee.UserControls.O2m.PhbkEmployeeViewO2mUserControl>("PhbkEmployeeViewO2mUserControl");
            Prism.Mvvm.ViewModelLocationProvider.Register<O2mPrismModule.Phonebook.PhbkEmployee.Views.O2mPage.PhbkEmployeeViewO2mPage, O2mPrismModule.Phonebook.PhbkEmployee.ViewModels.O2mPage.PhbkEmployeeViewO2mPageViewModel>();
            containerRegistry.RegisterForNavigation<O2mPrismModule.Phonebook.PhbkEmployee.Views.O2mPage.PhbkEmployeeViewO2mPage, O2mPrismModule.Phonebook.PhbkEmployee.ViewModels.O2mPage.PhbkEmployeeViewO2mPageViewModel>("PhbkEmployeeViewO2mPage");
            containerRegistry.Register<Xamarin.Forms.ContentPage, O2mPrismModule.Phonebook.PhbkEmployee.Views.O2mPage.PhbkEmployeeViewO2mPage>("PhbkEmployeeViewO2mPage");
            Prism.Mvvm.ViewModelLocationProvider.Register<O2mPrismModule.Phonebook.PhbkEnterprise.UserControls.O2m.PhbkEnterpriseViewO2mUserControl, O2mPrismModule.Phonebook.PhbkEnterprise.ViewModels.O2m.PhbkEnterpriseViewO2mViewModel>();
            containerRegistry.RegisterForRegionNavigation<O2mPrismModule.Phonebook.PhbkEnterprise.UserControls.O2m.PhbkEnterpriseViewO2mUserControl, O2mPrismModule.Phonebook.PhbkEnterprise.ViewModels.O2m.PhbkEnterpriseViewO2mViewModel>("PhbkEnterpriseViewO2mUserControl");
            containerRegistry.Register<Xamarin.Forms.ContentView, O2mPrismModule.Phonebook.PhbkEnterprise.UserControls.O2m.PhbkEnterpriseViewO2mUserControl>("PhbkEnterpriseViewO2mUserControl");
            Prism.Mvvm.ViewModelLocationProvider.Register<O2mPrismModule.Phonebook.PhbkEnterprise.Views.O2mPage.PhbkEnterpriseViewO2mPage, O2mPrismModule.Phonebook.PhbkEnterprise.ViewModels.O2mPage.PhbkEnterpriseViewO2mPageViewModel>();
            containerRegistry.RegisterForNavigation<O2mPrismModule.Phonebook.PhbkEnterprise.Views.O2mPage.PhbkEnterpriseViewO2mPage, O2mPrismModule.Phonebook.PhbkEnterprise.ViewModels.O2mPage.PhbkEnterpriseViewO2mPageViewModel>("PhbkEnterpriseViewO2mPage");
            containerRegistry.Register<Xamarin.Forms.ContentPage, O2mPrismModule.Phonebook.PhbkEnterprise.Views.O2mPage.PhbkEnterpriseViewO2mPage>("PhbkEnterpriseViewO2mPage");
        }
    }
}
