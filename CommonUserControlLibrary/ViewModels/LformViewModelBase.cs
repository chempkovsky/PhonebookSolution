using Xamarin.Forms;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Prism.Services.Dialogs;
using Prism.Navigation;

using CommonInterfacesClassLibrary.Interfaces;
using CommonInterfacesClassLibrary.AppGlblSettingsSrvc;
using CommonInterfacesClassLibrary.Enums;
using CommonCustomControlLibrary.Classes;
using CommonCustomControlLibrary.Fonts;

namespace CommonUserControlLibrary.ViewModels {
    public class LformViewModelBase: INotifyPropertyChanged, IBindingContextChanged, ILformViewModelInterface, IDestructible
    {
        protected IAppGlblSettingsService GlblSettingsSrv=null;
        protected IDialogService _dialogService=null;
        protected string edialogName = "noname";
        protected string adialogName = "noname";
        protected string udialogName = "noname";
        protected string ddialogName = "noname";
        protected string vdialogName = "noname";


        public LformViewModelBase(IAppGlblSettingsService GlblSettingsSrv, IDialogService dialogService) {
            this.GlblSettingsSrv = GlblSettingsSrv;
            this._dialogService = dialogService;
            _TableMenuItemsVM = GetDefaultTableMenuItemsVM();
            _RowMenuItemsVM = GetDefaultRowMenuItemsVM();
        }
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion
        #region BindingContextFeedbackRef
        protected object _BindingContextFeedbackRef = null;
        public object BindingContextFeedbackRef {
            get { return _BindingContextFeedbackRef; }
            set { 
                if(_BindingContextFeedbackRef != value) {
                    _BindingContextFeedbackRef = value;
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

        #region IBindingContextChanged
        public async Task OnLoaded(object sender, object newValue)
        {
            if (newValue is bool) {
                IsParentLoaded = (bool)newValue;
            }
        }
        #endregion
        #region HiddenFiltersPropertyChanged
        public void HiddenFiltersPropertyChanged(object Sender, object OldValue, object NewValue)
        {
            if(IsDestroyed) return;
            IEnumerable<IWebServiceFilterRsltInterface> hfs = NewValue as IEnumerable<IWebServiceFilterRsltInterface>;
            ObservableCollection<IWebServiceFilterRsltInterface> newhfs = new ObservableCollection<IWebServiceFilterRsltInterface>();
            if(hfs != null) {
                foreach(IWebServiceFilterRsltInterface hf  in hfs) {
                    newhfs.Add( new WebServiceFilterRsltViewModel() {fltrName=hf.fltrName, fltrDataType=hf.fltrDataType,  fltrOperator=hf.fltrOperator, fltrValue=hf.fltrValue, fltrError=hf.fltrError });
                }
            }
            HiddenFiltersVM = newhfs;
        }
        #endregion
        #region HiddenFiltersVM
        IEnumerable<IWebServiceFilterRsltInterface> _HiddenFiltersVM = new ObservableCollection<IWebServiceFilterRsltInterface>();
        public IEnumerable<IWebServiceFilterRsltInterface> HiddenFiltersVM
        {
            get
            {
                return _HiddenFiltersVM;
            }
            set
            {
                if (_HiddenFiltersVM != value)
                {
                    _HiddenFiltersVM = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion
        #region TableMenuItemsPropertyChanged
        protected ObservableCollection<IWebServiceFilterMenuInterface> GetDefaultTableMenuItemsVM() {
            return new ObservableCollection<IWebServiceFilterMenuInterface>()  {
                new WebServiceFilterMenuViewModel() { Id = "TableAddMI", Caption="Add Item", IconName="TablePlus", IconColor=Color.Default, Enabled=true, Data=null, Command = TableMenuItemsCommand},
            };
        }
        public void TableMenuItemsPropertyChanged(object Sender, object OldValue, object NewValue) {
            if(IsDestroyed) return;
            ObservableCollection<IWebServiceFilterMenuInterface> tmis = GetDefaultTableMenuItemsVM();
            IEnumerable<IWebServiceFilterMenuInterface> intmis = NewValue as IEnumerable<IWebServiceFilterMenuInterface>;
            if(intmis != null) {
                foreach(IWebServiceFilterMenuInterface tmi  in intmis) {
                    tmis.Add( new WebServiceFilterMenuViewModel() {Id = tmi.Id, Caption=tmi.Caption,  IconName=tmi.IconName, IconColor=tmi.IconColor, Enabled=tmi.Enabled, Data=tmi.Data, FeedbackData=tmi.FeedbackData, Command = tmi.Command });
                }
            }
            TableMenuItemsVM = tmis;
        }
        #endregion
        #region TableMenuItemsVM
        protected IEnumerable<IWebServiceFilterMenuInterface> _TableMenuItemsVM = null;
        public IEnumerable<IWebServiceFilterMenuInterface> TableMenuItemsVM
        { 
            get
            {
                return _TableMenuItemsVM;
            }
            set
            {
                if (_TableMenuItemsVM != value)
                {
                    _TableMenuItemsVM = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion
        #region RowMenuItemsPropertyChanged
        protected ObservableCollection<IWebServiceFilterMenuInterface> GetDefaultRowMenuItemsVM() {
            return new ObservableCollection<IWebServiceFilterMenuInterface>()  {
                new WebServiceFilterMenuViewModel() { Id = "RowUpdMI", Caption="Update item", IconName="TableEdit", IconColor=Color.Default, Enabled=true, Data=null, Command = RowMenuItemsCommand},
                new WebServiceFilterMenuViewModel() { Id = "RowDelMI", Caption="Delete item", IconName="TableRemove", IconColor=Color.Default, Enabled=true, Data=null, Command = RowMenuItemsCommand},
                new WebServiceFilterMenuViewModel() { Id = "RowViewMI", Caption="View item", IconName="TableEdit", IconColor=Color.Default, Enabled=true, Data=null, Command = RowMenuItemsCommand},
            };
        }
        public void RowMenuItemsPropertyChanged(object Sender, object OldValue, object NewValue) {
            if(IsDestroyed) return;
            ObservableCollection<IWebServiceFilterMenuInterface> tmis = GetDefaultRowMenuItemsVM();
            IEnumerable<IWebServiceFilterMenuInterface> intmis = null;
            intmis = NewValue as IEnumerable<IWebServiceFilterMenuInterface>;
            if(intmis != null) {
                foreach(IWebServiceFilterMenuInterface tmi  in intmis) {
                    tmis.Add( new WebServiceFilterMenuViewModel() {Id = tmi.Id, Caption=tmi.Caption,  IconName=tmi.IconName, IconColor=tmi.IconColor, Enabled=tmi.Enabled, Data=tmi.Data, FeedbackData=tmi.FeedbackData, Command=tmi.Command });
                }
            }
            RowMenuItemsVM = tmis;
        }
        #endregion
        #region RowMenuItemsVM
        protected IEnumerable<IWebServiceFilterMenuInterface> _RowMenuItemsVM = null;
        public IEnumerable<IWebServiceFilterMenuInterface> RowMenuItemsVM
        { 
            get
            {
                return _RowMenuItemsVM;
            }
            set
            {
                if (_RowMenuItemsVM != value)
                {
                    _RowMenuItemsVM = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion
        #region SelectedRowCommand
        protected ICommand _SelectedRowCommand = null;
        public ICommand SelectedRowCommand
        {
            get
            {
                return _SelectedRowCommand ?? (_SelectedRowCommand = new Command((p) => SelectedRowCommandExecute(p), (p) => SelectedRowCommandCanExecute(p)));
            }
        }
        protected void SelectedRowCommandExecute(object p)
        {
            BindingContextFeedbackRef = new BindingContextFeedback() {
		        BcfName = "SelectedRow",
		        BcfData = p
            };
        }
        protected bool SelectedRowCommandCanExecute(object p)
        {
            return true; 
        }
        #endregion
        #region TableMenuItemsCommand
        protected ICommand _TableMenuItemsCommand = null;
        public ICommand TableMenuItemsCommand
        {
            get
            {
                return _TableMenuItemsCommand ?? (_TableMenuItemsCommand = new Command((p) => TableMenuItemsCommandExecute(p), (p) => TableMenuItemsCommandCanExecute(p)));
            }
        }
        protected void TableMenuItemsCommandExecute(object p)
        {
            if(IsDestroyed) return;
            WebServiceFilterMenuViewModel mi = p as WebServiceFilterMenuViewModel;
            if(mi != null) {
                if(mi.Id == "TableAddMI") {
                    if(!CanAddVM) {
                        var parameters = new DialogParameters
                        {
                            { "Title", "Access denied" },
                            { "Message", "You do not have permission" },
                            { "MessageIconName", IconFont.Info_outline },
                            { "MessageIconColor", Application.Current.Resources["IconButtonDangerColor"] },
                            { "ShowOkBtn", true },
                            { "ShowCancelBtn", false },
                        };
                        _dialogService.ShowDialog("MessageDlg", parameters, (dp)=>{ });
                        return;
                    }
                    SformAddItemCommand();
                    return;
                }
            }
            BindingContextFeedbackRef = new BindingContextFeedback() {
		        BcfName = "TableMenuItemsCommand",
		        BcfData = p
            };
        }
        protected bool TableMenuItemsCommandCanExecute(object p)
        {
            WebServiceFilterMenuViewModel mi = p as WebServiceFilterMenuViewModel;
            if(mi != null) {
                if(mi.Id == "TableAddMI") {
                    return CanAddVM;
                }
            }
            return true; 
        }
        #endregion
        #region RowMenuItemsCommand
        protected ICommand _RowMenuItemsCommand = null;
        public ICommand RowMenuItemsCommand
        {
            get
            {
                return _RowMenuItemsCommand ?? (_RowMenuItemsCommand = new Command((p) => RowMenuItemsCommandExecute(p), (p) => RowMenuItemsCommandCanExecute(p)));
            }
        }
        protected void RowMenuItemsCommandExecute(object p)
        {
            if(IsDestroyed) return;
            WebServiceFilterMenuViewModel mi = p as WebServiceFilterMenuViewModel;
            if(mi != null) {
                if(mi.Id == "RowUpdMI") {
                    if(!CanUpdateVM) {
                        var parameters = new DialogParameters
                        {
                            { "Title", "Access denied" },
                            { "Message", "You do not have permission" },
                            { "MessageIconName", IconFont.Info_outline },
                            { "MessageIconColor", Application.Current.Resources["IconButtonDangerColor"] },
                            { "ShowOkBtn", true },
                            { "ShowCancelBtn", false },
                        };
                        _dialogService.ShowDialog("MessageDlg", parameters, (dp)=>{ });
                        return;
                    }
                    SformUpdItemCommand(mi.FeedbackData);
                    return;
                }
                if(mi.Id == "RowDelMI") {
                    if(!CanDeleteVM) {
                        var parameters = new DialogParameters
                        {
                            { "Title", "Access denied" },
                            { "Message", "You do not have permission" },
                            { "MessageIconName", IconFont.Info_outline },
                            { "MessageIconColor", Application.Current.Resources["IconButtonDangerColor"] },
                            { "ShowOkBtn", true },
                            { "ShowCancelBtn", false },
                        };
                        _dialogService.ShowDialog("MessageDlg", parameters, (dp)=>{ });
                        return;
                    }
                    SformDelItemCommand(mi.FeedbackData);
                    return;
                }
                if(mi.Id == "RowViewMI") {
                    SformViewItemCommand(mi.FeedbackData);
                    return;
                }
            }
            BindingContextFeedbackRef = new BindingContextFeedback() {
		        BcfName = "RowMenuItemsCommand",
		        BcfData = p
            };
        }
        protected bool RowMenuItemsCommandCanExecute(object p) {
            WebServiceFilterMenuViewModel mi = p as WebServiceFilterMenuViewModel;
            if(mi != null) {
                if(mi.Id == "RowUpdMI") {
                    return CanUpdateVM;
                }
                if(mi.Id == "RowDelMI") {
                    return CanDeleteVM;
                }
            }
            return true;
        }
        #endregion
        #region CanAddVM
        public void CanAddPropertyChanged(object Sender, object OldValue, object NewValue) {
            if(NewValue is bool)
                CanAddVM = (bool)NewValue;
        }
        protected bool _CanAddVM = false;
        public bool CanAddVM
        { 
            get
            {
                return _CanAddVM;
            }
            set
            {
                if (_CanAddVM != value)
                {
                    _CanAddVM = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion
        #region CanUpdateVM
        public void CanUpdatePropertyChanged(object Sender, object OldValue, object NewValue) {
            if(NewValue is bool)
                CanUpdateVM = (bool)NewValue;
        }
        protected bool _CanUpdateVM = false;
        public bool CanUpdateVM
        { 
            get
            {
                return _CanUpdateVM;
            }
            set
            {
                if (_CanUpdateVM != value)
                {
                    _CanUpdateVM = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion
        #region CanDeleteVM
        public void CanDeletePropertyChanged(object Sender, object OldValue, object NewValue) {
            if(NewValue is bool)
                CanDeleteVM = (bool)NewValue;
        }
        protected bool _CanDeleteVM = false;
        public bool CanDeleteVM
        { 
            get
            {
                return _CanDeleteVM;
            }
            set
            {
                if (_CanDeleteVM != value)
                {
                    _CanDeleteVM = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion
        #region SformAfterAddItem
        protected object _SformAfterAddItem=null;
        public object SformAfterAddItem {
            get { return _SformAfterAddItem; }
            set { 
                if (_SformAfterAddItem != value) { 
                    _SformAfterAddItem = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion
        #region SformAddItemCommand
        public void SformAddItemCommand() {
            if(IsDestroyed) return;
            if (!CanAddVM) return;
            IDialogParameters prms = new DialogParameters();
            prms.Add("Caption", "Add Item");
            prms.Add("HiddenFilters", HiddenFiltersVM);
            prms.Add("EformMode", EformModeEnum.AddMode);
            prms.Add("ShowSubmit", true);
            // prms.Add("FormControlModel", null);
            _dialogService.ShowDialog(adialogName, prms, (rslt) => {
                if(rslt == null) return;
                var rtprms = rslt.Parameters;
                if (rtprms == null) return;
                if (!rtprms.ContainsKey("Result")) return;
                if(!rtprms.GetValue<bool>("Result")) return;
                if (rtprms.ContainsKey("FormControlModel")) {
                    object itm = rtprms.GetValue<object>("FormControlModel");
                    SformAfterAddItem = null;
                    SformAfterAddItem = itm;
                    BindingContextFeedbackRef = new BindingContextFeedback() {
		                BcfName = "SformAfterAddItemCommand",
		                BcfData = itm
                    };
                }
            });
        }
        #endregion
        #region SformAfterUpdItem
        protected object _SformAfterUpdItem=null;
        public object SformAfterUpdItem {
            get { return _SformAfterUpdItem; }
            set { 
                if (_SformAfterUpdItem != value) { 
                    _SformAfterUpdItem = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion
        #region SformUpdItemCommand
        public void SformUpdItemCommand(object selected) {
            if(IsDestroyed) return;
            if ((!CanUpdateVM) || (selected == null)) return;
            IDialogParameters prms = new DialogParameters();
            prms.Add("Caption", "Update Item");
            prms.Add("HiddenFilters", HiddenFiltersVM);
            prms.Add("EformMode", EformModeEnum.UpdateMode);
            prms.Add("ShowSubmit", true);
            prms.Add("FormControlModel", selected);
            _dialogService.ShowDialog(udialogName, prms, (rslt) => {
                if(rslt == null) return;
                var rtprms = rslt.Parameters;
                if (rtprms == null) return;
                if (!rtprms.ContainsKey("Result")) return;
                if(!rtprms.GetValue<bool>("Result")) return;
                if (rtprms.ContainsKey("FormControlModel")) {
                    object itm = rtprms.GetValue<object>("FormControlModel");
                    SformAfterUpdItem = null;
                    SformAfterUpdItem = itm;
                    BindingContextFeedbackRef = new BindingContextFeedback() {
		                BcfName = "SformAfterUpdItemCommand",
		                BcfData = itm
                    };
                }
            });
        }
        #endregion
        #region SformAfterDelItem
        protected object _SformAfterDelItem=null;
        public object SformAfterDelItem {
            get { return _SformAfterDelItem; }
            set { 
                if (_SformAfterDelItem != value) { 
                    _SformAfterDelItem = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion
        #region SformDelItemCommand
        public void SformDelItemCommand(object selected) {
            if(IsDestroyed) return;
            if ((!CanDeleteVM) || (selected == null)) return;
            IDialogParameters prms = new DialogParameters();
            prms.Add("Caption", "Delete Item");
            prms.Add("HiddenFilters", HiddenFiltersVM);
            prms.Add("EformMode", EformModeEnum.DeleteMode);
            prms.Add("ShowSubmit", true);
            prms.Add("FormControlModel", selected);
            _dialogService.ShowDialog(ddialogName, prms, (rslt) => {
                if(rslt == null) return;
                var rtprms = rslt.Parameters;
                if (rtprms == null) return;
                if (!rtprms.ContainsKey("Result")) return;
                if(!rtprms.GetValue<bool>("Result")) return;
                if (rtprms.ContainsKey("FormControlModel")) {
                    object itm = rtprms.GetValue<object>("FormControlModel");
                    SformAfterDelItem = null;
                    SformAfterDelItem = itm;
                    BindingContextFeedbackRef = new BindingContextFeedback() {
		                BcfName = "SformAfterDelItemCommand",
		                BcfData = itm
                    };
                }
            });
        }
        #endregion
        #region SformViewItemCommand
        public void SformViewItemCommand(object selected) {
            if(IsDestroyed) return;
            if ((!CanDeleteVM) || (selected == null)) return;
            IDialogParameters prms = new DialogParameters();
            prms.Add("Caption", "View Item");
            prms.Add("HiddenFilters", HiddenFiltersVM);
            prms.Add("EformMode", EformModeEnum.DeleteMode);
            prms.Add("ShowSubmit", true);
            prms.Add("FormControlModel", selected);
            _dialogService.ShowDialog(vdialogName, prms, (rslt) => {});
        }
        #endregion

        #region OnDestroy
        public void OnDestroy() {
            IsDestroyed = true;
        }
        #endregion

        public bool _IsDestroyed = false;
        public bool IsDestroyed {
            get { return _IsDestroyed; }
            set { 
                if (_IsDestroyed != value) { 
                    if(value) {
                        _IsDestroyed = value;
                        RowMenuItemsVM = null; // correct: notify children
                        TableMenuItemsVM = null;
                        HiddenFiltersVM = null;
                        OnPropertyChanged();
                    }
                }
            }
        }

        #region IDestructible
        public void Destroy()
        {
            if(IsDestroyed) return;
            OnDestroy();
        }
        #endregion

    }
}

