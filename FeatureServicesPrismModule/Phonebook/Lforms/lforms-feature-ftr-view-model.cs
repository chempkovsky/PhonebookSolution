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

    "LformsFeatureFtrViewModel" UserControl is defined in the "FeatureServicesPrismModule"-project.
    In the file of IModule-class of "FeatureServicesPrismModule"-project the following line of code must be inserted:

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ...
            // According to requirements of the "LformsFeatureFtrViewModel.cs"-file of "FeatureServicesPrismModule"-project. 
            ViewModelLocationProvider.Register<LformsFeatureFtrUserControl, LformsFeatureFtrViewModel>();
            // According to requirements of the "LformsFeatureFtrViewModel.cs"-file of "FeatureServicesPrismModule"-project. 
            containerRegistry.RegisterForNavigation<LformsFeatureFtrUserControl, LformsFeatureFtrViewModel>("LformsFeatureFtrUserControl");
            ...
        }

*/

namespace FeatureServicesPrismModule.Phonebook.Lforms {
    public class LformsFeatureFtrViewModel : INotifyPropertyChanged, INavigationAware, IDestructible 
    {
        IRegionManager _regionManager;
        IContainerProvider _containerProvider;
        protected IAppGlblSettingsService _GlblSettingsSrv;
        public LformsFeatureFtrViewModel(IAppGlblSettingsService GlblSettingsSrv, IRegionManager regionManager, IContainerProvider containerProvider) {
            _regionManager = regionManager;
            _containerProvider = containerProvider;
            _GlblSettingsSrv = GlblSettingsSrv;

            _ContainerMenuItemsPhbkPhoneTypeViewLformUserControl = 
                new ObservableCollection<IWebServiceFilterMenuInterface>() {
                    new WebServiceFilterMenu() { Id = "0", Caption="Expand(Collapse)", IconName=IconFont.Aspect_ratio,  IconColor= (Color)Application.Current.Resources["IconButtonPrimaryColor"], Enabled=true, Data="PhbkPhoneTypeViewLformUserControl", Command = OnContainerMenuItemsCommand },
                };
            _FilterHeightPhbkPhoneTypeViewLformUserControl = _GlblSettingsSrv.DefaultFilterHeight("01598-LformUserControl.xaml");
            _GridHeightPhbkPhoneTypeViewLformUserControl = _GlblSettingsSrv.DefaultGridHeight("01598-LformUserControl.xaml");
            //_FilterHeightPhbkPhoneTypeViewLformUserControl = 1 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
            //_GridHeightPhbkPhoneTypeViewLformUserControl = 6 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;

            _ContainerMenuItemsPhbkEnterpriseViewLformUserControl = 
                new ObservableCollection<IWebServiceFilterMenuInterface>() {
                    new WebServiceFilterMenu() { Id = "1", Caption="Expand(Collapse)", IconName=IconFont.Aspect_ratio,  IconColor= (Color)Application.Current.Resources["IconButtonPrimaryColor"], Enabled=true, Data="PhbkEnterpriseViewLformUserControl", Command = OnContainerMenuItemsCommand },
                };
            _FilterHeightPhbkEnterpriseViewLformUserControl = _GlblSettingsSrv.DefaultFilterHeight("01598-LformUserControl.xaml");
            _GridHeightPhbkEnterpriseViewLformUserControl = _GlblSettingsSrv.DefaultGridHeight("01598-LformUserControl.xaml");
            //_FilterHeightPhbkEnterpriseViewLformUserControl = 1 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
            //_GridHeightPhbkEnterpriseViewLformUserControl = 6 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;

            _ContainerMenuItemsPhbkDivisionViewLformUserControl = 
                new ObservableCollection<IWebServiceFilterMenuInterface>() {
                    new WebServiceFilterMenu() { Id = "2", Caption="Expand(Collapse)", IconName=IconFont.Aspect_ratio,  IconColor= (Color)Application.Current.Resources["IconButtonPrimaryColor"], Enabled=true, Data="PhbkDivisionViewLformUserControl", Command = OnContainerMenuItemsCommand },
                };
            _FilterHeightPhbkDivisionViewLformUserControl = _GlblSettingsSrv.DefaultFilterHeight("01598-LformUserControl.xaml");
            _GridHeightPhbkDivisionViewLformUserControl = _GlblSettingsSrv.DefaultGridHeight("01598-LformUserControl.xaml");
            //_FilterHeightPhbkDivisionViewLformUserControl = 1 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
            //_GridHeightPhbkDivisionViewLformUserControl = 6 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;

            _ContainerMenuItemsPhbkEmployeeViewLformUserControl = 
                new ObservableCollection<IWebServiceFilterMenuInterface>() {
                    new WebServiceFilterMenu() { Id = "3", Caption="Expand(Collapse)", IconName=IconFont.Aspect_ratio,  IconColor= (Color)Application.Current.Resources["IconButtonPrimaryColor"], Enabled=true, Data="PhbkEmployeeViewLformUserControl", Command = OnContainerMenuItemsCommand },
                };
            _FilterHeightPhbkEmployeeViewLformUserControl = _GlblSettingsSrv.DefaultFilterHeight("01598-LformUserControl.xaml");
            _GridHeightPhbkEmployeeViewLformUserControl = _GlblSettingsSrv.DefaultGridHeight("01598-LformUserControl.xaml");
            //_FilterHeightPhbkEmployeeViewLformUserControl = 1 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
            //_GridHeightPhbkEmployeeViewLformUserControl = 6 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;

            _ContainerMenuItemsPhbkPhoneViewLformUserControl = 
                new ObservableCollection<IWebServiceFilterMenuInterface>() {
                    new WebServiceFilterMenu() { Id = "4", Caption="Expand(Collapse)", IconName=IconFont.Aspect_ratio,  IconColor= (Color)Application.Current.Resources["IconButtonPrimaryColor"], Enabled=true, Data="PhbkPhoneViewLformUserControl", Command = OnContainerMenuItemsCommand },
                };
            _FilterHeightPhbkPhoneViewLformUserControl = _GlblSettingsSrv.DefaultFilterHeight("01598-LformUserControl.xaml");
            _GridHeightPhbkPhoneViewLformUserControl = _GlblSettingsSrv.DefaultGridHeight("01598-LformUserControl.xaml");
            //_FilterHeightPhbkPhoneViewLformUserControl = 1 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
            //_GridHeightPhbkPhoneViewLformUserControl = 6 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;

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
                if ((_GlblSettingsSrv.GetViewModelMask("PhbkPhoneTypeView") & 1) == 1) {
                    await Device.InvokeOnMainThreadAsync(async () =>
                    {
                        uc = _containerProvider.Resolve<ContentView>("PhbkPhoneTypeViewLformUserControl");
                        rm = _regionManager.Regions["PhbkPhoneTypeViewLformUserControlLformsFeatureFtrUserControl"].Add(uc, null, true);
                        _regionManager.Regions["PhbkPhoneTypeViewLformUserControlLformsFeatureFtrUserControl"].Activate(uc);
                        INotifiedByParentInterface nbp = uc as INotifiedByParentInterface;
                        if(nbp != null) {
                                nbp.IsParentLoaded = true;
                        }
                        IsSwitching = true;
                        await Task.Delay(1);
                        IsSwitching = false;
                    });
                } else {
                    _regionManager.RequestNavigate("PhbkPhoneTypeViewLformUserControlLformsFeatureFtrUserControl", "AccessDeniedUserControl", OnNavigationResult);
                    //suc = _containerProvider.Resolve<IScopedRegionNavigationUserControlInterface>();
                    //suc.ScopedRegionManager = _regionManager.Regions["PhbkPhoneTypeViewLformUserControlLformsFeatureFtrUserControl"].Add(suc, null, true);
                    //suc.RequestNavigateSource = "AccessDeniedUserControl";
                    //_regionManager.Regions["PhbkPhoneTypeViewLformUserControlLformsFeatureFtrUserControl"].Activate(suc);
                }
                if ((_GlblSettingsSrv.GetViewModelMask("PhbkEnterpriseView") & 1) == 1) {
                    await Device.InvokeOnMainThreadAsync(async () =>
                    {
                        uc = _containerProvider.Resolve<ContentView>("PhbkEnterpriseViewLformUserControl");
                        rm = _regionManager.Regions["PhbkEnterpriseViewLformUserControlLformsFeatureFtrUserControl"].Add(uc, null, true);
                        _regionManager.Regions["PhbkEnterpriseViewLformUserControlLformsFeatureFtrUserControl"].Activate(uc);
                        INotifiedByParentInterface nbp = uc as INotifiedByParentInterface;
                        if(nbp != null) {
                                nbp.IsParentLoaded = true;
                        }
                        IsSwitching = true;
                        await Task.Delay(1);
                        IsSwitching = false;
                    });
                } else {
                    _regionManager.RequestNavigate("PhbkEnterpriseViewLformUserControlLformsFeatureFtrUserControl", "AccessDeniedUserControl", OnNavigationResult);
                    //suc = _containerProvider.Resolve<IScopedRegionNavigationUserControlInterface>();
                    //suc.ScopedRegionManager = _regionManager.Regions["PhbkEnterpriseViewLformUserControlLformsFeatureFtrUserControl"].Add(suc, null, true);
                    //suc.RequestNavigateSource = "AccessDeniedUserControl";
                    //_regionManager.Regions["PhbkEnterpriseViewLformUserControlLformsFeatureFtrUserControl"].Activate(suc);
                }
                if ((_GlblSettingsSrv.GetViewModelMask("PhbkDivisionView") & 1) == 1) {
                    await Device.InvokeOnMainThreadAsync(async () =>
                    {
                        uc = _containerProvider.Resolve<ContentView>("PhbkDivisionViewLformUserControl");
                        rm = _regionManager.Regions["PhbkDivisionViewLformUserControlLformsFeatureFtrUserControl"].Add(uc, null, true);
                        _regionManager.Regions["PhbkDivisionViewLformUserControlLformsFeatureFtrUserControl"].Activate(uc);
                        INotifiedByParentInterface nbp = uc as INotifiedByParentInterface;
                        if(nbp != null) {
                                nbp.IsParentLoaded = true;
                        }
                        IsSwitching = true;
                        await Task.Delay(1);
                        IsSwitching = false;
                    });
                } else {
                    _regionManager.RequestNavigate("PhbkDivisionViewLformUserControlLformsFeatureFtrUserControl", "AccessDeniedUserControl", OnNavigationResult);
                    //suc = _containerProvider.Resolve<IScopedRegionNavigationUserControlInterface>();
                    //suc.ScopedRegionManager = _regionManager.Regions["PhbkDivisionViewLformUserControlLformsFeatureFtrUserControl"].Add(suc, null, true);
                    //suc.RequestNavigateSource = "AccessDeniedUserControl";
                    //_regionManager.Regions["PhbkDivisionViewLformUserControlLformsFeatureFtrUserControl"].Activate(suc);
                }
                if ((_GlblSettingsSrv.GetViewModelMask("PhbkEmployeeView") & 1) == 1) {
                    await Device.InvokeOnMainThreadAsync(async () =>
                    {
                        uc = _containerProvider.Resolve<ContentView>("PhbkEmployeeViewLformUserControl");
                        rm = _regionManager.Regions["PhbkEmployeeViewLformUserControlLformsFeatureFtrUserControl"].Add(uc, null, true);
                        _regionManager.Regions["PhbkEmployeeViewLformUserControlLformsFeatureFtrUserControl"].Activate(uc);
                        INotifiedByParentInterface nbp = uc as INotifiedByParentInterface;
                        if(nbp != null) {
                                nbp.IsParentLoaded = true;
                        }
                        IsSwitching = true;
                        await Task.Delay(1);
                        IsSwitching = false;
                    });
                } else {
                    _regionManager.RequestNavigate("PhbkEmployeeViewLformUserControlLformsFeatureFtrUserControl", "AccessDeniedUserControl", OnNavigationResult);
                    //suc = _containerProvider.Resolve<IScopedRegionNavigationUserControlInterface>();
                    //suc.ScopedRegionManager = _regionManager.Regions["PhbkEmployeeViewLformUserControlLformsFeatureFtrUserControl"].Add(suc, null, true);
                    //suc.RequestNavigateSource = "AccessDeniedUserControl";
                    //_regionManager.Regions["PhbkEmployeeViewLformUserControlLformsFeatureFtrUserControl"].Activate(suc);
                }
                if ((_GlblSettingsSrv.GetViewModelMask("PhbkPhoneView") & 1) == 1) {
                    await Device.InvokeOnMainThreadAsync(async () =>
                    {
                        uc = _containerProvider.Resolve<ContentView>("PhbkPhoneViewLformUserControl");
                        rm = _regionManager.Regions["PhbkPhoneViewLformUserControlLformsFeatureFtrUserControl"].Add(uc, null, true);
                        _regionManager.Regions["PhbkPhoneViewLformUserControlLformsFeatureFtrUserControl"].Activate(uc);
                        INotifiedByParentInterface nbp = uc as INotifiedByParentInterface;
                        if(nbp != null) {
                                nbp.IsParentLoaded = true;
                        }
                        IsSwitching = true;
                        await Task.Delay(1);
                        IsSwitching = false;
                    });
                } else {
                    _regionManager.RequestNavigate("PhbkPhoneViewLformUserControlLformsFeatureFtrUserControl", "AccessDeniedUserControl", OnNavigationResult);
                    //suc = _containerProvider.Resolve<IScopedRegionNavigationUserControlInterface>();
                    //suc.ScopedRegionManager = _regionManager.Regions["PhbkPhoneViewLformUserControlLformsFeatureFtrUserControl"].Add(suc, null, true);
                    //suc.RequestNavigateSource = "AccessDeniedUserControl";
                    //_regionManager.Regions["PhbkPhoneViewLformUserControlLformsFeatureFtrUserControl"].Activate(suc);
                }
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
                  && _VisiblePhbkPhoneTypeViewLformUserControl
                  && _VisiblePhbkEnterpriseViewLformUserControl
                  && _VisiblePhbkDivisionViewLformUserControl
                  && _VisiblePhbkEmployeeViewLformUserControl
                  && _VisiblePhbkPhoneViewLformUserControl
                ;
            }
        }
        protected bool _VisiblePhbkPhoneTypeViewLformUserControl = true;
        public bool VisiblePhbkPhoneTypeViewLformUserControl
        {
            get
            {
                return _VisiblePhbkPhoneTypeViewLformUserControl;
            }
            set
            {
                if (_VisiblePhbkPhoneTypeViewLformUserControl != value)
                {
                    _VisiblePhbkPhoneTypeViewLformUserControl = value;
                    OnPropertyChanged();
                    OnPropertyChanged("FlexOn");
                }
            }
        }

        protected IEnumerable<IWebServiceFilterMenuInterface> _ContainerMenuItemsPhbkPhoneTypeViewLformUserControl = null;
        public IEnumerable<IWebServiceFilterMenuInterface> ContainerMenuItemsPhbkPhoneTypeViewLformUserControl {
            get { return _ContainerMenuItemsPhbkPhoneTypeViewLformUserControl; }
        }

        protected double _FilterHeightPhbkPhoneTypeViewLformUserControl = -1d;
        public  double FilterHeightPhbkPhoneTypeViewLformUserControl 
        {
            get { return _FilterHeightPhbkPhoneTypeViewLformUserControl; }
            set 
            {
                if(_FilterHeightPhbkPhoneTypeViewLformUserControl != value) {
                    _FilterHeightPhbkPhoneTypeViewLformUserControl = value;
                    OnPropertyChanged();
                }
            }
        }

        protected double _GridHeightPhbkPhoneTypeViewLformUserControl = -1d;
        public  double GridHeightPhbkPhoneTypeViewLformUserControl 
        {
            get { return _GridHeightPhbkPhoneTypeViewLformUserControl; }
            set 
            {
                if(_GridHeightPhbkPhoneTypeViewLformUserControl != value) {
                    _GridHeightPhbkPhoneTypeViewLformUserControl = value;
                    OnPropertyChanged();
                }
            }
        }

        protected bool _VisiblePhbkEnterpriseViewLformUserControl = true;
        public bool VisiblePhbkEnterpriseViewLformUserControl
        {
            get
            {
                return _VisiblePhbkEnterpriseViewLformUserControl;
            }
            set
            {
                if (_VisiblePhbkEnterpriseViewLformUserControl != value)
                {
                    _VisiblePhbkEnterpriseViewLformUserControl = value;
                    OnPropertyChanged();
                    OnPropertyChanged("FlexOn");
                }
            }
        }

        protected IEnumerable<IWebServiceFilterMenuInterface> _ContainerMenuItemsPhbkEnterpriseViewLformUserControl = null;
        public IEnumerable<IWebServiceFilterMenuInterface> ContainerMenuItemsPhbkEnterpriseViewLformUserControl {
            get { return _ContainerMenuItemsPhbkEnterpriseViewLformUserControl; }
        }

        protected double _FilterHeightPhbkEnterpriseViewLformUserControl = -1d;
        public  double FilterHeightPhbkEnterpriseViewLformUserControl 
        {
            get { return _FilterHeightPhbkEnterpriseViewLformUserControl; }
            set 
            {
                if(_FilterHeightPhbkEnterpriseViewLformUserControl != value) {
                    _FilterHeightPhbkEnterpriseViewLformUserControl = value;
                    OnPropertyChanged();
                }
            }
        }

        protected double _GridHeightPhbkEnterpriseViewLformUserControl = -1d;
        public  double GridHeightPhbkEnterpriseViewLformUserControl 
        {
            get { return _GridHeightPhbkEnterpriseViewLformUserControl; }
            set 
            {
                if(_GridHeightPhbkEnterpriseViewLformUserControl != value) {
                    _GridHeightPhbkEnterpriseViewLformUserControl = value;
                    OnPropertyChanged();
                }
            }
        }

        protected bool _VisiblePhbkDivisionViewLformUserControl = true;
        public bool VisiblePhbkDivisionViewLformUserControl
        {
            get
            {
                return _VisiblePhbkDivisionViewLformUserControl;
            }
            set
            {
                if (_VisiblePhbkDivisionViewLformUserControl != value)
                {
                    _VisiblePhbkDivisionViewLformUserControl = value;
                    OnPropertyChanged();
                    OnPropertyChanged("FlexOn");
                }
            }
        }

        protected IEnumerable<IWebServiceFilterMenuInterface> _ContainerMenuItemsPhbkDivisionViewLformUserControl = null;
        public IEnumerable<IWebServiceFilterMenuInterface> ContainerMenuItemsPhbkDivisionViewLformUserControl {
            get { return _ContainerMenuItemsPhbkDivisionViewLformUserControl; }
        }

        protected double _FilterHeightPhbkDivisionViewLformUserControl = -1d;
        public  double FilterHeightPhbkDivisionViewLformUserControl 
        {
            get { return _FilterHeightPhbkDivisionViewLformUserControl; }
            set 
            {
                if(_FilterHeightPhbkDivisionViewLformUserControl != value) {
                    _FilterHeightPhbkDivisionViewLformUserControl = value;
                    OnPropertyChanged();
                }
            }
        }

        protected double _GridHeightPhbkDivisionViewLformUserControl = -1d;
        public  double GridHeightPhbkDivisionViewLformUserControl 
        {
            get { return _GridHeightPhbkDivisionViewLformUserControl; }
            set 
            {
                if(_GridHeightPhbkDivisionViewLformUserControl != value) {
                    _GridHeightPhbkDivisionViewLformUserControl = value;
                    OnPropertyChanged();
                }
            }
        }

        protected bool _VisiblePhbkEmployeeViewLformUserControl = true;
        public bool VisiblePhbkEmployeeViewLformUserControl
        {
            get
            {
                return _VisiblePhbkEmployeeViewLformUserControl;
            }
            set
            {
                if (_VisiblePhbkEmployeeViewLformUserControl != value)
                {
                    _VisiblePhbkEmployeeViewLformUserControl = value;
                    OnPropertyChanged();
                    OnPropertyChanged("FlexOn");
                }
            }
        }

        protected IEnumerable<IWebServiceFilterMenuInterface> _ContainerMenuItemsPhbkEmployeeViewLformUserControl = null;
        public IEnumerable<IWebServiceFilterMenuInterface> ContainerMenuItemsPhbkEmployeeViewLformUserControl {
            get { return _ContainerMenuItemsPhbkEmployeeViewLformUserControl; }
        }

        protected double _FilterHeightPhbkEmployeeViewLformUserControl = -1d;
        public  double FilterHeightPhbkEmployeeViewLformUserControl 
        {
            get { return _FilterHeightPhbkEmployeeViewLformUserControl; }
            set 
            {
                if(_FilterHeightPhbkEmployeeViewLformUserControl != value) {
                    _FilterHeightPhbkEmployeeViewLformUserControl = value;
                    OnPropertyChanged();
                }
            }
        }

        protected double _GridHeightPhbkEmployeeViewLformUserControl = -1d;
        public  double GridHeightPhbkEmployeeViewLformUserControl 
        {
            get { return _GridHeightPhbkEmployeeViewLformUserControl; }
            set 
            {
                if(_GridHeightPhbkEmployeeViewLformUserControl != value) {
                    _GridHeightPhbkEmployeeViewLformUserControl = value;
                    OnPropertyChanged();
                }
            }
        }

        protected bool _VisiblePhbkPhoneViewLformUserControl = true;
        public bool VisiblePhbkPhoneViewLformUserControl
        {
            get
            {
                return _VisiblePhbkPhoneViewLformUserControl;
            }
            set
            {
                if (_VisiblePhbkPhoneViewLformUserControl != value)
                {
                    _VisiblePhbkPhoneViewLformUserControl = value;
                    OnPropertyChanged();
                    OnPropertyChanged("FlexOn");
                }
            }
        }

        protected IEnumerable<IWebServiceFilterMenuInterface> _ContainerMenuItemsPhbkPhoneViewLformUserControl = null;
        public IEnumerable<IWebServiceFilterMenuInterface> ContainerMenuItemsPhbkPhoneViewLformUserControl {
            get { return _ContainerMenuItemsPhbkPhoneViewLformUserControl; }
        }

        protected double _FilterHeightPhbkPhoneViewLformUserControl = -1d;
        public  double FilterHeightPhbkPhoneViewLformUserControl 
        {
            get { return _FilterHeightPhbkPhoneViewLformUserControl; }
            set 
            {
                if(_FilterHeightPhbkPhoneViewLformUserControl != value) {
                    _FilterHeightPhbkPhoneViewLformUserControl = value;
                    OnPropertyChanged();
                }
            }
        }

        protected double _GridHeightPhbkPhoneViewLformUserControl = -1d;
        public  double GridHeightPhbkPhoneViewLformUserControl 
        {
            get { return _GridHeightPhbkPhoneViewLformUserControl; }
            set 
            {
                if(_GridHeightPhbkPhoneViewLformUserControl != value) {
                    _GridHeightPhbkPhoneViewLformUserControl = value;
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
            _VisiblePhbkPhoneTypeViewLformUserControl = !IsAllCollapsed; OnPropertyChanged("VisiblePhbkPhoneTypeViewLformUserControl");
            FilterHeightPhbkPhoneTypeViewLformUserControl = _GlblSettingsSrv.DefaultFilterHeight("01598-LformUserControl.xaml");
                // 1 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
            GridHeightPhbkPhoneTypeViewLformUserControl = _GlblSettingsSrv.DefaultGridHeight("01598-LformUserControl.xaml");
                // 6 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;
            _VisiblePhbkEnterpriseViewLformUserControl = !IsAllCollapsed; OnPropertyChanged("VisiblePhbkEnterpriseViewLformUserControl");
            FilterHeightPhbkEnterpriseViewLformUserControl = _GlblSettingsSrv.DefaultFilterHeight("01598-LformUserControl.xaml");
                // 1 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
            GridHeightPhbkEnterpriseViewLformUserControl = _GlblSettingsSrv.DefaultGridHeight("01598-LformUserControl.xaml");
                // 6 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;
            _VisiblePhbkDivisionViewLformUserControl = !IsAllCollapsed; OnPropertyChanged("VisiblePhbkDivisionViewLformUserControl");
            FilterHeightPhbkDivisionViewLformUserControl = _GlblSettingsSrv.DefaultFilterHeight("01598-LformUserControl.xaml");
                // 1 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
            GridHeightPhbkDivisionViewLformUserControl = _GlblSettingsSrv.DefaultGridHeight("01598-LformUserControl.xaml");
                // 6 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;
            _VisiblePhbkEmployeeViewLformUserControl = !IsAllCollapsed; OnPropertyChanged("VisiblePhbkEmployeeViewLformUserControl");
            FilterHeightPhbkEmployeeViewLformUserControl = _GlblSettingsSrv.DefaultFilterHeight("01598-LformUserControl.xaml");
                // 1 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
            GridHeightPhbkEmployeeViewLformUserControl = _GlblSettingsSrv.DefaultGridHeight("01598-LformUserControl.xaml");
                // 6 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;
            _VisiblePhbkPhoneViewLformUserControl = !IsAllCollapsed; OnPropertyChanged("VisiblePhbkPhoneViewLformUserControl");
            FilterHeightPhbkPhoneViewLformUserControl = _GlblSettingsSrv.DefaultFilterHeight("01598-LformUserControl.xaml");
                // 1 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
            GridHeightPhbkPhoneViewLformUserControl = _GlblSettingsSrv.DefaultGridHeight("01598-LformUserControl.xaml");
                // 6 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;
            if (IsAllCollapsed) {
                switch(modelName) {
                    case "PhbkPhoneTypeViewLformUserControl": 
                        _VisiblePhbkPhoneTypeViewLformUserControl = true; OnPropertyChanged("VisiblePhbkPhoneTypeViewLformUserControl");
                        FilterHeightPhbkPhoneTypeViewLformUserControl = _GlblSettingsSrv.ExpandedFilterHeight("01598-LformUserControl.xaml");
                            // 2 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
                        GridHeightPhbkPhoneTypeViewLformUserControl = _GlblSettingsSrv.ExpandedGridHeight("01598-LformUserControl.xaml");
                            // 19 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;
                        break;
                    case "PhbkEnterpriseViewLformUserControl": 
                        _VisiblePhbkEnterpriseViewLformUserControl = true; OnPropertyChanged("VisiblePhbkEnterpriseViewLformUserControl");
                        FilterHeightPhbkEnterpriseViewLformUserControl = _GlblSettingsSrv.ExpandedFilterHeight("01598-LformUserControl.xaml");
                            // 2 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
                        GridHeightPhbkEnterpriseViewLformUserControl = _GlblSettingsSrv.ExpandedGridHeight("01598-LformUserControl.xaml");
                            // 19 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;
                        break;
                    case "PhbkDivisionViewLformUserControl": 
                        _VisiblePhbkDivisionViewLformUserControl = true; OnPropertyChanged("VisiblePhbkDivisionViewLformUserControl");
                        FilterHeightPhbkDivisionViewLformUserControl = _GlblSettingsSrv.ExpandedFilterHeight("01598-LformUserControl.xaml");
                            // 2 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
                        GridHeightPhbkDivisionViewLformUserControl = _GlblSettingsSrv.ExpandedGridHeight("01598-LformUserControl.xaml");
                            // 19 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;
                        break;
                    case "PhbkEmployeeViewLformUserControl": 
                        _VisiblePhbkEmployeeViewLformUserControl = true; OnPropertyChanged("VisiblePhbkEmployeeViewLformUserControl");
                        FilterHeightPhbkEmployeeViewLformUserControl = _GlblSettingsSrv.ExpandedFilterHeight("01598-LformUserControl.xaml");
                            // 2 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
                        GridHeightPhbkEmployeeViewLformUserControl = _GlblSettingsSrv.ExpandedGridHeight("01598-LformUserControl.xaml");
                            // 19 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;
                        break;
                    case "PhbkPhoneViewLformUserControl": 
                        _VisiblePhbkPhoneViewLformUserControl = true; OnPropertyChanged("VisiblePhbkPhoneViewLformUserControl");
                        FilterHeightPhbkPhoneViewLformUserControl = _GlblSettingsSrv.ExpandedFilterHeight("01598-LformUserControl.xaml");
                            // 2 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
                        GridHeightPhbkPhoneViewLformUserControl = _GlblSettingsSrv.ExpandedGridHeight("01598-LformUserControl.xaml");
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
            _ContainerMenuItemsPhbkPhoneTypeViewLformUserControl = null;
            _ContainerMenuItemsPhbkEnterpriseViewLformUserControl = null;
            _ContainerMenuItemsPhbkDivisionViewLformUserControl = null;
            _ContainerMenuItemsPhbkEmployeeViewLformUserControl = null;
            _ContainerMenuItemsPhbkPhoneViewLformUserControl = null;
        }
        #endregion

    }
}

