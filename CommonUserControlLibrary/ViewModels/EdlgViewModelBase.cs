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
using CommonInterfacesClassLibrary.Enums;


namespace CommonUserControlLibrary.ViewModels {
    public class EdlgViewModelBase: INotifyPropertyChanged, IDialogAware
    {
        protected IAppGlblSettingsService GlblSettingsSrv=null;
        protected IDialogService _dialogService=null;
        public EdlgViewModelBase(IAppGlblSettingsService GlblSettingsSrv, IDialogService dialogService) {

            this.GlblSettingsSrv = GlblSettingsSrv;
            this._dialogService = dialogService;


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
            if (parameters.ContainsKey("HiddenFilters"))  
            {
                HiddenFilters = parameters.GetValue<IEnumerable<IWebServiceFilterRsltInterface>>("HiddenFilters");
            }
            if (parameters.ContainsKey("EformMode"))  
            {
                EformMode = parameters.GetValue<EformModeEnum>("EformMode");
            }
            if (parameters.ContainsKey("FormControlModel"))  
            {
                FormControlModel = parameters.GetValue<object>("FormControlModel");
            }
            if (parameters.ContainsKey("ShowSubmit"))  
            {
                ShowSubmit = parameters.GetValue<bool>("ShowSubmit");
            }
            IsParentLoaded = true;
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

        #region EformMode    
        protected EformModeEnum _EformMode = EformModeEnum.DeleteMode;
        public EformModeEnum EformMode
        {
            get
            {
                return _EformMode;
            }
            set
            {
                if (_EformMode != value) {
                    _EformMode = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        #region FormControlModel
        protected object _FormControlModel = null;
        public object FormControlModel
        {
            get
            {
                return _FormControlModel;
            }
            set
            {
                if (_FormControlModel != value) {
                    _FormControlModel = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        #region ShowSubmit
        bool _ShowSubmit = true;
        public bool ShowSubmit
        {
            get
            {
                return _ShowSubmit;
            }
            set
            {
                if (_ShowSubmit != value)
                {
                    _ShowSubmit = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion


        #region SubmitCommand
        private ICommand _SubmitCommand;
        public ICommand SubmitCommand
        {
            get
            {
                return _SubmitCommand ?? (_SubmitCommand = new Command((param) => SubmitCommandAction(param), (param) => SubmitCommandCanExecute(param)));
            }
        }
        protected void SubmitCommandAction(object param)
        {
            IsDestroyed = true;
            HiddenFilters = null;
            FormControlModel = null;
            DialogParameters parameters = new DialogParameters();
            parameters.Add("FormControlModel", param);
            parameters.Add("Result", true);
            _RequestClose?.Invoke(parameters);
        }
        protected bool SubmitCommandCanExecute(object param)
        {
            return true;
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
            FormControlModel = null;
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

