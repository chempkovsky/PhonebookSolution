using System.Threading.Tasks;

namespace CommonInterfacesClassLibrary.Interfaces {
    public interface IEformViewModelInterface 
    {
        Task HiddenFiltersPropertyChanged(object Sender, object OldValue, object NewValue);
        Task FormControlModelChanged(object Sender, object OldValue, object NewValue);
        Task EformModeChanged(object Sender, object OldValue, object NewValue);
        void OnAutoSuggestBoxTextChanged(object Sender, object AutoSggstBx, string PropName, int Reason, string QueryText);
        void OnAutoSuggestBoxQuerySubmitted(object Sender, object AutoSggstBx, string PropName, object ChosenSuggestion, string QueryText);
    }
}

