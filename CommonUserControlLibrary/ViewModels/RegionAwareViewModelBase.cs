using System.ComponentModel;
using System.Runtime.CompilerServices;
using Prism.Regions.Navigation;
using Prism.Navigation;
using CommonInterfacesClassLibrary.Interfaces;


namespace CommonUserControlLibrary.ViewModels {
    public class RegionAwareViewModelBase: IRegionAwareViewModelInterface, INotifyPropertyChanged, IDestructible
    {

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        #region IRegionAwareViewModelInterface
        double _FilterHeight = -1d;
        public double FilterHeight {
            get { return _FilterHeight; }
            set { if (_FilterHeight != value) { _FilterHeight = value; OnPropertyChanged();} }
        }
        public virtual void FilterHeightChanged(object Sender, double OldValue, double NewValue) {
            FilterHeight = NewValue;
        }
        double _GridHeight = -1d;
        public double GridHeight {
            get { return _GridHeight; }
            set { if (_GridHeight != value) { _GridHeight = value; OnPropertyChanged();} }
        }
        public virtual void GridHeightChanged(object Sender, double OldValue, double NewValue) {
            GridHeight = NewValue;
        }
        bool _ShowFilter = false;
        public bool ShowFilter {
            get { return _ShowFilter; }
            set { if (_ShowFilter != value) { _ShowFilter = value; OnPropertyChanged();} }
        }
        public virtual void ShowFilterChanged(object Sender, bool OldValue, bool NewValue) {
            ShowFilter = NewValue;
        }
        bool _ShowAddFilterBtn = false;
        public virtual bool ShowAddFilterBtn {
            get { return _ShowAddFilterBtn; }
            set { if (_ShowAddFilterBtn != value) { _ShowAddFilterBtn = value; OnPropertyChanged();} }
        }
        public virtual void ShowAddFilterBtnChanged(object Sender, bool OldValue, bool NewValue) {
            ShowAddFilterBtn = NewValue;
        }
        protected bool CanAddParent = false;
        public virtual void CanAddChanged(object Sender, bool OldValue, bool NewValue) {
            CanAddParent = NewValue;
            OnPropertyChanged("CanAdd");
        }
        protected bool CanUpdateParent = false;
        public virtual void CanUpdateChanged(object Sender, bool OldValue, bool NewValue) {
            CanUpdateParent = NewValue;
            OnPropertyChanged("CanUpdate");
        }
        protected bool CanDeleteParent = false;
        public virtual void CanDeleteChanged(object Sender, bool OldValue, bool NewValue) {
            CanDeleteParent = NewValue;
            OnPropertyChanged("CanDelete");
        }


        double _FilterHeightDetail = -1d;
        public double FilterHeightDetail {
            get { return _FilterHeightDetail; }
            set { if (_FilterHeightDetail != value) { _FilterHeightDetail = value; OnPropertyChanged();} }
        }
        public virtual void FilterHeightDetailChanged(object Sender, double OldValue, double NewValue) {
            FilterHeightDetail = NewValue;
        }
        double _GridHeightDetail = -1d;
        public double GridHeightDetail {
            get { return _GridHeightDetail; }
            set { if (_GridHeightDetail != value) { _GridHeightDetail = value; OnPropertyChanged();} }
        }
        public virtual void GridHeightDetailChanged(object Sender, double OldValue, double NewValue) {
            GridHeightDetail = NewValue;
        }
        bool _ShowFilterDetail = false;
        public bool ShowFilterDetail {
            get { return _ShowFilterDetail; }
            set { if (_ShowFilterDetail != value) { _ShowFilterDetail = value; OnPropertyChanged();} }
        }
        public virtual void ShowFilterDetailChanged(object Sender, bool OldValue, bool NewValue) {
            ShowFilterDetail = NewValue;
        }
        bool _ShowAddFilterBtnDetail = false;
        public bool ShowAddFilterBtnDetail {
            get { return _ShowAddFilterBtnDetail; }
            set { if (_ShowAddFilterBtnDetail != value) { _ShowAddFilterBtnDetail = value; OnPropertyChanged();} }
        }
        public virtual void ShowAddFilterBtnDetailChanged(object Sender, bool OldValue, bool NewValue) {
            ShowAddFilterBtnDetail = NewValue;
        }
        protected bool CanAddDetailParent = false;
        public virtual void CanAddDetailChanged(object Sender, bool OldValue, bool NewValue) {
            CanAddDetailParent = NewValue;
            OnPropertyChanged("CanAddDetail");
        }
        protected bool CanUpdateDetailParent = false;
        public virtual void CanUpdateDetailChanged(object Sender, bool OldValue, bool NewValue) {
            CanUpdateDetailParent = NewValue;
            OnPropertyChanged("CanUpdateDetail");
        }
        protected bool CanDeleteDetailParent = false;
        public virtual void CanDeleteDetailChanged(object Sender, bool OldValue, bool NewValue) {
            CanDeleteDetailParent = NewValue;
            OnPropertyChanged("CanDeleteDetail");
        }
        bool _IsDestroyed = false;
        public bool IsDestroyed {
            get { return _IsDestroyed; }
            set { if (_IsDestroyed != value) { _IsDestroyed = value; OnPropertyChanged();} }
        }
        public virtual void OnDestroy() {
            IsDestroyed = true;
            CurrentNavigationContext = null;
        }
        #endregion
       protected INavigationContext CurrentNavigationContext = null;

        #region IDestructible
        public void Destroy()
        {
            if(IsDestroyed) return;
            OnDestroy();
        }
        #endregion

    }
}


