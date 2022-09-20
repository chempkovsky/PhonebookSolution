using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Windows.Input;
using CommonInterfacesClassLibrary.Interfaces;
using ModelInterfacesClassLibrary.interfaces.asp.aspnetroleView;
using CommonInterfacesClassLibrary.Enums;
using CommonCustomControlLibrary.Controls;
using CommonUserControlLibrary.UserControls;


namespace ModelServicesPrismModule.asp.aspnetroleView.UserControls.Aform {
    /// <summary>
    /// Interaction logic for AspnetroleViewAformUserControl.xaml
    /// </summary>
    public partial class AspnetroleViewAformUserControl: EformUserControlBase
    {
        public AspnetroleViewAformUserControl()
        {
            InitializeComponent();
            OnLoaded();
        }


    }
}

