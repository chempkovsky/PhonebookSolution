using Prism.Services.Dialogs;

using CommonInterfacesClassLibrary.AppGlblSettingsSrvc;
using CommonUserControlLibrary.ViewModels;
/*



    "PhbkPhoneViewLformUserControl" UserControl is defined in the "ModelServicesPrismModule"-project.
    In the file of IModule-class of "ModelServicesPrismModule"-project the following line of code must be inserted:

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ...
            // According to requirements of the "PhbkPhoneViewLformViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            ViewModelLocationProvider.Register<PhbkPhoneViewLformUserControl, PhbkPhoneViewLformViewModel>();
            // According to requirements of the "PhbkPhoneViewLformViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            containerRegistry.Register<ContentView, PhbkPhoneViewLformUserControl>("PhbkPhoneViewLformUserControl");
            ...
        }
*/

namespace ModelServicesPrismModule.Phonebook.PhbkPhone.ViewModels {
    public class PhbkPhoneViewLformViewModel:  LformViewModelBase
    {
        public PhbkPhoneViewLformViewModel(IAppGlblSettingsService GlblSettingsSrv, IDialogService dialogService):base(GlblSettingsSrv, dialogService) {
            edialogName = "";
            vdialogName = "PhbkPhoneViewVdlgViewModel";
            adialogName = "PhbkPhoneViewAdlgViewModel";
            udialogName = "PhbkPhoneViewUdlgViewModel";
            ddialogName = "PhbkPhoneViewDdlgViewModel";
            viewModelName = "PhbkPhoneView";
            _TableMenuItemsVM = GetDefaultTableMenuItemsVM();
            _RowMenuItemsVM = GetDefaultRowMenuItemsVM();
        }
    }
}



