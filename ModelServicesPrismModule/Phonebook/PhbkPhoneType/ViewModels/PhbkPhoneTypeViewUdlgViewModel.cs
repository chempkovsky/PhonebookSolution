
/*

There is no code in this file. It is correct.



    "PhbkPhoneTypeViewUdlgUserControl" UserControl is defined in the "ModelServicesPrismModule"-project.
    In the file of IModule-class of "ModelServicesPrismModule"-project the following line of code must be inserted:

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ...
            // According to requirements of the "PhbkPhoneTypeViewUdlgViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            containerRegistry.RegisterDialog<PhbkPhoneTypeViewUdlgUserControl, EdlgViewModelBase>("PhbkPhoneTypeViewUdlgViewModel");
            ...
        }
*/


