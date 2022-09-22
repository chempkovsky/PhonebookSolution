using Prism.Services.Dialogs;

using CommonInterfacesClassLibrary.AppGlblSettingsSrvc;
using CommonUserControlLibrary.ViewModels;
/*



    "PhbkDivisionViewLformUserControl" UserControl is defined in the "ModelServicesPrismModule"-project.
    In the file of IModule-class of "ModelServicesPrismModule"-project the following line of code must be inserted:

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ...
            // According to requirements of the "PhbkDivisionViewLformViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            ViewModelLocationProvider.Register<PhbkDivisionViewLformUserControl, PhbkDivisionViewLformViewModel>();
            // According to requirements of the "PhbkDivisionViewLformViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            containerRegistry.Register<ContentView, PhbkDivisionViewLformUserControl>("PhbkDivisionViewLformUserControl");
            ...
        }
*/

namespace ModelServicesPrismModule.Phonebook.PhbkDivision.ViewModels {
    public class PhbkDivisionViewLformViewModel:  LformViewModelBase
    {
        public PhbkDivisionViewLformViewModel(IAppGlblSettingsService GlblSettingsSrv, IDialogService dialogService):base(GlblSettingsSrv, dialogService) {
            edialogName = "";
            vdialogName = "PhbkDivisionViewVdlgViewModel";
            adialogName = "PhbkDivisionViewAdlgViewModel";
            udialogName = "PhbkDivisionViewUdlgViewModel";
            ddialogName = "PhbkDivisionViewDdlgViewModel";
            viewModelName = "PhbkDivisionView";
            _TableMenuItemsVM = GetDefaultTableMenuItemsVM();
            _RowMenuItemsVM = GetDefaultRowMenuItemsVM();
        }
    }
}



