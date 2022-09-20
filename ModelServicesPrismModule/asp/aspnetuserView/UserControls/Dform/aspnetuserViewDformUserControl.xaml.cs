using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Windows.Input;
using CommonInterfacesClassLibrary.Interfaces;
using ModelInterfacesClassLibrary.interfaces.asp.aspnetuserView;
using CommonInterfacesClassLibrary.Enums;
using CommonCustomControlLibrary.Controls;
using CommonUserControlLibrary.UserControls;


namespace ModelServicesPrismModule.asp.aspnetuserView.UserControls.Dform {
    /// <summary>
    /// Interaction logic for AspnetuserViewDformUserControl.xaml
    /// </summary>
    public partial class AspnetuserViewDformUserControl: EformUserControlBase
    {
        public AspnetuserViewDformUserControl()
        {
            InitializeComponent();
            OnLoaded();
        }


    }
}

