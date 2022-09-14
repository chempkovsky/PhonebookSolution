using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Windows.Input;
using CommonInterfacesClassLibrary.Interfaces;
using ModelInterfacesClassLibrary.Phonebook.PhbkDivision;
using CommonInterfacesClassLibrary.Enums;
using CommonCustomControlLibrary.Controls;
using CommonUserControlLibrary.UserControls;


namespace ModelServicesPrismModule.Phonebook.PhbkDivision.UserControls {
    /// <summary>
    /// Interaction logic for PhbkDivisionViewUformUserControl.xaml
    /// </summary>
    public partial class PhbkDivisionViewUformUserControl: EformUserControlBase
    {
        public PhbkDivisionViewUformUserControl()
        {
            InitializeComponent();
            OnLoaded();
        }


    }
}

