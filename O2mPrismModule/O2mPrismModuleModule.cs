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
            Prism.Mvvm.ViewModelLocationProvider.Register<O2mPrismModule.Phonebook.PhbkEnterprise.UserControls.PhbkEnterpriseViewO2mUserControl, O2mPrismModule.Phonebook.PhbkEnterprise.ViewModels.PhbkEnterpriseViewO2mViewModel>();
            containerRegistry.RegisterForRegionNavigation<O2mPrismModule.Phonebook.PhbkEnterprise.UserControls.PhbkEnterpriseViewO2mUserControl, O2mPrismModule.Phonebook.PhbkEnterprise.ViewModels.PhbkEnterpriseViewO2mViewModel>("PhbkEnterpriseViewO2mUserControl");
            containerRegistry.Register<Xamarin.Forms.ContentView, O2mPrismModule.Phonebook.PhbkEnterprise.UserControls.PhbkEnterpriseViewO2mUserControl>("PhbkEnterpriseViewO2mUserControl");
            Prism.Mvvm.ViewModelLocationProvider.Register<O2mPrismModule.Phonebook.PhbkEnterprise.Views.PhbkEnterpriseViewO2mPage, O2mPrismModule.Phonebook.PhbkEnterprise.ViewModels.PhbkEnterpriseViewO2mPageViewModel>();
            containerRegistry.RegisterForNavigation<O2mPrismModule.Phonebook.PhbkEnterprise.Views.PhbkEnterpriseViewO2mPage, O2mPrismModule.Phonebook.PhbkEnterprise.ViewModels.PhbkEnterpriseViewO2mPageViewModel>("PhbkEnterpriseViewO2mPage");
            containerRegistry.Register<Xamarin.Forms.ContentPage, O2mPrismModule.Phonebook.PhbkEnterprise.Views.PhbkEnterpriseViewO2mPage>("PhbkEnterpriseViewO2mPage");
            Prism.Mvvm.ViewModelLocationProvider.Register<O2mPrismModule.Phonebook.PhbkEmployee.UserControls.PhbkEmployeeViewO2mUserControl, O2mPrismModule.Phonebook.PhbkEmployee.ViewModels.PhbkEmployeeViewO2mViewModel>();
            containerRegistry.RegisterForRegionNavigation<O2mPrismModule.Phonebook.PhbkEmployee.UserControls.PhbkEmployeeViewO2mUserControl, O2mPrismModule.Phonebook.PhbkEmployee.ViewModels.PhbkEmployeeViewO2mViewModel>("PhbkEmployeeViewO2mUserControl");
            containerRegistry.Register<Xamarin.Forms.ContentView, O2mPrismModule.Phonebook.PhbkEmployee.UserControls.PhbkEmployeeViewO2mUserControl>("PhbkEmployeeViewO2mUserControl");
            Prism.Mvvm.ViewModelLocationProvider.Register<O2mPrismModule.Phonebook.PhbkEmployee.Views.PhbkEmployeeViewO2mPage, O2mPrismModule.Phonebook.PhbkEmployee.ViewModels.PhbkEmployeeViewO2mPageViewModel>();
            containerRegistry.RegisterForNavigation<O2mPrismModule.Phonebook.PhbkEmployee.Views.PhbkEmployeeViewO2mPage, O2mPrismModule.Phonebook.PhbkEmployee.ViewModels.PhbkEmployeeViewO2mPageViewModel>("PhbkEmployeeViewO2mPage");
            containerRegistry.Register<Xamarin.Forms.ContentPage, O2mPrismModule.Phonebook.PhbkEmployee.Views.PhbkEmployeeViewO2mPage>("PhbkEmployeeViewO2mPage");
        }
    }
}
