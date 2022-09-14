using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Windows.Input;
using CommonInterfacesClassLibrary.Interfaces;
using ModelInterfacesClassLibrary.Phonebook.PhbkEnterprise;
using CommonInterfacesClassLibrary.Enums;
using CommonCustomControlLibrary.Controls;
using CommonUserControlLibrary.UserControls;


namespace ModelServicesPrismModule.Phonebook.PhbkEnterprise.UserControls {
    /// <summary>
    /// Interaction logic for PhbkEnterpriseViewAformUserControl.xaml
    /// </summary>
    public partial class PhbkEnterpriseViewAformUserControl: EformUserControlBase
    {
        public PhbkEnterpriseViewAformUserControl()
        {
            InitializeComponent();
            OnLoaded();
        }


    }
}

