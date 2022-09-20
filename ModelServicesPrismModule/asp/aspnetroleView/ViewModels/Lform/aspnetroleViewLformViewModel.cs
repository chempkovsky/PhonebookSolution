using Prism.Services.Dialogs;

using CommonInterfacesClassLibrary.AppGlblSettingsSrvc;
using CommonUserControlLibrary.ViewModels;
/*



    "AspnetroleViewLformUserControl" UserControl is defined in the "ModelServicesPrismModule"-project.
    In the file of IModule-class of "ModelServicesPrismModule"-project the following line of code must be inserted:

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ...
            // According to requirements of the "AspnetroleViewLformViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            ViewModelLocationProvider.Register<AspnetroleViewLformUserControl, AspnetroleViewLformViewModel>();
            // According to requirements of the "AspnetroleViewLformViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            containerRegistry.Register<ContentView, AspnetroleViewLformUserControl>("AspnetroleViewLformUserControl");
            ...
        }
*/

namespace ModelServicesPrismModule.asp.aspnetroleView.ViewModels.Lform {
    public class AspnetroleViewLformViewModel:  LformViewModelBase
    {
        public AspnetroleViewLformViewModel(IAppGlblSettingsService GlblSettingsSrv, IDialogService dialogService):base(GlblSettingsSrv, dialogService) {
            edialogName = "";
            vdialogName = "AspnetroleViewVdlgViewModel";
            adialogName = "AspnetroleViewAdlgViewModel";
            udialogName = "AspnetroleViewUdlgViewModel";
            ddialogName = "AspnetroleViewDdlgViewModel";
        }
    }
}



