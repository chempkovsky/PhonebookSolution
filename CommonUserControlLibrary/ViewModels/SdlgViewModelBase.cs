using Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Prism.Services.Dialogs;
using CommonInterfacesClassLibrary.Interfaces;
using CommonInterfacesClassLibrary.AppGlblSettingsSrvc;


namespace CommonUserControlLibrary.ViewModels {
    public class SdlgViewModelBase: INotifyPropertyChanged, IDialogAware
    {
        protected IAppGlblSettingsService GlblSettingsSrv=null;
        public SdlgViewModelBase(IAppGlblSettingsService GlblSettingsSrv) {
            this.GlblSettingsSrv = GlblSettingsSrv;
            _FilterHeight = this.GlblSettingsSrv.DefaultFilterHeight("01421-SformUserControl.xaml");
            _GridHeight = this.GlblSettingsSrv.DefaultGridHeight("01421-SformUserControl.xaml");
        }
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        #region IDialogAware
        event Action<IDialogParameters> _RequestClose;
        public event Action<IDialogParameters> RequestClose
        {
            add
            {
                _RequestClose += value;
            }
            remove
            {
                _RequestClose -= value;
            }
        }
        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            
        }
        public void OnDialogOpened(IDialogParameters parameters)
        {
            if (parameters == null)  {
                IsParentLoaded = true;
                return;
            }
            if (parameters.ContainsKey("Caption"))
            {
                Caption = parameters.GetValue<string>("Caption");
                Title = Caption;
            }
            if (parameters.ContainsKey("FilterHeight"))
            {
                FilterHeight = parameters.GetValue<double>("FilterHeight");
            }
            if (parameters.ContainsKey("GridHeight"))
            {
                GridHeight = parameters.GetValue<double>("GridHeight");
            }
            if (parameters.ContainsKey("HiddenFilters"))  
            {
                HiddenFilters = parameters.GetValue<IEnumerable<IWebServiceFilterRsltInterface>>("HiddenFilters");
            }
            IsParentLoaded = true;
        }
        #endregion


        #region SelectedItem
        protected object _SelectedItem = null;
        protected object SelectedItem 
        {
            get
            {
                return _SelectedItem;
            }
            set
            {
                if (_SelectedItem != value)
                {
                    _SelectedItem = value;
                    OnPropertyChanged();
                    (OkCommand as Command).ChangeCanExecute();
                }
            }
        }
        #endregion

        #region Title
        string _Title = "";
        public string Title {
            get { return _Title; }
            set {
                if(_Title != value) {
                    _Title = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        #region GridHeight
        double _GridHeight = -1d;
        public double GridHeight
        {
            get
            {
                return _GridHeight;
            }
            set
            {
                if (_GridHeight != value)
                {
                    _GridHeight = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        #region FilterHeight
        double _FilterHeight = -1d;
        public double FilterHeight
        {
            get
            {
                return _FilterHeight;
            }
            set
            {
                if (_FilterHeight != value)
                {
                    _FilterHeight = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        #region Caption
        string _Caption = null;
        public string Caption
        {
            get
            {
                return _Caption;
            }
            set
            {
                if (_Caption != value)
                {
                    _Caption = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        #region HiddenFilters
        IEnumerable<IWebServiceFilterRsltInterface> _HiddenFilters = null;
        public IEnumerable<IWebServiceFilterRsltInterface> HiddenFilters
        {
            get
            {
                return _HiddenFilters;
            }
            set
            {
                if (_HiddenFilters != value)
                {
                    _HiddenFilters = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        #region IsParentLoaded
        protected bool _IsParentLoaded = false;
        public bool IsParentLoaded {
            get { return _IsParentLoaded; }
            set { 
                if(_IsParentLoaded != value) {
                    _IsParentLoaded = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        #region OnSelectedRowCommand
        protected ICommand _OnSelectedRowCommand = null;
        public ICommand OnSelectedRowCommand
        {
            get
            {
                return _OnSelectedRowCommand ?? (_OnSelectedRowCommand = new Command((p) => OnSelectedRowCommandExecute(p), (p) => OnSelectedRowCommandCanExecute(p)));
            }
        }
        protected void OnSelectedRowCommandExecute(object prm)
        {
                SelectedItem  = prm;
        }
        protected bool OnSelectedRowCommandCanExecute(object prm)
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
        protected void OkCommandAction(object param)
        {
            if(_SelectedItem != null) {
                object sip = _SelectedItem;
                IsDestroyed = true;
                HiddenFilters = null;
                DialogParameters parameters = new DialogParameters();
                parameters.Add("SelectedItem", sip);
                parameters.Add("Result", true);
                _RequestClose?.Invoke(parameters);
            }
        }
        protected bool OkCommandCanExecute(object param)
        {
            return _SelectedItem != null;
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
        protected void CancelCommandAction(object param)
        {
            IsDestroyed = true;
            HiddenFilters = null;
            DialogParameters parameters = new DialogParameters();
            parameters.Add("Result", false);
            _RequestClose?.Invoke(parameters);
        }
        protected bool CancelCommandCanExecute(object param)
        {
            return true;
        }
        #endregion

        #region IsDestroyed
        protected bool _IsDestroyed = false;
        public bool IsDestroyed {
            get { return _IsDestroyed; }
            set { 
                if(_IsDestroyed != value) {
                    _IsDestroyed = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

    }
}

