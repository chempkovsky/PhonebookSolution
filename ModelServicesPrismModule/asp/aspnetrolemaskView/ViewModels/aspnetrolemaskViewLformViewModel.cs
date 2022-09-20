using Prism.Services.Dialogs;

using CommonInterfacesClassLibrary.AppGlblSettingsSrvc;
using CommonUserControlLibrary.ViewModels;
/*



    "AspnetrolemaskViewLformUserControl" UserControl is defined in the "ModelServicesPrismModule"-project.
    In the file of IModule-class of "ModelServicesPrismModule"-project the following line of code must be inserted:

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ...
            // According to requirements of the "AspnetrolemaskViewLformViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            ViewModelLocationProvider.Register<AspnetrolemaskViewLformUserControl, AspnetrolemaskViewLformViewModel>();
            // According to requirements of the "AspnetrolemaskViewLformViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            containerRegistry.Register<ContentView, AspnetrolemaskViewLformUserControl>("AspnetrolemaskViewLformUserControl");
            ...
        }
*/

namespace ModelServicesPrismModule.asp.aspnetrolemaskView.ViewModels {
    public class AspnetrolemaskViewLformViewModel:  LformViewModelBase
    {
        public AspnetrolemaskViewLformViewModel(IAppGlblSettingsService GlblSettingsSrv, IDialogService dialogService):base(GlblSettingsSrv, dialogService) {
            edialogName = "";
            vdialogName = "AspnetrolemaskViewVdlgViewModel";
            adialogName = "AspnetrolemaskViewAdlgViewModel";
            udialogName = "AspnetrolemaskViewUdlgViewModel";
            ddialogName = "AspnetrolemaskViewDdlgViewModel";
        }
    }
}



