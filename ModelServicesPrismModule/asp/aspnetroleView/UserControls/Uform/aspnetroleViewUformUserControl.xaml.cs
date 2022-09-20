using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Windows.Input;
using CommonInterfacesClassLibrary.Interfaces;
using ModelInterfacesClassLibrary.interfaces.asp.aspnetroleView;
using CommonInterfacesClassLibrary.Enums;
using CommonCustomControlLibrary.Controls;
using CommonUserControlLibrary.UserControls;


namespace ModelServicesPrismModule.asp.aspnetroleView.UserControls.Uform {
    /// <summary>
    /// Interaction logic for AspnetroleViewUformUserControl.xaml
    /// </summary>
    public partial class AspnetroleViewUformUserControl: EformUserControlBase
    {
        public AspnetroleViewUformUserControl()
        {
            InitializeComponent();
            OnLoaded();
        }


    }
}

