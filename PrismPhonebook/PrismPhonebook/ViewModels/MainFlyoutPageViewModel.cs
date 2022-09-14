using Xamarin.Forms;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Essentials;
using Prism.Services.Dialogs;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Prism.Ioc;

using CommonInterfacesClassLibrary.AppGlblSettingsSrvc;


namespace PrismPhonebook.ViewModels {
    public class MainFlyoutPageViewModel: INotifyPropertyChanged, IDestructible  
    {
        protected IAppGlblSettingsService _GlblSettingsSrv=null;
        protected INavigationService _navigationService;
        protected IDialogService _dialogService;
        protected IContainerProvider _containerProvider;
        public MainFlyoutPageViewModel(IAppGlblSettingsService GlblSettingsSrv, INavigationService navigationService, IDialogService dialogService, IContainerProvider containerProvider) {
            _GlblSettingsSrv = GlblSettingsSrv;
            _GlblSettingsSrv.OnNavigateToNotification += NavigateTo;
            _GlblSettingsSrv.OnMessageNotification += ShowErrorMessage;
            _GlblSettingsSrv.OnUserChangedNotification += OnUserChangedNotification;
            _navigationService = navigationService;
            _dialogService = dialogService;
            _containerProvider = containerProvider;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        #region NavigateCommand
        protected ICommand _NavigateCommand = null;
        public ICommand NavigateCommand
        {
            get
            {
                return _NavigateCommand ?? (_NavigateCommand = new Command<string>((p) => NavigateCommandExecute(p), (p) => NavigateCommandCanExecute(p)));
            }
        }
        protected async void NavigateCommandExecute(string navPath)
        {
            INavigationService ns = _navigationService;
            IAppGlblSettingsService gss = _GlblSettingsSrv;
            if(gss.CurrNavPath == navPath) return; // static region trows exception if to navigate to the same Feature-Page
                                                   // bindable region names trow exception as well
                                                   // so it's the only way: do not navigate to the same page
            if (ns != null)  {
                //
                //  ns.GoBackToRootAsync();
                //  returns error
                //
                INavigationResult nrslt = await ns.NavigateAsync(name: $"/MainFlyoutPage/NavigationPage/{navPath}");
                if (!nrslt.Success)
                {
                    string msg = "Navigation Error";
                    if (nrslt.Exception != null) msg = ": " + nrslt.Exception.Message;
                    await ns.NavigateAsync(name: $"/MainFlyoutPage/NavigationPage/PageNotFoundPage");
                    if (gss != null) gss.ShowErrorMessage("Navigation Error", msg);
                } else {
                    gss.CurrNavPath = navPath;
                }
            }
        }
        protected bool NavigateCommandCanExecute(string navPath)
        {
            return true;
        }
        #endregion

        #region ShowDialogCommand
        protected ICommand _ShowDialogCommand = null;
        public ICommand ShowDialogCommand
        {
            get
            {
                return _ShowDialogCommand ?? (_ShowDialogCommand = new Command<string>((p) => ShowDialogCommandExecute(p), (p) => ShowDialogCommandCanExecute(p)));
            }
        }
        protected void ShowDialogCommandExecute(string navPath)
        {
            if (string.IsNullOrEmpty(navPath)) return;
            DialogParameters parameters = new DialogParameters();
            _dialogService.ShowDialog(navPath, parameters, (outprm) => { });
        }
        protected bool ShowDialogCommandCanExecute(string navPath)
        {
            return true;
        }
        #endregion

        #region IDestructible  
        public virtual void Destroy()
        {
            if( _GlblSettingsSrv != null ) {
                _GlblSettingsSrv.OnNavigateToNotification -= NavigateTo;
                _GlblSettingsSrv.OnMessageNotification -= ShowErrorMessage;
                _GlblSettingsSrv.OnUserChangedNotification -= OnUserChangedNotification;
            }
            _GlblSettingsSrv = null;
            _navigationService = null;
            _dialogService = null;
        }
        #endregion

        private async void NavigateTo(object sender, string navPath)
        {
            INavigationService ns = _navigationService;
            IAppGlblSettingsService gss = _GlblSettingsSrv;
            if (ns != null) {
                await MainThread.InvokeOnMainThreadAsync(async () => {
                    //
                    // next line returns (Success == false)
                    // await ns.GoBackToRootAsync();
                    //
                    INavigationResult nrslt = await ns.NavigateAsync(name: $"/MainFlyoutPage/NavigationPage/{navPath}");
                    if (!nrslt.Success)
                    {
                        string msg = "Navigation Error";
                        if (nrslt.Exception != null) msg = ": " + nrslt.Exception.Message;
                        await ns.NavigateAsync(name: $"/MainFlyoutPage/NavigationPage/PageNotFoundPage");
                        if (gss != null) gss.ShowErrorMessage("Navigation Error", msg);
                    }
                });
            }
        }
        private void ShowErrorMessage(object sender, string errorMessage)
        {
            IAppGlblSettingsService gss = _GlblSettingsSrv;
            if (gss == null) return;
            if (gss.DelayActivated) return;
            gss.DelayActivated = true;
            MainThread.BeginInvokeOnMainThread(() => {
                DialogParameters parameters = new DialogParameters();
                parameters.Add("Title", "Error");
                parameters.Add("Message", errorMessage);
                parameters.Add("DelayFromMilliseconds", 4000);
                if(_dialogService != null) _dialogService.ShowDialog("MessageDlg", parameters, (r) => { gss.DelayActivated = false; });
            });
        }
        private async void OnUserChangedNotification(object sender, string uname)
        {
            
            /* Uncomment to turn ON Authorization 
            if (string.IsNullOrEmpty(uname))
            {
                (sender as IAppGlblSettingsService).Permissions = (sender as IAppGlblSettingsService).GetEmptyPermissions();
                (sender as IAppGlblSettingsService).NavigateTo("HomePage");
                return;
            }
            else
            {
                IAspnetusermaskViewServicePermission ServicePermission = _containerProvider.Resolve<IAspnetusermaskViewServicePermission>();
                await MainThread.InvokeOnMainThreadAsync(async () => 
                {
                    IaspnetusermaskViewPage rslt = await ServicePermission.getcurrusermasks();
                    (sender as IAppGlblSettingsService).Permissions = ServicePermission.src2array(rslt);
                    (sender as IAppGlblSettingsService).NavigateTo("HomePage");
                });
                return;
            }
            */ 
            (sender as IAppGlblSettingsService).NavigateTo("HomePage");
        }
    }
}

