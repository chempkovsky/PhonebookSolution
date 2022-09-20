using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Windows.Input;
using CommonInterfacesClassLibrary.Interfaces;
using ModelInterfacesClassLibrary.interfaces.asp.aspnetuserView;
using CommonInterfacesClassLibrary.Enums;
using CommonCustomControlLibrary.Controls;
using CommonUserControlLibrary.UserControls;


namespace ModelServicesPrismModule.asp.aspnetuserView.UserControls {
    /// <summary>
    /// Interaction logic for AspnetuserViewUformUserControl.xaml
    /// </summary>
    public partial class AspnetuserViewUformUserControl: EformUserControlBase
    {
        public AspnetuserViewUformUserControl()
        {
            InitializeComponent();
            OnLoaded();
        }


    }
}

