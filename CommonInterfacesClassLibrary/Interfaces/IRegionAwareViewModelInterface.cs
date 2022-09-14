


namespace CommonInterfacesClassLibrary.Interfaces {
    public interface IRegionAwareViewModelInterface
    {
        void FilterHeightChanged(object Sender, double OldValue, double NewValue);
        void GridHeightChanged(object Sender, double OldValue, double NewValue);
        void ShowFilterChanged(object Sender, bool OldValue, bool NewValue);
        void ShowAddFilterBtnChanged(object Sender, bool OldValue, bool NewValue);
        void CanAddChanged(object Sender, bool OldValue, bool NewValue);
        void CanUpdateChanged(object Sender, bool OldValue, bool NewValue);
        void CanDeleteChanged(object Sender, bool OldValue, bool NewValue);


        void FilterHeightDetailChanged(object Sender, double OldValue, double NewValue);
        void GridHeightDetailChanged(object Sender, double OldValue, double NewValue);
        void ShowFilterDetailChanged(object Sender, bool OldValue, bool NewValue);
        void ShowAddFilterBtnDetailChanged(object Sender, bool OldValue, bool NewValue);
        void CanAddDetailChanged(object Sender, bool OldValue, bool NewValue);
        void CanUpdateDetailChanged(object Sender, bool OldValue, bool NewValue);
        void CanDeleteDetailChanged(object Sender, bool OldValue, bool NewValue);
        void OnDestroy();
    }
}


