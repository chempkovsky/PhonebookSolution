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
    /// Interaction logic for PhbkPhoneTypeViewUformUserControl.xaml
    /// </summary>
    public partial class PhbkPhoneTypeViewUformUserControl: EformUserControlBase
    {
        public PhbkPhoneTypeViewUformUserControl()
        {
            InitializeComponent();
            OnLoaded();
        }


    }
}

