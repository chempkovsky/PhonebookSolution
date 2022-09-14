


/*

    "PageNotFoundPageViewModel" UserControl is defined in the "CommonServicesPrismModule"-project.
    In the file of IModule-class of "CommonServicesPrismModule"-project the following line of code must be inserted:


        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ...

            ViewModelLocationProvider.Register<PageNotFoundPage, PageNotFoundPageViewModel>();
            containerRegistry.RegisterForNavigation<PageNotFoundPage, PageNotFoundPageViewModel>("PageNotFoundPage");
            ...
        }

*/

namespace CommonServicesPrismModule.ViewModels {
    public class PageNotFoundPageViewModel 
    {
        public PageNotFoundPageViewModel() {
        }
    }
}

