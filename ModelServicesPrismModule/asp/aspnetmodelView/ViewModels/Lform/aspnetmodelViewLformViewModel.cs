using Prism.Services.Dialogs;

using CommonInterfacesClassLibrary.AppGlblSettingsSrvc;
using CommonUserControlLibrary.ViewModels;
/*



    "AspnetmodelViewLformUserControl" UserControl is defined in the "ModelServicesPrismModule"-project.
    In the file of IModule-class of "ModelServicesPrismModule"-project the following line of code must be inserted:

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ...
            // According to requirements of the "AspnetmodelViewLformViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            ViewModelLocationProvider.Register<AspnetmodelViewLformUserControl, AspnetmodelViewLformViewModel>();
            // According to requirements of the "AspnetmodelViewLformViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            containerRegistry.Register<ContentView, AspnetmodelViewLformUserControl>("AspnetmodelViewLformUserControl");
            ...
        }
*/

namespace ModelServicesPrismModule.asp.aspnetmodelView.ViewModels.Lform {
    public class AspnetmodelViewLformViewModel:  LformViewModelBase
    {
        public AspnetmodelViewLformViewModel(IAppGlblSettingsService GlblSettingsSrv, IDialogService dialogService):base(GlblSettingsSrv, dialogService) {
            edialogName = "";
            vdialogName = "AspnetmodelViewVdlgViewModel";
            adialogName = "AspnetmodelViewAdlgViewModel";
            udialogName = "AspnetmodelViewUdlgViewModel";
            ddialogName = "AspnetmodelViewDdlgViewModel";
            viewModelName = "aspnetmodelView";
            _TableMenuItemsVM = GetDefaultTableMenuItemsVM();
            _RowMenuItemsVM = GetDefaultRowMenuItemsVM();
        }
    }
}



