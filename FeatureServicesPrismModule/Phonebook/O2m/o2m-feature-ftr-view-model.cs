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

    "O2mFeatureFtrViewModel" UserControl is defined in the "FeatureServicesPrismModule"-project.
    In the file of IModule-class of "FeatureServicesPrismModule"-project the following line of code must be inserted:

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ...
            // According to requirements of the "O2mFeatureFtrViewModel.cs"-file of "FeatureServicesPrismModule"-project. 
            ViewModelLocationProvider.Register<O2mFeatureFtrUserControl, O2mFeatureFtrViewModel>();
            // According to requirements of the "O2mFeatureFtrViewModel.cs"-file of "FeatureServicesPrismModule"-project. 
            containerRegistry.RegisterForNavigation<O2mFeatureFtrUserControl, O2mFeatureFtrViewModel>("O2mFeatureFtrUserControl");
            ...
        }

*/

namespace FeatureServicesPrismModule.Phonebook.O2m {
    public class O2mFeatureFtrViewModel : INotifyPropertyChanged, INavigationAware, IDestructible 
    {
        IRegionManager _regionManager;
        IContainerProvider _containerProvider;
        protected IAppGlblSettingsService _GlblSettingsSrv;
        public O2mFeatureFtrViewModel(IAppGlblSettingsService GlblSettingsSrv, IRegionManager regionManager, IContainerProvider containerProvider) {
            _regionManager = regionManager;
            _containerProvider = containerProvider;
            _GlblSettingsSrv = GlblSettingsSrv;

            _ContainerMenuItemsPhbkPhoneTypeViewO2mUserControl = 
                new ObservableCollection<IWebServiceFilterMenuInterface>() {
                    new WebServiceFilterMenu() { Id = "0", Caption="Expand(Collapse)", IconName=IconFont.Aspect_ratio,  IconColor= (Color)Application.Current.Resources["IconButtonPrimaryColor"], Enabled=true, Data="PhbkPhoneTypeViewO2mUserControl", Command = OnContainerMenuItemsCommand },
                };
            _FilterHeightPhbkPhoneTypeViewO2mUserControl = _GlblSettingsSrv.DefaultFilterHeight("01698-O2mUserControl.xaml");
            _GridHeightPhbkPhoneTypeViewO2mUserControl = _GlblSettingsSrv.DefaultGridHeight("01698-O2mUserControl.xaml");
            //_FilterHeightPhbkPhoneTypeViewO2mUserControl = 1 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
            //_GridHeightPhbkPhoneTypeViewO2mUserControl = 5 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;

            _ContainerMenuItemsPhbkEnterpriseViewO2mUserControl = 
                new ObservableCollection<IWebServiceFilterMenuInterface>() {
                    new WebServiceFilterMenu() { Id = "1", Caption="Expand(Collapse)", IconName=IconFont.Aspect_ratio,  IconColor= (Color)Application.Current.Resources["IconButtonPrimaryColor"], Enabled=true, Data="PhbkEnterpriseViewO2mUserControl", Command = OnContainerMenuItemsCommand },
                };
            _FilterHeightPhbkEnterpriseViewO2mUserControl = _GlblSettingsSrv.DefaultFilterHeight("01698-O2mUserControl.xaml");
            _GridHeightPhbkEnterpriseViewO2mUserControl = _GlblSettingsSrv.DefaultGridHeight("01698-O2mUserControl.xaml");
            //_FilterHeightPhbkEnterpriseViewO2mUserControl = 1 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
            //_GridHeightPhbkEnterpriseViewO2mUserControl = 5 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;

            _ContainerMenuItemsPhbkDivisionViewO2mUserControl = 
                new ObservableCollection<IWebServiceFilterMenuInterface>() {
                    new WebServiceFilterMenu() { Id = "2", Caption="Expand(Collapse)", IconName=IconFont.Aspect_ratio,  IconColor= (Color)Application.Current.Resources["IconButtonPrimaryColor"], Enabled=true, Data="PhbkDivisionViewO2mUserControl", Command = OnContainerMenuItemsCommand },
                };
            _FilterHeightPhbkDivisionViewO2mUserControl = _GlblSettingsSrv.DefaultFilterHeight("01698-O2mUserControl.xaml");
            _GridHeightPhbkDivisionViewO2mUserControl = _GlblSettingsSrv.DefaultGridHeight("01698-O2mUserControl.xaml");
            //_FilterHeightPhbkDivisionViewO2mUserControl = 1 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
            //_GridHeightPhbkDivisionViewO2mUserControl = 5 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;

            _ContainerMenuItemsPhbkEmployeeViewO2mUserControl = 
                new ObservableCollection<IWebServiceFilterMenuInterface>() {
                    new WebServiceFilterMenu() { Id = "3", Caption="Expand(Collapse)", IconName=IconFont.Aspect_ratio,  IconColor= (Color)Application.Current.Resources["IconButtonPrimaryColor"], Enabled=true, Data="PhbkEmployeeViewO2mUserControl", Command = OnContainerMenuItemsCommand },
                };
            _FilterHeightPhbkEmployeeViewO2mUserControl = _GlblSettingsSrv.DefaultFilterHeight("01698-O2mUserControl.xaml");
            _GridHeightPhbkEmployeeViewO2mUserControl = _GlblSettingsSrv.DefaultGridHeight("01698-O2mUserControl.xaml");
            //_FilterHeightPhbkEmployeeViewO2mUserControl = 1 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
            //_GridHeightPhbkEmployeeViewO2mUserControl = 5 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;

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
                //suc.ScopedRegionManager = _regionManager.Regions["PhbkPhoneTypeViewO2mUserControlO2mFeatureFtrUserControl"].Add(suc, null, true);
                //suc.RequestNavigateSource = "PhbkPhoneTypeViewO2mUserControl";
                //_regionManager.Regions["PhbkPhoneTypeViewO2mUserControlO2mFeatureFtrUserControl"].Activate(suc);
                await Device.InvokeOnMainThreadAsync(async () =>
                {
                    _regionManager.RequestNavigate("PhbkPhoneTypeViewO2mUserControlO2mFeatureFtrUserControl", "PhbkPhoneTypeViewO2mUserControl", OnNavigationResult);
                    IsSwitching = true;
                    await Task.Delay(1);
                    IsSwitching = false;
                });
                //suc = _containerProvider.Resolve<IScopedRegionNavigationUserControlInterface>();
                //suc.ScopedRegionManager = _regionManager.Regions["PhbkEnterpriseViewO2mUserControlO2mFeatureFtrUserControl"].Add(suc, null, true);
                //suc.RequestNavigateSource = "PhbkEnterpriseViewO2mUserControl";
                //_regionManager.Regions["PhbkEnterpriseViewO2mUserControlO2mFeatureFtrUserControl"].Activate(suc);
                await Device.InvokeOnMainThreadAsync(async () =>
                {
                    _regionManager.RequestNavigate("PhbkEnterpriseViewO2mUserControlO2mFeatureFtrUserControl", "PhbkEnterpriseViewO2mUserControl", OnNavigationResult);
                    IsSwitching = true;
                    await Task.Delay(1);
                    IsSwitching = false;
                });
                //suc = _containerProvider.Resolve<IScopedRegionNavigationUserControlInterface>();
                //suc.ScopedRegionManager = _regionManager.Regions["PhbkDivisionViewO2mUserControlO2mFeatureFtrUserControl"].Add(suc, null, true);
                //suc.RequestNavigateSource = "PhbkDivisionViewO2mUserControl";
                //_regionManager.Regions["PhbkDivisionViewO2mUserControlO2mFeatureFtrUserControl"].Activate(suc);
                await Device.InvokeOnMainThreadAsync(async () =>
                {
                    _regionManager.RequestNavigate("PhbkDivisionViewO2mUserControlO2mFeatureFtrUserControl", "PhbkDivisionViewO2mUserControl", OnNavigationResult);
                    IsSwitching = true;
                    await Task.Delay(1);
                    IsSwitching = false;
                });
                //suc = _containerProvider.Resolve<IScopedRegionNavigationUserControlInterface>();
                //suc.ScopedRegionManager = _regionManager.Regions["PhbkEmployeeViewO2mUserControlO2mFeatureFtrUserControl"].Add(suc, null, true);
                //suc.RequestNavigateSource = "PhbkEmployeeViewO2mUserControl";
                //_regionManager.Regions["PhbkEmployeeViewO2mUserControlO2mFeatureFtrUserControl"].Activate(suc);
                await Device.InvokeOnMainThreadAsync(async () =>
                {
                    _regionManager.RequestNavigate("PhbkEmployeeViewO2mUserControlO2mFeatureFtrUserControl", "PhbkEmployeeViewO2mUserControl", OnNavigationResult);
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
                  && _VisiblePhbkPhoneTypeViewO2mUserControl
                  && _VisiblePhbkEnterpriseViewO2mUserControl
                  && _VisiblePhbkDivisionViewO2mUserControl
                  && _VisiblePhbkEmployeeViewO2mUserControl
                ;
            }
        }
        protected bool _VisiblePhbkPhoneTypeViewO2mUserControl = true;
        public bool VisiblePhbkPhoneTypeViewO2mUserControl
        {
            get
            {
                return _VisiblePhbkPhoneTypeViewO2mUserControl;
            }
            set
            {
                if (_VisiblePhbkPhoneTypeViewO2mUserControl != value)
                {
                    _VisiblePhbkPhoneTypeViewO2mUserControl = value;
                    OnPropertyChanged();
                    OnPropertyChanged("FlexOn");
                }
            }
        }

        protected IEnumerable<IWebServiceFilterMenuInterface> _ContainerMenuItemsPhbkPhoneTypeViewO2mUserControl = null;
        public IEnumerable<IWebServiceFilterMenuInterface> ContainerMenuItemsPhbkPhoneTypeViewO2mUserControl {
            get { return _ContainerMenuItemsPhbkPhoneTypeViewO2mUserControl; }
        }

        protected double _FilterHeightPhbkPhoneTypeViewO2mUserControl = -1d;
        public  double FilterHeightPhbkPhoneTypeViewO2mUserControl 
        {
            get { return _FilterHeightPhbkPhoneTypeViewO2mUserControl; }
            set 
            {
                if(_FilterHeightPhbkPhoneTypeViewO2mUserControl != value) {
                    _FilterHeightPhbkPhoneTypeViewO2mUserControl = value;
                    OnPropertyChanged();
                }
            }
        }

        protected double _GridHeightPhbkPhoneTypeViewO2mUserControl = -1d;
        public  double GridHeightPhbkPhoneTypeViewO2mUserControl 
        {
            get { return _GridHeightPhbkPhoneTypeViewO2mUserControl; }
            set 
            {
                if(_GridHeightPhbkPhoneTypeViewO2mUserControl != value) {
                    _GridHeightPhbkPhoneTypeViewO2mUserControl = value;
                    OnPropertyChanged();
                }
            }
        }

        protected bool _VisiblePhbkEnterpriseViewO2mUserControl = true;
        public bool VisiblePhbkEnterpriseViewO2mUserControl
        {
            get
            {
                return _VisiblePhbkEnterpriseViewO2mUserControl;
            }
            set
            {
                if (_VisiblePhbkEnterpriseViewO2mUserControl != value)
                {
                    _VisiblePhbkEnterpriseViewO2mUserControl = value;
                    OnPropertyChanged();
                    OnPropertyChanged("FlexOn");
                }
            }
        }

        protected IEnumerable<IWebServiceFilterMenuInterface> _ContainerMenuItemsPhbkEnterpriseViewO2mUserControl = null;
        public IEnumerable<IWebServiceFilterMenuInterface> ContainerMenuItemsPhbkEnterpriseViewO2mUserControl {
            get { return _ContainerMenuItemsPhbkEnterpriseViewO2mUserControl; }
        }

        protected double _FilterHeightPhbkEnterpriseViewO2mUserControl = -1d;
        public  double FilterHeightPhbkEnterpriseViewO2mUserControl 
        {
            get { return _FilterHeightPhbkEnterpriseViewO2mUserControl; }
            set 
            {
                if(_FilterHeightPhbkEnterpriseViewO2mUserControl != value) {
                    _FilterHeightPhbkEnterpriseViewO2mUserControl = value;
                    OnPropertyChanged();
                }
            }
        }

        protected double _GridHeightPhbkEnterpriseViewO2mUserControl = -1d;
        public  double GridHeightPhbkEnterpriseViewO2mUserControl 
        {
            get { return _GridHeightPhbkEnterpriseViewO2mUserControl; }
            set 
            {
                if(_GridHeightPhbkEnterpriseViewO2mUserControl != value) {
                    _GridHeightPhbkEnterpriseViewO2mUserControl = value;
                    OnPropertyChanged();
                }
            }
        }

        protected bool _VisiblePhbkDivisionViewO2mUserControl = true;
        public bool VisiblePhbkDivisionViewO2mUserControl
        {
            get
            {
                return _VisiblePhbkDivisionViewO2mUserControl;
            }
            set
            {
                if (_VisiblePhbkDivisionViewO2mUserControl != value)
                {
                    _VisiblePhbkDivisionViewO2mUserControl = value;
                    OnPropertyChanged();
                    OnPropertyChanged("FlexOn");
                }
            }
        }

        protected IEnumerable<IWebServiceFilterMenuInterface> _ContainerMenuItemsPhbkDivisionViewO2mUserControl = null;
        public IEnumerable<IWebServiceFilterMenuInterface> ContainerMenuItemsPhbkDivisionViewO2mUserControl {
            get { return _ContainerMenuItemsPhbkDivisionViewO2mUserControl; }
        }

        protected double _FilterHeightPhbkDivisionViewO2mUserControl = -1d;
        public  double FilterHeightPhbkDivisionViewO2mUserControl 
        {
            get { return _FilterHeightPhbkDivisionViewO2mUserControl; }
            set 
            {
                if(_FilterHeightPhbkDivisionViewO2mUserControl != value) {
                    _FilterHeightPhbkDivisionViewO2mUserControl = value;
                    OnPropertyChanged();
                }
            }
        }

        protected double _GridHeightPhbkDivisionViewO2mUserControl = -1d;
        public  double GridHeightPhbkDivisionViewO2mUserControl 
        {
            get { return _GridHeightPhbkDivisionViewO2mUserControl; }
            set 
            {
                if(_GridHeightPhbkDivisionViewO2mUserControl != value) {
                    _GridHeightPhbkDivisionViewO2mUserControl = value;
                    OnPropertyChanged();
                }
            }
        }

        protected bool _VisiblePhbkEmployeeViewO2mUserControl = true;
        public bool VisiblePhbkEmployeeViewO2mUserControl
        {
            get
            {
                return _VisiblePhbkEmployeeViewO2mUserControl;
            }
            set
            {
                if (_VisiblePhbkEmployeeViewO2mUserControl != value)
                {
                    _VisiblePhbkEmployeeViewO2mUserControl = value;
                    OnPropertyChanged();
                    OnPropertyChanged("FlexOn");
                }
            }
        }

        protected IEnumerable<IWebServiceFilterMenuInterface> _ContainerMenuItemsPhbkEmployeeViewO2mUserControl = null;
        public IEnumerable<IWebServiceFilterMenuInterface> ContainerMenuItemsPhbkEmployeeViewO2mUserControl {
            get { return _ContainerMenuItemsPhbkEmployeeViewO2mUserControl; }
        }

        protected double _FilterHeightPhbkEmployeeViewO2mUserControl = -1d;
        public  double FilterHeightPhbkEmployeeViewO2mUserControl 
        {
            get { return _FilterHeightPhbkEmployeeViewO2mUserControl; }
            set 
            {
                if(_FilterHeightPhbkEmployeeViewO2mUserControl != value) {
                    _FilterHeightPhbkEmployeeViewO2mUserControl = value;
                    OnPropertyChanged();
                }
            }
        }

        protected double _GridHeightPhbkEmployeeViewO2mUserControl = -1d;
        public  double GridHeightPhbkEmployeeViewO2mUserControl 
        {
            get { return _GridHeightPhbkEmployeeViewO2mUserControl; }
            set 
            {
                if(_GridHeightPhbkEmployeeViewO2mUserControl != value) {
                    _GridHeightPhbkEmployeeViewO2mUserControl = value;
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
            _VisiblePhbkPhoneTypeViewO2mUserControl = !IsAllCollapsed; OnPropertyChanged("VisiblePhbkPhoneTypeViewO2mUserControl");
            FilterHeightPhbkPhoneTypeViewO2mUserControl = _GlblSettingsSrv.DefaultFilterHeight("01698-O2mUserControl.xaml");
                // 1 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
            GridHeightPhbkPhoneTypeViewO2mUserControl = _GlblSettingsSrv.DefaultGridHeight("01698-O2mUserControl.xaml");
                // 5 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;
            _VisiblePhbkEnterpriseViewO2mUserControl = !IsAllCollapsed; OnPropertyChanged("VisiblePhbkEnterpriseViewO2mUserControl");
            FilterHeightPhbkEnterpriseViewO2mUserControl = _GlblSettingsSrv.DefaultFilterHeight("01698-O2mUserControl.xaml");
                // 1 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
            GridHeightPhbkEnterpriseViewO2mUserControl = _GlblSettingsSrv.DefaultGridHeight("01698-O2mUserControl.xaml");
                // 5 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;
            _VisiblePhbkDivisionViewO2mUserControl = !IsAllCollapsed; OnPropertyChanged("VisiblePhbkDivisionViewO2mUserControl");
            FilterHeightPhbkDivisionViewO2mUserControl = _GlblSettingsSrv.DefaultFilterHeight("01698-O2mUserControl.xaml");
                // 1 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
            GridHeightPhbkDivisionViewO2mUserControl = _GlblSettingsSrv.DefaultGridHeight("01698-O2mUserControl.xaml");
                // 5 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;
            _VisiblePhbkEmployeeViewO2mUserControl = !IsAllCollapsed; OnPropertyChanged("VisiblePhbkEmployeeViewO2mUserControl");
            FilterHeightPhbkEmployeeViewO2mUserControl = _GlblSettingsSrv.DefaultFilterHeight("01698-O2mUserControl.xaml");
                // 1 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
            GridHeightPhbkEmployeeViewO2mUserControl = _GlblSettingsSrv.DefaultGridHeight("01698-O2mUserControl.xaml");
                // 5 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;
            if (IsAllCollapsed) {
                switch(modelName) {
                    case "PhbkPhoneTypeViewO2mUserControl": 
                        _VisiblePhbkPhoneTypeViewO2mUserControl = true; OnPropertyChanged("VisiblePhbkPhoneTypeViewO2mUserControl");
                        FilterHeightPhbkPhoneTypeViewO2mUserControl = _GlblSettingsSrv.ExpandedFilterHeight("01698-O2mUserControl.xaml");
                            // 1 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
                        GridHeightPhbkPhoneTypeViewO2mUserControl = _GlblSettingsSrv.ExpandedGridHeight("01698-O2mUserControl.xaml");
                            // 5 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;
                        break;
                    case "PhbkEnterpriseViewO2mUserControl": 
                        _VisiblePhbkEnterpriseViewO2mUserControl = true; OnPropertyChanged("VisiblePhbkEnterpriseViewO2mUserControl");
                        FilterHeightPhbkEnterpriseViewO2mUserControl = _GlblSettingsSrv.ExpandedFilterHeight("01698-O2mUserControl.xaml");
                            // 1 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
                        GridHeightPhbkEnterpriseViewO2mUserControl = _GlblSettingsSrv.ExpandedGridHeight("01698-O2mUserControl.xaml");
                            // 5 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;
                        break;
                    case "PhbkDivisionViewO2mUserControl": 
                        _VisiblePhbkDivisionViewO2mUserControl = true; OnPropertyChanged("VisiblePhbkDivisionViewO2mUserControl");
                        FilterHeightPhbkDivisionViewO2mUserControl = _GlblSettingsSrv.ExpandedFilterHeight("01698-O2mUserControl.xaml");
                            // 1 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
                        GridHeightPhbkDivisionViewO2mUserControl = _GlblSettingsSrv.ExpandedGridHeight("01698-O2mUserControl.xaml");
                            // 5 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;
                        break;
                    case "PhbkEmployeeViewO2mUserControl": 
                        _VisiblePhbkEmployeeViewO2mUserControl = true; OnPropertyChanged("VisiblePhbkEmployeeViewO2mUserControl");
                        FilterHeightPhbkEmployeeViewO2mUserControl = _GlblSettingsSrv.ExpandedFilterHeight("01698-O2mUserControl.xaml");
                            // 1 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
                        GridHeightPhbkEmployeeViewO2mUserControl = _GlblSettingsSrv.ExpandedGridHeight("01698-O2mUserControl.xaml");
                            // 5 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;
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
            _ContainerMenuItemsPhbkPhoneTypeViewO2mUserControl = null;
            _ContainerMenuItemsPhbkEnterpriseViewO2mUserControl = null;
            _ContainerMenuItemsPhbkDivisionViewO2mUserControl = null;
            _ContainerMenuItemsPhbkEmployeeViewO2mUserControl = null;
        }
        #endregion

    }
}

