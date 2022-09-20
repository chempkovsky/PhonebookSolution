using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Windows.Input;
using CommonInterfacesClassLibrary.Interfaces;
using ModelInterfacesClassLibrary.interfaces.asp.aspnetmodelView;
using CommonInterfacesClassLibrary.Enums;
using CommonCustomControlLibrary.Controls;
using CommonUserControlLibrary.UserControls;


namespace ModelServicesPrismModule.asp.aspnetmodelView.UserControls {
    /// <summary>
    /// Interaction logic for AspnetmodelViewDformUserControl.xaml
    /// </summary>
    public partial class AspnetmodelViewDformUserControl: EformUserControlBase
    {
        public AspnetmodelViewDformUserControl()
        {
            InitializeComponent();
            OnLoaded();
        }


    }
}

