using Prism.Services.Dialogs;

using CommonInterfacesClassLibrary.AppGlblSettingsSrvc;
using CommonUserControlLibrary.ViewModels;
/*



    "AspnetuserrolesViewLformUserControl" UserControl is defined in the "ModelServicesPrismModule"-project.
    In the file of IModule-class of "ModelServicesPrismModule"-project the following line of code must be inserted:

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ...
            // According to requirements of the "AspnetuserrolesViewLformViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            ViewModelLocationProvider.Register<AspnetuserrolesViewLformUserControl, AspnetuserrolesViewLformViewModel>();
            // According to requirements of the "AspnetuserrolesViewLformViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            containerRegistry.Register<ContentView, AspnetuserrolesViewLformUserControl>("AspnetuserrolesViewLformUserControl");
            ...
        }
*/

namespace ModelServicesPrismModule.asp.aspnetuserrolesView.ViewModels.Lform {
    public class AspnetuserrolesViewLformViewModel:  LformViewModelBase
    {
        public AspnetuserrolesViewLformViewModel(IAppGlblSettingsService GlblSettingsSrv, IDialogService dialogService):base(GlblSettingsSrv, dialogService) {
            edialogName = "";
            vdialogName = "AspnetuserrolesViewVdlgViewModel";
            adialogName = "AspnetuserrolesViewAdlgViewModel";
            udialogName = "AspnetuserrolesViewUdlgViewModel";
            ddialogName = "AspnetuserrolesViewDdlgViewModel";
        }
    }
}



