using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Windows.Input;
using CommonInterfacesClassLibrary.Interfaces;
using ModelInterfacesClassLibrary.Phonebook.PhbkPhoneType;
using CommonInterfacesClassLibrary.Enums;
using CommonCustomControlLibrary.Controls;
using CommonUserControlLibrary.UserControls;


namespace ModelServicesPrismModule.Phonebook.PhbkPhoneType.UserControls {
    /// <summary>
    /// Interaction logic for PhbkPhoneTypeViewVformUserControl.xaml
    /// </summary>
    public partial class PhbkPhoneTypeViewVformUserControl: EformUserControlBase
    {
        public PhbkPhoneTypeViewVformUserControl()
        {
            InitializeComponent();
            OnLoaded();
        }


    }
}


