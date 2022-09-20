using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Windows.Input;
using CommonInterfacesClassLibrary.Interfaces;
using ModelInterfacesClassLibrary.interfaces.asp.aspnetroleView;
using CommonInterfacesClassLibrary.Enums;
using CommonCustomControlLibrary.Controls;
using CommonUserControlLibrary.UserControls;


namespace ModelServicesPrismModule.asp.aspnetroleView.UserControls {
    /// <summary>
    /// Interaction logic for AspnetroleViewDformUserControl.xaml
    /// </summary>
    public partial class AspnetroleViewDformUserControl: EformUserControlBase
    {
        public AspnetroleViewDformUserControl()
        {
            InitializeComponent();
            OnLoaded();
        }


    }
}

