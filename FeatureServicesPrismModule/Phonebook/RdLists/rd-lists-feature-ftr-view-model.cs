using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Prism.Ioc;
using Prism.Regions;
using Prism.Navigation;
using System.Windows.Input;
using Prism.Regions.Navigation;
using Xamarin.Essentials;
using System.Threading.Tasks;

using CommonInterfacesClassLibrary.Interfaces;
using CommonUserControlLibrary.Classes;
using CommonInterfacesClassLibrary.AppGlblSettingsSrvc;
using CommonCustomControlLibrary.Fonts;

/*

    "RdListsFeatureFtrViewModel" UserControl is defined in the "FeatureServicesPrismModule"-project.
    In the file of IModule-class of "FeatureServicesPrismModule"-project the following line of code must be inserted:

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ...
            // According to requirements of the "RdListsFeatureFtrViewModel.cs"-file of "FeatureServicesPrismModule"-project. 
            ViewModelLocationProvider.Register<RdListsFeatureFtrUserControl, RdListsFeatureFtrViewModel>();
            // According to requirements of the "RdListsFeatureFtrViewModel.cs"-file of "FeatureServicesPrismModule"-project. 
            containerRegistry.RegisterForNavigation<RdListsFeatureFtrUserControl, RdListsFeatureFtrViewModel>("RdListsFeatureFtrUserControl");
            ...
        }

*/

namespace FeatureServicesPrismModule.Phonebook.RdLists {
    public class RdListsFeatureFtrViewModel : INotifyPropertyChanged, INavigationAware, IDestructible 
    {
        IRegionManager _regionManager;
        IContainerProvider _containerProvider;
        protected IAppGlblSettingsService _GlblSettingsSrv;
        public RdListsFeatureFtrViewModel(IAppGlblSettingsService GlblSettingsSrv, IRegionManager regionManager, IContainerProvider containerProvider) {
            _regionManager = regionManager;
            _containerProvider = containerProvider;
            _GlblSettingsSrv = GlblSettingsSrv;

            _ContainerMenuItemsPhbkPhoneTypeViewRdlistUserControl = 
                new ObservableCollection<IWebServiceFilterMenuInterface>() {
                    new WebServiceFilterMenu() { Id = "0", Caption="Expand(Collapse)", IconName=IconFont.Aspect_ratio,  IconColor= (Color)Application.Current.Resources["IconButtonPrimaryColor"], Enabled=true, Data="PhbkPhoneTypeViewRdlistUserControl", Command = OnContainerMenuItemsCommand },
                };
            _FilterHeightPhbkPhoneTypeViewRdlistUserControl = _GlblSettingsSrv.DefaultFilterHeight("02018-RdlistUserControl.xaml");
            _GridHeightPhbkPhoneTypeViewRdlistUserControl = _GlblSettingsSrv.DefaultGridHeight("02018-RdlistUserControl.xaml");
            //_FilterHeightPhbkPhoneTypeViewRdlistUserControl = 1 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
            //_GridHeightPhbkPhoneTypeViewRdlistUserControl = 6 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;

            _ContainerMenuItemsPhbkEnterpriseViewRdlistUserControl = 
                new ObservableCollection<IWebServiceFilterMenuInterface>() {
                    new WebServiceFilterMenu() { Id = "1", Caption="Expand(Collapse)", IconName=IconFont.Aspect_ratio,  IconColor= (Color)Application.Current.Resources["IconButtonPrimaryColor"], Enabled=true, Data="PhbkEnterpriseViewRdlistUserControl", Command = OnContainerMenuItemsCommand },
                };
            _FilterHeightPhbkEnterpriseViewRdlistUserControl = _GlblSettingsSrv.DefaultFilterHeight("02018-RdlistUserControl.xaml");
            _GridHeightPhbkEnterpriseViewRdlistUserControl = _GlblSettingsSrv.DefaultGridHeight("02018-RdlistUserControl.xaml");
            //_FilterHeightPhbkEnterpriseViewRdlistUserControl = 1 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
            //_GridHeightPhbkEnterpriseViewRdlistUserControl = 6 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;

            _ContainerMenuItemsPhbkDivisionViewRdlistUserControl = 
                new ObservableCollection<IWebServiceFilterMenuInterface>() {
                    new WebServiceFilterMenu() { Id = "2", Caption="Expand(Collapse)", IconName=IconFont.Aspect_ratio,  IconColor= (Color)Application.Current.Resources["IconButtonPrimaryColor"], Enabled=true, Data="PhbkDivisionViewRdlistUserControl", Command = OnContainerMenuItemsCommand },
                };
            _FilterHeightPhbkDivisionViewRdlistUserControl = _GlblSettingsSrv.DefaultFilterHeight("02018-RdlistUserControl.xaml");
            _GridHeightPhbkDivisionViewRdlistUserControl = _GlblSettingsSrv.DefaultGridHeight("02018-RdlistUserControl.xaml");
            //_FilterHeightPhbkDivisionViewRdlistUserControl = 1 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
            //_GridHeightPhbkDivisionViewRdlistUserControl = 6 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;

            _ContainerMenuItemsPhbkEmployeeViewRdlistUserControl = 
                new ObservableCollection<IWebServiceFilterMenuInterface>() {
                    new WebServiceFilterMenu() { Id = "3", Caption="Expand(Collapse)", IconName=IconFont.Aspect_ratio,  IconColor= (Color)Application.Current.Resources["IconButtonPrimaryColor"], Enabled=true, Data="PhbkEmployeeViewRdlistUserControl", Command = OnContainerMenuItemsCommand },
                };
            _FilterHeightPhbkEmployeeViewRdlistUserControl = _GlblSettingsSrv.DefaultFilterHeight("02018-RdlistUserControl.xaml");
            _GridHeightPhbkEmployeeViewRdlistUserControl = _GlblSettingsSrv.DefaultGridHeight("02018-RdlistUserControl.xaml");
            //_FilterHeightPhbkEmployeeViewRdlistUserControl = 1 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
            //_GridHeightPhbkEmployeeViewRdlistUserControl = 6 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;

            _ContainerMenuItemsPhbkPhoneViewRdlistUserControl = 
                new ObservableCollection<IWebServiceFilterMenuInterface>() {
                    new WebServiceFilterMenu() { Id = "4", Caption="Expand(Collapse)", IconName=IconFont.Aspect_ratio,  IconColor= (Color)Application.Current.Resources["IconButtonPrimaryColor"], Enabled=true, Data="PhbkPhoneViewRdlistUserControl", Command = OnContainerMenuItemsCommand },
                };
            _FilterHeightPhbkPhoneViewRdlistUserControl = _GlblSettingsSrv.DefaultFilterHeight("02018-RdlistUserControl.xaml");
            _GridHeightPhbkPhoneViewRdlistUserControl = _GlblSettingsSrv.DefaultGridHeight("02018-RdlistUserControl.xaml");
            //_FilterHeightPhbkPhoneViewRdlistUserControl = 1 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
            //_GridHeightPhbkPhoneViewRdlistUserControl = 6 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;

        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        #region INavigationAware
        public void OnNavigatedFrom(INavigationParameters parameters) {
        }
        public void OnNavigatedTo(INavigationParameters parameters) {
            if(!IsOnLoadedCalled) OnLoaded();
        }
        #endregion
        #region OnNavigationResult
        protected void OnNavigationResult(IRegionNavigationResult navResult) {
                if(IsDestroyed) return;
                if(navResult.Result.HasValue) { if(navResult.Result.Value) return; }
                string navErrorMsg = "Unknown Navigation Error";
                if (navResult.Error != null)
                {
                    navErrorMsg = navResult.Error.Message;
                    Exception inner = navResult.Error.InnerException;
                    while (inner != null)
                    {
                        navErrorMsg = navErrorMsg + ": " + inner.Message;
                        inner = inner.InnerException;
                    }
                }
                navResult.Context.NavigationService.RequestNavigate(new Uri("PageNotFoundUserControl", UriKind.Relative));
                _GlblSettingsSrv.ShowErrorMessage("Navigation Exception", navErrorMsg);
        }
        #endregion
        #region OnLoaded
        protected bool IsOnLoadedCalled = false;
        private async void OnLoaded()
        {
            if(IsDestroyed) return;
            if (!IsOnLoadedCalled)
            {
                IsOnLoadedCalled = true;
                ContentView uc = null;
                IRegionManager rm = null;
                // INotifiedByParentInterface nbp = null;
                //suc = _containerProvider.Resolve<IScopedRegionNavigationUserControlInterface>();
                //suc.ScopedRegionManager = _regionManager.Regions["PhbkPhoneTypeViewRdlistUserControlRdListsFeatureFtrUserControl"].Add(suc, null, true);
                //suc.RequestNavigateSource = "PhbkPhoneTypeViewRdlistUserControl";
                //_regionManager.Regions["PhbkPhoneTypeViewRdlistUserControlRdListsFeatureFtrUserControl"].Activate(suc);
                await Device.InvokeOnMainThreadAsync(async () =>
                {
                    _regionManager.RequestNavigate("PhbkPhoneTypeViewRdlistUserControlRdListsFeatureFtrUserControl", "PhbkPhoneTypeViewRdlistUserControl", OnNavigationResult);
                    IsSwitching = true;
                    await Task.Delay(1);
                    IsSwitching = false;
                });
                //suc = _containerProvider.Resolve<IScopedRegionNavigationUserControlInterface>();
                //suc.ScopedRegionManager = _regionManager.Regions["PhbkEnterpriseViewRdlistUserControlRdListsFeatureFtrUserControl"].Add(suc, null, true);
                //suc.RequestNavigateSource = "PhbkEnterpriseViewRdlistUserControl";
                //_regionManager.Regions["PhbkEnterpriseViewRdlistUserControlRdListsFeatureFtrUserControl"].Activate(suc);
                await Device.InvokeOnMainThreadAsync(async () =>
                {
                    _regionManager.RequestNavigate("PhbkEnterpriseViewRdlistUserControlRdListsFeatureFtrUserControl", "PhbkEnterpriseViewRdlistUserControl", OnNavigationResult);
                    IsSwitching = true;
                    await Task.Delay(1);
                    IsSwitching = false;
                });
                //suc = _containerProvider.Resolve<IScopedRegionNavigationUserControlInterface>();
                //suc.ScopedRegionManager = _regionManager.Regions["PhbkDivisionViewRdlistUserControlRdListsFeatureFtrUserControl"].Add(suc, null, true);
                //suc.RequestNavigateSource = "PhbkDivisionViewRdlistUserControl";
                //_regionManager.Regions["PhbkDivisionViewRdlistUserControlRdListsFeatureFtrUserControl"].Activate(suc);
                await Device.InvokeOnMainThreadAsync(async () =>
                {
                    _regionManager.RequestNavigate("PhbkDivisionViewRdlistUserControlRdListsFeatureFtrUserControl", "PhbkDivisionViewRdlistUserControl", OnNavigationResult);
                    IsSwitching = true;
                    await Task.Delay(1);
                    IsSwitching = false;
                });
                //suc = _containerProvider.Resolve<IScopedRegionNavigationUserControlInterface>();
                //suc.ScopedRegionManager = _regionManager.Regions["PhbkEmployeeViewRdlistUserControlRdListsFeatureFtrUserControl"].Add(suc, null, true);
                //suc.RequestNavigateSource = "PhbkEmployeeViewRdlistUserControl";
                //_regionManager.Regions["PhbkEmployeeViewRdlistUserControlRdListsFeatureFtrUserControl"].Activate(suc);
                await Device.InvokeOnMainThreadAsync(async () =>
                {
                    _regionManager.RequestNavigate("PhbkEmployeeViewRdlistUserControlRdListsFeatureFtrUserControl", "PhbkEmployeeViewRdlistUserControl", OnNavigationResult);
                    IsSwitching = true;
                    await Task.Delay(1);
                    IsSwitching = false;
                });
                //suc = _containerProvider.Resolve<IScopedRegionNavigationUserControlInterface>();
                //suc.ScopedRegionManager = _regionManager.Regions["PhbkPhoneViewRdlistUserControlRdListsFeatureFtrUserControl"].Add(suc, null, true);
                //suc.RequestNavigateSource = "PhbkPhoneViewRdlistUserControl";
                //_regionManager.Regions["PhbkPhoneViewRdlistUserControlRdListsFeatureFtrUserControl"].Activate(suc);
                await Device.InvokeOnMainThreadAsync(async () =>
                {
                    _regionManager.RequestNavigate("PhbkPhoneViewRdlistUserControlRdListsFeatureFtrUserControl", "PhbkPhoneViewRdlistUserControl", OnNavigationResult);
                    IsSwitching = true;
                    await Task.Delay(1);
                    IsSwitching = false;
                });
            }
        }
        #endregion
        

        protected bool _IsSwitching = false;
        public bool IsSwitching
        {
            get { return _IsSwitching; }
            set {
                if (_IsSwitching != value)
                {
                    _IsSwitching = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool FlexOn 
        {
            get 
            {
                if(IsDestroyed) return false;
                return true
                  && _VisiblePhbkPhoneTypeViewRdlistUserControl
                  && _VisiblePhbkEnterpriseViewRdlistUserControl
                  && _VisiblePhbkDivisionViewRdlistUserControl
                  && _VisiblePhbkEmployeeViewRdlistUserControl
                  && _VisiblePhbkPhoneViewRdlistUserControl
                ;
            }
        }
        protected bool _VisiblePhbkPhoneTypeViewRdlistUserControl = true;
        public bool VisiblePhbkPhoneTypeViewRdlistUserControl
        {
            get
            {
                return _VisiblePhbkPhoneTypeViewRdlistUserControl;
            }
            set
            {
                if (_VisiblePhbkPhoneTypeViewRdlistUserControl != value)
                {
                    _VisiblePhbkPhoneTypeViewRdlistUserControl = value;
                    OnPropertyChanged();
                    OnPropertyChanged("FlexOn");
                }
            }
        }

        protected IEnumerable<IWebServiceFilterMenuInterface> _ContainerMenuItemsPhbkPhoneTypeViewRdlistUserControl = null;
        public IEnumerable<IWebServiceFilterMenuInterface> ContainerMenuItemsPhbkPhoneTypeViewRdlistUserControl {
            get { return _ContainerMenuItemsPhbkPhoneTypeViewRdlistUserControl; }
        }

        protected double _FilterHeightPhbkPhoneTypeViewRdlistUserControl = -1d;
        public  double FilterHeightPhbkPhoneTypeViewRdlistUserControl 
        {
            get { return _FilterHeightPhbkPhoneTypeViewRdlistUserControl; }
            set 
            {
                if(_FilterHeightPhbkPhoneTypeViewRdlistUserControl != value) {
                    _FilterHeightPhbkPhoneTypeViewRdlistUserControl = value;
                    OnPropertyChanged();
                }
            }
        }

        protected double _GridHeightPhbkPhoneTypeViewRdlistUserControl = -1d;
        public  double GridHeightPhbkPhoneTypeViewRdlistUserControl 
        {
            get { return _GridHeightPhbkPhoneTypeViewRdlistUserControl; }
            set 
            {
                if(_GridHeightPhbkPhoneTypeViewRdlistUserControl != value) {
                    _GridHeightPhbkPhoneTypeViewRdlistUserControl = value;
                    OnPropertyChanged();
                }
            }
        }

        protected bool _VisiblePhbkEnterpriseViewRdlistUserControl = true;
        public bool VisiblePhbkEnterpriseViewRdlistUserControl
        {
            get
            {
                return _VisiblePhbkEnterpriseViewRdlistUserControl;
            }
            set
            {
                if (_VisiblePhbkEnterpriseViewRdlistUserControl != value)
                {
                    _VisiblePhbkEnterpriseViewRdlistUserControl = value;
                    OnPropertyChanged();
                    OnPropertyChanged("FlexOn");
                }
            }
        }

        protected IEnumerable<IWebServiceFilterMenuInterface> _ContainerMenuItemsPhbkEnterpriseViewRdlistUserControl = null;
        public IEnumerable<IWebServiceFilterMenuInterface> ContainerMenuItemsPhbkEnterpriseViewRdlistUserControl {
            get { return _ContainerMenuItemsPhbkEnterpriseViewRdlistUserControl; }
        }

        protected double _FilterHeightPhbkEnterpriseViewRdlistUserControl = -1d;
        public  double FilterHeightPhbkEnterpriseViewRdlistUserControl 
        {
            get { return _FilterHeightPhbkEnterpriseViewRdlistUserControl; }
            set 
            {
                if(_FilterHeightPhbkEnterpriseViewRdlistUserControl != value) {
                    _FilterHeightPhbkEnterpriseViewRdlistUserControl = value;
                    OnPropertyChanged();
                }
            }
        }

        protected double _GridHeightPhbkEnterpriseViewRdlistUserControl = -1d;
        public  double GridHeightPhbkEnterpriseViewRdlistUserControl 
        {
            get { return _GridHeightPhbkEnterpriseViewRdlistUserControl; }
            set 
            {
                if(_GridHeightPhbkEnterpriseViewRdlistUserControl != value) {
                    _GridHeightPhbkEnterpriseViewRdlistUserControl = value;
                    OnPropertyChanged();
                }
            }
        }

        protected bool _VisiblePhbkDivisionViewRdlistUserControl = true;
        public bool VisiblePhbkDivisionViewRdlistUserControl
        {
            get
            {
                return _VisiblePhbkDivisionViewRdlistUserControl;
            }
            set
            {
                if (_VisiblePhbkDivisionViewRdlistUserControl != value)
                {
                    _VisiblePhbkDivisionViewRdlistUserControl = value;
                    OnPropertyChanged();
                    OnPropertyChanged("FlexOn");
                }
            }
        }

        protected IEnumerable<IWebServiceFilterMenuInterface> _ContainerMenuItemsPhbkDivisionViewRdlistUserControl = null;
        public IEnumerable<IWebServiceFilterMenuInterface> ContainerMenuItemsPhbkDivisionViewRdlistUserControl {
            get { return _ContainerMenuItemsPhbkDivisionViewRdlistUserControl; }
        }

        protected double _FilterHeightPhbkDivisionViewRdlistUserControl = -1d;
        public  double FilterHeightPhbkDivisionViewRdlistUserControl 
        {
            get { return _FilterHeightPhbkDivisionViewRdlistUserControl; }
            set 
            {
                if(_FilterHeightPhbkDivisionViewRdlistUserControl != value) {
                    _FilterHeightPhbkDivisionViewRdlistUserControl = value;
                    OnPropertyChanged();
                }
            }
        }

        protected double _GridHeightPhbkDivisionViewRdlistUserControl = -1d;
        public  double GridHeightPhbkDivisionViewRdlistUserControl 
        {
            get { return _GridHeightPhbkDivisionViewRdlistUserControl; }
            set 
            {
                if(_GridHeightPhbkDivisionViewRdlistUserControl != value) {
                    _GridHeightPhbkDivisionViewRdlistUserControl = value;
                    OnPropertyChanged();
                }
            }
        }

        protected bool _VisiblePhbkEmployeeViewRdlistUserControl = true;
        public bool VisiblePhbkEmployeeViewRdlistUserControl
        {
            get
            {
                return _VisiblePhbkEmployeeViewRdlistUserControl;
            }
            set
            {
                if (_VisiblePhbkEmployeeViewRdlistUserControl != value)
                {
                    _VisiblePhbkEmployeeViewRdlistUserControl = value;
                    OnPropertyChanged();
                    OnPropertyChanged("FlexOn");
                }
            }
        }

        protected IEnumerable<IWebServiceFilterMenuInterface> _ContainerMenuItemsPhbkEmployeeViewRdlistUserControl = null;
        public IEnumerable<IWebServiceFilterMenuInterface> ContainerMenuItemsPhbkEmployeeViewRdlistUserControl {
            get { return _ContainerMenuItemsPhbkEmployeeViewRdlistUserControl; }
        }

        protected double _FilterHeightPhbkEmployeeViewRdlistUserControl = -1d;
        public  double FilterHeightPhbkEmployeeViewRdlistUserControl 
        {
            get { return _FilterHeightPhbkEmployeeViewRdlistUserControl; }
            set 
            {
                if(_FilterHeightPhbkEmployeeViewRdlistUserControl != value) {
                    _FilterHeightPhbkEmployeeViewRdlistUserControl = value;
                    OnPropertyChanged();
                }
            }
        }

        protected double _GridHeightPhbkEmployeeViewRdlistUserControl = -1d;
        public  double GridHeightPhbkEmployeeViewRdlistUserControl 
        {
            get { return _GridHeightPhbkEmployeeViewRdlistUserControl; }
            set 
            {
                if(_GridHeightPhbkEmployeeViewRdlistUserControl != value) {
                    _GridHeightPhbkEmployeeViewRdlistUserControl = value;
                    OnPropertyChanged();
                }
            }
        }

        protected bool _VisiblePhbkPhoneViewRdlistUserControl = true;
        public bool VisiblePhbkPhoneViewRdlistUserControl
        {
            get
            {
                return _VisiblePhbkPhoneViewRdlistUserControl;
            }
            set
            {
                if (_VisiblePhbkPhoneViewRdlistUserControl != value)
                {
                    _VisiblePhbkPhoneViewRdlistUserControl = value;
                    OnPropertyChanged();
                    OnPropertyChanged("FlexOn");
                }
            }
        }

        protected IEnumerable<IWebServiceFilterMenuInterface> _ContainerMenuItemsPhbkPhoneViewRdlistUserControl = null;
        public IEnumerable<IWebServiceFilterMenuInterface> ContainerMenuItemsPhbkPhoneViewRdlistUserControl {
            get { return _ContainerMenuItemsPhbkPhoneViewRdlistUserControl; }
        }

        protected double _FilterHeightPhbkPhoneViewRdlistUserControl = -1d;
        public  double FilterHeightPhbkPhoneViewRdlistUserControl 
        {
            get { return _FilterHeightPhbkPhoneViewRdlistUserControl; }
            set 
            {
                if(_FilterHeightPhbkPhoneViewRdlistUserControl != value) {
                    _FilterHeightPhbkPhoneViewRdlistUserControl = value;
                    OnPropertyChanged();
                }
            }
        }

        protected double _GridHeightPhbkPhoneViewRdlistUserControl = -1d;
        public  double GridHeightPhbkPhoneViewRdlistUserControl 
        {
            get { return _GridHeightPhbkPhoneViewRdlistUserControl; }
            set 
            {
                if(_GridHeightPhbkPhoneViewRdlistUserControl != value) {
                    _GridHeightPhbkPhoneViewRdlistUserControl = value;
                    OnPropertyChanged();
                }
            }
        }

        #region OnContainerMenuItemsCommand
        private ICommand _OnContainerMenuItemsCommand;
        public ICommand OnContainerMenuItemsCommand
        {
            get
            {
                return _OnContainerMenuItemsCommand ?? (_OnContainerMenuItemsCommand = new Command((param) => OnContainerMenuItemsCommandAction(param), (param) => OnContainerMenuItemsCommandCanExecute(param)));
            }
        }

        protected async void OnContainerMenuItemsCommandAction(object prm) {
            if(IsDestroyed) return;
            IWebServiceFilterMenuInterface mi = prm as IWebServiceFilterMenuInterface;
            if (mi == null) return;
            await Device.InvokeOnMainThreadAsync(async () =>
            {
                IsSwitching = true;
                await Task.Delay(1);
            });

            string modelName = mi.Data as string;
            if (string.IsNullOrEmpty(modelName)) return;
            bool IsAllCollapsed = FlexOn;
            _VisiblePhbkPhoneTypeViewRdlistUserControl = !IsAllCollapsed; OnPropertyChanged("VisiblePhbkPhoneTypeViewRdlistUserControl");
            FilterHeightPhbkPhoneTypeViewRdlistUserControl = _GlblSettingsSrv.DefaultFilterHeight("02018-RdlistUserControl.xaml");
                // 1 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
            GridHeightPhbkPhoneTypeViewRdlistUserControl = _GlblSettingsSrv.DefaultGridHeight("02018-RdlistUserControl.xaml");
                // 6 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;
            _VisiblePhbkEnterpriseViewRdlistUserControl = !IsAllCollapsed; OnPropertyChanged("VisiblePhbkEnterpriseViewRdlistUserControl");
            FilterHeightPhbkEnterpriseViewRdlistUserControl = _GlblSettingsSrv.DefaultFilterHeight("02018-RdlistUserControl.xaml");
                // 1 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
            GridHeightPhbkEnterpriseViewRdlistUserControl = _GlblSettingsSrv.DefaultGridHeight("02018-RdlistUserControl.xaml");
                // 6 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;
            _VisiblePhbkDivisionViewRdlistUserControl = !IsAllCollapsed; OnPropertyChanged("VisiblePhbkDivisionViewRdlistUserControl");
            FilterHeightPhbkDivisionViewRdlistUserControl = _GlblSettingsSrv.DefaultFilterHeight("02018-RdlistUserControl.xaml");
                // 1 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
            GridHeightPhbkDivisionViewRdlistUserControl = _GlblSettingsSrv.DefaultGridHeight("02018-RdlistUserControl.xaml");
                // 6 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;
            _VisiblePhbkEmployeeViewRdlistUserControl = !IsAllCollapsed; OnPropertyChanged("VisiblePhbkEmployeeViewRdlistUserControl");
            FilterHeightPhbkEmployeeViewRdlistUserControl = _GlblSettingsSrv.DefaultFilterHeight("02018-RdlistUserControl.xaml");
                // 1 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
            GridHeightPhbkEmployeeViewRdlistUserControl = _GlblSettingsSrv.DefaultGridHeight("02018-RdlistUserControl.xaml");
                // 6 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;
            _VisiblePhbkPhoneViewRdlistUserControl = !IsAllCollapsed; OnPropertyChanged("VisiblePhbkPhoneViewRdlistUserControl");
            FilterHeightPhbkPhoneViewRdlistUserControl = _GlblSettingsSrv.DefaultFilterHeight("02018-RdlistUserControl.xaml");
                // 1 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
            GridHeightPhbkPhoneViewRdlistUserControl = _GlblSettingsSrv.DefaultGridHeight("02018-RdlistUserControl.xaml");
                // 6 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;
            if (IsAllCollapsed) {
                switch(modelName) {
                    case "PhbkPhoneTypeViewRdlistUserControl": 
                        _VisiblePhbkPhoneTypeViewRdlistUserControl = true; OnPropertyChanged("VisiblePhbkPhoneTypeViewRdlistUserControl");
                        FilterHeightPhbkPhoneTypeViewRdlistUserControl = _GlblSettingsSrv.ExpandedFilterHeight("02018-RdlistUserControl.xaml");
                            // 2 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
                        GridHeightPhbkPhoneTypeViewRdlistUserControl = _GlblSettingsSrv.ExpandedGridHeight("02018-RdlistUserControl.xaml");
                            // 19 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;
                        break;
                    case "PhbkEnterpriseViewRdlistUserControl": 
                        _VisiblePhbkEnterpriseViewRdlistUserControl = true; OnPropertyChanged("VisiblePhbkEnterpriseViewRdlistUserControl");
                        FilterHeightPhbkEnterpriseViewRdlistUserControl = _GlblSettingsSrv.ExpandedFilterHeight("02018-RdlistUserControl.xaml");
                            // 2 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
                        GridHeightPhbkEnterpriseViewRdlistUserControl = _GlblSettingsSrv.ExpandedGridHeight("02018-RdlistUserControl.xaml");
                            // 19 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;
                        break;
                    case "PhbkDivisionViewRdlistUserControl": 
                        _VisiblePhbkDivisionViewRdlistUserControl = true; OnPropertyChanged("VisiblePhbkDivisionViewRdlistUserControl");
                        FilterHeightPhbkDivisionViewRdlistUserControl = _GlblSettingsSrv.ExpandedFilterHeight("02018-RdlistUserControl.xaml");
                            // 2 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
                        GridHeightPhbkDivisionViewRdlistUserControl = _GlblSettingsSrv.ExpandedGridHeight("02018-RdlistUserControl.xaml");
                            // 19 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;
                        break;
                    case "PhbkEmployeeViewRdlistUserControl": 
                        _VisiblePhbkEmployeeViewRdlistUserControl = true; OnPropertyChanged("VisiblePhbkEmployeeViewRdlistUserControl");
                        FilterHeightPhbkEmployeeViewRdlistUserControl = _GlblSettingsSrv.ExpandedFilterHeight("02018-RdlistUserControl.xaml");
                            // 2 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
                        GridHeightPhbkEmployeeViewRdlistUserControl = _GlblSettingsSrv.ExpandedGridHeight("02018-RdlistUserControl.xaml");
                            // 19 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;
                        break;
                    case "PhbkPhoneViewRdlistUserControl": 
                        _VisiblePhbkPhoneViewRdlistUserControl = true; OnPropertyChanged("VisiblePhbkPhoneViewRdlistUserControl");
                        FilterHeightPhbkPhoneViewRdlistUserControl = _GlblSettingsSrv.ExpandedFilterHeight("02018-RdlistUserControl.xaml");
                            // 2 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
                        GridHeightPhbkPhoneViewRdlistUserControl = _GlblSettingsSrv.ExpandedGridHeight("02018-RdlistUserControl.xaml");
                            // 19 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;
                        break;
                    default:
                        break;
                }
            }
            await Device.InvokeOnMainThreadAsync(async () =>
            {
                OnPropertyChanged("FlexOn");

                await Task.Delay(1);
                IsSwitching = false;
            });

        } 
        protected bool OnContainerMenuItemsCommandCanExecute(object prm) {
            return true;
        }
        #endregion

        #region IDestructible 
        bool _IsDestroyed = false;
        public bool IsDestroyed {
            get { return _IsDestroyed; }
            set { if (_IsDestroyed != value) { _IsDestroyed = value; OnPropertyChanged();} }
        }

        public void Destroy()
        {
            if(IsDestroyed) return;
            IsDestroyed = true;
            OnPropertyChanged("FlexOn");
            _regionManager = null;
            _ContainerMenuItemsPhbkPhoneTypeViewRdlistUserControl = null;
            _ContainerMenuItemsPhbkEnterpriseViewRdlistUserControl = null;
            _ContainerMenuItemsPhbkDivisionViewRdlistUserControl = null;
            _ContainerMenuItemsPhbkEmployeeViewRdlistUserControl = null;
            _ContainerMenuItemsPhbkPhoneViewRdlistUserControl = null;
        }
        #endregion

    }
}

