using Prism.Services.Dialogs;

using CommonInterfacesClassLibrary.AppGlblSettingsSrvc;
using CommonUserControlLibrary.ViewModels;
/*



    "PhbkEnterpriseViewLformUserControl" UserControl is defined in the "ModelServicesPrismModule"-project.
    In the file of IModule-class of "ModelServicesPrismModule"-project the following line of code must be inserted:

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ...
            // According to requirements of the "PhbkEnterpriseViewLformViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            ViewModelLocationProvider.Register<PhbkEnterpriseViewLformUserControl, PhbkEnterpriseViewLformViewModel>();
            // According to requirements of the "PhbkEnterpriseViewLformViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            containerRegistry.Register<ContentView, PhbkEnterpriseViewLformUserControl>("PhbkEnterpriseViewLformUserControl");
            ...
        }
*/

namespace ModelServicesPrismModule.Phonebook.PhbkEnterprise.ViewModels {
    public class PhbkEnterpriseViewLformViewModel:  LformViewModelBase
    {
        public PhbkEnterpriseViewLformViewModel(IAppGlblSettingsService GlblSettingsSrv, IDialogService dialogService):base(GlblSettingsSrv, dialogService) {
            edialogName = "";
            vdialogName = "PhbkEnterpriseViewVdlgViewModel";
            adialogName = "PhbkEnterpriseViewAdlgViewModel";
            udialogName = "PhbkEnterpriseViewUdlgViewModel";
            ddialogName = "PhbkEnterpriseViewDdlgViewModel";
            viewModelName = "PhbkEnterpriseView";
            _TableMenuItemsVM = GetDefaultTableMenuItemsVM();
            _RowMenuItemsVM = GetDefaultRowMenuItemsVM();
        }
    }
}



