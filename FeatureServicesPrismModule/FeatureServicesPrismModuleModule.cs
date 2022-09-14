using Prism.Ioc;
using Prism.Modularity;

namespace FeatureServicesPrismModule
{
    public class FeatureServicesPrismModuleModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

            Prism.Mvvm.ViewModelLocationProvider.Register<FeatureServicesPrismModule.Phonebook.O2m.O2mFeatureFtrUserControl, FeatureServicesPrismModule.Phonebook.O2m.O2mFeatureFtrViewModel>();
            containerRegistry.RegisterForNavigation<FeatureServicesPrismModule.Phonebook.O2m.O2mFeatureFtrUserControl, FeatureServicesPrismModule.Phonebook.O2m.O2mFeatureFtrViewModel>("O2mFeatureFtrUserControl");
            Prism.Mvvm.ViewModelLocationProvider.Register<FeatureServicesPrismModule.Phonebook.RLists.RListsFeatureFtrUserControl, FeatureServicesPrismModule.Phonebook.RLists.RListsFeatureFtrViewModel>();
            containerRegistry.RegisterForNavigation<FeatureServicesPrismModule.Phonebook.RLists.RListsFeatureFtrUserControl, FeatureServicesPrismModule.Phonebook.RLists.RListsFeatureFtrViewModel>("RListsFeatureFtrUserControl");
            Prism.Mvvm.ViewModelLocationProvider.Register<FeatureServicesPrismModule.Phonebook.RdLists.RdListsFeatureFtrUserControl, FeatureServicesPrismModule.Phonebook.RdLists.RdListsFeatureFtrViewModel>();
            containerRegistry.RegisterForNavigation<FeatureServicesPrismModule.Phonebook.RdLists.RdListsFeatureFtrUserControl, FeatureServicesPrismModule.Phonebook.RdLists.RdListsFeatureFtrViewModel>("RdListsFeatureFtrUserControl");
            Prism.Mvvm.ViewModelLocationProvider.Register<FeatureServicesPrismModule.Phonebook.Lforms.LformsFeatureFtrUserControl, FeatureServicesPrismModule.Phonebook.Lforms.LformsFeatureFtrViewModel>();
            containerRegistry.RegisterForNavigation<FeatureServicesPrismModule.Phonebook.Lforms.LformsFeatureFtrUserControl, FeatureServicesPrismModule.Phonebook.Lforms.LformsFeatureFtrViewModel>("LformsFeatureFtrUserControl");
        }
    }
}
