using Xamarin.Forms;
using Prism.Regions.Navigation;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;

/*

    "AccessDeniedViewModel" UserControl is defined in the "CommonServicesPrismModule"-project.
    In the file of IModule-class of "CommonServicesPrismModule"-project the following line of code must be inserted:


        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ...

            ViewModelLocationProvider.Register<AccessDeniedUserControl, AccessDeniedViewModel>();
            containerRegistry.Register<ContentView, AccessDeniedUserControl>("AccessDeniedUserControl");
            containerRegistry.RegisterForRegionNavigation<AccessDeniedUserControl, AccessDeniedViewModel>("AccessDeniedUserControl");
            ...
        }

*/

namespace CommonServicesPrismModule.ViewModels {
    public class AccessDeniedViewModel: INotifyPropertyChanged, IRegionAware 
    {
        public AccessDeniedViewModel() {
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion



        protected INavigationContext CurrentNavigationContext = null;

        #region ShowBackBtn
        public bool ShowBackBtn {
            get {
                return (CurrentNavigationContext == null) ?  false : CurrentNavigationContext.NavigationService.Journal.CanGoBack;
            }
        }
        #endregion

        #region IRegionAware
        public bool IsNavigationTarget(INavigationContext navigationContext)
        {
            // CurrentNavigationContext = navigationContext;
            // OnPropertyChanged("ShowBackBtn");
            // (OnNavigationBackCommand as Command).ChangeCanExecute();
            return true;
        }
        public void OnNavigatedFrom(INavigationContext navigationContext)
        {
            CurrentNavigationContext = navigationContext;
            OnPropertyChanged("ShowBackBtn");
            (OnNavigationBackCommand as Command).ChangeCanExecute();
        }
        public void OnNavigatedTo(INavigationContext navigationContext)
        {
            CurrentNavigationContext = navigationContext;
            OnPropertyChanged("ShowBackBtn");
            (OnNavigationBackCommand as Command).ChangeCanExecute();
        }
        #endregion

        #region OnNavigationBackCommand
        protected ICommand _OnNavigationBackCommand = null;
        public ICommand OnNavigationBackCommand
        {
            get
            {
                return _OnNavigationBackCommand ?? (_OnNavigationBackCommand = new Command(() => OnNavigationBackCommandExecute(), () => OnNavigationBackCommandCanExecute()));
            }
        }
        protected void OnNavigationBackCommandExecute()
        {
            if (CurrentNavigationContext != null) {
                if(CurrentNavigationContext.NavigationService.Journal.CanGoBack) {
                    CurrentNavigationContext.NavigationService.Journal.GoBack();
                }
            }
        }
        protected bool OnNavigationBackCommandCanExecute()
        {
            return (CurrentNavigationContext == null) ?  false : CurrentNavigationContext.NavigationService.Journal.CanGoBack;
        }
        #endregion
    }
}

