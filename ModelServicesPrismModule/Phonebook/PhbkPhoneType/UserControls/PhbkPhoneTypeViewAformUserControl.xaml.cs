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
    /// Interaction logic for PhbkPhoneTypeViewAformUserControl.xaml
    /// </summary>
    public partial class PhbkPhoneTypeViewAformUserControl: EformUserControlBase
    {
        public PhbkPhoneTypeViewAformUserControl()
        {
            InitializeComponent();
            OnLoaded();
        }


    }
}

