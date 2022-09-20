using Prism.Services.Dialogs;

using CommonInterfacesClassLibrary.AppGlblSettingsSrvc;
using CommonUserControlLibrary.ViewModels;
/*



    "AspnetuserViewLformUserControl" UserControl is defined in the "ModelServicesPrismModule"-project.
    In the file of IModule-class of "ModelServicesPrismModule"-project the following line of code must be inserted:

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ...
            // According to requirements of the "AspnetuserViewLformViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            ViewModelLocationProvider.Register<AspnetuserViewLformUserControl, AspnetuserViewLformViewModel>();
            // According to requirements of the "AspnetuserViewLformViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            containerRegistry.Register<ContentView, AspnetuserViewLformUserControl>("AspnetuserViewLformUserControl");
            ...
        }
*/

namespace ModelServicesPrismModule.asp.aspnetuserView.ViewModels.Lform {
    public class AspnetuserViewLformViewModel:  LformViewModelBase
    {
        public AspnetuserViewLformViewModel(IAppGlblSettingsService GlblSettingsSrv, IDialogService dialogService):base(GlblSettingsSrv, dialogService) {
            edialogName = "";
            vdialogName = "AspnetuserViewVdlgViewModel";
            adialogName = "AspnetuserViewAdlgViewModel";
            udialogName = "AspnetuserViewUdlgViewModel";
            ddialogName = "AspnetuserViewDdlgViewModel";
        }
    }
}



