using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Windows.Input;
using CommonInterfacesClassLibrary.Interfaces;
using ModelInterfacesClassLibrary.Phonebook.PhbkPhone;
using CommonInterfacesClassLibrary.Enums;
using CommonCustomControlLibrary.Controls;
using CommonUserControlLibrary.UserControls;


namespace ModelServicesPrismModule.Phonebook.PhbkPhone.UserControls {
    /// <summary>
    /// Interaction logic for PhbkPhoneViewAformUserControl.xaml
    /// </summary>
    public partial class PhbkPhoneViewAformUserControl: EformUserControlBase
    {
        public PhbkPhoneViewAformUserControl()
        {
            InitializeComponent();
            OnLoaded();
        }


    }
}

