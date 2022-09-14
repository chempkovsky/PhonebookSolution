
using System;
using Xamarin.Forms;
using System.ComponentModel;
using System.Windows.Input;
using Prism.Navigation;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Net.Http.Headers;
using CommonInterfacesClassLibrary.AppGlblLoginSrvc;
using CommonInterfacesClassLibrary.Interfaces;
using CommonInterfacesClassLibrary.AppGlblSettingsSrvc;

/*

    "LogoutUserPageViewModel" UserControl is defined in the "CommonServicesPrismModule"-project.
    In the file of IModule-class of "CommonServicesPrismModule"-project the following line of code must be inserted:


        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ...

            ViewModelLocationProvider.Register<LogoutUserPage, LogoutUserPageViewModel>();
            containerRegistry.RegisterForNavigation<LogoutUserPage, LogoutUserPageViewModel>("LogoutUserPage");
            ...
        }

*/

namespace CommonServicesPrismModule.ViewModels {
    public class LogoutUserPageViewModel: INotifyPropertyChanged
    {
        IAppGlblSettingsService _GlblSettingsSrv;
        IAppGlblLoginService _GlblLoginSrv;
        protected INavigationService _navigationService;
        public LogoutUserPageViewModel(IAppGlblLoginService GlblLoginSrv, IAppGlblSettingsService GlblSettingsSrv, INavigationService navigationService) {
            _GlblLoginSrv = GlblLoginSrv;
            _GlblSettingsSrv = GlblSettingsSrv;
            _navigationService = navigationService;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion
        #region CancelCommand
        private ICommand _CancelCommand;
        public ICommand CancelCommand
        {
            get
            {
                return _CancelCommand ?? (_CancelCommand = new Command((param) => CancelCommandAction(param), (param) => CancelCommandCanExecute(param)));
            }
        }
        protected async void CancelCommandAction(object param)
        {
            if(_GlblSettingsSrv != null) {
                _GlblSettingsSrv.NavigateTo("HomePage");
            }
        }
        protected bool CancelCommandCanExecute(object param)
        {
            return true;
        }
        #endregion
        #region OkCommand
        private ICommand _OkCommand;
        public ICommand OkCommand
        {
            get
            {
                return _OkCommand ?? (_OkCommand = new Command((param) => OkCommandAction(param), (param) => OkCommandCanExecute(param)));
            }
        }
        protected async void OkCommandAction(object param)
        {
            bool model = await _GlblLoginSrv.Logout();
            if (!model) return;
            if(_GlblSettingsSrv != null) {
                _GlblSettingsSrv.AuthInfo = null;
                _GlblSettingsSrv.Client.DefaultRequestHeaders.Authorization = null;
                // this line must be the last. It activates notification
                _GlblSettingsSrv.UserName = null;

                // this line was used at development time
                // _GlblSettingsSrv.NavigateTo("HomePage");
            }
        }
        protected bool OkCommandCanExecute(object param)
        {
            return true;
        }
        #endregion

        #region IDestructible  
        public virtual void Destroy()
        {
            _GlblSettingsSrv = null;
            _GlblLoginSrv = null;
        }
        #endregion

    }
}

