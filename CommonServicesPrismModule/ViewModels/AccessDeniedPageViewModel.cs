


/*

    "AccessDeniedPageViewModel" UserControl is defined in the "CommonServicesPrismModule"-project.
    In the file of IModule-class of "CommonServicesPrismModule"-project the following line of code must be inserted:


        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ...

            ViewModelLocationProvider.Register<AccessDeniedPage, AccessDeniedPageViewModel>();
            containerRegistry.RegisterForNavigation<AccessDeniedPage, AccessDeniedPageViewModel>("AccessDeniedPage");
            ...
        }

*/

namespace CommonServicesPrismModule.ViewModels {
    public class AccessDeniedPageViewModel 
    {
        public AccessDeniedPageViewModel() {
        }
    }
}

