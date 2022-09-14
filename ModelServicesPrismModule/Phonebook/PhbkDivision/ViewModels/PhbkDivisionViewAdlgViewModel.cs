
/*

There is no code in this file. It is correct.



    "PhbkDivisionViewAdlgUserControl" UserControl is defined in the "ModelServicesPrismModule"-project.
    In the file of IModule-class of "ModelServicesPrismModule"-project the following line of code must be inserted:

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ...
            // According to requirements of the "PhbkDivisionViewAdlgViewModel.cs"-file of "ModelServicesPrismModule"-project. 
            containerRegistry.RegisterDialog<PhbkDivisionViewAdlgUserControl, EdlgViewModelBase>("PhbkDivisionViewAdlgViewModel");
            ...
        }
*/


