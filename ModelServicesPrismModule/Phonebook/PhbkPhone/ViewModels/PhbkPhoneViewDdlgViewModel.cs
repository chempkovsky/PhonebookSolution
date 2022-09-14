
/*

There is no code in this file. It is correct.



    "PhbkPhoneViewDdlgUserControl" UserControl is defined in the "ModelServicesPrismModule"-project.
    In the file of IModule-class of "ModelServicesPrismModule"-project the following line of code must be inserted:

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ...
            // According to requirements of the "PhbkPhoneViewDdlgViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            containerRegistry.RegisterDialog<PhbkPhoneViewDdlgUserControl, EdlgViewModelBase>("PhbkPhoneViewDdlgViewModel");
            ...
        }
*/


