
/*

There is no code in this file. It is correct.



    "AspnetrolemaskViewUdlgUserControl" UserControl is defined in the "ModelServicesPrismModule"-project.
    In the file of IModule-class of "ModelServicesPrismModule"-project the following line of code must be inserted:

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ...
            // According to requirements of the "AspnetrolemaskViewUdlgViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            containerRegistry.RegisterDialog<AspnetrolemaskViewUdlgUserControl, EdlgViewModelBase>("AspnetrolemaskViewUdlgViewModel");
            ...
        }
*/


