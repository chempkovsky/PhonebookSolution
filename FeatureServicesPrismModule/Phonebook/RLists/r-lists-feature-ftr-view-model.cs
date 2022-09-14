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

    "RListsFeatureFtrViewModel" UserControl is defined in the "FeatureServicesPrismModule"-project.
    In the file of IModule-class of "FeatureServicesPrismModule"-project the following line of code must be inserted:

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ...
            // According to requirements of the "RListsFeatureFtrViewModel.cs"-file of "FeatureServicesPrismModule"-project. 
            ViewModelLocationProvider.Register<RListsFeatureFtrUserControl, RListsFeatureFtrViewModel>();
            // According to requirements of the "RListsFeatureFtrViewModel.cs"-file of "FeatureServicesPrismModule"-project. 
            containerRegistry.RegisterForNavigation<RListsFeatureFtrUserControl, RListsFeatureFtrViewModel>("RListsFeatureFtrUserControl");
            ...
        }

*/

namespace FeatureServicesPrismModule.Phonebook.RLists {
    public class RListsFeatureFtrViewModel : INotifyPropertyChanged, INavigationAware, IDestructible 
    {
        IRegionManager _regionManager;
        IContainerProvider _containerProvider;
        protected IAppGlblSettingsService _GlblSettingsSrv;
        public RListsFeatureFtrViewModel(IAppGlblSettingsService GlblSettingsSrv, IRegionManager regionManager, IContainerProvider containerProvider) {
            _regionManager = regionManager;
            _containerProvider = containerProvider;
            _GlblSettingsSrv = GlblSettingsSrv;

            _ContainerMenuItemsPhbkPhoneTypeViewRlistUserControl = 
                new ObservableCollection<IWebServiceFilterMenuInterface>() {
                    new WebServiceFilterMenu() { Id = "0", Caption="Expand(Collapse)", IconName=IconFont.Aspect_ratio,  IconColor= (Color)Application.Current.Resources["IconButtonPrimaryColor"], Enabled=true, Data="PhbkPhoneTypeViewRlistUserControl", Command = OnContainerMenuItemsCommand },
                };
            _FilterHeightPhbkPhoneTypeViewRlistUserControl = _GlblSettingsSrv.DefaultFilterHeight("01918-RlistUserControl.xaml");
            _GridHeightPhbkPhoneTypeViewRlistUserControl = _GlblSettingsSrv.DefaultGridHeight("01918-RlistUserControl.xaml");
            //_FilterHeightPhbkPhoneTypeViewRlistUserControl = 1 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
            //_GridHeightPhbkPhoneTypeViewRlistUserControl = 6 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;

            _ContainerMenuItemsPhbkEnterpriseViewRlistUserControl = 
                new ObservableCollection<IWebServiceFilterMenuInterface>() {
                    new WebServiceFilterMenu() { Id = "1", Caption="Expand(Collapse)", IconName=IconFont.Aspect_ratio,  IconColor= (Color)Application.Current.Resources["IconButtonPrimaryColor"], Enabled=true, Data="PhbkEnterpriseViewRlistUserControl", Command = OnContainerMenuItemsCommand },
                };
            _FilterHeightPhbkEnterpriseViewRlistUserControl = _GlblSettingsSrv.DefaultFilterHeight("01918-RlistUserControl.xaml");
            _GridHeightPhbkEnterpriseViewRlistUserControl = _GlblSettingsSrv.DefaultGridHeight("01918-RlistUserControl.xaml");
            //_FilterHeightPhbkEnterpriseViewRlistUserControl = 1 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
            //_GridHeightPhbkEnterpriseViewRlistUserControl = 6 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;

            _ContainerMenuItemsPhbkDivisionViewRlistUserControl = 
                new ObservableCollection<IWebServiceFilterMenuInterface>() {
                    new WebServiceFilterMenu() { Id = "2", Caption="Expand(Collapse)", IconName=IconFont.Aspect_ratio,  IconColor= (Color)Application.Current.Resources["IconButtonPrimaryColor"], Enabled=true, Data="PhbkDivisionViewRlistUserControl", Command = OnContainerMenuItemsCommand },
                };
            _FilterHeightPhbkDivisionViewRlistUserControl = _GlblSettingsSrv.DefaultFilterHeight("01918-RlistUserControl.xaml");
            _GridHeightPhbkDivisionViewRlistUserControl = _GlblSettingsSrv.DefaultGridHeight("01918-RlistUserControl.xaml");
            //_FilterHeightPhbkDivisionViewRlistUserControl = 1 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
            //_GridHeightPhbkDivisionViewRlistUserControl = 6 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;

            _ContainerMenuItemsPhbkEmployeeViewRlistUserControl = 
                new ObservableCollection<IWebServiceFilterMenuInterface>() {
                    new WebServiceFilterMenu() { Id = "3", Caption="Expand(Collapse)", IconName=IconFont.Aspect_ratio,  IconColor= (Color)Application.Current.Resources["IconButtonPrimaryColor"], Enabled=true, Data="PhbkEmployeeViewRlistUserControl", Command = OnContainerMenuItemsCommand },
                };
            _FilterHeightPhbkEmployeeViewRlistUserControl = _GlblSettingsSrv.DefaultFilterHeight("01918-RlistUserControl.xaml");
            _GridHeightPhbkEmployeeViewRlistUserControl = _GlblSettingsSrv.DefaultGridHeight("01918-RlistUserControl.xaml");
            //_FilterHeightPhbkEmployeeViewRlistUserControl = 1 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
            //_GridHeightPhbkEmployeeViewRlistUserControl = 6 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;

            _ContainerMenuItemsPhbkPhoneViewRlistUserControl = 
                new ObservableCollection<IWebServiceFilterMenuInterface>() {
                    new WebServiceFilterMenu() { Id = "4", Caption="Expand(Collapse)", IconName=IconFont.Aspect_ratio,  IconColor= (Color)Application.Current.Resources["IconButtonPrimaryColor"], Enabled=true, Data="PhbkPhoneViewRlistUserControl", Command = OnContainerMenuItemsCommand },
                };
            _FilterHeightPhbkPhoneViewRlistUserControl = _GlblSettingsSrv.DefaultFilterHeight("01918-RlistUserControl.xaml");
            _GridHeightPhbkPhoneViewRlistUserControl = _GlblSettingsSrv.DefaultGridHeight("01918-RlistUserControl.xaml");
            //_FilterHeightPhbkPhoneViewRlistUserControl = 1 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
            //_GridHeightPhbkPhoneViewRlistUserControl = 6 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;

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
                //suc.ScopedRegionManager = _regionManager.Regions["PhbkPhoneTypeViewRlistUserControlRListsFeatureFtrUserControl"].Add(suc, null, true);
                //suc.RequestNavigateSource = "PhbkPhoneTypeViewRlistUserControl";
                //_regionManager.Regions["PhbkPhoneTypeViewRlistUserControlRListsFeatureFtrUserControl"].Activate(suc);
                await Device.InvokeOnMainThreadAsync(async () =>
                {
                    _regionManager.RequestNavigate("PhbkPhoneTypeViewRlistUserControlRListsFeatureFtrUserControl", "PhbkPhoneTypeViewRlistUserControl", OnNavigationResult);
                    IsSwitching = true;
                    await Task.Delay(1);
                    IsSwitching = false;
                });
                //suc = _containerProvider.Resolve<IScopedRegionNavigationUserControlInterface>();
                //suc.ScopedRegionManager = _regionManager.Regions["PhbkEnterpriseViewRlistUserControlRListsFeatureFtrUserControl"].Add(suc, null, true);
                //suc.RequestNavigateSource = "PhbkEnterpriseViewRlistUserControl";
                //_regionManager.Regions["PhbkEnterpriseViewRlistUserControlRListsFeatureFtrUserControl"].Activate(suc);
                await Device.InvokeOnMainThreadAsync(async () =>
                {
                    _regionManager.RequestNavigate("PhbkEnterpriseViewRlistUserControlRListsFeatureFtrUserControl", "PhbkEnterpriseViewRlistUserControl", OnNavigationResult);
                    IsSwitching = true;
                    await Task.Delay(1);
                    IsSwitching = false;
                });
                //suc = _containerProvider.Resolve<IScopedRegionNavigationUserControlInterface>();
                //suc.ScopedRegionManager = _regionManager.Regions["PhbkDivisionViewRlistUserControlRListsFeatureFtrUserControl"].Add(suc, null, true);
                //suc.RequestNavigateSource = "PhbkDivisionViewRlistUserControl";
                //_regionManager.Regions["PhbkDivisionViewRlistUserControlRListsFeatureFtrUserControl"].Activate(suc);
                await Device.InvokeOnMainThreadAsync(async () =>
                {
                    _regionManager.RequestNavigate("PhbkDivisionViewRlistUserControlRListsFeatureFtrUserControl", "PhbkDivisionViewRlistUserControl", OnNavigationResult);
                    IsSwitching = true;
                    await Task.Delay(1);
                    IsSwitching = false;
                });
                //suc = _containerProvider.Resolve<IScopedRegionNavigationUserControlInterface>();
                //suc.ScopedRegionManager = _regionManager.Regions["PhbkEmployeeViewRlistUserControlRListsFeatureFtrUserControl"].Add(suc, null, true);
                //suc.RequestNavigateSource = "PhbkEmployeeViewRlistUserControl";
                //_regionManager.Regions["PhbkEmployeeViewRlistUserControlRListsFeatureFtrUserControl"].Activate(suc);
                await Device.InvokeOnMainThreadAsync(async () =>
                {
                    _regionManager.RequestNavigate("PhbkEmployeeViewRlistUserControlRListsFeatureFtrUserControl", "PhbkEmployeeViewRlistUserControl", OnNavigationResult);
                    IsSwitching = true;
                    await Task.Delay(1);
                    IsSwitching = false;
                });
                //suc = _containerProvider.Resolve<IScopedRegionNavigationUserControlInterface>();
                //suc.ScopedRegionManager = _regionManager.Regions["PhbkPhoneViewRlistUserControlRListsFeatureFtrUserControl"].Add(suc, null, true);
                //suc.RequestNavigateSource = "PhbkPhoneViewRlistUserControl";
                //_regionManager.Regions["PhbkPhoneViewRlistUserControlRListsFeatureFtrUserControl"].Activate(suc);
                await Device.InvokeOnMainThreadAsync(async () =>
                {
                    _regionManager.RequestNavigate("PhbkPhoneViewRlistUserControlRListsFeatureFtrUserControl", "PhbkPhoneViewRlistUserControl", OnNavigationResult);
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
                  && _VisiblePhbkPhoneTypeViewRlistUserControl
                  && _VisiblePhbkEnterpriseViewRlistUserControl
                  && _VisiblePhbkDivisionViewRlistUserControl
                  && _VisiblePhbkEmployeeViewRlistUserControl
                  && _VisiblePhbkPhoneViewRlistUserControl
                ;
            }
        }
        protected bool _VisiblePhbkPhoneTypeViewRlistUserControl = true;
        public bool VisiblePhbkPhoneTypeViewRlistUserControl
        {
            get
            {
                return _VisiblePhbkPhoneTypeViewRlistUserControl;
            }
            set
            {
                if (_VisiblePhbkPhoneTypeViewRlistUserControl != value)
                {
                    _VisiblePhbkPhoneTypeViewRlistUserControl = value;
                    OnPropertyChanged();
                    OnPropertyChanged("FlexOn");
                }
            }
        }

        protected IEnumerable<IWebServiceFilterMenuInterface> _ContainerMenuItemsPhbkPhoneTypeViewRlistUserControl = null;
        public IEnumerable<IWebServiceFilterMenuInterface> ContainerMenuItemsPhbkPhoneTypeViewRlistUserControl {
            get { return _ContainerMenuItemsPhbkPhoneTypeViewRlistUserControl; }
        }

        protected double _FilterHeightPhbkPhoneTypeViewRlistUserControl = -1d;
        public  double FilterHeightPhbkPhoneTypeViewRlistUserControl 
        {
            get { return _FilterHeightPhbkPhoneTypeViewRlistUserControl; }
            set 
            {
                if(_FilterHeightPhbkPhoneTypeViewRlistUserControl != value) {
                    _FilterHeightPhbkPhoneTypeViewRlistUserControl = value;
                    OnPropertyChanged();
                }
            }
        }

        protected double _GridHeightPhbkPhoneTypeViewRlistUserControl = -1d;
        public  double GridHeightPhbkPhoneTypeViewRlistUserControl 
        {
            get { return _GridHeightPhbkPhoneTypeViewRlistUserControl; }
            set 
            {
                if(_GridHeightPhbkPhoneTypeViewRlistUserControl != value) {
                    _GridHeightPhbkPhoneTypeViewRlistUserControl = value;
                    OnPropertyChanged();
                }
            }
        }

        protected bool _VisiblePhbkEnterpriseViewRlistUserControl = true;
        public bool VisiblePhbkEnterpriseViewRlistUserControl
        {
            get
            {
                return _VisiblePhbkEnterpriseViewRlistUserControl;
            }
            set
            {
                if (_VisiblePhbkEnterpriseViewRlistUserControl != value)
                {
                    _VisiblePhbkEnterpriseViewRlistUserControl = value;
                    OnPropertyChanged();
                    OnPropertyChanged("FlexOn");
                }
            }
        }

        protected IEnumerable<IWebServiceFilterMenuInterface> _ContainerMenuItemsPhbkEnterpriseViewRlistUserControl = null;
        public IEnumerable<IWebServiceFilterMenuInterface> ContainerMenuItemsPhbkEnterpriseViewRlistUserControl {
            get { return _ContainerMenuItemsPhbkEnterpriseViewRlistUserControl; }
        }

        protected double _FilterHeightPhbkEnterpriseViewRlistUserControl = -1d;
        public  double FilterHeightPhbkEnterpriseViewRlistUserControl 
        {
            get { return _FilterHeightPhbkEnterpriseViewRlistUserControl; }
            set 
            {
                if(_FilterHeightPhbkEnterpriseViewRlistUserControl != value) {
                    _FilterHeightPhbkEnterpriseViewRlistUserControl = value;
                    OnPropertyChanged();
                }
            }
        }

        protected double _GridHeightPhbkEnterpriseViewRlistUserControl = -1d;
        public  double GridHeightPhbkEnterpriseViewRlistUserControl 
        {
            get { return _GridHeightPhbkEnterpriseViewRlistUserControl; }
            set 
            {
                if(_GridHeightPhbkEnterpriseViewRlistUserControl != value) {
                    _GridHeightPhbkEnterpriseViewRlistUserControl = value;
                    OnPropertyChanged();
                }
            }
        }

        protected bool _VisiblePhbkDivisionViewRlistUserControl = true;
        public bool VisiblePhbkDivisionViewRlistUserControl
        {
            get
            {
                return _VisiblePhbkDivisionViewRlistUserControl;
            }
            set
            {
                if (_VisiblePhbkDivisionViewRlistUserControl != value)
                {
                    _VisiblePhbkDivisionViewRlistUserControl = value;
                    OnPropertyChanged();
                    OnPropertyChanged("FlexOn");
                }
            }
        }

        protected IEnumerable<IWebServiceFilterMenuInterface> _ContainerMenuItemsPhbkDivisionViewRlistUserControl = null;
        public IEnumerable<IWebServiceFilterMenuInterface> ContainerMenuItemsPhbkDivisionViewRlistUserControl {
            get { return _ContainerMenuItemsPhbkDivisionViewRlistUserControl; }
        }

        protected double _FilterHeightPhbkDivisionViewRlistUserControl = -1d;
        public  double FilterHeightPhbkDivisionViewRlistUserControl 
        {
            get { return _FilterHeightPhbkDivisionViewRlistUserControl; }
            set 
            {
                if(_FilterHeightPhbkDivisionViewRlistUserControl != value) {
                    _FilterHeightPhbkDivisionViewRlistUserControl = value;
                    OnPropertyChanged();
                }
            }
        }

        protected double _GridHeightPhbkDivisionViewRlistUserControl = -1d;
        public  double GridHeightPhbkDivisionViewRlistUserControl 
        {
            get { return _GridHeightPhbkDivisionViewRlistUserControl; }
            set 
            {
                if(_GridHeightPhbkDivisionViewRlistUserControl != value) {
                    _GridHeightPhbkDivisionViewRlistUserControl = value;
                    OnPropertyChanged();
                }
            }
        }

        protected bool _VisiblePhbkEmployeeViewRlistUserControl = true;
        public bool VisiblePhbkEmployeeViewRlistUserControl
        {
            get
            {
                return _VisiblePhbkEmployeeViewRlistUserControl;
            }
            set
            {
                if (_VisiblePhbkEmployeeViewRlistUserControl != value)
                {
                    _VisiblePhbkEmployeeViewRlistUserControl = value;
                    OnPropertyChanged();
                    OnPropertyChanged("FlexOn");
                }
            }
        }

        protected IEnumerable<IWebServiceFilterMenuInterface> _ContainerMenuItemsPhbkEmployeeViewRlistUserControl = null;
        public IEnumerable<IWebServiceFilterMenuInterface> ContainerMenuItemsPhbkEmployeeViewRlistUserControl {
            get { return _ContainerMenuItemsPhbkEmployeeViewRlistUserControl; }
        }

        protected double _FilterHeightPhbkEmployeeViewRlistUserControl = -1d;
        public  double FilterHeightPhbkEmployeeViewRlistUserControl 
        {
            get { return _FilterHeightPhbkEmployeeViewRlistUserControl; }
            set 
            {
                if(_FilterHeightPhbkEmployeeViewRlistUserControl != value) {
                    _FilterHeightPhbkEmployeeViewRlistUserControl = value;
                    OnPropertyChanged();
                }
            }
        }

        protected double _GridHeightPhbkEmployeeViewRlistUserControl = -1d;
        public  double GridHeightPhbkEmployeeViewRlistUserControl 
        {
            get { return _GridHeightPhbkEmployeeViewRlistUserControl; }
            set 
            {
                if(_GridHeightPhbkEmployeeViewRlistUserControl != value) {
                    _GridHeightPhbkEmployeeViewRlistUserControl = value;
                    OnPropertyChanged();
                }
            }
        }

        protected bool _VisiblePhbkPhoneViewRlistUserControl = true;
        public bool VisiblePhbkPhoneViewRlistUserControl
        {
            get
            {
                return _VisiblePhbkPhoneViewRlistUserControl;
            }
            set
            {
                if (_VisiblePhbkPhoneViewRlistUserControl != value)
                {
                    _VisiblePhbkPhoneViewRlistUserControl = value;
                    OnPropertyChanged();
                    OnPropertyChanged("FlexOn");
                }
            }
        }

        protected IEnumerable<IWebServiceFilterMenuInterface> _ContainerMenuItemsPhbkPhoneViewRlistUserControl = null;
        public IEnumerable<IWebServiceFilterMenuInterface> ContainerMenuItemsPhbkPhoneViewRlistUserControl {
            get { return _ContainerMenuItemsPhbkPhoneViewRlistUserControl; }
        }

        protected double _FilterHeightPhbkPhoneViewRlistUserControl = -1d;
        public  double FilterHeightPhbkPhoneViewRlistUserControl 
        {
            get { return _FilterHeightPhbkPhoneViewRlistUserControl; }
            set 
            {
                if(_FilterHeightPhbkPhoneViewRlistUserControl != value) {
                    _FilterHeightPhbkPhoneViewRlistUserControl = value;
                    OnPropertyChanged();
                }
            }
        }

        protected double _GridHeightPhbkPhoneViewRlistUserControl = -1d;
        public  double GridHeightPhbkPhoneViewRlistUserControl 
        {
            get { return _GridHeightPhbkPhoneViewRlistUserControl; }
            set 
            {
                if(_GridHeightPhbkPhoneViewRlistUserControl != value) {
                    _GridHeightPhbkPhoneViewRlistUserControl = value;
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
            _VisiblePhbkPhoneTypeViewRlistUserControl = !IsAllCollapsed; OnPropertyChanged("VisiblePhbkPhoneTypeViewRlistUserControl");
            FilterHeightPhbkPhoneTypeViewRlistUserControl = _GlblSettingsSrv.DefaultFilterHeight("01918-RlistUserControl.xaml");
                // 1 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
            GridHeightPhbkPhoneTypeViewRlistUserControl = _GlblSettingsSrv.DefaultGridHeight("01918-RlistUserControl.xaml");
                // 6 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;
            _VisiblePhbkEnterpriseViewRlistUserControl = !IsAllCollapsed; OnPropertyChanged("VisiblePhbkEnterpriseViewRlistUserControl");
            FilterHeightPhbkEnterpriseViewRlistUserControl = _GlblSettingsSrv.DefaultFilterHeight("01918-RlistUserControl.xaml");
                // 1 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
            GridHeightPhbkEnterpriseViewRlistUserControl = _GlblSettingsSrv.DefaultGridHeight("01918-RlistUserControl.xaml");
                // 6 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;
            _VisiblePhbkDivisionViewRlistUserControl = !IsAllCollapsed; OnPropertyChanged("VisiblePhbkDivisionViewRlistUserControl");
            FilterHeightPhbkDivisionViewRlistUserControl = _GlblSettingsSrv.DefaultFilterHeight("01918-RlistUserControl.xaml");
                // 1 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
            GridHeightPhbkDivisionViewRlistUserControl = _GlblSettingsSrv.DefaultGridHeight("01918-RlistUserControl.xaml");
                // 6 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;
            _VisiblePhbkEmployeeViewRlistUserControl = !IsAllCollapsed; OnPropertyChanged("VisiblePhbkEmployeeViewRlistUserControl");
            FilterHeightPhbkEmployeeViewRlistUserControl = _GlblSettingsSrv.DefaultFilterHeight("01918-RlistUserControl.xaml");
                // 1 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
            GridHeightPhbkEmployeeViewRlistUserControl = _GlblSettingsSrv.DefaultGridHeight("01918-RlistUserControl.xaml");
                // 6 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;
            _VisiblePhbkPhoneViewRlistUserControl = !IsAllCollapsed; OnPropertyChanged("VisiblePhbkPhoneViewRlistUserControl");
            FilterHeightPhbkPhoneViewRlistUserControl = _GlblSettingsSrv.DefaultFilterHeight("01918-RlistUserControl.xaml");
                // 1 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
            GridHeightPhbkPhoneViewRlistUserControl = _GlblSettingsSrv.DefaultGridHeight("01918-RlistUserControl.xaml");
                // 6 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;
            if (IsAllCollapsed) {
                switch(modelName) {
                    case "PhbkPhoneTypeViewRlistUserControl": 
                        _VisiblePhbkPhoneTypeViewRlistUserControl = true; OnPropertyChanged("VisiblePhbkPhoneTypeViewRlistUserControl");
                        FilterHeightPhbkPhoneTypeViewRlistUserControl = _GlblSettingsSrv.ExpandedFilterHeight("01918-RlistUserControl.xaml");
                            // 2 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
                        GridHeightPhbkPhoneTypeViewRlistUserControl = _GlblSettingsSrv.ExpandedGridHeight("01918-RlistUserControl.xaml");
                            // 19 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;
                        break;
                    case "PhbkEnterpriseViewRlistUserControl": 
                        _VisiblePhbkEnterpriseViewRlistUserControl = true; OnPropertyChanged("VisiblePhbkEnterpriseViewRlistUserControl");
                        FilterHeightPhbkEnterpriseViewRlistUserControl = _GlblSettingsSrv.ExpandedFilterHeight("01918-RlistUserControl.xaml");
                            // 2 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
                        GridHeightPhbkEnterpriseViewRlistUserControl = _GlblSettingsSrv.ExpandedGridHeight("01918-RlistUserControl.xaml");
                            // 19 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;
                        break;
                    case "PhbkDivisionViewRlistUserControl": 
                        _VisiblePhbkDivisionViewRlistUserControl = true; OnPropertyChanged("VisiblePhbkDivisionViewRlistUserControl");
                        FilterHeightPhbkDivisionViewRlistUserControl = _GlblSettingsSrv.ExpandedFilterHeight("01918-RlistUserControl.xaml");
                            // 2 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
                        GridHeightPhbkDivisionViewRlistUserControl = _GlblSettingsSrv.ExpandedGridHeight("01918-RlistUserControl.xaml");
                            // 19 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;
                        break;
                    case "PhbkEmployeeViewRlistUserControl": 
                        _VisiblePhbkEmployeeViewRlistUserControl = true; OnPropertyChanged("VisiblePhbkEmployeeViewRlistUserControl");
                        FilterHeightPhbkEmployeeViewRlistUserControl = _GlblSettingsSrv.ExpandedFilterHeight("01918-RlistUserControl.xaml");
                            // 2 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
                        GridHeightPhbkEmployeeViewRlistUserControl = _GlblSettingsSrv.ExpandedGridHeight("01918-RlistUserControl.xaml");
                            // 19 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;
                        break;
                    case "PhbkPhoneViewRlistUserControl": 
                        _VisiblePhbkPhoneViewRlistUserControl = true; OnPropertyChanged("VisiblePhbkPhoneViewRlistUserControl");
                        FilterHeightPhbkPhoneViewRlistUserControl = _GlblSettingsSrv.ExpandedFilterHeight("01918-RlistUserControl.xaml");
                            // 2 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
                        GridHeightPhbkPhoneViewRlistUserControl = _GlblSettingsSrv.ExpandedGridHeight("01918-RlistUserControl.xaml");
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
            _ContainerMenuItemsPhbkPhoneTypeViewRlistUserControl = null;
            _ContainerMenuItemsPhbkEnterpriseViewRlistUserControl = null;
            _ContainerMenuItemsPhbkDivisionViewRlistUserControl = null;
            _ContainerMenuItemsPhbkEmployeeViewRlistUserControl = null;
            _ContainerMenuItemsPhbkPhoneViewRlistUserControl = null;
        }
        #endregion

    }
}

