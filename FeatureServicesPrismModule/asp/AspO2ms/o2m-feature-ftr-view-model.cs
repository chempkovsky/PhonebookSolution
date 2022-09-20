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

namespace FeatureServicesPrismModule.asp.AspO2ms {
    public class O2mFeatureFtrViewModel : INotifyPropertyChanged, INavigationAware, IDestructible 
    {
        IRegionManager _regionManager;
        IContainerProvider _containerProvider;
        protected IAppGlblSettingsService _GlblSettingsSrv;
        public O2mFeatureFtrViewModel(IAppGlblSettingsService GlblSettingsSrv, IRegionManager regionManager, IContainerProvider containerProvider) {
            _regionManager = regionManager;
            _containerProvider = containerProvider;
            _GlblSettingsSrv = GlblSettingsSrv;

            _ContainerMenuItemsAspnetmodelViewO2mUserControl = 
                new ObservableCollection<IWebServiceFilterMenuInterface>() {
                    new WebServiceFilterMenu() { Id = "0", Caption="Expand(Collapse)", IconName=IconFont.Aspect_ratio,  IconColor= (Color)Application.Current.Resources["IconButtonPrimaryColor"], Enabled=true, Data="AspnetmodelViewO2mUserControl", Command = OnContainerMenuItemsCommand },
                };
            _FilterHeightAspnetmodelViewO2mUserControl = _GlblSettingsSrv.DefaultFilterHeight("01698-O2mUserControl.xaml");
            _GridHeightAspnetmodelViewO2mUserControl = _GlblSettingsSrv.DefaultGridHeight("01698-O2mUserControl.xaml");
            //_FilterHeightAspnetmodelViewO2mUserControl = 1 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
            //_GridHeightAspnetmodelViewO2mUserControl = 5 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;

            _ContainerMenuItemsAspnetroleViewO2mUserControl = 
                new ObservableCollection<IWebServiceFilterMenuInterface>() {
                    new WebServiceFilterMenu() { Id = "1", Caption="Expand(Collapse)", IconName=IconFont.Aspect_ratio,  IconColor= (Color)Application.Current.Resources["IconButtonPrimaryColor"], Enabled=true, Data="AspnetroleViewO2mUserControl", Command = OnContainerMenuItemsCommand },
                };
            _FilterHeightAspnetroleViewO2mUserControl = _GlblSettingsSrv.DefaultFilterHeight("01698-O2mUserControl.xaml");
            _GridHeightAspnetroleViewO2mUserControl = _GlblSettingsSrv.DefaultGridHeight("01698-O2mUserControl.xaml");
            //_FilterHeightAspnetroleViewO2mUserControl = 1 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
            //_GridHeightAspnetroleViewO2mUserControl = 5 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;

            _ContainerMenuItemsAspnetuserViewO2mUserControl = 
                new ObservableCollection<IWebServiceFilterMenuInterface>() {
                    new WebServiceFilterMenu() { Id = "2", Caption="Expand(Collapse)", IconName=IconFont.Aspect_ratio,  IconColor= (Color)Application.Current.Resources["IconButtonPrimaryColor"], Enabled=true, Data="AspnetuserViewO2mUserControl", Command = OnContainerMenuItemsCommand },
                };
            _FilterHeightAspnetuserViewO2mUserControl = _GlblSettingsSrv.DefaultFilterHeight("01698-O2mUserControl.xaml");
            _GridHeightAspnetuserViewO2mUserControl = _GlblSettingsSrv.DefaultGridHeight("01698-O2mUserControl.xaml");
            //_FilterHeightAspnetuserViewO2mUserControl = 1 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
            //_GridHeightAspnetuserViewO2mUserControl = 5 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;

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
                //suc.ScopedRegionManager = _regionManager.Regions["AspnetmodelViewO2mUserControlO2mFeatureFtrUserControl"].Add(suc, null, true);
                //suc.RequestNavigateSource = "AspnetmodelViewO2mUserControl";
                //_regionManager.Regions["AspnetmodelViewO2mUserControlO2mFeatureFtrUserControl"].Activate(suc);
                await Device.InvokeOnMainThreadAsync(async () =>
                {
                    _regionManager.RequestNavigate("AspnetmodelViewO2mUserControlO2mFeatureFtrUserControl", "AspnetmodelViewO2mUserControl", OnNavigationResult);
                    IsSwitching = true;
                    await Task.Delay(1);
                    IsSwitching = false;
                });
                //suc = _containerProvider.Resolve<IScopedRegionNavigationUserControlInterface>();
                //suc.ScopedRegionManager = _regionManager.Regions["AspnetroleViewO2mUserControlO2mFeatureFtrUserControl"].Add(suc, null, true);
                //suc.RequestNavigateSource = "AspnetroleViewO2mUserControl";
                //_regionManager.Regions["AspnetroleViewO2mUserControlO2mFeatureFtrUserControl"].Activate(suc);
                await Device.InvokeOnMainThreadAsync(async () =>
                {
                    _regionManager.RequestNavigate("AspnetroleViewO2mUserControlO2mFeatureFtrUserControl", "AspnetroleViewO2mUserControl", OnNavigationResult);
                    IsSwitching = true;
                    await Task.Delay(1);
                    IsSwitching = false;
                });
                //suc = _containerProvider.Resolve<IScopedRegionNavigationUserControlInterface>();
                //suc.ScopedRegionManager = _regionManager.Regions["AspnetuserViewO2mUserControlO2mFeatureFtrUserControl"].Add(suc, null, true);
                //suc.RequestNavigateSource = "AspnetuserViewO2mUserControl";
                //_regionManager.Regions["AspnetuserViewO2mUserControlO2mFeatureFtrUserControl"].Activate(suc);
                await Device.InvokeOnMainThreadAsync(async () =>
                {
                    _regionManager.RequestNavigate("AspnetuserViewO2mUserControlO2mFeatureFtrUserControl", "AspnetuserViewO2mUserControl", OnNavigationResult);
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
                  && _VisibleAspnetmodelViewO2mUserControl
                  && _VisibleAspnetroleViewO2mUserControl
                  && _VisibleAspnetuserViewO2mUserControl
                ;
            }
        }
        protected bool _VisibleAspnetmodelViewO2mUserControl = true;
        public bool VisibleAspnetmodelViewO2mUserControl
        {
            get
            {
                return _VisibleAspnetmodelViewO2mUserControl;
            }
            set
            {
                if (_VisibleAspnetmodelViewO2mUserControl != value)
                {
                    _VisibleAspnetmodelViewO2mUserControl = value;
                    OnPropertyChanged();
                    OnPropertyChanged("FlexOn");
                }
            }
        }

        protected IEnumerable<IWebServiceFilterMenuInterface> _ContainerMenuItemsAspnetmodelViewO2mUserControl = null;
        public IEnumerable<IWebServiceFilterMenuInterface> ContainerMenuItemsAspnetmodelViewO2mUserControl {
            get { return _ContainerMenuItemsAspnetmodelViewO2mUserControl; }
        }

        protected double _FilterHeightAspnetmodelViewO2mUserControl = -1d;
        public  double FilterHeightAspnetmodelViewO2mUserControl 
        {
            get { return _FilterHeightAspnetmodelViewO2mUserControl; }
            set 
            {
                if(_FilterHeightAspnetmodelViewO2mUserControl != value) {
                    _FilterHeightAspnetmodelViewO2mUserControl = value;
                    OnPropertyChanged();
                }
            }
        }

        protected double _GridHeightAspnetmodelViewO2mUserControl = -1d;
        public  double GridHeightAspnetmodelViewO2mUserControl 
        {
            get { return _GridHeightAspnetmodelViewO2mUserControl; }
            set 
            {
                if(_GridHeightAspnetmodelViewO2mUserControl != value) {
                    _GridHeightAspnetmodelViewO2mUserControl = value;
                    OnPropertyChanged();
                }
            }
        }

        protected bool _VisibleAspnetroleViewO2mUserControl = true;
        public bool VisibleAspnetroleViewO2mUserControl
        {
            get
            {
                return _VisibleAspnetroleViewO2mUserControl;
            }
            set
            {
                if (_VisibleAspnetroleViewO2mUserControl != value)
                {
                    _VisibleAspnetroleViewO2mUserControl = value;
                    OnPropertyChanged();
                    OnPropertyChanged("FlexOn");
                }
            }
        }

        protected IEnumerable<IWebServiceFilterMenuInterface> _ContainerMenuItemsAspnetroleViewO2mUserControl = null;
        public IEnumerable<IWebServiceFilterMenuInterface> ContainerMenuItemsAspnetroleViewO2mUserControl {
            get { return _ContainerMenuItemsAspnetroleViewO2mUserControl; }
        }

        protected double _FilterHeightAspnetroleViewO2mUserControl = -1d;
        public  double FilterHeightAspnetroleViewO2mUserControl 
        {
            get { return _FilterHeightAspnetroleViewO2mUserControl; }
            set 
            {
                if(_FilterHeightAspnetroleViewO2mUserControl != value) {
                    _FilterHeightAspnetroleViewO2mUserControl = value;
                    OnPropertyChanged();
                }
            }
        }

        protected double _GridHeightAspnetroleViewO2mUserControl = -1d;
        public  double GridHeightAspnetroleViewO2mUserControl 
        {
            get { return _GridHeightAspnetroleViewO2mUserControl; }
            set 
            {
                if(_GridHeightAspnetroleViewO2mUserControl != value) {
                    _GridHeightAspnetroleViewO2mUserControl = value;
                    OnPropertyChanged();
                }
            }
        }

        protected bool _VisibleAspnetuserViewO2mUserControl = true;
        public bool VisibleAspnetuserViewO2mUserControl
        {
            get
            {
                return _VisibleAspnetuserViewO2mUserControl;
            }
            set
            {
                if (_VisibleAspnetuserViewO2mUserControl != value)
                {
                    _VisibleAspnetuserViewO2mUserControl = value;
                    OnPropertyChanged();
                    OnPropertyChanged("FlexOn");
                }
            }
        }

        protected IEnumerable<IWebServiceFilterMenuInterface> _ContainerMenuItemsAspnetuserViewO2mUserControl = null;
        public IEnumerable<IWebServiceFilterMenuInterface> ContainerMenuItemsAspnetuserViewO2mUserControl {
            get { return _ContainerMenuItemsAspnetuserViewO2mUserControl; }
        }

        protected double _FilterHeightAspnetuserViewO2mUserControl = -1d;
        public  double FilterHeightAspnetuserViewO2mUserControl 
        {
            get { return _FilterHeightAspnetuserViewO2mUserControl; }
            set 
            {
                if(_FilterHeightAspnetuserViewO2mUserControl != value) {
                    _FilterHeightAspnetuserViewO2mUserControl = value;
                    OnPropertyChanged();
                }
            }
        }

        protected double _GridHeightAspnetuserViewO2mUserControl = -1d;
        public  double GridHeightAspnetuserViewO2mUserControl 
        {
            get { return _GridHeightAspnetuserViewO2mUserControl; }
            set 
            {
                if(_GridHeightAspnetuserViewO2mUserControl != value) {
                    _GridHeightAspnetuserViewO2mUserControl = value;
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
            _VisibleAspnetmodelViewO2mUserControl = !IsAllCollapsed; OnPropertyChanged("VisibleAspnetmodelViewO2mUserControl");
            FilterHeightAspnetmodelViewO2mUserControl = _GlblSettingsSrv.DefaultFilterHeight("01698-O2mUserControl.xaml");
                // 1 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
            GridHeightAspnetmodelViewO2mUserControl = _GlblSettingsSrv.DefaultGridHeight("01698-O2mUserControl.xaml");
                // 5 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;
            _VisibleAspnetroleViewO2mUserControl = !IsAllCollapsed; OnPropertyChanged("VisibleAspnetroleViewO2mUserControl");
            FilterHeightAspnetroleViewO2mUserControl = _GlblSettingsSrv.DefaultFilterHeight("01698-O2mUserControl.xaml");
                // 1 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
            GridHeightAspnetroleViewO2mUserControl = _GlblSettingsSrv.DefaultGridHeight("01698-O2mUserControl.xaml");
                // 5 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;
            _VisibleAspnetuserViewO2mUserControl = !IsAllCollapsed; OnPropertyChanged("VisibleAspnetuserViewO2mUserControl");
            FilterHeightAspnetuserViewO2mUserControl = _GlblSettingsSrv.DefaultFilterHeight("01698-O2mUserControl.xaml");
                // 1 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
            GridHeightAspnetuserViewO2mUserControl = _GlblSettingsSrv.DefaultGridHeight("01698-O2mUserControl.xaml");
                // 5 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;
            if (IsAllCollapsed) {
                switch(modelName) {
                    case "AspnetmodelViewO2mUserControl": 
                        _VisibleAspnetmodelViewO2mUserControl = true; OnPropertyChanged("VisibleAspnetmodelViewO2mUserControl");
                        FilterHeightAspnetmodelViewO2mUserControl = _GlblSettingsSrv.ExpandedFilterHeight("01698-O2mUserControl.xaml");
                            // 1 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
                        GridHeightAspnetmodelViewO2mUserControl = _GlblSettingsSrv.ExpandedGridHeight("01698-O2mUserControl.xaml");
                            // 5 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;
                        break;
                    case "AspnetroleViewO2mUserControl": 
                        _VisibleAspnetroleViewO2mUserControl = true; OnPropertyChanged("VisibleAspnetroleViewO2mUserControl");
                        FilterHeightAspnetroleViewO2mUserControl = _GlblSettingsSrv.ExpandedFilterHeight("01698-O2mUserControl.xaml");
                            // 1 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
                        GridHeightAspnetroleViewO2mUserControl = _GlblSettingsSrv.ExpandedGridHeight("01698-O2mUserControl.xaml");
                            // 5 * _GlblSettingsSrv.TableHeightFactor + _GlblSettingsSrv.TableHeightAddition;
                        break;
                    case "AspnetuserViewO2mUserControl": 
                        _VisibleAspnetuserViewO2mUserControl = true; OnPropertyChanged("VisibleAspnetuserViewO2mUserControl");
                        FilterHeightAspnetuserViewO2mUserControl = _GlblSettingsSrv.ExpandedFilterHeight("01698-O2mUserControl.xaml");
                            // 1 * _GlblSettingsSrv.FilterHeightFactor + _GlblSettingsSrv.FilterHeightAddition;
                        GridHeightAspnetuserViewO2mUserControl = _GlblSettingsSrv.ExpandedGridHeight("01698-O2mUserControl.xaml");
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
            _ContainerMenuItemsAspnetmodelViewO2mUserControl = null;
            _ContainerMenuItemsAspnetroleViewO2mUserControl = null;
            _ContainerMenuItemsAspnetuserViewO2mUserControl = null;
        }
        #endregion

    }
}

