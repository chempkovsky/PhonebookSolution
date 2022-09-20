using Prism.Services.Dialogs;

using CommonInterfacesClassLibrary.AppGlblSettingsSrvc;
using CommonUserControlLibrary.ViewModels;
/*



    "AspnetusermaskViewLformUserControl" UserControl is defined in the "ModelServicesPrismModule"-project.
    In the file of IModule-class of "ModelServicesPrismModule"-project the following line of code must be inserted:

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ...
            // According to requirements of the "AspnetusermaskViewLformViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            ViewModelLocationProvider.Register<AspnetusermaskViewLformUserControl, AspnetusermaskViewLformViewModel>();
            // According to requirements of the "AspnetusermaskViewLformViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            containerRegistry.Register<ContentView, AspnetusermaskViewLformUserControl>("AspnetusermaskViewLformUserControl");
            ...
        }
*/

namespace ModelServicesPrismModule.asp.aspnetusermaskView.ViewModels.Lform {
    public class AspnetusermaskViewLformViewModel:  LformViewModelBase
    {
        public AspnetusermaskViewLformViewModel(IAppGlblSettingsService GlblSettingsSrv, IDialogService dialogService):base(GlblSettingsSrv, dialogService) {
            edialogName = "";
            vdialogName = "";
            adialogName = "";
            udialogName = "";
            ddialogName = "";
        }
    }
}



