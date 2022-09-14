


/*

    "HomePageViewModel" UserControl is defined in the "CommonServicesPrismModule"-project.
    In the file of IModule-class of "CommonServicesPrismModule"-project the following line of code must be inserted:


        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ...

            ViewModelLocationProvider.Register<HomePage, HomePageViewModel>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>("HomePage");
            ...
        }

*/

namespace CommonServicesPrismModule.ViewModels {
    public class HomePageViewModel 
    {
        public HomePageViewModel() {
        }
    }
}

