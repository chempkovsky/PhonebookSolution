using Prism.Services.Dialogs;

using CommonInterfacesClassLibrary.AppGlblSettingsSrvc;
using CommonUserControlLibrary.ViewModels;
/*



    "PhbkPhoneTypeViewLformUserControl" UserControl is defined in the "ModelServicesPrismModule"-project.
    In the file of IModule-class of "ModelServicesPrismModule"-project the following line of code must be inserted:

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ...
            // According to requirements of the "PhbkPhoneTypeViewLformViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            ViewModelLocationProvider.Register<PhbkPhoneTypeViewLformUserControl, PhbkPhoneTypeViewLformViewModel>();
            // According to requirements of the "PhbkPhoneTypeViewLformViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            containerRegistry.Register<ContentView, PhbkPhoneTypeViewLformUserControl>("PhbkPhoneTypeViewLformUserControl");
            ...
        }
*/

namespace ModelServicesPrismModule.Phonebook.PhbkPhoneType.ViewModels {
    public class PhbkPhoneTypeViewLformViewModel:  LformViewModelBase
    {
        public PhbkPhoneTypeViewLformViewModel(IAppGlblSettingsService GlblSettingsSrv, IDialogService dialogService):base(GlblSettingsSrv, dialogService) {
            edialogName = "";
            vdialogName = "PhbkPhoneTypeViewVdlgViewModel";
            adialogName = "PhbkPhoneTypeViewAdlgViewModel";
            udialogName = "PhbkPhoneTypeViewUdlgViewModel";
            ddialogName = "PhbkPhoneTypeViewDdlgViewModel";
            viewModelName = "PhbkPhoneTypeView";
            _TableMenuItemsVM = GetDefaultTableMenuItemsVM();
            _RowMenuItemsVM = GetDefaultRowMenuItemsVM();
        }
    }
}



