
/*

There is no code in this file. It is correct.



    "PhbkPhoneTypeViewVdlgUserControl" UserControl is defined in the "ModelServicesPrismModule"-project.
    In the file of IModule-class of "ModelServicesPrismModule"-project the following line of code must be inserted:

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ...
            // According to requirements of the "PhbkPhoneTypeViewVdlgViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            containerRegistry.RegisterDialog<PhbkPhoneTypeViewVdlgUserControl, EdlgViewModelBase>("PhbkPhoneTypeViewVdlgViewModel");
            ...
        }
*/


