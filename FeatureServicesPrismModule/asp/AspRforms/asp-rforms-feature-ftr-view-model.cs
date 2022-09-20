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

    "AspRformsFeatureFtrViewModel" UserControl is defined in the "FeatureServicesPrismModule"-project.
    In the file of IModule-class of "FeatureServicesPrismModule"-project the following line of code must be inserted:

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ...
            // According to requirements of the "AspRformsFeatureFtrViewModel.cs"-file of "FeatureServicesPrismModule"-project. 
            ViewModelLocationProvider.Register<AspRformsFeatureFtrUserControl, AspRformsFeatureFtrViewModel>();
            // According to requirements of the "AspRformsFeatureFtrViewModel.cs"-file of "FeatureServicesPrismModule"-project. 
            containerRegistry.RegisterForNavigation<AspRformsFeatureFtrUserControl, AspRformsFeatureFtrViewModel>("AspRformsFeatureFtrUserControl");
            ...
        }

*/

namespace FeatureServicesPrismModule.asp.AspRforms {
    public class AspRformsFeatureFtrViewModel : INotifyPropertyChanged, INavigationAware, IDestructible 
    {
        IRegionManager _regionManager;
        IContainerProvider _containerProvider;
        protected IAppGlblSettingsService _GlblSettingsSrv;
        public AspRformsFeatureFtrViewModel(IAppGlblSettingsService GlblSettingsSrv, IRegionManager regionManager, IContainerProvider containerProvider) {
            _regionManager = regionManager;
            _containerProvider = containerProvider;
            _GlblSettingsSrv = GlblSettingsSrv;

            _ContainerMenuItemsAspnetmodelViewRlistUserControl = 
                new ObservableCollection<IWebServiceFilterMenuInterface>() {
                    new WebServiceFilterMenu() { Id = "0", Caption="Expand(Collapse)", IconName=IconFont.Aspect_ratio,  IconColor= (Color)Application.Current.Resources["IconButtonPrimaryColor"], Enabled=true, Data="AspnetmodelViewRlistUserControl", Command = OnContainerMenuItemsCommand },
                };
            _FilterHeightAspnetmodelViewRlistUserControl = _GlblSettingsSrv.DefaultFilterHeight("01918-RlistUserControl.xaml");
            _GridHeightAspnetmodelViewRlistUserControl = _GlblSettingsSrv.DefaultGridHeight("01918-RlistUserControl.xaml");
            //_FilterHeightAspnetmodelViewRlistUserControl = 1 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
            //_GridHeightAspnetmodelViewRlistUserControl = 6 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;

            _ContainerMenuItemsAspnetmodelViewRdlistUserControl = 
                new ObservableCollection<IWebServiceFilterMenuInterface>() {
                    new WebServiceFilterMenu() { Id = "1", Caption="Expand(Collapse)", IconName=IconFont.Aspect_ratio,  IconColor= (Color)Application.Current.Resources["IconButtonPrimaryColor"], Enabled=true, Data="AspnetmodelViewRdlistUserControl", Command = OnContainerMenuItemsCommand },
                };
            _FilterHeightAspnetmodelViewRdlistUserControl = _GlblSettingsSrv.DefaultFilterHeight("02018-RdlistUserControl.xaml");
            _GridHeightAspnetmodelViewRdlistUserControl = _GlblSettingsSrv.DefaultGridHeight("02018-RdlistUserControl.xaml");
            //_FilterHeightAspnetmodelViewRdlistUserControl = 1 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
            //_GridHeightAspnetmodelViewRdlistUserControl = 6 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;

            _ContainerMenuItemsAspnetroleViewRlistUserControl = 
                new ObservableCollection<IWebServiceFilterMenuInterface>() {
                    new WebServiceFilterMenu() { Id = "2", Caption="Expand(Collapse)", IconName=IconFont.Aspect_ratio,  IconColor= (Color)Application.Current.Resources["IconButtonPrimaryColor"], Enabled=true, Data="AspnetroleViewRlistUserControl", Command = OnContainerMenuItemsCommand },
                };
            _FilterHeightAspnetroleViewRlistUserControl = _GlblSettingsSrv.DefaultFilterHeight("01918-RlistUserControl.xaml");
            _GridHeightAspnetroleViewRlistUserControl = _GlblSettingsSrv.DefaultGridHeight("01918-RlistUserControl.xaml");
            //_FilterHeightAspnetroleViewRlistUserControl = 1 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
            //_GridHeightAspnetroleViewRlistUserControl = 6 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;

            _ContainerMenuItemsAspnetroleViewRdlistUserControl = 
                new ObservableCollection<IWebServiceFilterMenuInterface>() {
                    new WebServiceFilterMenu() { Id = "3", Caption="Expand(Collapse)", IconName=IconFont.Aspect_ratio,  IconColor= (Color)Application.Current.Resources["IconButtonPrimaryColor"], Enabled=true, Data="AspnetroleViewRdlistUserControl", Command = OnContainerMenuItemsCommand },
                };
            _FilterHeightAspnetroleViewRdlistUserControl = _GlblSettingsSrv.DefaultFilterHeight("02018-RdlistUserControl.xaml");
            _GridHeightAspnetroleViewRdlistUserControl = _GlblSettingsSrv.DefaultGridHeight("02018-RdlistUserControl.xaml");
            //_FilterHeightAspnetroleViewRdlistUserControl = 1 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
            //_GridHeightAspnetroleViewRdlistUserControl = 6 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;

            _ContainerMenuItemsAspnetuserViewRlistUserControl = 
                new ObservableCollection<IWebServiceFilterMenuInterface>() {
                    new WebServiceFilterMenu() { Id = "4", Caption="Expand(Collapse)", IconName=IconFont.Aspect_ratio,  IconColor= (Color)Application.Current.Resources["IconButtonPrimaryColor"], Enabled=true, Data="AspnetuserViewRlistUserControl", Command = OnContainerMenuItemsCommand },
                };
            _FilterHeightAspnetuserViewRlistUserControl = _GlblSettingsSrv.DefaultFilterHeight("01918-RlistUserControl.xaml");
            _GridHeightAspnetuserViewRlistUserControl = _GlblSettingsSrv.DefaultGridHeight("01918-RlistUserControl.xaml");
            //_FilterHeightAspnetuserViewRlistUserControl = 1 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
            //_GridHeightAspnetuserViewRlistUserControl = 6 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;

            _ContainerMenuItemsAspnetuserViewRdlistUserControl = 
                new ObservableCollection<IWebServiceFilterMenuInterface>() {
                    new WebServiceFilterMenu() { Id = "5", Caption="Expand(Collapse)", IconName=IconFont.Aspect_ratio,  IconColor= (Color)Application.Current.Resources["IconButtonPrimaryColor"], Enabled=true, Data="AspnetuserViewRdlistUserControl", Command = OnContainerMenuItemsCommand },
                };
            _FilterHeightAspnetuserViewRdlistUserControl = _GlblSettingsSrv.DefaultFilterHeight("02018-RdlistUserControl.xaml");
            _GridHeightAspnetuserViewRdlistUserControl = _GlblSettingsSrv.DefaultGridHeight("02018-RdlistUserControl.xaml");
            //_FilterHeightAspnetuserViewRdlistUserControl = 1 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
            //_GridHeightAspnetuserViewRdlistUserControl = 6 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;

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
                //suc.ScopedRegionManager = _regionManager.Regions["AspnetmodelViewRlistUserControlAspRformsFeatureFtrUserControl"].Add(suc, null, true);
                //suc.RequestNavigateSource = "AspnetmodelViewRlistUserControl";
                //_regionManager.Regions["AspnetmodelViewRlistUserControlAspRformsFeatureFtrUserControl"].Activate(suc);
                await Device.InvokeOnMainThreadAsync(async () =>
                {
                    _regionManager.RequestNavigate("AspnetmodelViewRlistUserControlAspRformsFeatureFtrUserControl", "AspnetmodelViewRlistUserControl", OnNavigationResult);
                    IsSwitching = true;
                    await Task.Delay(1);
                    IsSwitching = false;
                });
                //suc = _containerProvider.Resolve<IScopedRegionNavigationUserControlInterface>();
                //suc.ScopedRegionManager = _regionManager.Regions["AspnetmodelViewRdlistUserControlAspRformsFeatureFtrUserControl"].Add(suc, null, true);
                //suc.RequestNavigateSource = "AspnetmodelViewRdlistUserControl";
                //_regionManager.Regions["AspnetmodelViewRdlistUserControlAspRformsFeatureFtrUserControl"].Activate(suc);
                await Device.InvokeOnMainThreadAsync(async () =>
                {
                    _regionManager.RequestNavigate("AspnetmodelViewRdlistUserControlAspRformsFeatureFtrUserControl", "AspnetmodelViewRdlistUserControl", OnNavigationResult);
                    IsSwitching = true;
                    await Task.Delay(1);
                    IsSwitching = false;
                });
                //suc = _containerProvider.Resolve<IScopedRegionNavigationUserControlInterface>();
                //suc.ScopedRegionManager = _regionManager.Regions["AspnetroleViewRlistUserControlAspRformsFeatureFtrUserControl"].Add(suc, null, true);
                //suc.RequestNavigateSource = "AspnetroleViewRlistUserControl";
                //_regionManager.Regions["AspnetroleViewRlistUserControlAspRformsFeatureFtrUserControl"].Activate(suc);
                await Device.InvokeOnMainThreadAsync(async () =>
                {
                    _regionManager.RequestNavigate("AspnetroleViewRlistUserControlAspRformsFeatureFtrUserControl", "AspnetroleViewRlistUserControl", OnNavigationResult);
                    IsSwitching = true;
                    await Task.Delay(1);
                    IsSwitching = false;
                });
                //suc = _containerProvider.Resolve<IScopedRegionNavigationUserControlInterface>();
                //suc.ScopedRegionManager = _regionManager.Regions["AspnetroleViewRdlistUserControlAspRformsFeatureFtrUserControl"].Add(suc, null, true);
                //suc.RequestNavigateSource = "AspnetroleViewRdlistUserControl";
                //_regionManager.Regions["AspnetroleViewRdlistUserControlAspRformsFeatureFtrUserControl"].Activate(suc);
                await Device.InvokeOnMainThreadAsync(async () =>
                {
                    _regionManager.RequestNavigate("AspnetroleViewRdlistUserControlAspRformsFeatureFtrUserControl", "AspnetroleViewRdlistUserControl", OnNavigationResult);
                    IsSwitching = true;
                    await Task.Delay(1);
                    IsSwitching = false;
                });
                //suc = _containerProvider.Resolve<IScopedRegionNavigationUserControlInterface>();
                //suc.ScopedRegionManager = _regionManager.Regions["AspnetuserViewRlistUserControlAspRformsFeatureFtrUserControl"].Add(suc, null, true);
                //suc.RequestNavigateSource = "AspnetuserViewRlistUserControl";
                //_regionManager.Regions["AspnetuserViewRlistUserControlAspRformsFeatureFtrUserControl"].Activate(suc);
                await Device.InvokeOnMainThreadAsync(async () =>
                {
                    _regionManager.RequestNavigate("AspnetuserViewRlistUserControlAspRformsFeatureFtrUserControl", "AspnetuserViewRlistUserControl", OnNavigationResult);
                    IsSwitching = true;
                    await Task.Delay(1);
                    IsSwitching = false;
                });
                //suc = _containerProvider.Resolve<IScopedRegionNavigationUserControlInterface>();
                //suc.ScopedRegionManager = _regionManager.Regions["AspnetuserViewRdlistUserControlAspRformsFeatureFtrUserControl"].Add(suc, null, true);
                //suc.RequestNavigateSource = "AspnetuserViewRdlistUserControl";
                //_regionManager.Regions["AspnetuserViewRdlistUserControlAspRformsFeatureFtrUserControl"].Activate(suc);
                await Device.InvokeOnMainThreadAsync(async () =>
                {
                    _regionManager.RequestNavigate("AspnetuserViewRdlistUserControlAspRformsFeatureFtrUserControl", "AspnetuserViewRdlistUserControl", OnNavigationResult);
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
                  && _VisibleAspnetmodelViewRlistUserControl
                  && _VisibleAspnetmodelViewRdlistUserControl
                  && _VisibleAspnetroleViewRlistUserControl
                  && _VisibleAspnetroleViewRdlistUserControl
                  && _VisibleAspnetuserViewRlistUserControl
                  && _VisibleAspnetuserViewRdlistUserControl
                ;
            }
        }
        protected bool _VisibleAspnetmodelViewRlistUserControl = true;
        public bool VisibleAspnetmodelViewRlistUserControl
        {
            get
            {
                return _VisibleAspnetmodelViewRlistUserControl;
            }
            set
            {
                if (_VisibleAspnetmodelViewRlistUserControl != value)
                {
                    _VisibleAspnetmodelViewRlistUserControl = value;
                    OnPropertyChanged();
                    OnPropertyChanged("FlexOn");
                }
            }
        }

        protected IEnumerable<IWebServiceFilterMenuInterface> _ContainerMenuItemsAspnetmodelViewRlistUserControl = null;
        public IEnumerable<IWebServiceFilterMenuInterface> ContainerMenuItemsAspnetmodelViewRlistUserControl {
            get { return _ContainerMenuItemsAspnetmodelViewRlistUserControl; }
        }

        protected double _FilterHeightAspnetmodelViewRlistUserControl = -1d;
        public  double FilterHeightAspnetmodelViewRlistUserControl 
        {
            get { return _FilterHeightAspnetmodelViewRlistUserControl; }
            set 
            {
                if(_FilterHeightAspnetmodelViewRlistUserControl != value) {
                    _FilterHeightAspnetmodelViewRlistUserControl = value;
                    OnPropertyChanged();
                }
            }
        }

        protected double _GridHeightAspnetmodelViewRlistUserControl = -1d;
        public  double GridHeightAspnetmodelViewRlistUserControl 
        {
            get { return _GridHeightAspnetmodelViewRlistUserControl; }
            set 
            {
                if(_GridHeightAspnetmodelViewRlistUserControl != value) {
                    _GridHeightAspnetmodelViewRlistUserControl = value;
                    OnPropertyChanged();
                }
            }
        }

        protected bool _VisibleAspnetmodelViewRdlistUserControl = true;
        public bool VisibleAspnetmodelViewRdlistUserControl
        {
            get
            {
                return _VisibleAspnetmodelViewRdlistUserControl;
            }
            set
            {
                if (_VisibleAspnetmodelViewRdlistUserControl != value)
                {
                    _VisibleAspnetmodelViewRdlistUserControl = value;
                    OnPropertyChanged();
                    OnPropertyChanged("FlexOn");
                }
            }
        }

        protected IEnumerable<IWebServiceFilterMenuInterface> _ContainerMenuItemsAspnetmodelViewRdlistUserControl = null;
        public IEnumerable<IWebServiceFilterMenuInterface> ContainerMenuItemsAspnetmodelViewRdlistUserControl {
            get { return _ContainerMenuItemsAspnetmodelViewRdlistUserControl; }
        }

        protected double _FilterHeightAspnetmodelViewRdlistUserControl = -1d;
        public  double FilterHeightAspnetmodelViewRdlistUserControl 
        {
            get { return _FilterHeightAspnetmodelViewRdlistUserControl; }
            set 
            {
                if(_FilterHeightAspnetmodelViewRdlistUserControl != value) {
                    _FilterHeightAspnetmodelViewRdlistUserControl = value;
                    OnPropertyChanged();
                }
            }
        }

        protected double _GridHeightAspnetmodelViewRdlistUserControl = -1d;
        public  double GridHeightAspnetmodelViewRdlistUserControl 
        {
            get { return _GridHeightAspnetmodelViewRdlistUserControl; }
            set 
            {
                if(_GridHeightAspnetmodelViewRdlistUserControl != value) {
                    _GridHeightAspnetmodelViewRdlistUserControl = value;
                    OnPropertyChanged();
                }
            }
        }

        protected bool _VisibleAspnetroleViewRlistUserControl = true;
        public bool VisibleAspnetroleViewRlistUserControl
        {
            get
            {
                return _VisibleAspnetroleViewRlistUserControl;
            }
            set
            {
                if (_VisibleAspnetroleViewRlistUserControl != value)
                {
                    _VisibleAspnetroleViewRlistUserControl = value;
                    OnPropertyChanged();
                    OnPropertyChanged("FlexOn");
                }
            }
        }

        protected IEnumerable<IWebServiceFilterMenuInterface> _ContainerMenuItemsAspnetroleViewRlistUserControl = null;
        public IEnumerable<IWebServiceFilterMenuInterface> ContainerMenuItemsAspnetroleViewRlistUserControl {
            get { return _ContainerMenuItemsAspnetroleViewRlistUserControl; }
        }

        protected double _FilterHeightAspnetroleViewRlistUserControl = -1d;
        public  double FilterHeightAspnetroleViewRlistUserControl 
        {
            get { return _FilterHeightAspnetroleViewRlistUserControl; }
            set 
            {
                if(_FilterHeightAspnetroleViewRlistUserControl != value) {
                    _FilterHeightAspnetroleViewRlistUserControl = value;
                    OnPropertyChanged();
                }
            }
        }

        protected double _GridHeightAspnetroleViewRlistUserControl = -1d;
        public  double GridHeightAspnetroleViewRlistUserControl 
        {
            get { return _GridHeightAspnetroleViewRlistUserControl; }
            set 
            {
                if(_GridHeightAspnetroleViewRlistUserControl != value) {
                    _GridHeightAspnetroleViewRlistUserControl = value;
                    OnPropertyChanged();
                }
            }
        }

        protected bool _VisibleAspnetroleViewRdlistUserControl = true;
        public bool VisibleAspnetroleViewRdlistUserControl
        {
            get
            {
                return _VisibleAspnetroleViewRdlistUserControl;
            }
            set
            {
                if (_VisibleAspnetroleViewRdlistUserControl != value)
                {
                    _VisibleAspnetroleViewRdlistUserControl = value;
                    OnPropertyChanged();
                    OnPropertyChanged("FlexOn");
                }
            }
        }

        protected IEnumerable<IWebServiceFilterMenuInterface> _ContainerMenuItemsAspnetroleViewRdlistUserControl = null;
        public IEnumerable<IWebServiceFilterMenuInterface> ContainerMenuItemsAspnetroleViewRdlistUserControl {
            get { return _ContainerMenuItemsAspnetroleViewRdlistUserControl; }
        }

        protected double _FilterHeightAspnetroleViewRdlistUserControl = -1d;
        public  double FilterHeightAspnetroleViewRdlistUserControl 
        {
            get { return _FilterHeightAspnetroleViewRdlistUserControl; }
            set 
            {
                if(_FilterHeightAspnetroleViewRdlistUserControl != value) {
                    _FilterHeightAspnetroleViewRdlistUserControl = value;
                    OnPropertyChanged();
                }
            }
        }

        protected double _GridHeightAspnetroleViewRdlistUserControl = -1d;
        public  double GridHeightAspnetroleViewRdlistUserControl 
        {
            get { return _GridHeightAspnetroleViewRdlistUserControl; }
            set 
            {
                if(_GridHeightAspnetroleViewRdlistUserControl != value) {
                    _GridHeightAspnetroleViewRdlistUserControl = value;
                    OnPropertyChanged();
                }
            }
        }

        protected bool _VisibleAspnetuserViewRlistUserControl = true;
        public bool VisibleAspnetuserViewRlistUserControl
        {
            get
            {
                return _VisibleAspnetuserViewRlistUserControl;
            }
            set
            {
                if (_VisibleAspnetuserViewRlistUserControl != value)
                {
                    _VisibleAspnetuserViewRlistUserControl = value;
                    OnPropertyChanged();
                    OnPropertyChanged("FlexOn");
                }
            }
        }

        protected IEnumerable<IWebServiceFilterMenuInterface> _ContainerMenuItemsAspnetuserViewRlistUserControl = null;
        public IEnumerable<IWebServiceFilterMenuInterface> ContainerMenuItemsAspnetuserViewRlistUserControl {
            get { return _ContainerMenuItemsAspnetuserViewRlistUserControl; }
        }

        protected double _FilterHeightAspnetuserViewRlistUserControl = -1d;
        public  double FilterHeightAspnetuserViewRlistUserControl 
        {
            get { return _FilterHeightAspnetuserViewRlistUserControl; }
            set 
            {
                if(_FilterHeightAspnetuserViewRlistUserControl != value) {
                    _FilterHeightAspnetuserViewRlistUserControl = value;
                    OnPropertyChanged();
                }
            }
        }

        protected double _GridHeightAspnetuserViewRlistUserControl = -1d;
        public  double GridHeightAspnetuserViewRlistUserControl 
        {
            get { return _GridHeightAspnetuserViewRlistUserControl; }
            set 
            {
                if(_GridHeightAspnetuserViewRlistUserControl != value) {
                    _GridHeightAspnetuserViewRlistUserControl = value;
                    OnPropertyChanged();
                }
            }
        }

        protected bool _VisibleAspnetuserViewRdlistUserControl = true;
        public bool VisibleAspnetuserViewRdlistUserControl
        {
            get
            {
                return _VisibleAspnetuserViewRdlistUserControl;
            }
            set
            {
                if (_VisibleAspnetuserViewRdlistUserControl != value)
                {
                    _VisibleAspnetuserViewRdlistUserControl = value;
                    OnPropertyChanged();
                    OnPropertyChanged("FlexOn");
                }
            }
        }

        protected IEnumerable<IWebServiceFilterMenuInterface> _ContainerMenuItemsAspnetuserViewRdlistUserControl = null;
        public IEnumerable<IWebServiceFilterMenuInterface> ContainerMenuItemsAspnetuserViewRdlistUserControl {
            get { return _ContainerMenuItemsAspnetuserViewRdlistUserControl; }
        }

        protected double _FilterHeightAspnetuserViewRdlistUserControl = -1d;
        public  double FilterHeightAspnetuserViewRdlistUserControl 
        {
            get { return _FilterHeightAspnetuserViewRdlistUserControl; }
            set 
            {
                if(_FilterHeightAspnetuserViewRdlistUserControl != value) {
                    _FilterHeightAspnetuserViewRdlistUserControl = value;
                    OnPropertyChanged();
                }
            }
        }

        protected double _GridHeightAspnetuserViewRdlistUserControl = -1d;
        public  double GridHeightAspnetuserViewRdlistUserControl 
        {
            get { return _GridHeightAspnetuserViewRdlistUserControl; }
            set 
            {
                if(_GridHeightAspnetuserViewRdlistUserControl != value) {
                    _GridHeightAspnetuserViewRdlistUserControl = value;
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
            _VisibleAspnetmodelViewRlistUserControl = !IsAllCollapsed; OnPropertyChanged("VisibleAspnetmodelViewRlistUserControl");
            FilterHeightAspnetmodelViewRlistUserControl = _GlblSettingsSrv.DefaultFilterHeight("01918-RlistUserControl.xaml");
                // 1 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
            GridHeightAspnetmodelViewRlistUserControl = _GlblSettingsSrv.DefaultGridHeight("01918-RlistUserControl.xaml");
                // 6 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;
            _VisibleAspnetmodelViewRdlistUserControl = !IsAllCollapsed; OnPropertyChanged("VisibleAspnetmodelViewRdlistUserControl");
            FilterHeightAspnetmodelViewRdlistUserControl = _GlblSettingsSrv.DefaultFilterHeight("02018-RdlistUserControl.xaml");
                // 1 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
            GridHeightAspnetmodelViewRdlistUserControl = _GlblSettingsSrv.DefaultGridHeight("02018-RdlistUserControl.xaml");
                // 6 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;
            _VisibleAspnetroleViewRlistUserControl = !IsAllCollapsed; OnPropertyChanged("VisibleAspnetroleViewRlistUserControl");
            FilterHeightAspnetroleViewRlistUserControl = _GlblSettingsSrv.DefaultFilterHeight("01918-RlistUserControl.xaml");
                // 1 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
            GridHeightAspnetroleViewRlistUserControl = _GlblSettingsSrv.DefaultGridHeight("01918-RlistUserControl.xaml");
                // 6 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;
            _VisibleAspnetroleViewRdlistUserControl = !IsAllCollapsed; OnPropertyChanged("VisibleAspnetroleViewRdlistUserControl");
            FilterHeightAspnetroleViewRdlistUserControl = _GlblSettingsSrv.DefaultFilterHeight("02018-RdlistUserControl.xaml");
                // 1 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
            GridHeightAspnetroleViewRdlistUserControl = _GlblSettingsSrv.DefaultGridHeight("02018-RdlistUserControl.xaml");
                // 6 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;
            _VisibleAspnetuserViewRlistUserControl = !IsAllCollapsed; OnPropertyChanged("VisibleAspnetuserViewRlistUserControl");
            FilterHeightAspnetuserViewRlistUserControl = _GlblSettingsSrv.DefaultFilterHeight("01918-RlistUserControl.xaml");
                // 1 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
            GridHeightAspnetuserViewRlistUserControl = _GlblSettingsSrv.DefaultGridHeight("01918-RlistUserControl.xaml");
                // 6 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;
            _VisibleAspnetuserViewRdlistUserControl = !IsAllCollapsed; OnPropertyChanged("VisibleAspnetuserViewRdlistUserControl");
            FilterHeightAspnetuserViewRdlistUserControl = _GlblSettingsSrv.DefaultFilterHeight("02018-RdlistUserControl.xaml");
                // 1 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
            GridHeightAspnetuserViewRdlistUserControl = _GlblSettingsSrv.DefaultGridHeight("02018-RdlistUserControl.xaml");
                // 6 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;
            if (IsAllCollapsed) {
                switch(modelName) {
                    case "AspnetmodelViewRlistUserControl": 
                        _VisibleAspnetmodelViewRlistUserControl = true; OnPropertyChanged("VisibleAspnetmodelViewRlistUserControl");
                        FilterHeightAspnetmodelViewRlistUserControl = _GlblSettingsSrv.ExpandedFilterHeight("01918-RlistUserControl.xaml");
                            // 2 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
                        GridHeightAspnetmodelViewRlistUserControl = _GlblSettingsSrv.ExpandedGridHeight("01918-RlistUserControl.xaml");
                            // 19 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;
                        break;
                    case "AspnetmodelViewRdlistUserControl": 
                        _VisibleAspnetmodelViewRdlistUserControl = true; OnPropertyChanged("VisibleAspnetmodelViewRdlistUserControl");
                        FilterHeightAspnetmodelViewRdlistUserControl = _GlblSettingsSrv.ExpandedFilterHeight("02018-RdlistUserControl.xaml");
                            // 2 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
                        GridHeightAspnetmodelViewRdlistUserControl = _GlblSettingsSrv.ExpandedGridHeight("02018-RdlistUserControl.xaml");
                            // 19 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;
                        break;
                    case "AspnetroleViewRlistUserControl": 
                        _VisibleAspnetroleViewRlistUserControl = true; OnPropertyChanged("VisibleAspnetroleViewRlistUserControl");
                        FilterHeightAspnetroleViewRlistUserControl = _GlblSettingsSrv.ExpandedFilterHeight("01918-RlistUserControl.xaml");
                            // 2 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
                        GridHeightAspnetroleViewRlistUserControl = _GlblSettingsSrv.ExpandedGridHeight("01918-RlistUserControl.xaml");
                            // 19 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;
                        break;
                    case "AspnetroleViewRdlistUserControl": 
                        _VisibleAspnetroleViewRdlistUserControl = true; OnPropertyChanged("VisibleAspnetroleViewRdlistUserControl");
                        FilterHeightAspnetroleViewRdlistUserControl = _GlblSettingsSrv.ExpandedFilterHeight("02018-RdlistUserControl.xaml");
                            // 2 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
                        GridHeightAspnetroleViewRdlistUserControl = _GlblSettingsSrv.ExpandedGridHeight("02018-RdlistUserControl.xaml");
                            // 19 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;
                        break;
                    case "AspnetuserViewRlistUserControl": 
                        _VisibleAspnetuserViewRlistUserControl = true; OnPropertyChanged("VisibleAspnetuserViewRlistUserControl");
                        FilterHeightAspnetuserViewRlistUserControl = _GlblSettingsSrv.ExpandedFilterHeight("01918-RlistUserControl.xaml");
                            // 2 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
                        GridHeightAspnetuserViewRlistUserControl = _GlblSettingsSrv.ExpandedGridHeight("01918-RlistUserControl.xaml");
                            // 19 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;
                        break;
                    case "AspnetuserViewRdlistUserControl": 
                        _VisibleAspnetuserViewRdlistUserControl = true; OnPropertyChanged("VisibleAspnetuserViewRdlistUserControl");
                        FilterHeightAspnetuserViewRdlistUserControl = _GlblSettingsSrv.ExpandedFilterHeight("02018-RdlistUserControl.xaml");
                            // 2 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
                        GridHeightAspnetuserViewRdlistUserControl = _GlblSettingsSrv.ExpandedGridHeight("02018-RdlistUserControl.xaml");
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
            _ContainerMenuItemsAspnetmodelViewRlistUserControl = null;
            _ContainerMenuItemsAspnetmodelViewRdlistUserControl = null;
            _ContainerMenuItemsAspnetroleViewRlistUserControl = null;
            _ContainerMenuItemsAspnetroleViewRdlistUserControl = null;
            _ContainerMenuItemsAspnetuserViewRlistUserControl = null;
            _ContainerMenuItemsAspnetuserViewRdlistUserControl = null;
        }
        #endregion

    }
}

