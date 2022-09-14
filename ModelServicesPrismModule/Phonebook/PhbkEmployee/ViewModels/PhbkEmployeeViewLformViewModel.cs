using Prism.Services.Dialogs;

using CommonInterfacesClassLibrary.AppGlblSettingsSrvc;
using CommonUserControlLibrary.ViewModels;
/*



    "PhbkEmployeeViewLformUserControl" UserControl is defined in the "ModelServicesPrismModule"-project.
    In the file of IModule-class of "ModelServicesPrismModule"-project the following line of code must be inserted:

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ...
            // According to requirements of the "PhbkEmployeeViewLformViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            ViewModelLocationProvider.Register<PhbkEmployeeViewLformUserControl, PhbkEmployeeViewLformViewModel>();
            // According to requirements of the "PhbkEmployeeViewLformViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            containerRegistry.Register<ContentView, PhbkEmployeeViewLformUserControl>("PhbkEmployeeViewLformUserControl");
            ...
        }
*/

namespace ModelServicesPrismModule.Phonebook.PhbkEmployee.ViewModels {
    public class PhbkEmployeeViewLformViewModel:  LformViewModelBase
    {
        public PhbkEmployeeViewLformViewModel(IAppGlblSettingsService GlblSettingsSrv, IDialogService dialogService):base(GlblSettingsSrv, dialogService) {
            edialogName = "";
            vdialogName = "PhbkEmployeeViewVdlgViewModel";
            adialogName = "PhbkEmployeeViewAdlgViewModel";
            udialogName = "PhbkEmployeeViewUdlgViewModel";
            ddialogName = "PhbkEmployeeViewDdlgViewModel";
        }
    }
}



